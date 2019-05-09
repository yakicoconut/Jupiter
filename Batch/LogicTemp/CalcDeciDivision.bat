@echo off
title %~nx0
echo 少数算出除算
   : ・バッチでは浮動少数を扱えないため
   :   割り算の答えが少数となる場合、予め桁をずらして計算する
   : ・但し、返り値となる変数に少数を入れられないため文字列として返す


rem 少数計算サブルーチン使用
call :CALC_FLOAT 8 4 100

rem 結果表示
echo %return_CALC_FLOAT%
pause


rem 少数計算サブルーチン
  : 引数1:左辺
  : 引数2:右辺
  : 引数3:下駄数(10*nの結果で指定)
:CALC_FLOAT
  SETLOCAL
    : 引数格納
      set /a  left=%~1
      set /a right=%~2
      set /a digit=%~3
      rem 左辺は桁数をズラす
      set /a left=%left%*%digit%

    : 除算
    set /a answer=%left%/%right%
    rem 結果を少数に変換(文字列)
    set answer=0.%answer%

  rem 戻り値
  ENDLOCAL && set return_CALC_FLOAT=%answer%
  exit /b