@echo off
title %~nx0
rem �p���[�V�F�����s�o�b�`


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION


: �����`�F�b�N
  rem �����J�E���g
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %argc%==0 goto :USER_INPUT
  rem ��������`�ʂ�̏ꍇ�A���������
  if %argc%==1 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:1
  pause
  exit /b


rem ���[�U���͏���
:USER_INPUT
  echo �Ώۃt�@�C�����w�肵�Ă�������
  set /P USR="���͂��Ă�������:"
  set tgtPath="%USR:"=%"
  
  rem �l���؃��x����
  goto :CHK_VAL


rem ��������
:CHK_ARG
  : �������p��
    set tgtPath=%1


rem �l����
:CHK_VAL
  : �˂��ݕԂ�_�t�@�C�����݊m�F
    if not exist %tgtPath% (
      echo;
      echo �t�@�C�������݂��܂���
      echo �I�����܂�

      pause
      exit
    )


: .ps1�̎��s
  echo;
  echo;
  rem .ps1�t�@�C�����Ǘ��Ҏ��s
  powershell -ExecutionPolicy Unrestricted %tgtPath%

  pause
  exit