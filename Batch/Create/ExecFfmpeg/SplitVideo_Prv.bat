@echo off
title %~nx0
echo ���敪���擪�����m�F


: �Q�ƃo�b�`
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem �����^����o�b�`
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"
  rem ���ԕb�ϊ��o�b�`
  set call_TimeToSec=%~dp0"..\..\OwnLib\TimeToSec.bat"
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo=%~dp0"..\..\OwnLib\DirFilePathInfo.bat"


: �����`�F�b�N
  rem �����^����o�b�`�g�p
  call %call_ChkArgDataType% 9 "PATH TIME TIME NUM NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %8 %9
  rem �������Ȃ��ꍇ�A���[�U���͂�
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem ���茋�ʂ����s�̏ꍇ�A�I��
  if %ret_ChkArgDataType2%==0 goto :EOF
  rem �^���茋�ʈ��p��
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType3%) do (
    rem �����t�H�[�}�b�g�擾
    set starFmt=%%a
    set distFmt=%%b
  )

  rem �������p��
  set srcPath=%1
  set   start="%2"
  set    dist="%3"
  set /a lead=%4
  set /a term=%5
  set   codec=%6
  set    rate=%7
  set     tbn=%8
  set outPath=%9

  rem �{������
  goto :RUN


rem ���[�U���͏���
:USER_INPUT
  echo �������Ȃ����߁A�I�����܂�
  pause
  exit /b


rem �{����
:RUN
  : �b���ϊ�
    rem �J�n����
    rem ���ԕb�ϊ��o�b�`�g�p
    call %call_TimeToSec% %start%
    set startSec=%return_TimeToSec1%
    rem �~���b������ꍇ�A�h�b�g�t���Ŋi�[
    if not "%return_TimeToSec2%"=="" ( set startMilli=.%return_TimeToSec2% )

    rem ��������
    call %call_TimeToSec% %dist%
    set distSec=%return_TimeToSec1%
    set /a calcDistSec=%distSec% - %term%
    if not "%return_TimeToSec2%"=="" ( set distMilli=.%return_TimeToSec2% )

  : �t�@�C��������
    rem �f�B���N�g���t�@�C�����o�b�`�g�p
    call %call_DirFilePathInfo% %outPath% dp
    set dirPath=%return_DirFilePathInfo%
    call %call_DirFilePathInfo% %outPath% n
    set fileName=%return_DirFilePathInfo%
    call %call_DirFilePathInfo% %outPath% x
    set ex=%return_DirFilePathInfo%

  : �T�u���[�`���Ăяo��
    rem 
    call :EXEC_CMD %startSec% %lead% %startMilli% _A_LEAD
    rem 
    call :EXEC_CMD %calcDistSec% %term% %distMilli% _B_TERM

    exit /b


rem ���s�T�u���[�`��
:EXEC_CMD
SETLOCAL
  : ����
    set startSec=%1
    set length=%2
    set startMilli=%3
    set elapsedMilli=%3
    set id=%4

  : �t�@�C�������ʎq�ǉ�
    rem �\���t�@�C�����쐬
    set strOutPath=%fileName%%id%%ex%
    rem �o�̓t�@�C���p�X�쐬
    set outPath=%dirPath%%strOutPath%

    rem �\���t�@�C�����ϊ�
    rem �u\�v���u/�v�ϊ�
    set strOutPath=%strOutPath:\=/%
    rem �u'�v���u�f�v�ϊ�
    set strOutPath=%strOutPath:'=�f%

  : ���s
    rem �������s
    %~dp0ffmpeg\win32\ffmpeg.exe -y -ss %startSec%%startMilli% -i %srcPath% -t %length%%elapsedMilli% %codec:"=% -filter_complex drawtext="text=%strOutPath:"=%: fontcolor=green: fontsize=30: x=w-text_w:y=h-text_h" -r %rate% -video_track_timescale %tbn% %outPath%

ENDLOCAL
exit /b