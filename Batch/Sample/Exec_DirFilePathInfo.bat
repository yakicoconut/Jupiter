@echo off
title %~nx0
echo �f�B���N�g���t�@�C�����o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"

: �ϐ�
  set myPath="C:\Program Files\Java\jre1.8.0_144\Welcome.html"

: ����
  rem �f�B���N�g���t�@�C�����o�b�`�g�p
  call %call_DirFilePathInfo% %myPath% up 2
  echo %return_DirFilePathInfo%
pause