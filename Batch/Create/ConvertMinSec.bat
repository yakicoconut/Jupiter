@echo off
title %~nx0
echo �����b�ϊ�


rem �����̓��[�v
:INPUTMINUTE
  echo;
  echo ������
  set /P USR="���͂��Ă�������:"
  set targetSec=%USR%
  : �˂��ݕԂ�_�󔒂̏ꍇ
    if "%targetSec%"=="" (
     echo ���͂�����܂���
     echo �I�����܂�

     pause
     exit
    )

  : �����b�ϊ�
    rem ���͒l�𐔒l�ɕϊ�
    set /a calcSec=%targetSec%

    rem 60�b���|���ĕb���ɕϊ�
    set /a calcAnswer=%calcSec% * 60

    rem ���ʕ\��
    echo %calcSec% �� = %calcAnswer% �b

    rem �����̓��[�v�g�p
    goto :INPUTMINUTE