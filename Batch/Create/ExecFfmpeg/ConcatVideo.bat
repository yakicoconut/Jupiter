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


  : �o�̓t�@�C����
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �o�̓t�@�C�������� TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: ���s
  rem �������s
    : -f     :�uimage2 %%06d.jpg�v�w��Łu000001.jpg�v����A�ԏo�͎w��
    : -safe  :
    : -i     :����w��
    : -c copy:�I���W�i���t�@�C���̃R�[�f�b�N���ăG���R�[�h���邱�ƂȂ���������
  ffmpeg\win32\ffmpeg.exe -f concat -safe 0 -i %concatList% -c copy %outPath%
  rem ����_�ʉ�
REM   ffmpeg\ffmpeg.exe -f concat -safe 0  -i %concatList% -vcodec h264 -acodec aac -strict experimental %outPath%