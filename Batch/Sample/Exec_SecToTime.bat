@echo off
title %~nx0
echo 秒時間変換バッチの使用例


: 参照バッチ
  rem 秒時間変換バッチ
  set call_SecToTime="..\OwnLib\SecToTime.bat"


: 処理
  rem 秒時間変換バッチ使用
  call %call_SecToTime% 5025
  echo %return_SecToTime%
pause