@echo off
title %~nx0
rem ��������o�b�`
rem ����01:�Ώےl
rem �ߒl:���茋��(0:���l�łȂ��A1:���l)


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


    rem �umm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON


    rem �uh:mm:ss�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON


    rem �uhh:mm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON


    rem �uhh:mm:ss.ff�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON


    rem ���ׂăG���[�̏ꍇ�A���^�[��
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem �����t���O�𗧂Ă�
    set isTime=1


:RETURN
  rem �߂�l
  ENDLOCAL && set return_ChkTimeFormat=%isTime%
  exit /b