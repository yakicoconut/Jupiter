@echo off
title %~nx0
rem �p���[�V�F�����s�o�b�`


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: ���g�̃t�@�C����������s�Ώۂ�.ps1�t�@�C�������擾
  rem ���g�̃t�@�C�����擾
  set myName=%~nx0

  rem �p�X�ݒ�
  rem �������Ƀp�X���g�p�������ꍇ�A�ȉ��R�}���h���́u%~dp0\�v��u��
  set pS1=%~dp0%myName%
  rem �t�@�C��������u_Kick.bat�v���u.ps1�v�ɒu����
  set pS1=%pS1:_Kick.bat=.ps1%


: �Ώ�PS�t�@�C�����݊m�F
  if not exist %pS1% (
    rem �{�t�@�C�����̒u�������Ώە����擾
    set fileNmae=%myName:_Kick.bat=%

    echo �Ώ�.ps1�t�@�C�������݂��܂���
    echo;
    echo �{�t�@�C���́u!fileNmae!�v������
    echo ���s�Ώۂ�.ps1�t�@�C�����ɕύX���Ă���ēx���s���Ă�������

    pause
    exit
  )


: .ps1�̎��s
  rem .ps1�t�@�C�����Ǘ��Ҏ��s
  powershell -ExecutionPolicy Unrestricted %pS1%

pause