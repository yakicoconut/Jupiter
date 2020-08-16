@echo off
title %~nx0
echo �������[�v�R�}���h���s
echo;
rem �e�L�X�g�t�@�C���̓��e�������ɃR�}���h�����[�v���s����


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION
  : �ݒ�
    rem ���s�R�}���h�t�@�C��
    set cmdFile=""
    rem �����w��t�@�C��
    set argFile=""


  : ���O����
    rem �J�����g�f�B���N�g�����t�@�C���̈ʒu�ɕύX
    cd /d %~dp0


  : �Q�ƃo�b�`
    rem ���l�̂ݔN���������b�~���擾�o�b�`
    set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"
    rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%
    rem �f�B���N�g���t�@�C�����o�b�`
    set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


  : �ݒ�L���m�F
    rem ���s�R�}���h�t�@�C���ݒ肪����Ă���ꍇ
    if not %cmdFile%=="" (
      rem �����w��t�@�C���ݒ肪����Ă���ꍇ
      if not %argFile%=="" (
        rem �����w��t�@�C�������֑J��
        goto :ARG_FILE_PROCESS
      )
    )

    : �w��t�@�C���̐ݒ肪����Ă��Ȃ��ꍇ
      rem ���[�U���̓o�b�`
      set call_UserInput="..\..\OwnLib\UserInput.bat"
      rem ���[�U���̓T�u���[�`���g�p
      call :USER_INPT


  rem �����w��t�@�C������
  :ARG_FILE_PROCESS
    echo;
    echo;

    rem �f�B���N�g���t�@�C�����o�b�`�g�p
    call %call_DirFilePathInfo% %cmdFile% dp
    rem �Ώۃo�b�`�ʒu�ɃJ�����g�f�B���N�g���ύX
    cd /d %return_DirFilePathInfo%

    rem �w�肵���t�@�C�����s���ƂɃ��[�v
    set /a counter=0
    rem �I�v�V�����p�ϐ�������(�X�y�[�X�~1)
    set option1=" "
    rem ��������ɗ���I�v�V����
    set option2=""
    for /f "usebackq delims=" %%a in (%argFile%) do (
      rem �Ώۈ�s
      set row=%%a

      rem �s���̓T�u���[�`���g�p
      call :ANA_ROW
    )


  :END
    pause
    exit


rem ���[�U���̓T�u���[�`��
:USER_INPT
  rem ���s�R�}���h�t�@�C��
  call %call_UserInput% ���s�R�}���h�t�@�C���w�� TRUE PATH
  set cmdFile=%return_UserInput1%
  echo;

  rem �����w��t�@�C��
  call %call_UserInput% �����w��t�@�C���w�� TRUE PATH
  set argFile=%return_UserInput1%

  exit /b

rem �f�o�b�O�p�T�u���[�`��
:DEBUG
SETLOCAL
  set cmdFile=%~1
  set datetime=%~2
  set counter=%3
  set option1=%4
  set option2=%5
  set arg=%6

  rem �����������ڃ��x��
  :MULTI_ARG
    rem �l������ꍇ
    if not "%~7"=="" (
      rem �����V�t�g
      shift

      rem ���������i�[�T�u���[�`���g�p
      call :ARG_PLUS %7

      rem �����������ڃ��x����
      goto :MULTI_ARG
    )

  rem �l�\��
  echo %cmdFile%
  echo %datetime%
  echo %counter%
  echo %option1%
  echo %option2%
  echo %arg%
  pause
  echo;
  exit /b

  rem ���������i�[�T�u���[�`��
  :ARG_PLUS
    rem �������ڂɒǉ�
    set arg=%arg% %1
    exit /b

ENDLOCAL

rem �s���̓T�u���[�`��
:ANA_ROW
  rem �������擾
  set initChar=%row:~0,1%
  rem ���s�R�}���h�ϐ�������
  set execCmd=

  : �Ώےl����
    rem ��������W�N�H�[�g�̏ꍇ�A�����󂯓n�����x����
    if %initChar%^"=="^" ( goto :DELIVERY_ARG )
    rem ���������u#�v�̏ꍇ�A�V���[�v���̓��x����
    if %initChar%==# ( goto :ANA_SHARP )
    rem ���������X�y�[�X�̏ꍇ�A�s���͏I�����x����
    if "%initChar%"==" " ( goto :ANA_ROW_END )
    rem ��L������ł��Ȃ��ꍇ�A���̂܂܈����󂯓n�����x����

  rem �����󂯓n�����x��
  :DELIVERY_ARG
    rem �J�E���^�C���N�������g
    set /a counter=%counter%+1

    rem �o�b�`���s�T�u���[�`���g�p
    call :EXEC_BAT
    exit /b

  rem �V���[�v���̓��x��
  :ANA_SHARP
    rem �擪�\���擾
    set reserveWord=%row:~0,9%
    rem W�N�H�[�g��΍�
    set reserveWord="%reserveWord:"=%"

    rem �x�����ϐ�����
    if %reserveWord%=="#option1:" (
      rem �ۊ��ʑ΍�Ƃ��ĕϐ��ݒ���T�u���[�`����
      rem �O�I�v�V�����ݒ�T�u���[�`���g�p
      call :OPT_ONE
    )
    if %reserveWord%=="#option2:" (
      rem �O�I�v�V�����ݒ�T�u���[�`���g�p
      call :OPT_TWO
    )
    if %reserveWord%=="#command:" (
      rem ���s�R�}���h�ݒ�T�u���[�`���g�p
      call :SET_EXEC_CMD
    )

    rem �R�}���h���s
    %execCmd%
    exit /b

  rem �s���͏I�����x��
  :ANA_ROW_END
    exit /b

ENDLOCAL
  exit /b

rem �o�b�`���s�T�u���[�`��
:EXEC_BAT
  REM rem �f�o�b�O�p�T�u���[�`���g�p
  REM call :DEBUG %cmdFile% %datetime% %counter% %option1% %option2% %row%

  rem ���s�R�}���h�t�@�C���g�p
  call %cmdFile% %datetime% %counter% %option1% %option2% %row%
  exit /b

rem �O�I�v�V�����ݒ�T�u���[�`��
:OPT_ONE
  rem �\���ӌ���ϐ��ɐݒ�
  set option1="%row:~9%"
  exit /b

rem ��I�v�V�����ݒ�T�u���[�`��
:OPT_TWO
  set option2="%row:~9%"
  exit /b

rem ���s�R�}���h�ݒ�T�u���[�`��
:SET_EXEC_CMD
  rem ���s�R�}���h�ݒ�
  set execCmd=%row:~9%
  exit /b