@echo off
title %~nx0
echo �����v�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����v�Z�o�b�`
  set call_CalcDecimal="..\OwnLib\CalcDecimal.bat"


: ����
  echo;
  echo 1.0�p�^�[��
    rem �Ώےl�ݒ�
    set left=1.0
    set right=1.0

    rem ���l����o�b�`�g�p
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    rem ���ʂɏ���������ꍇ�����ݒ肷��
    rem �������ʕϐ�������
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    2 �����Ҍ���

  echo;
  echo ���E�ӕʃp�^�[��
    set left=1.2
    set right=3.4
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    4.6 �����Ҍ���

  echo;
  echo �J��オ��p�^�[��
    set left=5.6
    set right=7.8
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo   %return_CalcDecimal01%%decResult%
    echo   13.4 �����Ҍ���

  echo;
  echo �񌅃p�^�[��
    set left=1.23
    set right=4.56
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    5.79 �����Ҍ���

  echo;
  echo �񌅌J��グ�p�^�[��
    set left=1.88
    set right=1.12
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    3 �����Ҍ���

  echo;
  echo ���Ⴂ�p�^�[��
    set left=1.23
    set right=4.5
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    5.73 �����Ҍ���

  echo;
  echo ����0�p�^�[��
    set left=1.08
    set right=4.09
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    5.17 �����Ҍ���

  echo;
  echo ����0(���ӂ̂�)�J��オ��p�^�[��
    set left=0.02
    set right=9.99
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo   %return_CalcDecimal01%%decResult%
    echo   10.01 �����Ҍ���

  echo;
  echo ����0(�E�ӂ̂�)���Ⴂ�p�^�[��
    set left=1.23
    set right=0.0234
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    1.2534 �����Ҍ���

  echo;
  echo ����0�J��オ��p�^�[��
    set left=0.9998
    set right=0.0002
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    set decResult=
    if not "%return_CalcDecimal02%"=="" set decResult=.%return_CalcDecimal02%
    echo    %return_CalcDecimal01%%decResult%
    echo    1 �����Ҍ���

pause