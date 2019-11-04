@echo off
title %~nx0
rem ゼロ埋めバッチ
rem 引数01:対象値
rem 引数02:桁数(「-」始まりの場合、下駄モード)
rem 戻値  :ゼロ処理後値


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION
  : 引数
    rem 対象値
    set value=%1
    rem 桁数
    set pad=%2

    rem ゼロ埋めモードフラグ初期化
    set padFlg=0
    rem 下駄モードの場合
    if %pad:~0,1%==- (
      rem 「-」除去
      set pad=%pad:~1%
      rem ゼロ埋めモードフラグオフ
      set padFlg=1
    )

  : 指定桁分の変数を作成
    set pad_num=
    for /L %%i in (1, 1, %pad%) do (
      set pad_num=0!pad_num!
    )

  : 値作成
    rem ゼロ埋めモードの場合
    if %padFlg%==0 (
      rem 作成した桁数分の0の後ろに対象値を結合
      set num=!pad_num!%value%
      rem 指定桁数分を後ろから取得
      set num=!num:~-%pad%!
    ) else (
      rem 下駄モード
      set num=%value%!pad_num!
      set num=!num:~0,%pad%!
    )


rem 戻り値
ENDLOCAL && set return_ZeroPadding=%num%
exit /b