@echo off
title %~nx0
echo コマンドループ_ffprobe
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

  : コマンド実行
    echo   実行時間   :%datetime%
    echo   カウンタ   :%counter%
    echo   オプション1:%option1%
    echo   引数       :%arg%
    echo   オプション2:%option2%

    rem ファイル名見出し出力
    echo %counter%:%arg%>>ffprobe_%datetime%.txt

    rem ffprobe実行
    "..\ffmpeg\win32\ffprobe.exe" %option1% %arg% %option2%>>ffprobe_%datetime%.txt
    echo;>>ffprobe_%datetime%.txt
    echo;
    echo;

ENDLOCAL
exit /b