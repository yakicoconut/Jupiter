@echo off
title %~nx0
echo ffmpegで文字列挿入
: ffmpegで動画上にテキストを描画する - Qiita
: 	https://qiita.com/niusounds/items/797fe0743a9d59681446
: FFmpeg Filters Documentation
: 	https://www.ffmpeg.org/ffmpeg-filters.html#Syntax
: ffmpeg drawtextフィルタで遊んでみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-45.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 10以降の引数取得
  set arg07=%7
  set arg08=%8
  set arg09=%9
  shift /7
  shift /7
  shift /7
  set arg10=%7
  set arg11=%8
  set arg12=%9

  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 12 "PATH STR PATH STR NUM STR TIME TIME STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %arg07% %arg08% %arg09% %arg10% %arg11% %arg12%
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF
  rem 型判定結果引継ぎ
  for /f "tokens=7,8" %%a in (%ret_ChkArgDataType3%) do (
    rem 時刻フォーマット取得
    set starFmt=%%a
    set distFmt=%%b
  )

  rem 引数引継ぎ
  set batName=%0
  set srcPath=%1
  set     txt=%2
  set    font=%3
  set   color=%4
  set    size=%5
  set   point=%6
  set   start="%arg07%"
  set    dist="%arg08%"
  set   codec=%arg09%
  set    rate=%arg10%
  set     tbn=%arg11%
  set outPath=%arg12%

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

  : 挿入テキスト
    echo;
    echo 挿入テキスト入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set txt=%return_UserInput1%

  : フォントファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% フォントファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set font=%return_UserInput1%

  : カラー
    echo;
    echo カラー(white、#88e5ff等)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set color=%return_UserInput1%

  : サイズ入力
    echo;
    echo サイズ入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set size=%return_UserInput1%

  : 配置位置
    echo;
    echo 配置位置(x=数値:y=数値)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set point=%return_UserInput1%

  : 開始時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

  : 完了時間
    echo;
    echo 完了時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set distFmt=%return_UserInput2%

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
  : フォントファイルパス変換
    rem 「:」は「\\」でエスケープ
    rem 「\」は「/」に変換
    set font=%font:\=/%
    set font=%font::=\\:%

  : 開始時間秒数変換
    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %start% %starFmt%
    set start=%ret_DISMANTLE_TIME01:"=%
    set startMilli=%ret_DISMANTLE_TIME02%

    rem 文字列として分割
    set   strHour=%start:~0,2%
    set strMinute=%start:~3,2%
    set strSecond=%start:~6,2%

    rem 二桁目が「0」の場合
    if %strHour:~0,1%==0 (
      rem 数値型に格納するとエラーとなるため、一桁目のみ取得
      set strHour=%strHour:~1,1%
    )
    if %strMinute:~0,1%==0 (
      set strMinute=%strMinute:~1,1%
    )
    if %strSecond:~0,1%==0 (
      set strSecond=%strSecond:~1,1%
    )

    rem 数値変換
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

    rem 秒数変換
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a  startSec=%secHour%+%secMinute%+%second%


  : 完了時間秒数変換
    rem 時刻解体サブルーチン使用
    call :DISMANTLE_TIME %dist% %distFmt%
    set dist=%ret_DISMANTLE_TIME01:"=%
    set distMilli=%ret_DISMANTLE_TIME02%

    rem 文字列として分割
    set   strHour=%dist:~0,2%
    set strMinute=%dist:~3,2%
    set strSecond=%dist:~6,2%

    rem 二桁目が「0」の場合
    if %strHour:~0,1%==0 (
      rem 数値型に格納するとエラーとなるため、一桁目のみ取得
      set strHour=%strHour:~1,1%
    )
    if %strMinute:~0,1%==0 (
      set strMinute=%strMinute:~1,1%
    )
    if %strSecond:~0,1%==0 (
      set strSecond=%strSecond:~1,1%
    )

    rem 数値変換
    set /a   hour=%strHour%
    set /a minute=%strMinute%
    set /a second=%strSecond%

    rem 秒数変換
    set /a   secHour=%hour%*3600
    set /a secMinute=%minute%*60
    set /a   distSec=%secHour%+%secMinute%+%second%

  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 分割実行
      : -y      :上書き
      : -i      :対象ファイル
      : -filter~:drawtext=
      :            テキスト描写
      :            fontfile=ttfファイルパス
      :              フォント指定
      :              ※要調査
      :            text=対象テキスト
      :              描画対象テキスト
      :            fontcolor=フォント色
      :              フォント色(white、#88e5ff等)
      :            fontsize=数値
      :              フォントサイズ
      :            x=(y=)
      :              テキスト配置位置
      :              数値
      :                配置位置X
      :              main_w(w)、main_h(h)
      :                対象動画幅、高さ予約語
      :              text_w(tw)、text_h(th)
      :                入力テキスト幅、高さ予約語
      :              (例:画面中央に配置
      :                  x=(w-text_w)/2:y=(h-text_h-line_h)/2
      :            enable='between(t,開始時間,完了時間)'
      :              描画時間
      : -c:v    :動画コーデック
      : -c:a    :音声コーデック
      : -r      :フレームレート
      : -video~ :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -filter_complex drawtext="fontfile=%font:"=%: text=%txt:"=%: fontcolor=%color%: fontsize=%size%: %point:"=%: enable='between(t,%startSec%%startMilli%,%distSec%%distMilli%)'" %codec:"=% -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %txt:"=%>>%logPath%
  echo %font:"=%>>%logPath%
  echo %color:"=%>>%logPath%
  echo %size:"=%>>%logPath%
  echo %point:"=%>>%logPath%
  echo %start:"=%%startMilli%>>%logPath%
  echo %dist:"=%%distMilli%>>%logPath%
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


rem 時刻解体サブルーチン
:DISMANTLE_TIME
SETLOCAL
  : 引数
    rem 入力時刻
    set inpTime=%1
    rem 時刻フォーマット
    set format=%2

  : ミリ秒が存在する場合
    if %format:~-2,2%==.f (
      set milli=%inpTime:~-3,2%
    )
    if %format:~-3,3%==.ff (
      set milli=%inpTime:~-4,3%
    )
    if %format:~-4,4%==.fff (
      set milli=%inpTime:~-5,4%
    )

  : 先頭「m」、「h」、「hh」判断
    if %format:~0,2%==mm (
      set tms="00:%inpTime:~1,5%"
    )
    if %format:~0,2%==h: (
      set tms="0%inpTime:~1,7%"
    )
    if %format:~0,3%==hh: (
      rem 「hh」の場合もミリ秒を抜く
      set tms="%inpTime:~1,8%"
    )

rem 返り値1:時分秒
rem 返り値2:ミリ秒
ENDLOCAL && set ret_DISMANTLE_TIME01=%tms%&& set ret_DISMANTLE_TIME02=%milli%
exit /b