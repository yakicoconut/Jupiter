@echo off
title %~nx0
rem �����_��؂�o�b�`
rem ����01:�Ώےl
rem �ߒl01:��������
rem �ߒl02:��������


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1

  : �u.�v�ŋ�؂�
    rem ��in���́u"�v�͕K�{(�u.�v������ƃt�@�C���ƔF������Ă��܂�����)
    for /f "tokens=1,2 delims=." %%i in ("%value%") do (
      set integer=%%i
      set decimal=%%j
    )


rem �߂�l
ENDLOCAL && set return_SepDecimal01=%integer%&& set return_SepDecimal02=%decimal%
exit /b