@echo off
title %~nx0
rem ユーザ入力バッチ
: 引数01:表示文言
:          「""」のみの場合、表示しない
: 引数02:不正入力ループ
:          TRUE:再入力
:          以外:終了
: 引数03:判断モード
:          PATH:ファイルパス
:          NUM :数値
:          DATE:日付
:          TIME:時刻
:          以外:文字列
: 戻値1 :入力値(「""」付き)
: 戻値2 :判定結果
:          0   :判断失敗
:          1   :判断成功
:          以外:該当判断の返り値


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 引数
    rem 表示文言
    set description=%1
    rem 無効入力ループ
    set isInvalidLoop=%2
    rem 判断モード
    set judgeMode=%3


  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem 丸括弧含有判定バッチ
    set call_ChkIncParenthesis=%~dp0"ChkIncParenthesis.bat"
    rem 数値判定バッチ
    set call_ChkNum=%~dp0"ChkNum.bat"
    rem 日付書式判定バッチ
    set call_ChkDateFormat=%~dp0"ChkDateFormat.bat"
    rem 時刻書式判定バッチ
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"


  rem ユーザ入力
  :USER_INPUT
    rem 表示文言が「""」のみでない場合
    if not %description%=="" (
      rem 文言表示
      echo %description:"=%
    )

    rem 変数初期化
    set USR=""
    set /P USR="入力してください:"

    rem 「""」入力対策
    set returnVal=%USR:"=%
    set returnVal="%returnVal%"
    rem 判定結果宣言
    set judgResult=

    : ねずみ返し_丸括弧判定
      rem 丸括弧含有判定バッチ使用
      call %call_ChkIncParenthesis% %returnVal%

      rem 丸括弧を含む場合
      if %return_ChkIncParenthesis%==1 (
        set invalidErrStr=「^(」か、「^)」が含まれています
        goto :IS_Invalid_LOOP
      )

    : ねずみ返し_無入力判定
      if %returnVal%=="" (
        rem 無効入力表示文言設定
        set invalidErrStr=無入力です
        rem 無効入力判断へ
        goto :IS_Invalid_LOOP
      )

    rem 判定結果を成功に設定
    set judgResult=1


  : 判断処理
    : ファイルパスモード
      if %judgeMode%==PATH (
        rem パスが存在しない場合
        if not exist %returnVal% (
          set invalidErrStr=パスが存在しません
          goto :IS_Invalid_LOOP
        )
      )

    : 数値モード
      if %judgeMode%==NUM (
        rem 数値判定バッチ使用
        call %call_ChkNum% %returnVal:"=%

        rem 数値でない場合
        if !return_ChkNum!==0 (
          set invalidErrStr=数値ではありません
          goto :IS_Invalid_LOOP
        )
      )

    : 日付モード
      if %judgeMode%==DATE (
        rem 日付書式判定バッチ使用
        call %call_ChkDateFormat% %returnVal:"=%

        rem 日付でない場合
        if !return_ChkDateFormat1!==0 (
          set invalidErrStr=日付ではありません
          goto :IS_Invalid_LOOP
        )
        rem 判定結果を成功に書式を設定
        set judgResult=!return_ChkDateFormat2!
      )

    : 時刻モード
      if %judgeMode%==TIME (
        rem 時刻書式判定バッチ使用
        call %call_ChkTimeFormat% %returnVal:"=%

        rem 時刻でない場合
        if !return_ChkTimeFormat1!==0 (
          set invalidErrStr=時刻ではありません
          goto :IS_Invalid_LOOP
        )
        rem 判定結果を成功に書式を設定
        set judgResult=!return_ChkTimeFormat2!
      )


  rem バッチ終了
  :RETURN
    rem 処理なし


rem 戻り値(2つ以上の場合、戻り値2以降の「&&」直前スペース注意)
ENDLOCAL && set return_UserInput1=%returnVal%&& set return_UserInput2=%judgResult%
exit /b


rem 無効入力判断
:IS_Invalid_LOOP
  rem 無効入力ループが有効の場合
  if "%isInvalidLoop%"=="TRUE" (
    rem 無効入力表示文言表示
    echo;
    echo !invalidErrStr!、再度入力してください
    echo;
    rem 入力ループ
    goto :USER_INPUT
  )

  rem 判定結果を失敗に設定
  set judgResult=0

  rem バッチ終了へ
  goto :RETURN