@echo off
title %~nx0
echo �A�v���N��
: �T�v
:   �[���z����g�p���ăA�v�����N������
: �ϐ�
:    target���l:�N���ΏۃA�v���p�X
:              :�uEND�v���`�����ϐ��܂ŃC���N�������g���Ď��s�����
:   argment���l:����
:     excDQ���l:�N������W�N�H�[�e�[�V�������쎡���邩�ǂ���
:              :����`�ȊO:����A����`:���Ȃ�


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION
  : �Ώېݒ�
    set   target1="C:\Windows\system32\cmd.exe"
    set   target2="C:\Windows\system32\cmd.exe /k"
    set  argment2="ipconfig"
    set    excDQ2=1

    rem �ŏI�v�f
    set target3=END


  rem �[���z����o�����x��
  set /a counter = 0
  :GET_ARRAY_ASC
    rem �J�E���^�C���N�������g
    set /a counter += 1

    : �z��擾
      rem �uset�v�́u)�v�̑O�܂ł��������邽�߃X�y�[�X�����Ȃ�
      rem �v�f�擾�A��̏ꍇ�͋󕶎��ݒ�
      if not "!target%counter%!"=="" ( set target=!target%counter%!) else ( set target="")
      rem W�N�H�[�g���O�t���O�擾
      if not "!excDQ%counter%!"=="" ( set excDQ=!excDQ%counter%!) else ( set excDQ="")
      rem �����擾
      set arg=!argment%counter%!

    : �˂��ݕԂ�
      rem �ŏI�v�f�̏ꍇ�A�I��
      if "%target:"=%"=="END" goto :END
      rem �v�f����̏ꍇ�A���[�v�p��
      if "%target:"=%"=="" goto :GET_ARRAY_ASC

    : �ΏۃA�v���N��
      rem WQ���O�t���O�I�t�̏ꍇ�A�ʏ���s
      if "%excDQ:"=%"=="" (
        START "" %target% %arg%
      ) else (
        START "" %target:"=% %arg:"=%
      )

      echo;
      echo %target:"=%
      Timeout 2

    rem ���x�����[�v
    goto :GET_ARRAY_ASC


  :END
    ENDLOCAL
    exit