@echo off
echo �ΏۃA�v�����ċN������


: �ϐ�
  rem �A�v���p�X
  set appPath=D:\Calacala_StartFolder\CAL_Applications\�肩�ȁ[\�肩�ȁ[.exe
  rem �v���Z�X��
  set processName=�肩�ȁ[.exe


: ���s
  rem �^�X�N�L��
  taskkill /im %processName%

  echo �A�v���N��
  start %appPath%