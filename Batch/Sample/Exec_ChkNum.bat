@echo off
title %~nx0
echo ���l����o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���l����o�b�`
  set call_ChkNum="..\OwnLib\ChkNum.bat"


: ����
  : �P���p�^�[��
    rem �Ώےl�ݒ�
    set target=9

    rem ���l����o�b�`�g�p
    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : �����p�^�[��
    set target=123

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : �����p�^�[��
    set target=1.5

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : ���������p�^�[��
    set target=1a2b3c

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : �����p�^�[��
    set target=def

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


  : ���ԃp�^�[��
    set target=10:50

    call %call_ChkNum% %target%
    echo %target%
    echo %return_ChkNum%
    echo ---------------


pause