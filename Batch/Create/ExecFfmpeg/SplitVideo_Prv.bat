@echo off
title %~nx0
echo 動画分割先頭末尾確認


: 参照バッチ
  rem 経過時間計算バッチ
  set call_ElapsedTime=%~dp0"..\..\OwnLib\ElapsedTime.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"
  rem 時間秒変換バッチ
  set call_TimeToSec=%~dp0"..\..\OwnLib\TimeToSec.bat"
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo=%~dp0"..\..\OwnLib\DirFilePathInfo.bat"


: 引数チェック
  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 9 "PATH TIME TIME NUM NUM STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %8 %9
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
  set /a lead=%4
  set /a term=%5
  set   codec=%6
  set    rate=%7
  set     tbn=%8
  set outPath=%9

  rem 本処理へ
  goto :RUN


rem ユーザ入力処理
:USER_INPUT
  echo 引数がないため、終了します
  pause
  exit /b


rem 本処理
:RUN
  : 秒数変換
    rem 開始時間
    rem 時間秒変換バッチ使用
    call %call_TimeToSec% %start%
    set startSec=%return_TimeToSec1%
    rem ミリ秒がある場合、ドット付きで格納
    if not "%return_TimeToSec2%"=="" ( set startMilli=.%return_TimeToSec2% )

    rem 分割時間
    call %call_TimeToSec% %dist%
    set distSec=%return_TimeToSec1%
    set /a calcDistSec=%distSec% - %term%
    if not "%return_TimeToSec2%"=="" ( set distMilli=.%return_TimeToSec2% )

  : ファイル名分解
    rem ディレクトリファイル情報バッチ使用
    call %call_DirFilePathInfo% %outPath% dp
    set dirPath=%return_DirFilePathInfo%
    call %call_DirFilePathInfo% %outPath% n
    set fileName=%return_DirFilePathInfo%
    call %call_DirFilePathInfo% %outPath% x
    set ex=%return_DirFilePathInfo%

  : サブルーチン呼び出し
    rem 
    call :EXEC_CMD %startSec% %lead% %startMilli% _A_LEAD
    rem 
    call :EXEC_CMD %calcDistSec% %term% %distMilli% _B_TERM

    exit /b


rem 実行サブルーチン
:EXEC_CMD
SETLOCAL
  : 引数
    set startSec=%1
    set length=%2
    set startMilli=%3
    set elapsedMilli=%3
    set id=%4

  : ファイル名識別子追加
    rem 表示ファイル名作成
    set strOutPath=%fileName%%id%%ex%
    rem 出力ファイルパス作成
    set outPath=%dirPath%%strOutPath%

    rem 表示ファイル名変換
    rem 「\」→「/」変換
    set strOutPath=%strOutPath:\=/%
    rem 「'」→「’」変換
    set strOutPath=%strOutPath:'=’%

  : 実行
    rem 分割実行
    %~dp0ffmpeg\win32\ffmpeg.exe -y -ss %startSec%%startMilli% -i %srcPath% -t %length%%elapsedMilli% %codec:"=% -filter_complex drawtext="text=%strOutPath:"=%: fontcolor=green: fontsize=30: x=w-text_w:y=h-text_h" -r %rate% -video_track_timescale %tbn% %outPath%

ENDLOCAL
exit /b