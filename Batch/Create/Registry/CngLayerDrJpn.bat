@echo off
title %~nx0
echo ���{��L�[�{�[�h�ݒ�


: �錾
  rem ���{��ݒ�
  set value="kbd106.dll"

  rem ���W�X�g���p�X
  set targetKey="HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\i8042prt\Parameters"


: ���s
  rem ���W�X�g���X�V
  reg add %targetKey% /v "LayerDriver JPN" /t REG_SZ /d %value% /f


pause