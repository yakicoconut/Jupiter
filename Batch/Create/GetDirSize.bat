@echo off
title %~nx0
echo �t�H���_�e�ʎ擾
: Windows�o�b�`�t�@�C�� �t�H���_�̗e�ʂ��ꗗ : �f�G�ȒU�߂���ɂȂ�I
: 	http://blog.livedoor.jp/shige19840901/archives/51692011.html


: �Q�ƃo�b�`
  rem ���p�X�y�[�X��떄�߃o�b�`
  set call_SpacePadding="..\OwnLib\SpacePadding.bat"

pause
: �錾
  REM rem ���~�ߌ���
  REM set /a paddDigit=20

  REM rem �o�̓t�@�C����
  REM set fname= %~dp0sizelist.csv
  REM echo;
  REM echo �Ώۃt�H���_�p�X����

  REM rem �ϐ�������
  REM set USR=

  REM set /P USR="���͂��Ă�������:"
  REM set targetDirPath=%USR%
  REM : �˂��ݕԂ�_�󔒂̏ꍇ
  REM   if "%targetDirPath%"=="" (
  REM     echo;
  REM     echo ���͂�����܂���
  REM     echo �I�����܂�
  REM     goto :EOF
  REM   )
  REM : �˂��ݕԂ�_�Ώۂ����݂��Ȃ��ꍇ
  REM   if not exist "%targetDirPath%" (
  REM     echo;
  REM     echo �w��t�@�C�������݂��܂���
  REM     echo �I�����܂�
  REM     goto :EOF
  REM   )
set targetDirPath=E:\Etemp

: ���s
  rem �J�����g�t�H���_�ύX
  pushd %targetDirPath%

  rem �S�t�H���_���[�v
  rem �T�C�Y�擾�T�u���[�`���g�p
  for /d %%d in (*) do call :GET_SIZE "%~dp0%%d"


: ������
  echo;
  echo;
  pause
  exit


rem �T�C�Y�擾�T�u���[�`��
  : ����1:�t�H���_��
:GET_SIZE
  rem ������dir�R�}���h�Ŏg�p
  for /f "tokens=3 delims= " %%a in ('dir /s %1 ^| find "�̃t�@�C��"') do set size=%%a
  REM rem �擾�����T�C�Y���o��
  REM echo %1,"%size%">>%fname%

  rem ���p�X�y�[�X���߃o�b�`�g�p
  call %call_SpacePadding% %~1 %paddDigit%
  set targetDirName=%return_SpacePadding%

  : �M�K�o�C�g�ϊ�
    rem �J���}����
    set /a kiloSize=%size:,=%

    rem 0�ȊO�̏ꍇ
    if not %kiloSize%==0 (
      rem �L���o�C�g�ŕϊ�
      set /a kiloSize=%kiloSize%/1024
    )

  rem ���ʕ\��
  echo %targetDirName%:%kiloSize%

  exit /b