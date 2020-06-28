@echo off
title %~nx0
echo ffmpegで動画からGif生成
: ffmpegの基本的な使い方 | | Gnzo Labo
: 	https://apiwb01.gnzo.com/labo/archives/100
: FFmpegで動画をGIFに変換 - Qiita
: 	https://qiita.com/wMETAw/items/fdb754022aec1da88e6e


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 動画情報取得バッチ
  set call_GetMpegInfo=%~dp0"GetMpegInfo.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==4 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:4
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

    echo;
    echo 対象フレームレート
    rem 動画情報取得バッチ使用
    rem フレームレートのみ取得オプション
    call %call_GetMpegInfo% "-v error -show_entries stream=r_frame_rate -i" %srcPath%

    echo;
    echo 対象画面サイズ
    rem 動画情報取得バッチ使用
    rem 画面サイズのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %srcPath%

  : 出力サイズ
    echo;
    echo 出力サイズ(HeightxWidth)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set size=%return_UserInput1%

  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%

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
  call %call_ChkArgDataType% "PATH STR NUM STR" %1 %2 %3 %4
  rem 判定結果が失敗の場合、終了へ
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set srcPath=%1
    set    size=%2
    set    rate=%3
    set outPath=%4


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

    rem Gif生成
      : -y      :上書き
      : -i      :対象ファイル
      : -an     :
      : -r      :フレームレート
      : -pix_fmt:rgb24
      :           
      : -f      :gif
      :           
      : -s      :
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -an -r %rate% -pix_fmt rgb24 -f gif -s %size% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %size:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause