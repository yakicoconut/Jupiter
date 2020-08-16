@echo off
title %~nx0
rem 引数型判定バッチ
: 引数
:   01 :指定引数数
:   02 :判定型
:         「""」内に以下、型を半角スペースで
:       対象引数分設定
:         PATH:ファイルパス
:         NUM :数値
:         DATE:日付
:         TIME:時刻
:         以外:文字列
:         (例:パス、数値、日付、数値の引数指定
:             "PATH NUM DATE NUM"
:   03~:検証値
:       複数に対応
: 戻値
:   01:引数カウント
:   02:判定結果
:        0:判断失敗
:        1:判断成功
:   03:各引数の判断結果返り値
:      文字列、数値、パスについては固定値設定
:      戻値01(判定結果)が失敗の場合は「""」設定


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 引数疑似配列化
    rem 全引数変数化
    set argCmd=%*
    rem 指定引数数
    set chkCount=%1

    rem カウンタ初期化
    rem ※カウント対象は3つ目の引数からのため
    rem   数合わせとして「-2」スタート
    set /a argCt=-2
    for %%a in (!argCmd!) do (
      rem カウンタインクリメント
      set /a argCt+=1
      rem 疑似配列に引数格納
      set arg!argCt!=%%a
    )

    rem ねずみ返し_引数の数が一致しない場合
    if not %argCt%==%chkCount% (
      rem 判定結果を「0:失敗」に設定
      set retVal=0
      rem 引数無入力でない場合
      if not %argCt%==0 (
        call :INVALID_DATA 引数の数が定義と異なります
        echo 定義数:%chkCount%
        echo 引数数:%argCt%
      )
      goto :RETURN
    )

    rem 型引数疑似配列化サブルーチン使用
    rem 疑似配列の一つ目(判定型)指定
    call :ARG_DATA_TYPE %arg0:"=%

    rem 判定型数と引数の数が合わない場合
    if not %argCt%==%argTypeCt% (
      echo 判定型の数と引数の数が合いません
      echo 判定型数:%argTypeCt%
      echo 引数数  :%argCt%

      rem 無効引数共通処理サブルーチン使用
      call :INVALID_DATA "引数の確認をしてください"
      goto :RETURN
    )

  : 参照バッチ
    rem 呼び出しを想定して自身と同じフォルダを指定
    rem 数値判定バッチ
    set call_ChkNum=%~dp0"ChkNum.bat"
    rem 日付書式判定バッチ
    set call_ChkDateFormat=%~dp0"ChkDateFormat.bat"
    rem 時刻書式判定バッチ
    set call_ChkTimeFormat=%~dp0"ChkTimeFormat.bat"

  : 擬似配列順取り出しラベル
     rem 判定結果初期化(1:成功)
     set retVal=1
     rem 取り出しカウンタ
     rem ※一つ目の引数が判定型のため二つ目以降からスタート
     set /a getCt=1

     :GET_ARRAY
      : 型判定
       rem 判断結果疑似配列設定(文字列固定値設定)
       set jdg!getCt!=STR

       : ファイルパス
         if !argType%getCt%!==PATH (
           rem パスが存在しない場合
           if not exist !arg%getCt%! (
             call :INVALID_DATA パスが存在しません
             goto :RETURN
           )
           rem 判断結果疑似配列設定(パス固定値設定)
           set jdg!getCt!=PATH
         )
       : 数値
         if !argType%getCt%!==NUM (
           rem 数値判定バッチ使用
           call %call_ChkNum% !arg%getCt%:"=!

           rem 数値でない場合
           if !return_ChkNum!==0 (
             call :INVALID_DATA 数値ではありません
             goto :RETURN
           )
           rem 判断結果疑似配列設定(数値固定値設定)
           set jdg!getCt!=NUM
         )
       : 日付
         if !argType%getCt%!==DATE (
           rem 日付書式判定バッチ使用
           call %call_ChkDateFormat% !arg%getCt%:"=!

           rem 日付でない場合
           if !return_ChkDateFormat1!==0 (
             call :INVALID_DATA 日付ではありません
             goto :RETURN
           )
           rem 判定結果を成功に書式を設定
           set jdg!getCt!=!return_ChkDateFormat2!
         )
       : 時刻
         if !argType%getCt%!==TIME (
           rem 時刻書式判定バッチ使用
           call %call_ChkTimeFormat% !arg%getCt%:"=!

           rem 時刻でない場合
           if !return_ChkTimeFormat1!==0 (
             call :INVALID_DATA 時刻ではありません
             goto :RETURN
           )
           set jdg!getCt!=!return_ChkTimeFormat2!
         )

       rem カウンタがマックスなら終了
       if %getCt% == %argCt% goto :RETURN

       rem カウンタインクリメント
       set /a getCt+=1
       goto :GET_ARRAY

  rem バッチ終了
  :RETURN
    rem 判定結果が失敗の場合
    rem 判断結果疑似配列取り出しサブルーチン使用
    if %retVal%==1 call :JDG_ARY_TO_VAR

rem 戻り値(2つ以上の場合、戻り値2以降の「&&」直前スペース注意)
ENDLOCAL && set ret_ChkArgDataType1=%argCt%&& set ret_ChkArgDataType2=%retVal%&& set ret_ChkArgDataType3="%jdgResult%"
exit /b

rem 型引数疑似配列化サブルーチン
:ARG_DATA_TYPE
  rem 引数取得コマンド
  set argTypeCmd=%*

  rem 引数取り出しループ
  set /a argTypeCt=0
  for %%a in (!argTypeCmd!) do (
    rem カウンタインクリメント
    set /a argTypeCt+=1
    rem 疑似配列に引数格納
    set argType!argTypeCt!=%%a
  )

  exit /b

rem 無効引数共通処理サブルーチン
:INVALID_DATA
  echo;
  echo %~1

  rem 判定結果を「0:失敗」に設定
  set retVal=0

  rem サブルーチン終了へ
  exit /b

rem 判断結果疑似配列取り出しサブルーチン
:JDG_ARY_TO_VAR
  rem 最初の値を判断結果変数に追加
  set jdgResult=%jdg1%

  rem 引数取り出しループ
  set /a jdgCt=1
  :JDG_ARY_TO_VAR_LOOP
    rem カウンタがマックスなら終了
    if %jdgCt% == %argCt% exit /b
    set /a jdgCt+=1

    rem 判断結果変数に追加
    set jdgResult=%jdgResult% !jdg%jdgCt%!

    goto :JDG_ARY_TO_VAR_LOOP