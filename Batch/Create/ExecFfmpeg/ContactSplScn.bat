@echo off
title %~nx0
echo ffmpegで動画分割
: ffmpegで動画をタイル配置する - Akionux-wiki
: 	http://ja.akionux.net/wiki/index.php/ffmpeg%E3%81%A7%E5%8B%95%E7%94%BB%E3%82%92%E3%82%BF%E3%82%A4%E3%83%AB%E9%85%8D%E7%BD%AE%E3%81%99%E3%82%8B
: ffmpeg で使える映像のテストソース | ニコラボ
: 	https://nico-lab.net/testsrc_with_ffmpeg/
: 映像と音声の pts を扱う setpts, asetpts | ニコラボ
: 	https://nico-lab.net/setpts_asetpts_with_ffmpeg/


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem ユーザ入力バッチ
  set call_UserInput=%~dp0"..\..\OwnLib\UserInput.bat"
  rem 引数型判定バッチ
  set call_ChkArgDataType=%~dp0"..\..\OwnLib\ChkArgDataType.bat"


: 引数チェック
  rem 10以降の引数取得
  set arg08=%8
  set arg09=%9
  shift /8
  shift /8
  set arg10=%8
  set arg11=%9

  rem 引数型判定バッチ使用
  call %call_ChkArgDataType% 11 "PATH PATH STR STR STR STR STR STR NUM NUM STR" %1 %2 %3 %4 %5 %6 %7 %arg08% %arg09% %arg10% %arg11%
  rem 引数がない場合、ユーザ入力へ
  set argc=%ret_ChkArgDataType1%
  if %argc%==0 goto :USER_INPUT
  rem 判定結果が失敗の場合、終了
  if %ret_ChkArgDataType2%==0 goto :EOF

  rem 引数引継ぎ
  set  srcPath=%1
  set contPath=%2
  set baseSize=%3
  set  v0Scale=%4
  set  v0Point=%5
  set  v1Scale=%6
  set  v1Point=%7
  set    codec=%arg08%
  set     rate=%arg09%
  set      tbn=%arg10%
  set  outPath=%arg11%

  rem 本処理へ
  goto :RUN


rem ユーザ入力処理
:USER_INPUT
  : 動画1ファイルパス
    echo;
    echo 動画1パス入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% ※動画2よりも再生時間が大きいものを指定 TRUE PATH
    rem 入力値引継ぎ
    set srcPath=%return_UserInput1%

  : 動画2ファイルパス
    echo;
    rem ユーザ入力バッチ使用
    call %call_UserInput% 動画2パス入力 TRUE PATH
    rem 入力値引継ぎ
    set contPath=%return_UserInput1%

  : 基底画面サイズ
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo ベースサイズ入力(縦x横)
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set baseSize=%return_UserInput1%

  : 動画1スケール比
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 動画1スケール比入力(縦:横)
    echo ※どちらかを「-1」設定とすると自動計算となる
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set v0Scale=%return_UserInput1%

  : 動画1配置位置
    echo;
    echo 動画1配置位置(x=数値:y=数値)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set v0Point=%return_UserInput1%

  : 動画2スケール比
    echo;
    rem バッチ内で「()」を使用できないためここで表示
    echo 動画2スケール比入力(縦:横)
    echo ※どちらかを「-1」設定とすると自動計算となる
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set v1Scale=%return_UserInput1%

  : 動画2配置位置
    echo;
    echo 動画2配置位置(x=数値:y=数値)入力
    rem ユーザ入力バッチ使用
    call %call_UserInput% "" FALSE STR
    rem 入力値引継ぎ
    set v1Point=%return_UserInput1%

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


rem 本処理
:RUN
  : 実行
    rem ログフォルダ作成
    if not exist %~dp0Log ( mkdir %~dp0Log )
    rem ファイル名でログファイルパス設定
    set logPath=%~dp0Log\%~n0.log
    rem 実行前ログ出力
    echo %date% %time%>>%logPath%
    echo;>>%logPath%

    rem 分割実行
      : -y      :上書き
      : -i      :対象ファイル
      :          複数指定の場合、「-i」オプションごと記述する
      : -filter~:[入力情報]オプション[定義名]
      :            入力ファイルに適用するオプションを
      :            定義名に格納し、使用可能
      :          →詳細は「ImgCompo.bat」参照
      :          (今回解説:
      :            nullsrc=size=サイズ(縦x横) [定義名];
      :              nullsrc=
      :                カラーソース
      :                他にも「pal75bars」、「rgbtestsrc」等、使用可能
      :              size=サイズ(縦x横)
      :                カラーソースのサイズ指定
      :              [定義名]
      :                任意の定義名
      :              解説
      :                動画貼り付けの基底となる画像を作成
      :            [i:v] setpts=オプション, scale=スケール比(縦:横) [定義名];
      :              [i:v]
      :                 ※i:0始まりの数値
      :                「-i」オプションで指定した動画
      :              setpts=オプション,
      :                再生速度やスタート位置のオプション
      :                PTS-STARTPTS
      :                  入力した映像のptsを指定する
      :              scale=スケール比(縦:横)
      :                貼り付け動画サイズ比
      :              解説
      :                対象の動画をサイズ指定して、開始位置そのままで定義
      :            [基底定義名][対象定義名] overlay=オプション [定義名];
      :              [基底定義名]
      :                貼り付け元となる定義名
      :              [対象定義名]
      :                貼り付け対象動画の定義名
      :              overlay=オプション
      :                オーバレイ用オプション
      :                shortest=値
      :                  0:オフ、1:オン
      :                  基底と対象の内、動画再生時間が短い方の終了に合わせる
      :                動画配置位置(x=数値:y=数値)
      :                  動画の配置位置
      :              解説
      :                一つ目
      :                  ・「nullsrc=～」で指定した基底画像定義名「base」に対して
      :                    動画1の定義名「one」を使用し、「out1」とする
      :                  ・基底画像は再生時間がないため?「shortest」オプションのオンが必須?
      :                  →[base][one] 式 [out1]
      :                二つ目
      :                  ・上記一つ目の「out1」に対して動画2の定義名「two」を使用、
      :                    最後の動画のため定義名は定義しない
      :                  ・動画1が動画2よりも長いことを前提に「shortest」オプションの指定はなし
      :                  →[out0][two] 式
      : -c:v    :動画コーデック
      : -c:a    :音声コーデック
      : -r      :フレームレート
      : -video~ :tbn設定
    %~dp0ffmpeg\win32\ffmpeg.exe -y -i %srcPath% -i %contPath% -filter_complex "nullsrc=size=%baseSize% [base]; [0:v] setpts=PTS-STARTPTS, scale=%v0Scale% [one]; [1:v] setpts=PTS-STARTPTS, scale=%v1Scale% [two]; [base][one] overlay=shortest=1:%v0Point% [out0]; [out0][two] overlay=%v1Point%" -r %rate% -video_track_timescale %tbn% %outPath%


:END
  rem ログ出力
  rem 「=」が存在する変数はリダイレクトが
  rem 出来ないためスペースを付与
  echo %srcPath:"=%>>%logPath%
  echo %contPath:"=%>>%logPath%
  echo %baseSize:"=%>>%logPath%
  echo %v0Scale:"=%>>%logPath%
  echo %v0Point%>>%logPath%
  echo %v1Scale:"=%>>%logPath%
  echo %v1Point%>>%logPath%
  echo %codec:"=%>>%logPath%
  echo %rate:"=%>>%logPath%
  echo %tbn:"=%>>%logPath%
  echo %outPath:"=%>>%logPath%
  echo;>>%logPath%
  echo %date% %time%>>%logPath%
  echo;>>%logPath%
  echo;>>%logPath%

  rem 引数がない(ユーザ入力で実行した)場合、ポーズ
  if %argc%==0 pause

exit /b