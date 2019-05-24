@echo off
title %~nx0
rem 丸括弧含有判定バッチ
rem 引数01:対象値
rem 戻値  :判定結果(0:丸括弧が含まれない、1:含まれる)


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1


  : 実行
    rem 判定結果
    set isInclude=0

    rem エラーレベル初期化(正常コマンド実行)
    cd >NUL

    rem 丸括弧が存在するかどうか
    echo %value% | find "(" >NUL
    rem エラーレベル判定サブルーチン使用
    call :CHK_ERR_LEVEL
    echo %value% | find ")" >NUL
    call :CHK_ERR_LEVEL


rem 戻り値
ENDLOCAL && set return_ChkIncParenthesis=%isInclude%
exit /b


rem エラーレベル判定サブルーチン
:CHK_ERR_LEVEL
  rem 0:存在する、1:存在しない
  if %ERRORLEVEL%==0 (
    set isInclude=1
  )
exit /b