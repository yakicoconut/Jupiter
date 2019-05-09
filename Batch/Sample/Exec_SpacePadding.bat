@echo off
title %~nx0
echo 半角スペース後ろ埋めバッチの使用例


: 参照バッチ
  rem 半角スペース後ろ埋めバッチ
  set call_SpacePadding="..\OwnLib\SpacePadding.bat"


: 4桁パターン
  rem 半角スペース後ろ埋めバッチ使用
  call %call_SpacePadding% あいう 4
  echo %return_SpacePadding%:123


: 10桁パターン
  rem 半角スペース後ろ埋めバッチ使用
  call %call_SpacePadding% あいう 10
  echo %return_SpacePadding%:123


pause