@echo off
title %~nx0
echo �R�}���h���[�v_Ping
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
    echo   ���s����  :%datetime%
    echo   �J�E���^  :%counter%
    echo   �I�v�V����:%option%
    echo   ����      :%arg%

    ping %option% %arg%
    echo;
    echo;

ENDLOCAL
exit /b