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
  set rootSource=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%rootSource%"=="" (
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
  set rootDestination=%USR%
  : �󔒂̏ꍇ
    if "%rootDestination%"=="" (
      echo;
      echo ���͂�����܂���
      echo �J�����g�t�H���_���w�肵�܂�

      rem �J�����g�t�H���_���擾
      rem if���̒����ϐ��ɂ͒x�����ϐ����g�p����
      set rootDestination=%~dp0
      rem ������\���͂���
      set rootDestination=!rootDestination:~0,-1!
      echo !rootDestination!
    )


: �t�H���_�R�s�[
  rem �t�H���_�\���̏o��
  dir %rootSource% /b /ad /s>FOLDERS.txt

  rem �f�B���N�g���t�@�C�����o�b�`�g�p_�R�s�[�����[�g�t�H���_���擾
  call %call_DirFilePathInfo% %rootSource% n
  set rootSourceName=%return_DirFilePathInfo%
  rem �R�s�[�惋�[�g�t�H���_�ɃR�s�[�����[�g�t�H���_���쐬
  mkdir "%rootDestination%\%rootSourceName%"

  rem �o�͂����t�H���_������s������
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�H���_�p�X)��ϐ��Ɋi�[
    set x=%%a

    rem �R�s�[�����[�g�t�H���_�܂ł̃p�X���폜
    set x=!x:%rootSource%\=!

    rem �R�s�[�惋�[�g�t�H���_�Ƀt�H���_���쐬
    mkdir "%rootDestination%\%rootSourceName%\!x!"
  )

  rem ��ƃt�@�C���̍폜
  del FOLDERS.txt


: ���㏈��
  rem �R�s�[���t�H���_�c���[�t�@�C���쐬
  tree %rootSource%>TARGETTREE.txt

  rem �R�s�[��t�H���_�c���[�t�@�C���쐬
  tree %rootDestination%\%rootSourceName%>DESTINATIONTREE.txt


  echo;
  echo �e�c���[�t�@�C�����I��点�Ă���o�b�`���I�����Ă�������
  pause

  rem �c���[�t�@�C���폜
  del "%~dp0\TARGETTREE.txt"
  del "%~dp0\DESTINATIONTREE.txt"