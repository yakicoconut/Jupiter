@echo off
title %~nx0
echo ファイル名を指定して実行の履歴を追加
   : 「ファイル名を指定して実行」を極める - Qiita
   : 	https://qiita.com/sta/items/4b70e6b130a1033dc2c5


: 宣言
  rem レジストリパス
  set targetKey="HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\RunMRU"


: 実行
  : 現在の履歴を出力
    : rem /s:再帰的に検索
    : rem /v:値名を指定
    : reg query %targetKey% /s>C:\RUNMRULIST.txt

  : 履歴の削除
    : reg delete %targetKey% /v "a" /f
    : reg delete %targetKey% /v "b" /f
    : reg delete %targetKey% /v "c" /f
    : reg delete %targetKey% /v "d" /f
    : reg delete %targetKey% /v "e" /f
    : reg delete %targetKey% /v "f" /f
    : reg delete %targetKey% /v "g" /f
    : reg delete %targetKey% /v "h" /f
    : reg delete %targetKey% /v "i" /f
    : reg delete %targetKey% /v "j" /f
    : reg delete %targetKey% /v "k" /f
    : reg delete %targetKey% /v "l" /f
    : reg delete %targetKey% /v "m" /f
    : reg delete %targetKey% /v "n" /f
    : reg delete %targetKey% /v "o" /f
    : reg delete %targetKey% /v "p" /f
    : reg delete %targetKey% /v "q" /f
    : reg delete %targetKey% /v "r" /f
    : reg delete %targetKey% /v "s" /f
    : reg delete %targetKey% /v "t" /f
    : reg delete %targetKey% /v "u" /f
    : reg delete %targetKey% /v "v" /f
    : reg delete %targetKey% /v "w" /f
    : reg delete %targetKey% /v "x" /f
    : reg delete %targetKey% /v "y" /f
    : reg delete %targetKey% /v "z" /f
    : reg add %targetKey% /v "MRUList" /t REG_SZ /d "" /f

  : 履歴追加
    rem 使用頻度が多いショートカットの登録
    rem 対象パス末尾の「\1」は自動登録識別子?
    reg add %targetKey% /v "a" /t REG_SZ /d "ssms\1" /f
    reg add %targetKey% /v "b" /t REG_SZ /d "cmd\1" /f
    reg add %targetKey% /v "c" /t REG_SZ /d "control\1" /f
    reg add %targetKey% /v "d" /t REG_SZ /d "regedit\1" /f
    reg add %targetKey% /v "e" /t REG_SZ /d "appwiz.cpl\1" /f
    reg add %targetKey% /v "f" /t REG_SZ /d "devmgmt.msc\1" /f
    reg add %targetKey% /v "g" /t REG_SZ /d "eventvwr.msc\1" /f
    reg add %targetKey% /v "h" /t REG_SZ /d "explorer\1" /f
    reg add %targetKey% /v "i" /t REG_SZ /d "control admintools\1" /f
    reg add %targetKey% /v "j" /t REG_SZ /d "control netconnections\1" /f

    rem 追加した履歴の順番設定を追加(必須)
    reg add %targetKey% /v "MRUList" /t REG_SZ /d "abcdefghij" /f