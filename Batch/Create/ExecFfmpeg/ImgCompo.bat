@echo off
title %~nx0
echo ffmpeg�œ���ɉ摜������
: ffmpeg ����ɃE�H�[�^�[�}�[�N�i���S�j�����Ă݂� - �]�������{�{
: 	http://fftest33.blog.fc2.com/blog-entry-80.html


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ���[�U���͏���
  : �w�i����t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �w�i����t�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%

  : ��������t�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% ��������t�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set compPath=%return_UserInput1%

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


: �摜�������s
  : 
  : 
  : 
  : 
  : 
  : 
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -i %compPath% -filter_complex overlay %codec% -r %rate% -video_track_timescale %tbn% %outPath%
  pause


exit


rem ������̃T�u���[�`��
:DISMANTLE_TIME
SETLOCAL
  : ����
    rem ���͎���
    set inpTime=%1
    rem �����t�H�[�}�b�g
    set format=%2

  : �~���b�����݂���ꍇ
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-3,2%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-4,3%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-5,4%
    )

  : �擪�um�v�A�uh�v�A�uhh�v���f
    if %format:~0,2%==mm (
      set tms="00:%inpTime:~1,5%"
    )
    if %format:~0,2%==h: (
      set tms="0%inpTime:~1,7%"
    )
    if %format:~0,3%==hh: (
      rem �uhh�v�̏ꍇ���~���b�𔲂�
      set tms="%inpTime:~1,8%"
    )

rem �Ԃ�l1:�����b
rem �Ԃ�l2:�~���b
ENDLOCAL && set ret_DISMANTLE_TIME01=%tms%&& set ret_DISMANTLE_TIME02=%milli%
exit /b