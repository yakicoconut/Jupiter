@echo off
title %~nx0
echo �w��VPN�ڑ�
rem �w�肵��VPN�ɐڑ�����


: �錾
  rem �Ώ�PPTP��
  set vpnName="PPTP-APP"

  : ����
    rem ���[�U��
    set user=%~1
    rem �p�X���[�h
    set pass=%~2

  : �����L��
    if "%user%"=="" (
      echo;
      echo ���[�U������
      set /P user="���͂��Ă�������:"
    )
    if "%pass%"=="" (
      echo;
      echo �p�X���[�h����
      set /P pass="���͂��Ă�������:"
    )


: ���s
  rem �ڑ�
  start RasDial %vpnName% %user% %pass%
  pause