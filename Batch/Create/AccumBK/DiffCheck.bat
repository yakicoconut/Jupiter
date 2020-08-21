@echo off
title %~nx0
echo 累積差分バックアップの漏れをチェックする


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 事前
  rem 先ディレクトリ
  set targetDir01=BackUp_Main
  set targetDir02=BackUp_DiffCheck
  rem ねずみ返し_対象が存在しない場合
  if not exist %targetDir01% (
    echo;
    echo %targetDir01%フォルダが存在しません
    echo 終了します
    pause
    exit
  )
  if not exist %targetDir02% (
    echo;
    echo %targetDir02%フォルダが存在しません
    echo 終了します
    pause
    exit
  )

: 事前処理
  rem 現在日時の取得
  set datetime=%date:/=%%time: =0%
  set datetime=%datetime::=%
  set datetime=%datetime:.=%
  set datetime=%datetime:~0,17%

  rem 差分情報ファイル名
  set diffCheckFile=DIFFFILES_%datetime%.txt


: 比較処理
  rem 差分ファイル情報取得
  rem /l:ログのみ、/njh:ヘッダ除去、/njs:フッダ除去、/ns:サイズ除去、/fp:完全パス
  robocopy "%targetDir01%" "%targetDir02%" /mir /l /njh /njs /ns /fp>%diffCheckFile%


: 差分チェック
  rem 「/f "delims="」で区切り文字を指定
  rem 「=」後に文字指定がないので改行が区切りとなる
  for /f "delims=" %%a in (%diffCheckFile%) do (
    rem 「"tokens="」で指定インデックスを取り出し
    for /f "tokens=1,2 delims=	" %%b in ("%%a") do (
      rem 事前処理
      rem スペース除去
      set prefix=%%b
      set prefix=!prefix: =!
      rem 変数初期化
      set delTarget=""
      set upTarget=""

      rem ねずみ返し_対象外
      if "!prefix!"=="" (
        rem 次のループへ
      ) else (

        rem 削除ファイルの場合、削除フォルダのパスを削除
        set delTarget=%%c
        set delTarget=!delTarget:%myDir%%targetDir02%=!

        rem 削除ファイル
        if !prefix!==*EXTRAFile (
          echo;
          echo チェックフォルダとの間に差異があります
          echo %diffCheckFile%を確認してください
          pause
          exit
        ) else (

          rem 削除フォルダ
          if !prefix!==*EXTRADir (
            echo;
            echo チェックフォルダとの間に差異があります
            echo %diffCheckFile%を確認してください
            pause
            exit
          ) else (

            rem 削除ファイルでない場合、元フォルダのパスを削除
            set upTarget=%%c
            set upTarget=!upTarget:%myDir%%targetDir01:"=%=!

            rem 更新ファイル
            if !prefix!==より新しい (
              echo;
              echo チェックフォルダとの間に差異があります
              echo %diffCheckFile%を確認してください
              pause
              exit
            ) else (

              rem 作成フォルダ
              if !prefix!==新しいディレクトリ (
                echo;
                echo チェックフォルダとの間に差異があります
                echo %diffCheckFile%を確認してください
                pause
                exit
              ) else (

                rem 作成ファイル
                if !prefix!==新しいファイル (
                  echo;
                  echo チェックフォルダとの間に差異があります
                  echo %diffCheckFile%を確認してください
                  pause
                  exit
                )
              )
            )
          )
        )
      )
rem ループモニタ
rem pause
    )
  )

echo;
echo チェック完了
pause


: 事後処理
  del %diffCheckFile%