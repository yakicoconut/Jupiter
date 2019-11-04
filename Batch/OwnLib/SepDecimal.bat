@echo off
title %~nx0
rem 小数点区切りバッチ
rem 引数01:対象値
rem 戻値01:整数部分
rem 戻値02:少数部分


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1

  : 「.」で区切る
    rem ※in内の「"」は必須(「.」があるとファイルと認識されてしまうため)
    for /f "tokens=1,2 delims=." %%i in ("%value%") do (
      set integer=%%i
      set decimal=%%j
    )


rem 戻り値
ENDLOCAL && set return_SepDecimal01=%integer%&& set return_SepDecimal02=%decimal%
exit /b