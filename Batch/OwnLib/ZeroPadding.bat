@echo off
title %~nx0
rem �[�����߃o�b�`
rem ����01:�Ώےl
rem ����02:����
rem �ߒl:�[�����ߌ�̒l


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
      set pad_num=0!pad_num!
    )

  : �[�����ߒl�쐬
    rem �쐬����������0�ɑΏےl������
    set num=!pad_num!%value%
    rem �w�茅��������납��擾
    set num=!num:~-%pad%!


rem �߂�l
ENDLOCAL && set return_ZeroPadding=%num%
exit /b