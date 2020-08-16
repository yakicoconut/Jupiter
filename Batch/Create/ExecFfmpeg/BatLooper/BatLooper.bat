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
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 1 "PATH" %1
  rem 引数がない場合、ユーザ入力へ
  if %ret_ChkArgDataType1%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set tgtPath=%1

  rem 本処理へ
  goto :RUN


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set tgtPath=%return_UserInput1%


rem 本処理
:RUN
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