@echo off
title %~nx0
echo ffmpeg�œ��挋��


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����J�E���g
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem �������Ȃ��ꍇ�A���[�U���͂�
  if %argc%==0 goto :USER_INPUT
  rem ��������`�ʂ�̏ꍇ�A���������
  if %argc%==5 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:5
  pause
  exit /b


rem ���[�U���͏���
:USER_INPUT
  : �Ώی������X�g�t�@�C���p�X
    echo;
    echo �Ώی������X�g�t�@�C���p�X����
    echo �������t�@�C�����A�ӏ������ufile '�t�@�C��'�v
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% ���R�����g�́u#�v TRUE PATH
    rem ���͒l���p��
    set concatList=%return_UserInput1%

  : �R�[�f�b�N
    echo;
    echo �R�[�f�b�N����(-c:v ���溰�ޯ� -c:a �������ޯ�)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" FALSE STR
    rem ���͒l���p��
    set codec=%return_UserInput1:"=%

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
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �o�̓t�@�C�������� TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%

    rem �{������
    goto :RUN


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH STR NUM NUM STR" %1 %2 %3 %4 %5
  rem ���茋�ʂ����s�̏ꍇ�A�I����
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set concatList=%1
    set      codec=%2
    set       rate=%3
    set        tbn=%4
    set    outPath=%5


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

    rem ���挋��
      : -y     :�㏑��
      : -f     :concat
      :           
      : -safe  :0
      :           
      : -i     :�Ώۃt�@�C��(�������惊�X�g�t�@�C��)
      : -c:v   :����R�[�f�b�N
      : -c:a   :�����R�[�f�b�N
      : -r     :�t���[�����[�g
      : -video~:tbn�ݒ�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -f concat -safe 0 -i %concatList% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %concatList:"=%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem �������Ȃ�(���[�U���͂Ŏ��s����)�ꍇ�A�|�[�Y
  if %argc%==0 pause

exit /b