@echo off
title %~nx0
echo ���ԕb�ϊ��o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���ԕb�ϊ��o�b�`
  set call_SecToTime="..\OwnLib\SecToTime.bat"


: ����
  rem ���ԕb�ϊ��o�b�`�g�p
  call %call_SecToTime% 5025
  echo %return_SecToTime%
pause