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
    rem 時間秒変換バッチ
    set call_TimeToSec=%~dp0"..\OwnLib\TimeToSec.bat"
    rem 秒時間変換バッチ
    set call_SecToTime="..\OwnLib\SecToTime.bat"

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
      rem 時間秒変換バッチ使用
      call %call_TimeToSec% %startTime%
      set startSec=%return_TimeToSec%
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
      call %call_TimeToSec% %endTime%
      set endSec=%return_TimeToSec%
      if "%endMilli%"=="" set /a endMilli=0
      call %call_ZeroPadding% %endMilli% -3
      set endMilli=%return_ZeroPadding%

  : 8進数数値変換
    : 開始
      rem 8進数数値変換バッチ使用
      call %call_CngOctalNum% %startMilli%
      set /a startMilli=%return_CngOctalNum%
    : 終了
      call %call_CngOctalNum% %endMilli%
      set /a endMilli=%return_CngOctalNum%

  : 処理時間計算
    rem 単純計算
    set /a elapsedSec=%endSec% - %startSec%
    set /a elapsedMilli=%endMilli% - %startMilli%

    : 絶対値(開始時間 > 終了時間)処理
      rem ミリ秒
      if %elapsedMilli:~0,1%==- (
        rem ミリ秒は1000まで数えるため
        rem 1000ミリ秒にマイナスを足す
        set /a elapsedMilli=1000 + %elapsedMilli%
        set /a elapsedSec=%elapsedSec%-1
      )

    rem ミリ秒は3桁パッド
    call %call_ZeroPadding% %elapsedMilli% 3
    set elapsedMilli=%return_ZeroPadding%

  : 結果
    rem 秒時間変換バッチ使用
    call %call_SecToTime% %elapsedSec%
    set elapsedTime=%return_SecToTime:"=%

    rem ミリ秒が0でない場合、コンマをつけて変数化
    if not %elapsedMilli% == 0 set retElapsedMilli=.%elapsedMilli%

    rem 返却用変数作成
    set elapsedTime=%elapsedTime%%retElapsedMilli%

rem 戻り値
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b