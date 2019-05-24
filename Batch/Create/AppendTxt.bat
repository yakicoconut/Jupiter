@echo off
title %~nx0
echo 同フォルダ内のファイルを一つのテキストファイルにまとめる


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


rem 出力ファイル名入力
:INPUTOUTPUTFILENAME
  rem ユーザ入力バッチ使用
  call %call_UserInput% 出力ファイル名入力※要拡張子 FALSE STR
  if %return_UserInput2%==0 (
    echo;
    echo 入力がありません
    echo 終了します
    pause
    goto :EOF
  )
  rem 入力地引継ぎ
  set outptFileName=%return_UserInput1%


rem 対象ファイルパス入力
:INPUTTARGETFILEPATH
  echo;
  echo 対象ファイルパス入力
  rem ユーザ入力バッチ使用
  call %call_UserInput% 出力ファイル名を変更する場合は空白でエンター FALSE STR
  if %return_UserInput2%==0 (
      echo;
      goto :INPUTOUTPUTFILENAME
  )
  rem 入力地引継ぎ
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