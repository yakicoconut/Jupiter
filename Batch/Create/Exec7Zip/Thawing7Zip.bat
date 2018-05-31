@echo off
title %~nx0
echo 7Zip一括解凍バッチ
: パスワードを記述したファイルを使用することで
: パスつきファイルを一括解凍可能


rem パスワードファイルパス入力
:INPUTPASSFILE
  echo;
  echo パスワードファイル(.txt)のパスを入力してください
  echo パスワードは解凍ファイルと対になるよう記述してください
  echo パスワードが設定されていないファイルは空行としてください

  rem 変数初期化
  set USR=""
  set /P USR="入力してください:"

  rem 「""」入力対策
  set targetPassFile=%USR:"=%
  set targetPassFile="%targetPassFile%"
  : ねずみ返し_空白の場合
    if %targetPassFile%=="" (
      goto :INPUTTARGETROOT
    )
  : ねずみ返し_入力パスが無効の場合
    if not exist %targetPassFile% (
      echo;
      echo 入力パスが正しくありません
      goto :INPUTPASSFILE
    )


rem 対象圧縮ファイルルートフォルダパス入力
:INPUTTARGETROOT
  echo;
  echo 対象圧縮ファイルのルートフォルダパスを入力してください

  rem 変数初期化
  set USR=""
  set /P USR="入力してください(文末\なし):"

  rem 「""」入力対策
  set targetRoot=%USR:"=%
  set targetRoot="%targetRoot%"
  : ねずみ返し_空白の場合
    if %targetRoot%=="" (
      echo;
      echo 入力がありません
      echo 終了します
      pause
      goto :EOF
    )
  : ねずみ返し_入力パスが無効の場合
    if not exist %targetRoot% (
      echo;
      echo 入力パスが正しくありません
      goto :INPUTTARGETROOT
    )


: 処理分岐
  rem パスワードファイルの指定がされていない場合
  if %targetPassFile%=="" (
    rem 対象ファイルループ処理へ
    goto :TARGETDIRLOOP
  )


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
: パスワードの中身を添字変数に格納
  rem 添字初期化
  set /a passSuffix=1
  rem パスワードファイルから空白行を含む全ての行をループ
  for /f "usebackq tokens=1* delims=:" %%a in (`findstr /n "^" %targetPassFile%`) do (
    rem パスワードを添字変数に格納
    set pass_!passSuffix!=%%b

    rem 添字インクリメント
    set /a passSuffix+=1
  )


rem 対象ファイルループ処理
:TARGETDIRLOOP
  rem 動的変数取り出しカウンタ初期化
    set /a count=1
  for /f "usebackq delims=" %%a in (`dir /a-d /b %targetRoot%`) do (
    set x=%%a

    rem 解凍処理サブルーチン使用
    call :THAWING

    rem カウンタインクリメント
    set /a count+=1
  )

  exit


rem 解凍処理サブルーチン
:THAWING
  rem 対象ファイルパス作成
  set targetFilePath=%targetRoot:"=%\%x%

  rem 7za.exeを使用して解凍を実行
  "%~dp07Zip\7za.exe" x -p!pass_%count%! "%targetFilePath%"

  rem サブルーチンを抜ける
  exit /b