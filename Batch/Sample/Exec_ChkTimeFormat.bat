@echo off
title %~nx0
echo ��������o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ��������o�b�`
  set call_ChkTimeFormat="..\OwnLib\ChkTimeFormat.bat"


: ����
  : �����p�^�[��
    set target=123

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : ���������p�^�[��
    set target=1a2b3c

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �����p�^�[��
    set target=def

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �um;s�v�p�^�[��
    set target=1:0

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �umm;s�v�p�^�[��
    set target=10:5

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �um:ss�v�p�^�[��
    set target=0:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �umm:ss�v�p�^�[��
    set target=12:51

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uh:m;s�v�p�^�[��
    set target=4:5:4

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uh:mm;s�v�p�^�[��
    set target=3:10:2

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uh:m:ss�v�p�^�[��
    set target=5:4:20

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uh:mm:ss�v�p�^�[��
    set target=6:10:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uhh:m;s�v�p�^�[��
    set target=14:1:5

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uhh:mm;s�v�p�^�[��
    set target=21:10:0

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uhh:m:ss�v�p�^�[��
    set target=11:1:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


  : �uhh:mm:ss�v�p�^�[��
    set target=09:10:50

    call %call_ChkTimeFormat% %target%
    echo %target%
    echo %return_ChkTimeFormat%
    echo ---------------


pause