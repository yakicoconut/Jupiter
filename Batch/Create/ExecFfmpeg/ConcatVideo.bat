@echo off
title %~nx0
echo ffmpeg�œ��挋��


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ���[�U���͏���
  : �Ώی������X�g�t�@�C���p�X
    echo;
    echo �Ώی������X�g�t�@�C���p�X����
    echo �������t�@�C�����A�ӏ������ufile '�t�@�C��'�v
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% ���R�����g�́u#�v TRUE PATH
    rem ���͒l���p��
    set concatList=%return_UserInput1%

  : �R�[�f�b�N
    echo;
    echo �R�[�f�b�N����(-c:v ���溰�ޯ� -c:a �������ޯ�)
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
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �o�̓t�@�C�������� TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: ���s
  rem ����
    : -f concat:
    : -safe 0  :
    : -i       :
    : -c copy  :
  ffmpeg\win32\ffmpeg.exe -f concat -safe 0 -i %concatList% %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  pause