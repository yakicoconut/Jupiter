@echo off
title %~nx0
echo �[�����߃o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �[�����߃o�b�`
  set call_ZeroPadding="..\OwnLib\ZeroPadding.bat"


: �[�����߃��[�h_4���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 123 4
  echo %return_ZeroPadding%

: �[�����߃��[�h_10���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 123 10
  echo %return_ZeroPadding%


: ���ʃ��[�h_5���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 4 -5
  echo %return_ZeroPadding%

: ���ʃ��[�h_10���p�^�[��
  rem �[�����߃o�b�`�g�p
  call %call_ZeroPadding% 56789 -10
  echo %return_ZeroPadding%


pause