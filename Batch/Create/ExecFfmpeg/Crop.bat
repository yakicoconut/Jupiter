@echo off
title %~nx0
echo ffmpeg�ŉ�ʃT�C�Y�ύX
: FFprobeTips ? FFmpeg
: 	https://trac.ffmpeg.org/wiki/FFprobeTips


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
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=height,width -of csv=s=x:p=0" %sourcePath%

  : �N���b�v�w�����
    echo;
    echo �N���b�v�w�����
    echo ���o��X����:�o��Y����:�Ώ�X�̾��:�Ώ�Y�̾��
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set crop=%return_UserInput1%

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
  : -vf crop=a:b:c:d  :�N���b�v�ݒ�
  :                    a:�o��X�T�C�Y
  :                    b:�o��Y�T�C�Y
  :                    c:�Ώ�X�I�t�Z�b�g
  :                    d:�Ώ�Y�I�t�Z�b�g
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -vf crop=%crop% %outPath%
  pause