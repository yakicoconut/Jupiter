@echo off
title %~nx0
echo カレントディレクトリ名のみ取得
echo ※レガシィ処理
echo   →「\OwnLib\DirFilePathInfo.bat」で実現


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 処理
  rem カレントフォルダパス取得
  set currentDirPath=%~dp0

  rem カレントフォルダ名のみ取得ループ
  rem 末尾文字取得スタート位置変数
  rem ※一番後ろは「\」となるので二文字目からはじめる
  set /a backStart = -2
  rem フォルダ名文字数変数
  set /a dirNamehLen = 0
  :YEN_POSITION
    rem 末尾文字取得
    set last=!currentDirPath:~%backStart%,1!

    rem ループ変数計算
    set /a backStart -= 1
    set /a dirNamehLen += 1

    rem 「\」マークだった場合、ループ終了
    if not "%last%"=="\" goto :YEN_POSITION

    rem ループ変数調整
    set /a backStart += 2
    set /a dirNamehLen -= 1

  rem カレントフォルダ名取得
  set currentDirName=!currentDirPath:~%backStart%,%dirNamehLen%!

  echo %currentDirName%
  pause