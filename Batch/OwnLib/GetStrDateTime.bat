@echo off
title %~nx0
rem 数値のみ年月日時分秒ミリ取得バッチ
rem 戻値:数値のみ年月日時分秒ミリ


rem 変数ローカル化
SETLOCAL
  : 年月日時分秒ミリ取得
    rem 年月日時取得(「/」削除)
    set repDate=%date:/=%
    rem 時刻取得(一桁数値ゼロ埋め)
    set repTime=%time: =0%
    rem 「:」削除
    set repTime=%repTime::=%
    rem 「.」(ミリ秒コンマ)削除
    set repTime=%repTime:.=%


rem 戻り値
ENDLOCAL && set return_GetStrDateTime=%repDate%%repTime%
exit /b