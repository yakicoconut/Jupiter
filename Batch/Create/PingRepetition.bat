@echo off
title %~nx0
echo ping�R�}���h�A�����s


: �錾
  rem �Ώ�URL
  set targetUrl=yahoo.co.jp
  rem �J��Ԃ���(1/�b)
  set repetition=30


: ���O����
  rem �N���������b�~���擾
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  set outFileName=PingRepetition_%datetime%.txt

  rem �J�n�����擾
  set startTime=%date% %time%
  rem �o��
  echo %startTime%>>%outFileName%

  echo �J�n:%startTime%
  echo �Ώ�:%targetUrl%
  echo ��:%repetition%

: ���s
  rem ping�A�����s
  ping  -n %repetition% %targetUrl%>>%outFileName%


: ���㏈��
  rem �I�������擾
  set endTime=%date% %time%

  rem �o��
  echo;>>%outFileName%
  echo %endTime%>>%outFileName%