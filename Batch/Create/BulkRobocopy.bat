@echo off
title %~nx0
echo �o�b�N�A�b�v����
echo ���Ώۃt�H���_�̓��̃t�H���_�����g�p����


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION


: �Ώۃt�@�C������
  echo;
  echo �Ώۃt�H���_���L�q�����t�@�C�����w�肵�Ă�������
  set /P USR="���͂��Ă�������:"
  set targetFile=%USR%
  : �˂��ݕԂ�_�t�@�C�����݊m�F
    if not exist %targetFile% (
      echo;
      echo �t�@�C�������݂��܂���
      echo �I�����܂�

      pause
      exit
    )

  rem ������������T�u���[�`���g�p
  set y=%targetFile%
  call :INVALIDCHARA

  rem �_�u���N�H�[�e�[�V�������f�T�u���[�`���g�p
  set y=%targetFile%
  call :WQUOTATIONDECSION
  set targetFile=%y%


: �w��t�@�C������
  rem �w�肵���t�@�C���������Ƃ��Ďg�p
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem �o�b�N�A�b�v�����T�u���[�`���g�p
    rem �Ώۃt�H���_�p�X�������ɐݒ�
    set x=%%a
    call :EXECROBOCOPY
  )


rem ���㏈��
:END
  echo;
  echo �R�s�[�����I��

  pause
  exit


rem �o�b�N�A�b�v�����T�u���[�`��
:EXECROBOCOPY
  : �o�̓t�@�C���p�X�쐬
    rem ���̃t�H���_�p�X�擾
    for %%a in (%x%) do set outPutBaseFolderName=%%~dpa
    rem �����́u\�v�}�[�N����
    set outPutBaseFolderName=%outPutBaseFolderName:~0,-1%
    rem �t�H���_���擾
    for %%a in (%outPutBaseFolderName%) do set outPutBaseFolderName=%%~na
    rem �i�[�t�H���_���擾
    for %%a in (%x%) do set outPutFolderName=%%~na

  : ���{�R�s�[
    rem ���{�R�s�[���s
    rem �I�v�V����:�S�Ă̊K�w�ALog�t�H���_���O
    robocopy %x% %cd%\%outPutBaseFolderName%\%outPutFolderName% /mir /xd Log

  rem �T�u���[�`������������
  set x=
  rem �T�u���[�`���I��
  exit /b


rem ������������T�u���[�`��
:INVALIDCHARA
  rem �G���[���x��������(����R�}���h���s)
  cd >NUL

  echo %y% | find "(" >NUL
  echo %y% | find ")" >NUL

  : �G���[���x������
  :   0:���݂���
  :   1:���݂��Ȃ�
  if %ERRORLEVEL% equ 0 (
    rem ���������\���T�u���[�`���g�p
    rem �u()�v���Łu()�v���g�p���������̕\�����s���Ȃ�����
    rem �T�u���[�`���őΉ�
    call :ECHOINVALIDCHARA

    pause
    rem �o�b�`�I��
    exit
  )

  rem �T�u���[�`������������
  set y=
  rem �G���[���x��������(����R�}���h���s)
  cd >NUL
  rem �T�u���[�`���I��
  exit /b


rem ���������\���T�u���[�`��
:ECHOINVALIDCHARA
  echo;
  echo %y%
  echo;
  echo �ɖ����ȕ����u(�v�A�u)�v�����܂܂�Ă��܂�
  echo �I�����܂�

  rem �T�u���[�`���I��
  exit /b


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