@echo off
title %~nx0
echo WinMerge実行バッチ
: テキストファイルを二つ開き、
: 編集後に二つのファイルをWinMergeにかける


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"


: 事前準備
  rem 比較1
  set comp1=.\MyResorce\Comp1.txt
  rem 比較2
  set comp2=.\MyResorce\Comp2.txt


: 比較用テキストファイル開く
  rem 表示順的に2から先に開く
  start %comp2%
  start %comp1%

  echo 比較ファイル保存後、WinMergeを実行します
  pause


: WinMerge実行
  start .\WinMerge2140\WinMergeU.exe %comp1% %comp2%
  exit