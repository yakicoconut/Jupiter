@echo off
title %~nx0
echo ���t��������o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���t��������o�b�`
  set call_ChkDateFormat="..\OwnLib\ChkDateFormat.bat"


: ����
  : �����p�^�[��
    set target=123

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : ���������p�^�[��
    set target=1a2b3c

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : �����p�^�[��
    set target=def

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : �uyyyy/mm/dd�v�p�^�[��
    set target=0000/11/22

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : �uyy/mm/dd�v�p�^�[��
    set target=33/44/55

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


  : �umm/dd�v�p�^�[��
    set target=66/77

    call %call_ChkDateFormat% %target%
    echo %target%
    echo %return_ChkDateFormat1%
    echo %return_ChkDateFormat2%
    echo ---------------


pause