@echo off
title %~nx0
echo Msinfo32�R�}���h���ʎ擾
echo ���t�@�C�����͔N����+�V���A���i���o�[
echo ���Ǘ��Ҏ��s���K�v�ȉ\������


: msinfo32���s
  rem �{�o�b�`�ʒu���擾
  set execDir=%~dp0
  rem ���t���擾
  set YYYYMMDD=%DATE:/=%

  rem IdentifyingNumber��2�s�ڎ擾
  for /f "tokens=2 usebackq delims=^:" %%i in (`wmic csproduct get IdentifyingNumber ^| findstr /n /r "." ^| findstr /r "^2:"`) do set serialNum=%%i

  rem �V���A���i���o�[�\��
  echo;
  echo �V���A���i���o�[:%serialNum%

  rem �g�����T�u���[�`���g�p
  set x=%serialNum%
  call :trim %x%
  rem �X�y�[�X�����݂���ꍇ�A�ŏ��̃X�y�[�X�܂ł���
  rem �t�@�C�����ɏo���Ȃ����߁u"�v�ł�����
  set serialNum="%x%"

  rem �t�@�C���o��
  echo �o�̓t�@�C����:msinfo32_%YYYYMMDD%_%serialNum%.txt
  msinfo32 /report %execDir%\msinfo32_%YYYYMMDD%_%serialNum%.txt

  pause
  exit


rem �g�����T�u���[�`��
:trim
  rem ���̃X�y�[�X������
  set x=%*

  exit /b