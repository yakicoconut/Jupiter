@echo off
title %~nx0
echo �l�b�g�X�e�C�g�ꗗ�\��


: ���O����
  rem ���g�̃t�H���_�p�X�擾
  set currentDir=%~dp0
  rem ���ݓ����擾
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%


: netstat���X�g�o��
  echo;
  echo netstat���X�g

  rem �o��
  netstat -aon>>%currentDir%\NETSTAT_%datetime%.txt

  pause