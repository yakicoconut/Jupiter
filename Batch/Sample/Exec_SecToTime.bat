@echo off
title %~nx0
echo �b���ԕϊ��o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �b���ԕϊ��o�b�`
  set call_SecToTime="..\OwnLib\SecToTime.bat"


: ����
  rem �b���ԕϊ��o�b�`�g�p
  call %call_SecToTime% 5025
  echo %return_SecToTime%
pause