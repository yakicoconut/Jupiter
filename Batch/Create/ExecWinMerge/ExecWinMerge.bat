@echo off
title %~nx0
echo WinMerge���s�o�b�`
: �e�L�X�g�t�@�C�����J���A
: �ҏW��ɓ�̃t�@�C����WinMerge�ɂ�����


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: ��r�p�e�L�X�g�t�@�C���J��
  rem �\�����I��2�����ɊJ��
  rem ��r2
  start .\MyResorce\Comp2.txt
  rem ��r1
  start .\MyResorce\Comp1.txt

  echo ��r�t�@�C���ۑ���AWinMerge�����s���܂�
  pause


: WinMerge���s
  start .\WinMerge2140\WinMergeU.exe .\MyResorce\Comp1.txt .\MyResorce\Comp2.txt
  exit