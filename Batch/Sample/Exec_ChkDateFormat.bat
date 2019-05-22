@echo off
title %~nx0
echo 日付書式判定バッチの使用例


: 参照バッチ
  rem 日付書式判定バッチ
  set call_ChkDateFormat="..\OwnLib\ChkDateFormat.bat"


: 処理
  : 複数パターン
    set target=123

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : 文字複合パターン
    set target=1a2b3c

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : 文字パターン
    set target=def

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : 「yyyy/mm/dd」パターン
    set target=0000/11/22

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : 「yy/mm/dd」パターン
    set target=33/44/55

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : 「mm/dd」パターン
    set target=66/77

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


pause