@echo off
title %~nx0
rem 8�i�����l�ϊ��o�b�`
rem   DOS�R�}���h�ł�0���߂̐��l��8�i���Ƃ��Ĉ����邽�߁A
rem   0���߂���Ă���8��9�̓I�[�o�[�t���[�ƂȂ�̂�
rem   �擪�́u0�v����������
rem ����01:�Ώےl
rem �ߒl:�ϊ��㐔�l������


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1

  : ���s
    rem �ԋp�p���l
    set retNum="%value%"

    :LOOP
      : �˂��ݕԂ�_�����Ƃ�
        rem �Ώےl����̏ꍇ
        if %retNum%=="" (
          rem ���ׂ�0�̃p�^�[���̂��߁u0�v��ݒ�
          set retNum="0"
          goto :END_BAT
        )
        rem �ꕶ���ڂ�0�łȂ��ꍇ
        if not %retNum:~1,1%==0 ( goto :END_BAT )

      rem �񕶎��ڈȍ~���[�v�ϐ��i�[
      set retNum="%retNum:~2,-1%"
      goto :LOOP

  rem ������
  :END_BAT
    rem W�N�H�[�g�폜
    set retNum=%retNum:"=%

rem �߂�l
ENDLOCAL && set return_CngOctalNum=%retNum%
exit /b