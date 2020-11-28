@echo off
title %~nx0
rem 時間秒変換バッチ
rem 引数01:対象時刻
rem 戻値01:秒数合計
rem 戻値02:ミリ秒


rem 変数ローカル化
SETLOCAL
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem 8進数数値変換バッチ
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem 時刻書式判定バッチ
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"
    rem 時分秒ミリ解体バッチ
    set call_DismantleTime=%~dp0"DismantleTime.bat"

  : 引数
    rem 入力時刻
    set inpTime=%~1

    rem 時刻書式判定バッチ使用
    call %call_ChkTimeFormat% %inpTime%
    set fmt=%return_ChkTimeFormat2%

    rem 時分秒ミリ解体バッチ使用
    call %call_DismantleTime% %inpTime% %fmt%
    set tgtTime=%return_DismantleTime1%
    set tgtMilli=%return_DismantleTime2%
    rem ミリ秒がない場合は0を設定
    if "%tgtMilli%"=="" set /a tgtMilli=0

  : 8進数数値変換
    rem 8進数数値変換バッチ使用
    call %call_CngOctalNum% %tgtTime:~0,2%
    set /a hour=%return_CngOctalNum%
    call %call_CngOctalNum% %tgtTime:~3,2%
    set /a minute=%return_CngOctalNum%
    call %call_CngOctalNum% %tgtTime:~6,2%
    set /a second=%return_CngOctalNum%

  : 計算
    rem 時分→秒
    set /a secHour=%hour% * 3600
    set /a secMinute=%minute% * 60

    rem 秒数合計
    set /a retSec=%secHour% + %secMinute% + %second%

rem 戻り値
ENDLOCAL && set return_TimeToSec1=%retSec%&& set return_TimeToSec2=%tgtMilli%
exit /b