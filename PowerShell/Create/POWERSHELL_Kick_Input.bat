@echo off
title %~nx0
rem パワーシェル実行バッチ


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION


: 対象ファイル入力
  echo 対象ファイルを指定してください
  set /P USR="入力してください:"
  set pS1=%USR%
  : ねずみ返し_ファイル存在確認
    if not exist %pS1% (
      echo;
      echo ファイルが存在しません
      echo 終了します

      pause
      exit
    )

  rem ダブルクォーテーション判断サブルーチン使用
  set y=%pS1%
  call :WQUOTATIONDECSION
  set pS1=%y%


: .ps1の実行
  echo;
  echo;
  rem .ps1ファイルを管理者実行
  powershell -ExecutionPolicy Unrestricted %pS1%

  pause
  exit


rem ダブルクォーテーション判断サブルーチン
:WQUOTATIONDECSION
  rem 一文字目が「"」でない場合
  rem If文のエスケープに「^」を使用
  if not ^%y:~0,1%==^" (
    rem 先頭にダブルクォートをつける
    set x="%y%
  )

  rem 末尾が「"」でない場合
  if not ^%y:~-1,1%==^" (
    rem 末尾にダブルクォートをつける
    set y=%y%"
  )

  rem サブルーチンを抜ける
  exit /b