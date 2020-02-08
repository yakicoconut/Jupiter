@echo off
title %~nx0
echo 日本語キーボード設定


: 宣言
  rem 日本語設定
  set value="kbd106.dll"

  rem レジストリパス
  set targetKey="HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\i8042prt\Parameters"


: 実行
  rem レジストリ更新
  reg add %targetKey% /v "LayerDriver JPN" /t REG_SZ /d %value% /f


pause