@echo off
title %~nx0
rem ������������o�b�`
rem ����01:�Ώےl
rem �ߒl1 :���茋��(0:�����łȂ��A1:����)
rem �ߒl2 :�Y���t�H�[�}�b�g


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1


  : ���s
    rem ���ӓ_
    : �E�uecho %value%�v�ƃp�C�v�̊Ԃ̓X�y�[�X�����Ȃ�
    :   �u�����Ώە���+�X�y�[�X�v�ƂȂ邽��
    : �E�o�b�`�ł́u{n, m}�v�͎g�p�ł��Ȃ�?

    rem �����t���O
    set isTime=0
    rem �ԋp�p�t�H�[�}�b�g�ϐ�
    set format=

    rem �umm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=mm:ss
      goto :FLAGON
    )

    rem �uh:mm:ss�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss
      goto :FLAGON
    )

    rem �uh:mm:ss.f�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.f
      goto :FLAGON
    )

    rem �uh:mm:ss.ff�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.ff
      goto :FLAGON
    )

    rem �uh:mm:ss.fff�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.fff
      goto :FLAGON
    )

    rem �uhh:mm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss
      goto :FLAGON
    )

    rem �uhh:mm:ss.f�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.f
      goto :FLAGON
    )

    rem �uhh:mm:ss.ff�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.ff
      goto :FLAGON
    )

    rem �uhh:mm:ss.fff�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.fff
      goto :FLAGON
    )


    rem ���ׂăG���[�̏ꍇ�A���^�[��
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem �����t���O�𗧂Ă�
    set isTime=1


  rem �o�b�`�I��
  :RETURN
    rem �����Ȃ�


rem �߂�l
ENDLOCAL && set return_ChkTimeFormat1=%isTime%&& set return_ChkTimeFormat2=%format%
exit /b