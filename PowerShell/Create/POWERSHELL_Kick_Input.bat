@echo off
title %~nx0
rem �p���[�V�F�����s�o�b�`


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �����`�F�b�N
  rem �������J�E���g�T�u���[�`���g�p
  call :CNT_ARG %*

  rem ���������s�t�@�C�����ɐݒ�
  rem ���ۊ��ʑ΍�Ƃ��Ċ��ʊO�Őݒ�
  set pS1=%*
  rem W�N�H�[�g�΍�
  set pS1="!pS1:"=!"

  rem ������1�̏ꍇ�A.ps1���s���x����
  if %argCt% == 1 goto :EXEC_SP1
  rem �˂��ݕԂ�_������2�ȏ�̏ꍇ
  if %argCt% geq 2 (
    echo ������2�ȏ㑶�݂��邽��
    echo �I�����܂�
    echo ����:%argCt%
    pause
    exit
  )


: ���[�U���͏���
  echo �Ώۃt�@�C�����w�肵�Ă�������
  set /P USR="���͂��Ă�������:"
  set pS1="!USR:"=!"


rem .ps1���s���x��
:EXEC_SP1
  rem �Ώ�PS�t�@�C�����݊m�F
  if not exist !pS1! (
    echo �Ώ�.ps1�t�@�C�������݂��܂���
    echo !pS1!
    pause
    exit
  )

  echo;
  echo;
  rem .ps1�t�@�C�����Ǘ��Ҏ��s
  powershell -ExecutionPolicy Unrestricted !pS1!

  pause
  exit


rem �������J�E���g�T�u���[�`��
:CNT_ARG
  rem �S�����ϐ���
  set argCmd=%*

  rem �J�E���^������
  set /a argCt=0
  for %%a in (!argCmd!) do (
    rem �J�E���^�C���N�������g
    set /a argCt+=1
  )

  exit /b