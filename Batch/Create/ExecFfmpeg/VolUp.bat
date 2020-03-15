@echo off
title %~nx0
echo ffmpeg�ŉ��ʒ���
: ffmpeg �ŉ��̃{�����[���𒲐�����Bgain ���� - ����}�O�ŁI
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

  : �w��{�����[������
    echo;
    echo �w��{�����[������(�����Ŏw��ux.x�v)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set vol=%return_UserInput1%

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
  rem ���ʒ���
  : -i                :���t�@�C��
  : -af "volume=���l" :���ʒ���
  :                    (��1:���ʎw��A�b�v
  :                         -af "volume=+5dB"
  :                    (��2:���ʎw��_�E��
  :                         -af "volume=-5dB"
  :                    (��3:����%�A�b�v
  :                         -af "volume=1.5"
  : -async ���l       :�����T���v���� Stretch/Squeeze (�܂�T���v���̎������Ԃ�ύX) ���ē�������
  :                    ���l(1~1000)�͉����Y�����Ƃ��ɂP�b�Ԃŉ��T���v���܂ŕύX���Ă��������w�肷��
  :                    �u1�v�w��͓��ʂŁA�����̍ŏ������������Č㑱�̃T���v���͂��̂܂�
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -af "volume=%vol%" %codec% -r %rate% -video_track_timescale %tbn% %outPath% -async 1
  pause