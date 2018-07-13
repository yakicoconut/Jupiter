@echo off
title %~nx0
echo ネットステイト一覧表示


: 事前準備
  rem 自身のフォルダパス取得
  set currentDir=%~dp0
  rem 現在日時取得
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%


: netstatリスト出力
  echo;
  echo netstatリスト

  rem 出力
  netstat -aon>>%currentDir%\NETSTAT_%datetime%.txt

  pause