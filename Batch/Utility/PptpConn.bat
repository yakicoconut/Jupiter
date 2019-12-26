@echo off
title %~nx0
echo 指定VPN接続
rem 指定したVPNに接続する


: 宣言
  rem 対象PPTP名
  set vpnName="PPTP-APP"

  : 引数
    rem ユーザ名
    set user=%~1
    rem パスワード
    set pass=%~2

  : 引数有無
    if "%user%"=="" (
      echo;
      echo ユーザ名入力
      set /P user="入力してください:"
    )
    if "%pass%"=="" (
      echo;
      echo パスワード入力
      set /P pass="入力してください:"
    )


: 実行
  rem 接続
  start RasDial %vpnName% %user% %pass%
  pause