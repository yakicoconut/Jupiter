@echo off
title %~nx0
echo 経過時間計算バッチの使用例


: 参照バッチ
  rem 経過時間計算バッチ
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: 実行時間パターン
  rem 処理前時刻取得
  set beforeTime=%time%
  rem 二文字目取得
  set hourColon=%beforeTime:~1,1%
  rem 二文字目が「:」(時間が一桁)の場合
  if %hourColon% == : (
    rem 0埋めする
    set beforeTime=0%beforeTime%
  )

  rem タイムアウト処理
  timeout 4

  rem 処理後時刻取得
  set afterTime=%time%
  set hourColon=%afterTime:~1,1%
  if %hourColon% == : (
    set afterTime=0%afterTime%
  )

  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime% - %afterTime% → %return_ElapsedTime%


: 差分計算_コンマ秒パターン
  rem 開始時刻
  set beforeTime=01:59:19.40

  rem 終了時刻
  set  afterTime=01:00:00.39

  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime% - %afterTime% → %return_ElapsedTime%


: 差分計算パターン
  rem 開始時刻
  set beforeTime=00:13:30

  rem 終了時刻
  set  afterTime=00:14:00

  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo %beforeTime%    - %afterTime%    → %return_ElapsedTime%


pause