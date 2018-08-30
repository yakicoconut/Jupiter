$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo メディアファイルのプロパティをCSVファイルに出力する
#


<# ユーザ入力 #>
  Write-Host 対象フォルダ入力
  $USR = (Read-Host 入力してください)
  # 先頭文末ダブルクォーテーション削除
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetRootPath = $USR


<# 事前処理 #>
  # シェルインスタンス生成
  $sh = New-Object -ComObject Shell.Application
  # 対象ファイル取得
  $items = Get-ChildItem -Path $targetRootPath -Recurse
  # 出力ファイル名
  $outFileName = "CsvOutSample.csv"
  # 出力用カスタムオブジェクト配列
  $outCsvs = @()


<# 本処理 #>
  # ファイルループ
  foreach($x in $items)
  {
    # ねずみ返し_対象の拡張子が.mp3でない場合
    if ($x.Extension -ne ".mp3")
    {
      continue
    }

    # 親フォルダ取得
    $pathName = Split-Path $x.FullName -Parent
    # 親フォルダから名前空間取得
    $folder = $sh.Namespace($pathName)
    # 名前空間からパース
    $file = $folder.ParseName($x.Name)

    # # とりあえず表示
    # # ファイル名
    # Write-Host $folder.GetDetailsOf($file, 0)
    # Write-Host "トラック番号    :"$folder.GetDetailsOf($file, 26).PadLeft(2, "0")
    # Write-Host "タイトル        :"$folder.GetDetailsOf($file, 21)
    # Write-Host "アルバム        :"$folder.GetDetailsOf($file, 14)
    # Write-Host "参加アーティスト:"$folder.GetDetailsOf($file, 13)
    # Write-Host "長さ            :"$folder.GetDetailsOf($file, 27)
    # Write-Host "サイズ          :"$folder.GetDetailsOf($file, 1)
    # Write-Host "ジャンル        :"$folder.GetDetailsOf($file, 16)

    # 配列データからカスタムオブジェクト作成
    $obj = [PSCustomObject]@{
      FileName = $folder.GetDetailsOf($file, 0)
      Title = $folder.GetDetailsOf($file, 21)
      Artists = $folder.GetDetailsOf($file, 13)
      Album = $folder.GetDetailsOf($file, 14)
      Track = $folder.GetDetailsOf($file, 26)
      Genres = $folder.GetDetailsOf($file, 16)
    }
    $outCsvs += $obj
  }

  # CSV出力
  $outCsvs | Export-Csv $outFileName -Encoding Default -NoTypeInformation