@echo off
title %~nx0
echo �w��VPN�ڑ�
rem �w�肵��VPN�ɐڑ�����


: ���O
  rem �Ώ�PPTP��
  set vpnName="PPTP-APP"

  echo %vpnName% �ɐڑ����܂�


: ���s
  rem �ڑ�
  start RasDial %vpnName% /connect

  REM rem �ؗ�
  REM start RasDial %vpnName% /disconnect