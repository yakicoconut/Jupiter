@echo off
title %~nx0
echo ffmpeg�ŕ�����}��
: ffmpeg�œ����Ƀe�L�X�g��`�悷�� - Qiita
: 	https://qiita.com/niusounds/items/797fe0743a9d59681446
: FFmpeg Filters Documentation
: 	https://www.ffmpeg.org/ffmpeg-filters.html#Syntax
: ffmpeg drawtext�t�B���^�ŗV��ł݂� - �]�������{�{
: 	http://fftest33.blog.fc2.com/blog-entry-45.html


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem 10�ȍ~�̈����擾
  set arg07=%7
  set arg08=%8
  set arg09=%9
  shift /7
  shift /7
  shift /7
  set arg10=%7
  set arg11=%8
  set arg12=%9

  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 12 "PATH STR PATH STR NUM STR TIME TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %arg07% %arg08% %arg09% %arg10% %arg11% %arg12%
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF
  rem �^���茋�ʈ��p��
  for /f "tokens=7,8" %%a in (%ret_ChkArgDataType3%) do (
    rem �����t�H�[�}�b�g�擾
    set starFmt=%%a
    set distFmt=%%b
  )

  rem �������p��
  set batName=%0
  set srcPath=%1
  set     txt=%2
  set    font=%3
  set   color=%4
  set    size=%5
  set   point=%6
  set   start="%arg07%"
  set    dist="%arg08%"
  set   codec=%arg09%
  set    rate=%arg10%
  set     tbn=%arg11%
  set outPath=%arg12%

  rem �{������
  goto :RUN


rem ���[�U���͏���
:USER_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set srcPath=%return_UserInput1%

  : �}���e�L�X�g
    echo;
    echo �}���e�L�X�g����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set txt=%return_UserInput1%

  : �t�H���g�t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �t�H���g�t�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set font=%return_UserInput1%

  : �J���[
    echo;
    echo �J���[(white�A#88e5ff��)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set color=%return_UserInput1%

  : �T�C�Y����
    echo;
    echo �T�C�Y����(���l)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set size=%return_UserInput1%

  : �z�u�ʒu
    echo;
    echo �z�u�ʒu(x=���l:y=���l)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set point=%return_UserInput1%

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


rem �{����
:RUN
  : �t�H���g�t�@�C���p�X�ϊ�
    rem �u:�v�́u\\�v�ŃG�X�P�[�v
    rem �u\�v�́u/�v�ɕϊ�
    set font=%font:\=/%
    set font=%font::=\\:%

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
    set dist=%ret_DISMANTLE_TIME01:"=%
    set distMilli=%ret_DISMANTLE_TIME02%

    rem ������Ƃ��ĕ���
    set   strHour=%dist:~0,2%
    set strMinute=%dist:~3,2%
    set strSecond=%dist:~6,2%

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
    set /a   distSec=%secHour%+%secMinute%+%second%

  : ���s
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �������s
      : -y      :�㏑��
      : -i      :�Ώۃt�@�C��
      : -filter~:drawtext=
      :            �e�L�X�g�`��
      :            fontfile=ttf�t�@�C���p�X
      :              �t�H���g�w��
      :              ���v����
      :            text=�Ώۃe�L�X�g
      :              �`��Ώۃe�L�X�g
      :            fontcolor=�t�H���g�F
      :              �t�H���g�F(white�A#88e5ff��)
      :            fontsize=���l
      :              �t�H���g�T�C�Y
      :            x=(y=)
      :              �e�L�X�g�z�u�ʒu
      :              ���l
      :                �z�u�ʒuX
      :              main_w(w)�Amain_h(h)
      :                �Ώۓ��敝�A�����\���
      :              text_w(tw)�Atext_h(th)
      :                ���̓e�L�X�g���A�����\���
      :              (��:��ʒ����ɔz�u
      :                  x=(w-text_w)/2:y=(h-text_h-line_h)/2
      :            enable='between(t,�J�n����,��������)'
      :              �`�掞��
      : -c:v    :����R�[�f�b�N
      : -c:a    :�����R�[�f�b�N
      : -r      :�t���[�����[�g
      : -video~ :tbn�ݒ�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -filter_complex drawtext="fontfile=%font:"=%: text=%txt:"=%: fontcolor=%color%: fontsize=%size%: %point:"=%: enable='between(t,%startSec%%startMilli%,%distSec%%distMilli%)'" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %txt:"=%>>%logPath%
  echo %font:"=%>>%logPath%
  echo %color:"=%>>%logPath%
  echo %size:"=%>>%logPath%
  echo %point:"=%>>%logPath%
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