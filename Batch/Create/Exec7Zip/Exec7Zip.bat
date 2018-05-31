@echo off
title %~nx0
echo 7Zip実行バッチ


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: 引数有無確認
  rem 引数がない場合
  if "%~1"=="" (
    rem ユーザ入力処理へ
    goto :NOARG
  )

  rem 引数が間違っている(ファイル/フォルダが存在しない)場合
  if not exist %1 (
    echo;
    echo 指定ファイル/フォルダが使用できません
    rem ユーザ入力処理へ
    goto :NOARG
  )

  rem 引数を変数に設定
  set targetPath=%1

  rem 拡張子判断へ
  goto :EXTENSIONDECISION


rem ユーザ入力処理
:NOARG
  echo;
  echo 圧縮、解凍を行うファイル/フォルダパスを入力してください

  rem 変数初期化
  set USR=""
  set /P USR="入力してください(文末\なし):"

  rem 「""」入力対策
  set targetPath=%USR:"=%
  set targetPath="%targetPath%"
  : ねずみ返し_空白の場合
    if %targetPath%=="" (
      echo;
      echo 入力がありません
      echo 終了します
      pause
      goto :EOF
    )
  : ねずみ返し_入力パスが無効の場合
    if not exist %targetPath% (
      echo;
      echo 入力パスが正しくありません
      goto :NOARG
    )


rem 拡張子判断
:EXTENSIONDECISION
  rem ディレクトリファイル情報バッチ使用_拡張子取得
  call %call_DirFilePathInfo% %targetPath% x
  set targetExtension=%return_DirFilePathInfo%

  rem 圧縮ファイルの場合
  if "%targetExtension%"==".7zip" (
    rem 解凍処理へ
    goto :THAWING
  )
  if "%targetExtension%"==".zip" (
    rem 解凍処理へ
    goto :THAWING
  )

  rem 圧縮ファイルでない場合
  rem 圧縮処理へ
  goto :COMPRESS


rem 解凍処理
:THAWING
  rem 引数がある場合
  if not "%~1"=="" (
    rem 引数を全て変数に設定
    set targetPath=%*
  )

  rem 7za.exeを使用して解凍を実行
  "%~dp07Zip\7za.exe" x -p%password% %targetPath%

  rem ねずみ返し_パスワード入力がない場合
  if not %ERRORLEVEL%==2 (
    echo;
    echo 解凍に成功しました
    pause
    goto :EOF
  )

  : 解凍パスワード入力処理
    echo;
    echo 解凍パスワードを入力してください
    : パスワード付きのファイルを解凍しようとすると自動でユーザ入力となるが
    : 入力内容がマスクされてしまうため入力処理を独自で用意

    rem 入力変数初期化
    set USR=
    set /P USR="入力してください:"

    set password=%USR%
    rem パスワードがある場合
    if not "%password%"=="" (
      rem 解凍処理をループ
      goto :THAWING
    )

  echo;
  echo 入力がありません
  echo 終了します
  pause
  goto :EOF


rem 圧縮処理
:COMPRESS

  rem ディレクトリファイル情報バッチ使用_ファイル/フォルダ名取得
  rem 変数に引数を全て格納する前に行う
  call %call_DirFilePathInfo% %targetPath% n
  set targetName=%return_DirFilePathInfo%

  rem 引数がある場合
  if not "%~1"=="" (
    rem 引数を全て変数に設定
    set targetPath=%*
  )

  : 圧縮パスワード入力処理
    echo;
    echo 圧縮パスワードを入力してください
    echo 設定しない場合は空白でエンター
    : 7Zipの-pオプションはパスワードをユーザ入力させる機能があるが
    : 空白で確定した場合、空白がパスワードになるため独自で用意

    rem パスワード使用オプション初期化
    set isPassword=
    rem 入力変数初期化
    set USR=
    set /P USR="入力してください:"

    set password=%USR%
    rem パスワードがある場合
    if not "%password%"=="" (
      rem パスワード使用オプションを設定
      set isPassword=-p
    )

  rem 7za.exeを使用して圧縮を実行
  "%~dp07Zip\7za.exe" a %isPassword%%password% "%~dp0%targetName%".7zip %targetPath%

  pause
  exit