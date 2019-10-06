@echo off
title %~nx0
rem 時刻書式判定バッチ
rem 引数01:対象値
rem 戻値1 :判定結果(0:時刻でない、1:時刻)
rem 戻値2 :該当フォーマット


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
    rem 返却用フォーマット変数
    set format=

    rem 「mm:ss」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=mm:ss
      goto :FLAGON
    )

    rem 「h:mm:ss」
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss
      goto :FLAGON
    )

    rem 「h:mm:ss.f」
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.f
      goto :FLAGON
    )

    rem 「h:mm:ss.ff」
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.ff
      goto :FLAGON
    )

    rem 「h:mm:ss.fff」
    echo %value%| findstr /r "^[0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=h:mm:ss.fff
      goto :FLAGON
    )

    rem 「hh:mm:ss」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss
      goto :FLAGON
    )

    rem 「hh:mm:ss.f」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.f
      goto :FLAGON
    )

    rem 「hh:mm:ss.ff」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.ff
      goto :FLAGON
    )

    rem 「hh:mm:ss.fff」
    echo %value%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 (
      set format=hh:mm:ss.fff
      goto :FLAGON
    )


    rem すべてエラーの場合、リターン
    if %ERRORLEVEL% equ 1 goto :RETURN


    :FLAGON
    rem 時刻フラグを立てる
    set isTime=1


  rem バッチ終了
  :RETURN
    rem 処理なし


rem 戻り値
ENDLOCAL && set return_ChkTimeFormat1=%isTime%&& set return_ChkTimeFormat2=%format%
exit /b