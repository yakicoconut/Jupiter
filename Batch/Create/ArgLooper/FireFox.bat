@echo off
title %~nx0
echo �R�}���h���[�v_FireFox
: ����01:���[�v�J�n���̐��l�̂ݔN���������b�~��
: ����02:���[�v�J�E���^
: ����03:�I�v�V����
: ����04:�Ώۈ���
: �ߒl  :�Ȃ�


SETLOCAL
  : ��������
    rem �˂��ݕԂ�_�������Ȃ��ꍇ
    if "%~1"=="" (
      echo �{�t�@�C���͒P�̂Ŏ��s�����A
      echo ArgLooper.bat����Ăяo���Ă�������
      echo �I�����܂�
      pause
      exit
    )

  : ����
    set datetime=%~1
    set counter=%~2
    set option=%~3
    set arg=%~4

  : �R�}���h���s
    echo %datetime%
    echo %counter%
    echo %option%
    echo %arg%

    "C:\Program Files\Mozilla Firefox\firefox.exe" %option% %arg%
    echo;
    echo;

ENDLOCAL
exit /b