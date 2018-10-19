@echo off
title %~nx0
echo WinMerge実行バッチ
: テキストファイルを二つ開き、
: 編集後に二つのファイルをWinMergeにかける


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: 比較用テキストファイル開く
  rem 表示順的に2から先に開く
  rem 比較2
  start .\MyResorce\Comp2.txt
  rem 比較1
  start .\MyResorce\Comp1.txt

  echo 比較ファイル保存後、WinMergeを実行します
  pause


: WinMerge実行
  start .\WinMerge2140\WinMergeU.exe .\MyResorce\Comp1.txt .\MyResorce\Comp2.txt
  exit