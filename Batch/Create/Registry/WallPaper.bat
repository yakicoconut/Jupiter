@echo off
title %~nx0
echo �ǎ��ύX(�v�ċN��)


: �錾
  rem �ǎ��t�@�C���ʒu
  set wallPaper="E:\MyFiles-P00486\My-Doc\DOC_�ʐ^\�ǎ�\269_w5.jpg"

  rem ���W�X�g���p�X
  set targetKey="HKEY_CURRENT_USER\Control Panel\Desktop"


: ���s
  rem ���W�X�g�����̕ǎ��t�@�C���̍X�V
  reg add %targetKey% /v "Wallpaper" /t REG_SZ /d %wallPaper% /f


pause