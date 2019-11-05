@echo off
title %~nx0
rem ゼロ末尾削除バッチ
rem 引数01:対象値
rem 戻値  :削除後値


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1

  rem 末尾削除ループ
  :DEL_ZERO_END
    rem ねずみ返し_値がない場合(0のみを考慮)
    if "%value%"=="" goto :END_BAT
    rem ねずみ返し_末尾が0でない場合
    if not %value:~-1,1%==0 goto :END_BAT

    rem 末尾を削除して変数に格納
    set value=%value:~0,-1%
    goto :DEL_ZERO_END

  rem 事後作業
  :END_BAT
    rem 処理なし

rem 戻り値
ENDLOCAL && set return_DelZeroEnd=%value%
exit /b