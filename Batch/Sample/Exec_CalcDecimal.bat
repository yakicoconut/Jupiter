@echo off
title %~nx0
echo �����v�Z�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����v�Z�o�b�`
  set call_CalcDecimal="..\OwnLib\CalcDecimal.bat"


: ����
  REM echo;
  REM echo 1.0�p�^�[��
  REM   rem �Ώےl�ݒ�
  REM   set left=1.0
  REM   set right=1.0

  REM   rem ���l����o�b�`�g�p
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo ���E�ӕʃp�^�[��
  REM   set left=1.2
  REM   set right=3.4
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo �J��オ��p�^�[��
  REM   set left=5.6
  REM   set right=7.8
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo   %return_CalcDecimal%

  REM echo;
  REM echo �񌅃p�^�[��
  REM   set left=1.23
  REM   set right=4.56
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo �񌅌J��グ�p�^�[��
  REM   set left=1.88
  REM   set right=1.12
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  REM echo;
  REM echo ���Ⴂ�p�^�[��
  REM   set left=1.23
  REM   set right=4.5
  REM   call %call_CalcDecimal% %left% %right%
  REM   echo    %left%
  REM   echo +  %right%
  REM   echo --------
  REM   echo    %return_CalcDecimal%

  echo;
  echo ����0�p�^�[��
    set left=1.08
    set right=4.09
    call %call_CalcDecimal% %left% %right%
    echo    %left%
    echo +  %right%
    echo --------
    echo    %return_CalcDecimal%
    echo    5.17 �����Ҍ���

pause