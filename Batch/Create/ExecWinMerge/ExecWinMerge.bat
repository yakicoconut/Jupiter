@echo off
title %~nx0
echo WinMerge���s�o�b�`
: �e�L�X�g�t�@�C�����J���A
: �ҏW��ɓ�̃t�@�C����WinMerge�ɂ�����


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: ���O����
  rem ��r1
  set comp1=.\MyResorce\Comp1.txt
  rem ��r2
  set comp2=.\MyResorce\Comp2.txt


: ��r�p�e�L�X�g�t�@�C���J��
  rem �\�����I��2�����ɊJ��
  start %comp2%
  start %comp1%

  echo ��r�t�@�C���ۑ���AWinMerge�����s���܂�
  pause


: WinMerge���s
  start .\WinMerge2140\WinMergeU.exe %comp1% %comp2%
  exit