@echo off
title %~nx0
echo ffmpegで動画情報を取得する


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set inPath=%return_UserInput1%


: 実行
  rem 分割実行
  ffmpeg\win32\ffprobe.exe %inPath%
  pause