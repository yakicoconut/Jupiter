@echo off
title %~nx0
echo .bat����w�肵��.sql�t�@�C�������s����


: ���ʐݒ�ϐ�
  : �錾
    rem ���O�C�����[�U��
    set loginUser=sa
    rem ���O�C���p�X���[�h(�u%�v�́u%�v�ŗv�G�X�P�[�v)
    set loginPassword=PassWord
    rem ���sSQL�t�@�C�����w��
    set cmdFileName=OutputTableValues.sql
    rem �Ώ�DB�t�@�C�����w��
    set targetDbFileName=TargetDb.txt


  : �\��
    echo;
    echo �ݒ���(�ύX�͖{�o�b�`�t�@�C���𒼐ڕҏW)
    echo ���O�C�����[�U��  :%loginUser%
    echo ���O�C���p�X���[�h:%loginPassword%
    echo ���sSQL�t�@�C��   :%cmdFileName%
    echo �Ώ�DB�t�@�C��    :%targetDbFileName%
    echo ���Ώ�DB�t�@�C���ɂ͑Ώۂ�DB���̂��ӏ������ɂ���


: �ΏۃT�[�o����
  echo;
  echo �ΏۃT�[�o�̎w��
  set /P USR="���͂��Ă�������:"
  set serverName=%USR%

  rem ���͐��������f�T�u���[�`���g�p
  rem �T�[�o���̂������ɐݒ�
  set y=%serverName%
  call :INPUTDETECTION


: �t�@�C�����݊m�F
    rem �t�@�C�����݊m�F�T�u���[�`���g�p
    rem ���sSQL�t�@�C���p�X�������ɐݒ�
    set y=%cmdFileName%
    call :ISFILEEXSIST

    rem �t�@�C�����݊m�F�T�u���[�`���g�p
    rem �Ώ�DB�t�@�C���p�X�������ɐݒ�
    set y=%targetDbFileName%
    call :ISFILEEXSIST


: �Ώ�DB�t�@�C�����[�v
  rem �w�肵���t�@�C���������Ƃ��Ďg�p
  for /f "delims=" %%a in (%targetDbFileName%) do (
    rem �R�}���h���s�T�u���[�`���g�p
    rem �Ώ�DB���̂������ɐݒ�
    set x=%%a
    call :EXECCMD
  )

  pause
  exit


rem �R�}���h���s�T�u���[�`��
:EXECCMD
  rem DB���̐ݒ�
  set dbName=%x%
  set logFileName=%x%
  rem template�łȂ��ꍇ�͉��H����
  if not "%x%" == "GemDB_template" (
    rem GemDB_xxxxx�ɉ��H
    set logFileName=%x:~0,11%
  )
  set logFileName=%logFileName%.txt

  rem -S:�T�[�o���A-E:Windows�F�ؐڑ��A-d:DB���A-o:���ʏo�̓t�@�C�����A-i:���sSQL�t�@�C���A-Q:���sSQL�R�}���h
  sqlcmd -S %serverName%    ^
         -U %loginUser%     ^
         -P %loginPassword% ^
         -d %dbName%        ^
         -i %cmdFileName%   ^
         -o %logFileName%

  rem �T�u���[�`������������
  set x=
  rem �T�u���[�`���I��
  exit /b


rem ���͐��������f�T�u���[�`��
:INPUTDETECTION
  if "%y%"=="" (
    echo;
    echo ���͂�����܂���
    echo �I�����܂�

    pause
    rem �o�b�`�I��
    exit
  )

  rem �T�u���[�`������������
  set y=
  rem �T�u���[�`���I��
  exit /b


rem �t�@�C�����݊m�F�T�u���[�`��
:ISFILEEXSIST
  if exist %y% (
    rem �T�u���[�`������������
    set y=
    rem �T�u���[�`���I��
    exit /b
  )

  echo;
  echo %y%
  echo ��L�̃t�@�C�������݂��܂���
  echo �I�����܂�

  pause
  rem �o�b�`�I��
  exit


: ����
: �E�o�b�`�t�@�C�����̉��s�́u^�v�ōs��
: �E�Q�l�T�C�g
:    SQLServer��select�̌��ʂ�CSV�ŏo�͂�����@�B | mokuzine's note
:     http://note.mokuzine.net/sqlserver-csv-out/