@echo off
title %~nx0
rem ���ԕb�ϊ��o�b�`
rem ����01:�b��
rem �ߒl01:�ԊҌ㎞��


rem �ϐ����[�J����
SETLOCAL
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem 8�i�����l�ϊ��o�b�`
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem �[�����߃o�b�`
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"

  : ����
    rem ���͎���
    set inpSec=%~1

  : �v�Z
    : �b����
      rem �����Z�o
      set /a minute=%inpSec% / 60
      rem �[���b
      rem (��:121�b
      rem     2�� = 121�b / 60
      rem     1�b = 121�b - (60 * 2)
      set /a second=%inpSec% - %minute% * 60

    : ������
      rem ���ԎZ�o
      set /a hour=%minute% / 60
      set /a minute=%minute% - %hour% * 60

    : �ԋp�l�쐬
      rem �[�����߃o�b�`�g�p
      call %call_ZeroPadding% %hour% 2
      set hour=%return_ZeroPadding%
      call %call_ZeroPadding% %minute% 2
      set minute=%return_ZeroPadding%
      call %call_ZeroPadding% %second% 2
      set second=%return_ZeroPadding%

      rem �ԋp�l�쐬
      set retTime="%hour%:%minute%:%second%"

rem �߂�l
ENDLOCAL && set return_SecToTime=%retTime%
exit /b