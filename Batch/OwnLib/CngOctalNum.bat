@echo off
title %~nx0
rem 8進数数値変換バッチ
rem   DOSコマンドでは0埋め二桁の数値は8進数として扱われる
rem   そのため、「08」と「09」はオーバーフローとなる
rem 引数01:対象値(二桁)
rem 戻値:変換後数値


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1


  : 実行
    rem 返却用数値
    set returnNumeric=%value%

    rem 「08」の場合
    if %value% == 08 (
      rem 「8」に変換
      set returnNumeric=8
    )

    rem 「09」の場合
    if %value% == 09 (
      rem 「9」に変換
      set returnNumeric=9
    )


rem 戻り値
ENDLOCAL && set return_CngOctalNum=%returnNumeric%
exit /b