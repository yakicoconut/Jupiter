@echo off
title %~nx0
rem �����b�~����̃o�b�`
rem ����01:�Ώێ���
rem ����02:�Ώێ����t�H�[�}�b�g
rem �ߒl01:�����b
rem �ߒl02:�~���b


rem �ϐ����[�J����
SETLOCAL
  : ����
    rem ���͎���
    set inpTime=%~1
    rem �����t�H�[�}�b�g
    set format=%~2

    rem �˂��ݕԂ�_�t�H�[�}�b�g���w�肳��Ă��Ȃ�
    if "%format%"=="" (
      echo;
      echo �t�H�[�}�b�g���w�肳��Ă��܂���
      echo �I�����܂�
      pause
      exit
    )

  : �~���b�����݂���ꍇ
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-1,1%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-2,2%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-3,3%
    )

  : �擪�um�v�A�uh�v�A�uhh�v���f
    if %format:~0,2%==mm (
      set tms=00:%inpTime:~0,5%
    )
    if %format:~0,2%==h: (
      set tms=0%inpTime:~0,7%
    )
    if %format:~0,3%==hh: (
      rem �uhh�v�̏ꍇ���~���b�𔲂�
      set tms=%inpTime:~0,8%
    )


rem �߂�l
ENDLOCAL && set return_DismantleTime1=%tms%&& set return_DismantleTime2=%milli%
exit /b