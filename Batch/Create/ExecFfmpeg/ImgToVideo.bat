@echo off
title %~nx0
echo ffmpegで画像から動画生成
: FFMPEGで1枚の静止画から動画を作成する | 技術的特異点
: 	http://tecsingularity.com/ffmpeg/make-movie/
: 動画操作ソフト ffmpeg のエラー "width not divisible by 2" への対処 - Qiita
: 	https://qiita.com/genchi-jin/items/90078b6ec751fdacbc9e

: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==6 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:6
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

  : 動画時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 動画時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set movieTime=%return_UserInput1%
    set movieTimeFmt=%return_UserInput2%

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

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType1%==0 goto :EOF
  rem 型判定結果引継ぎ
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType2%) do (
    rem 時刻フォーマット取得
    set movieTimeFmt=%%a
  )

  : 引数引継ぎ
    set   srcPath=%1
    set movieTime="%2"
    set     codec=%3
    set      rate=%4
    set       tbn=%5
    set   outPath=%6


rem 本処理
:RUN
  : 動画時間秒数変換
    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %movieTime% %movieTimeFmt%
    set movieTime=%ret_DISMANTLE_TIME01:"=%
    set movieTimeMilli=%ret_DISMANTLE_TIME02%

    rem 文字列として分割
    set   strHour=%movieTime:~0,2%
    set strMinute=%movieTime:~3,2%
    set strSecond=%movieTime:~6,2%

    rem 二桁目が「0」の場合
    if %strHour:~0,1%==0 (
      rem 数値型に格納するとエラーとなるため、一桁目のみ取得
      set strHour=%strHour:~1,1%
    )
    if %strMinute:~0,1%==0 (
      set strMinute=%strMinute:~1,1%
    )
    if %strSecond:~0,1%==0 (
      set strSecond=%strSecond:~1,1%
    )

    rem 数値変換
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

    rem 秒数変換
    set /a      secHour=%hour%*3600
    set /a    secMinute=%minute%*60
    set /a movieTimeSec=%secHour%+%secMinute%+%second%

  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 画像取得実行
      : -y      :上書き
      : -loop   :1
      :            
      : -i      :対象ファイル
      : -c:v    :動画コーデック(「h264」指定)
      : -pix_fmt:yuv420p
      :            
      : ^vf     :"scale=trunc(iw/2)*2:trunc(ih/2)*2"
      :            
      : -t      :対象期間(秒)
      : -r      :フレームレート
      : -video~ :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -loop 1 -i %srcPath% -pix_fmt yuv420p -vf "scale=trunc(iw/2)*2:trunc(ih/2)*2" -t %movieTimeSec%%movieTimeMilli% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %movieTime:"=%%movieTimeMilli%>>%logPath%
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