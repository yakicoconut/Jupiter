@echo off
title %~nx0
echo バックアップの差分を作成する


rem 遅延環境変数オン
SETLOCAL ENABLEDELAYEDEXPANSION


: 参照バッチ
  rem 削除バッチ(コピーを行うだけで使用はしない)
  set call_DiffExtra_DelFiles="DelFiles.bat"
  rem コピー先の削除バッチを大文字にするための変数
  set reName_DiffExtra_DelFiles="DELFILES.bat"


: 変数
  rem 識別子
  set identifier=Pla

  rem 先ディレクトリ
  set targetDir01="BackUp_Main"
  set targetDir02="BackUp_Main_DiffSource"
  set targetDir03="BackUp_DiffCheck"
  rem 差分情報ファイル
  set targetFile=DIFFFILES.txt


: 事前処理
  rem 先ディレクトリの「"」を削除
  set targetDir01=%targetDir01:"=%
  set targetDir02=%targetDir02:"=%
  set targetDir03=%targetDir03:"=%

  rem 自身のフォルダパス取得
  set currentDir=%~dp0

  rem 現行処理可視化ファイル名
  set process07=差分作成処理01

  rem 本バッチが単体で使用された場合は現在時刻を取得する
  if "%dateTime01%"=="" (
    rem 現在日時の取得
    set dateTime01=!date:/=!!time: =0!
    set dateTime01=!dateTime01::=!
    set dateTime01=!dateTime01:.=!
    set dateTime01=!dateTime01:~0,17!
  )


: 差分作成
  rem 現行処理可視化ファイル出力
  echo 処理中>%process07%

  rem ねずみ返し_差分情報ファイルがない場合
  if not exist %targetFile% (
    echo;
    echo %targetFile%ファイルがありません
    echo 終了します
    pause

    rem 現行処理可視化ファイル削除
    del %process07%
    exit
  )

  echo;
  echo 差分抽出開始

  rem 差分抽出フォルダ作成
  rem 変数IDENTIFIERは上記で呼び出したバッチ内部で定義される
  set diffDir=BackUp_%identifier%_%dateTime01%
  mkdir %diffDir%

  rem 「/f "delims="」で区切り文字を指定
  rem 「=」後に文字指定がないので改行が区切りとなる
  for /f "delims=" %%a in (%targetFile%) do (
    rem 「"tokens="」で指定インデックスを取り出し
    for /f "tokens=1,2 delims=	" %%b in ("%%a") do (
      rem 事前処理
      rem スペース除去
      set preFix=%%b
      set preFix=!preFix: =!
      rem 変数初期化
      set delTarget=""
      set upTarget=""

      rem ねずみ返し_対象外
      if "!preFix!"=="" (
        echo 対象外
        rem 次のループへ
      ) else (

        rem 削除ファイルの場合、削除フォルダのパスを削除
        set delTarget=%%c
        set delTarget=!delTarget:%currentDir%%targetDir02%=!
        set delTarget=!delTarget:%currentDir%%targetDir03%=!

        rem 削除ファイル
        if !preFix!==*EXTRAFile (
          echo 削除ファイル
          echo !delTarget!>>DELTARGET.txt
        ) else (

          rem 削除フォルダ
          if !preFix!==*EXTRADir (
            echo 削除フォルダ
            echo !delTarget!>>DELTARGET.txt
          ) else (

            rem 削除ファイルでない場合、元フォルダのパスを削除
            set upTarget=%%c
            set upTarget=!upTarget:%currentDir%%targetDir01:"=%=!

            rem 更新ファイル
            if !preFix!==より新しい (
              echo 更新ファイル
              echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
            ) else (

              rem 更新ファイル
              if !preFix!==新しい (
                echo 更新ファイル
                echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
              ) else (

                rem 作成フォルダ
                if !preFix!==新しいディレクトリ (
                  echo 作成フォルダ
                  rem xcopyでは2階層以上の新規フォルダを作成できないためmkdirを使用
                  mkdir "%diffDir%!upTarget!"
                ) else (

                  rem 作成ファイル
                  if !preFix!==新しいファイル (
                    echo 作成ファイル
                    echo f | xcopy "%targetDir01%!upTarget!" "%diffDir%!upTarget!" /y /h
                  )
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

  rem 処理対象一覧をフォルダに含める
  move %targetFile% %diffDir%

  rem 削除対象ファイル一覧がある場合
  rem 削除バッチと削除対象ファイル一覧をフォルダに含める
  if exist DELTARGET.txt (
    rem 削除関連ファイルの移動/コピー
    copy %call_DiffExtra_DelFiles% %diffDir%
    move DELTARGET.txt %diffDir%

    rem 削除バッチを大文字に変更する
    ren %diffDir%\%call_DiffExtra_DelFiles% %reName_DiffExtra_DelFiles%
  )

  rem 現行処理可視化ファイル削除
  del %process07%


: 事後処理
  rem 終了時刻の取得
  set datetime02=%date:/=%%time: =0%
  set datetime02=%datetime02::=%
  set datetime02=%datetime02:.=%
  set datetime02=%datetime02:~0,17%

  rem 終了時刻出力
  echo %dateTime01%>>%diffDir%\%dateTime01%
  echo %datetime02%>>%diffDir%\%dateTime01%