@echo off
title %~nx0
echo テキストファイル指定文字列行取得
echo;
: テキストファイルを読み込んで
: 指定文字列が存在する行のみ出力する


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 参照バッチ
    rem 数値のみ年月日時分秒ミリ取得バッチ
    set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"
    rem 数値のみ年月日時分秒ミリ取得バッチ使用
    call %call_GetStrDateTime%
    set datetime=%return_GetStrDateTime%
    rem ユーザ入力バッチ
    set call_UserInput="..\OwnLib\UserInput.bat"


  : ユーザ入力
    rem 対象ファイル
    call %call_UserInput% 対象ファイル指定 TRUE PATH
    set tgtFile=%return_UserInput1%
    echo;

    rem 検証文字列開始位置
    call %call_UserInput% 検証文字列開始位置 TRUE NUM
    set startPoint=%return_UserInput1%
    echo;

    rem 文字数
    call %call_UserInput% 文字数 TRUE NUM
    set tgtLength=%return_UserInput1%
    echo;

    rem 指定文字列
    call %call_UserInput% 指定文字列 TRUE STR
    set tgtStr=%return_UserInput1%


  : 指定ファイルループ
    set /a counter=1
    for /f "usebackq delims=" %%a in (%tgtFile%) do (
      rem 対象一行
      set row=%%a
      rem 検証文字列取得
      set verifyStr=!row:~%startPoint:"=%,%tgtLength:"=%!

      rem 文字列検証
      if "!verifyStr!"==%tgtStr% (
        rem 行数と対象行出力
        echo !counter!:!row!>>%~nx0_%datetime%.txt
      )
      rem カウンタインクリメント
      set /a counter=!counter!+1
    )


  :END
    echo;
    echo 出力ファイル:%~nx0_%datetime%.txt
    pause
    exit