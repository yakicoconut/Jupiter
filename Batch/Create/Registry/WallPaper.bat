@echo off
title %~nx0
echo 壁紙変更(要再起動)


: 宣言
  rem 壁紙ファイル位置
  set wallPaper="E:\MyFiles-P00486\My-Doc\DOC_写真\壁紙\269_w5.jpg"

  rem レジストリパス
  set targetKey="HKEY_CURRENT_USER\Control Panel\Desktop"


: 実行
  rem レジストリ内の壁紙ファイルの更新
  reg add %targetKey% /v "Wallpaper" /t REG_SZ /d %wallPaper% /f


pause