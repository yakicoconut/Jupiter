@echo off
title %~nx0
echo 経過時間計算バッチの使用例


: 参照バッチ
  rem 経過時間計算バッチ
  set call_ElapsedTime="..\OwnLib\ElapsedTime.bat"


: 差分計算_「mm:ss」パターン
  echo;
  set beforeTime=12:51
  set  afterTime=24:10
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo      %beforeTime%
  echo -    %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:11:19 ←期待結果

: 差分計算_「h:mm:ss」パターン
  echo;
  set beforeTime=6:10:50
  set  afterTime=8:00:00
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   01:49:10 ←期待結果

: 差分計算_「h:mm:ss.f」パターン
  echo;
  set beforeTime=6:10:50.4
  set  afterTime=6:10:50.5
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:00.1 ←期待結果

: 差分計算_「h:mm:ss.ff」パターン
  echo;
  set beforeTime=6:10:50.45
  set  afterTime=9:00:00.99
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   02:49:10.54 ←期待結果

: 差分計算_「h:mm:ss.fff」パターン
  echo;
  set beforeTime=1:23:45.670
  set  afterTime=9:54:32.100
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo    %beforeTime%
  echo -  %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   08:30:46.430 ←期待結果

: 差分計算_コンマ秒パターン
  echo;
  set beforeTime=01:59:19.40
  set  afterTime=02:00:00.39
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:40.99 ←期待結果

: 差分計算_「hh:mm:ss」パターン
  echo;
  set beforeTime=00:13:30
  set  afterTime=00:14:00
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:30 ←期待結果

: 差分計算_コンマ三桁差分パターン
  echo;
  set beforeTime=00:00:34.600
  set  afterTime=00:00:41.607
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:07.007 ←期待結果

: 差分計算_8進数オーバーフロー1_引数パターン
  echo;
  set beforeTime=00:00:10.080
  set  afterTime=00:00:11.090
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:01.010 ←期待結果

: 差分計算_8進数オーバーフロー2_パターン
  echo;
  set beforeTime=00:00:10.009
  set  afterTime=00:00:11.008
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:00.999 ←期待結果

: 差分計算_8進数オーバーフロー_結果パターン
  echo;
  set beforeTime=00:00:10.020
  set  afterTime=00:00:11.100
  rem 経過時間計算バッチ使用
  call %call_ElapsedTime% %beforeTime% %afterTime%
  echo   %beforeTime%
  echo - %afterTime%
  echo   ------------
  echo   %return_ElapsedTime%
  echo   00:00:01.08 ←期待結果

pause