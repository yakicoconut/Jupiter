@echo off
title %~nx0
echo 対象フォルダ構成コピー


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 変数
  rem フォルダ名数
  set /a length=0


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


: コピー先フォルダ入力
  echo;
  echo コピー先のルートフォルダを入力してください

  rem 変数初期化
  set USR=

  set /P USR="入力してください(文末\なし):"
  set destinationRoot=%USR%
  : 空白の場合
    if "%destinationRoot%"=="" (
      echo;
      echo 入力がありません
      echo カレントフォルダを指定します

      rem カレントフォルダを取得
      rem if文の中も変数には遅延環境変数を使用する
      set destinationRoot=%~dp0
      rem 文末の\をはずす
      set destinationRoot=!destinationRoot:~0,-1!
      echo !destinationRoot!
    )


rem コピー元ルートフォルダパスを1文字ずつ取得してカウントする
rem ループ用変数にコピー元ルートフォルダパスを設定
set last=%targetRoot%
:LOOP
  rem カウントアップ
  set /a length+=1

  rem 文字列を一文字削除
  set last=%last:~1%

  rem 文字が残っている場合、ループ
  if not "%last%"=="" goto LOOP


: フォルダコピー
  rem カレントフォルダの変更
  cd /d %targetRoot%

  rem フォルダ構成の出力
  dir /b /ad /s>FOLDERS.txt

  rem 出力したフォルダ名を一行ずつ処理
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem ループ対象(コピー対象フォルダパス)を変数に格納
    set x=%%a

    rem (対象フォルダ名のみ取得(コピー元ルートフォルダを抜く)
    set x=!x:~%length%!

    rem コピー先ルートフォルダにフォルダを作成
    mkdir "%destinationRoot%!x!"
  )

  rem 作業ファイルの削除
  del "%targetRoot%\FOLDERS.txt"


: 事後処理
  rem コピー元フォルダツリーファイル作成
  tree>TARGETTREE.txt
  move "%targetRoot%\TARGETTREE.txt" "%~dp0"

  rem コピー先フォルダツリーファイル作成
  cd /d %destinationRoot%
  tree>DESTINATIONTREE.txt
  move "%destinationRoot%\DESTINATIONTREE.txt" "%~dp0"


  echo;
  echo 各ツリーファイルを終わらせてからバッチを終了してください
  pause

  rem ツリーファイル削除
  del "%~dp0\TARGETTREE.txt"
  del "%~dp0\DESTINATIONTREE.txt"