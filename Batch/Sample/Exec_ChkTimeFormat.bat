@echo off
title %~nx0
echo 時刻判定バッチの使用例


: 参照バッチ
  rem 時刻判定バッチ
  set call_ChkTimeFormat="..\OwnLib\ChkTimeFormat.bat"


: 処理
  : 複数パターン
    set target=123

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 文字複合パターン
    set target=1a2b3c

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 文字パターン
    set target=def

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「m;s」パターン
    set target=1:0

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「mm;s」パターン
    set target=10:5

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「m:ss」パターン
    set target=0:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「mm:ss」パターン
    set target=12:51

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「h:m;s」パターン
    set target=4:5:4

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「h:mm;s」パターン
    set target=3:10:2

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「h:m:ss」パターン
    set target=5:4:20

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「h:mm:ss」パターン
    set target=6:10:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「hh:m;s」パターン
    set target=14:1:5

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「hh:mm;s」パターン
    set target=21:10:0

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「hh:m:ss」パターン
    set target=11:1:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


  : 「hh:mm:ss」パターン
    set target=12:34:56.78

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat1%
    echo %return_ChkTimeFormat2%
    echo ---------------


pause