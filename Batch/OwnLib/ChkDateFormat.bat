@echo off
title %~nx0
rem ���t��������o�b�`
rem ����01:�Ώےl
rem �ߒl1 :���茋��(0:���t�łȂ��A1:���t)
rem �ߒl2 :�Y���t�H�[�}�b�g


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem �Ώےl
    set value=%1


  : ���s
    rem ���ӓ_
    : �E�uecho %value%�v�ƃp�C�v�̊Ԃ̓X�y�[�X�����Ȃ�

    rem ���t�t���O
    set isDate=0
    rem �ԋp�p�t�H�[�}�b�g�ϐ�
    set format=

    rem �uyyyy/mm/dd�v
    echo %value%| findstr /r "^[0-9][0-9][0-9][0-9]/[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=yyyy/mm/dd
      goto :FLAGON
    )

    rem �uyy/mm/dd�v
    echo %value%| findstr /r "^[0-9][0-9]/[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=yy/mm/dd
      goto :FLAGON
    )

    rem �umm/dd�v
    echo %value%| findstr /r "^[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=mm/dd
      goto :FLAGON
    )

    rem ���ׂăG���[�̏ꍇ�A���^�[��
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem ���t�t���O�𗧂Ă�
    set isDate=1


  rem �o�b�`�I��
  :RETURN
    rem �����Ȃ�


rem �߂�l(2�ȏ�̏ꍇ�A�߂�l2�ȍ~�́u&&�v���O�X�y�[�X����)
ENDLOCAL && set return_ChkDateFormat1=%isDate%&& set return_ChkDateFormat2=%format%
exit /b