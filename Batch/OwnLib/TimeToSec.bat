@echo off
title %~nx0
rem ���ԕb�ϊ��o�b�`
rem ����01:�Ώێ���
rem �ߒl01:�b�����v
rem �ߒl02:�~���b


rem �ϐ����[�J����
SETLOCAL
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem 8�i�����l�ϊ��o�b�`
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem ������������o�b�`
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"
    rem �����b�~����̃o�b�`
    set call_DismantleTime=%~dp0"DismantleTime.bat"

  : ����
    rem ���͎���
    set inpTime=%~1

    rem ������������o�b�`�g�p
    call %call_ChkTimeFormat% %inpTime%
    set fmt=%return_ChkTimeFormat2%

    rem �����b�~����̃o�b�`�g�p
    call %call_DismantleTime% %inpTime% %fmt%
    set tgtTime=%return_DismantleTime1%
    set tgtMilli=%return_DismantleTime2%
    rem �~���b���Ȃ��ꍇ��0��ݒ�
    if "%tgtMilli%"=="" set /a tgtMilli=0

  : 8�i�����l�ϊ�
    rem 8�i�����l�ϊ��o�b�`�g�p
    call %call_CngOctalNum% %tgtTime:~0,2%
    set /a hour=%return_CngOctalNum%
    call %call_CngOctalNum% %tgtTime:~3,2%
    set /a minute=%return_CngOctalNum%
    call %call_CngOctalNum% %tgtTime:~6,2%
    set /a second=%return_CngOctalNum%

  : �v�Z
    rem �������b
    set /a secHour=%hour% * 3600
    set /a secMinute=%minute% * 60

    rem �b�����v
    set /a retSec=%secHour% + %secMinute% + %second%

rem �߂�l
ENDLOCAL && set return_TimeToSec1=%retSec%&& set return_TimeToSec2=%tgtMilli%
exit /b