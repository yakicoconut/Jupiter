@echo off
title %~nx0
rem ���[�U���̓o�b�`
: ����01:�\������
:          �u""�v�݂̂̏ꍇ�A�\�����Ȃ�
: ����02:�s�����̓��[�v
:          TRUE:�ē���
:          �ȊO:�I��
: ����03:���f���[�h
:          PATH:�t�@�C���p�X
:          NUM :���l
:          DATE:���t
:          TIME:����
:          �ȊO:������
: �ߒl1 :���͒l(�u""�v�t��)
: �ߒl2 :���茋��
:          0   :���f���s
:          1   :���f����
:          �ȊO:�Y�����f�̕Ԃ�l


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : ����
    rem �\������
    set description=%1
    rem �������̓��[�v
    set isInvalidLoop=%2
    rem ���f���[�h
    set judgeMode=%3


  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem �ۊ��ʊܗL����o�b�`
    set call_ChkIncParenthesis=%~dp0"ChkIncParenthesis.bat"
    rem ���l����o�b�`
    set call_ChkNum=%~dp0"ChkNum.bat"
    rem ���t��������o�b�`
    set call_ChkDateFormat=%~dp0"ChkDateFormat.bat"
    rem ������������o�b�`
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"


  rem ���[�U����
  :USER_INPUT
    rem �\���������u""�v�݂̂łȂ��ꍇ
    if not %description%=="" (
      rem �����\��
      echo %description:"=%
    )

    rem �ϐ�������
    set USR=""
    set /P USR="���͂��Ă�������:"

    rem �u""�v���͑΍�
    set returnVal=%USR:"=%
    set returnVal="%returnVal%"
    rem ���茋�ʐ錾
    set judgResult=

    : �˂��ݕԂ�_�ۊ��ʔ���
      rem �ۊ��ʊܗL����o�b�`�g�p
      call %call_ChkIncParenthesis% %returnVal%

      rem �ۊ��ʂ��܂ޏꍇ
      if %return_ChkIncParenthesis%==1 (
        set invalidErrStr=�u^(�v���A�u^)�v���܂܂�Ă��܂�
        goto :IS_Invalid_LOOP
      )

    : �˂��ݕԂ�_�����͔���
      if %returnVal%=="" (
        rem �������͕\�������ݒ�
        set invalidErrStr=�����͂ł�
        rem �������͔��f��
        goto :IS_Invalid_LOOP
      )

    rem ���茋�ʂ𐬌��ɐݒ�
    set judgResult=1


  : ���f����
    : �t�@�C���p�X���[�h
      if %judgeMode%==PATH (
        rem �p�X�����݂��Ȃ��ꍇ
        if not exist %returnVal% (
          set invalidErrStr=�p�X�����݂��܂���
          goto :IS_Invalid_LOOP
        )
      )

    : ���l���[�h
      if %judgeMode%==NUM (
        rem ���l����o�b�`�g�p
        call %call_ChkNum% %returnVal:"=%

        rem ���l�łȂ��ꍇ
        if !return_ChkNum!==0 (
          set invalidErrStr=���l�ł͂���܂���
          goto :IS_Invalid_LOOP
        )
      )

    : ���t���[�h
      if %judgeMode%==DATE (
        rem ���t��������o�b�`�g�p
        call %call_ChkDateFormat% %returnVal:"=%

        rem ���t�łȂ��ꍇ
        if !return_ChkDateFormat1!==0 (
          set invalidErrStr=���t�ł͂���܂���
          goto :IS_Invalid_LOOP
        )
        rem ���茋�ʂ𐬌��ɏ�����ݒ�
        set judgResult=!return_ChkDateFormat2!
      )

    : �������[�h
      if %judgeMode%==TIME (
        rem ������������o�b�`�g�p
        call %call_ChkTimeFormat% %returnVal:"=%

        rem �����łȂ��ꍇ
        if !return_ChkTimeFormat1!==0 (
          set invalidErrStr=�����ł͂���܂���
          goto :IS_Invalid_LOOP
        )
        rem ���茋�ʂ𐬌��ɏ�����ݒ�
        set judgResult=!return_ChkTimeFormat2!
      )


  rem �o�b�`�I��
  :RETURN
    rem �����Ȃ�


rem �߂�l(2�ȏ�̏ꍇ�A�߂�l2�ȍ~�́u&&�v���O�X�y�[�X����)
ENDLOCAL && set return_UserInput1=%returnVal%&& set return_UserInput2=%judgResult%
exit /b


rem �������͔��f
:IS_Invalid_LOOP
  rem �������̓��[�v���L���̏ꍇ
  if "%isInvalidLoop%"=="TRUE" (
    rem �������͕\�������\��
    echo;
    echo !invalidErrStr!�A�ēx���͂��Ă�������
    echo;
    rem ���̓��[�v
    goto :USER_INPUT
  )

  rem ���茋�ʂ����s�ɐݒ�
  set judgResult=0

  rem �o�b�`�I����
  goto :RETURN