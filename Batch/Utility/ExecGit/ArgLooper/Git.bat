@echo off
title %~nx0
echo �R�}���h���[�v_Git
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

  : �錾
    rem ���O�p���s�o�b�`�t�H���_�擾
    set crDir=%~dp0

  : ����
    set datetime=%~1
    set counter=%~2
    set option1=%~3
    set arg=%~4
    set option2=%~5

  : �R�}���h���s
    echo   ���s����   :%datetime%
    echo   �J�E���^   :%counter%
    echo   �I�v�V����1:%option1%
    echo   ����       :%arg%
    echo   �I�v�V����2:%option2%

    rem �t�@�C�������o���o��
    echo %counter%:%arg%>>%crDir%Git_%datetime%.txt

    rem Git���s
    git %option1% %arg% %option2%>>%crDir%Git_%datetime%.txt
    echo;>>%crDir%Git_%datetime%.txt
    echo;
    echo;

ENDLOCAL
exit /b