@echo off
title %~nx0
echo �R�}���h���[�v_Ping
: ����01:���[�v�J�n���̐��l�̂ݔN���������b�~��
: ����02:���[�v�J�E���^
: ����03:�O�I�v�V����
: ����04:��I�v�V����
: ����05:�Ώۈ���
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
    set option1=%~3
    set option2=%~4
    set arg=%5

  rem �����������ڃ��x��
  :MULTI_ARG
    rem �l������ꍇ
    if not "%~6"=="" (

      rem �������ڂɒǉ�
      set arg=%arg% %6
      rem �����V�t�g
      shift
      rem �����������ڃ��x����
      goto :MULTI_ARG
    )

  : �R�}���h���s
    echo   ���s����   :%datetime%
    echo   �J�E���^   :%counter%
    echo   �I�v�V����1:%option1%
    echo   ����       :%arg%
    echo   �I�v�V����2:%option2%

    ping %option1% %arg% %option2%>>PingCmd_%datetime%.txt
    echo;
    echo;

ENDLOCAL
exit /b