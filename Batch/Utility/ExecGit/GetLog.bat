@echo off
title %~nx0
echo 対象フォルダコミット履歴取得
: 詳細
:   --reverse       :
:   --pretty=oneline:
:   -- パス         :
: サイト
:   git logでコミットハッシュだけほしい - DRYな備忘録
:   	https://otiai10.hatenablog.com/entry/2016/06/15/072039
:   gitでコミットログを逆順（古い方から）表示する : git log first commit tail initial reverse ? GitHub
:   	https://gist.github.com/maeharin/4727153
:   git logのオプションと綺麗にツリー表示するためのエイリアス - Qiita
:   	https://qiita.com/hirotsugu_kawa/items/41afaafe477b877b5b73
:   git logを時間順にソートする ? DQNEO起業日記
:   	http://dqn.sakusakutto.jp/2014/10/git_log_date_order.html
:   git logコマンドまとめ - Qiita
:   	https://qiita.com/ma5aki-Y/items/2f5d57207bbd8a57b15e
:   git log の option 色々 - Qiita
:   	https://qiita.com/takayukioda/items/f1fa9e4c18c233b93e11
:   git logで特定ディレクトリのコミット履歴を閲覧する - Qiita
:   	https://qiita.com/devnokiyo/items/6444c92223aa7e83e93d


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 数値のみ年月日時分秒ミリ取得バッチ
  set call_GetStrDateTime="..\..\OwnLib\GetStrDateTime.bat"
  rem 数値のみ年月日時分秒ミリ取得バッチ使用
  call %call_GetStrDateTime%


: 引数引継ぎ
  rem 対象フォルダ
  set tgtDir="%~1"

  rem ねずみ返し_引数がない場合
  if "%~1"=="" (
    goto :USR_INPUT
  )
  goto :EXEC


:USR_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象フォルダパス入力 TRUE PATH
    rem 入力値引継ぎ
    set tgtDir=%return_UserInput1%


:EXEC
  rem ログ取得実行
  git log --reverse --pretty=oneline -- %tgtDir:"=%>%return_GetStrDateTime%.txt


pause
exit /b