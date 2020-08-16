@echo off
title %~nx0
echo メインブランチのGit Pushを実行する
: batファイルによるGitリモートリポジトリへのpush
: 	http://country-programmer.dfkp.info/2017/09/pushbybat/
: シェルスクリプトで現在のブランチ名を取得する（git rev-parse） - ペンギン村 Tech Blog
: 	http://blog.penginmura.tech/entry/2018/01/12/093400


: 事前準備
  rem 指定ブランチ名
  set targetBranch=master


: カレントブランチ名取得
  rem ブランチ名取得Gitコマンド作成
  set revParse=git rev-parse --abbrev-ref HEAD

  rem コマンド結果変数化
  for /f "usebackq delims=" %%a in (`%revParse%`) do set curBranch=%%a


: ブランチ判断
  if not %curBranch%==%targetBranch% (
    echo;
    echo カレントブランチが指定名と異なります
    echo   指定:%targetBranch%
    echo   現在:%curBranch%
    echo;
    echo プッシュは実行せず終了します

    pause
    exit
  )


: 実行
  echo;
  echo プッシュを実行します
  echo 対象ブランチ:%curBranch%

  echo;
  pause

  rem プッシュ実行
  echo;
  git push


pause