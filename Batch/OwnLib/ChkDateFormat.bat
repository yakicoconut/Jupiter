@echo off
title %~nx0
rem 日付書式判定バッチ
rem 引数01:対象値
rem 戻値1 :判定結果(0:日付でない、1:日付)
rem 戻値2 :該当フォーマット


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1


  : 実行
    rem 注意点
    : ・「echo %value%」とパイプの間はスペースを入れない

    rem 日付フラグ
    set isDate=0
    rem 返却用フォーマット変数
    set format=

    rem 「yyyy/mm/dd」
    echo %value%| findstr /r "^[0-9][0-9][0-9][0-9]/[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=yyyy/mm/dd
      goto :FLAGON
    )

    rem 「yy/mm/dd」
    echo %value%| findstr /r "^[0-9][0-9]/[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=yy/mm/dd
      goto :FLAGON
    )

    rem 「mm/dd」
    echo %value%| findstr /r "^[0-9][0-9]/[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=mm/dd
      goto :FLAGON
    )

    rem すべてエラーの場合、リターン
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem 日付フラグを立てる
    set isDate=1


  rem バッチ終了
  :RETURN
    rem 処理なし


rem 戻り値(2つ以上の場合、戻り値2以降の「&&」直前スペース注意)
ENDLOCAL && set return_ChkDateFormat1=%isDate%&& set return_ChkDateFormat2=%format%
exit /b