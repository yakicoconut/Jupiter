@echo off
title %~nx0
echo ffmpeg�Ńt���[�����[�g��ύX����


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
    set inPath=%return_UserInput1%

    echo;
    echo �Ώ�fps
    echo r_frame_rate  :�S�^�C���X�^���v�𐳊m�ɕ\�����Ƃ��ł���
    echo                �Œ�̃t���[�����[�g(�X�g���[�����̂��ׂĂ�
    echo                �t���[�����[�g�̍ŏ����{��)
    echo avg_frame_rate:���σt���[�����[�g
    rem ������擾�o�b�`�g�p
    rem �Ώۓ���fps�̂ݎ擾�I�v�V����
    call %call_GetMpegInfo% "-v error -select_streams v -show_entries stream=r_frame_rate -show_entries stream=avg_frame_rate" %inPath%

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