@echo off
title %~nx0
echo ffmpeg�o�b�`�A�����s
: ffmpeg���g�p����o�b�`�̘A���Ăяo�����ł��Ȃ����߁A
: �e�L�X�g�t�@�C���̓��e�������ɃR�}���h�����[�v���s����
: Strange errors when using ffmpeg in a loop - Unix & Linux Stack Exchange
: 	https://unix.stackexchange.com/questions/36310/strange-errors-when-using-ffmpeg-in-a-loop



: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����J�E���g
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %argc%==0 goto :USER_INPUT
  rem ��������`�ʂ�̏ꍇ�A���������
  if %argc%==1 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:1
  pause
  exit /b


rem ���[�U���͏���
:USER_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set tgtPath=%return_UserInput1%


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH" %1
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType1%==0 goto :EOF
  REM rem �^���茋�ʈ��p��
  REM for /f "tokens=2,3" %%a in (%ret_ChkArgDataType2%) do (
  REM   rem �����t�H�[�}�b�g�擾
  REM   set starFmt=%%a
  REM   set distFmt=%%b
  REM )

  : �������p��
    set tgtPath=%1


: �R�}���h���s
  for /f "usebackq delims=" %%a in (%tgtPath%) do (
    REM %%a
    REM if %%a==REM pause

    rem �Ώۈ�s
    set row=%%a

    rem �s���̓T�u���[�`���g�p
    call :ANA_ROW
  )

  pause
  exit /b


rem �s���̓T�u���[�`��
:ANA_ROW
  rem �������擾
  set initChar=%row:~0,1%

  : �Ώےl����
    rem ��������W�N�H�[�g�̏ꍇ�A�R�}���h���s�T�u���[�`����
    if %initChar%^"=="^" ( goto :EXEC_CMD )
    rem ���������u#�v�̏ꍇ�A�T�u���[�`���I��
    if %initChar%==# ( exit /b )

rem �R�}���h���s�T�u���[�`��
:EXEC_CMD
  call %row%
  echo;
  exit /b