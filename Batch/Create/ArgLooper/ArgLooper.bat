@echo off
title %~nx0
echo 引数ループコマンド実行
echo;
rem テキストファイルの内容を引数にコマンドをループ実行する


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION
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

      rem 行分析サブルーチン使用
      call :ANA_ROW
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
SETLOCAL
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
      rem 引数シフト
      shift

      rem 複数引数格納サブルーチン使用
      call :ARG_PLUS %7

      rem 複数引数項目ラベルへ
      goto :MULTI_ARG
    )

  rem 値表示
  echo %cmdFile%
  echo %datetime%
  echo %counter%
  echo %option1%
  echo %option2%
  echo %arg%
  pause
  echo;
  exit /b

  rem 複数引数格納サブルーチン
  :ARG_PLUS
    rem 引数項目に追加
    set arg=%arg% %1
    exit /b

ENDLOCAL

rem 行分析サブルーチン
:ANA_ROW
  rem 頭文字取得
  set initChar=%row:~0,1%
  rem 実行コマンド変数初期化
  set execCmd=

  : 対象値分岐
    rem 頭文字がWクォートの場合、引数受け渡しラベルへ
    if %initChar%^"=="^" ( goto :DELIVERY_ARG )
    rem 頭文字が「#」の場合、シャープ分析ラベルへ
    if %initChar%==# ( goto :ANA_SHARP )
    rem 頭文字がスペースの場合、行分析終了ラベルへ
    if "%initChar%"==" " ( goto :ANA_ROW_END )
    rem 上記いずれでもない場合、そのまま引数受け渡しラベルへ

  rem 引数受け渡しラベル
  :DELIVERY_ARG
    rem カウンタインクリメント
    set /a counter=%counter%+1

    rem バッチ実行サブルーチン使用
    call :EXEC_BAT
    exit /b

  rem シャープ分析ラベル
  :ANA_SHARP
    rem 先頭予約語取得
    set reserveWord=%row:~0,9%
    rem Wクォート奇数対策
    set reserveWord="%reserveWord:"=%"

    rem 遅延環境変数処理
    if %reserveWord%=="#option1:" (
      rem 丸括弧対策として変数設定をサブルーチン化
      rem 前オプション設定サブルーチン使用
      call :OPT_ONE
    )
    if %reserveWord%=="#option2:" (
      rem 前オプション設定サブルーチン使用
      call :OPT_TWO
    )
    if %reserveWord%=="#command:" (
      rem 実行コマンド設定サブルーチン使用
      call :SET_EXEC_CMD
    )

    rem コマンド実行
    %execCmd%
    exit /b

  rem 行分析終了ラベル
  :ANA_ROW_END
    exit /b

ENDLOCAL
  exit /b

rem バッチ実行サブルーチン
:EXEC_BAT
  REM rem デバッグ用サブルーチン使用
  REM call :DEBUG %cmdFile% %datetime% %counter% %option1% %option2% %row%

  rem 実行コマンドファイル使用
  call %cmdFile% %datetime% %counter% %option1% %option2% %row%
  exit /b

rem 前オプション設定サブルーチン
:OPT_ONE
  rem 予約語意向を変数に設定
  set option1="%row:~9%"
  exit /b

rem 後オプション設定サブルーチン
:OPT_TWO
  set option2="%row:~9%"
  exit /b

rem 実行コマンド設定サブルーチン
:SET_EXEC_CMD
  rem 実行コマンド設定
  set execCmd=%row:~9%
  exit /b