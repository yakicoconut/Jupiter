@echo off
title %~nx0
rem 経過時間計算バッチ
rem 引数01:開始時刻
rem 引数02:終了時刻
rem 戻値:経過時間(文字列)


rem 変数ローカル化
SETLOCAL
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem ゼロ埋めバッチ
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"

  : 引数
    rem 開始時刻
    set startTime=%1
    set /a   startHour=%startTime:~0,2%
    set /a startMinute=%startTime:~3,2%
    set /a startSecond=%startTime:~6,2%
    set /a  startComma=%startTime:~9,2%

    rem 終了時刻
    set endTime=%2
    set /a   endHour=%endTime:~0,2%
    set /a endMinute=%endTime:~3,2%
    set /a endSecond=%endTime:~6,2%
    set /a  endComma=%endTime:~9,2%


  : 処理時間計算
    rem 単純計算
    set /a   elapsedHour=%endHour%   - %startHour%
    set /a elapsedMinute=%endMinute% - %startMinute%
    set /a elapsedSecond=%endSecond% - %startSecond%
    set /a  elapsedComma=%endComma%  - %startComma%

    rem 開始時間が終了時間を上回っている場合
    if %startHour%   gtr %endHour%   set /a   elapsedHour=24 - %startHour%   + %endHour%
    if %startMinute% gtr %endMinute% set /a elapsedMinute=60 - %startMinute% + %endMinute%
    if %startSecond% gtr %endSecond% set /a elapsedSecond=60 - %startSecond% + %endSecond%
    if %startComma%  gtr %endComma%  set /a  elapsedComma=60 - %startComma%  + %endComma%

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
    rem コンマ
    call %call_ZeroPadding% %elapsedComma% 2
    set elapsedComma=%return_ZeroPadding%

  : 結果
    rem 計算結果を時間表記にする
    set elapsedTime=%elapsedHour%:%elapsedMinute%:%elapsedSecond%.%elapsedComma%


rem 戻り値
ENDLOCAL && set return_ElapsedTime=%elapsedTime%
exit /b