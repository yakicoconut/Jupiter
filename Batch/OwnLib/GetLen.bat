@echo off
title %~nx0
rem 桁数取得バッチ
rem 引数01:対象値(「"」は無視される)
rem 戻値  :桁数


rem 遅延環境変数オン
SETLOCAL
  : 引数
    rem 対象値
    set value=%~1

  : 事前処理
    rem 桁数変数初期化
    set /a len=0

  rem 桁数カウントアップ
  :COUNT_UP
    rem ねずみ返し_対象値が空になったら
    if "%value%"=="" (
      rem ループ処理終了
      goto :LOOP_END
    )
    rem 対象値から一文字削除
    set value=%value:~1%
    set /a len=%len%+1
    goto :COUNT_UP

  rem 事後処理
  :LOOP_END
    rem 処理なし

rem 戻り値
ENDLOCAL && set return_GetLen=%len%
exit /b