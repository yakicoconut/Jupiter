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
    set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"
    rem 数値のみ年月日時分秒ミリ取得バッチ使用
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%


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
      set call_UserInput="..\OwnLib\UserInput.bat"
      rem ユーザ入力サブルーチン使用
      call :USER_INPT


  rem 引数指定ファイル処理
  :ARG_FILE_PROCESS
    rem 指定したファイルを行ごとにループ
    set /a counter=0
    rem オプション用変数初期化(スペース×1)
    set option=" "
    for /f "usebackq delims=" %%a in (%argFile%) do (
      rem 対象一行
      set row=%%a
      rem 頭文字取得
      set initChar=!row:~0,1!

      rem 頭文字が「#」(コメント行)でない場合
      if not !initChar!==# (
        rem カウンタインクリメント
        set /a counter=!counter!+1

        rem 実行コマンドファイル使用
        call !cmdFile! %datetime% !counter! !option! "!row!"
      )

      rem 行の先頭が「#option 」の場合
      if "!row:~0,8!"=="#option:" (
        rem オプション用変数に設定
        set option="!row:~8!"
      )
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