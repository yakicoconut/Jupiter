@echo off
title %~nx0
echo ffmpegで音量調整
: ffmpeg で音のボリュームを調整する。gain 調整 - それマグで！
: 	https://takuya-1st.hatenablog.jp/entry/2016/04/13/023014


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput="..\..\OwnLib\UserInput.bat"


: ユーザ入力処理
  : 対象ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 対象ファイルパス入力 TRUE PATH
    rem 入力値引継ぎ
    set sourcePath=%return_UserInput1%

  : 指定ボリューム入力
    echo;
    echo 指定ボリューム入力(少数で指定「x.x」)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set vol=%return_UserInput1%

  : コーデック
    echo;
    echo コーデック入力(-c:v 動画Codec -c:a 音声Codec)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set codec=%return_UserInput1:"=%

  : 1秒あたり何枚
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 1秒あたり枚数入力 TRUE NUM
    rem 入力値引継ぎ
    set rate=%return_UserInput1%

  : tbn入力
    echo;
    echo tbn入力(数値)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set tbn=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

: 実行
  rem 音量調整
  : -i                :元ファイル
  : -af "volume=数値" :音量調整
  :                    (例1:音量指定アップ
  :                         -af "volume=+5dB"
  :                    (例2:音量指定ダウン
  :                         -af "volume=-5dB"
  :                    (例3:音量%アップ
  :                         -af "volume=1.5"
  : -async 数値       :音声サンプルを Stretch/Squeeze (つまりサンプルの持続時間を変更) して同期する
  :                    数値(1~1000)は音がズレたときに１秒間で何サンプルまで変更していいかを指定する
  :                    「1」指定は特別で、音声の最初だけ同期して後続のサンプルはそのまま
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -af "volume=%vol%" %codec% -r %rate% -video_track_timescale %tbn% %outPath% -async 1
  pause