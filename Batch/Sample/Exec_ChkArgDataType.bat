@echo off
title %~nx0
echo 引数型判定バッチの使用例


: 参照バッチ
  rem 引数型判定バッチ
  set call_ChkArgDataType="..\OwnLib\ChkArgDataType.bat"


: 成功パターン
  echo;
  echo =================
  echo 型指定:文字列
  echo 引数  :文字列
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "STR" ABC
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)
  
  echo;
  echo =================
  echo 型指定:数値
  echo 引数  :数値
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "NUM" 123
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:パス
  echo 引数  :パス
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "PATH" C:\
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:日付
  echo 引数  :日付
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "DATE" 2020/03/21
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:時刻
  echo 引数  :時刻
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "TIME" 21:22
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 日付 時刻
  echo 結果  :成功
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" DEF 234 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)


: 失敗パターン
echo;
  echo;
  echo =================
  echo 型指定:数値
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "NUM" DEF
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:パス
  echo 引数  :数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "PATH" 345
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:日付
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "DATE" GHI
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:時刻
  echo 引数  :パス
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "TIME" C:\
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値
  echo 引数  :文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR NUM" GHI
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列
  echo 引数  :文字列 数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR" JKL 456
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:数値   パス 日付 時刻 文字列
  echo 引数  :文字列 数値 パス 日付 時刻
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "NUM PATH DATE TIME STR" MNO 567 C:\ 2020/03/21 21:22
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 パス 日付 時刻 数値
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" PQR C:\ 2020/03/21 21:22 678
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 日付 時刻 パス
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" STU 789 2020/03/21 21:22 C:\
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 時刻 日付
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" VWX 890 C:\ 21:22 2020/03/21
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

  echo;
  echo =================
  echo 型指定:文字列 数値 パス 日付 時刻
  echo 引数  :文字列 数値 パス 日付 文字列
  echo 結果  :失敗
  echo -----------------
  call %call_ChkArgDataType% "STR NUM PATH DATE TIME" YZA 901 C:\ 2020/03/21 ZYX
  if %ret_ChkArgDataType1%==1 (echo 成功) else (echo 失敗)
  if not %ret_ChkArgDataType2%=="" (echo %ret_ChkArgDataType2%)

pause