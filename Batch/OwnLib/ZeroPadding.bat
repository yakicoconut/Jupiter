@echo off
title %~nx0
rem ゼロ埋めバッチ
rem 引数01:対象値
rem 引数02:桁数
rem 戻値:ゼロ埋め後の値


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 引数
    rem 対象値
    set value=%1
    rem 桁数
    set pad=%2


  : 指定桁分の変数を作成
    set pad_num=
    for /L %%i in (1, 1, %pad%) do (
      set pad_num=0!pad_num!
    )

  : ゼロ埋め値作成
    rem 作成した桁数の0に対象値を結合
    set num=!pad_num!%value%
    rem 指定桁数分を後ろから取得
    set num=!num:~-%pad%!


rem 戻り値
ENDLOCAL && set return_ZeroPadding=%num%
exit /b