@echo off
title %~nx0
echo ffmpegで動画からGif生成
: ffmpegの基本的な使い方 | | Gnzo Labo
: 	https://apiwb01.gnzo.com/labo/archives/100
: FFmpegで動画をGIFに変換 - Qiita
: 	https://qiita.com/wMETAw/items/fdb754022aec1da88e6e


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 動画情報取得バッチ
  set call_GetMpegInfo="GetMpegInfo.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%

    echo;
    echo 対象フレームレート
    rem 動画情報取得バッチ使用
    rem フレームレートのみ取得オプション
    call %call_GetMpegInfo% "-v error -show_entries stream=r_frame_rate -i" %sourcePath%

    echo;
    echo 対象画面サイズ
    rem 動画情報取得バッチ使用
    rem 画面サイズのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %sourcePath%

  : フレームレート
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% フレームレート TRUE NUM
    rem 入力値引継ぎ
    set fps=%return_UserInput1%

  : 出力サイズ
    echo;
    echo 出力サイズ入力
    echo ※(HEIGHTxWIDTH)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set size=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 実行
  rem Gif生成
  ffmpeg\win32\ffmpeg.exe -i  %sourcePath% -an -r %fps% -pix_fmt rgb24 -f gif -s %size% %outPath%
  pause