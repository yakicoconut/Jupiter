@echo off
title %~nx0
echo curl�R�}���h�A�����s


rem �x�����ϐ��I��
setlocal ENABLEDELAYEDEXPANSION


: �錾
  rem �Ώ�URL
  set targetUrl=yahoo.co.jp
  rem �J��Ԃ���
  set repetition=2


: ���O����
  rem �N���������b�~���擾
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  rem �t�@�C�����쐬
  set outFileName=cUrlRepetition_%datetime%.txt

  rem ���\��
  echo �Ώ�:%targetUrl%
  echo ��:%repetition%
  pause


: ���s
  set /a count=0
:BEGIN
  rem �J�E���^���}�b�N�X�Ɠ����ɂȂ�����I��
  if %count% == %repetition% (
    exit

  ) else (
    rem curl���s�T�u���[�`���g�p
    call :EXECCURL

    rem 1�b�Ԋu���J����
    timeout 1

    rem �J�E���^��+1���ă��x��BEGIN�ɖ߂�
    set /a count=!count!+1
    goto :BEGIN

  )


rem curl���s�T�u���[�`��
:EXECCURL
  rem crul���s
  curl -Ik -w "HTTPCode=%%{http_code} TotalTime=%%{time_total}\n" %targetUrl%>>%outFileName%

  rem �T�u���[�`���I��
  exit /b