@echo off
title %~nx0
echo ���t�H���_���̃t�@�C������̃e�L�X�g�t�@�C���ɂ܂Ƃ߂�


rem �o�̓t�@�C��������
:INPUTOUTPUTFILENAME
  echo;
  echo �o�̓t�@�C��������

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������:"
  set outptFileName=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%outptFileName%"=="" (
      echo;
      echo ���͂�����܂���
      echo �I�����܂�
      goto :EOF
    )


rem �Ώۃt�@�C���p�X����
:INPUTTARGETFILEPATH
  echo;
  echo �Ώۃt�@�C���p�X����
  echo �o�̓t�@�C������ύX����ꍇ�͋󔒂ŃG���^�[

  rem �ϐ�������
  set USR=

  set /P USR="���͂��Ă�������:"
  set targetFilePath=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetFilePath%"=="" (
      echo;

      goto :INPUTOUTPUTFILENAME
    )


: �t�@�C���o��
  rem �t�@�C�����o��
  echo ===============%targetFilePath%===============>>%outptFileName%
  rem �t�@�C�����e�o��
  type %targetFilePath%>>%outptFileName%
  rem ���s�o��
  echo;>>%outptFileName%

  rem �Ώۃt�@�C���p�X���̓��x����
  goto :INPUTTARGETFILEPATH