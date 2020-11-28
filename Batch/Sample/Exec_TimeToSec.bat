@echo off
title %~nx0
echo 時間秒変換バッチの使用例


: 参照バッチ
  rem 時間秒変換バッチ
  set call_TimeToSec="..\OwnLib\TimeToSec.bat"


: パターン
  rem 時間秒変換バッチ使用
  call %call_TimeToSec% 01:23:45.678
  echo %return_TimeToSec1%
  echo %return_TimeToSec2%

: パターン
  rem 時間秒変換バッチ使用
  call %call_TimeToSec% 1:23:45.67
  echo %return_TimeToSec1%
  echo %return_TimeToSec2%
pause