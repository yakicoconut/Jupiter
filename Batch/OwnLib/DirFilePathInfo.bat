@echo off
title %~nx0
: ディレクトリファイル情報バッチ
: 引数01:対象ディレクトリファイルパス
: 引数02:パス情報選択(下記参照)
: 引数03:上層フォルダ取得(第二引数がup)のときに使用
:        デフォルトは1階層上を取得
: 戻値:ディレクトリファイル情報


rem 変数ローカル化
SETLOCAL ENABLEDELAYEDEXPANSION
  : 引数例
    : 対象パス:C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : ~   :C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : f   :C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : d   :C:
    : p   :\Program Files\Java\jre1.8.0_144\
    : n   :Welcome
    : x   :.html
    : s   :C:\PROGRA~1\Java\JRE18~2.0_1\WELCOM~1.HTM
    : a   :--a------
    : t   :2017/09/08 20:51
    : z   :955
    : dp  :C:\Program Files\Java\jre1.8.0_144\
    : nx  :Welcome.html
    : fs  :C:\PROGRA~1\Java\JRE18~2.0_1\WELCOM~1.HTM
    : ftza:--a------ 2017/09/08 20:51 955 C:\Program Files\Java\jre1.8.0_144\Welcome.html
    : up 1:jre1.8.0_144
    : up 2:Java


  : 引数
    rem デフォルトでは引数をそのまま設定
    set dirFilePathInfo=%1

    rem ねずみ返し_第二引数がない場合、即終了
    if "%2"=="" goto END

    rem 第二引数を「"」抜きで設定
    set option=%~2

    rem 第三引数に 値がない場合
    if "%3"=="" (
      rem 「1」に設定
      set /a upCount=1
    ) else (
      rem 「"」抜きで設定
      set /a upCount=%~3
    )


    rem 第二引数が「~」の場合、「"」削除
    if %option%==~ set dirFilePathInfo=%~1
    rem 完全修飾パス名
    if %option%==f set dirFilePathInfo=%~f1
    rem ドライブ文字
    if %option%==d set dirFilePathInfo=%~d1
    rem ドライブ文字を抜いた一つ上のフォルダパス
    if %option%==p set dirFilePathInfo=%~p1
    rem ファイル名のみ
    if %option%==n set dirFilePathInfo=%~n1
    rem 拡張子
    if %option%==x set dirFilePathInfo=%~x1
    rem 短い名前
    if %option%==s set dirFilePathInfo=%~s1
    rem 属性
    if %option%==a set dirFilePathInfo=%~a1
    rem 日付/時刻
    if %option%==t set dirFilePathInfo=%~t1
    rem サイズ
    if %option%==z set dirFilePathInfo=%~z1
    rem ライブ文字とパス
    if %option%==dp set dirFilePathInfo=%~dp1
    rem ファイル名と拡張子
    if %option%==nx set dirFilePathInfo=%~nx1
    rem 完全なパスと短い名前
    if %option%==fs set dirFilePathInfo=%~fs1
    rem dirコマンド出力
    if %option%==ftza set dirFilePathInfo=%~ftza1
    rem 自作引数_フォルダ名(第三引数使用)
    if %option%==up (
      rem ループカウント初期化
      set /a loopCount=0

      rem 指定階層分上のフォルダをループで取得
      :UPLOOP
        rem フォルダパス(一つ上の\まで)取得
        set dirFilePathInfo=%~p1
        rem 末尾の「\」マーク除去
        set dirFilePathInfo=!dirFilePathInfo:~0,-1!

        rem ループカウントアップ
        set /a loopCount+=1
        rem ループ回数が満たされれば終了
        if not !loopCount!==!upCount! call :UPLOOP "!dirFilePathInfo!""

      rem パス最下層のフォルダ名取得
      for /f "delims=" %%a in ("!dirFilePathInfo!") do set dirFilePathInfo=%%~nxa
    )


:END
  rem 処理無し

rem 戻り値
ENDLOCAL && set return_DirFilePathInfo=%dirFilePathInfo%
exit /b