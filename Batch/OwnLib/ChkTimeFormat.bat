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

    REM rem �um;s�v
    REM echo %value%| findstr /r "^[0-9]:[0-9]$" >NUL
    REM rem �G���[�łȂ���΃t���O�𗧂Ă�
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �umm;s�v
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �um:ss�v
    REM echo %value%| findstr /r "^[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem �umm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uh:m;s�v
    REM echo %value%| findstr /r "^[0-9]:[0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uh:mm;s�v
    REM echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uh:m:ss�v
    REM echo %value%| findstr /r "^[0-9]:[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem �uh:mm:ss�v
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uhh:m;s�v
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uhh:mm;s�v
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem �uhh:m:ss�v
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem �uhh:mm:ss�v
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
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