@echo off
title %~nx0
echo ffmpegで再生速度調整
: ffmpegを使って動画の再生速度を変えてみる - 脳内メモ＋＋
: 	http://fftest33.blog.fc2.com/blog-entry-36.html
: 映像と音声の pts を扱う setpts, asetpts | ニコラボ
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/
: ffmpegの使い方やコマンド一覧をまとめました。動画リサイズ・静止画変換・フレーム補間について|おちゃカメラ。
: 	https://photo-tea.com/p/17/ffmpeg-command-list/

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

  : 入力
    echo;
    echo 倍速非入力(少数で指定「x.x」)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE NUM
    rem 入力値引継ぎ
    set spdRatio=%return_UserInput1%

  : 出力ファイル名
    echo;
    echo 出力ファイル名入力(要拡張子)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" TRUE STR
    rem 入力値引継ぎ
    set outPath=%return_UserInput1%

: 実行
  rem 音量調整
  : -i             :元ファイル
  : -vf            :
  : setpts=PTS/数値:
  :                 (例1:
  :                      
  :                 (例2:
  :                      
  : -af atempo=数値:
  :                 (例1:
  :                      
  :                 (例2:
  :                      
  ffmpeg\win32\ffmpeg.exe -i %sourcePath% -vf setpts=PTS/%spdRatio% -af atempo=%spdRatio% %outPath%