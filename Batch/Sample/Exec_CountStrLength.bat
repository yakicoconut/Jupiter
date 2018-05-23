@echo off
title %~nx0
echo 文字数カウントバッチの使用例


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_CountStrLength="..\OwnLib\CountStrLength.bat"

: 変数
  set str="abcdefg"

: 処理
  rem ディレクトリファイル情報バッチ使用
  call %call_CountStrLength% %str%
  echo %return_CountStrLength%
pause