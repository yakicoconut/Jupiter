@echo off
title %~nx0
echo 少数計算バッチの使用例


: 参照バッチ
  rem 少数計算バッチ
  set call_CalcDecimal="..\OwnLib\CalcDecimal.bat"


: 処理
  echo;
  echo 1.0パターン
    rem 対象値設定
    set left=1.0
    set right=1.0

    rem 数値判定バッチ使用
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    2.0 ←期待結果

  echo;
  echo 左右辺別パターン
    set left=1.2
    set right=3.4
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    4.6 ←期待結果

  echo;
  echo 繰り上がりパターン
    set left=5.6
    set right=7.8
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo   %return_CalcDecimal%
    echo   13.4 ←期待結果

  echo;
  echo 二桁パターン
    set left=1.23
    set right=4.56
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    5.79 ←期待結果

  echo;
  echo 二桁繰り上げパターン
    set left=1.88
    set right=1.12
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    3.00 ←期待結果

  echo;
  echo 桁違いパターン
    set left=1.23
    set right=4.5
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    5.73 ←期待結果

  echo;
  echo 第一位0パターン
    set left=1.08
    set right=4.09
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    5.17 ←期待結果

  echo;
  echo 第一位0(左辺のみ)繰り上がりパターン
    set left=0.02
    set right=9.99
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    10.01 ←期待結果

  echo;
  echo 第一位0(右辺のみ)桁違いパターン
    set left=1.23
    set right=0.0234
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    1.2534 ←期待結果

pause