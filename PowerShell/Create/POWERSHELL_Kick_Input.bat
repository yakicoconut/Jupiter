@echo off
title %~nx0
rem �p���[�V�F�����s�o�b�`


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION


: �Ώۃt�@�C������
  echo �Ώۃt�@�C�����w�肵�Ă�������
  set /P USR="���͂��Ă�������:"
  set pS1=%USR%
  : �˂��ݕԂ�_�t�@�C�����݊m�F
    if not exist %pS1% (
      echo;
      echo �t�@�C�������݂��܂���
      echo �I�����܂�

      pause
      exit
    )

  rem �_�u���N�H�[�e�[�V�������f�T�u���[�`���g�p
  set y=%pS1%
  call :WQUOTATIONDECSION
  set pS1=%y%


: .ps1�̎��s
  echo;
  echo;
  rem .ps1�t�@�C�����Ǘ��Ҏ��s
  powershell -ExecutionPolicy Unrestricted %pS1%

  pause
  exit


rem �_�u���N�H�[�e�[�V�������f�T�u���[�`��
:WQUOTATIONDECSION
  rem �ꕶ���ڂ��u"�v�łȂ��ꍇ
  rem If���̃G�X�P�[�v�Ɂu^�v���g�p
  if not ^%y:~0,1%==^" (
    rem �擪�Ƀ_�u���N�H�[�g������
    set x="%y%
  )

  rem �������u"�v�łȂ��ꍇ
  if not ^%y:~-1,1%==^" (
    rem �����Ƀ_�u���N�H�[�g������
    set y=%y%"
  )

  rem �T�u���[�`���𔲂���
  exit /b