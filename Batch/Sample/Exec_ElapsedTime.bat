@echo off
title %~nx0
echo �o�ߎ��Ԍv�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: ����
  rem �����O�����擾
  set beforeTime=%time%

  rem �^�C���A�E�g����
  timeout 4

  rem �����㎞���擾
  set afterTime=%time%

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %return_ElapsedTime%

pause