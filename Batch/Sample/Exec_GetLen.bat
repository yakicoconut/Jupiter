@echo off
title %~nx0
echo �����擾�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����擾�o�b�`
  set call_GetLen="..\OwnLib\GetLen.bat"


: ���l
  rem �����擾�o�b�`�g�p
  call %call_GetLen% 1
  echo %return_GetLen%

: ���p�p��
  rem �����擾�o�b�`�g�p
  call %call_GetLen% ab
  echo %return_GetLen%

: �S�p
  rem �����擾�o�b�`�g�p
  call %call_GetLen% ������
  echo %return_GetLen%

: �ϐ�_�_�u���N�H�[�g�Ȃ�
  set var01=�ϐ�01
  rem �����擾�o�b�`�g�p
  call %call_GetLen% %var01%
  echo %return_GetLen%

: �ϐ�_�_�u���N�H�[�g����
  set var02="�ϐ�02"
  rem �����擾�o�b�`�g�p
  call %call_GetLen% %var02%
  echo %return_GetLen%

pause