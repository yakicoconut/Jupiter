@echo off
title %~nx0
echo 時分秒ミリ解体バッチの使用例


: 参照バッチ
  rem 時分秒ミリ解体バッチ
  set call_DismantleTime="..\OwnLib\DismantleTime.bat"
  rem 時刻書式判定バッチ
  set call_ChkTimeFormat="..\OwnLib\ChkTimeFormat.bat"


: 処理
  : 「mm:ss」パターン
    set target=12:51

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

rem ※「mm:ss.f」の定義が「ChkTimeFormat.bat」にないためコメント
  REM : 「mm:ss.f」パターン
  REM   set target=12:51.1

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------

  REM : 「mm:ss.ff」パターン
  REM   set target=12:51.12

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------

  REM : 「mm:ss.fff」パターン
  REM   set target=12:51.123

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------


  : 「h:mm:ss」パターン
    set target=6:10:50

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「h:mm:ss.f」パターン
    set target=6:10:50.4

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「h:mm:ss.ff」パターン
    set target=6:10:50.45

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「h:mm:ss.fff」パターン
    set target=6:10:50.456

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------


  : 「hh:mm:ss」パターン
    set target=12:34:56

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「hh:mm:ss.f」パターン
    set target=12:34:56.7

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「hh:mm:ss.ff」パターン
    set target=12:34:56.78

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : 「hh:mm:ss.fff」パターン
    set target=12:34:56.789

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

pause