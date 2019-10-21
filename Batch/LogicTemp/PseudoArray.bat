@echo off
title %~nx0
echo 擬似配列
echo コマンドプロンプトに配列の仕様がないため
echo 変数名を動的に変更し擬似配列を実装する
echo;


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 擬似配列作成
    rem 変数カウントタ初期化
    set /a counter=0

    rem 動的変数作成ループ
    rem setコマンド時の変数名に動的な数値を付加する
    for /f "delims=" %%a in ('dir') do (
      rem カウンタを増やす
      set /a counter+=1

      rem ファイルから取得した行を動的変数に代入
      set var_!counter!=%%a
    )

    rem カウンタの最大値を取得
    set /a totalCounter=%counter%

    rem 擬似配列順取り出しサブルーチン
    set /a getCounter=0
    call :GET_ARRAY_ASC

    echo;
    echo -----------------------------------------------
    echo;

    rem 擬似配列逆取り出しサブルーチン
    call :GET_ARRAY_DESC

    goto END


   rem 擬似配列順取り出しサブルーチン
   :GET_ARRAY_ASC
     rem ねずみ返し_カウンタがマックスなら終了
     if %getCounter% == %totalCounter%  exit /b

     rem カウンタインクリメント
     set /a getCounter+=1

     rem 表示
     echo !var_%getCounter%!
     echo 現在 %getCounter%/%totalCounter%

     goto GET_ARRAY_ASC


  rem 擬似配列逆取り出しサブルーチン
  :GET_ARRAY_DESC
    rem ねずみ返し_カウンタが0なら終了
    if %counter%==0 exit /b

    echo !var_%counter%!
    echo 残り !counter!/!totalCounter!

    rem カウンタを減らす
    set /a counter-=1

    goto GET_ARRAY_DESC
    pause


  :END
    echo;
    pause