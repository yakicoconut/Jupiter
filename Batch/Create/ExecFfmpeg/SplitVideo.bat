@echo off
title %~nx0
echo ffmpegで動画分割
: ffmpeg で音のボリュームを調整する。gain 調整 - それマグで！
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014
: ffmpegで無劣化カット - 脳みそスワップアウト
: 	http://iamapen.hatenablog.com/entry/2018/12/30/100811
: ffmpeg で360度動画を編集したときのメモ
: 	https://gist.github.com/soonraah/7c7a8369829975aeb65ed048af789f4f


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"
  rem 時間秒変換バッチ
  set call_TimeToSec=%~dp0"..\..\OwnLib\TimeToSec.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 9 "PATH TIME TIME STR NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %8 %9
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF
  rem 型判定結果引継ぎ
  for /f "tokens=2,3" %%a in (%ret_ChkArgDataType3%) do (
    rem 時刻フォーマット取得
    set starFmt=%%a
    set distFmt=%%b
  )

  rem 引数引継ぎ
  set srcPath=%1
  set   start="%2"
  set    dist="%3"
  set   color=%4
  set    size=%5
  set   codec=%6
  set    rate=%7
  set     tbn=%8
  set outPath=%9

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

  : 開始時間
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set starFmt=%return_UserInput2%

  : 分割時間
    echo;
    echo 分割時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set distFmt=%return_UserInput2%

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
  : 時間処理
    : 分割時間処理
      rem 経過時間計算バッチ使用
      call %call_ElapsedTime% %start:"=% %dist:"=%
      set elapsed=%return_ElapsedTime%

    : 秒数変換
      rem 開始時間
      rem 時間秒変換バッチ使用
      call %call_TimeToSec% %start%
      set startSec=%return_TimeToSec1%
      rem ミリ秒がある場合、ドット付きで格納
      if not "%return_TimeToSec2%"=="" ( set startMilli=.%return_TimeToSec2% )

      rem 分割時間
      call %call_TimeToSec% %elapsed%
      set length=%return_TimeToSec1%
      if not "%return_TimeToSec2%"=="" ( set elapsedMilli=.%return_TimeToSec2% )


  : 表示ファイル名変換
    rem 「\」→「/」変換
    set strOutPath=%outPath:\=/%
    rem 「'」→「’」変換
    set strOutPath=%outPath:'=’%


  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 分割実行
      : -y     :上書き
      : -ss    :開始位置(秒)、「-i」オプションより先に記述しないと音ズレする
      : -i     :対象ファイル
      : -t     :対象期間(秒)
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
      : -c:v   :動画コーデック
      : -c:a   :音声コーデック
      : -r     :フレームレート
      : -video~:tbn設定
      : -strict:unofficial
      :           天体情報
    %~dp0ffmpeg\win32\ffmpeg.exe -y -ss %startSec%%startMilli% -i %srcPath% -t %length%%elapsedMilli% %codec:"=% -filter_complex drawtext="text=%strOutPath:"=%: fontcolor=%color%: fontsize=%size%: x=w-text_w:y=h-text_h" -r %rate% -video_track_timescale %tbn% -strict unofficial %outPath%


:END
  rem ログ出力
  echo %srcPath:"=%>>%logPath%
  echo %start:"=%>>%logPath%
  echo %dist:"=%>>%logPath%
  echo %color:"=%>>%logPath%
  echo %size:"=%>>%logPath%
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