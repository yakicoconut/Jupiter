@echo off
title %~nx0
echo 7Zip実行バッチ
: インストールしないでzipや7z圧縮ファイルを作る方法 | 7-Zip
: 	https://sevenzip.osdn.jp/howto/non-install-compress.html
: コマンドでZIPや7zにパスワードを付ける | 7-Zip
: 	https://sevenzip.osdn.jp/howto/dos-command-password.html


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo=%~dp0"..\..\OwnLib\DirFilePathInfo.bat"
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==1 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:1
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set tgtPath=%return_UserInput1%

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH" %1
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set tgtPath=%1


rem 本処理
:RUN
  : コマンド実行
    for /f "usebackq delims=" %%a in (%tgtPath%) do (
      rem 圧縮処理サブルーチン使用
      call :COMP %%a
    )

pause
exit /b


rem 圧縮処理サブルーチン
:COMP
  : 引数引継ぎ
    rem 圧縮対象パス
    set zipTgt=%1
    rem パスワード
    set pass="%~2"

    rem パスワード指定がある場合、オプション設定
    rem 「-p」オプションとパスワードの間にスペースは入れない
    set isPass=""
    if "%pass:"=%"=="" ( set pass="") else ( set isPass="-p")

    rem 出力ファイル名称作成
    rem ディレクトリファイル情報バッチ使用_ファイル名取得
    call %call_DirFilePathInfo% %zipTgt% n
    set outName=%return_DirFilePathInfo%

  : 圧縮実行
    "%~dp07Zip\7za.exe" a %isPass:"=%%pass:"=% %~dp0%outName%.7z %zipTgt%

exit /b