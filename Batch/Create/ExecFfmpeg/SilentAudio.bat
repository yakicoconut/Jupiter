@echo off
title %~nx0
echo ffmpegで動画無音化
: FFmpegで動画の一部を無音にするときは音声を削除せずに無音データで埋めないとダメ
: 	https://hori-ryota.com/blog/ffmpeg-mp4-part-to-silence-nosound-missing/


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 5 "PATH STR NUM NUM STR" %1 %2 %3 %4 %5
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set srcPath=%1
  set   codec=%2
  set    rate=%3
  set     tbn=%4
  set outPath=%5

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

  : コーデック
    echo;
    echo コーデック入力(-c:v 動画Codec)
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

    rem 分割実行
      : -y       :上書き
      : -i       :対象ファイル
      : -f       :lavf
      :             
      : -i       :aevalsrc=0
      :             
      : -c:v     :動画コーデック
      :           copy
      :             
      : -map     :0:0
      :             
      :          :1:0
      :            
      : -shortest:最短の入力ストリームが終了したらエンコード終了
      : -ac      :2
      :             
      : -strict  :-2
      :             
      : -c:v     :動画コーデック
      : -c:a     :音声コーデック
      : -r       :フレームレート
      : -video~  :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -f lavfi -i aevalsrc=0 %codec:"=% -map 0:0 -map 1:0 -shortest -ac 2 -strict -2 -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause

exit /b


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