@echo off
title %~nx0
echo ���t�H���_���̃t�@�C������̃e�L�X�g�t�@�C���ɂ܂Ƃ߂�


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\OwnLib\UserInput.bat"


rem �o�̓t�@�C��������
:INPUTOUTPUTFILENAME
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% �o�̓t�@�C�������́��v�g���q FALSE STR
  if %return_UserInput2%==0 (
    echo;
    echo ���͂�����܂���
    echo �I�����܂�
    pause
    goto :EOF
  )
  rem ���͒n���p��
  set outptFileName=%return_UserInput1%


rem �Ώۃt�@�C���p�X����
:INPUTTARGETFILEPATH
  echo;
  echo �Ώۃt�@�C���p�X����
  rem ���[�U���̓o�b�`�g�p
  call %call_UserInput% �o�̓t�@�C������ύX����ꍇ�͋󔒂ŃG���^�[ FALSE STR
  if %return_UserInput2%==0 (
      echo;
      goto :INPUTOUTPUTFILENAME
  )
  rem ���͒n���p��
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