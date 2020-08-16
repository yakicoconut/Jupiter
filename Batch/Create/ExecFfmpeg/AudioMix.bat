@echo off
title %~nx0
echo ffmpegで音声合成
: audio - ffmpegを使用して2つのオーディオファイルをオーバーレイ/ダウンミックスする方法 - ITツールウェブ
: 	https://ja.coder.work/so/audio/105491
: FFmpeg Filters Documentation
: 	https://ffmpeg.org/ffmpeg-filters.html#amix


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 4 "PATH PATH NUM STR" %1 %2 %3 %4
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set srcPath=%1
  set mixPath=%2
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

  : 対象音声ファイル
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象音声ファイル入力 TRUE PATH
    rem 入力値引継ぎ
    set mixPath=%return_UserInput1%

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
      : -y      :上書き
      : -i      :対象ファイル(2以上のミックスにも対応)
      : -filter~:amix=
      :            音声合成
      :            inputs=
      :              対象ファイル数指定
      :              デフォルト2
      :              「-i」オプションで指定した数
      :            duration=
      :              出力ファイルの長さ(省略可)
      :              longest
      :                規定
      :                対象ファイルの内、最も長いものに合わせる
      :              shortest
      :                短いものに合わせる
      :              first
      :                一つ目のファイルに合わせる
      : -acodec :
      :          libmp3lame
      :            
      : -ab     :ビットレート指定
      :          k指定
      :          →低すぎる場合、以下警告出力
      :            (例:「192」指定→「Bitrate 192 is extremely low, maybe you mean 192k」
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %mixPath% -filter_complex amix="inputs=2:duration=first" -acodec libmp3lame -ab %bitRate%k %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %mixPath:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause

exit /b