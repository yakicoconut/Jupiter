@echo off
title %~nx0
echo pingコマンド連続実行


: 宣言
  rem 対象URL
  set targetUrl=yahoo.co.jp
  rem 繰り返し回数(1/秒)
  set repetition=30


: 事前準備
  rem 年月日時分秒ミリ取得
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  set outFileName=PingRepetition_%datetime%.txt

  rem 開始時刻取得
  set startTime=%date% %time%
  rem 出力
  echo %startTime%>>%outFileName%

  echo 開始:%startTime%
  echo 対象:%targetUrl%
  echo 回数:%repetition%

: 実行
  rem ping連続実行
  ping  -n %repetition% %targetUrl%>>%outFileName%


: 事後処理
  rem 終了時刻取得
  set endTime=%date% %time%

  rem 出力
  echo;>>%outFileName%
  echo %endTime%>>%outFileName%