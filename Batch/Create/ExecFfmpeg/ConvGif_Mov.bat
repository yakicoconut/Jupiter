@echo off
title %~nx0
echo ffmpeg�œ��悩��Gif����
: ffmpeg�̊�{�I�Ȏg���� | | Gnzo Labo
: 	https://apiwb01.gnzo.com/labo/archives/100
: FFmpeg�œ����GIF�ɕϊ� - Qiita
: 	https://qiita.com/wMETAw/items/fdb754022aec1da88e6e


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem ������擾�o�b�`
  set call_GetMpegInfo="GetMpegInfo.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

    echo;
    echo �Ώۃt���[�����[�g
    rem ������擾�o�b�`�g�p
    rem �t���[�����[�g�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -show_entries stream=r_frame_rate -i" %sourcePath%

    echo;
    echo �Ώۉ�ʃT�C�Y
    rem ������擾�o�b�`�g�p
    rem ��ʃT�C�Y�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %sourcePath%

  : �t���[�����[�g
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �t���[�����[�g TRUE NUM
    rem ���͒l���p��
    set fps=%return_UserInput1%

  : �o�̓T�C�Y
    echo;
    echo �o�̓T�C�Y����
    echo ��(HEIGHTxWIDTH)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set size=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: ���s
  rem Gif����
  ffmpeg\win32\ffmpeg.exe -i  %sourcePath% -an -r %fps% -pix_fmt rgb24 -f gif -s %size% %outPath%
  pause