@echo off
title %~nx0
echo ffmpegで動画結合


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ユーザ入力処理
  : 対象結合リストファイルパス
    echo;
    echo 対象結合リストファイルパス入力
    echo ※結合ファイル順、箇条書き「file 'ファイル'」
    rem ユーザ入力バッチ使用
    call %call_UserInput% ※コメントは「#」 TRUE PATH
    rem 入力値引継ぎ
    set concatList=%return_UserInput1%


  : 出力ファイル名
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 出力ファイル名入力 TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 実行
  rem 分割実行
    : -f   :
    : -safe:
    : -i   :
    : -c   :
  ffmpeg\win32\ffmpeg.exe -f concat -safe 0  -i %concatList% -c copy %outPath%
  rem 結合_別解
REM   ffmpeg\ffmpeg.exe -f concat -safe 0  -i %concatList% -vcodec h264 -acodec aac -strict experimental %outPath%