@echo off
title %~nx0
rem 時間秒変換バッチ
rem 引数01:秒数
rem 戻値01:返還後時刻


rem 変数ローカル化
SETLOCAL
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem 8進数数値変換バッチ
    set call_CngOctalNum=%~dp0"CngOctalNum.bat"
    rem ゼロ埋めバッチ
    set call_ZeroPadding=%~dp0"ZeroPadding.bat"

  : 引数
    rem 入力時刻
    set inpSec=%~1

  : 計算
    : 秒→分
      rem 分数算出
      set /a minute=%inpSec% / 60
      rem 端数秒
      rem (例:121秒
      rem     2分 = 121秒 / 60
      rem     1秒 = 121秒 - (60 * 2)
      set /a second=%inpSec% - %minute% * 60

    : 分→時
      rem 時間算出
      set /a hour=%minute% / 60
      set /a minute=%minute% - %hour% * 60

    : 返却値作成
      rem ゼロ埋めバッチ使用
      call %call_ZeroPadding% %hour% 2
      set hour=%return_ZeroPadding%
      call %call_ZeroPadding% %minute% 2
      set minute=%return_ZeroPadding%
      call %call_ZeroPadding% %second% 2
      set second=%return_ZeroPadding%

      rem 返却値作成
      set retTime="%hour%:%minute%:%second%"

rem 戻り値
ENDLOCAL && set return_SecToTime=%retTime%
exit /b