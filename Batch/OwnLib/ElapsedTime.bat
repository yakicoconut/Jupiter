@echo off
title %~nx0
rem 経過時間計算バッチ
rem 引数01:開始時刻
rem 引数02:終了時刻
rem 戻値:経過時間(文字列)


rem 変数ローカル化
SETLOCAL ENABLEDELAYEDEXPANSION
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem ゼロ埋めバッチ
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"
    rem 8進数数値変換バッチ
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem 時刻書式判定バッチ
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"
    rem 時分秒ミリ解体バッチ
    set call_DismantleTime=%~dp0"DismantleTime.bat"

  : 引数
    rem 開始時刻
    set startTime=%1
    rem 終了時刻
    set   endTime=%2

  : 時分秒ミリ解体
    : 開始
      rem 時刻書式判定バッチ使用
      call %call_ChkTimeFormat% %startTime%
      set startFormat=%return_ChkTimeFormat2%

      rem 時分秒ミリ解体バッチ使用
      call %call_DismantleTime% %startTime% %startFormat%
      set startTime=%return_DismantleTime1%
      set startMilli=%return_DismantleTime2%
      rem ミリ秒がない場合は0を設定
      if "%startMilli%"=="" set /a startMilli=0
      rem ミリ秒はゼロ下駄
      call %call_ZeroPadding% %startMilli% -3
      set startMilli=%return_ZeroPadding%

    : 終了
      call %call_ChkTimeFormat% %endTime%
      set endFormat=%return_ChkTimeFormat2%

      call %call_DismantleTime% %endTime% %endFormat%
      set endTime=%return_DismantleTime1%
      set endMilli=%return_DismantleTime2%
      if "%endMilli%"=="" set /a endMilli=0
      call %call_ZeroPadding% %endMilli% -3
      set endMilli=%return_ZeroPadding%

  : 8進数数値変換
    : 開始
      rem 8進数数値変換バッチ使用
      call %call_CngOctalNum% %startTime:~0,2%
      set /a startHour=%return_CngOctalNum%
      call %call_CngOctalNum% %startTime:~3,2%
      set /a startMinute=%return_CngOctalNum%
      call %call_CngOctalNum% %startTime:~6,2%
      set /a startSecond=%return_CngOctalNum%
      rem ミリ秒はゼロ埋めしないため対象外

    : 終了
      call %call_CngOctalNum% %endTime:~0,2%
      set /a endHour=%return_CngOctalNum%
      call %call_CngOctalNum% %endTime:~3,2%
      set /a endMinute=%return_CngOctalNum%
      call %call_CngOctalNum% %endTime:~6,2%
      set /a endSecond=%return_CngOctalNum%

  : 処理時間計算
    rem 単純計算
    set /a   elapsedHour=%endHour%   - %startHour%
    set /a elapsedMinute=%endMinute% - %startMinute%
    set /a elapsedSecond=%endSecond% - %startSecond%
    set /a  elapsedMilli=%endMilli%  - %startMilli%

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

      rem ミリ秒
      if %startMilli% gtr %endMilli% (
        rem ミリ秒は1000まで数える
        set /a elapsedMilli=1000 - %startMilli% + %endMilli%
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
    rem ミリ秒
    call %call_ZeroPadding% %elapsedMilli% 3
    set elapsedMilli=%return_ZeroPadding%

  : 結果
    rem ミリ秒が0でない場合、コンマをつけて変数化
    if not %elapsedMilli% == 0 set retElapsedMilli=.%elapsedMilli%

    rem 返却用変数作成
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%%retElapsedMilli%

rem 戻り値
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b