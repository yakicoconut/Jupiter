@echo off
title %~nx0
echo ffmpegで音声ファイル音量調整


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 4 "PATH NUM NUM STR" %1 %2 %3 %4
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  : 引数引継ぎ
    set srcPath=%1
    set     vol=%~2
    set bitRate=%3
    set outPath=%4

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

  : 指定ボリューム入力
    echo;
    echo 指定ボリューム入力(少数で指定「x.x」)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set vol=%return_UserInput1%

  : ビットレート入力
    echo;
    echo 出力ビットレート入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set bitRate=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

    rem 本処理へ
    goto :RUN


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
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -af "volume=%vol%" -acodec libmp3lame -ab %bitRate%k %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %vol:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause

exit /b