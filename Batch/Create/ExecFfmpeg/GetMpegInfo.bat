@echo off
title %~nx0
echo ffmpeg�œ�������擾����


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set inPath=%return_UserInput1%


: ���s
  rem �������s
  ffmpeg\win32\ffprobe.exe %inPath%
  pause