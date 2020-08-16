@echo off
title %~nx0
echo ffmpeg�ŉ摜�擾
: ffmpeg�œ��悩��Î~��𔲂��o�� - Qiita
: 	https://qiita.com/matoken/items/664e7a7e8f31e8a46a6:
: ffmpeg�f�t�H���g�o�̓t���[�����[�g
: 	https://avp.stackovernet.com/ja/q/6007
: ����
:   �J�n���Ԃ�r���ɐݒ肷��Ƃ��̈ʒu�܂ŏ����҂��ƂȂ�


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem ������擾�o�b�`
  set call_GetMpegInfo=%~dp0"GetMpegInfo.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����J�E���g
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %argc%==0 goto :USER_INPUT
  rem ��������`�ʂ�̏ꍇ�A���������
  if %argc%==4 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:4
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

    echo;
    echo �Ώ�fps
    echo r_frame_rate  :�S�^�C���X�^���v�𐳊m�ɕ\�����Ƃ��ł���
    echo                �Œ�̃t���[�����[�g(�X�g���[�����̂��ׂĂ�
    echo                �t���[�����[�g�̍ŏ����{��)
    echo avg_frame_rate:���σt���[�����[�g
    rem ������擾�o�b�`�g�p
    rem �Ώۓ���fps�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -select_streams v -show_entries stream=r_frame_rate -show_entries stream=avg_frame_rate" %srcPath%

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

  : 1�b�����艽��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% 1�b�����薇������ TRUE NUM
    rem ���͒l���p��
    set rate=%return_UserInput1%

    rem �{������
    goto :RUN


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH TIME TIME NUM" %1 %2 %3 %4
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
    set    rate=%4


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
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �摜�擾���s
    : -i :����w��
    : -ss:�J�n�ʒu(�b)
    : -t :�Ώۊ���(�b)
    : -r :1�b�����艽�������o����
    :     fps(�t���[�����[�g)�̊m�F�́uffprobe.exe �Ώۓ���v
    : -f :�uimage2 %%06d.jpg�v�w��Łu000001.jpg�v����A�ԏo�͎w��
    %~dp0ffmpeg\win32\ffmpeg.exe -i %srcPath% -ss %startSec%%startMilli% -t %length%%distMilli% -r %rate% -f image2 Img_%%06d.png


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %start:"=%%startMilli%>>%logPath%
  echo %dist:"=%%distMilli%>>%logPath%
  echo %rate:"=%>>%logPath%
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