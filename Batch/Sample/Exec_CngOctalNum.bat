@echo off
title %~nx0
echo 8�i�����l�ϊ��o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem 8�i�����l�ϊ��o�b�`
  set call_CngOctalNum="..\OwnLib\CngOctalNum.bat"


: 00
  rem 8�i�����l�ϊ��o�b�`�g�p
  call %call_CngOctalNum% 00
  echo %return_CngOctalNum%

: 01
  rem 8�i�����l�ϊ��o�b�`�g�p
  call %call_CngOctalNum% 01
  echo %return_CngOctalNum%

: 08
  rem 8�i�����l�ϊ��o�b�`�g�p
  call %call_CngOctalNum% 08
  echo %return_CngOctalNum%

: 09
  rem 8�i�����l�ϊ��o�b�`�g�p
  call %call_CngOctalNum% 09
  echo %return_CngOctalNum%


pause