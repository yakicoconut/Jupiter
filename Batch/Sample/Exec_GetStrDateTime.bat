@echo off
title %~nx0
echo 数値のみ年月日時分秒ミリ取得バッチの使用例


: 参照バッチ
  rem 数値のみ年月日時分秒ミリ取得バッチ
  set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"


: 実行
  rem 数値のみ年月日時分秒ミリ取得バッチ使用
  call %call_GetStrDateTime%
  echo %return_GetStrDateTime%


pause