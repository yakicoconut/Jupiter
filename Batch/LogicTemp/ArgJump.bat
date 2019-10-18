@echo off
title %~nx0
echo 引数有無分岐
echo 引数がある場合とない場合で入力を分岐する


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


: 引数有無確認
  rem 引数がない場合
  if "%~1"=="" (
    rem ユーザ入力処理へ
    goto :NOARG
  )

  rem 引数を変数に設定
  set targetVar=%1

  rem 実行へ
  goto :RUN


rem ユーザ入力処理
:NOARG
  : ユーザ入力1
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 引数がないため入力 TRUE STR
    rem 入力値引継ぎ
    set targetVar=%return_UserInput1%


rem 実行
:RUN
  echo;
  echo %targetVar%

  echo;
  pause