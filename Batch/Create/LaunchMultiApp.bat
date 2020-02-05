@echo off
title %~nx0
echo アプリ起動
: 概要
:   擬似配列を使用してアプリを起動する
: 変数
:    target数値:起動対象アプリパス
:              :「END」を定義した変数までインクリメントして実行される
:   argment数値:引数
:     excDQ数値:起動時にWクォーテーションを作治するかどうか
:              :未定義以外:する、未定義:しない


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 対象設定
    set   target1="C:\Windows\system32\cmd.exe"
    set   target2="C:\Windows\system32\cmd.exe /k"
    set  argment2="ipconfig"
    set    excDQ2=1

    rem 最終要素
    set target3=END


  rem 擬似配列取り出しラベル
  set /a counter = 0
  :GET_ARRAY_ASC
    rem カウンタインクリメント
    set /a counter += 1

    : 配列取得
      rem 「set」は「)」の前までが代入されるためスペースを入れない
      rem 要素取得、空の場合は空文字設定
      if not "!target%counter%!"=="" ( set target=!target%counter%!) else ( set target="")
      rem Wクォート除外フラグ取得
      if not "!excDQ%counter%!"=="" ( set excDQ=!excDQ%counter%!) else ( set excDQ="")
      rem 引数取得
      set arg=!argment%counter%!

    : ねずみ返し
      rem 最終要素の場合、終了
      if "%target:"=%"=="END" goto :END
      rem 要素が空の場合、ループ継続
      if "%target:"=%"=="" goto :GET_ARRAY_ASC

    : 対象アプリ起動
      rem WQ除外フラグオフの場合、通常実行
      if "%excDQ:"=%"=="" (
        START "" %target% %arg%
      ) else (
        START "" %target:"=% %arg:"=%
      )

      echo;
      echo %target:"=%
      Timeout 2

    rem ラベルループ
    goto :GET_ARRAY_ASC


  :END
    ENDLOCAL
    exit