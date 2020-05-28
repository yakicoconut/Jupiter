@echo off
title %~nx0
echo コマンドループ_Git
: 引数01:ループ開始時の数値のみ年月日時分秒ミリ
: 引数02:ループカウンタ
: 引数03:前オプション
: 引数04:後オプション
: 引数05:対象引数
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

  : 宣言
    rem ログ用実行バッチフォルダ取得
    set crDir=%~dp0

  : 引数
    set datetime=%~1
    set counter=%~2
    set option1=%~3
    set option2=%~4
    set arg=%5

    rem 複数引数項目ラベル
    :MULTI_ARG
      rem 値がある場合
      if not "%~6"=="" (
        rem 複数引数格納サブルーチン使用
        call :ARG_PLUS %6

        rem 引数シフト
        shift

        rem 複数引数項目ラベルへ
        goto :MULTI_ARG
      )

  : コマンド実行
    echo   実行時間   :%datetime%
    echo   カウンタ   :%counter%
    echo   オプション1:%option1%
    echo   引数       :%arg%
    echo   オプション2:%option2%

    rem ファイル名見出し出力
    echo %counter%:%arg%>>%crDir%Git_%datetime%.txt

    rem Git実行
    git %option1% %arg% %option2%>>%crDir%Git_%datetime%.txt
    echo;>>%crDir%Git_%datetime%.txt
    echo;
    echo;
    exit /b

  rem 複数引数格納サブルーチン
  :ARG_PLUS
    rem 引数項目に追加
    set arg=%arg% %1
    exit /b

ENDLOCAL