@echo off
title %~nx0
echo �t�H���_�e�ʎ擾
: Windows�o�b�`�t�@�C�� �t�H���_�̗e�ʂ��ꗗ : �f�G�ȒU�߂���ɂȂ�I
: 	http://blog.livedoor.jp/shige19840901/archives/51692011.html
: byte�i�o�C�g�j���AKB��MB�Ɋ��Z�F�G�N�Z��(EXCEL)�֐�
: 	https://dw230.jp/f/019/


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"
  rem ���p�X�y�[�X��떄�߃o�b�`�̐�΃p�X�Ŏ擾
  call %call_DirFilePathInfo% "..\OwnLib\SpacePadding.bat" f
  set call_SpacePadding=%return_DirFilePathInfo%


: �錾
  rem ��떄�ߌ���
  set /a paddDigit=20

  rem �o�̓t�@�C����
  set fname= %~dp0sizelist.csv
  echo;
  echo �Ώۃt�H���_�p�X����

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������:"
  set targetDirPath=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetDirPath%"=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      goto :EOF
    )
  : �˂��ݕԂ�_�Ώۂ����݂��Ȃ��ꍇ
    if not exist "%targetDirPath%" (
      echo;
      echo �w��t�@�C�������݂��܂���
      echo �I�����܂�
      goto :EOF
    )


: ���s
  rem �J�����g�t�H���_�ύX
  pushd %targetDirPath%

  rem �S�t�H���_���[�v
  rem �T�C�Y�擾�T�u���[�`���g�p
  for /d %%d in (*) do call :GET_SIZE "%%d"


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

rem 32�r�b�g�ȏ�̐��l(-2147483648 ~ 2147483647)��ϐ��ɓ�����Ȃ�
  REM : �M�K�o�C�g�ϊ�
  REM   rem �J���}����
  REM   set /a kiloSize=%size:,=%
  REM   rem 0�ȊO�̏ꍇ
  REM   if not %kiloSize%==0 (
  REM     rem �L���o�C�g�ŕϊ�
  REM     set /a kiloSize=%kiloSize%/1024
  REM   )

  rem ���ʕ\��
  echo %targetDirName%:%size%

  exit /b