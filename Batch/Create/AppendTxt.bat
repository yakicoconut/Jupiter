@echo off
title %~nx0
echo 同フォルダ内のファイルを一つのテキストファイルにまとめる


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


: 出力ファイル名入力
  echo 出力ファイル名入力(要拡張子)
  rem ユーザ入力バッチ使用
  call %call_UserInput% "" TRUE STR
  rem 入力値引継ぎ
  set outptFileName=%return_UserInput1%


rem 対象ファイルパス入力
:INPUTTARGETFILEPATH
  echo;
  rem ユーザ入力バッチ使用
  call %call_UserInput% 対象ファイルパス入力 TRUE PATH
  rem 入力値引継ぎ
  set targetFilePath=%return_UserInput1%


: ファイル出力
  rem ファイル名出力
  echo ===============%targetFilePath:"=%===============>>%outptFileName%
  rem ファイル内容出力
  type %targetFilePath%>>%outptFileName%
  rem 改行出力
  echo;>>%outptFileName%

  rem 対象ファイルパス入力ラベルへ
  goto :INPUTTARGETFILEPATH