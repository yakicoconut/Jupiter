@echo off
title %~nx0
echo コマンドループ_FireFox
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
    set option=%~3
    set arg=%~4

  : コマンド実行
    echo %datetime%
    echo %counter%
    echo %option%
    echo %arg%

    "C:\Program Files\Mozilla Firefox\firefox.exe" %option% %arg%
    echo;
    echo;

ENDLOCAL
exit /b