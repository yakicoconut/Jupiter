@echo off
title %~nx0
echo バックアップとしてミラーリングフォルダを作成する


: 変数
  rem 対象フォルダの上位フォルダ
  set sourceRoot01="C:\Users\p00486.PNET\Desktop\DeskTopTemp\_OTHERS - コピー"

  rem 個別対象フォルダ
  set sourceDir01="C:\Users\p00486.PNET\Desktop\DeskTopTemp\MSイベントセミナー_201704"
  set sourceDir02="C:\xampp\htdocs\_dev"
  set sourceDir03="E:\MyFiles-P00486\My-Doc\DOC_写真\エラー"
  rem for文の引数を使用してフォルダ名取得
  for %%a in (%sourceDir01%) do set sourceDirName01=%%~na
  for %%a in (%sourceDir02%) do set sourceDirName02=%%~na
  for %%a in (%sourceDir03%) do set sourceDirName03=%%~na
  rem →※※※下記「コピー先フォルダ名は要手動編集」注意※※※

  rem コピー先フォルダ
  set targetDir01="BackUp_Main"

  rem 個別対象フォルダを統括するフォルダ(メインのミラーリング時に除外するため)
  set exclusionDir="ETC"


: 事前処理
  rem 現行処理可視化ファイル名
  set process01=ミラーリング処理中01
  set process02=ミラーリング処理中02

  rem ログフォルダ作成
  if not exist Log (
    mkdir "Log"
  )


: ルートフォルダミラーリング
  rem 現行処理可視化ファイル出力
  echo 処理中>%process01%

  rem 対象ルートフォルダ内の全てのフォルダをロボコピー
  robocopy %sourceRoot01%    %targetDir01% /mir /xd %exclusionDir% /log:"Log\log01.log" /v
      echo %sourceRoot01% → %targetDir01% コピー完了

  rem 現行処理可視化ファイル削除
  del %process01%


: ルートフォルダ外ミラーリング
  rem 現行処理可視化ファイル出力
  echo 処理中>%process02%

  rem ログファイル初期化
  echo "">Log\log02.log

  rem *コピー先フォルダ名は要手動編集*
  robocopy "%sourceDir01%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName01%" /mir /log+:"Log\log02.log" /v
  REM robocopy "%sourceDir02%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName02%" /mir /log+:"Log\log02.log" /v
  REM robocopy "%sourceDir03%" "%targetDir01:"=%\%exclusionDir:"=%\%sourceDirName03%" /mir /log+:"Log\log02.log" /v

  rem 現行処理可視化ファイル削除
  del %process02%
