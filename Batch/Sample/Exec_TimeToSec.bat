@echo off
title %~nx0
echo ���ԕb�ϊ��o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���ԕb�ϊ��o�b�`
  set call_TimeToSec="..\OwnLib\TimeToSec.bat"


: �p�^�[��
  rem ���ԕb�ϊ��o�b�`�g�p
  call %call_TimeToSec% 01:23:45.678
  echo %return_TimeToSec1%
  echo %return_TimeToSec2%

: �p�^�[��
  rem ���ԕb�ϊ��o�b�`�g�p
  call %call_TimeToSec% 1:23:45.67
  echo %return_TimeToSec1%
  echo %return_TimeToSec2%
pause