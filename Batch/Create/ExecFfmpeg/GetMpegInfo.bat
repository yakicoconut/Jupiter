@echo off
title %~nx0
echo ffmpeg�œ�������擾����
rem ����01:�I�v�V����
rem ����02:�Ώۃt�@�C���p�X
rem �ߒl  :�Ȃ�


rem �ϐ����[�J����
SETLOCAL
  : �Q�ƃo�b�`
    rem �Ăяo����z�肵�Ď��g�Ɠ����t�H���_���w��
    rem ���[�U���̓o�b�`
    set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"


  : ����
    rem �I�v�V����
    set option=%1


  : �����L���m�F
    rem �������Ȃ��ꍇ�A���[�U���͏�����
    if "%~2"=="" ( goto :NOARG )

    rem ������ϐ��ɐݒ�
    set inPath=%2
    rem ���s��
    goto :RUN


  rem ���[�U���͏���
  :NOARG
    : �Ώۃt�@�C���p�X
      echo;
      rem ���[�U���̓o�b�`�g�p
      call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
      rem ���͒l���p��
      set inPath=%return_UserInput1%


  rem ���s
  :RUN
    rem �������s
    : �����A���̂ݎ擾
    :   -v error                         :
    :   -select_streams v:0              :
    :   -show_entries stream=height,width:
    :   -of csv=s=x:p=0                  :
    ffmpeg\win32\ffprobe.exe %option:"=% %inPath%
    pause