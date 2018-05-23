@echo off
title %~nx0
echo ディレクトリファイル情報バッチの使用例


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"

: 変数
  set myPath="C:\Program Files\Java\jre1.8.0_144\Welcome.html"

: 処理
  rem ディレクトリファイル情報バッチ使用
  call %call_DirFilePathInfo% %myPath% up 2
  echo %return_DirFilePathInfo%
pause