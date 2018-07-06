@echo off
title %~nx0
echo .batから指定した.sqlファイルを実行する


: 共通設定変数
  : 宣言
    rem ログインユーザ名
    set loginUser=sa
    rem ログインパスワード(「%」は「%」で要エスケープ)
    set loginPassword=PassWord
    rem 実行SQLファイル名指定
    set cmdFileName=OutputTableValues.sql
    rem 対象DBファイル名指定
    set targetDbFileName=TargetDb.txt


  : 表示
    echo;
    echo 設定情報(変更は本バッチファイルを直接編集)
    echo ログインユーザ名  :%loginUser%
    echo ログインパスワード:%loginPassword%
    echo 実行SQLファイル   :%cmdFileName%
    echo 対象DBファイル    :%targetDbFileName%
    echo ※対象DBファイルには対象のDB名称を箇条書きにする


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

    rem ファイル存在確認サブルーチン使用
    rem 対象DBファイルパスを引数に設定
    set y=%targetDbFileName%
    call :ISFILEEXSIST


: 対象DBファイルループ
  rem 指定したファイルを引数として使用
  for /f "delims=" %%a in (%targetDbFileName%) do (
    rem コマンド実行サブルーチン使用
    rem 対象DB名称を引数に設定
    set x=%%a
    call :EXECCMD
  )

  pause
  exit


rem コマンド実行サブルーチン
:EXECCMD
  rem DB名称設定
  set dbName=%x%
  set logFileName=%x%
  rem templateでない場合は加工する
  if not "%x%" == "GemDB_template" (
    rem GemDB_xxxxxに加工
    set logFileName=%x:~0,11%
  )
  set logFileName=%logFileName%.txt

  rem -S:サーバ名、-E:Windows認証接続、-d:DB名、-o:結果出力ファイル名、-i:実行SQLファイル、-Q:実行SQLコマンド
  sqlcmd -S %serverName%    ^
         -U %loginUser%     ^
         -P %loginPassword% ^
         -d %dbName%        ^
         -i %cmdFileName%   ^
         -o %logFileName%

  rem サブルーチン引数初期化
  set x=
  rem サブルーチン終了
  exit /b


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


: メモ
: ・バッチファイル内の改行は「^」で行う
: ・参考サイト
:    SQLServerでselectの結果をCSVで出力する方法。 | mokuzine's note
:     http://note.mokuzine.net/sqlserver-csv-out/