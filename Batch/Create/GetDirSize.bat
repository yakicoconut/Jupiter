@echo off
title %~nx0
echo フォルダ容量取得
: Windowsバッチファイル フォルダの容量を一覧 : 素敵な旦那さんになる！
: 	http://blog.livedoor.jp/shige19840901/archives/51692011.html
: byte（バイト）を、KBやMBに換算：エクセル(EXCEL)関数
: 	https://dw230.jp/f/019/


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\OwnLib\DirFilePathInfo.bat"
  rem 半角スペース後ろ埋めバッチの絶対パスで取得
  call %call_DirFilePathInfo% "..\OwnLib\SpacePadding.bat" f
  set call_SpacePadding=%return_DirFilePathInfo%


: 宣言
  rem 後ろ埋め桁数
  set /a paddDigit=20

  rem 出力ファイル名
  set fname= %~dp0sizelist.csv
  echo;
  echo 対象フォルダパス入力

  rem 変数初期化
  set USR=

  set /P USR="入力してください:"
  set targetDirPath=%USR%
  : ねずみ返し_空白の場合
    if "%targetDirPath%"=="" (
      echo;
      echo 入力がありません
      echo 終了します
      goto :EOF
    )
  : ねずみ返し_対象が存在しない場合
    if not exist "%targetDirPath%" (
      echo;
      echo 指定ファイルが存在しません
      echo 終了します
      goto :EOF
    )


: 実行
  rem カレントフォルダ変更
  pushd %targetDirPath%

  rem 全フォルダループ
  rem サイズ取得サブルーチン使用
  for /d %%d in (*) do call :GET_SIZE "%%d"


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

rem 32ビット以上の数値(-2147483648 ~ 2147483647)を変数に入れられない
  REM : ギガバイト変換
  REM   rem カンマ抜き
  REM   set /a kiloSize=%size:,=%
  REM   rem 0以外の場合
  REM   if not %kiloSize%==0 (
  REM     rem キロバイトで変換
  REM     set /a kiloSize=%kiloSize%/1024
  REM   )

  rem 結果表示
  echo %targetDirName%:%size%

  exit /b