@echo off
title %~nx0
echo 数値判定バッチの使用例


: 参照バッチ
  rem 数値判定バッチ
  set call_ChkNum="..\OwnLib\ChkNum.bat"


: 処理
  : 単数パターン
    rem 対象値設定
    set target=9

    rem 数値判定バッチ使用
    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : 複数パターン
    set target=123

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : 少数パターン
    set target=1.5

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : 文字複合パターン
    set target=1a2b3c

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : 文字パターン
    set target=def

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : 時間パターン
    set target=10:50

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


pause