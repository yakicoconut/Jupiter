@echo off
title %~nx0
echo ���p�X�y�[�X��떄�߃o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem ���p�X�y�[�X��떄�߃o�b�`
  set call_SpacePadding="..\OwnLib\SpacePadding.bat"


: 4���p�^�[��
  rem ���p�X�y�[�X��떄�߃o�b�`�g�p
  call %call_SpacePadding% ������ 4
  echo %return_SpacePadding%:123


: 10���p�^�[��
  rem ���p�X�y�[�X��떄�߃o�b�`�g�p
  call %call_SpacePadding% ������ 10
  echo %return_SpacePadding%:123


pause