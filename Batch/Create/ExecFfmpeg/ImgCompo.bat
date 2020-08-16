@echo off
title %~nx0
echo ffmpeg�œ���Ƀ��f�B�A����
: ffmpeg ����ɃE�H�[�^�[�}�[�N�i���S�j�����Ă݂� - �]�������{�{
: 	http://fftest33.blog.fc2.com/blog-entry-80.html
: FFmpeg Filters Documentation
: 	https://ffmpeg.org/ffmpeg-filters.html


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


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

  : �����t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �����t�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set compPath=%return_UserInput1%

  : �z�u�ʒu
    echo;
    echo �z�u�ʒu(x=���l:y=���l)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set point=%return_UserInput1%

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
  call %call_ChkArgDataType% "PATH PATH STR STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7
  rem ���茋�ʂ����s�̏ꍇ�A�I����
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set  srcPath=%1
    set compPath=%2
    set    point=%3
    set    codec=%4
    set     rate=%5
    set      tbn=%6
    set  outPath=%7


rem �{����
:RUN
  : ���s
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �摜�������s
      : -y      :�㏑��
      : -i      :�Ώۃt�@�C��
      : -filter~:overlay=
      :            ���f�B�A(�r�f�I�E�摜)���d�˂�
      :            x=(y=)
      :              �z�u�ʒu
      :              main_w, W(main_h, H)
      :                �w�i�t�@�C����ʐ��@
      :              overlay_w, w(overlay_h, h)
      :                �z�u�t�@�C����ʐ��@
      : -c:v    :����R�[�f�b�N
      : -c:a    :�����R�[�f�b�N
      : -r      :�t���[�����[�g
      : -video~ :tbn�ݒ�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %compPath% -filter_complex overlay="%point:"=%" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %compPath:"=%>>%logPath%
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