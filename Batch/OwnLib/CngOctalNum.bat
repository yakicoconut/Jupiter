@echo off
title %~nx0
rem 8進数数値変換バッチ
rem   DOSコマンドでは0埋めの数値は8進数として扱われるため、
rem   0埋めされている8と9はオーバーフローとなるので
rem   先頭の「0」を除去する
rem 引数01:対象値
rem 戻値:変換後数値文字列


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1

  : 実行
    rem 返却用数値
    set retNum="%value%"

    :LOOP
      : ねずみ返し_事後作業へ
        rem 対象値が空の場合
        if %retNum%=="" (
          rem すべて0のパターンのため「0」を設定
          set retNum="0"
          goto :END_BAT
        )
        rem 一文字目が0でない場合
        if not %retNum:~1,1%==0 ( goto :END_BAT )

      rem 二文字目以降ループ変数格納
      set retNum="%retNum:~2,-1%"
      goto :LOOP

  rem 事後作業
  :END_BAT
    rem Wクォート削除
    set retNum=%retNum:"=%

rem 戻り値
ENDLOCAL && set return_CngOctalNum=%retNum%
exit /b