@echo off
title %~nx0
echo �����_��؂�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����_��؂�o�b�`
  set call_SepDecimal="..\OwnLib\SepDecimal.bat"


: ����
  : �ꌅ
    rem �Ώےl�ݒ�
    set target=1.1
    rem �����_��؂�o�b�`�g�p
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : ������
    set target=1.12
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : ��
    set target=12.34
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

  : �����̂�
    set target=56
    call %call_SepDecimal% %target%
    echo %target%
    echo %return_SepDecimal01%
    echo %return_SepDecimal02%
    echo ---------------

pause