@echo off
title %~nx0
echo �[�������폜�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���l����o�b�`
  set call_DelZeroEnd="..\OwnLib\DelZeroEnd.bat"


: ����
  : ��
    rem �Ώےl�ݒ�
    set target=10

    rem ���l����o�b�`�g�p
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : �O��
    set target=200
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : �[���Ȃ�
    set target=345
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : �[���̂�
    set target=0
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

  : �[���[��
    set target=00
    call %call_DelZeroEnd% %target%
    echo %target%
    echo %return_DelZeroEnd%
    echo ---------------

pause