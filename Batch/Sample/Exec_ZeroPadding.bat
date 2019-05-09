@echo off
title %~nx0
echo ゼロ埋めバッチの使用例


: 参照バッチ
  rem ゼロ埋めバッチ
  set call_ZeroPadding="..\OwnLib\ZeroPadding.bat"


: 4桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 123 4
  echo %return_ZeroPadding%


: 10桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 123 10
  echo %return_ZeroPadding%


pause