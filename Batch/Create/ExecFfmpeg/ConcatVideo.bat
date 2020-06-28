@echo off
title %~nx0
echo ffmpegで動画結合


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
  if %argc%==5 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:5
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  : 対象結合リストファイルパス
    echo;
    echo 対象結合リストファイルパス入力
    echo ※結合ファイル順、箇条書き「file 'ファイル'」
    rem ユーザ入力バッチ使用
    call %call_UserInput% ※コメントは「#」 TRUE PATH
    rem 入力値引継ぎ
    set concatList=%return_UserInput1%

  : コーデック
    echo;
    echo コーデック入力(-c:v 動画ｺｰﾃﾞｯｸ -c:a 音声ｺｰﾃﾞｯｸ)
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
    rem ユーザ入力バッチ使用
    call %call_UserInput% 出力ファイル名入力 TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH STR NUM NUM STR" %1 %2 %3 %4 %5
  rem 判定結果が失敗の場合、終了へ
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set concatList=%1
    set      codec=%2
    set       rate=%3
    set        tbn=%4
    set    outPath=%5


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

    rem 動画結合
      : -y     :上書き
      : -f     :concat
      :           
      : -safe  :0
      :           
      : -i     :対象ファイル(結合動画リストファイル)
      : -c:v   :動画コーデック
      : -c:a   :音声コーデック
      : -r     :フレームレート
      : -video~:tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -f concat -safe 0 -i %concatList% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %concatList:"=%>>%logPath%
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