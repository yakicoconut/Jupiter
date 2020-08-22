@echo off
title %~nx0
rem パワーシェル実行バッチ


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 引数チェック
  rem 引数数カウントサブルーチン使用
  call :CNT_ARG %*

  rem 引数を実行ファイル名に設定
  rem ※丸括弧対策として括弧外で設定
  set pS1=%*
  rem Wクォート対策
  set pS1="!pS1:"=!"

  rem 引数が1つの場合、.ps1実行ラベルへ
  if %argCt% == 1 goto :EXEC_SP1
  rem 引数が2つ以上の場合、
  if %argCt% geq 2 (
    echo 引数が2つ以上存在するため
    echo 終了します
    echo 引数:%argCt%
    pause
    exit
  )


: 自身のファイル名から実行対象の.ps1ファイル名を取得
  rem 自身のファイルパス取得
  set pS1=%0
  rem ファイル名から「_Kick.bat」を「.ps1」に置換え
  set pS1=%pS1:_Kick.bat=.ps1%


rem .ps1実行ラベル
:EXEC_SP1
  rem 対象PSファイル存在確認
  if not exist !pS1! (
    echo 対象.ps1ファイルが存在しません
    echo !pS1!
    pause
    exit
  )

  echo;
  echo;
  rem .ps1ファイルを管理者実行
  powershell -ExecutionPolicy Unrestricted !pS1!

pause
exit


rem 引数数カウントサブルーチン
:CNT_ARG
  rem 全引数変数化
  set argCmd=%*

  rem カウンタ初期化
  set /a argCt=0
  for %%a in (!argCmd!) do (
    rem カウンタインクリメント
    set /a argCt+=1
  )

  exit /b