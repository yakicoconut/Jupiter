@echo off
title %~nx0
rem 数値判定バッチ
rem 引数01:対象値
rem 戻値:判定結果(0:数値でない、1:数値)


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象値
    set value=%1


  : 実行
    rem 数値フラグ
    set isNumeric=0

    rem 対象値ループ
      : 単体もしくは連続した数値で分割した上位2つを変数に格納
      : (例1:abc9def  →「abc」、「def」
      : (例2:ghi123jkl→「ghi」、「jkl」
    for /F "tokens=1,2 delims=0123456789" %%i in ("%value%") do (
      set hoge=%%i
      set fuga=%%j
    )

    rem 1つ目が空の場合
    if "%hoge%"=="" (
      rem 数値と判断
      set isNumeric=1
    )

    rem 1つ目が「.」かつ2つ目が空の場合
    if "%hoge%"=="." (
      if "%fuga%"=="" (
        rem 少数も数値と判断
        set isNumeric=1
      )
    )


rem 戻り値
ENDLOCAL && set return_ChkNum=%isNumeric%
exit /b