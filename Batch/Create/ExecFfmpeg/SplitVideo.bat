@echo off
title %~nx0
echo ffmpeg�œ��敪��
: ffmpeg �ŉ��̃{�����[���𒲐�����Bgain ���� - ����}�O�ŁI
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014
: ffmpeg�Ŗ��򉻃J�b�g - �]�݂��X���b�v�A�E�g
: 	http://iamapen.hatenablog.com/entry/2018/12/30/100811


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


  : �o�̓t�@�C����
    echo;
    echo �o�̓t�@�C��������(�v�g���q)
    rem ���[�U���̓o�b�`�g�p
    call %call_UserInput% "" TRUE STR
    rem ���͒l���p��
    set outPath=%return_UserInput1%


: �b���ϊ�
  rem �o�ߎ��Ԍv�Z�o�b�`�g�p
  call %call_ElapsedTime% %start:"=% %dist:"=%
  set elapsed=%return_ElapsedTime%

  : ���ڕ���
    rem ������Ƃ��ĕ���
    set   strHour=%elapsed:~0,2%
    set strMinute=%elapsed:~3,2%
    set strSecond=%elapsed:~6,2%

    rem �񌅖ڂ��u0�v�̏ꍇ
    if %strHour:~0,1%==0 (
      rem ���l�^�Ɋi�[����ƃG���[�ƂȂ邽�߁A�ꌅ�ڂ̂ݎ擾
      set strHour=%strHour:~1,1%
    )
    if %strMinute:~0,1%==0 (
      set strMinute=%strMinute:~1,1%
    )
    if %strSecond:~0,1%==0 (
      set strSecond=%strSecond:~1,1%
    )

    rem ���l�ϊ�
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

  rem �b���ϊ�
  set /a   secHour=%hour%*600
  set /a secMinute=%minute%*60
  set /a    length=%secHour%+%secMinute%+%second%


: ���s
  rem �������s
  : -y         :�㏑��
  : -ss        :�J�n�ʒu(�b)�A�u-i�v�I�v�V��������ɋL�q���Ȃ��Ɖ��Y������
  : -ss 0      :�؂���J�n�I�t�Z�b�g(�u�J�n�ʒu�v�Ɨ����w�肷��)
  : -i         :���t�@�C��
  : -t         :�Ώۊ���(�b)
  : -c:v copy  :�f�����ϊ�(����)
  : -c:a copy  :�������ϊ�(����)
  : -async ���l:�����T���v���� Stretch/Squeeze (�܂�T���v���̎������Ԃ�ύX) ���ē�������
  :             ���l(1~1000)�͉����Y�����Ƃ��ɂP�b�Ԃŉ��T���v���܂ŕύX���Ă��������w�肷��
  :             �u1�v�w��͓��ʂŁA�����̍ŏ������������Č㑱�̃T���v���͂��̂܂�
  ffmpeg\win32\ffmpeg.exe -y -ss %start% -ss 0 -i %sourcePath% -t %length% -c:v copy -c:a copy -async 1 %outPath%