@echo off
title %~nx0
echo 引数型判定バッチの使用例


: 参照バッチ
  rem 引数型判定バッチ
  set call_ChkArgDataType="..\OwnLib\ChkArgDataType.bat"


: 設定
  rem カウンタ
  set /a counter=0

: 成功パターン
  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列
  echo 引数  :文字列
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 1 "STR" ABC
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:数値
  echo 引数  :数値
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 1 "NUM" 123
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:パス
  echo 引数  :パス
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 1 "PATH" C:\
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:日付
  echo 引数  :日付
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 1 "DATE" 2020/03/21
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:時刻
  echo 引数  :時刻
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 1 "TIME" 21:22
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 日付 時刻
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" DEF 234 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%


: 失敗パターン
echo;
  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:数値
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 1 "NUM" DEF
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:パス
  echo 引数  :数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 1 "PATH" 345
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:日付
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 1 "DATE" GHI
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:時刻
  echo 引数  :パス
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 1 "TIME" C:\
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 1 "STR NUM" GHI
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列
  echo 引数  :文字列 数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" JKL 456
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:数値   パス 日付 時刻 文字列
  echo 引数  :文字列 数値 パス 日付 時刻
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 5 "NUM PATH DATE TIME STR" MNO 567 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 パス 日付 時刻 数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" PQR C:\ 2020/03/21 21:22 678
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 日付 時刻 パス
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" STU 789 2020/03/21 21:22 C:\
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 時刻 日付
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" VWX 890 C:\ 21:22 2020/03/21
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 日付 文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% 5 "STR NUM PATH DATE TIME" YZA 901 C:\ 2020/03/21 ZYX
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列
  echo 引数  :文字列
  echo 結果  :失敗(指定引数が定義数と異なる)
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" あいう
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値
  echo 引数  :文字列 数値
  echo 結果  :失敗(指定引数が定義数と異なる)
  echo -----------------
  call %call_ChkArgDataType% 1 "STR NUM" えお 100
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列
  echo 引数  :文字列 数値
  echo 結果  :失敗(指定引数が定義数と異なる)
  echo -----------------
  call %call_ChkArgDataType% 3 "STR" かきく 101
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス
  echo 引数  :数値
  echo 結果  :失敗(指定引数が定義数と異なる)
  echo -----------------
  call %call_ChkArgDataType% 3 "STR NUM PATH" 102
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列 数値 パス
  echo 引数  :数値
  echo 結果  :失敗(指定引数が定義数と異なる)
  echo -----------------
  call %call_ChkArgDataType% 2 "STR" 102 23:26
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

  echo;
  echo =================
  call :PTN_COUNTER
  echo 型指定:文字列
  echo 引数  :なし
  echo 結果  :失敗(引数なし)
  echo -----------------
  call %call_ChkArgDataType% 1 "STR"
  if %ret_ChkArgDataType1%==0 (echo 引数なしは失敗扱い)
  if %ret_ChkArgDataType2%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType3%=="" (echo %ret_ChkArgDataType3%)
  echo 実引数数:%ret_ChkArgDataType1%

pause
exit

rem パターンカウンタ
:PTN_COUNTER
  set /a counter=%counter%+1
  echo パターン%counter%

  exit /b