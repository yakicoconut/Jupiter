@echo off
title %~nx0
echo ffmpeg�œ��敪��


: �Q�ƃo�b�`
  rem �f�B���N�g���t�@�C�����o�b�`
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"
  rem ��������o�b�`�̐�΃p�X�擾
  call %call_DirFilePathInfo% "..\..\OwnLib\ChkTimeFormat.bat" f
  set call_ChkTimeFormat=%return_DirFilePathInfo%
  rem �o�ߎ��Ԍv�Z�o�b�`�̐�΃p�X�擾
  call %call_DirFilePathInfo% "..\..\OwnLib\ElapsedTime.bat" f
  set call_ElapsedTime=%return_DirFilePathInfo%


: ���[�U���͏���
  :FILE
    echo;
    echo �Ώۃt�@�C���w��

    rem �ϐ�������
    set USR=""
    set /P USR="���͂��Ă�������(����\�Ȃ�):"

    rem �u""�v���͑΍�
    set sourcePath=%USR:"=%
    set sourcePath="%sourcePath%"
    : �˂��ݕԂ�_�󔒂̏ꍇ
      if %sourcePath%=="" (
        echo;
        echo ���͂�����܂���
        echo �I�����܂�
        pause
        goto :EOF
      )
    : �˂��ݕԂ�_���̓p�X�������̏ꍇ
      if not exist %sourcePath% (
        echo;
        echo ���̓p�X������������܂���
        goto :FILE
      )


  :START
    echo;
    echo �J�n���Ԏw��

    rem �ϐ�������
    set USR=""
    set /P USR="���͂��Ă�������([hh:]mm:ss):"

    set start="%USR%"
    : �˂��ݕԂ�_�󔒂̏ꍇ
      if %start%=="" (
        echo;
        echo ���͂�����܂���
        echo �I�����܂�
        pause
        goto :EOF
      )
    : �˂��ݕԂ�_��������
      rem ��������o�b�`�g�p
      call %call_ChkTimeFormat% %start:"=%
      set isTimeFormat=%return_ChkTimeFormat1%
      set targetTimeFormat=%return_ChkTimeFormat2%
      rem �����t�H�[�}�b�g�ɉ����Ă��Ȃ��ꍇ
      if %isTimeFormat%==0 (
        echo;
        echo ���͂��ꂽ�l�������ł͂���܂���
        goto :START
      )

      rem �R���}�b�����͂���Ă���ꍇ
      if %targetTimeFormat%==hh:mm:ss.ff (
        echo;
        echo �R���}�b�͓��͂��Ȃ��ł�������
        goto :START
      )

      rem �uhh:mm:ss�v�ɕϊ�
      if %targetTimeFormat%==mm:ss (
        set start=00:%start%
      )
      if %targetTimeFormat%==h:mm:ss (
        set start=0:%start%
      )


  :LENGTH
    echo;
    echo �������Ԏw��

    rem �ϐ�������
    set USR=""
    set /P USR="���͂��Ă�������([hh:]mm:ss):"

    set dist="%USR%"
    : �˂��ݕԂ�_�󔒂̏ꍇ
      if %dist%=="" (
        echo;
        echo ���͂�����܂���
        echo �I�����܂�
        pause
        goto :EOF
      )
    : �˂��ݕԂ�_��������
      rem ��������o�b�`�g�p
      call %call_ChkTimeFormat% %dist:"=%
      set isTimeFormat=%return_ChkTimeFormat1%
      set targetTimeFormat=%return_ChkTimeFormat2%
      rem �����t�H�[�}�b�g�ɉ����Ă��Ȃ��ꍇ
      if %isTimeFormat%==0 (
        echo;
        echo ���͂��ꂽ�l�������ł͂���܂���
        goto :LENGTH
      )

      rem �R���}�b�����͂���Ă���ꍇ
      if %targetTimeFormat%==hh:mm:ss.ff (
        echo;
        echo �R���}�b�͓��͂��Ȃ��ł�������
        goto :LENGTH
      )

      rem �uhh:mm:ss�v�ɕϊ�
      if %targetTimeFormat%==mm:ss (
        set dist=00:%dist%
      )
      if %targetTimeFormat%==h:mm:ss (
        set dist=0:%dist%
      )

    : �b���ϊ�
      rem �o�ߎ��Ԍv�Z�o�b�`�g�p
      call %call_ElapsedTime% %start:"=% %dist:"=%
      set elapsed=%return_ElapsedTime%

      rem ���ڕ���
      set /a   hour=%elapsed:~0,2%
      set /a minute=%elapsed:~3,2%
      set /a second=%elapsed:~6,2%

      rem �b���ϊ�
      set /a   secHour=%hour%*600
      set /a secMinute=%minute%*60
      set /a    length=%secHour%+%secMinute%+%second%


  :OUTPATH
    echo;
    echo �o�̓t�@�C�����̎w��

    rem �ϐ�������
    set USR=""
    set /P USR="���͂��Ă�������(����\�Ȃ�):"

    set outPath="%USR%"
    : �˂��ݕԂ�_�󔒂̏ꍇ
      if %outPath%=="" (
        echo;
        echo ���͂�����܂���
        echo �I�����܂�
        pause
        goto :EOF
      )


: ���s
  rem �������s
  ffmpeg\ffmpeg.exe -y -ss %start% -i %sourcePath% -t %length% %outPath%