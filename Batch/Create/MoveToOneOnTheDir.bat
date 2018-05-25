@echo off
title %~nx0
echo 対象フォルダ内の全てのファイルを一つ上のディレクトリへ移動


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"


: コピー元ルートフォルダ入力
  echo;
  echo 対象フォルダ入力

  rem 変数初期化
  set USR=

  set /P USR="入力してください(文末\なし):"
  set targetPath=%USR%
  : ねずみ返し_空白の場合
    if "%targetPath%"=="" (
      echo;
      echo 入力がありません
      echo 終了します
      goto :EOF
    )


: ファイルコピー
  rem ディレクトリファイル情報バッチ使用_一つ上のフォルダパス取得
  call %call_DirFilePathInfo% %targetPath% dp
  set oneOnThePath=%return_DirFilePathInfo%

  rem 各ファイル名を取得し引数として使用
  dir %targetPath% /a-d /b>FILES.txt

  rem ファイルループ
  for /f "delims=" %%a in (FILES.txt) do (
    rem ループ対象(コピー対象ファイル名)を変数に格納
    set x=%%a

    rem メタファイル退避
    if "!x!" == "FILES.txt" (echo 処理中1) else (
      rem ディレクトリ移動処理
      move "%targetPath%\!x!"  "%oneOnThePath%"
    )
  )

del FILES.txt
pause