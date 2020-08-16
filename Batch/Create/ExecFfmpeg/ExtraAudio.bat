@echo off
title %~nx0
echo ffmpegで音声抽出
: 【ffmpeg】 マルチトラックの動画の作り方 - ニコニコ動画研究所
: 	https://looooooooop.blog.fc2.com/blog-entry-960.html
: FFMpegでDVD(VOB)系音声(AC3・DTS)を変換する
: 	http://49.212.76.154/pc/ffmpeg_dvd.html


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 3 "PATH NUM STR" %1 %2 %3
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set srcPath=%1
  set bitRate=%2
  set outPath=%3

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

  : ビットレート入力
    echo;
    echo 出力ビットレート入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set bitRate=%return_UserInput1%

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

    rem 音声抽出実行
      : -y     :上書き
      : -i     :対象ファイル
      : -acodec:
      :         libmp3lame
      :           
      : -ab    :ビットレート指定
      :         k指定
      :         →低すぎる場合、以下警告出力
      :           (例:「192」指定→「Bitrate 192 is extremely low, maybe you mean 192k」
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -acodec libmp3lame -ab %bitRate%k %outPath%

    rem 時間プロパティがおかしくなるオプション
      : -vcodec :copy
      :            コーデックコピー
      : -map    :直後の数字が入力順、「:」 で区切って次の数字が
      :          コンテナフォーマットに割り当てられている順番
      :          一般的な動画は「0:0」が映像、「0:1」が音声で、「0:2」以降が副音声または字幕
    REM %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath%  -vcodec copy -map 0:1 %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %bitRate:"=%>>%logPath%
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