@echo off
title %~nx0
echo ffmpegで画面サイズ変更
: FFprobeTips ? FFmpeg
: 	https://trac.ffmpeg.org/wiki/FFprobeTips


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
    echo 対象画面サイズ
    rem 動画情報取得バッチ使用
    rem 画面サイズのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %sourcePath%

  : クロップ指定入力
    echo;
    echo クロップ指定入力
    echo ※出力Xｻｲｽﾞ:出力Yｻｲｽﾞ:対象Xｵﾌｾｯﾄ:対象Yｵﾌｾｯﾄ
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set crop=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

: 実行
  rem 音量調整
  : -i                :元ファイル
  : -vf crop=a:b:c:d  :クロップ設定
  :                    a:出力Xサイズ
  :                    b:出力Yサイズ
  :                    c:対象Xオフセット
  :                    d:対象Yオフセット
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -vf crop=%crop% %outPath%
  pause