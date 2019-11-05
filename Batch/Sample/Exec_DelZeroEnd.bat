@echo off
title %~nx0
echo ゼロ末尾削除バッチの使用例


: 参照バッチ
  rem 数値判定バッチ
  set call_DelZeroEnd="..\OwnLib\DelZeroEnd.bat"


: 処理
  : 二桁
    rem 対象値設定
    set target=10

    rem 数値判定バッチ使用
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : 三桁
    set target=200
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : ゼロなし
    set target=345
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : ゼロのみ
    set target=0
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : ゼロゼロ
    set target=00
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

pause