@echo off
title %~nx0
echo �J�����g�f�B���N�g�����̂ݎ擾
echo �����K�V�B����
echo   ���u\OwnLib\DirFilePathInfo.bat�v�Ŏ���


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: ����
  rem �J�����g�t�H���_�p�X�擾
  set currentDirPath=%~dp0

  rem �J�����g�t�H���_���̂ݎ擾���[�v
  rem ���������擾�X�^�[�g�ʒu�ϐ�
  rem ����Ԍ��́u\�v�ƂȂ�̂œ񕶎��ڂ���͂��߂�
  set /a backStart = -2
  rem �t�H���_���������ϐ�
  set /a dirNamehLen = 0
  :YEN_POSITION
    rem ���������擾
    set last=!currentDirPath:~%backStart%,1!

    rem ���[�v�ϐ��v�Z
    set /a backStart -= 1
    set /a dirNamehLen += 1

    rem �u\�v�}�[�N�������ꍇ�A���[�v�I��
    if not "%last%"=="\" goto :YEN_POSITION

    rem ���[�v�ϐ�����
    set /a backStart += 2
    set /a dirNamehLen -= 1

  rem �J�����g�t�H���_���擾
  set currentDirName=!currentDirPath:~%backStart%,%dirNamehLen%!

  echo %currentDirName%
  pause