@echo off
title %~nx0
rem パワーシェル実行バッチ


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==1 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:1
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  echo 対象ファイルを指定してください
  set /P USR="入力してください:"
  set tgtPath="%USR:"=%"
  
  rem 値検証ラベルへ
  goto :CHK_VAL


rem 引数判定
:CHK_ARG
  : 引数引継ぎ
    set tgtPath=%1


rem 値検証
:CHK_VAL
  : ねずみ返し_ファイル存在確認
    if not exist %tgtPath% (
      echo;
      echo ファイルが存在しません
      echo 終了します

      pause
      exit
    )


: .ps1の実行
  echo;
  echo;
  rem .ps1ファイルを管理者実行
  powershell -ExecutionPolicy Unrestricted %tgtPath%

  pause
  exit