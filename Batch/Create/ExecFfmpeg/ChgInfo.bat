@echo off
title %~nx0
echo ffmpegで動画設定変更
: ffmpeg でのフレームレート設定の違い | ニコラボ
: 	https://nico-lab.net/setting_fps_with_ffmpeg/
: ffmpegで動画の各種情報を確認する - Qiita
: 	https://qiita.com/ymotongpoo/items/eb9754b75606be117b70
: ビデオ ? ffmpeg連結がDTSの順序外れエラーを発生させる - コードログ
: 	https://codeday.me/jp/qa/20190531/908166.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 動画情報取得バッチ
  set call_GetMpegInfo=%~dp0"GetMpegInfo.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 5 "PATH STR NUM NUM STR" %1 %2 %3 %4 %5
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set srcPath=%1
  set   codec=%2
  set    rate=%3
  set     tbn=%4
  set outPath=%5

  rem 本処理へ
  goto :RUN


rem ユーザ入力処理
:USER_INPUT
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set srcPath=%return_UserInput1%

    echo;
    echo 対象fps
    echo r_frame_rate  :全タイムスタンプを正確に表すことができる
    echo                最低のフレームレート(ストリーム内のすべての
    echo                フレームレートの最小公倍数)
    echo avg_frame_rate:平均フレームレート
    rem 動画情報取得バッチ使用
    rem 対象動画fpsのみ取得オプション
    call %call_GetMpegInfo% "-v error -select_streams v -show_entries stream=r_frame_rate -show_entries stream=avg_frame_rate" %srcPath%

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

    rem 変更実行
      : -y     :上書き
      : -i     :対象ファイル
      : -c:v   :動画コーデック
      : -c:a   :音声コーデック
      : -r     :フレームレート
      : -video~:tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
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

exit /b