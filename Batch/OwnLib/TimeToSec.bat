@echo off
title %~nx0
rem ���ԕb�ϊ��o�b�`
rem ����01:�Ώێ���
rem �ߒl01:�b�����v


rem �ϐ����[�J����
SETLOCAL
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem 8�i�����l�ϊ��o�b�`
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"

  : ����
    rem ���͎���
    set inpTime=%~1

  : 8�i�����l�ϊ�
    rem 8�i�����l�ϊ��o�b�`�g�p
    call %call_CngOctalNum% %inpTime:~0,2%
    set /a hour=%return_CngOctalNum%
    call %call_CngOctalNum% %inpTime:~3,2%
    set /a minute=%return_CngOctalNum%
    call %call_CngOctalNum% %inpTime:~6,2%
    set /a second=%return_CngOctalNum%

  : �v�Z
    rem �������b
    set /a secHour=%hour% * 3600
    set /a secMinute=%minute% * 60

    rem �b�����v
    set /a retSec=%secHour% + %secMinute% + %second%


rem �߂�l
ENDLOCAL && set return_TimeToSec=%retSec%
exit /b