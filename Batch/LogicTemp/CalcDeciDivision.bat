@echo off
title %~nx0
echo �����Z�o���Z
   : �E�o�b�`�ł͕��������������Ȃ�����
   :   ����Z�̓����������ƂȂ�ꍇ�A�\�ߌ������炵�Čv�Z����
   : �E�A���A�Ԃ�l�ƂȂ�ϐ��ɏ����������Ȃ����ߕ�����Ƃ��ĕԂ�


rem �����v�Z�T�u���[�`���g�p
call :CALC_FLOAT 8 4 100

rem ���ʕ\��
echo %return_CALC_FLOAT%
pause


rem �����v�Z�T�u���[�`��
  : ����1:����
  : ����2:�E��
  : ����3:���ʐ�(10*n�̌��ʂŎw��)
:CALC_FLOAT
  SETLOCAL
    : �����i�[
      set /a  left=%~1
      set /a right=%~2
      set /a digit=%~3
      rem ���ӂ͌������Y����
      set /a left=%left%*%digit%

    : ���Z
    set /a answer=%left%/%right%
    rem ���ʂ������ɕϊ�(������)
    set answer=0.%answer%

  rem �߂�l
  ENDLOCAL && set return_CALC_FLOAT=%answer%
  exit /b