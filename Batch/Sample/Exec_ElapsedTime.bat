@echo off
title %~nx0
echo �o�ߎ��Ԍv�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: ���s���ԃp�^�[��
  rem �����O�����擾
  set beforeTime=%time%

  rem �^�C���A�E�g����
  timeout 4

  rem �����㎞���擾
  set afterTime=%time%

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %return_ElapsedTime%


: �����v�Z_�R���}�b�p�^�[��
  rem �J�n����
  set beforeTime=00:13:19.40

  rem �I������
  set afterTime=01:14:00.39

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %return_ElapsedTime%


: �����v�Z�p�^�[��
  rem �J�n����
  set beforeTime=00:13:19

  rem �I������
  set afterTime=01:14:00

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %return_ElapsedTime%


pause