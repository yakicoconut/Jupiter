@echo off
title %~nx0
echo �W���o�͕ϐ��i�[
: �W���o�͂̓��e��for���𗘗p����ƕϐ��Ɋi�[�\
: �o�b�` TIPS :: �R�}���h�v�����v�g | Refills
: 	https://syon.github.io/refills/rid/1498316/


: ���s
  rem ���ݎ����擾
  for /f "delims=" %%a in ('time /t') do set varTime=%%a
  echo;
  echo ----------------------------------
  echo %varTime%
  pause

  rem echo
  for /f "delims=" %%a in ('echo abc') do set varEcho=%%a
  echo;
  echo ----------------------------------
  echo %varEcho%
  pause

  rem dir�R�}���h
  echo;
  echo ----------------------------------
  for /f "delims=" %%a in ('dir') do (
    echo %%a
  )
  pause