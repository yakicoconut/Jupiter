@echo off
title %~nx0
echo 丸括弧含有判定バッチの使用例


: 参照バッチ
  rem 丸括弧含有判定バッチ
  set call_ChkIncParenthesis="..\OwnLib\ChkIncParenthesis.bat"


: パターン1
  set str=abc
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

: パターン2
  set str=a(bc
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

: パターン3
  set str=ab)c
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

  : パターン4
  set str=a(b)c
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

pause