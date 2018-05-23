@echo off
title %~nx0
echo 対象フォルダ構成コピー


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"


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


: フォルダコピー
  rem フォルダ構成の出力
  dir %targetRoot% /b /ad /s>FOLDERS.txt

  rem ディレクトリファイル情報バッチ使用_コピー元ルートフォルダ名取得
  call %call_DirFilePathInfo% %targetRoot% n
  set targetRootDirName=%return_DirFilePathInfo%
  rem コピー先ルートフォルダにコピー元ルートフォルダを作成
  mkdir "%destinationRoot%\%targetRootDirName%"

  rem 出力したフォルダ名を一行ずつ処理
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem ループ対象(コピー対象フォルダパス)を変数に格納
    set x=%%a

    rem コピー元ルートフォルダまでのパスを削除
    set x=!x:%targetRoot%\=!

    rem コピー先ルートフォルダにフォルダを作成
    mkdir "%destinationRoot%\%targetRootDirName%\!x!"
  )

  rem 作業ファイルの削除
  del FOLDERS.txt


: 事後処理
  rem コピー元フォルダツリーファイル作成
  tree %targetRoot%>TARGETTREE.txt

  rem コピー先フォルダツリーファイル作成
  tree %destinationRoot%\%targetRootDirName%>DESTINATIONTREE.txt


  echo;
  echo 各ツリーファイルを終わらせてからバッチを終了してください
  pause

  rem ツリーファイル削除
  del "%~dp0\TARGETTREE.txt"
  del "%~dp0\DESTINATIONTREE.txt"