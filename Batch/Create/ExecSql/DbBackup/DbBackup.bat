@echo off
title %~nx0
echo .bat����w�肵��.sql�t�@�C�������s
echo BD�̃o�b�N�A�b�v�X�N���v�g��systemDB�ɑ΂��Ď��s���邽��
echo �Ώ�DB�t�@�C���͎g�p���Ȃ�


: ���ʐݒ�ϐ�
  : �錾
    rem *���O�C�����[�U��*
    set loginUser=sa
    rem *���O�C���p�X���[�h(�u%�v�́u%�v�ŗv�G�X�P�[�v)*
    set loginPassword=PassWord
    rem *���sSQL�t�@�C�����w��*
    set cmdFileName=DbBackip.sql

  : �\��
    echo;
    echo �ݒ���(�ύX�͖{�o�b�`�t�@�C���𒼐ڕҏW)
    echo ���O�C�����[�U��  :%loginUser%
    echo ���O�C���p�X���[�h:%loginPassword%
    echo ���sSQL�t�@�C��   :%cmdFileName%

  : ���
    rem �{�o�b�`�ʒu���擾
    set execDir=%~dp0


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


rem �R�}���h���s�T�u���[�`��
:EXECCMD
  echo;
  rem -S:�T�[�o���A-E:Windows�F�ؐڑ��A-d:DB���A-o:���ʏo�̓t�@�C�����A-i:���sSQL�t�@�C���A-Q:���sSQL�R�}���h
  sqlcmd -S %serverName%    ^
         -U %loginUser%     ^
         -P %loginPassword% ^
         -i %cmdFileName%


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