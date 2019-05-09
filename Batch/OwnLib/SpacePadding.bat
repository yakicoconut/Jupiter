@echo off
title %~nx0
rem 半角スペース後ろ埋めバッチ
rem 引数01:対象値
rem 引数02:桁数
rem 戻値:半角スペース埋め後の値


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
      set pad_num= !pad_num!
    )

  : 半角スペース埋め値作成
    rem 対象値に作成した桁数の半角スペースを結合
    set str=%value%!pad_num!
    rem 指定桁数分を前から取得
    set str=!str:~0,%pad%!


rem 戻り値
ENDLOCAL && set return_SpacePadding=%str%
exit /b