@echo off
title %~nx0
echo ffmpegで音声追加
: FFmpegを利用した動画の合成、クロマキー合成 - Qiita
: 	https://qiita.com/developer-kikikaikai/items/47a13cbcb6fdb535345a
: ffmpegを使って動画と音声を結合する方法 | 非IT企業に勤める中年サラリーマンのIT日記
: 	http://pineplanter.moo.jp/non-it-salaryman/2019/04/21/ffmpeg-join/
: ffmpegを使って映像と音声を結合する - Qiita
: 	https://qiita.com/niusounds/items/f69a4438f52fbf81f0bd
: android - ffmpegで動画と音声を結合するときに先頭に無音を追加するには - スタック・オーバーフロー
: 	https://ja.stackoverflow.com/questions/18161/ffmpeg%E3%81%A7%E5%8B%95%E7%94%BB%E3%81%A8%E9%9F%B3%E5%A3%B0%E3%82%92%E7%B5%90%E5%90%88%E3%81%99%E3%82%8B%E3%81%A8%E3%81%8D%E3%81%AB%E5%85%88%E9%A0%AD%E3%81%AB%E7%84%A1%E9%9F%B3%E3%82%92%E8%BF%BD%E5%8A%A0%E3%81%99%E3%82%8B%E3%81%AB%E3%81%AF


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==7 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:7
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set srcPath=%return_UserInput1%

  : 対象音声ファイル
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象音声ファイル入力 TRUE PATH
    rem 入力値引継ぎ
    set audioPath=%return_UserInput1%

  : 開始時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

  : コーデック
    echo;
    echo コーデック入力(-c:v 動画Codec -c:a 音声Codec)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set codec=%return_UserInput1:"=%

  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%

  : tbn入力
    echo;
    echo tbn入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set tbn=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH PATH TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7
  rem 判定結果が失敗の場合、終了へ
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set   srcPath=%1
    set audioPath=%2
    set     start=%3
    set     codec=%4
    set      rate=%5
    set       tbn=%6
    set   outPath=%7


rem 本処理
:RUN
  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 音声合成
      : -y        :上書き
      : -i        :対象ファイル
      : -itsoffset:開始時間
      :            挿入ファイルより前に記述必須
      : -map      :
      : -c:v      :動画コーデック
      : -c:a      :音声コーデック
      : -r        :フレームレート
      : -video~   :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -itsoffset %start:"=% -i %audioPath% -map 0:v:0 -map 1:a:0 %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%
    REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% %outPath%
    REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %audioPath:"=%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause

exit /b