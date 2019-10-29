@echo off
title %~nx0
echo ffmpegで文字列挿入
: ffmpegで動画上にテキストを描画する - Qiita
: 	https://qiita.com/niusounds/items/797fe0743a9d59681446


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%

  : 挿入テキスト
    echo;
    echo 挿入テキスト入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set txt=%return_UserInput1%

  : 開始時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %start% %targetTimeFormat%
    set start=%ret_DISMANTLE_TIME01%
    set startMilli=%ret_DISMANTLE_TIME02%

  : 完了時間
    echo;
    echo 完了時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %dist% %targetTimeFormat%
    set dist=%ret_DISMANTLE_TIME01%
    set distMilli=%ret_DISMANTLE_TIME02%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 秒数変換
  : 開始時間
    rem 経過時間計算バッチ使用
    call %call_ElapsedTime% 00:00:00 %start:"=%
    set startElapsed=%return_ElapsedTime%

    rem 秒数変換サブルーチン使用
    call :CONV_SEC %startElapsed%
    set starSec=%ret_CONV_SEC%

  : 完了時間
    rem 経過時間計算バッチ使用
    call %call_ElapsedTime% 00:00:00 %dist:"=%
    set distElapsed=%return_ElapsedTime%

    rem 秒数変換サブルーチン使用
    call :CONV_SEC %distElapsed%
    set distSec=%ret_CONV_SEC%


: 実行
  rem tbn変更
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -filter_complex "drawtext=fontfile=/path/to/fontfile:text=%txt%:enable='between(t,%starSec%%startMilli%,%distSec%%distMilli%)" %outPath%
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


rem 秒数変換サブルーチン
:CONV_SEC
SETLOCAL
  : 引数
    rem 時間
    set formalTime=%1

  : 項目分割
    rem 文字列として分割
    set   strHour=%formalTime:~0,2%
    set strMinute=%formalTime:~3,2%
    set strSecond=%formalTime:~6,2%

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

  : 数値変換
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

  : 秒数変換
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a   secTime=%secHour%+%secMinute%+%second%

rem 戻り値:秒数
ENDLOCAL && set ret_CONV_SEC=%secTime%
exit /b