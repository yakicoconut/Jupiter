@echo off
title %~nx0
echo �Ώۃt�H���_�\���R�s�[


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"


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


: �t�H���_�R�s�[
  rem �t�H���_�\���̏o��
  dir %targetRoot% /b /ad /s>FOLDERS.txt

  rem �f�B���N�g���t�@�C�����o�b�`�g�p_�R�s�[�����[�g�t�H���_���擾
  call %call_DirFilePathInfo% %targetRoot% n
  set targetRootDirName=%return_DirFilePathInfo%
  rem �R�s�[�惋�[�g�t�H���_�ɃR�s�[�����[�g�t�H���_���쐬
  mkdir "%destinationRoot%\%targetRootDirName%"

  rem �o�͂����t�H���_������s������
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�H���_�p�X)��ϐ��Ɋi�[
    set x=%%a

    rem �R�s�[�����[�g�t�H���_�܂ł̃p�X���폜
    set x=!x:%targetRoot%\=!

    rem �R�s�[�惋�[�g�t�H���_�Ƀt�H���_���쐬
    mkdir "%destinationRoot%\%targetRootDirName%\!x!"
  )

  rem ��ƃt�@�C���̍폜
  del FOLDERS.txt


: ���㏈��
  rem �R�s�[���t�H���_�c���[�t�@�C���쐬
  tree %targetRoot%>TARGETTREE.txt

  rem �R�s�[��t�H���_�c���[�t�@�C���쐬
  tree %destinationRoot%\%targetRootDirName%>DESTINATIONTREE.txt


  echo;
  echo �e�c���[�t�@�C�����I��点�Ă���o�b�`���I�����Ă�������
  pause

  rem �c���[�t�@�C���폜
  del "%~dp0\TARGETTREE.txt"
  del "%~dp0\DESTINATIONTREE.txt"