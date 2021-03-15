$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo メディアファイルのプロパティをCSVファイルから取得して編集する
# 編集できる拡張子は.mp3のみ
# それ以外の拡張子に無理やり実行するとファイル破損する
# ライブラリTagLib使用
#   TagLib
#   	http://taglib.org/
# Using PowerShell to edit MP3 tags - Todd Klindt's Office 365 Admin Blog
# 	https://www.toddklindt.com/blog/Lists/Posts/Post.aspx?ID=468
# taglib-sharp.dll Download for missing file error _ dll-found.com
# 	http://www.dll-found.com/taglib-sharp.dll_download.html


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
  $items = @(Get-ChildItem -LiteralPath $targetRootPath -Recurse -File)
  # CSVファイル読み込み
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default

  # 外部dll「taglib-sharp.dll」の読み込み
  [Reflection.Assembly]::LoadFrom( (Resolve-Path ".\tablib\taglib-sharp.dll"))


<# 本処理 #>
  foreach($x in $items)
  {
    # 相対パス変換
    $tgtName = $x.FullName.Replace($targetRootPath + "\","")

    # 要素順位検索(最初のもののみ、なければ「-1」)
    $ind = [Array]::IndexOf($csv.対象ファイル名, $tgtName)

    # ねずみ返し_CSVに設定がない場合
    if ($ind -eq -1)
    {
      continue
    }

    # 対象表示
    Write-Host $tgtName


    # # 拡張子変更
      # 変数初期化
      $ext = ""
      $newFileName = ""

      # 対象パス取得
      $targetPath = $x.FullName

    # taglib-sharp.dllは.mp3のみ対応なので
      # 拡張子が.mp3じゃない場合、一時的に拡張子を.mp3に変更する
      if ($x.Extension -ne ".mp3")
      {
        # 拡張子退避
        $ext = $x.Extension

        # 変更後ファイル名取得
        $newFileName = [System.IO.Path]::ChangeExtension($targetPath, ".mp3")

        # 変更
        Rename-Item $targetPath $newFileName

        # 新パスを変数に格納
        $targetPath = $newFileName
      }

      # 対象ファイルの読み込み
      $media = [TagLib.File]::Create((resolve-path -LiteralPath $targetPath))
      # # とりあえず表示_全タグ
      # Write-Host $media.tag


    # # 対象プロパティの設定
      $media.Tag.Title = $csv[$ind].タイトル
      $media.Tag.Artists = $csv[$ind].参加アーティスト
      $media.Tag.Album = $csv[$ind].アルバム
      $media.Tag.Track = $csv[$ind].トラック番号
      $media.Tag.Genres = $csv[$ind].ジャンル
      # ジャケットの値がある場合
      if ($csv[$ind].ジャケット -ne "")
      {
        # ジャケットはピクテゃに変換
        $pic = [taglib.picture]::createfrompath($targetRootPath + "\" + $csv[$ind].ジャケット)
        $media.Tag.Pictures  = $pic
      }

      # 保存
      $media.Save()


    # # 拡張子が変更された場合
      if ($ext -ne "")
      {
        # 変更後ファイル名作成
        $newFileName = [System.IO.Path]::ChangeExtension($targetPath, $ext)
        # 拡張子を戻す
        Rename-Item $targetPath $newFileName
      }
  }