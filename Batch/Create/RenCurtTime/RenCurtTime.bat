@echo off
title %~nx0
echo ���ݎ����Ńt�@�C������������
echo ��������:�����݂̂ɓK�p
echo �����Ȃ�:���K�w�S�t�@�C���ɓK�p


rem �ϐ����[�J����
SETLOCAL ENABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"
  rem ���l�̂ݔN���������b�~���擾�o�b�`
  set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"


: ���O����
  rem ���g�̃t�H���_�p�X�擾
  set currentDir=%~dp0

  rem ������������Ƃ��̓J�����g�f�B���N�g���������̈ʒu�ɂȂ邽��
  rem �J�����g�f�B���N�g�������g�̃t�H���_�ɕύX
  cd /d %currentDir%

  rem ��ʃt�H���_�p�X�擾
  rem �f�B���N�g���t�@�C�����o�b�`�g�p
  call %call_DirFilePathInfo% %currentDir:~0, -1% dp
  set oneOnTheDir=%return_DirFilePathInfo%


: �����L���m�F
  rem �������Ȃ��ꍇ
  if "%~1"=="" (
    rem �����Ȃ�������
    goto :NOARG
  )

  : �������菈��
    rem �����i�[
    set targetFile=%1

    rem �t�@�C�����擾
    rem �f�B���N�g���t�@�C�����o�b�`�g�p
    call %call_DirFilePathInfo% %targetFile% nx
    set beforeFileName=%return_DirFilePathInfo%

    rem �g���q�擾
    rem �f�B���N�g���t�@�C�����o�b�`�g�p
    call %call_DirFilePathInfo% %targetFile% x
    set extension=%return_DirFilePathInfo%

    echo;
    rem �����̃t�@�C�����J�����g�t�H���_�Ɉړ�
    move %targetFile% %currentDir%

    rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%

    rem �ύX��t�@�C�����쐬
    set afterFileName=%datetime%%extension%

    rem ���l�[��
    ren "%beforeFileName%" %afterFileName%

    rem ��ʃt�H���_�ړ��T�u���[�`���g�p
    call :MOVTOONEONTHEDIR %afterFileName%

    exit


rem �����Ȃ�����
:NOARG
  rem �e�t�@�C�������擾�������Ƃ��Ďg�p
  dir %targetPath% /a-d /b>FILES.txt

  rem �t�@�C�����[�v
  for /f "delims=" %%a in (FILES.txt) do (
    rem ���[�v�Ώ�(�R�s�[�Ώۃt�@�C����)��ϐ��Ɋi�[
    set x=%%a

    rem ���^�t�@�C���ޔ�
    if "!x!" == "FILES.txt" (echo ������1) else (
      if "!x!" == "%~nx0"    (echo ������2) else (
        rem �g���q�擾
        rem �f�B���N�g���t�@�C�����o�b�`�g�p
        call %call_DirFilePathInfo% "!x!" x
        set extension=!return_DirFilePathInfo!

        rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
        call %call_GetStrDateTime%
        set datetime=!return_GetStrDateTime!

        rem �ύX��t�@�C�����쐬
        set afterFileName=!datetime!!extension!

        rem ���l�[��
        ren "!x!" !afterFileName!

        rem ��ʃt�H���_�ړ��T�u���[�`���g�p
        call :MOVTOONEONTHEDIR !afterFileName!
      )
    )
  )

  del FILES.txt

  exit


rem ��ʃt�H���_�ړ��T�u���[�`��
:MOVTOONEONTHEDIR
  echo;
  rem �Ώۃt�@�C������ʃt�H���_�Ɉړ�
  move %currentDir%%afterFileName% %oneOnTheDir%

  rem �T�u���[�`���I��
  exit /b