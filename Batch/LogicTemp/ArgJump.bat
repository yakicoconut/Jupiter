@echo off
title %~nx0
echo �����L������
echo ����������ꍇ�ƂȂ��ꍇ�œ��͂𕪊򂷂�


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


: �����L���m�F
  rem �������Ȃ��ꍇ
  if "%~1"=="" (
    rem ���[�U���͏�����
    goto :NOARG
  )

  rem ������ϐ��ɐݒ�
  set targetVar=%1

  rem ���s��
  goto :RUN


rem ���[�U���͏���
:NOARG
  : ���[�U����1
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �������Ȃ����ߓ��� TRUE STR
    rem ���͒l���p��
    set targetVar=%return_UserInput1%


rem ���s
:RUN
  echo;
  echo %targetVar%

  echo;
  pause