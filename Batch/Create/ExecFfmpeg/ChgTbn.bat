@echo off
title %~nx0
echo ffmpeg��tbn����
: ffmpeg �ł̃t���[�����[�g�ݒ�̈Ⴂ | �j�R���{
: 	https://nico-lab.net/setting_fps_with_ffmpeg/
: ffmpeg�œ���̊e������m�F���� - Qiita
: 	https://qiita.com/ymotongpoo/items/eb9754b75606be117b70
: �r�f�I ? ffmpeg�A����DTS�̏����O��G���[�𔭐������� - �R�[�h���O
: 	https://codeday.me/jp/qa/20190531/908166.html


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
    echo �Ώۉ�ʃT�C�Y
    rem ������擾�o�b�`�g�p
    rem ��ʃT�C�Y�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=time_base -of csv=s=x:p=0" %sourcePath%

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


: ���s
  rem tbn�ύX
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -c copy -video_track_timescale %tbn% %outPath%
  pause