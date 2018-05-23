@echo off
title %~nx0
echo 指定フォルダ以下全てのファイルを指定フォルダにコピー


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: コピー元ルートフォルダ入力
  echo;
  echo コピー元のルートフォルダパスを入力してください

  rem 変数初期化
  set USR=

  set /P USR="入力してください(文末\なし):"
  set targetRoot=%USR%
  : ねずみ返し_空白の場合
    if "%targetRoot%"=="" (
      echo;
      echo 入力がありません
      echo 終了します
      goto :EOF
    )


: ファイルコピー
  echo;
  echo コピー実行

  rem フォルダを抜いた一覧を出力
  dir "%targetRoot%" /b /a-d /s>FILES.txt

  rem ファイルリストをループ
  for /f "delims=" %%a in (FILES.txt) do (
    rem ループ対象(コピー対象フォルダパス)を変数に格納
    set x=%%a

    rem コピー(隠しファイル含む)
    xcopy "!x!" "%targetRoot%" /h
  )

  del FILES.txt
  pause