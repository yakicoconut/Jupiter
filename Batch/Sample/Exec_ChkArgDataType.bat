@echo off
title %~nx0
echo �����^����o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����^����o�b�`
  set call_ChkArgDataType="..\OwnLib\ChkArgDataType.bat"


: �ݒ�
  rem �J�E���^
  set /a counter=0

: �����p�^�[��
  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������
  echo ����  :������
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 1 "STR" ABC
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:���l
  echo ����  :���l
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 1 "NUM" 123
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:�p�X
  echo ����  :�p�X
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 1 "PATH" C:\
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:���t
  echo ����  :���t
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 1 "DATE" 2020/03/21
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:����
  echo ����  :����
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 1 "TIME" 21:22
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���t ����
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" DEF 234 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%


: ���s�p�^�[��
echo;
  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:���l
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 1 "NUM" DEF
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:�p�X
  echo ����  :���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 1 "PATH" 345
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:���t
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 1 "DATE" GHI
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:����
  echo ����  :�p�X
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 1 "TIME" C:\
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 1 "STR NUM" GHI
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������
  echo ����  :������ ���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" JKL 456
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:���l   �p�X ���t ���� ������
  echo ����  :������ ���l �p�X ���t ����
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 5 "NUM PATH DATE TIME STR" MNO 567 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ �p�X ���t ���� ���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" PQR C:\ 2020/03/21 21:22 678
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l ���t ���� �p�X
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" STU 789 2020/03/21 21:22 C:\
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���� ���t
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" VWX 890 C:\ 21:22 2020/03/21
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���t ������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" YZA 901 C:\ 2020/03/21 ZYX
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������
  echo ����  :������
  echo ����  :���s(�w���������`���ƈقȂ�)
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" ������
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l
  echo ����  :������ ���l
  echo ����  :���s(�w���������`���ƈقȂ�)
  echo -----------------
  call %call_ChkArgDataType% 1 "STR NUM" ���� 100
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������
  echo ����  :������ ���l
  echo ����  :���s(�w���������`���ƈقȂ�)
  echo -----------------
  call %call_ChkArgDataType% 3 "STR" ������ 101
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X
  echo ����  :���l
  echo ����  :���s(�w���������`���ƈقȂ�)
  echo -----------------
  call %call_ChkArgDataType% 3 "STR NUM PATH" 102
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������ ���l �p�X
  echo ����  :���l
  echo ����  :���s(�w���������`���ƈقȂ�)
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" 102 23:26
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo �^�w��:������
  echo ����  :�Ȃ�
  echo ����  :���s(�����Ȃ�)
  echo -----------------
  call %call_ChkArgDataType% 1 "STR"
  if %ret_ChkArgDataType1%==0 (echo �����Ȃ��͎��s����)
  if %ret_ChkArgDataType2%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo ��������:%ret_ChkArgDataType1%

pause
exit

rem �p�^�[���J�E���^
:PTN_COUNTER
  set /a counter=%counter%+1
  echo �p�^�[��%counter%

  exit /b