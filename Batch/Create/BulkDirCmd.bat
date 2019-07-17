@echo off
title %~nx0
echo 対象ディレクトリ内のファイル情報取得
echo ※対象フォルダ記述ファイルには絶対パスを箇条書きにする


rem 遅延環境変数オフ
SETLOCAL DISABLEDELAYEDEXPANSION


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


: 事前準備
  rem バッチ配置位置を退避
  set originDir=%cd%


: 対象ファイル入力
  echo;
  rem ユーザ入力バッチ使用
  call %call_UserInput% 対象フォルダ記述ファイル指定 TRUE PATH
  rem 入力値引継ぎ
  set targetFile=%return_UserInput1%


: 指定ファイル操作
  rem 指定したファイルを引数として使用
  for /f "usebackq delims=" %%a in (%targetFile%) do (
    rem ファイルリストサブルーチン使用
    rem 対象フォルダパスを引数に設定
    set x=%%a
    call :OUTPUTFILELIST
  )


rem 事後処理
:END
  echo;
  echo ファイル情報取得処理終了

  rem 作業用ファイル一覧の削除
  del %originDir%\FILES.txt

  pause
  exit


rem ファイルリスト出力サブルーチン
:OUTPUTFILELIST
  : 出力ファイルパス作成
    rem 一つ上のフォルダパス取得
    for %%a in (%x%) do set outPutFileName=%%~dpa
    rem 末尾の「\」マーク除去
    set outPutFileName=%outPutFileName:~0,-1%
    rem フォルダ名取得
    for %%a in (%outPutFileName%) do set outPutFileName=%%~na
    rem ファイル名作成
    set outPutFileName=%originDir%\bin_%outPutFileName%.txt

  : ルートフォルダファイル一覧取得
    rem カレントディレクトリを対象フォルダに変更
    cd /d %x%
    rem カレントディレクトリの表示
    echo;
    echo;
    cd
    rem 直下ファイル情報をバッチの位置に出力
    dir * >>%outPutFileName%

  : 対象ルートディレクトリ操作
    rem カレントディレクトリ内のファイル一覧を取得
    dir * /ad /b>FILES.txt

    rem 取得した一覧をバッチの位置に移動
    move FILES.txt %originDir% >nul

  : 対象子ディレクトリ操作
    rem 遅延環境変数オン
    SETLOCAL ENABLEDELAYEDEXPANSION

    echo;
    echo ファイル情報取得処理開始

    rem 取得したフォルダ名を引数として使用
    for /f "delims=" %%a in (%originDir%\FILES.txt) do (

      rem 除外フォルダの指定
      if "%%a" == "Log" (echo 処理中1) else (
        rem カレントディレクトリを処理中のフォルダに変更
        cd /d %x%\%%a

        rem カレントディレクトリの表示
        cd

        rem カレントディレクトリのファイル情報をバッチの位置に出力
        dir * /s>>%outPutFileName%
      )
    )

  rem サブルーチン引数初期化
  set x=
  rem サブルーチン終了
  exit /b