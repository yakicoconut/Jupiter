@echo off
title %~nx0
echo 桁数取得バッチの使用例


: 参照バッチ
  rem 桁数取得バッチ
  set call_GetLen="..\OwnLib\GetLen.bat"


: 数値
  rem 桁数取得バッチ使用
  call %call_GetLen% 1
  echo %return_GetLen%

: 半角英字
  rem 桁数取得バッチ使用
  call %call_GetLen% ab
  echo %return_GetLen%

: 全角
  rem 桁数取得バッチ使用
  call %call_GetLen% あいう
  echo %return_GetLen%

: 変数_ダブルクォートなし
  set var01=変数01
  rem 桁数取得バッチ使用
  call %call_GetLen% %var01%
  echo %return_GetLen%

: 変数_ダブルクォートあり
  set var02="変数02"
  rem 桁数取得バッチ使用
  call %call_GetLen% %var02%
  echo %return_GetLen%

pause