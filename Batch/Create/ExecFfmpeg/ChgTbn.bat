@echo off
title %~nx0
echo ffmpegでtbn調整
: ffmpeg でのフレームレート設定の違い | ニコラボ
: 	https://nico-lab.net/setting_fps_with_ffmpeg/
: ffmpegで動画の各種情報を確認する - Qiita
: 	https://qiita.com/ymotongpoo/items/eb9754b75606be117b70
: ビデオ ? ffmpeg連結がDTSの順序外れエラーを発生させる - コードログ
: 	https://codeday.me/jp/qa/20190531/908166.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 動画情報取得バッチ
  set call_GetMpegInfo="GetMpegInfo.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%

    echo;
    echo 対象画面サイズ
    rem 動画情報取得バッチ使用
    rem 画面サイズのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v:0 -show_entries stream=time_base -of csv=s=x:p=0" %sourcePath%

  : tbn入力
    echo;
    echo tbn入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set tbn=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 実行
  rem tbn変更
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -c copy -video_track_timescale %tbn% %outPath%
  pause