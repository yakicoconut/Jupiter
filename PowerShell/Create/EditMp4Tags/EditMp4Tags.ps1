$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo .mp4ファイルのタグプロパティをCSVファイルから取得して編集する
# メモ
#  ・アートワーク
#    対象ファイルが存在しない場合、AtomicParsley.exeが落ちる
#    設定後に画像ファイルを削除しても動画に設定した画像は固定される
#
# サイト
#   AACのタグ解析 - 亀岡的プログラマ日記
#     http://posaune.hatenablog.com/entry/20091212/1260628232
#   AtomicParsley
#     http://www.xucker.jpn.org/keyword/atomicparsley.html
#   iPod touchでビデオの視聴制限: アイスティーを飲みながら...
#     http://iced.tea-nifty.com/lemon/2008/09/ipod-touch-a3ec.html


<# ユーザ入力 #>
  Write-Host 対象フォルダ入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetRootPath = $USR

  Write-Host ""
  Write-Host 対象CSV入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetCsvPath = $USR


<# 事前処理 #>
  # ファイル情報を配列で取得
  $items = @(Get-ChildItem $targetRootPath -Recurse)
  # CSVファイル読み込み
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default
  # バッチ実行パス退避
  $wkDir = Convert-Path .
  # CSVのフォルダにカレントディレクトリ変更
  cd (Split-Path $targetCsvPath -parent)


<# 本処理 #>
  foreach($x in $items)
  {
    # 要素順位検索(最初のもののみ、なければ「-1」)
    $ind = [Array]::IndexOf($csv.対象ファイル名, $x.name)
    # ねずみ返し_CSVに設定がない場合
    if ($ind -eq -1)
    {
      continue
    }

    # 対象表示
    Write-Host
    Write-Host $x.name

    # # 設定取得
      # 引数変数初期化
      $artwork = ""

      # 引数取得
      $title    = $csv[$ind].タイトル
      $artist   = $csv[$ind].参加アーティスト
      $album    = $csv[$ind].アルバム
      $tracknum = $csv[$ind].トラック番号
      $genre    = $csv[$ind].ジャンル
      # アートワークファイルが存在する場合
      if(Test-Path $csv[$ind].アートワーク)
      {
        $artwork  = $csv[$ind].アートワーク
      }
      # オプション引数用変数初期化
      $optionTitle    = ""
      $optionArtist   = ""
      $optionAlbum    = ""
      $optionTracknum = ""
      $optionGenre    = ""
      $optionArtwork  = ""
      # 要素が空でない場合、オプション引数を設定
      if($title -ne "")   { $optionTitle    = "--title"    }
      if($artist -ne "")  { $optionArtist   = "--artist"   }
      if($album -ne "")   { $optionAlbum    = "--album"    }
      if($tracknum -ne ""){ $optionTracknum = "--tracknum" }
      if($genre -ne "")   { $optionGenre    = "--genre"    }
      if($artwork -ne "") { $optionArtwork  = "--artwork"  }

    # # コマンド実行
      &($wkDir + "\AtomicParsley\win32-0.9.0\AtomicParsley.exe") $x.FullName --overWrite $optionTitle $title $optionArtist $artist $optionAlbum $album $optionTracknum $tracknum $optionGenre $genre $optionArtwork $artwork
  }