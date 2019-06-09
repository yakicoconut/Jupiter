@echo off
title %~nx0
echo 最新数値ファイル名取得


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 宣言
  rem 指定拡張子
  set exst=.html
  rem コピーもとファイル
  set copySource=_x.html


: 出力ファイル名作成
  rem 指定拡張子のファイル名昇順最後のみ取得
  for /F "tokens=1* delims=" %%a in ('dir /b /o n *%exst%') do set fileName=%%a

  rem 拡張子除去
  set remExstName=!fileName:%exst%=!

  : 先頭「0」退避
    rem 先頭一文字取得
    set lead=%remExstName:~0,1%

    rem 「0」の場合
    if %lead%==0 (
      rem 退避
      set evaZero=%lead%
      rem 先頭を抜いた部分取得
      set /a remExstName=%remExstName:~1%
    )

    rem 出力ファイル名(+1したもの)
    set /a numOutFileName=%remExstName%+1

    rem 出力ファイル名作成
    set outFileName=%evaZero%%numOutFileName%%exst%


: コピー実行
  rem ファイル名表示
  echo %fileName% → %outFileName%

  rem コピーもとファイルを出力ファイル名でコピー
  copy %copySource% %outFileName%


pause