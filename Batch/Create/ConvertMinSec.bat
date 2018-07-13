@echo off
title %~nx0
echo 分→秒変換


rem 分入力ループ
:INPUTMINUTE
  echo;
  echo 分入力
  set /P USR="入力してください:"
  set targetSec=%USR%
  : ねずみ返し_空白の場合
    if "%targetSec%"=="" (
     echo 入力がありません
     echo 終了します

     pause
     exit
    )

  : 分→秒変換
    rem 入力値を数値に変換
    set /a calcSec=%targetSec%

    rem 60秒を掛けて秒数に変換
    set /a calcAnswer=%calcSec% * 60

    rem 結果表示
    echo %calcSec% 分 = %calcAnswer% 秒

    rem 分入力ループ使用
    goto :INPUTMINUTE