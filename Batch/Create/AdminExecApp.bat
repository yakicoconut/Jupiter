@echo off
title %~nx0
echo �w��exe���Ǘ��Ҏ��s����


: ���O����
  rem �Ώ�exe�p�X
  set targetApp="C:\Windows\system32\cmd.exe /k"


: �A�v�����s
  rem �p���[�V�F�����g�p���đΏ�exe���Ǘ��Ҏ��s
  @powershell -NoProfile -ExecutionPolicy unrestricted -Command "Start-Process %targetApp:"=% -Verb runas"