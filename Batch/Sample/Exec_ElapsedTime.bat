@echo off
title %~nx0
echo �o�ߎ��Ԍv�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: ���s���ԃp�^�[��
  rem �����O�����擾
  set beforeTime=%time%
  rem �񕶎��ڎ擾
  set hourColon=%beforeTime:~1,1%
  rem �񕶎��ڂ��u:�v(���Ԃ��ꌅ)�̏ꍇ
  if %hourColon% == : (
    rem 0���߂���
    set beforeTime=0%beforeTime%
  )

  rem �^�C���A�E�g����
  timeout 4

  rem �����㎞���擾
  set afterTime=%time%
  set hourColon=%afterTime:~1,1%
  if %hourColon% == : (
    set afterTime=0%afterTime%
  )

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime% - %afterTime% �� %return_ElapsedTime%


: �����v�Z_�R���}�b�p�^�[��
  rem �J�n����
  set beforeTime=01:59:19.40

  rem �I������
  set  afterTime=01:00:00.39

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime% - %afterTime% �� %return_ElapsedTime%


: �����v�Z�p�^�[��
  rem �J�n����
  set beforeTime=00:13:30

  rem �I������
  set  afterTime=00:14:00

  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime%    - %afterTime%    �� %return_ElapsedTime%


pause