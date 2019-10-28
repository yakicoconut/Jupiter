@echo off
title %~nx0
echo ffmpegで動画分割
: ffmpeg で音のボリュームを調整する。gain 調整 - それマグで！
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014
: ffmpegで無劣化カット - 脳みそスワップアウト
: 	http://iamapen.hatenablog.com/entry/2018/12/30/100811


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
    echo 開始時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set start=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem ミリ秒が存在する場合
    if %targetTimeFormat:~-2,2%==.f (
      set startMilli=%start:~-3,2%
    )
    if %targetTimeFormat:~-3,3%==.ff (
      set startMilli=%start:~-4,3%
    )
    if %targetTimeFormat:~-4,4%==.fff (
      set startMilli=%start:~-5,4%
    )

    rem 先頭が「m」、「h」、「hh」判断
    if %targetTimeFormat:~0,2%==mm (
      set start="00:%start:~1,5%"
    )
    if %targetTimeFormat:~0,2%==h: (
      set start="0%start:~1,7%"
    )
    if %targetTimeFormat:~0,3%==hh: (
      rem 「hh」の場合もミリ秒を抜く
      set start="%start:~1,8%"
    )


  rem 分割時間
  :LENGTH
    echo;
    echo 分割時間入力(hh:mm:ss.fff)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE TIME
    rem 入力値引継ぎ
    set dist=%return_UserInput1%
    set targetTimeFormat=%return_UserInput2%

    rem ミリ秒が存在する場合
    if %targetTimeFormat:~-2,2%==.f (
      set distMilli=%dist:~-3,2%
    )
    if %targetTimeFormat:~-3,3%==.ff (
      set distMilli=%dist:~-4,3%
    )
    if %targetTimeFormat:~-4,4%==.fff (
      set distMilli=%dist:~-5,4%
    )

    rem 先頭が「m」、「h」、「hh」判断
    if %targetTimeFormat:~0,2%==mm (
      set dist="00:%dist:~1,5%"
    )
    if %targetTimeFormat:~0,2%==h: (
      set dist="0%dist:~1,7%"
    )
    if %targetTimeFormat:~0,3%==hh: (
      rem 「hh」の場合もミリ秒を抜く
      set dist="%dist:~1,8%"
    )


  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%


: 秒数変換
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %start:"=% %dist:"=%
  set elapsed=%return_ElapsedTime%

  : 項目分割
    rem 文字列として分割
    set   strHour=%elapsed:~0,2%
    set strMinute=%elapsed:~3,2%
    set strSecond=%elapsed:~6,2%

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
    set /a    length=%secHour%+%secMinute%+%second%


: 実行
  rem 分割実行
  : -y         :上書き
  : -ss        :開始位置(秒)、「-i」オプションより先に記述しないと音ズレする
  : -i         :元ファイル
  : -t         :対象期間(秒)
  : -c:v copy  :映像無変換(無劣化)
  : -c:a copy  :音声無変換(無劣化)
  : -async 数値:音声サンプルを Stretch/Squeeze (つまりサンプルの持続時間を変更) して同期する
  :             数値(1~1000)は音がズレたときに１秒間で何サンプルまで変更していいかを指定する
  :             「1」指定は特別で、音声の最初だけ同期して後続のサンプルはそのまま
  ffmpeg\win32\ffmpeg.exe -y -ss %start:"=%%startMilli% -i %sourcePath% -t %length%%distMilli% -c:v copy -c:a copy -async 1 %outPath%