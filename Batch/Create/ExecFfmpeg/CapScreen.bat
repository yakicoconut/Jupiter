@echo off
title %~nx0
echo ffmpeg�ŉ摜�擾
: ffmpeg�œ��悩��Î~��𔲂��o�� - Qiita
: 	https://qiita.com/matoken/items/664e7a7e8f31e8a46a6:


: �Q�ƃo�b�`
  rem ���[�U���̓o�b�`
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem �o�ߎ��Ԍv�Z�o�b�`
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ���[�U���͏���
  : �Ώۃt�@�C���p�X
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% �Ώۃt�@�C���p�X���� TRUE PATH
    rem ���͒l���p��
    set sourcePath=%return_UserInput1%


  rem �J�n����
  :START
    echo;
    rem �o�b�`���Łu()�v���g�p�ł��Ȃ����߂����ŕ\��
    echo �J�n���ԓ���(hh:mm:ss)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

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


  rem ��������
  :LENGTH
    echo;
    echo �������ԓ���(hh:mm:ss)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE TIME
    rem ���͒l���p��
    set dist=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

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


  : 1�b�����艽��
    echo;
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% 1�b�����薇������ TRUE NUM
    rem ���͒l���p��
    set rate=%return_UserInput1%


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


: ���s
  rem �摜�擾���s
    : -i :����w��
    : -ss:�J�n�ʒu(�b)
    : -t :�Ώۊ���(�b)
    : -r :1�b�����艽�������o����
    :     fps(�t���[�����[�g)�̊m�F�́uffprobe.exe �Ώۓ���v
    : -f :�uimage2 %%06d.jpg�v�w��Łu000001.jpg�v����A�ԏo�͎w��
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -ss %start% -t %length% -r %rate% -f image2 %%06d.jpg