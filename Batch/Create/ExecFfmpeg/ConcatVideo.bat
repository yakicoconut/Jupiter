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


: 実行
  rem 結合
    : -f concat:
    : -safe 0  :
    : -i       :
    : -c copy  :
  ffmpeg\win32\ffmpeg.exe -f concat -safe 0 -i %concatList% %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  pause