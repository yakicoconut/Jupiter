@echo off
title %~nx0
echo �ۊ��ʊܗL����o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �ۊ��ʊܗL����o�b�`
  set call_ChkIncParenthesis="..\OwnLib\ChkIncParenthesis.bat"


: �p�^�[��1
  set str=abc
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

: �p�^�[��2
  set str=a(bc
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

: �p�^�[��3
  set str=ab)c
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

  : �p�^�[��4
  set str=a(b)c
  echo %str%
  call %call_ChkIncParenthesis% %str%
  echo %return_ChkIncParenthesis%

pause