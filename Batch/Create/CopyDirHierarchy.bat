@echo off
title %~nx0
echo �Ώۃt�H���_�\���R�s�[


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �ϐ�
  rem �t�H���_����
  set /a length=0


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


: �R�s�[��t�H���_����
  echo;
  echo �R�s�[��̃��[�g�t�H���_����͂��Ă�������

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������(����\�Ȃ�):"
  set destinationRoot=%USR%
  : �󔒂̏ꍇ
    if "%destinationRoot%"=="" (
      echo;
      echo ���͂�����܂���
      echo �J�����g�t�H���_���w�肵�܂�

      rem �J�����g�t�H���_���擾
      rem if���̒����ϐ��ɂ͒x�����ϐ����g�p����
      set destinationRoot=%~dp0
      rem ������\���͂���
      set destinationRoot=!destinationRoot:~0,-1!
      echo !destinationRoot!
    )


rem �R�s�[�����[�g�t�H���_�p�X��1�������擾���ăJ�E���g����
rem ���[�v�p�ϐ��ɃR�s�[�����[�g�t�H���_�p�X��ݒ�
set last=%targetRoot%
:LOOP
  rem �J�E���g�A�b�v
  set /a length+=1

  rem ��������ꕶ���폜
  set last=%last:~1%

  rem �������c���Ă���ꍇ�A���[�v
  if not "%last%"=="" goto LOOP


: �t�H���_�R�s�[
  rem �J�����g�t�H���_�̕ύX
  cd /d %targetRoot%

  rem �t�H���_�\���̏o��
  dir /b /ad /s>FOLDERS.txt

  rem �o�͂����t�H���_������s������
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�H���_�p�X)��ϐ��Ɋi�[
    set x=%%a

    rem (�Ώۃt�H���_���̂ݎ擾(�R�s�[�����[�g�t�H���_�𔲂�)
    set x=!x:~%length%!

    rem �R�s�[�惋�[�g�t�H���_�Ƀt�H���_���쐬
    mkdir "%destinationRoot%!x!"
  )

  rem ��ƃt�@�C���̍폜
  del "%targetRoot%\FOLDERS.txt"


: ���㏈��
  rem �R�s�[���t�H���_�c���[�t�@�C���쐬
  tree>TARGETTREE.txt
  move "%targetRoot%\TARGETTREE.txt" "%~dp0"

  rem �R�s�[��t�H���_�c���[�t�@�C���쐬
  cd /d %destinationRoot%
  tree>DESTINATIONTREE.txt
  move "%destinationRoot%\DESTINATIONTREE.txt" "%~dp0"


  echo;
  echo �e�c���[�t�@�C�����I��点�Ă���o�b�`���I�����Ă�������
  pause

  rem �c���[�t�@�C���폜
  del "%~dp0\TARGETTREE.txt"
  del "%~dp0\DESTINATIONTREE.txt"