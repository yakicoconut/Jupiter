@echo off
title %~nx0
echo 小数点区切りバッチの使用例


: 参照バッチ
  rem 小数点区切りバッチ
  set call_SepDecimal="..\OwnLib\SepDecimal.bat"


: 処理
  : 一桁
    rem 対象値設定
    set target=1.1
    rem 小数点区切りバッチ使用
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : 少数二桁
    set target=1.12
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : 二桁
    set target=12.34
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : 整数のみ
    set target=56
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

pause