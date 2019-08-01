@echo off
title %~nx0
echo 現在時刻でファイル名書き換え
echo 引数存在:引数のみに適用
echo 引数なし:同階層全ファイルに適用


rem 変数ローカル化
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"
  rem 数値のみ年月日時分秒ミリ取得バッチ
  set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"


: 事前準備
  rem 自身のフォルダパス取得
  set currentDir=%~dp0

  rem 引数を取ったときはカレントディレクトリが引数の位置になるため
  rem カレントディレクトリを自身のフォルダに変更
  cd /d %currentDir%

  rem 上位フォルダパス取得
  rem ディレクトリファイル情報バッチ使用
  call %call_DirFilePathInfo% %currentDir:~0, -1% dp
  set oneOnTheDir=%return_DirFilePathInfo%


: 引数有無確認
  rem 引数がない場合
  if "%~1"=="" (
    rem 引数なし処理へ
    goto :NOARG
  )

  : 引数あり処理
    rem 引数格納
    set targetFile=%1

    rem ファイル名取得
    rem ディレクトリファイル情報バッチ使用
    call %call_DirFilePathInfo% %targetFile% nx
    set beforeFileName=%return_DirFilePathInfo%

    rem 拡張子取得
    rem ディレクトリファイル情報バッチ使用
    call %call_DirFilePathInfo% %targetFile% x
    set extension=%return_DirFilePathInfo%

    echo;
    rem 引数のファイルをカレントフォルダに移動
    move %targetFile% %currentDir%

    rem 数値のみ年月日時分秒ミリ取得バッチ使用
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%

    rem 変更後ファイル名作成
    set afterFileName=%datetime%%extension%

    rem リネーム
    ren "%beforeFileName%" %afterFileName%

    rem 上位フォルダ移動サブルーチン使用
    call :MOVTOONEONTHEDIR %afterFileName%

    exit


rem 引数なし処理
:NOARG
  rem 各ファイル名を取得し引数として使用
  dir %targetPath% /a-d /b>FILES.txt

  rem ファイルループ
  for /f "delims=" %%a in (FILES.txt) do (
    rem ループ対象(コピー対象ファイル名)を変数に格納
    set x=%%a

    rem メタファイル退避
    if "!x!" == "FILES.txt" (echo 処理中1) else (
      if "!x!" == "%~nx0"    (echo 処理中2) else (
        rem 拡張子取得
        rem ディレクトリファイル情報バッチ使用
        call %call_DirFilePathInfo% "!x!" x
        set extension=!return_DirFilePathInfo!

        rem 数値のみ年月日時分秒ミリ取得バッチ使用
        call %call_GetStrDateTime%
        set datetime=!return_GetStrDateTime!

        rem 変更後ファイル名作成
        set afterFileName=!datetime!!extension!

        rem リネーム
        ren "!x!" !afterFileName!

        rem 上位フォルダ移動サブルーチン使用
        call :MOVTOONEONTHEDIR !afterFileName!
      )
    )
  )

  del FILES.txt

  exit


rem 上位フォルダ移動サブルーチン
:MOVTOONEONTHEDIR
  echo;
  rem 対象ファイルを上位フォルダに移動
  move %currentDir%%afterFileName% %oneOnTheDir%

  rem サブルーチン終了
  exit /b