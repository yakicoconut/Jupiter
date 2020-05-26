@echo off
title %~nx0
echo 引数ループコマンド実行
echo;
rem テキストファイルの内容を引数にコマンドをループ実行する


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 設定
    rem 実行コマンドファイル
    set cmdFile=""
    rem 引数指定ファイル
    set argFile=""


  : 事前準備
    rem カレントディレクトリをファイルの位置に変更
    cd /d %~dp0


  : 参照バッチ
    rem 数値のみ年月日時分秒ミリ取得バッチ
    set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"
    rem 数値のみ年月日時分秒ミリ取得バッチ使用
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%
    rem ディレクトリファイル情報バッチ
    set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


  : 設定有無確認
    rem 実行コマンドファイル設定がされている場合
    if not %cmdFile%=="" (
      rem 引数指定ファイル設定がされている場合
      if not %argFile%=="" (
        rem 引数指定ファイル処理へ遷移
        goto :ARG_FILE_PROCESS
      )
    )

    : 指定ファイルの設定がされていない場合
      rem ユーザ入力バッチ
      set call_UserInput="..\..\OwnLib\UserInput.bat"
      rem ユーザ入力サブルーチン使用
      call :USER_INPT


  rem 引数指定ファイル処理
  :ARG_FILE_PROCESS
    echo;
    echo;

    rem ディレクトリファイル情報バッチ使用
    call %call_DirFilePathInfo% %cmdFile% dp
    rem 対象バッチ位置にカレントディレクトリ変更
    cd /d %return_DirFilePathInfo%

    rem 指定したファイルを行ごとにループ
    set /a counter=0
    rem オプション用変数初期化(スペース×1)
    set option1=" "
    rem 引数より後に来るオプション
    set option2=""
    for /f "usebackq delims=" %%a in (%argFile%) do (
      rem 対象一行
      set row=%%a

      rem ファイル呼び出しサブルーチン使用
      call :EXEC_FILE
    )


  :END
    pause
    exit


rem ユーザ入力サブルーチン
:USER_INPT
  rem 実行コマンドファイル
  call %call_UserInput% 実行コマンドファイル指定 TRUE PATH
  set cmdFile=%return_UserInput1%
  echo;

  rem 引数指定ファイル
  call %call_UserInput% 引数指定ファイル指定 TRUE PATH
  set argFile=%return_UserInput1%

  exit /b

rem デバッグ用サブルーチン
:DEBUG
SETLOCAL ENABLEDELAYEDEXPANSION
  set cmdFile=%~1
  set datetime=%~2
  set counter=%3
  set option1=%4
  set option2=%5
  set arg=%6

  rem 複数引数項目ラベル
  :MULTI_ARG
    rem 値がある場合
    if not "%~7"=="" (

      rem 引数項目に追加
      set arg=%arg% %7
      rem 引数シフト
      shift
      rem 複数引数項目ラベルへ
      goto :MULTI_ARG
    )

  echo !cmdFile!
  echo !datetime!
  echo !counter!
  echo !option1!
  echo !option2!
  echo !arg!
  pause
  echo;

ENDLOCAL
  exit /b

rem ファイル呼び出しサブルーチン
:EXEC_FILE
  rem 頭文字取得
  set initChar=%row:~0,1%
  rem 引数フラグ初期化
  set isArg=TRUE

  rem 頭文字が「#」(コメント行)の場合、引数フラグを折る
  if %initChar%==# ( set isArg="" )
  rem スペース
  if "%initChar%"==" " ( set isArg="" )

  rem 引数フラグが立っている場合
  if %isArg%==TRUE (
    REM rem デバッグ用サブルーチン使用
    REM call :DEBUG %cmdFile% %datetime% %counter% %option1% %option2% %row%

    rem 実行コマンドファイル使用
    call %cmdFile% %datetime% %counter% %option1% %option2% %row%

    rem カウンタインクリメント
    set /a counter=%counter%+1

    exit /b
  )

  rem 行の先頭が「#option1 」の場合
  if "%row:~0,9%"=="#option1:" (
    rem オプション用変数に設定
    set option1="%row:~9%"
  )
  if "%row:~0,9%"=="#option2:" (
    set option2="%row:~9%"
  )
  if "%row:~0,9%"=="#command:" (
    rem コマンド実行
    %row:~9%
  )

  exit /b