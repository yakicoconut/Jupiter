@echo off
title %~nx0
echo ffmpeg�œ��敪��
: ffmpeg �ŉ��̃{�����[���𒲐�����Bgain ���� - ����}�O�ŁI
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014
: ffmpeg�Ŗ��򉻃J�b�g - �]�݂��X���b�v�A�E�g
: 	http://iamapen.hatenablog.com/entry/2018/12/30/100811
: ffmpeg ��360�x�����ҏW�����Ƃ��̃���
: 	https://gist.github.com/soonraah/7c7a8369829975aeb65ed048af789f4f


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"
  rem ���ԕb�ϊ��o�b�`
  set call_TimeToSec=%~dp0"..\..\OwnLib\TimeToSec.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 9 "PATH TIME TIME STR NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %8 %9
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF
  rem �^���茋�ʈ��p��
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType3%) do (
    rem �����t�H�[�}�b�g�擾
    set starFmt=%%a
    set distFmt=%%b
  )

  rem �������p��
  set srcPath=%1
  set   start="%2"
  set    dist="%3"
  set   color=%4
  set    size=%5
  set   codec=%6
  set    rate=%7
  set     tbn=%8
  set outPath=%9

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
  : ���ԏ���
    : �������ԏ���
      rem �o�ߎ��Ԍv�Z�o�b�`�g�p
      call %call_ElapsedTime% %start:"=% %dist:"=%
      set elapsed=%return_ElapsedTime%

    : �b���ϊ�
      rem �J�n����
      rem ���ԕb�ϊ��o�b�`�g�p
      call %call_TimeToSec% %start%
      set startSec=%return_TimeToSec1%
      rem �~���b������ꍇ�A�h�b�g�t���Ŋi�[
      if not "%return_TimeToSec2%"=="" ( set startMilli=.%return_TimeToSec2% )

      rem ��������
      call %call_TimeToSec% %elapsed%
      set length=%return_TimeToSec1%
      if not "%return_TimeToSec2%"=="" ( set elapsedMilli=.%return_TimeToSec2% )


  : �\���t�@�C�����ϊ�
    rem �u\�v���u/�v�ϊ�
    set strOutPath=%outPath:\=/%
    rem �u'�v���u�f�v�ϊ�
    set strOutPath=%outPath:'=�f%


  : ���s
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �������s
      : -y     :�㏑��
      : -ss    :�J�n�ʒu(�b)�A�u-i�v�I�v�V��������ɋL�q���Ȃ��Ɖ��Y������
      : -i     :�Ώۃt�@�C��
      : -t     :�Ώۊ���(�b)
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
      : -c:v   :����R�[�f�b�N
      : -c:a   :�����R�[�f�b�N
      : -r     :�t���[�����[�g
      : -video~:tbn�ݒ�
      : -strict:unofficial
      :           �V�̏��
    %~dp0ffmpeg\win32\ffmpeg.exe -y -ss %startSec%%startMilli% -i %srcPath% -t %length%%elapsedMilli% %codec:"=% -filter_complex drawtext="text=%strOutPath:"=%: fontcolor=%color%: fontsize=%size%: x=w-text_w:y=h-text_h" -r %rate% -video_track_timescale %tbn% -strict unofficial %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %start:"=%>>%logPath%
  echo %dist:"=%>>%logPath%
  echo %color:"=%>>%logPath%
  echo %size:"=%>>%logPath%
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