@echo off
title %~nx0
echo 同ディレクトリ内フォルダ圧縮バッチ


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION

: 圧縮処理
  for /f "usebackq delims=" %%a in (`dir /ad /b`) do (
    rem 対象フォルダ
    set tgtDir="%%a"

    rem 「7Zip」フォルダでない場合
    if not !tgtDir!=="7Zip" (
      rem 7za.exeを使用して圧縮を実行
      "7Zip\7za.exe" a !tgtDir!.7z !tgtDir!
    )
  )
  pause