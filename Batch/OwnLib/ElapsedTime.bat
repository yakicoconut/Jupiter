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
    rem ���ԕb�ϊ��o�b�`
    set call_TimeToSec=%~dp0"..\OwnLib\TimeToSec.bat"
    rem �b���ԕϊ��o�b�`
    set call_SecToTime="..\OwnLib\SecToTime.bat"

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
      set startMilli=%return_DismantleTime2%
      rem ���ԕb�ϊ��o�b�`�g�p
      call %call_TimeToSec% %startTime%
      set startSec=%return_TimeToSec%
      rem �~���b���Ȃ��ꍇ��0��ݒ�
      if "%startMilli%"=="" set /a startMilli=0
      rem �~���b�̓[������
      call %call_ZeroPadding% %startMilli% -3
      set startMilli=%return_ZeroPadding%

    : �I��
      call %call_ChkTimeFormat% %endTime%
      set endFormat=%return_ChkTimeFormat2%

      call %call_DismantleTime% %endTime% %endFormat%
      set endTime=%return_DismantleTime1%
      set endMilli=%return_DismantleTime2%
      call %call_TimeToSec% %endTime%
      set endSec=%return_TimeToSec%
      if "%endMilli%"=="" set /a endMilli=0
      call %call_ZeroPadding% %endMilli% -3
      set endMilli=%return_ZeroPadding%

  : 8�i�����l�ϊ�
    : �J�n
      rem 8�i�����l�ϊ��o�b�`�g�p
      call %call_CngOctalNum% %startMilli%
      set /a startMilli=%return_CngOctalNum%
    : �I��
      call %call_CngOctalNum% %endMilli%
      set /a endMilli=%return_CngOctalNum%

  : �������Ԍv�Z
    rem �P���v�Z
    set /a elapsedSec=%endSec% - %startSec%
    set /a elapsedMilli=%endMilli% - %startMilli%

    : ��Βl(�J�n���� > �I������)����
      rem �~���b
      if %elapsedMilli:~0,1%==- (
        rem �~���b��1000�܂Ő����邽��
        rem 1000�~���b�Ƀ}�C�i�X�𑫂�
        set /a elapsedMilli=1000 + %elapsedMilli%
        set /a elapsedSec=%elapsedSec%-1
      )

    rem �~���b��3���p�b�h
    call %call_ZeroPadding% %elapsedMilli% 3
    set elapsedMilli=%return_ZeroPadding%

  : ����
    rem �b���ԕϊ��o�b�`�g�p
    call %call_SecToTime% %elapsedSec%
    set elapsedTime=%return_SecToTime:"=%

    rem �~���b��0�łȂ��ꍇ�A�R���}�����ĕϐ���
    if not %elapsedMilli% == 0 set retElapsedMilli=.%elapsedMilli%

    rem �ԋp�p�ϐ��쐬
    set elapsedTime=%elapsedTime%%retElapsedMilli%

rem �߂�l
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b