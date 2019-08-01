@echo off
title %~nx0
echo 端末固有情報取得
: Wevtutil でリモートの Windows マシンのイベントログを取得する
: 	https://mseeeen.msen.jp/acquire-event-log-in-remote-machine-with-wevtutil/


: 準備
  rem 取得パス
  set targetPath001="C:\bin\Log"


: 参照バッチ
  rem 数値のみ年月日時分秒ミリ取得バッチ
  set call_GetStrDateTime="..\OwnLib\GetStrDateTime.bat"


: 宣言
  rem 数値のみ年月日時分秒ミリ取得バッチ使用
  call %call_GetStrDateTime%
  set datetime=%return_GetStrDateTime%
  rem コメント用インデント半角スペース×2
  set indent=  


: MsInfo32
  echo;
  echo;
  echo msinfo32取得

  rem IdentifyingNumberの2行目取得
  for /f "tokens=2 usebackq delims=^:" %%i in (`wmic csproduct get IdentifyingNumber ^| findstr /n /r "." ^| findstr /r "^2:"`) do set serialNum=%%i

  rem シリアルナンバー表示
  echo %indent%シリアルナンバー:%serialNum%

  rem トリムサブルーチン使用
  set x=%serialNum%
  call :TRIM %x%
  rem スペースが存在する場合、最初のスペースまでしか
  rem ファイル名に出来ないため「"」でくくる
  set serialNum="%x%"


  : 出力フォルダ作成
    rem ※実際には問題ないが表示上は「"」を取る
    echo %indent%出力フォルダ作成:%~dp0TermInfo_%serialNum:"=%_%datetime%
    md TermInfo_%serialNum%_%datetime%


  rem ファイル出力
  msinfo32 /report TermInfo_%serialNum%_%datetime%\MsInfo32.txt


: EventLog
  echo;
  echo 各イベントログ出力
  wevtutil epl Application     TermInfo_%serialNum%_%datetime%\EventLog_Application.evtx
  wevtutil epl Security        TermInfo_%serialNum%_%datetime%\EventLog_Security.evtx
  wevtutil epl Setup           TermInfo_%serialNum%_%datetime%\EventLog_Setup.evtx
  wevtutil epl System          TermInfo_%serialNum%_%datetime%\EventLog_System.evtx
  wevtutil epl ForwardedEvents TermInfo_%serialNum%_%datetime%\EventLog_ForwardedEvents.evtx


: CheckDisk
  echo;
  echo チェックディスク結果取得
  rem ※実際には正常に出力されるが表示上エラーとなるためシリアルの「"」を取る
  chkdsk>TermInfo_%serialNum:"=%_%datetime%\ChekDisk.txt


: Log001
  echo;
  echo 対象フォルダ取得

  rem 対象フォルダが存在する場合
  if exist %targetPath001% (
    rem フォルダコピー
    echo d | xcopy %targetPath001% TermInfo_%serialNum%_%datetime%\Target001 /s
  )


: 事後作業
  echo;
  echo;
  echo 処理完了
  pause
  exit


rem トリムサブルーチン
:TRIM
  rem 後ろのスペースを除去
  set x=%*

  exit /b