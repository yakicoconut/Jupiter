@echo off
title %~nx0
echo ffmpeg�ŕ�����}��
: ffmpeg�œ����Ƀe�L�X�g��`�悷�� - Qiita
: 	https://qiita.com/niusounds/items/797fe0743a9d59681446


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

  : �}���e�L�X�g
    echo;
    echo �}���e�L�X�g����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set txt=%return_UserInput1%

  : �J�n����
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo �J�n���ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem ������̃T�u���[�`���g�p
    call :DISMANTLE_TIME %start% %targetTimeFormat%
    set start=%ret_DISMANTLE_TIME01%
    set startMilli=%ret_DISMANTLE_TIME02%

  : ��������
    echo;
    echo �������ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set dist=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem ������̃T�u���[�`���g�p
    call :DISMANTLE_TIME %dist% %targetTimeFormat%
    set dist=%ret_DISMANTLE_TIME01%
    set distMilli=%ret_DISMANTLE_TIME02%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: �b���ϊ�
  : �J�n����
    rem �o�ߎ��Ԍv�Z�o�b�`�g�p
    call %call_ElapsedTime% 00:00:00 %start:"=%
    set startElapsed=%return_ElapsedTime%

    rem �b���ϊ��T�u���[�`���g�p
    call :CONV_SEC %startElapsed%
    set starSec=%ret_CONV_SEC%

  : ��������
    rem �o�ߎ��Ԍv�Z�o�b�`�g�p
    call %call_ElapsedTime% 00:00:00 %dist:"=%
    set distElapsed=%return_ElapsedTime%

    rem �b���ϊ��T�u���[�`���g�p
    call :CONV_SEC %distElapsed%
    set distSec=%ret_CONV_SEC%


: ���s
  rem tbn�ύX
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -filter_complex "drawtext=fontfile=/path/to/fontfile:text=%txt%:enable='between(t,%starSec%%startMilli%,%distSec%%distMilli%)" %outPath%
  pause


exit


rem ������̃T�u���[�`��
:DISMANTLE_TIME
SETLOCAL
  : ����
    rem ���͎���
    set inpTime=%1
    rem �����t�H�[�}�b�g
    set format=%2

  : �~���b�����݂���ꍇ
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-3,2%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-4,3%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-5,4%
    )

  : �擪�um�v�A�uh�v�A�uhh�v���f
    if %format:~0,2%==mm (
      set tms="00:%inpTime:~1,5%"
    )
    if %format:~0,2%==h: (
      set tms="0%inpTime:~1,7%"
    )
    if %format:~0,3%==hh: (
      rem �uhh�v�̏ꍇ���~���b�𔲂�
      set tms="%inpTime:~1,8%"
    )

rem �Ԃ�l1:�����b
rem �Ԃ�l2:�~���b
ENDLOCAL && set ret_DISMANTLE_TIME01=%tms%&& set ret_DISMANTLE_TIME02=%milli%
exit /b


rem �b���ϊ��T�u���[�`��
:CONV_SEC
SETLOCAL
  : ����
    rem ����
    set formalTime=%1

  : ���ڕ���
    rem ������Ƃ��ĕ���
    set   strHour=%formalTime:~0,2%
    set strMinute=%formalTime:~3,2%
    set strSecond=%formalTime:~6,2%

    rem �񌅖ڂ��u0�v�̏ꍇ
    if %strHour:~0,1%==0 (
      rem ���l�^�Ɋi�[����ƃG���[�ƂȂ邽�߁A�ꌅ�ڂ̂ݎ擾
      set strHour=%strHour:~1,1%
    )
    if %strMinute:~0,1%==0 (
      set strMinute=%strMinute:~1,1%
    )
    if %strSecond:~0,1%==0 (
      set strSecond=%strSecond:~1,1%
    )

  : ���l�ϊ�
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

  : �b���ϊ�
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a   secTime=%secHour%+%secMinute%+%second%

rem �߂�l:�b��
ENDLOCAL && set ret_CONV_SEC=%secTime%
exit /b