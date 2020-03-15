@echo off
title %~nx0
echo 7Zip���s�o�b�`


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: �����L���m�F
  rem �������Ȃ��ꍇ
  if "%~1"=="" (
    rem ���[�U���͏�����
    goto :NOARG
  )

  rem �������Ԉ���Ă���(�t�@�C��/�t�H���_�����݂��Ȃ�)�ꍇ
  if not exist %1 (
    echo;
    echo �w��t�@�C��/�t�H���_���g�p�ł��܂���
    rem ���[�U���͏�����
    goto :NOARG
  )

  rem ������ϐ��ɐݒ�
  set targetPath=%1

  rem �g���q���f��
  goto :EXTENSIONDECISION


rem ���[�U���͏���
:NOARG
  echo;
  echo ���k�A�𓀂��s���t�@�C��/�t�H���_�p�X����͂��Ă�������

  rem �ϐ�������
  set USR=""
  set /P USR="���͂��Ă�������(����\�Ȃ�):"

  rem �u""�v���͑΍�
  set targetPath=%USR:"=%
  set targetPath="%targetPath%"
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if %targetPath%=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      pause
      goto :EOF
    )
  : �˂��ݕԂ�_���̓p�X�������̏ꍇ
    if not exist %targetPath% (
      echo;
      echo ���̓p�X������������܂���
      goto :NOARG
    )


rem �g���q���f
:EXTENSIONDECISION
  rem �f�B���N�g���t�@�C�����o�b�`�g�p_�g���q�擾
  call %call_DirFilePathInfo% %targetPath% x
  set targetExtension=%return_DirFilePathInfo%

  rem ���k�t�@�C���̏ꍇ
  if "%targetExtension%"==".7zip" (
    rem �𓀏�����
    goto :THAWING
  )
  if "%targetExtension%"==".zip" (
    rem �𓀏�����
    goto :THAWING
  )

  rem ���k�t�@�C���łȂ��ꍇ
  rem ���k������
  goto :COMPRESS


rem �𓀏���
:THAWING
  rem ����������ꍇ
  if not "%~1"=="" (
    rem ������S�ĕϐ��ɐݒ�
    set targetPath=%*
  )

  rem 7za.exe���g�p���ĉ𓀂����s
  "%~dp07Zip\7za.exe" x -p%password% %targetPath%

  rem �˂��ݕԂ�_�p�X���[�h���͂��Ȃ��ꍇ
  if not %ERRORLEVEL%==2 (
    echo;
    echo �𓀂ɐ������܂���
    pause
    goto :EOF
  )

  : �𓀃p�X���[�h���͏���
    echo;
    echo �𓀃p�X���[�h����͂��Ă�������
    : �p�X���[�h�t���̃t�@�C�����𓀂��悤�Ƃ���Ǝ����Ń��[�U���͂ƂȂ邪
    : ���͓��e���}�X�N����Ă��܂����ߓ��͏�����Ǝ��ŗp��

    rem ���͕ϐ�������
    set USR=
    set /P USR="���͂��Ă�������:"

    set password=%USR%
    rem �p�X���[�h������ꍇ
    if not "%password%"=="" (
      rem �𓀏��������[�v
      goto :THAWING
    )

  echo;
  echo ���͂�����܂���
  echo �I�����܂�
  pause
  goto :EOF


rem ���k����
:COMPRESS

  rem �f�B���N�g���t�@�C�����o�b�`�g�p_�t�@�C��/�t�H���_���擾
  rem �ϐ��Ɉ�����S�Ċi�[����O�ɍs��
  call %call_DirFilePathInfo% %targetPath% n
  set targetName=%return_DirFilePathInfo%

  rem ����������ꍇ
  if not "%~1"=="" (
    rem ������S�ĕϐ��ɐݒ�
    set targetPath=%*
  )

  : ���k�p�X���[�h���͏���
    echo;
    echo ���k�p�X���[�h����͂��Ă�������
    echo �ݒ肵�Ȃ��ꍇ�͋󔒂ŃG���^�[
    : 7Zip��-p�I�v�V�����̓p�X���[�h�����[�U���͂�����@�\�����邪
    : �󔒂Ŋm�肵���ꍇ�A�󔒂��p�X���[�h�ɂȂ邽�ߓƎ��ŗp��

    rem �p�X���[�h�g�p�I�v�V����������
    set isPassword=
    rem ���͕ϐ�������
    set USR=
    set /P USR="���͂��Ă�������:"

    set password=%USR%
    rem �p�X���[�h������ꍇ
    if not "%password%"=="" (
      rem �p�X���[�h�g�p�I�v�V������ݒ�
      set isPassword=-p
    )

  rem 7za.exe���g�p���Ĉ��k�����s
  "%~dp07Zip\7za.exe" a %isPassword%%password% "%~dp0%targetName%".7zip %targetPath%

  pause
  exit