@echo off
title %~nx0
echo �ŐV���l�t�@�C�����擾


rem �x�����ϐ��I��
SETLOCAL ENABLEDELAYEDEXPANSION


: �錾
  rem �w��g���q
  set exst=.html
  rem �R�s�[���ƃt�@�C��
  set copySource=_x.html


: �o�̓t�@�C�����쐬
  rem �w��g���q�̃t�@�C���������Ō�̂ݎ擾
  for /F "tokens=1* delims=" %%a in ('dir /b /o n *%exst%') do set fileName=%%a

  rem �g���q����
  set remExstName=!fileName:%exst%=!

  : �擪�u0�v�ޔ�
    rem �擪�ꕶ���擾
    set lead=%remExstName:~0,1%

    rem �u0�v�̏ꍇ
    if %lead%==0 (
      rem �ޔ�
      set evaZero=%lead%
      rem �擪�𔲂��������擾
      set /a remExstName=%remExstName:~1%
    )

    rem �o�̓t�@�C����(+1��������)
    set /a numOutFileName=%remExstName%+1

    rem �o�̓t�@�C�����쐬
    set outFileName=%evaZero%%numOutFileName%%exst%


: �R�s�[���s
  rem �t�@�C�����\��
  echo %fileName% �� %outFileName%

  rem �R�s�[���ƃt�@�C�����o�̓t�@�C�����ŃR�s�[
  copy %copySource% %outFileName%


pause