@echo off
title %~nx0
echo �o�ߎ��Ԍv�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: �����v�Z_�umm:ss�v�p�^�[��
  echo;
  set beforeTime=12:51
  set  afterTime=24:10
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo      %beforeTime%
  echo -    %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:11:19 �����Ҍ���

: �����v�Z_�uh:mm:ss�v�p�^�[��
  echo;
  set beforeTime=6:10:50
  set  afterTime=8:00:00
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:49:10 �����Ҍ���

: �����v�Z_�uh:mm:ss.f�v�p�^�[��
  echo;
  set beforeTime=6:10:50.4
  set  afterTime=6:10:50.5
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:00.1 �����Ҍ���

: �����v�Z_�uh:mm:ss.ff�v�p�^�[��
  echo;
  set beforeTime=6:10:50.45
  set  afterTime=9:00:00.99
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   02:49:10.54 �����Ҍ���

: �����v�Z_�uh:mm:ss.fff�v�p�^�[��
  echo;
  set beforeTime=1:23:45.670
  set  afterTime=9:54:32.100
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   08:30:46.430 �����Ҍ���

: �����v�Z_�R���}�b�p�^�[��
  echo;
  set beforeTime=01:59:19.40
  set  afterTime=02:00:00.39
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:40.99 �����Ҍ���

: �����v�Z_�uhh:mm:ss�v�p�^�[��
  echo;
  set beforeTime=00:13:30
  set  afterTime=00:14:00
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:30 �����Ҍ���

: �����v�Z_�R���}�O�������p�^�[��
  echo;
  set beforeTime=00:00:34.600
  set  afterTime=00:00:41.607
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:07.007 �����Ҍ���


pause