@echo off
title %~nx0
: 文字数カウントバッチ
: 引数01:対象文字列
: 戻値:文字数(数値)


rem 変数ローカル化
SETLOCAL
  : 引数
    rem 対象文字列取得
    set targetStr=%~1

  : 文字数カウント
  set length=0
  :LOOP
    rem カウントアップ
    set /a length+=1

    rem 文字列から一文字削除
    set targetStr=%targetStr:~1%

    rem 文字が残っている場合、ループ
    if not "%targetStr%"=="" goto LOOP


rem 戻り値
ENDLOCAL && set /a return_CountStrLength=%length%
exit /b