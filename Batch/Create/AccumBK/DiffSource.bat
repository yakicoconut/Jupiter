@echo off
title %~nx0
echo 一括でバックアップと差分の抽出をする


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem 差分作成バッチ
  set call_DiffExtra_Create="DiffCreate.bat"
  rem ミラーリングバッチ
  set call_DiffExtra_Target="DiffTarget.bat"


: 変数
  rem 先ディレクトリ
  set targetDir01="BackUp_Main"
  set targetDir02="BackUp_Main_DiffSource"


: 事前処理
  rem 自身のフォルダパス取得
  set currentDir=%~dp0

  rem 現在日時の取得
  rem 本バッチでは使用しないが差分作成バッチで使用するグローバル変数
  set dateTime01=%date:/=%%time: =0%
  set dateTime01=%dateTime01::=%
  set dateTime01=%dateTime01:.=%
  set dateTime01=%dateTime01:~0,17%

  rem 現行処理可視化ファイル名
  set process03=差分取得処理01
  set process04=差分取得処理02
  set process05=差分取得処理03
  set process06=差分取得処理04


: 比較元(旧ファイル群)フォルダの作成
  rem 現行処理可視化ファイル出力
  echo 処理中>%process03%

  rem メインフォルダを比較元フォルダにミラーリング
  robocopy "%targetDir01%"  "%targetDir02%" /mir /log:"Log\log_diff01.log" /v
       echo %targetDir01% → %targetDir02% コピー完了

  rem 現行処理可視化ファイル削除
  del %process03%


: 比較先(新ファイル群)フォルダの作成
  rem 現行処理可視化ファイル出力
  echo 処理中>%process04%

  rem ミラーリングバッチの呼び出し
  call %call_DiffExtra_Target%

  rem 現行処理可視化ファイル削除
  del %process04%


: 差分情報抽出
  rem 現行処理可視化ファイル出力
  echo 処理中>%process05%

  rem 差分ファイル情報取得
  rem /l:ログのみ、/njh:ヘッダ除去、/njs:フッダ除去、/ns:サイズ除去、/fp:完全パス
  robocopy "%targetDir01%" "%targetDir02%" /mir /l /njh /njs /ns /fp>DIFFFILES.txt

  rem 現行処理可視化ファイル削除
  del %process05%


:差分作成
  rem 現行処理可視化ファイル出力
  echo 処理中>%process06%

  rem 差分作成バッチの呼び出し
  call %call_DiffExtra_Create%

  rem 現行処理可視化ファイル削除
  del %process06%