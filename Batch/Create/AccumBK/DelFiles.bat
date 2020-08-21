@echo off
title %~nx0
echo ミラーリングフォルダの削除対象ファイルを削除する


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 変数
  rem 削除対象ファイル一覧テキスト
  set targetFile=DELTARGET.txt
  rem ねずみ返し_ファイルが存在しない場合
  if not exist %targetFile% (
    echo;
    echo %targetFile%ファイルが存在しません
    echo 終了します
    pause
    exit
  )


: 削除対象ファイル一覧テキストの内容を削除する
  for /f "delims=" %%a in (%targetFile%) do (
    rem 対象ファイルパスの代入
    set targetPath=%~dp0%%a

    rem 対象が存在するかで分岐(forにcontinueがないためねずみ返しできない)
    if exist "!targetPath!" (
      rem 末尾が「\」ならフォルダ
      if !targetPath:~-1!==\ (
        echo;
        echo %%a
        rem 対象フォルダ削除
        rd "!targetPath!" /s /q
      ) else (
        echo;
        echo %%a
        rem 対象ファイル削除(通常ファイル)
        echo y | del "!targetPath!" /q

        rem ファイルが削除されなかった場合
        if exist "!targetPath!" (
          echo;
          rem 隠しファイル削除
          echo y | del "!targetPath!" /q /ah
        )
      )
    )
  )