@echo off
title %~nx0
echo �Ώۃf�B���N�g�����̃t�@�C�����擾
echo ���Ώۃt�H���_�L�q�t�@�C���ɂ͐�΃p�X���ӏ������ɂ���


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


: ���O����
  rem �o�b�`�z�u�ʒu��ޔ�
  set originDir=%cd%


: �Ώۃt�@�C������
  echo;
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% �Ώۃt�H���_�L�q�t�@�C���w�� TRUE PATH
  rem ���͒l���p��
  set targetFile=%return_UserInput1%


: �w��t�@�C������
  rem �w�肵���t�@�C���������Ƃ��Ďg�p
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem �t�@�C�����X�g�T�u���[�`���g�p
    rem �Ώۃt�H���_�p�X�������ɐݒ�
    set x=%%a
    call :OUTPUTFILELIST
  )


rem ���㏈��
:END
  echo;
  echo �t�@�C�����擾�����I��

  rem ��Ɨp�t�@�C���ꗗ�̍폜
  del %originDir%\FILES.txt

  pause
  exit


rem �t�@�C�����X�g�o�̓T�u���[�`��
:OUTPUTFILELIST
  : �o�̓t�@�C���p�X�쐬
    rem ���̃t�H���_�p�X�擾
    for %%a in (%x%) do set outPutFileName=%%~dpa
    rem �����́u\�v�}�[�N����
    set outPutFileName=%outPutFileName:~0,-1%
    rem �t�H���_���擾
    for %%a in (%outPutFileName%) do set outPutFileName=%%~na
    rem �t�@�C�����쐬
    set outPutFileName=%originDir%\bin_%outPutFileName%.txt

  : ���[�g�t�H���_�t�@�C���ꗗ�擾
    rem �J�����g�f�B���N�g����Ώۃt�H���_�ɕύX
    cd /d %x%
    rem �J�����g�f�B���N�g���̕\��
    echo;
    echo;
    cd
    rem �����t�@�C�������o�b�`�̈ʒu�ɏo��
    dir * >>%outPutFileName%

  : �Ώۃ��[�g�f�B���N�g������
    rem �J�����g�f�B���N�g�����̃t�@�C���ꗗ���擾
    dir * /ad /b>FILES.txt

    rem �擾�����ꗗ���o�b�`�̈ʒu�Ɉړ�
    move FILES.txt %originDir% >nul

  : �Ώێq�f�B���N�g������
    rem �x�����ϐ��I��
    SETLOCAL ENABLEDELAYEDEXPANSION

    echo;
    echo �t�@�C�����擾�����J�n

    rem �擾�����t�H���_���������Ƃ��Ďg�p
    for /f "delims=" %%a in (%originDir%\FILES.txt) do (

      rem ���O�t�H���_�̎w��
      if "%%a" == "Log" (echo ������1) else (
        rem �J�����g�f�B���N�g�����������̃t�H���_�ɕύX
        cd /d %x%\%%a

        rem �J�����g�f�B���N�g���̕\��
        cd

        rem �J�����g�f�B���N�g���̃t�@�C�������o�b�`�̈ʒu�ɏo��
        dir * /s>>%outPutFileName%
      )
    )

  rem �T�u���[�`������������
  set x=
  rem �T�u���[�`���I��
  exit /b