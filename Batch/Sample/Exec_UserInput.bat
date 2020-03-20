@echo off
title %~nx0
echo ユーザ入力バッチの使用例


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\OwnLib\UserInput.bat"


: パターン1
  echo;
  echo ================================
  echo 文字列入力例1_文字入力
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:有効
  echo     判断モード    :デフォルト(文字列)
  echo   期待結果
  echo     無入力  ⇒入力ループ
  echo     任意入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% 文字入力パターン TRUE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン2
  echo;
  echo ================================
  echo 文字列入力例2_表示文言なし
  echo   設定
  echo     表示文言      :""
  echo     無効入力ループ:有効
  echo     判断モード    :デフォルト(文字列)
  echo   期待結果
  echo     無入力  ⇒入力ループ
  echo     任意入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% "" TRUE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン3
  echo;
  echo ================================
  echo 文字列入力例3_文字入力 - 無効入力ループ無効
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:無効
  echo     判断モード    :デフォルト(文字列)
  echo   期待結果
  echo     無入力  ⇒戻値1:空文字
  echo               戻値2:0
  echo     任意入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% "文字入力 - 無効入力ループ無効パターン" FALSE STR
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン4
  echo;
  echo ================================
  echo パス入力例1_パス入力
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:有効
  echo     判断モード    :パス
  echo   期待結果
  echo     無効入力⇒入力ループ
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% パス入力パターン TRUE PATH
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン5
  echo;
  echo ================================
  echo パス入力例2_パス入力 - 無効入力ループ無効
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:無効
  echo     判断モード    :パス
  echo   期待結果
  echo     無効入力⇒戻値1:入力文字列
  echo               戻値2:0
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% "パス入力 - 無効入力ループ無効パターン" FALSE PATH
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン6
  echo;
  echo ================================
  echo 数値入力例1_数値入力
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:有効
  echo     判断モード    :数値
  echo   期待結果
  echo     無効入力⇒入力ループ
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% 数値入力パターン TRUE NUM
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン7
  echo;
  echo ================================
  echo 数値入力例2_数値入力 - 無効入力ループ無効
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:無効
  echo     判断モード    :数値
  echo   期待結果
  echo     無効入力⇒戻値1:入力文字列
  echo               戻値2:0
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:1
  echo --------------------------------
  call %call_UserInput% "数値入力 - 無効入力ループ無効パターン" FALSE NUM
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン8
  echo;
  echo ================================
  echo 日付入力例1_日付入力
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:有効
  echo     判断モード    :日付
  echo   期待結果
  echo     無効入力⇒入力ループ
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:有効パターン(yyyy/mm/dd、yy/mm/dd、mm/dd)
  echo --------------------------------
  call %call_UserInput% 日付入力パターン TRUE DATE
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン9
  echo;
  echo ================================
  echo 日付入力例2_日付入力 - 無効入力ループ無効
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:無効
  echo     判断モード    :日付
  echo   期待結果
  echo     無効入力⇒戻値1:入力文字列
  echo               戻値2:0
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:有効パターン(yyyy/mm/dd、yy/mm/dd、mm/dd)
  echo --------------------------------
  call %call_UserInput% "日付入力 - 無効入力ループ無効パターン" FALSE DATE
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン10
  echo;
  echo ================================
  echo 時刻入力例1_時刻入力
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:有効
  echo     判断モード    :時刻
  echo   期待結果
  echo     無効入力⇒入力ループ
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:有効パターン(mm:ss、h:mm:ss、hh:mm:ss、hh:mm:ss.ff)
  echo --------------------------------
  call %call_UserInput% 時刻入力パターン TRUE TIME
  echo %return_UserInput1%
  echo %return_UserInput2%

: パターン11
  echo;
  echo ================================
  echo 時刻入力例2_時刻入力 - 無効入力ループ無効
  echo   設定
  echo     表示文言      :任意
  echo     無効入力ループ:無効
  echo     判断モード    :時刻
  echo   期待結果
  echo     無効入力⇒戻値1:入力文字列
  echo               戻値2:0
  echo     有効入力⇒戻値1:入力文字列
  echo               戻値2:有効パターン(mm:ss、h:mm:ss、hh:mm:ss、hh:mm:ss.ff)
  echo --------------------------------
  call %call_UserInput% "時刻入力 - 無効入力ループ無効パターン" FALSE TIME
  echo %return_UserInput1%
  echo %return_UserInput2%

pause