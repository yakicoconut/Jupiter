@echo off
title %~nx0
echo 標準出力変数格納
: 標準出力の内容はfor文を利用すると変数に格納可能
: バッチ TIPS :: コマンドプロンプト | Refills
: 	https://syon.github.io/refills/rid/1498316/


: 実行
  rem 現在時刻取得
  for /f "delims=" %%a in ('time /t') do set varTime=%%a
  echo;
  echo ----------------------------------
  echo %varTime%
  pause

  rem echo
  for /f "delims=" %%a in ('echo abc') do set varEcho=%%a
  echo;
  echo ----------------------------------
  echo %varEcho%
  pause

  rem dirコマンド
  echo;
  echo ----------------------------------
  for /f "delims=" %%a in ('dir') do (
    echo %%a
  )
  pause