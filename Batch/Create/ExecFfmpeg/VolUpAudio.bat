@echo off
title %~nx0
echo ffmpeg�ŉ����t�@�C�����ʒ���


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 4 "PATH NUM NUM STR" %1 %2 %3 %4
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  : �������p��
    set srcPath=%1
    set     vol=%~2
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

  : �w��{�����[������
    echo;
    echo �w��{�����[������(�����Ŏw��ux.x�v)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set vol=%return_UserInput1%

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

    rem �{������
    goto :RUN


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

    rem ���ʒ���
      : -y     :�㏑��
      : -i     :�Ώۃt�@�C��
      : -af    :"volume=���l"
      :           ���ʒ���
      :           (��1:���ʎw��A�b�v
      :                -af "volume=+5dB"
      :           (��2:���ʎw��_�E��
      :                -af "volume=-5dB"
      :           (��3:����%�A�b�v
      :                -af "volume=1.5"
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -af "volume=%vol%" -acodec libmp3lame -ab %bitRate%k %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %vol:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b