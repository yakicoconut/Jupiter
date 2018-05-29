@echo off
title %~nx0
rem パワーシェル実行バッチ


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 自身のファイル名から実行対象の.ps1ファイル名を取得
  rem 自身のファイル名取得
  set myName=%~nx0

  rem パス設定
  rem ※引数にパスを使用したい場合、以下コマンド内の「%~dp0\」を置換
  set pS1=%~dp0%myName%
  rem ファイル名から「_Kick.bat」を「.ps1」に置換え
  set pS1=%pS1:_Kick.bat=.ps1%


: 対象PSファイル存在確認
  if not exist %pS1% (
    rem 本ファイル名の置き換え対象部分取得
    set fileNmae=%myName:_Kick.bat=%

    echo 対象.ps1ファイルが存在しません
    echo;
    echo 本ファイルの「!fileNmae!」部分を
    echo 実行対象の.ps1ファイル名に変更してから再度実行してください

    pause
    exit
  )


: .ps1の実行
  rem .ps1ファイルを管理者実行
  powershell -ExecutionPolicy Unrestricted %pS1%

pause