@echo off
title %~nx0
echo Msinfo32コマンド結果取得
echo ※ファイル名は年月日+シリアルナンバー
echo ※管理者実行が必要な可能性あり


: msinfo32実行
  rem 本バッチ位置を取得
  set execDir=%~dp0
  rem 日付を取得
  set YYYYMMDD=%DATE:/=%

  rem IdentifyingNumberの2行目取得
  for /f "tokens=2 usebackq delims=^:" %%i in (`wmic csproduct get IdentifyingNumber ^| findstr /n /r "." ^| findstr /r "^2:"`) do set serialNum=%%i

  rem シリアルナンバー表示
  echo;
  echo シリアルナンバー:%serialNum%

  rem トリムサブルーチン使用
  set x=%serialNum%
  call :trim %x%
  rem スペースが存在する場合、最初のスペースまでしか
  rem ファイル名に出来ないため「"」でくくる
  set serialNum="%x%"

  rem ファイル出力
  echo 出力ファイル名:msinfo32_%YYYYMMDD%_%serialNum%.txt
  msinfo32 /report %execDir%\msinfo32_%YYYYMMDD%_%serialNum%.txt

  pause
  exit


rem トリムサブルーチン
:trim
  rem 後ろのスペースを除去
  set x=%*

  exit /b