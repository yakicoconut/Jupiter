@echo off
title %~nx0
rem �o�ߎ��Ԍv�Z�o�b�`
rem ����01:�J�n����
rem ����02:�I������
rem �ߒl:�o�ߎ���(������)


rem �ϐ����[�J����
SETLOCAL
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem �[�����߃o�b�`
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"

  : ����
    rem �J�n����
    set startTime=%1
    set /a   startHour=%startTime:~0,2%
    set /a startMinute=%startTime:~3,2%
    set /a startSecond=%startTime:~6,2%
    set /a  startComma=%startTime:~9,2%

    rem �I������
    set endTime=%2
    set /a   endHour=%endTime:~0,2%
    set /a endMinute=%endTime:~3,2%
    set /a endSecond=%endTime:~6,2%
    set /a  endComma=%endTime:~9,2%


  : �������Ԍv�Z
    rem �P���v�Z
    set /a   elapsedHour=%endHour%   - %startHour%
    set /a elapsedMinute=%endMinute% - %startMinute%
    set /a elapsedSecond=%endSecond% - %startSecond%
    set /a  elapsedComma=%endComma%  - %startComma%

    rem �J�n���Ԃ��I�����Ԃ������Ă���ꍇ
    if %startHour%   gtr %endHour%   set /a   elapsedHour=24 - %startHour%   + %endHour%
    if %startMinute% gtr %endMinute% set /a elapsedMinute=60 - %startMinute% + %endMinute%
    if %startSecond% gtr %endSecond% set /a elapsedSecond=60 - %startSecond% + %endSecond%
    if %startComma%  gtr %endComma%  set /a  elapsedComma=60 - %startComma%  + %endComma%

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
    rem �R���}
    call %call_ZeroPadding% %elapsedComma% 2
    set elapsedComma=%return_ZeroPadding%

  : ����
    rem �v�Z���ʂ����ԕ\�L�ɂ���
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%.%elapsedComma%


rem �߂�l
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b