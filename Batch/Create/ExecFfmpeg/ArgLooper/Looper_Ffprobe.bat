@echo off
title %~nx0
echo コマンドループ_ffprobe
echo;
: 引数01:ループ開始時の数値のみ年月日時分秒ミリ
: 引数02:ループカウンタ
: 引数03:オプション
: 引数04:対象引数
: 戻値  :なし


SETLOCAL
  : 引数判定
    rem ねずみ返し_引数がない場合
    if "%~1"=="" (
      echo ※本ファイルは単体で実行しないでください
      echo 終了します
      pause
      exit
    )

  : 引数
    rem 引数引継ぎ
    set datetime=%~1
    set counter=%~2
    set option=%~3
    set arg=%~4

  : コマンド実行
    rem ファイル名見出し出力
    echo %counter%:%arg%>>ffprobe_%datetime%.txt

    rem ffprobe実行
    ".\ExecFfmpeg\ffmpeg\win32\ffprobe.exe" %option% %arg%>>ffprobe_%datetime%.txt
    echo;>>ffprobe_%datetime%.txt
    echo;
    echo;

ENDLOCAL
exit /b