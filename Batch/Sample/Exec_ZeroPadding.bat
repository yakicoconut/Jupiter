@echo off
title %~nx0
echo �[�����߃o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �[�����߃o�b�`
  set call_ZeroPadding="..\OwnLib\ZeroPadding.bat"


: 4���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 123 4
  echo %return_ZeroPadding%


: 10���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 123 10
  echo %return_ZeroPadding%


pause