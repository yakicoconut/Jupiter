@echo off
title %~nx0
echo ffmpegで動画にメディア合成
: ffmpeg 動画にウォーターマーク（ロゴ）をつけてみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-80.html
: FFmpeg Filters Documentation
: 	https://ffmpeg.org/ffmpeg-filters.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数カウント
  set argc=0
  for %%a in ( %* ) do set /a argc+=1

  rem 引数がない場合、ユーザ入力へ
  if %argc%==0 goto :USER_INPUT
  rem 引数が定義通りの場合、引数判定へ
  if %argc%==7 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:7
  pause
  exit /b


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set srcPath=%return_UserInput1%

  : 合成ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 合成ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set compPath=%return_UserInput1%

  : 配置位置
    echo;
    echo 配置位置(x=数値:y=数値)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set point=%return_UserInput1%

  : コーデック
    echo;
    echo コーデック入力(-c:v 動画Codec -c:a 音声Codec)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set codec=%return_UserInput1:"=%

  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%

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

    rem 本処理へ
    goto :RUN


rem 引数判定
:CHK_ARG
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% "PATH PATH STR STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7
  rem 判定結果が失敗の場合、終了へ
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set  srcPath=%1
    set compPath=%2
    set    point=%3
    set    codec=%4
    set     rate=%5
    set      tbn=%6
    set  outPath=%7


rem 本処理
:RUN
  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 画像合成実行
      : -y      :上書き
      : -i      :対象ファイル
      : -filter~:overlay=
      :            メディア(ビデオ・画像)を重ねる
      :            x=(y=)
      :              配置位置
      :              main_w, W(main_h, H)
      :                背景ファイル画面寸法
      :              overlay_w, w(overlay_h, h)
      :                配置ファイル画面寸法
      : -c:v    :動画コーデック
      : -c:a    :音声コーデック
      : -r      :フレームレート
      : -video~ :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %compPath% -filter_complex overlay="%point:"=%" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %compPath:"=%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause