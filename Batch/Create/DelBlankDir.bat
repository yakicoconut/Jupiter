@echo off
title %~nx0
echo 空フォルダの一括削除


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 変数
  rem 動的変数カウンター
  set /a count=0


: コピー元ルートフォルダ入力
  echo;
  echo 削除対象ルートフォルダを入力してください

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


: 動的変数作成
  rem 対象フォルダ内のフォルダを全て取得
  dir "%targetRoot%" /ad /b /s>FOLDERS.txt

  rem 動的変数作成ループ
  rem setコマンド時の変数名に動的な数値を付加する
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem カウントを増やす
    set /a count+=1

    rem ファイルから取得した行を動的変数に代入
    set var_!count!=%%a
  )

  rem カウンターの最大値を取得
  set /a totalCount=%count%


: フォルダ削除
  rem 動的変数取り出し
  rem drコマンドはフォルダ内に空フォルダがある場合、削除できないため下層のフォルダから対象にする
  :EXECDEL
    rem ねずみ返し_カウンタが0なら終了
    if %count%==0 goto END

    echo !var_%count%!の削除
    echo 残り !count!/!totalCount!
    rem 対象フォルダの削除
    rd "!var_%count%!"

    rem カウンタを減らす
    set /a count-=1

    goto EXECDEL


:END
  del FOLDERS.txt
  pause