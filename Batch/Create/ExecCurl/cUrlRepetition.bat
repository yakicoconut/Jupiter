@echo off
title %~nx0
echo curlコマンド連続実行


rem 遅延環境変数オン
setlocal ENABLEDELAYEDEXPANSION


: 宣言
  rem 対象URL
  set targetUrl=yahoo.co.jp
  rem 繰り返し回数
  set repetition=2


: 事前準備
  rem 年月日時分秒ミリ取得
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  rem ファイル名作成
  set outFileName=cUrlRepetition_%datetime%.txt

  rem 情報表示
  echo 対象:%targetUrl%
  echo 回数:%repetition%
  pause


: 実行
  set /a count=0
:BEGIN
  rem カウンタがマックスと同じになったら終了
  if %count% == %repetition% (
    exit

  ) else (
    rem curl実行サブルーチン使用
    call :EXECCURL

    rem 1秒間隔を開ける
    timeout 1

    rem カウンタに+1してラベルBEGINに戻る
    set /a count=!count!+1
    goto :BEGIN

  )


rem curl実行サブルーチン
:EXECCURL
  rem crul実行
  curl -Ik -w "HTTPCode=%%{http_code} TotalTime=%%{time_total}\n" %targetUrl%>>%outFileName%

  rem サブルーチン終了
  exit /b