@echo off
title %~nx0
echo テキストファイル内容取得


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


: 対象ファイル入力
  echo;
  rem ユーザ入力バッチ使用
  call %call_UserInput% 対象ファイル指定 TRUE PATH
  rem 入力値引継ぎ
  set targetFile=%return_UserInput1%


: 指定ファイル操作
  rem 指定したファイル内容を引数として使用
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem 実処理サブルーチン使用
    call :EXEC_CMD %%a
  )


rem 事後処理
:END
  echo;
  echo ファイル情報取得処理終了

  pause
  exit


rem 実処理サブルーチン
:EXEC_CMD
SETLOCAL
  : 引数
    set var01=%1

  : コマンド実行
    echo %var01%

ENDLOCAL && set ret01=%var01%&& set ret02=abc
exit /b