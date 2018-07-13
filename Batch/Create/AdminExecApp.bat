@echo off
title %~nx0
echo 指定exeを管理者実行する


: 事前準備
  rem 対象exeパス
  set targetApp="C:\Windows\system32\cmd.exe /k"


: アプリ実行
  rem パワーシェルを使用して対象exeを管理者実行
  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %targetApp:"=% -Verb runas"