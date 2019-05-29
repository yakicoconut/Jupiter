@echo off
title %~nx0
echo ffmpegで画像取得
: ffmpegで動画から静止画を抜き出す - Qiita
: 	https://qiita.com/matoken/items/664e7a7e8f31e8a46a6:


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"
  rem 経過時間計算バッチ
  set call_ElapsedTime="..\..\OwnLib\ElapsedTime.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%


  rem 開始時間
  :START
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 開始時間入力(hh:mm:ss)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem コンマ秒が入力されている場合
    if %targetTimeFormat%==hh:mm:ss.ff (
      echo;
      echo コンマ秒は入力しないでください
      goto :START
    )

    rem 「hh:mm:ss」に変換
    if %targetTimeFormat%==mm:ss (
      set start=00:%start%
    )
    if %targetTimeFormat%==h:mm:ss (
      set start=0:%start%
    )


  rem 分割時間
  :LENGTH
    echo;
    echo 分割時間入力(hh:mm:ss)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem コンマ秒が入力されている場合
    if %targetTimeFormat%==hh:mm:ss.ff (
      echo;
      echo コンマ秒は入力しないでください
      goto :LENGTH
    )

    rem 「hh:mm:ss」に変換
    if %targetTimeFormat%==mm:ss (
      set dist=00:%dist%
    )
    if %targetTimeFormat%==h:mm:ss (
      set dist=0:%dist%
    )


  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%


: 秒数変換
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %start:"=% %dist:"=%
  set elapsed=%return_ElapsedTime%
  rem 項目分割
  set /a   hour=%elapsed:~0,2%
  set /a minute=%elapsed:~3,2%
  set /a second=%elapsed:~6,2%
  rem 秒数変換
  set /a   secHour=%hour%*600
  set /a secMinute=%minute%*60
  set /a    length=%secHour%+%secMinute%+%second%


: 実行
  rem 画像取得実行
    : -i :動画指定
    : -ss:開始位置(秒)
    : -t :対象期間(秒)
    : -r :1秒あたり何枚抜き出すか
    :     fps(フレームレート)の確認は「ffprobe.exe 対象動画」
    : -f :「image2 %%06d.jpg」指定で「000001.jpg」から連番出力指定
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -ss %start% -t %length% -r %rate% -f image2 %%06d.jpg