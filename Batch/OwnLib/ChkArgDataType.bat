@echo off
title %~nx0
rem �����^����o�b�`
: ����
:   01 :�w�������
:   02 :����^
:         �u""�v���Ɉȉ��A�^�𔼊p�X�y�[�X��
:       �Ώۈ������ݒ�
:         PATH:�t�@�C���p�X
:         NUM :���l
:         DATE:���t
:         TIME:����
:         �ȊO:������
:         (��:�p�X�A���l�A���t�A���l�̈����w��
:             "PATH NUM DATE NUM"
:   03~:���ؒl
:       �����ɑΉ�
: �ߒl
:   01:�����J�E���g
:   02:���茋��
:        0:���f���s
:        1:���f����
:   03:�e�����̔��f���ʕԂ�l
:      ������A���l�A�p�X�ɂ��Ă͌Œ�l�ݒ�
:      �ߒl01(���茋��)�����s�̏ꍇ�́u""�v�ݒ�


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : �����^���z��
    rem �S�����ϐ���
    set argCmd=%*
    rem �w�������
    set chkCount=%1

    rem �J�E���^������
    rem ���J�E���g�Ώۂ�3�ڂ̈�������̂���
    rem   �����킹�Ƃ��āu-2�v�X�^�[�g
    set /a argCt=-2
    for %%a in (!argCmd!) do (
      rem �J�E���^�C���N�������g
      set /a argCt+=1
      rem �^���z��Ɉ����i�[
      set arg!argCt!=%%a
    )

    rem �˂��ݕԂ�_�����̐�����v���Ȃ��ꍇ
    if not %argCt%==%chkCount% (
      rem ���茋�ʂ��u0:���s�v�ɐݒ�
      set retVal=0
      rem ���������͂łȂ��ꍇ
      if not %argCt%==0 (
        call :INVALID_DATA �����̐�����`�ƈقȂ�܂�
        echo ��`��:%chkCount%
        echo ������:%argCt%
      )
      goto :RETURN
    )

    rem �^�����^���z�񉻃T�u���[�`���g�p
    rem �^���z��̈��(����^)�w��
    call :ARG_DATA_TYPE %arg0:"=%

    rem ����^���ƈ����̐�������Ȃ��ꍇ
    if not %argCt%==%argTypeCt% (
      echo ����^�̐��ƈ����̐��������܂���
      echo ����^��:%argTypeCt%
      echo ������  :%argCt%

      rem �����������ʏ����T�u���[�`���g�p
      call :INVALID_DATA "�����̊m�F�����Ă�������"
      goto :RETURN
    )

  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem ���l����o�b�`
    set call_ChkNum=%~dp0"ChkNum.bat"
    rem ���t��������o�b�`
    set call_ChkDateFormat=%~dp0"ChkDateFormat.bat"
    rem ������������o�b�`
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"

  : �[���z�񏇎��o�����x��
     rem ���茋�ʏ�����(1:����)
     set retVal=1
     rem ���o���J�E���^
     rem ����ڂ̈���������^�̂��ߓ�ڈȍ~����X�^�[�g
     set /a getCt=1

     :GET_ARRAY
      : �^����
       rem ���f���ʋ^���z��ݒ�(������Œ�l�ݒ�)
       set jdg!getCt!=STR

       : �t�@�C���p�X
         if !argType%getCt%!==PATH (
           rem �p�X�����݂��Ȃ��ꍇ
           if not exist !arg%getCt%! (
             call :INVALID_DATA �p�X�����݂��܂���
             goto :RETURN
           )
           rem ���f���ʋ^���z��ݒ�(�p�X�Œ�l�ݒ�)
           set jdg!getCt!=PATH
         )
       : ���l
         if !argType%getCt%!==NUM (
           rem ���l����o�b�`�g�p
           call %call_ChkNum% !arg%getCt%:"=!

           rem ���l�łȂ��ꍇ
           if !return_ChkNum!==0 (
             call :INVALID_DATA ���l�ł͂���܂���
             goto :RETURN
           )
           rem ���f���ʋ^���z��ݒ�(���l�Œ�l�ݒ�)
           set jdg!getCt!=NUM
         )
       : ���t
         if !argType%getCt%!==DATE (
           rem ���t��������o�b�`�g�p
           call %call_ChkDateFormat% !arg%getCt%:"=!

           rem ���t�łȂ��ꍇ
           if !return_ChkDateFormat1!==0 (
             call :INVALID_DATA ���t�ł͂���܂���
             goto :RETURN
           )
           rem ���茋�ʂ𐬌��ɏ�����ݒ�
           set jdg!getCt!=!return_ChkDateFormat2!
         )
       : ����
         if !argType%getCt%!==TIME (
           rem ������������o�b�`�g�p
           call %call_ChkTimeFormat% !arg%getCt%:"=!

           rem �����łȂ��ꍇ
           if !return_ChkTimeFormat1!==0 (
             call :INVALID_DATA �����ł͂���܂���
             goto :RETURN
           )
           set jdg!getCt!=!return_ChkTimeFormat2!
         )

       rem �J�E���^���}�b�N�X�Ȃ�I��
       if %getCt% == %argCt% goto :RETURN

       rem �J�E���^�C���N�������g
       set /a getCt+=1
       goto :GET_ARRAY

  rem �o�b�`�I��
  :RETURN
    rem ���茋�ʂ����s�̏ꍇ
    rem ���f���ʋ^���z����o���T�u���[�`���g�p
    if %retVal%==1 call :JDG_ARY_TO_VAR

rem �߂�l(2�ȏ�̏ꍇ�A�߂�l2�ȍ~�́u&&�v���O�X�y�[�X����)
ENDLOCAL && set ret_ChkArgDataType1=%argCt%&& set ret_ChkArgDataType2=%retVal%&& set ret_ChkArgDataType3="%jdgResult%"
exit /b

rem �^�����^���z�񉻃T�u���[�`��
:ARG_DATA_TYPE
  rem �����擾�R�}���h
  set argTypeCmd=%*

  rem �������o�����[�v
  set /a argTypeCt=0
  for %%a in (!argTypeCmd!) do (
    rem �J�E���^�C���N�������g
    set /a argTypeCt+=1
    rem �^���z��Ɉ����i�[
    set argType!argTypeCt!=%%a
  )

  exit /b

rem �����������ʏ����T�u���[�`��
:INVALID_DATA
  echo;
  echo %~1

  rem ���茋�ʂ��u0:���s�v�ɐݒ�
  set retVal=0

  rem �T�u���[�`���I����
  exit /b

rem ���f���ʋ^���z����o���T�u���[�`��
:JDG_ARY_TO_VAR
  rem �ŏ��̒l�𔻒f���ʕϐ��ɒǉ�
  set jdgResult=%jdg1%

  rem �������o�����[�v
  set /a jdgCt=1
  :JDG_ARY_TO_VAR_LOOP
    rem �J�E���^���}�b�N�X�Ȃ�I��
    if %jdgCt% == %argCt% exit /b
    set /a jdgCt+=1

    rem ���f���ʕϐ��ɒǉ�
    set jdgResult=%jdgResult% !jdg%jdgCt%!

    goto :JDG_ARY_TO_VAR_LOOP