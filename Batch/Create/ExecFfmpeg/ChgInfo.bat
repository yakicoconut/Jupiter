@echo off
title %~nx0
echo ffmpeg�œ���ݒ��ύX����
: ffmpeg �ł̃t���[�����[�g�ݒ�̈Ⴂ | �j�R���{
: 	https://nico-lab.net/setting_fps_with_ffmpeg/
: ffmpeg�œ���̊e������m�F���� - Qiita
: 	https://qiita.com/ymotongpoo/items/eb9754b75606be117b70
: �r�f�I ? ffmpeg�A����DTS�̏����O��G���[�𔭐������� - �R�[�h���O
: 	https://codeday.me/jp/qa/20190531/908166.html


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
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
  if %argc%==5 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:5
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
  call %call_ChkArgDataType% "PATH STR NUM NUM STR" %1 %2 %3 %4 %5
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set srcPath=%1
    set   codec=%2
    set    rate=%3
    set     tbn=%4
    set outPath=%5


rem �{����
:RUN
  : ���s
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �ύX���s
    : -i :����w��
    : -r :1�b�����艽�������o����
    :     �t���[�����[�g�̊m�F�́uffprobe.exe �Ώۓ���v
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
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
