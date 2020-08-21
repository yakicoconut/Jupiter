. ".\Tools\GetHashList.ps1"
. ".\Tools\ExtraHashDiff.ps1"
# # ファイル差分抽出
# サイト
#   Copy-itemを使ったディレクトリコピーはしないほうが無難なのでは、という話 - mk_55's diary
#   	https://mk-55.hatenablog.com/entry/2016/09/19/155051
#   Copy-Item -Recurse の振舞
#   	http://www.vwnet.jp/Windows/PowerShell/copy/Copy-Recurse.htm
#   powershellのクロージャを理解する - Qiita
#   	https://qiita.com/jca02266/items/ad35844ca6fcd2103185

# タイトル設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


<# 事前準備 #>
  # # 設定
    # 対象フォルダ
    $tgtRoot = "D:\_Git\Cal_Bare"
    # ファイルハッシュ一覧CSV名
    $outFileName = "HashList.csv"
    # 前回識別子
    $preIdentifier = "_PRE"
    # コピー先フォルダパス設定
    $crDateTime = "_" + (Get-Date -Format "yyyyMMddHHmmss")
    $copyDist = "Diff" + $crDateTime

  # # 動的設定
    # ねずみ返し_対象フォルダが存在しない場合
    if (!(Test-Path($tgtRoot)))
    {
      Write-Host "$tgtRoot が存在しません"
      Write-Host "終了します"
      exit
    }
    # 既存ハッシュ一覧ファイル存在確認
    $isExistPreFile = Test-Path($outFileName)


<# メイン #>
  # # ファイルハッシュ一覧作成
    # 差分比較用ハッシュ一覧作成関数使用
    Cre8DiffHashList $isExistPreFile $tgtRoot $outFileName $preIdentifier

    # 既存ハッシュ一覧ファイルが存在しない場合
    if (!$isExistPreFile)
    {
      Write-Host "差分全コピー"
      # 対象フォルダごとコピー
      Copy-Item $tgtRoot $copyDist -Recurse
      # CSVコピー
      Copy-Item $outFileName $copyDist
      exit
    }

  # # 差分コピー
    # ハッシュ差分抽出関数使用
    ExtraDiffFromHash $outFileName ([System.IO.Path]::GetFileNameWithoutExtension($outFileName) + "_PRE" + [System.IO.Path]::GetExtension($outFileName)) $tgtRoot $copyDist