@echo off
title %~nx0
echo �����^����o�b�`�̎g�p��


: �Q�ƃo�b�`
  rem �����^����o�b�`
  set call_ChkArgDataType="..\OwnLib\ChkArgDataType.bat"


: �����p�^�[��
  echo;
  echo =================
  echo �^�w��:������
  echo ����  :������
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "STR" ABC
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)
  
  echo;
  echo =================
  echo �^�w��:���l
  echo ����  :���l
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "NUM" 123
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:�p�X
  echo ����  :�p�X
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "PATH" C:\
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:���t
  echo ����  :���t
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "DATE" 2020/03/21
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:����
  echo ����  :����
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "TIME" 21:22
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���t ����
  echo ����  :����
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" DEF 234 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)


: ���s�p�^�[��
echo;
  echo;
  echo =================
  echo �^�w��:���l
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "NUM" DEF
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:�p�X
  echo ����  :���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "PATH" 345
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:���t
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "DATE" GHI
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:����
  echo ����  :�p�X
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "TIME" C:\
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l
  echo ����  :������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR NUM" GHI
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������
  echo ����  :������ ���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR" JKL 456
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:���l   �p�X ���t ���� ������
  echo ����  :������ ���l �p�X ���t ����
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "NUM PATH DATE TIME STR" MNO 567 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ �p�X ���t ���� ���l
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" PQR C:\ 2020/03/21 21:22 678
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l ���t ���� �p�X
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" STU 789 2020/03/21 21:22 C:\
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���� ���t
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" VWX 890 C:\ 21:22 2020/03/21
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo �^�w��:������ ���l �p�X ���t ����
  echo ����  :������ ���l �p�X ���t ������
  echo ����  :���s
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" YZA 901 C:\ 2020/03/21 ZYX
  if %ret_ChkArgDataType1%==1 (echo ����) else (echo ���s)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

pause