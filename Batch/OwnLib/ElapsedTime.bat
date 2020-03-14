@echo off
title %~nx0
rem �o�ߎ��Ԍv�Z�o�b�`
rem ����01:�J�n����
rem ����02:�I������
rem �ߒl:�o�ߎ���(������)


rem �ϐ����[�J����
SETLOCAL ENABLEDELAYEDEXPANSION
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem �[�����߃o�b�`
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"
    rem 8�i�����l�ϊ��o�b�`
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem ������������o�b�`
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"
    rem �����b�~����̃o�b�`
    set call_DismantleTime=%~dp0"DismantleTime.bat"

  : ����
    rem �J�n����
    set startTime=%1
    rem �I������
    set   endTime=%2

  : �����b�~�����
    : �J�n
      rem ������������o�b�`�g�p
      call %call_ChkTimeFormat% %startTime%
      set startFormat=%return_ChkTimeFormat2%

      rem �����b�~����̃o�b�`�g�p
      call %call_DismantleTime% %startTime% %startFormat%
      set startTime=%return_DismantleTime1%
      set startComma=%return_DismantleTime2%
      rem �~���b���Ȃ��ꍇ��0��ݒ�
      if "%startComma%"=="" set /a startComma=0
      rem �~���b�̓[������
      call %call_ZeroPadding% %startComma% -3
      set startComma=%return_ZeroPadding%

    : �I��
      call %call_ChkTimeFormat% %endTime%
      set endFormat=%return_ChkTimeFormat2%

      call %call_DismantleTime% %endTime% %endFormat%
      set endTime=%return_DismantleTime1%
      set endComma=%return_DismantleTime2%
      if "%endComma%"=="" set /a endComma=0
      call %call_ZeroPadding% %endComma% -3
      set endComma=%return_ZeroPadding%

  : 8�i�����l�ϊ�
    : �J�n
      rem 8�i�����l�ϊ��o�b�`�g�p
      call %call_CngOctalNum% %startTime:~0,2%
      set /a startHour=%return_CngOctalNum%
      call %call_CngOctalNum% %startTime:~3,2%
      set /a startMinute=%return_CngOctalNum%
      call %call_CngOctalNum% %startTime:~6,2%
      set /a startSecond=%return_CngOctalNum%
      rem �~���b�̓[�����߂��Ȃ����ߑΏۊO

    : �I��
      call %call_CngOctalNum% %endTime:~0,2%
      set /a endHour=%return_CngOctalNum%
      call %call_CngOctalNum% %endTime:~3,2%
      set /a endMinute=%return_CngOctalNum%
      call %call_CngOctalNum% %endTime:~6,2%
      set /a endSecond=%return_CngOctalNum%

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
      rem �R���}�b��1000�܂Ő�����
      set /a elapsedComma=1000 - %startComma% + %endComma%
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

  : ����
    rem �~���b��0�łȂ��ꍇ�A�R���}�����ĕϐ���
    if not %elapsedComma% == 0 set retElapsedComma=.%elapsedComma%

    rem �ԋp�p�ϐ��쐬
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%%retElapsedComma%

rem �߂�l
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b