@echo off
title %~nx0
echo ffmpegで動画に画像を合成
: ffmpeg 動画にウォーターマーク（ロゴ）をつけてみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-80.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ユーザ入力処理
  : 背景動画ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 背景動画ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%

  : 合成動画ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 合成動画ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set compPath=%return_UserInput1%

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


: 画像合成実行
  : 
  : 
  : 
  : 
  : 
  : 
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -i %compPath% -filter_complex overlay %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  pause


exit


rem 時刻解体サブルーチン
:DISMANTLE_TIME
SETLOCAL
  : 引数
    rem 入力時刻
    set inpTime=%1
    rem 時刻フォーマット
    set format=%2

  : ミリ秒が存在する場合
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-3,2%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-4,3%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-5,4%
    )

  : 先頭「m」、「h」、「hh」判断
    if %format:~0,2%==mm (
      set tms="00:%inpTime:~1,5%"
    )
    if %format:~0,2%==h: (
      set tms="0%inpTime:~1,7%"
    )
    if %format:~0,3%==hh: (
      rem 「hh」の場合もミリ秒を抜く
      set tms="%inpTime:~1,8%"
    )

rem 返り値1:時分秒
rem 返り値2:ミリ秒
ENDLOCAL && set ret_DISMANTLE_TIME01=%tms%&& set ret_DISMANTLE_TIME02=%milli%
exit /b