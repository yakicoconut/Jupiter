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
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 1 "PATH" %1
  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %ret_ChkArgDataType1%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set tgtPath=%1

  rem �{������
  goto :RUN


rem ���[�U���͏���
:USER_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set tgtPath=%return_UserInput1%


rem �{����
:RUN
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