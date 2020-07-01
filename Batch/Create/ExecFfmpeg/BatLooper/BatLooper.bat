@echo off
title %~nx0
echo ffmpegバッチ連続実行
: ffmpegを使用するバッチの連続呼び出しができないため、
: テキストファイルの内容を引数にコマンドをループ実行する
: Strange errors when using ffmpeg in a loop - Unix & Linux Stack Exchange
: 	https://unix.stackexchange.com/questions/36310/strange-errors-when-using-ffmpeg-in-a-loop



: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==1 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:1
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set tgtPath=%return_UserInput1%


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH" %1
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType1%==0 goto :EOF
  REM rem 型判定結果引継ぎ
  REM for /f "tokens=2,3" %%a in (%ret_ChkArgDataType2%) do (
  REM   rem 時刻フォーマット取得
  REM   set starFmt=%%a
  REM   set distFmt=%%b
  REM )

  : 引数引継ぎ
    set tgtPath=%1


: コマンド実行
  for /f "usebackq delims=" %%a in (%tgtPath%) do (
    REM %%a
    REM if %%a==REM pause

    rem 対象一行
    set row=%%a

    rem 行分析サブルーチン使用
    call :ANA_ROW
  )

  pause
  exit /b


rem 行分析サブルーチン
:ANA_ROW
  rem 頭文字取得
  set initChar=%row:~0,1%

  : 対象値分岐
    rem 頭文字がWクォートの場合、コマンド実行サブルーチンへ
    if %initChar%^"=="^" ( goto :EXEC_CMD )
    rem 頭文字が「#」の場合、サブルーチン終了
    if %initChar%==# ( exit /b )

rem コマンド実行サブルーチン
:EXEC_CMD
  call %row%
  echo;
  exit /b