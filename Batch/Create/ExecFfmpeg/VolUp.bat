@echo off
title %~nx0
echo ffmpeg�ŉ��ʒ���
: ffmpeg �ŉ��̃{�����[���𒲐�����Bgain ���� - ����}�O�ŁI
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014


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
  if %argc%==6 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:6
  pause
  exit /b


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

  : �R�[�f�b�N
    echo;
    echo �R�[�f�b�N����(-c:v ����Codec -c:a ����Codec)
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
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%

    rem �{������
    goto :RUN


rem ��������
:CHK_ARG
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% "PATH NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set srcPath=%1
    set     vol=%~2
    set   codec=%3
    set    rate=%4
    set     tbn=%5
    set outPath=%6


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
      : -async:���l
      :          �����T���v���� Stretch/Squeeze (�܂�T���v���̎������Ԃ�ύX) ���ē�������
      :          ���l(1~1000)�͉����Y�����Ƃ���1�b�Ԃŉ��T���v���܂ŕύX���Ă��������w�肷��
      :          �u1�v�w��͓��ʂŁA�����̍ŏ������������Č㑱�̃T���v���͂��̂܂�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -async 1 -af "volume=%vol%" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %vol:"=%>>%logPath%
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