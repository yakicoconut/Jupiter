@echo off
title %~nx0
echo 定期ファイル削除バッチ
echo タスクスケジューラ等で呼び出して使用する


: 削除処理
  rem Logフォルダ内で更新日付が90日以前の.logファイルを削除
  rem ※タスクスケジューラから呼び出す場合、絶対パスを使用する
  forfiles /p "D:\Log" /d -90 /s /m "*.log" /c "cmd /c del @file"