@echo off
title %~nx0
rem 経過時間計算バッチ
rem 引数01:開始時刻(「hh:mm:ss.ff」もしくは「hh:mm:ss」)
rem 引数02:終了時刻(「hh:mm:ss.ff」もしくは「hh:mm:ss」)
rem 戻値:経過時間(文字列)


rem 変数ローカル化
SETLOCAL ENABLEDELAYEDEXPANSION
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem ゼロ埋めバッチ
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"
    rem 8進数数値変換バッチ
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"

  : 引数
    rem 開始時刻
    set startTime=%1
    rem 終了時刻
    set   endTime=%2

  : コンマ秒有無判定
    set commaFlg=0
    rem 「hh:mm:ss.ff」
    echo %startTime%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    echo %endTime%| findstr /r "^[0-9][0-9]:[0-9][0-9]:[0-9][0-9].[0-9][0-9]$" >NUL
    if %ERRORLEVEL% equ 0 set commaFlg=1

  : 項目分割
    rem 開始時刻
    rem 8進数数値変換バッチ使用
    call %call_CngOctalNum% %startTime:~0,2%
    set /a startHour=%return_CngOctalNum%
    call %call_CngOctalNum% %startTime:~3,2%
    set /a startMinute=%return_CngOctalNum%
    call %call_CngOctalNum% %startTime:~6,2%
    set /a startSecond=%return_CngOctalNum%

    rem 終了時刻
    call %call_CngOctalNum% %endTime:~0,2%
    set /a endHour=%return_CngOctalNum%
    call %call_CngOctalNum% %endTime:~3,2%
    set /a endMinute=%return_CngOctalNum%
    call %call_CngOctalNum% %endTime:~6,2%
    set /a endSecond=%return_CngOctalNum%

    rem コンマ秒がある場合
    if %commaFlg%==1 (
      call %call_CngOctalNum% %startTime:~9,2%
      set /a startComma=!return_CngOctalNum!
      call %call_CngOctalNum% %endTime:~9,2%
      set /a endComma=!return_CngOctalNum!
    ) else (
      rem ない場合、「00」を設定
      set /a startComma=00
      set /a   endComma=00
    )

  : 処理時間計算
    rem 単純計算
    set /a   elapsedHour=%endHour%   - %startHour%
    set /a elapsedMinute=%endMinute% - %startMinute%
    set /a elapsedSecond=%endSecond% - %startSecond%
    set /a  elapsedComma=%endComma%  - %startComma%

    : 絶対値(開始時間 > 終了時間)処理
      rem 分
      if %startMinute% gtr %endMinute% (
        set /a elapsedMinute=60 - %startMinute% + %endMinute%
        rem 繰り下がり
        set /a elapsedHour=%elapsedHour%-1
        rem 「-1」の場合、「00」に訂正
        if !elapsedHour! == -1 set /a elapsedHour=00
      )

      rem 秒
      if %startSecond% gtr %endSecond% (
        set /a elapsedSecond=60 - %startSecond% + %endSecond%
        set /a elapsedMinute=!elapsedMinute!-1
        rem 「-1」の場合、「59」に訂正
        if !elapsedMinute! == -1 set /a elapsedMinute=59
      )

    rem コンマ秒
    if %startComma% gtr %endComma% (
      rem コンマ秒は100まで数える
      set /a elapsedComma=100 - %startComma% + %endComma%
      set /a elapsedSecond=!elapsedSecond!-1
      if !elapsedSecond! == -1 set /a elapsedSecond=59
    )

  : 文字列変換
    rem ゼロ埋めバッチ使用
    rem 時間
    call %call_ZeroPadding% %elapsedHour% 2
    set elapsedHour=%return_ZeroPadding%
    rem 分
    call %call_ZeroPadding% %elapsedMinute% 2
    set elapsedMinute=%return_ZeroPadding%
    rem 秒
    call %call_ZeroPadding% %elapsedSecond% 2
    set elapsedSecond=%return_ZeroPadding%
    rem コンマ秒
    call %call_ZeroPadding% %elapsedComma% 2
    set elapsedComma=%return_ZeroPadding%

  : 結果
    rem 計算結果を時間表記にする
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%
    rem コンマ秒がある場合
    if %commaFlg%==1 (
      set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%.%elapsedComma%
    )


rem 戻り値
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b