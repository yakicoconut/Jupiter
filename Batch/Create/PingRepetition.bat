@echo off
title %~nx0
echo ping�R�}���h�A�����s


: �Q�ƃo�b�`
  rem ���l�̂ݔN���������b�~���擾�o�b�`
  set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"


: �錾
  rem �Ώ�URL
  set targetUrl=yahoo.co.jp
  rem �J��Ԃ���(1/�b)
  set repetition=30


: ���O����
  rem ���l�̂ݔN���������b�~���擾�o�b�`�g�p
  call %call_GetStrDateTime%
  set datetime=%return_GetStrDateTime%

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
  ping -n %repetition% %targetUrl%>>%outFileName%


: ���㏈��
  rem �I�������擾
  set endTime=%date% %time%

  rem �o��
  echo;>>%outFileName%
  echo %endTime%>>%outFileName%