@echo off
title %~nx0
rem 少数計算バッチ
rem 引数01:左辺
rem 引数02:右辺
rem 戻値01:計算結果


rem 変数ローカル化
SETLOCAL ENABLEDELAYEDEXPANSION
  : 参照バッチ
    rem 小数点区切りバッチ
    set call_SepDecimal=%~dp0"..\OwnLib\SepDecimal.bat"
    rem 桁数取得バッチ
    set call_GetLen=%~dp0"..\OwnLib\GetLen.bat"
    rem ゼロ埋めバッチ
    set call_ZeroPadding=%~dp0"..\OwnLib\ZeroPadding.bat"

  : 引数
    set leftVal=%1
    set rightVal=%2

  : 事前準備
    : 左辺
      rem 小数点区切りバッチ使用
      call %call_SepDecimal% %leftVal%
      set leftInt=%return_SepDecimal01%
      set leftDec=%return_SepDecimal02%
      rem 小数点以下第一位が0の場合、便宜上、整数桁1を加える
      if %leftDec:~0,1%==0 set /a leftDec=1%leftDec%
      rem 桁数取得バッチ使用
      call %call_GetLen% %leftDec%
      set /a leftDecLen=%return_GetLen%
  
    : 右辺
      call %call_SepDecimal% %rightVal%
      set rightInt=%return_SepDecimal01%
      set rightDec=%return_SepDecimal02%
      if %rightDec:~0,1%==0 set /a rightDec=1%rightDec%
      call %call_GetLen% %rightDec%
      set /a rightDecLen=%return_GetLen%
  
    : 少数計算準備
      rem 元桁数変数を左辺の桁数で初期化
      set /a srcDecLen=%leftDecLen%
  
      rem 右辺少数桁>左辺少数桁の場合
      if %rightDecLen% gtr %leftDecLen% (
        rem 右辺の桁数を設定
        set /a srcDecLen=%rightDecLen%
      )

      rem ゼロ埋めバッチ使用(下駄モード)
      call %call_ZeroPadding% %leftDec% -%srcDecLen%
      set  leftDec=%return_ZeroPadding%
      call %call_ZeroPadding% %rightDec% -%srcDecLen%
      set  rightDec=%return_ZeroPadding%

echo %leftDec%
echo %rightDec%
pause
  : 計算
    rem 整数計算
    set /a integer = %leftInt% + %rightInt%
    rem 少数計算
    set /a decimal = %leftDec% + %rightDec%
  
    : 少数処理
      rem 桁数取得バッチ使用
      call %call_GetLen% %decimal%
      set /a resultDecimalLen=%return_GetLen%
  
      rem 少数計算結果の桁数が元の少数桁よりも大きい場合
      if %resultDecimalLen% gtr %srcDecLen% (
        rem 繰り上がり計算
        set /a integer = %integer% + 1
        rem 繰り上がった値を抜いた値(先頭が0の場合、エラーとなるため文字列で格納)
        set decimal=!decimal:~-%srcDecLen%!
      )
  
rem 戻り値
ENDLOCAL && set return_CalcDecimal=%integer%.%decimal%
exit /b