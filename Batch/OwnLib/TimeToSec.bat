@echo off
title %~nx0
rem 時間秒変換バッチ
rem 引数01:対象時刻
rem 戻値01:秒数合計


rem 変数ローカル化
SETLOCAL
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem 8進数数値変換バッチ
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"

  : 引数
    rem 入力時刻
    set inpTime=%~1

  : 8進数数値変換
    rem 8進数数値変換バッチ使用
    call %call_CngOctalNum% %inpTime:~0,2%
    set /a hour=%return_CngOctalNum%
    call %call_CngOctalNum% %inpTime:~3,2%
    set /a minute=%return_CngOctalNum%
    call %call_CngOctalNum% %inpTime:~6,2%
    set /a second=%return_CngOctalNum%

  : 計算
    rem 時分→秒
    set /a secHour=%hour% * 3600
    set /a secMinute=%minute% * 60

    rem 秒数合計
    set /a retSec=%secHour% + %secMinute% + %second%


rem 戻り値
ENDLOCAL && set return_TimeToSec=%retSec%
exit /b