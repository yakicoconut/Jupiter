@echo off
title %~nx0
echo バックアップ処理
echo ※対象フォルダの二つ上のフォルダ名を使用する


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION


: 対象ファイル入力
  echo;
  echo 対象フォルダを記述したファイルを指定してください
  set /P USR="入力してください:"
  set targetFile=%USR%
  : ねずみ返し_ファイル存在確認
    if not exist %targetFile% (
      echo;
      echo ファイルが存在しません
      echo 終了します

      pause
      exit
    )

  rem 無効文字判定サブルーチン使用
  set y=%targetFile%
  call :INVALIDCHARA

  rem ダブルクォーテーション判断サブルーチン使用
  set y=%targetFile%
  call :WQUOTATIONDECSION
  set targetFile=%y%


: 指定ファイル操作
  rem 指定したファイルを引数として使用
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem バックアップ処理サブルーチン使用
    rem 対象フォルダパスを引数に設定
    set x=%%a
    call :EXECROBOCOPY
  )


rem 事後処理
:END
  echo;
  echo コピー処理終了

  pause
  exit


rem バックアップ処理サブルーチン
:EXECROBOCOPY
  : 出力ファイルパス作成
    rem 一つ上のフォルダパス取得
    for %%a in (%x%) do set outPutBaseFolderName=%%~dpa
    rem 末尾の「\」マーク除去
    set outPutBaseFolderName=%outPutBaseFolderName:~0,-1%
    rem フォルダ名取得
    for %%a in (%outPutBaseFolderName%) do set outPutBaseFolderName=%%~na
    rem 格納フォルダ名取得
    for %%a in (%x%) do set outPutFolderName=%%~na

  : ロボコピー
    rem ロボコピー実行
    rem オプション:全ての階層、Logフォルダ除外
    robocopy %x% %cd%\%outPutBaseFolderName%\%outPutFolderName% /mir /xd Log

  rem サブルーチン引数初期化
  set x=
  rem サブルーチン終了
  exit /b


rem 無効文字判定サブルーチン
:INVALIDCHARA
  rem エラーレベル初期化(正常コマンド実行)
  cd >NUL

  echo %y% | find "(" >NUL
  echo %y% | find ")" >NUL

  : エラーレベル判定
  :   0:存在する
  :   1:存在しない
  if %ERRORLEVEL% equ 0 (
    rem 無効文字表示サブルーチン使用
    rem 「()」内で「()」を使用した文言の表示が行えないため
    rem サブルーチンで対応
    call :ECHOINVALIDCHARA

    pause
    rem バッチ終了
    exit
  )

  rem サブルーチン引数初期化
  set y=
  rem エラーレベル初期化(正常コマンド実行)
  cd >NUL
  rem サブルーチン終了
  exit /b


rem 無効文字表示サブルーチン
:ECHOINVALIDCHARA
  echo;
  echo %y%
  echo;
  echo に無効な文字「(」、「)」等が含まれています
  echo 終了します

  rem サブルーチン終了
  exit /b


rem ダブルクォーテーション判断サブルーチン
:WQUOTATIONDECSION
  rem 一文字目が「"」でない場合
  rem If文のエスケープに「^」を使用
  if not ^%y:~0,1%==^" (
    rem 先頭にダブルクォートをつける
    set x="%y%
  )

  rem 末尾が「"」でない場合
  if not ^%y:~-1,1%==^" (
    rem 末尾にダブルクォートをつける
    set y=%y%"
  )

  rem サブルーチンを抜ける
  exit /b