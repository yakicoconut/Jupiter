@echo off
title %~nx0
echo 7Zip�ꊇ�𓀃o�b�`
: �p�X���[�h���L�q�����t�@�C�����g�p���邱�Ƃ�
: �p�X���t�@�C�����ꊇ�𓀉\


rem �p�X���[�h�t�@�C���p�X����
:INPUTPASSFILE
  echo;
  echo �p�X���[�h�t�@�C��(.txt)�̃p�X����͂��Ă�������
  echo �p�X���[�h�͉𓀃t�@�C���Ƒ΂ɂȂ�悤�L�q���Ă�������
  echo �p�X���[�h���ݒ肳��Ă��Ȃ��t�@�C���͋�s�Ƃ��Ă�������

  rem �ϐ�������
  set USR=""
  set /P USR="���͂��Ă�������:"

  rem �u""�v���͑΍�
  set targetPassFile=%USR:"=%
  set targetPassFile="%targetPassFile%"
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if %targetPassFile%=="" (
      goto :INPUTTARGETROOT
    )
  : �˂��ݕԂ�_���̓p�X�������̏ꍇ
    if not exist %targetPassFile% (
      echo;
      echo ���̓p�X������������܂���
      goto :INPUTPASSFILE
    )


rem �Ώۈ��k�t�@�C�����[�g�t�H���_�p�X����
:INPUTTARGETROOT
  echo;
  echo �Ώۈ��k�t�@�C���̃��[�g�t�H���_�p�X����͂��Ă�������

  rem �ϐ�������
  set USR=""
  set /P USR="���͂��Ă�������(����\�Ȃ�):"

  rem �u""�v���͑΍�
  set targetRoot=%USR:"=%
  set targetRoot="%targetRoot%"
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if %targetRoot%=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      pause
      goto :EOF
    )
  : �˂��ݕԂ�_���̓p�X�������̏ꍇ
    if not exist %targetRoot% (
      echo;
      echo ���̓p�X������������܂���
      goto :INPUTTARGETROOT
    )


: ��������
  rem �p�X���[�h�t�@�C���̎w�肪����Ă��Ȃ��ꍇ
  if %targetPassFile%=="" (
    rem �Ώۃt�@�C�����[�v������
    goto :TARGETDIRLOOP
  )


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
: �p�X���[�h�̒��g��Y���ϐ��Ɋi�[
  rem �Y��������
  set /a passSuffix=1
  rem �p�X���[�h�t�@�C������󔒍s���܂ޑS�Ă̍s�����[�v
  for /f "usebackq tokens=1* delims=:" %%a in (`findstr /n "^" %targetPassFile%`) do (
    rem �p�X���[�h��Y���ϐ��Ɋi�[
    set pass_!passSuffix!=%%b

    rem �Y���C���N�������g
    set /a passSuffix+=1
  )


rem �Ώۃt�@�C�����[�v����
:TARGETDIRLOOP
  rem ���I�ϐ����o���J�E���^������
    set /a count=1
  for /f "usebackq delims=" %%a in (`dir /a-d /b %targetRoot%`) do (
    set x=%%a

    rem �𓀏����T�u���[�`���g�p
    call :THAWING

    rem �J�E���^�C���N�������g
    set /a count+=1
  )

  exit


rem �𓀏����T�u���[�`��
:THAWING
  rem �Ώۃt�@�C���p�X�쐬
  set targetFilePath=%targetRoot:"=%\%x%

  rem 7za.exe���g�p���ĉ𓀂����s
  "%~dp07Zip\7za.exe" x -p!pass_%count%! "%targetFilePath%"

  rem �T�u���[�`���𔲂���
  exit /b