@echo off
title %~nx0
echo �����b�~����̃o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����b�~����̃o�b�`
  set call_DismantleTime="..\OwnLib\DismantleTime.bat"
  rem ������������o�b�`
  set call_ChkTimeFormat="..\OwnLib\ChkTimeFormat.bat"


: ����
  : �umm:ss�v�p�^�[��
    set target=12:51

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

rem ���umm:ss.f�v�̒�`���uChkTimeFormat.bat�v�ɂȂ����߃R�����g
  REM : �umm:ss.f�v�p�^�[��
  REM   set target=12:51.1

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------

  REM : �umm:ss.ff�v�p�^�[��
  REM   set target=12:51.12

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------

  REM : �umm:ss.fff�v�p�^�[��
  REM   set target=12:51.123

  REM   call %call_ChkTimeFormat% %target%
  REM   call %call_DismantleTime% %target% %return_ChkTimeFormat2%
  REM   echo %target%
  REM   echo %return_ChkTimeFormat2%
  REM   echo %return_DismantleTime1%
  REM   echo %return_DismantleTime2%
  REM   echo ---------------


  : �uh:mm:ss�v�p�^�[��
    set target=6:10:50

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uh:mm:ss.f�v�p�^�[��
    set target=6:10:50.4

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uh:mm:ss.ff�v�p�^�[��
    set target=6:10:50.45

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uh:mm:ss.fff�v�p�^�[��
    set target=6:10:50.456

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------


  : �uhh:mm:ss�v�p�^�[��
    set target=12:34:56

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uhh:mm:ss.f�v�p�^�[��
    set target=12:34:56.7

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uhh:mm:ss.ff�v�p�^�[��
    set target=12:34:56.78

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

  : �uhh:mm:ss.fff�v�p�^�[��
    set target=12:34:56.789

    call %call_ChkTimeFormat% %target%
    call %call_DismantleTime% %target% %return_ChkTimeFormat2%
    echo %target%
    echo %return_ChkTimeFormat2%
    echo %return_DismantleTime1%
    echo %return_DismantleTime2%
    echo ---------------

pause