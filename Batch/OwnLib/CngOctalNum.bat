@echo off
title %~nx0
rem 8�i�����l�ϊ��o�b�`
rem   DOS�R�}���h�ł�0���ߓ񌅂̐��l��8�i���Ƃ��Ĉ�����
rem   ���̂��߁A�u08�v�Ɓu09�v�̓I�[�o�[�t���[�ƂȂ�
rem ����01:�Ώےl(��)
rem �ߒl:�ϊ��㐔�l


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1


  : ���s
    rem �ԋp�p���l
    set returnNumeric=%value%

    rem �u08�v�̏ꍇ
    if %value% == 08 (
      rem �u8�v�ɕϊ�
      set returnNumeric=8
    )

    rem �u09�v�̏ꍇ
    if %value% == 09 (
      rem �u9�v�ɕϊ�
      set returnNumeric=9
    )


rem �߂�l
ENDLOCAL && set return_CngOctalNum=%returnNumeric%
exit /b