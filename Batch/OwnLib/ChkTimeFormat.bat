@echo off
title %~nx0
rem 時刻判定バッチ
rem 引数01:対象値
rem 戻値:判定結果(0:数値でない、1:数値)


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1


  : 実行
    rem 注意点
    : ・「echo %value%」とパイプの間はスペースを入れない
    :   「検索対象文字+スペース」となるため
    : ・バッチでは「{n, m}」は使用できない?

    rem 時刻フラグ
    set isTime=0

    REM rem 「m;s」
    REM echo %value%| findstr /r "^[0-9]:[0-9]$" >NUL
    REM rem エラーでなければフラグを立てる
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「mm;s」
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「m:ss」
    REM echo %value%| findstr /r "^[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem 「mm:ss」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「h:m;s」
    REM echo %value%| findstr /r "^[0-9]:[0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「h:mm;s」
    REM echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「h:m:ss」
    REM echo %value%| findstr /r "^[0-9]:[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem 「h:mm:ss」
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「hh:m;s」
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「hh:mm;s」
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    REM rem 「hh:m:ss」
    REM echo %value%| findstr /r "^[0-9][0-9]:[0-9]:[0-9][0-9]$" >NUL
    REM if %ERRORLEVEL% equ 0 goto :FLAGON

    rem 「hh:mm:ss」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 goto :FLAGON


    rem すべてエラーの場合、リターン
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem 時刻フラグを立てる
    set isTime=1


:RETURN
  rem 戻り値
  ENDLOCAL && set return_ChkTimeFormat=%isTime%
  exit /b