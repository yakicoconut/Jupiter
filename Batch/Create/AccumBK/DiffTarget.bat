@echo off
title %~nx0
echo �o�b�N�A�b�v�Ƃ��ă~���[�����O�t�H���_���쐬����


: �ϐ�
  rem �Ώۃt�H���_�̏�ʃt�H���_
  set sourceRoot01="C:\Users\p00486.PNET\Desktop\DeskTopTemp\_OTHERS - �R�s�["

  rem �ʑΏۃt�H���_
  set sourceDir01="C:\Users\p00486.PNET\Desktop\DeskTopTemp\MS�C�x���g�Z�~�i�[_201704"
  set sourceDir02="C:\xampp\htdocs\_dev"
  set sourceDir03="E:\MyFiles-P00486\My-Doc\DOC_�ʐ^\�G���["
  rem for���̈������g�p���ăt�H���_���擾
  for %%a in (%sourceDir01%) do set sourceDirName01=%%~na
  for %%a in (%sourceDir02%) do set sourceDirName02=%%~na
  for %%a in (%sourceDir03%) do set sourceDirName03=%%~na
  rem �����������L�u�R�s�[��t�H���_���͗v�蓮�ҏW�v���Ӂ�����

  rem �R�s�[��t�H���_
  set targetDir01="BackUp_Main"

  rem �ʑΏۃt�H���_�𓝊�����t�H���_(���C���̃~���[�����O���ɏ��O���邽��)
  set exclusionDir="ETC"


: ���O����
  rem ���s���������t�@�C����
  set process01=�~���[�����O������01
  set process02=�~���[�����O������02

  rem ���O�t�H���_�쐬
  if not exist Log (
    mkdir "Log"
  )


: ���[�g�t�H���_�~���[�����O
  rem ���s���������t�@�C���o��
  echo ������>%process01%

  rem �Ώۃ��[�g�t�H���_���̑S�Ẵt�H���_�����{�R�s�[
  robocopy %sourceRoot01%    %targetDir01% /mir /xd %exclusionDir% /log:"Log\log01.log" /v
      echo %sourceRoot01% �� %targetDir01% �R�s�[����

  rem ���s���������t�@�C���폜
  del %process01%


: ���[�g�t�H���_�O�~���[�����O
  rem ���s���������t�@�C���o��
  echo ������>%process02%

  rem ���O�t�@�C��������
  echo "">Log\log02.log

  rem *�R�s�[��t�H���_���͗v�蓮�ҏW*
  robocopy "%sourceDir01%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName01%" /mir /log+:"Log\log02.log" /v
  REM robocopy "%sourceDir02%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName02%" /mir /log+:"Log\log02.log" /v
  REM robocopy "%sourceDir03%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName03%" /mir /log+:"Log\log02.log" /v

  rem ���s���������t�@�C���폜
  del %process02%
