@echo off
title %~nx0
echo ���f�B���N�g�����t�H���_���k�o�b�`


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION

: ���k����
  for /f "usebackq delims=" %%a in (`dir /ad /b`) do (
    rem �Ώۃt�H���_
    set tgtDir="%%a"

    rem �u7Zip�v�t�H���_�łȂ��ꍇ
    if not !tgtDir!=="7Zip" (
      rem 7za.exe���g�p���Ĉ��k�����s
      "7Zip\7za.exe" a !tgtDir!.7z !tgtDir!
    )
  )
  pause