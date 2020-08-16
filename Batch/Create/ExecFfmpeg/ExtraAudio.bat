@echo off
title %~nx0
echo ffmpeg�ŉ������o
: �yffmpeg�z �}���`�g���b�N�̓���̍��� - �j�R�j�R���挤����
: 	https://looooooooop.blog.fc2.com/blog-entry-960.html
: FFMpeg��DVD(VOB)�n����(AC3�EDTS)��ϊ�����
: 	http://49.212.76.154/pc/ffmpeg_dvd.html


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 3 "PATH NUM STR" %1 %2 %3
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set srcPath=%1
  set bitRate=%2
  set outPath=%3

  rem �{������
  goto :RUN


rem ���[�U���͏���
:USER_INPUT
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set srcPath=%return_UserInput1%

  : �r�b�g���[�g����
    echo;
    echo �o�̓r�b�g���[�g����(���l)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set bitRate=%return_UserInput1%

  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


rem �{����
:RUN
  : ���s
    rem ���O�t�H���_�쐬
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem �t�@�C�����Ń��O�t�@�C���p�X�ݒ�
    set logPath=%~dp0Log\%~n0.log
    rem ���s�O���O�o��
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem �������o���s
      : -y     :�㏑��
      : -i     :�Ώۃt�@�C��
      : -acodec:
      :         libmp3lame
      :           
      : -ab    :�r�b�g���[�g�w��
      :         k�w��
      :         ���Ⴗ����ꍇ�A�ȉ��x���o��
      :           (��:�u192�v�w�聨�uBitrate 192 is extremely low, maybe you mean 192k�v
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -acodec libmp3lame -ab %bitRate%k %outPath%

    rem ���ԃv���p�e�B�����������Ȃ�I�v�V����
      : -vcodec :copy
      :            �R�[�f�b�N�R�s�[
      : -map    :����̐��������͏��A�u:�v �ŋ�؂��Ď��̐�����
      :          �R���e�i�t�H�[�}�b�g�Ɋ��蓖�Ă��Ă��鏇��
      :          ��ʓI�ȓ���́u0:0�v���f���A�u0:1�v�������ŁA�u0:2�v�ȍ~���������܂��͎���
    REM %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath%  -vcodec copy -map 0:1 %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b


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