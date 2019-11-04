@echo off
title %~nx0
echo 少数計算バッチの使用例


: 参照バッチ
  rem 少数計算バッチ
  set call_CalcDecimal="..\OwnLib\CalcDecimal.bat"


: 処理
  REM echo;
  REM echo 1.0パターン
  REM   rem 対象値設定
  REM   set left=1.0
  REM   set right=1.0

  REM   rem 数値判定バッチ使用
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo 左右辺別パターン
  REM   set left=1.2
  REM   set right=3.4
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo 繰り上がりパターン
  REM   set left=5.6
  REM   set right=7.8
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo   %return_CalcDecimal%

  REM echo;
  REM echo 二桁パターン
  REM   set left=1.23
  REM   set right=4.56
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo 二桁繰り上げパターン
  REM   set left=1.88
  REM   set right=1.12
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo 桁違いパターン
  REM   set left=1.23
  REM   set right=4.5
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

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

pause