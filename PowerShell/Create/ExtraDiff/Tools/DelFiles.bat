@echo off
title %~nx0
echo �~���[�����O�t�H���_�̍폜�Ώۃt�@�C�����폜����


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �ϐ�
  rem �폜�Ώۃt�@�C���ꗗ�e�L�X�g
  set targetFile=DELTARGET.txt
  rem �˂��ݕԂ�_�t�@�C�������݂��Ȃ��ꍇ
  if not exist %targetFile% (
    echo;
    echo %targetFile%�t�@�C�������݂��܂���
    echo �I�����܂�
    pause
    exit
  )


: �폜�Ώۃt�@�C���ꗗ�e�L�X�g�̓��e���폜����
  for /f "delims=" %%a in (%targetFile%) do (
    rem �Ώۃt�@�C���p�X�̑��
    set targetPath=%~dp0%%a

    rem �Ώۂ����݂��邩�ŕ���(for��continue���Ȃ����߂˂��ݕԂ��ł��Ȃ�)
    if exist "!targetPath!" (
      rem �������u\�v�Ȃ�t�H���_
      if !targetPath:~-1!==\ (
        echo;
        echo %%a
        rem �Ώۃt�H���_�폜
        rd "!targetPath!" /s /q
      ) else (
        echo;
        echo %%a
        rem �Ώۃt�@�C���폜(�ʏ�t�@�C��)
        echo y | del "!targetPath!" /q

        rem �t�@�C�����폜����Ȃ������ꍇ
        if exist "!targetPath!" (
          echo;
          rem �B���t�@�C���폜
          echo y | del "!targetPath!" /q /ah
        )
      )
    )
  )