@echo off
title %~nx0
echo ffmpeg�Ńt���[�����[�g��ύX����


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


  : �t���[�����[�g
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �t���[�����[�g TRUE NUM
    rem ���͒l���p��
    set fps=%return_UserInput1%


  : �o�̓t�@�C����
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �o�̓t�@�C�������� TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: ���s
  rem �������s
    : -i :����w��
    : -r :1�b�����艽�������o����
    :     fps(�t���[�����[�g)�̊m�F�́uffprobe.exe �Ώۓ���v
  ffmpeg\win32\ffmpeg.exe -i %inPath% -r %fps% %outPath%