@echo off
title %~nx0
echo ゼロ埋めバッチの使用例


: 参照バッチ
  rem ゼロ埋めバッチ
  set call_ZeroPadding="..\OwnLib\ZeroPadding.bat"


: ゼロ埋めモード_4桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 123 4
  echo %return_ZeroPadding%

: ゼロ埋めモード_10桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 123 10
  echo %return_ZeroPadding%


: 下駄モード_5桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 4 -5
  echo %return_ZeroPadding%

: 下駄モード_10桁パターン
  rem ゼロ埋めバッチ使用
  call %call_ZeroPadding% 56789 -10
  echo %return_ZeroPadding%


pause