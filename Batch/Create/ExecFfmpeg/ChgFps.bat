@echo off
title %~nx0
echo ffmpegでフレームレートを変更する


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
    set inPath=%return_UserInput1%

    echo;
    echo 対象fps
    echo r_frame_rate  :全タイムスタンプを正確に表すことができる
    echo                最低のフレームレート(ストリーム内のすべての
    echo                フレームレートの最小公倍数)
    echo avg_frame_rate:平均フレームレート
    rem 動画情報取得バッチ使用
    rem 対象動画fpsのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v -show_entries stream=r_frame_rate -show_entries stream=avg_frame_rate" %inPath%

  : フレームレート
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% フレームレート TRUE NUM
    rem 入力値引継ぎ
    set fps=%return_UserInput1%

  : 出力ファイル名
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 出力ファイル名入力 TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 実行
  rem 分割実行
    : -i :動画指定
    : -r :1秒あたり何枚抜き出すか
    :     fps(フレームレート)の確認は「ffprobe.exe 対象動画」
  ffmpeg\win32\ffmpeg.exe -i %inPath% -r %fps% %outPath%