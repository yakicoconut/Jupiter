@echo off
title %~nx0
echo ��t�H���_�̈ꊇ�폜


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �ϐ�
  rem ���I�ϐ��J�E���^�[
  set /a count=0


: �R�s�[�����[�g�t�H���_����
  echo;
  echo �폜�Ώۃ��[�g�t�H���_����͂��Ă�������

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������(����\�Ȃ�):"
  set targetRoot=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetRoot%"=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      goto :EOF
    )


: ���I�ϐ��쐬
  rem �Ώۃt�H���_���̃t�H���_��S�Ď擾
  dir "%targetRoot%" /ad /b /s>FOLDERS.txt

  rem ���I�ϐ��쐬���[�v
  rem set�R�}���h���̕ϐ����ɓ��I�Ȑ��l��t������
  for /f "delims=" %%a in (FOLDERS.txt) do (
    rem �J�E���g�𑝂₷
    set /a count+=1

    rem �t�@�C������擾�����s�𓮓I�ϐ��ɑ��
    set var_!count!=%%a
  )

  rem �J�E���^�[�̍ő�l���擾
  set /a totalCount=%count%


: �t�H���_�폜
  rem ���I�ϐ����o��
  rem dr�R�}���h�̓t�H���_���ɋ�t�H���_������ꍇ�A�폜�ł��Ȃ����߉��w�̃t�H���_����Ώۂɂ���
  :EXECDEL
    rem �˂��ݕԂ�_�J�E���^��0�Ȃ�I��
    if %count%==0 goto END

    echo !var_%count%!�̍폜
    echo �c�� !count!/!totalCount!
    rem �Ώۃt�H���_�̍폜
    rd "!var_%count%!"

    rem �J�E���^�����炷
    set /a count-=1

    goto EXECDEL


:END
  del FOLDERS.txt
  pause