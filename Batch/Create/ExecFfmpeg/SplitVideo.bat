@echo off
title %~nx0
echo ffmpegで動画分割


: 参照バッチ
  rem ディレクトリファイル情報バッチ
  set call_DirFilePathInfo="..\..\OwnLib\DirFilePathInfo.bat"
  rem 時刻判定バッチの絶対パス取得
  call %call_DirFilePathInfo% "..\..\OwnLib\ChkTimeFormat.bat" f
  set call_ChkTimeFormat=%return_DirFilePathInfo%
  rem 経過時間計算バッチの絶対パス取得
  call %call_DirFilePathInfo% "..\..\OwnLib\ElapsedTime.bat" f
  set call_ElapsedTime=%return_DirFilePathInfo%


: ユーザ入力処理
  :FILE
    echo;
    echo 対象ファイル指定

    rem 変数初期化
    set USR=""
    set /P USR="入力してください(文末\なし):"

    rem 「""」入力対策
    set sourcePath=%USR:"=%
    set sourcePath="%sourcePath%"
    : ねずみ返し_空白の場合
      if %sourcePath%=="" (
        echo;
        echo 入力がありません
        echo 終了します
        pause
        goto :EOF
      )
    : ねずみ返し_入力パスが無効の場合
      if not exist %sourcePath% (
        echo;
        echo 入力パスが正しくありません
        goto :FILE
      )


  :START
    echo;
    echo 開始時間指定

    rem 変数初期化
    set USR=""
    set /P USR="入力してください([hh:]mm:ss):"

    set start="%USR%"
    : ねずみ返し_空白の場合
      if %start%=="" (
        echo;
        echo 入力がありません
        echo 終了します
        pause
        goto :EOF
      )
    : ねずみ返し_時刻判定
      rem 時刻判定バッチ使用
      call %call_ChkTimeFormat% %start:"=%
      set isTimeFormat=%return_ChkTimeFormat1%
      set targetTimeFormat=%return_ChkTimeFormat2%
      rem 時刻フォーマットに沿っていない場合
      if %isTimeFormat%==0 (
        echo;
        echo 入力された値が時刻ではありません
        goto :START
      )

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


  :LENGTH
    echo;
    echo 分割時間指定

    rem 変数初期化
    set USR=""
    set /P USR="入力してください([hh:]mm:ss):"

    set dist="%USR%"
    : ねずみ返し_空白の場合
      if %dist%=="" (
        echo;
        echo 入力がありません
        echo 終了します
        pause
        goto :EOF
      )
    : ねずみ返し_時刻判定
      rem 時刻判定バッチ使用
      call %call_ChkTimeFormat% %dist:"=%
      set isTimeFormat=%return_ChkTimeFormat1%
      set targetTimeFormat=%return_ChkTimeFormat2%
      rem 時刻フォーマットに沿っていない場合
      if %isTimeFormat%==0 (
        echo;
        echo 入力された値が時刻ではありません
        goto :LENGTH
      )

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


  :OUTPATH
    echo;
    echo 出力ファイル名称指定

    rem 変数初期化
    set USR=""
    set /P USR="入力してください(文末\なし):"

    set outPath="%USR%"
    : ねずみ返し_空白の場合
      if %outPath%=="" (
        echo;
        echo 入力がありません
        echo 終了します
        pause
        goto :EOF
      )


: 実行
  rem 分割実行
  ffmpeg\ffmpeg.exe -y -ss %start% -i %sourcePath% -t %length% %outPath%