@echo off
title %~nx0
echo ffmpegで画像取得
: ffmpegで動画から静止画を抜き出す - Qiita
: 	https://qiita.com/matoken/items/664e7a7e8f31e8a46a6:
: ffmpegデフォルト出力フレームレート
: 	https://avp.stackovernet.com/ja/q/6007
: 注意
:   開始時間を途中に設定するとその位置まで処理待ちとなる


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
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
    echo 対象fps
    echo r_frame_rate  :全タイムスタンプを正確に表すことができる
    echo                最低のフレームレート(ストリーム内のすべての
    echo                フレームレートの最小公倍数)
    echo avg_frame_rate:平均フレームレート
    rem 動画情報取得バッチ使用
    rem 対象動画fpsのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v -show_entries stream=r_frame_rate -show_entries stream=avg_frame_rate" %srcPath%

  : 開始時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

  : 分割時間
    echo;
    echo 分割時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set distFmt=%return_UserInput2%

  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH TIME TIME NUM" %1 %2 %3 %4
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType1%==0 goto :EOF
  rem 型判定結果引継ぎ
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType2%) do (
    rem 時刻フォーマット取得
    set starFmt=%%a
    set distFmt=%%b
  )

  : 引数引継ぎ
    set srcPath=%1
    set   start="%2"
    set    dist="%3"
    set    rate=%4


rem 本処理
:RUN
  : 開始時間秒数変換
    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %start% %starFmt%
    set start=%ret_DISMANTLE_TIME01:"=%
    set startMilli=%ret_DISMANTLE_TIME02%

    rem 文字列として分割
    set   strHour=%start:~0,2%
    set strMinute=%start:~3,2%
    set strSecond=%start:~6,2%

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
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a  startSec=%secHour%+%secMinute%+%second%


  : 分割時間秒数変換
    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %dist% %distFmt%
    set dist=%ret_DISMANTLE_TIME01%
    set distMilli=%ret_DISMANTLE_TIME02%

    rem 経過時間計算バッチ使用
    call %call_ElapsedTime% %start:"=% %dist:"=%
    set elapsed=%return_ElapsedTime%

  : 項目分割
    rem 文字列として分割
    set   strHour=%elapsed:~0,2%
    set strMinute=%elapsed:~3,2%
    set strSecond=%elapsed:~6,2%

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
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a    length=%secHour%+%secMinute%+%second%


  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 画像取得実行
    : -i :動画指定
    : -ss:開始位置(秒)
    : -t :対象期間(秒)
    : -r :1秒あたり何枚抜き出すか
    :     fps(フレームレート)の確認は「ffprobe.exe 対象動画」
    : -f :「image2 %%06d.jpg」指定で「000001.jpg」から連番出力指定
    %~dp0ffmpeg\win32\ffmpeg.exe -i %srcPath% -ss %startSec%%startMilli% -t %length%%distMilli% -r %rate% -f image2 Img_%%06d.png


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %start:"=%%startMilli%>>%logPath%
  echo %dist:"=%%distMilli%>>%logPath%
  echo %rate:"=%>>%logPath%
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