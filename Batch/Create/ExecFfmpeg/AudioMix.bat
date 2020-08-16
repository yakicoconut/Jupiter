@echo off
title %~nx0
echo ffmpeg�ŉ�������
: audio - ffmpeg���g�p����2�̃I�[�f�B�I�t�@�C�����I�[�o�[���C/�_�E���~�b�N�X������@ - IT�c�[���E�F�u
: 	https://ja.coder.work/so/audio/105491
: FFmpeg Filters Documentation
: 	https://ffmpeg.org/ffmpeg-filters.html#amix


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 4 "PATH PATH NUM STR" %1 %2 %3 %4
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set srcPath=%1
  set mixPath=%2
  set bitRate=%3
  set outPath=%4

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

  : �Ώۉ����t�@�C��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۉ����t�@�C������ TRUE PATH
    rem ���͒l���p��
    set mixPath=%return_UserInput1%

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

    rem ��������
      : -y      :�㏑��
      : -i      :�Ώۃt�@�C��(2�ȏ�̃~�b�N�X�ɂ��Ή�)
      : -filter~:amix=
      :            ��������
      :            inputs=
      :              �Ώۃt�@�C�����w��
      :              �f�t�H���g2
      :              �u-i�v�I�v�V�����Ŏw�肵����
      :            duration=
      :              �o�̓t�@�C���̒���(�ȗ���)
      :              longest
      :                �K��
      :                �Ώۃt�@�C���̓��A�ł��������̂ɍ��킹��
      :              shortest
      :                �Z�����̂ɍ��킹��
      :              first
      :                ��ڂ̃t�@�C���ɍ��킹��
      : -acodec :
      :          libmp3lame
      :            
      : -ab     :�r�b�g���[�g�w��
      :          k�w��
      :          ���Ⴗ����ꍇ�A�ȉ��x���o��
      :            (��:�u192�v�w�聨�uBitrate 192 is extremely low, maybe you mean 192k�v
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %mixPath% -filter_complex amix="inputs=2:duration=first" -acodec libmp3lame -ab %bitRate%k %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %mixPath:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b