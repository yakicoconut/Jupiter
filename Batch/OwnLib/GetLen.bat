@echo off
title %~nx0
rem �����擾�o�b�`
rem ����01:�Ώےl(�u"�v�͖��������)
rem �ߒl  :����


rem �x�����ϐ��I��
SETLOCAL
  : ����
    rem �Ώےl
    set value=%~1

  : ���O����
    rem �����ϐ�������
    set /a len=0

  rem �����J�E���g�A�b�v
  :COUNT_UP
    rem �˂��ݕԂ�_�Ώےl����ɂȂ�����
    if "%value%"=="" (
      rem ���[�v�����I��
      goto :LOOP_END
    )
    rem �Ώےl����ꕶ���폜
    set value=%value:~1%
    set /a len=%len%+1
    goto :COUNT_UP

  rem ���㏈��
  :LOOP_END
    rem �����Ȃ�

rem �߂�l
ENDLOCAL && set return_GetLen=%len%
exit /b