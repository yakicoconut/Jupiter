@echo off
title %~nx0
echo ���t�H���_���̃t�@�C������̃e�L�X�g�t�@�C���ɂ܂Ƃ߂�


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


: �o�̓t�@�C��������
  echo �o�̓t�@�C��������(�v�g���q)
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% "" TRUE STR
  rem ���͒l���p��
  set outptFileName=%return_UserInput1%


rem �Ώۃt�@�C���p�X����
:INPUTTARGETFILEPATH
  echo;
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
  rem ���͒l���p��
  set targetFilePath=%return_UserInput1%


: �t�@�C���o��
  rem �t�@�C�����o��
  echo ===============%targetFilePath:"=%===============>>%outptFileName%
  rem �t�@�C�����e�o��
  type %targetFilePath%>>%outptFileName%
  rem ���s�o��
  echo;>>%outptFileName%

  rem �Ώۃt�@�C���p�X���̓��x����
  goto :INPUTTARGETFILEPATH