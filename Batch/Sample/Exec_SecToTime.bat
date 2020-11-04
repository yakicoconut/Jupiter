@echo off
title %~nx0
echo 時間秒変換バッチの使用例


: 参照バッチ
  rem 時間秒変換バッチ
  set call_SecToTime="..\OwnLib\SecToTime.bat"


: 処理
  rem 時間秒変換バッチ使用
  call %call_SecToTime% 5025
  echo %return_SecToTime%
pause