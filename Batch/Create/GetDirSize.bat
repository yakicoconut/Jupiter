@echo off
title %~nx0
echo フォルダ容量取得
: Windowsバッチファイル フォルダの容量を一覧 : 素敵な旦那さんになる！
: 	http://blog.livedoor.jp/shige19840901/archives/51692011.html


: 参照バッチ
  rem 半角スペース後ろ埋めバッチ
  set call_SpacePadding="..\OwnLib\SpacePadding.bat"

pause
: 宣言
  REM rem 後ろ梅め桁数
  REM set /a paddDigit=20

  REM rem 出力ファイル名
  REM set fname= %~dp0sizelist.csv
  REM echo;
  REM echo 対象フォルダパス入力

  REM rem 変数初期化
  REM set USR=

  REM set /P USR="入力してください:"
  REM set targetDirPath=%USR%
  REM : ねずみ返し_空白の場合
  REM   if "%targetDirPath%"=="" (
  REM     echo;
  REM     echo 入力がありません
  REM     echo 終了します
  REM     goto :EOF
  REM   )
  REM : ねずみ返し_対象が存在しない場合
  REM   if not exist "%targetDirPath%" (
  REM     echo;
  REM     echo 指定ファイルが存在しません
  REM     echo 終了します
  REM     goto :EOF
  REM   )
set targetDirPath=E:\Etemp

: 実行
  rem カレントフォルダ変更
  pushd %targetDirPath%

  rem 全フォルダループ
  rem サイズ取得サブルーチン使用
  for /d %%d in (*) do call :GET_SIZE "%~dp0%%d"


: 事後作業
  echo;
  echo;
  pause
  exit


rem サイズ取得サブルーチン
  : 引数1:フォルダ名
:GET_SIZE
  rem 引数をdirコマンドで使用
  for /f "tokens=3 delims= " %%a in ('dir /s %1 ^| find "個のファイル"') do set size=%%a
  REM rem 取得したサイズを出力
  REM echo %1,"%size%">>%fname%

  rem 半角スペース埋めバッチ使用
  call %call_SpacePadding% %~1 %paddDigit%
  set targetDirName=%return_SpacePadding%

  : ギガバイト変換
    rem カンマ抜き
    set /a kiloSize=%size:,=%

    rem 0以外の場合
    if not %kiloSize%==0 (
      rem キロバイトで変換
      set /a kiloSize=%kiloSize%/1024
    )

  rem 結果表示
  echo %targetDirName%:%kiloSize%

  exit /b