@echo off
title %~nx0
rem �o�ߎ��Ԍv�Z�o�b�`
rem ����01:�J�n����(�uhh:mm:ss.ff�v�������́uhh:mm:ss�v)
rem ����02:�I������(�uhh:mm:ss.ff�v�������́uhh:mm:ss�v)
rem �ߒl:�o�ߎ���(������)


rem �ϐ����[�J����
SETLOCAL ENABLEDELAYEDEXPANSION
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem �[�����߃o�b�`
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"
    rem 8�i�����l�ϊ��o�b�`
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"

  : ����
    rem �J�n����
    set startTime=%1
    rem �I������
    set   endTime=%2

  : �R���}�b�L������
    set commaFlg=0
    rem �uhh:mm:ss.ff�v
    echo %startTime%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    echo %endTime%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 set commaFlg=1

  : ���ڕ���
    rem �J�n����
    rem 8�i�����l�ϊ��o�b�`�g�p
    call %call_CngOctalNum% %startTime:~0,2%
    set /a startHour=%return_CngOctalNum%
    call %call_CngOctalNum% %startTime:~3,2%
    set /a startMinute=%return_CngOctalNum%
    call %call_CngOctalNum% %startTime:~6,2%
    set /a startSecond=%return_CngOctalNum%

    rem �I������
    call %call_CngOctalNum% %endTime:~0,2%
    set /a endHour=%return_CngOctalNum%
    call %call_CngOctalNum% %endTime:~3,2%
    set /a endMinute=%return_CngOctalNum%
    call %call_CngOctalNum% %endTime:~6,2%
    set /a endSecond=%return_CngOctalNum%

    rem �R���}�b������ꍇ
    if %commaFlg%==1 (
      call %call_CngOctalNum% %startTime:~9,2%
      set /a startComma=!return_CngOctalNum!
      call %call_CngOctalNum% %endTime:~9,2%
      set /a endComma=!return_CngOctalNum!
    ) else (
      rem �Ȃ��ꍇ�A�u00�v��ݒ�
      set /a startComma=00
      set /a   endComma=00
    )

  : �������Ԍv�Z
    rem �P���v�Z
    set /a   elapsedHour=%endHour%   - %startHour%
    set /a elapsedMinute=%endMinute% - %startMinute%
    set /a elapsedSecond=%endSecond% - %startSecond%
    set /a  elapsedComma=%endComma%  - %startComma%

    : ��Βl(�J�n���� > �I������)����
      rem ��
      if %startMinute% gtr %endMinute% (
        set /a elapsedMinute=60 - %startMinute% + %endMinute%
        rem �J�艺����
        set /a elapsedHour=%elapsedHour%-1
        rem �u-1�v�̏ꍇ�A�u00�v�ɒ���
        if !elapsedHour! == -1 set /a elapsedHour=00
      )

      rem �b
      if %startSecond% gtr %endSecond% (
        set /a elapsedSecond=60 - %startSecond% + %endSecond%
        set /a elapsedMinute=!elapsedMinute!-1
        rem �u-1�v�̏ꍇ�A�u59�v�ɒ���
        if !elapsedMinute! == -1 set /a elapsedMinute=59
      )

    rem �R���}�b
    if %startComma% gtr %endComma% (
      rem �R���}�b��100�܂Ő�����
      set /a elapsedComma=100 - %startComma% + %endComma%
      set /a elapsedSecond=!elapsedSecond!-1
      if !elapsedSecond! == -1 set /a elapsedSecond=59
    )

  : ������ϊ�
    rem �[�����߃o�b�`�g�p
    rem ����
    call %call_ZeroPadding% %elapsedHour% 2
    set elapsedHour=%return_ZeroPadding%
    rem ��
    call %call_ZeroPadding% %elapsedMinute% 2
    set elapsedMinute=%return_ZeroPadding%
    rem �b
    call %call_ZeroPadding% %elapsedSecond% 2
    set elapsedSecond=%return_ZeroPadding%
    rem �R���}�b
    call %call_ZeroPadding% %elapsedComma% 2
    set elapsedComma=%return_ZeroPadding%

  : ����
    rem �v�Z���ʂ����ԕ\�L�ɂ���
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%
    rem �R���}�b������ꍇ
    if %commaFlg%==1 (
      set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%.%elapsedComma%
    )


rem �߂�l
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b