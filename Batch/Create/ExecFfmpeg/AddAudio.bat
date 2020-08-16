@echo off
title %~nx0
echo ffmpeg�ŉ����ǉ�
: FFmpeg�𗘗p��������̍����A�N���}�L�[���� - Qiita
: 	https://qiita.com/developer-kikikaikai/items/47a13cbcb6fdb535345a
: ffmpeg���g���ē���Ɖ���������������@ | ��IT��Ƃɋ΂߂钆�N�T�����[�}����IT���L
: 	http://pineplanter.moo.jp/non-it-salaryman/2019/04/21/ffmpeg-join/
: ffmpeg���g���ĉf���Ɖ������������� - Qiita
: 	https://qiita.com/niusounds/items/f69a4438f52fbf81f0bd
: android - ffmpeg�œ���Ɖ�������������Ƃ��ɐ擪�ɖ�����ǉ�����ɂ� - �X�^�b�N�E�I�[�o�[�t���[
: 	https://ja.stackoverflow.com/questions/18161/ffmpeg%E3%81%A7%E5%8B%95%E7%94%BB%E3%81%A8%E9%9F%B3%E5%A3%B0%E3%82%92%E7%B5%90%E5%90%88%E3%81%99%E3%82%8B%E3%81%A8%E3%81%8D%E3%81%AB%E5%85%88%E9%A0%AD%E3%81%AB%E7%84%A1%E9%9F%B3%E3%82%92%E8%BF%BD%E5%8A%A0%E3%81%99%E3%82%8B%E3%81%AB%E3%81%AF


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
  if %argc%==7 goto :CHK_ARG

  echo �����̐�����`�ƈقȂ邽�߁A�I�����܂�
  echo ����:%argc%
  echo ��`:7
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

  : �Ώۉ����t�@�C��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۉ����t�@�C������ TRUE PATH
    rem ���͒l���p��
    set audioPath=%return_UserInput1%

  : �J�n����
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo �J�n���ԓ���(hh:mm:ss.fff)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

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
  call %call_ChkArgDataType% "PATH PATH TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7
  rem ���茋�ʂ����s�̏ꍇ�A�I����
  if %ret_ChkArgDataType1%==0 goto :EOF

  : �������p��
    set   srcPath=%1
    set audioPath=%2
    set     start=%3
    set     codec=%4
    set      rate=%5
    set       tbn=%6
    set   outPath=%7


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
      : -y        :�㏑��
      : -i        :�Ώۃt�@�C��
      : -itsoffset:�J�n����
      :            �}���t�@�C�����O�ɋL�q�K�{
      : -map      :
      : -c:v      :����R�[�f�b�N
      : -c:a      :�����R�[�f�b�N
      : -r        :�t���[�����[�g
      : -video~   :tbn�ݒ�
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -itsoffset %start:"=% -i %audioPath% -map 0:v:0 -map 1:a:0 %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%
    REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% %outPath%
    REM ffmpeg\win32\ffmpeg.exe -i %srcPath% -i %audioPath% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ���O�o��
  echo %srcPath:"=%>>%logPath%
  echo %audioPath:"=%>>%logPath%
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