@echo off
title %~nx0
rem �[�����߃o�b�`
rem ����01:�Ώےl
rem ����02:����(�u-�v�n�܂�̏ꍇ�A���ʃ��[�h)
rem �ߒl  :�[��������l


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : ����
    rem �Ώےl
    set value=%1
    rem ����
    set pad=%2

    rem �[�����߃��[�h�t���O������
    set padFlg=0
    rem ���ʃ��[�h�̏ꍇ
    if %pad:~0,1%==- (
      rem �u-�v����
      set pad=%pad:~1%
      rem �[�����߃��[�h�t���O�I�t
      set padFlg=1
    )

  : �w�茅���̕ϐ����쐬
    set pad_num=
    for /L %%i in (1, 1, %pad%) do (
      set pad_num=0!pad_num!
    )

  : �l�쐬
    rem �[�����߃��[�h�̏ꍇ
    if %padFlg%==0 (
      rem �쐬������������0�̌��ɑΏےl������
      set num=!pad_num!%value%
      rem �w�茅��������납��擾
      set num=!num:~-%pad%!
    ) else (
      rem ���ʃ��[�h
      set num=%value%!pad_num!
      set num=!num:~0,%pad%!
    )


rem �߂�l
ENDLOCAL && set return_ZeroPadding=%num%
exit /b