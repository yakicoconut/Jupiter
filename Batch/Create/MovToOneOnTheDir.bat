@echo off
title %~nx0
echo �Ώۃt�H���_���̑S�Ẵt�@�C�������̃f�B���N�g���ֈړ�


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"


: �R�s�[�����[�g�t�H���_����
  echo;
  echo �Ώۃt�H���_����

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������(����\�Ȃ�):"
  set targetPath=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetPath%"=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      goto :EOF
    )


: �t�@�C���R�s�[
  rem �f�B���N�g���t�@�C�����o�b�`�g�p_���̃t�H���_�p�X�擾
  call %call_DirFilePathInfo% %targetPath% dp
  set oneOnThePath=%return_DirFilePathInfo%

  rem �e�t�@�C�������擾�������Ƃ��Ďg�p
  dir %targetPath% /a-d /b>FILES.txt

  rem �t�@�C�����[�v
  for /f "delims=" %%a in (FILES.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�@�C����)��ϐ��Ɋi�[
    set x=%%a

    rem ���^�t�@�C���ޔ�
    if "!x!" == "FILES.txt" (echo ������1) else (
      rem �f�B���N�g���ړ�����
      move "%targetPath%\!x!"  "%oneOnThePath%"
    )
  )

del FILES.txt
pause