@echo off
title %~nx0
echo ffmpeg�ŉ摜���瓮�搶��
: FFMPEG��1���̐Î~�悩�瓮����쐬���� | �Z�p�I���ٓ_
: 	http://tecsingularity.com/ffmpeg/make-movie/


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ���[�U���͏���
  : �Ώۉ摜�t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۉ摜�t�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

  : ���掞��
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo ���掞�ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem ������̃T�u���[�`���g�p
    call :DISMANTLE_TIME %start% %targetTimeFormat%
    set start=%ret_DISMANTLE_TIME01:"=%
    set startMilli=%ret_DISMANTLE_TIME02%

  : 1�b�����艽��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% 1�b�����薇������ TRUE NUM
    rem ���͒l���p��
    set rate=%return_UserInput1%

  : tbn����
    echo;
    echo tbn����(���l)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set tbn=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: �J�n���ԕb���ϊ�
    rem ������Ƃ��ĕ���
    set   strHour=%start:~0,2%
    set strMinute=%start:~3,2%
    set strSecond=%start:~6,2%

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

    rem ���l�ϊ�
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

    rem �b���ϊ�
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a  startSec=%secHour%+%secMinute%+%second%


: �摜�擾���s
  : -i :����w��
  : -ss:�J�n�ʒu(�b)
  : -t :�Ώۊ���(�b)
  : -r :1�b�����艽�������o����
  :     fps(�t���[�����[�g)�̊m�F�́uffprobe.exe �Ώۓ���v
  : -f :�uimage2 %%06d.jpg�v�w��Łu000001.jpg�v����A�ԏo�͎w��
  ffmpeg\win32\ffmpeg.exe -loop 1 -i %sourcePath% -vcodec h264 -pix_fmt yuv420p -t %startSec%%startMilli% -r %rate% -video_track_timescale %tbn% %outPath%
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