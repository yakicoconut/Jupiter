@echo off
title %~nx0
echo 7Zip���s�o�b�`
: �C���X�g�[�����Ȃ���zip��7z���k�t�@�C���������@ | 7-Zip
: 	https://sevenzip.osdn.jp/howto/non-install-compress.html
: �R�}���h��ZIP��7z�Ƀp�X���[�h��t���� | 7-Zip
: 	https://sevenzip.osdn.jp/howto/dos-command-password.html


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo=%~dp0"..\..\OwnLib\DirFilePathInfo.bat"
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


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

    rem �{������
    goto :RUN


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH" %1
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set tgtPath=%1


rem �{����
:RUN
  : �R�}���h���s
    for /f "usebackq delims=" %%a in (%tgtPath%) do (
      rem ���k�����T�u���[�`���g�p
      call :COMP %%a
    )

pause
exit /b


rem ���k�����T�u���[�`��
:COMP
  : �������p��
    rem ���k�Ώۃp�X
    set zipTgt=%1
    rem �p�X���[�h
    set pass="%~2"

    rem �p�X���[�h�w�肪����ꍇ�A�I�v�V�����ݒ�
    rem �u-p�v�I�v�V�����ƃp�X���[�h�̊ԂɃX�y�[�X�͓���Ȃ�
    set isPass=""
    if "%pass:"=%"=="" ( set pass="") else ( set isPass="-p")

    rem �o�̓t�@�C�����̍쐬
    rem �f�B���N�g���t�@�C�����o�b�`�g�p_�t�@�C�����擾
    call %call_DirFilePathInfo% %zipTgt% n
    set outName=%return_DirFilePathInfo%

  : ���k���s
    "%~dp07Zip\7za.exe" a %isPass:"=%%pass:"=% %~dp0%outName%.7z %zipTgt%

exit /b