@echo off
title %~nx0
echo TortoiseSVN�X�V


: �錾
  rem �Ώ�SVN�t�H���_
  set targetDir="E:\MyFiles-P00486\My-SVN"


: ���s
  rem �Ώ�SNV�����A�S�t�H���_�X�V
  cd %targetDir%
  for /d %%i in (*) do call :UPDATE_SVN %%i

  exit


rem SVN�X�V�T�u���[�`��
:UPDATE_SVN
  echo %1 ���X�V���Ă��܂�...
  TortoiseProc.exe /command:update /path:%1 /notempfile /closeonend:1
  exit /b