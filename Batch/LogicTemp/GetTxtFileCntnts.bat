@echo off
title %~nx0
echo �e�L�X�g�t�@�C�����e�擾


rem �x�����ϐ��I�t
SETLOCAL DISABLEDELAYEDEXPANSION


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


: �Ώۃt�@�C������
  echo;
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% �Ώۃt�@�C���w�� TRUE PATH
  rem ���͒l���p��
  set targetFile=%return_UserInput1%


: �w��t�@�C������
  rem �w�肵���t�@�C�����e�������Ƃ��Ďg�p
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem �������T�u���[�`���g�p
    call :EXEC_CMD %%a
  )


rem ���㏈��
:END
  echo;
  echo �t�@�C�����擾�����I��

  pause
  exit


rem �������T�u���[�`��
:EXEC_CMD
SETLOCAL
  : ����
    set var01=%1

  : �R�}���h���s
    echo %var01%

ENDLOCAL && set ret01=%var01%&& set ret02=abc
exit /b