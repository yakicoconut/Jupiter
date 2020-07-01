@echo off
title %~nx0
echo ffmpegで動画にメディア合成
: ffmpeg 動画にウォーターマーク（ロゴ）をつけてみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-80.html
: FFmpeg Filters Documentation
: 	https://ffmpeg.org/ffmpeg-filters.html
: FFmpegを利用した動画の合成、クロマキー合成 - Qiita
: 	https://qiita.com/developer-kikikaikai/items/47a13cbcb6fdb535345a
: ffmpeg でクロマキー合成 | ニコラボ
: 	https://nico-lab.net/ffmpeg_with_chroma_key_by_colorkey/


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
  if %argc%==8 goto :CHK_ARG

  echo 引数の数が定義と異なるため、終了します
  echo 引数:%argc%
  echo 定義:8
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

  : 透明色指定
    echo;
    echo 透明色(white、#88e5ff等)入力
    echo ※無入力は無指定
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set alpha=%return_UserInput1%

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
  call %call_ChkArgDataType% "PATH PATH STR STR STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %8
  rem 判定結果が失敗の場合、終了へ
  if %ret_ChkArgDataType1%==0 goto :EOF

  : 引数引継ぎ
    set  srcPath=%1
    set compPath=%2
    set    point=%3
    set    alpha=%4
    set    codec=%5
    set     rate=%6
    set      tbn=%7
    set  outPath=%8


rem 本処理
:RUN
  : 引数個別処理
    rem 透明色指定がある場合、オプション設定
    if not "%alpha:"=%"=="" ( set alpha=[1:0]colorkey=%alpha:"=%:0.01:1[tgt];[0:0][tgt])

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
      : -filter~:[入力情報]オプション[定義名]
      :            入力ファイルに適用するオプションを
      :            定義名に格納し、使用可能
      :            [入力情報]
      :              [0:0]:一つ目の対象ファイル
      :              [1:0]:二つ目の対象ファイル
      :            [定義名]
      :              (例:[tgt]
      :            オプション
      :              colorkey=
      :                透明色指定
      :              overlay=
      :                メディア(ビデオ・画像)を重ねる
      :                x=(y=)
      :                  配置位置
      :                  main_w, W(main_h, H)
      :                    背景ファイル画面寸法
      :                  overlay_w, w(overlay_h, h)
      :                    配置ファイル画面寸法
      :            (例:白を透明色に指定して(100,100)に配置
      :                [1:0]colorkey=white:0.01:1[tgt];[0:0][tgt]overlay=x=100:y100
      :                  [1:0]colorkey=white:0.01:1[tgt];
      :                    →二つ目の対象ファイルを透明色「白」で設定し、定義名「[tgt]」とする
      :                  [0:0][tgt]overlay=x=100:y100
      :                    →一つ目の対象ファイルの(100,100)に定義名「[tgt]」を合成
      : -c:v    :動画コーデック
      : -c:a    :音声コーデック
      : -r      :フレームレート
      : -video~ :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %compPath% -filter_complex %alpha%overlay="%point:"=%:" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %compPath:"=%>>%logPath%
  echo %point:"=%>>%logPath%
  echo %alpha:"=%>>%logPath%
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