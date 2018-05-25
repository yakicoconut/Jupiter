@echo off
title %~nx0
echo 同フォルダ内のファイルを一つのテキストファイルにまとめる


rem 出力ファイル名入力
:INPUTOUTPUTFILENAME
  echo;
  echo 出力ファイル名入力

  rem 変数初期化
  set USR=

  set /P USR="入力してください:"
  set outptFileName=%USR%
  : ねずみ返し_空白の場合
    if "%outptFileName%"=="" (
      echo;
      echo 入力がありません
      echo 終了します
      goto :EOF
    )


rem 対象ファイルパス入力
:INPUTTARGETFILEPATH
  echo;
  echo 対象ファイルパス入力
  echo 出力ファイル名を変更する場合は空白でエンター

  rem 変数初期化
  set USR=

  set /P USR="入力してください:"
  set targetFilePath=%USR%
  : ねずみ返し_空白の場合
    if "%targetFilePath%"=="" (
      echo;

      goto :INPUTOUTPUTFILENAME
    )


: ファイル出力
  rem ファイル名出力
  echo ===============%targetFilePath%===============>>%outptFileName%
  rem ファイル内容出力
  type %targetFilePath%>>%outptFileName%
  rem 改行出力
  echo;>>%outptFileName%

  rem 対象ファイルパス入力ラベルへ
  goto :INPUTTARGETFILEPATH