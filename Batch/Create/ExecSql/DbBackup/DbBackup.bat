@echo off
title %~nx0
echo .batから指定した.sqlファイルを実行
echo BDのバックアップスクリプトはsystemDBに対して実行するため
echo 対象DBファイルは使用しない


: 共通設定変数
  : 宣言
    rem *ログインユーザ名*
    set loginUser=sa
    rem *ログインパスワード(「%」は「%」で要エスケープ)*
    set loginPassword=PassWord
    rem *実行SQLファイル名指定*
    set cmdFileName=DbBackip.sql

  : 表示
    echo;
    echo 設定情報(変更は本バッチファイルを直接編集)
    echo ログインユーザ名  :%loginUser%
    echo ログインパスワード:%loginPassword%
    echo 実行SQLファイル   :%cmdFileName%

  : 一般
    rem 本バッチ位置を取得
    set execDir=%~dp0


: 対象サーバ入力
  echo;
  echo 対象サーバの指定
  set /P USR="入力してください:"
  set serverName=%USR%

  rem 入力正当性判断サブルーチン使用
  rem サーバ名称を引数に設定
  set y=%serverName%
  call :INPUTDETECTION


: ファイル存在確認
    rem ファイル存在確認サブルーチン使用
    rem 実行SQLファイルパスを引数に設定
    set y=%cmdFileName%
    call :ISFILEEXSIST


rem コマンド実行サブルーチン
:EXECCMD
  echo;
  rem -S:サーバ名、-E:Windows認証接続、-d:DB名、-o:結果出力ファイル名、-i:実行SQLファイル、-Q:実行SQLコマンド
  sqlcmd -S %serverName%    ^
         -U %loginUser%     ^
         -P %loginPassword% ^
         -i %cmdFileName%


rem 入力正当性判断サブルーチン
:INPUTDETECTION
  if "%y%"=="" (
    echo;
    echo 入力がありません
    echo 終了します

    pause
    rem バッチ終了
    exit
  )

  rem サブルーチン引数初期化
  set y=
  rem サブルーチン終了
  exit /b


rem ファイル存在確認サブルーチン
:ISFILEEXSIST
  if exist %y% (
    rem サブルーチン引数初期化
    set y=
    rem サブルーチン終了
    exit /b
  )

  echo;
  echo %y%
  echo 上記のファイルが存在しません
  echo 終了します

  pause
  rem バッチ終了
  exit