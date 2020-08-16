@echo off
title %~nx0
echo ffmpeg�œ��敪��
: ffmpeg �ŉ��̃{�����[���𒲐�����Bgain ���� - ����}�O�ŁI
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014
: ffmpeg�Ŗ��򉻃J�b�g - �]�݂��X���b�v�A�E�g
: 	http://iamapen.hatenablog.com/entry/2018/12/30/100811


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"


: �����`�F�b�N
  rem �����J�E���g
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %argc%==0 goto :USER_INPUT
  rem ��������`�ʂ�̏ꍇ�A���������
  if %argc%==7 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:7
  pause
  exit /b


rem ���[�U���͏���
:USER_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set srcPath=%return_UserInput1%

  : �J�n����
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo �J�n���ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

  : ��������
    echo;
    echo �������ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set dist=%return_UserInput1%
    set distFmt=%return_UserInput2%

  : �R�[�f�b�N
    echo;
    echo �R�[�f�b�N����(-c:v ����Codec -c:a ����Codec)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set codec=%return_UserInput1:"=%

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

    rem �{������
    goto :RUN


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH TIME TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType1%==0 goto :EOF
  rem �^���茋�ʈ��p��
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType2%) do (
    rem �����t�H�[�}�b�g�擾
    set starFmt=%%a
    set distFmt=%%b
  )

  : �������p��
    set srcPath=%1
    set   start="%2"
    set    dist="%3"
    set   codec=%4
    set    rate=%5
    set     tbn=%6
    set outPath=%7


rem �{����
:RUN
  : �J�n���ԕb���ϊ�
    rem ������̃T�u���[�`���g�p
    call :DISMANTLE_TIME %start% %starFmt%
    set start=%ret_DISMANTLE_TIME01:"=%
    set startMilli=%ret_DISMANTLE_TIME02%

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


  : �������ԕb���ϊ�
    rem ������̃T�u���[�`���g�p
    call :DISMANTLE_TIME %dist% %distFmt%
    set dist=%ret_DISMANTLE_TIME01%
    set distMilli=%ret_DISMANTLE_TIME02%

    rem �o�ߎ��Ԍv�Z�o�b�`�g�p
    call %call_ElapsedTime% %start:"=% %dist:"=%
    set elapsed=%return_ElapsedTime%

    : ���ڕ���
      rem ������Ƃ��ĕ���
      set   strHour=%elapsed:~0,2%
      set strMinute=%elapsed:~3,2%
      set strSecond=%elapsed:~6,2%

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
      set /a    length=%secHour%+%secMinute%+%second%


  : ���s
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �������s
    : -y         :�㏑��
    : -ss        :�J�n�ʒu(�b)�A�u-i�v�I�v�V��������ɋL�q���Ȃ��Ɖ��Y������
    : -i         :���t�@�C��
    : -t         :�Ώۊ���(�b)
    : -c:v copy  :�f�����ϊ�(����)
    : -c:a copy  :�������ϊ�(����)
    : -async ���l:�����T���v���� Stretch/Squeeze (�܂�T���v���̎������Ԃ�ύX) ���ē�������
    :             ���l(1~1000)�͉����Y�����Ƃ��ɂP�b�Ԃŉ��T���v���܂ŕύX���Ă��������w�肷��
    :             �u1�v�w��͓��ʂŁA�����̍ŏ������������Č㑱�̃T���v���͂��̂܂�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -ss %startSec%%startMilli% -i %srcPath% -t %length%%distMilli% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %start:"=%%startMilli%>>%logPath%
  echo %dist:"=%%distMilli%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b


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