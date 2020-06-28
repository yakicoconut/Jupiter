@echo off
title %~nx0
echo ffmpegで音量調整
: ffmpeg で音のボリュームを調整する。gain 調整 - それマグで！
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014


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
  if %argc%==6 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:6
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

  : 指定ボリューム入力
    echo;
    echo 指定ボリューム入力(少数で指定「x.x」)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set vol=%return_UserInput1%

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
  call %call_ChkArgDataType% "PATH NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set srcPath=%1
    set     vol=%~2
    set   codec=%3
    set    rate=%4
    set     tbn=%5
    set outPath=%6


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

    rem 音量調整
      : -y     :上書き
      : -i     :対象ファイル
      : -af    :"volume=数値"
      :           音量調整
      :           (例1:音量指定アップ
      :                -af "volume=+5dB"
      :           (例2:音量指定ダウン
      :                -af "volume=-5dB"
      :           (例3:音量%アップ
      :                -af "volume=1.5"
      : -async:数値
      :          音声サンプルを Stretch/Squeeze (つまりサンプルの持続時間を変更) して同期する
      :          数値(1~1000)は音がズレたときに1秒間で何サンプルまで変更していいかを指定する
      :          「1」指定は特別で、音声の最初だけ同期して後続のサンプルはそのまま
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -async 1 -af "volume=%vol%" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %vol:"=%>>%logPath%
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