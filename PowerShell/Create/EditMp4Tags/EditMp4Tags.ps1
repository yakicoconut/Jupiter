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
    Write-Host $x.name


    # # 設定取得
      $title    = $csv[$ind].タイトル
      $artist   = $csv[$ind].参加アーティスト
      $album    = $csv[$ind].アルバム
      $tracknum = $csv[$ind].トラック番号
      $genre    = $csv[$ind].ジャンル
      $artwork  = $csv[$ind].アートワーク
      # 空の場合、「UNKNOWN」とする
      if($title -eq "")   { $title = "UNKNOWN" }
      if($artist -eq "")  { $artist = "UNKNOWN" }
      if($album -eq "")   { $album = "UNKNOWN" }
      if($tracknum -eq ""){ $tracknum = "UNKNOWN" }
      if($genre -eq "")   { $genre = "UNKNOWN" }


    # # コマンド実行
      # アートワーク設定がない場合
      if($artwork -eq "") {
        .\AtomicParsley\win32-0.9.0\AtomicParsley.exe `
        $x.FullName                                   `
        --overWrite                                   `
        --title     $title                            `
        --artist    $artist                           `
        --album     $album                            `
        --tracknum  $tracknum                         `
        --genre     $genre
      } else {
        .\AtomicParsley\win32-0.9.0\AtomicParsley.exe `
        $x.FullName                                   `
        --overWrite                                   `
        --title     $title                            `
        --artist    $artist                           `
        --album     $album                            `
        --tracknum  $tracknum                         `
        --genre     $genre                            `
        --artwork   $artwork
      }
  }