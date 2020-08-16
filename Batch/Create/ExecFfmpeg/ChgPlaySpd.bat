@echo off
title %~nx0
echo ffmpeg�ōĐ����x����
: ffmpeg���g���ē���̍Đ����x��ς��Ă݂� - �]�������{�{
: 	http://fftest33.blog.fc2.com/blog-entry-36.html
: �f���Ɖ����� pts ������ setpts, asetpts | �j�R���{
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/
: ffmpeg�̎g������R�}���h�ꗗ���܂Ƃ߂܂����B���惊�T�C�Y�E�Î~��ϊ��E�t���[����Ԃɂ���|������J�����B
: 	https://photo-tea.com/p/17/ffmpeg-command-list/


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 6 "PATH NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem �������p��
  set  srcPath=%1
  set spdRatio=%2
  set    codec=%3
  set     rate=%4
  set      tbn=%5
  set  outPath=%6

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

  : �{�������
    echo;
    echo �{�������(�����Ŏw��ux.x�v)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE NUM
    rem ���͒l���p��
    set spdRatio=%return_UserInput1%

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

    rem ���摬�x����
      : -y     :�㏑��
      : -i     :�Ώۃt�@�C��
      : -vf    :setpts=PTS/���l
      :           (��1:
      : -af    :atempo=���l
      :           (��1:
      : -c:v   :����R�[�f�b�N
      : -c:a   :�����R�[�f�b�N
      : -r     :�t���[�����[�g
      : -video~:tbn
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -vf setpts=PTS/%spdRatio% -af atempo=%spdRatio% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %spdRatio:"=%>>%logPath%
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