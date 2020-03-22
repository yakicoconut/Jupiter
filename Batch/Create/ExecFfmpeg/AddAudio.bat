@echo off
title %~nx0
echo ffmpegで音声追加
: FFmpegを利用した動画の合成、クロマキー合成 - Qiita
: 	https://qiita.com/developer-kikikaikai/items/47a13cbcb6fdb535345a
: ffmpegを使って動画と音声を結合する方法 | 非IT企業に勤める中年サラリーマンのIT日記
: 	http://pineplanter.moo.jp/non-it-salaryman/2019/04/21/ffmpeg-join/


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ユーザ入力処理
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
    set audioPath=%return_UserInput1%

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


: 実行
  rem 音声合成
  ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -map 0:v:0 -map a:a:0 %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% %outPath%
  REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -r %rate% -video_track_timescale %tbn% %outPath%
  pause