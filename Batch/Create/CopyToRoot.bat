@echo off
title %~nx0
echo �w��t�H���_�ȉ��S�Ẵt�@�C�����w��t�H���_�ɃR�s�[


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �R�s�[�����[�g�t�H���_����
  echo;
  echo �R�s�[���̃��[�g�t�H���_�p�X����͂��Ă�������

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������(����\�Ȃ�):"
  set targetRoot=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetRoot%"=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      goto :EOF
    )


: �t�@�C���R�s�[
  echo;
  echo �R�s�[���s

  rem �t�H���_�𔲂����ꗗ���o��
  dir "%targetRoot%" /b /a-d /s>FILES.txt

  rem �t�@�C�����X�g�����[�v
  for /f "delims=" %%a in (FILES.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�H���_�p�X)��ϐ��Ɋi�[
    set x=%%a

    rem �R�s�[(�B���t�@�C���܂�)
    xcopy "!x!" "%targetRoot%" /h
  )

  del FILES.txt
  pause