@echo off
title %~nx0
echo 8進数数値変換バッチの使用例


: 参照バッチ
  rem 8進数数値変換バッチ
  set call_CngOctalNum="..\OwnLib\CngOctalNum.bat"


: 00
  rem 8進数数値変換バッチ使用
  call %call_CngOctalNum% 00
  echo %return_CngOctalNum%

: 01
  rem 8進数数値変換バッチ使用
  call %call_CngOctalNum% 01
  echo %return_CngOctalNum%

: 08
  rem 8進数数値変換バッチ使用
  call %call_CngOctalNum% 08
  echo %return_CngOctalNum%

: 09
  rem 8進数数値変換バッチ使用
  call %call_CngOctalNum% 09
  echo %return_CngOctalNum%


pause