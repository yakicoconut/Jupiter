@echo off
title %~nx0
echo ffmpegで動画情報を取得する
rem 引数01:オプション
rem 引数02:対象ファイルパス
rem 戻値  :なし


rem 変数ローカル化
SETLOCAL
  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem ユーザ入力バッチ
    set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"


  : 引数
    rem オプション
    set option=%1


  : 引数有無確認
    rem 引数がない場合、ユーザ入力処理へ
    if "%~2"=="" ( goto :NOARG )

    rem 引数を変数に設定
    set inPath=%2
    rem 実行へ
    goto :RUN


  rem ユーザ入力処理
  :NOARG
    : 対象ファイルパス
      echo;
      rem ユーザ入力バッチ使用
      call %call_UserInput% 対象ファイルパス入力 TRUE PATH
      rem 入力値引継ぎ
      set inPath=%return_UserInput1%


  rem 実行
  :RUN
    rem 分割実行
    : 高さ、幅のみ取得
    :   -v error                         :
    :   -select_streams v:0              :
    :   -show_entries stream=height,width:
    :   -of csv=s=x:p=0                  :
    ffmpeg\win32\ffprobe.exe %option:"=% %inPath%
    pause