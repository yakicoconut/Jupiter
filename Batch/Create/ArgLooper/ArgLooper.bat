@echo off
title %~nx0
echo �������[�v�R�}���h���s
echo;
rem �e�L�X�g�t�@�C���̓��e�������ɃR�}���h�����[�v���s����


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
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
      rem �������擾
      set initChar=!row:~0,1!

      rem ���������u#�v(�R�����g�s)�łȂ��ꍇ
      if not !initChar!==# (
        rem �J�E���^�C���N�������g
        set /a counter=!counter!+1

        rem ���s�R�}���h�t�@�C���g�p
        call !cmdFile! %datetime% !counter! !option1! "!row!" !option2!
      )

      rem �s�̐擪���u#option1 �v�̏ꍇ
      if "!row:~0,9!"=="#option1:" (
        rem �I�v�V�����p�ϐ��ɐݒ�
        set option1="!row:~9!"
      )
      if "!row:~0,9!"=="#option2:" (
        set option2="!row:~9!"
      )
      if "!row:~0,9!"=="#command:" (
        rem �R�}���h���s
        !row:~9!
      )
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