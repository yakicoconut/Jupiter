@echo off
title %~nx0
rem ���p�X�y�[�X��떄�߃o�b�`
rem ����01:�Ώےl
rem ����02:����
rem �ߒl:���p�X�y�[�X���ߌ�̒l


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : ����
    rem �Ώےl
    set value=%1
    rem ����
    set pad=%2


  : �w�茅���̕ϐ����쐬
    set pad_num=
    for /L %%i in (1, 1, %pad%) do (
      set pad_num= !pad_num!
    )

  : ���p�X�y�[�X���ߒl�쐬
    rem �Ώےl�ɍ쐬���������̔��p�X�y�[�X������
    set str=%value%!pad_num!
    rem �w�茅������O����擾
    set str=!str:~0,%pad%!


rem �߂�l
ENDLOCAL && set return_SpacePadding=%str%
exit /b