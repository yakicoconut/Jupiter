@echo off
echo 対象アプリを再起動する


: 変数
  rem アプリパス
  set appPath=D:\Calacala_StartFolder\CAL_Applications\りかなー\りかなー.exe
  rem プロセス名
  set processName=りかなー.exe


: 実行
  rem タスクキル
  taskkill /im %processName%

  echo アプリ起動
  start %appPath%