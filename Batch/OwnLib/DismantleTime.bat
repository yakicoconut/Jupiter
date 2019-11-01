@echo off
title %~nx0
rem 時分秒ミリ解体バッチ
rem 引数01:対象時刻
rem 引数02:対象時刻フォーマット
rem 戻値01:時分秒
rem 戻値02:ミリ秒


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 入力時刻
    set inpTime=%~1
    rem 時刻フォーマット
    set format=%~2

    rem ねずみ返し_フォーマットが指定されていない
    if "%format%"=="" (
      echo;
      echo フォーマットが指定されていません
      echo 終了します
      pause
      exit
    )

  : ミリ秒が存在する場合
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-1,1%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-2,2%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-3,3%
    )

  : 先頭「m」、「h」、「hh」判断
    if %format:~0,2%==mm (
      set tms=00:%inpTime:~0,5%
    )
    if %format:~0,2%==h: (
      set tms=0%inpTime:~0,7%
    )
    if %format:~0,3%==hh: (
      rem 「hh」の場合もミリ秒を抜く
      set tms=%inpTime:~0,8%
    )


rem 戻り値
ENDLOCAL && set return_DismantleTime1=%tms%&& set return_DismantleTime2=%milli%
exit /b