@echo off
title %~nx0
echo ���s�R�}���h�t�@�C��
echo;
: ����01:���[�v�J�n���̐��l�̂ݔN���������b�~��
: ����02:���[�v�J�E���^
: ����03:�I�v�V����
: ����04:�Ώۈ���
: �ߒl  :�Ȃ�


SETLOCAL
  : ��������
    rem �˂��ݕԂ�_�������Ȃ��ꍇ
    if "%~1"=="" (
      echo ���{�t�@�C���͒P�̂Ŏ��s���Ȃ��ł�������
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

    ping %option% %arg%
    echo;
    echo;

ENDLOCAL
exit /b