@echo off
title %~nx0
echo �������J�E���g�o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_CountStrLength="..\OwnLib\CountStrLength.bat"

: �ϐ�
  set str="abcdefg"

: ����
  rem �f�B���N�g���t�@�C�����o�b�`�g�p
  call %call_CountStrLength% %str%
  echo %return_CountStrLength%
pause