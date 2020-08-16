@echo off
title %~nx0
echo ffmpeg�ŉ����ǉ�
: FFmpeg�𗘗p��������̍����A�N���}�L�[���� - Qiita
: 	https://qiita.com/developer-kikikaikai/items/47a13cbcb6fdb535345a
: ffmpeg���g���ē���Ɖ���������������@ | ��IT��Ƃɋ΂߂钆�N�T�����[�}����IT���L
: 	http://pineplanter.moo.jp/non-it-salaryman/2019/04/21/ffmpeg-join/


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set srcPath=%return_UserInput1%

  : �Ώۉ����t�@�C��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۉ����t�@�C������ TRUE PATH
    rem ���͒l���p��
    set audioPath=%return_UserInput1%

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


: ���s
  rem ��������
  ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -map 0:v:0 -map a:a:0 %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% %outPath%
  REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -r %rate% -video_track_timescale %tbn% %outPath%
  pause