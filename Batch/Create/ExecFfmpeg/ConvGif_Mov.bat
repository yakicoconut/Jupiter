@echo off
title %~nx0
echo ffmpeg�œ��悩��Gif����
: ffmpeg�̊�{�I�Ȏg���� | | Gnzo Labo
: 	https://apiwb01.gnzo.com/labo/archives/100
: FFmpeg�œ����GIF�ɕϊ� - Qiita
: 	https://qiita.com/wMETAw/items/fdb754022aec1da88e6e


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem ������擾�o�b�`
  set call_GetMpegInfo=%~dp0"GetMpegInfo.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 4 "PATH STR NUM STR" %1 %2 %3 %4
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set srcPath=%1
  set    size=%2
  set    rate=%3
  set outPath=%4

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

    echo;
    echo �Ώۃt���[�����[�g
    rem ������擾�o�b�`�g�p
    rem �t���[�����[�g�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -show_entries stream=r_frame_rate -i" %srcPath%

    echo;
    echo �Ώۉ�ʃT�C�Y
    rem ������擾�o�b�`�g�p
    rem ��ʃT�C�Y�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %srcPath%

  : �o�̓T�C�Y
    echo;
    echo �o�̓T�C�Y(HeightxWidth)����
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set size=%return_UserInput1%

  : 1�b�����艽��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% 1�b�����薇������ TRUE NUM
    rem ���͒l���p��
    set rate=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


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

    rem Gif����
      : -y      :�㏑��
      : -i      :�Ώۃt�@�C��
      : -an     :
      : -r      :�t���[�����[�g
      : -pix_fmt:rgb24
      :           
      : -f      :gif
      :           
      : -s      :
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -an -r %rate% -pix_fmt rgb24 -f gif -s %size% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %size:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause