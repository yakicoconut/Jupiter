@echo off
title %~nx0
echo ���l�̂ݔN���������b�~���擾�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���l�̂ݔN���������b�~���擾�o�b�`
  set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"


: ���s
  rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
  call %call_GetStrDateTime%
  echo %return_GetStrDateTime%


pause