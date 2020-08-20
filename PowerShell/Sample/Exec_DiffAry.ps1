using module "..\OwnLib\DiffAry.psm1"
# # 配列差分取得関連クラス使用例

# タイトル設定
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 致命的でないエラーで処理終了設定
$ErrorActionPreference = "Stop"


<# 事前準備 #>
  # 対象配列
  $tgtAry = @("B", "C", "D")
  # 比較配列
  $compAry = @("A", "B", "E", "F", "G")

<# 使用例 #>
  # 配列差分取得関連クラスインスタンス生成
  $diffAryClass = [DiffAryClass]::new()

  # # 配列欠如抽出メソッド
    $lack = $diffAryClass.LackDiff($tgtAry, $compAry)
    Write-Host $lack