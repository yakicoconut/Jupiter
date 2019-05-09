@echo off
title %~nx0
echo TortoiseSVN更新


: 宣言
  rem 対象SVNフォルダ
  set targetDir="E:\MyFiles-P00486\My-SVN"


: 実行
  rem 対象SNV直下、全フォルダ更新
  cd %targetDir%
  for /d %%i in (*) do call :UPDATE_SVN %%i

  exit


rem SVN更新サブルーチン
:UPDATE_SVN
  echo %1 を更新しています...
  TortoiseProc.exe /command:update /path:%1 /notempfile /closeonend:1
  exit /b