@echo off
title %~nx0
echo 指定VPN接続
rem 指定したVPNに接続する


: 事前
  rem 対象PPTP名
  set vpnName="PPTP-APP"

  echo %vpnName% に接続します


: 実行
  rem 接続
  start RasDial %vpnName% /connect

  REM rem 切離
  REM start RasDial %vpnName% /disconnect