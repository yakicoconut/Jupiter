@echo off
title %~nx0
echo ffmpegで再生速度調整
: ffmpegを使って動画の再生速度を変えてみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-36.html
: 映像と音声の pts を扱う setpts, asetpts | ニコラボ
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/
: ffmpegの使い方やコマンド一覧をまとめました。動画リサイズ・静止画変換・フレーム補間について|おちゃカメラ。
: 	https://photo-tea.com/p/17/ffmpeg-command-list/


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 6 "PATH NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set  srcPath=%1
  set spdRatio=%2
  set    codec=%3
  set     rate=%4
  set      tbn=%5
  set  outPath=%6

  rem 本処理へ
  goto :RUN


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set srcPath=%return_UserInput1%

  : 倍速比入力
    echo;
    echo 倍速比入力(少数で指定「x.x」)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set spdRatio=%return_UserInput1%

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

    rem 動画速度調整
      : -y     :上書き
      : -i     :対象ファイル
      : -vf    :setpts=PTS/数値
      :           (例1:
      : -af    :atempo=数値
      :           (例1:
      : -c:v   :動画コーデック
      : -c:a   :音声コーデック
      : -r     :フレームレート
      : -video~:tbn
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -vf setpts=PTS/%spdRatio% -af atempo=%spdRatio% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %spdRatio:"=%>>%logPath%
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