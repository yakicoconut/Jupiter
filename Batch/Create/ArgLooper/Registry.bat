@echo off
title %~nx0
echo コマンドループ_Registry
: 引数01:ループ開始時の数値のみ年月日時分秒ミリ
: 引数02:ループカウンタ
: 引数03:オプション
: 引数04:対象引数
: 戻値  :なし


SETLOCAL
  : 引数判定
    rem ねずみ返し_引数がない場合
    if "%~1"=="" (
      echo 本ファイルは単体で実行せず、
      echo ArgLooper.batから呼び出してください
      echo 終了します
      pause
      exit
    )

  : 引数
    set datetime=%~1
    set counter=%~2
    set option1=%~3
    set arg=%~4
    set option2=%~5
    rem 末尾「\」判定
    if %arg:~-2,1%==\ (
      rem 除去
      set arg="%arg:~1,-2%"
    )

  : コマンド実行
    echo   実行時間   :%datetime%
    echo   カウンタ   :%counter%
    echo   オプション1:%option1%
    echo   引数       :%arg%
    echo   オプション2:%option2%

    reg %option1% %arg% %option2%
    echo;
    echo;

ENDLOCAL
exit /b