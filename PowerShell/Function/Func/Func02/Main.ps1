$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "関数テスト02_メイン"
Write-Host
# 別ファイル呼び出し


<# 共通設定 #>
  # カウンタ初期化
  $counter = 0


<# ファイルごと実行 #>
  Write-Host "-----------------"
    Write-Host "ファイル自体を実行"
    $counter++
    # ファイル実行
    .\GlbFile01.ps1 $counter "str$counter"


<# 起動演算子(&) #>
  # 起動演算子(&)から読み込み
  & "$PSScriptRoot\GlbFunc01.ps1"

  Write-Host "-----------------"
    Write-Host "起動演算子(&)読み込みローカル関数"
    Write-Host "  エラーパターン"
    Write-Host "  ※起動演算子(&)で読み込んだファイルの"
    Write-Host "    ローカル関数は呼び出せない"
    $counter++
    try
    {
      FnLocalAndRead $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "起動演算子(&)読み込みグローバル関数"
    $counter++
    FnGlbAndRead $counter


<# 演算子(.) #>
  # 演算子(.)から読み込み
  . "$PSScriptRoot\GlbFunc02.ps1"

  Write-Host "-----------------"
    Write-Host "演算子(.)ローカル関数"
    Write-Host "  演算子(.)で読み込んだファイルは"
    Write-Host "  ローカル関数も呼び出し可能"
    $counter++
    FnLocalDotRead $counter

  Write-Host "-----------------"
    Write-Host "演算子(.)グローバル関数"
    $counter++
    FnLocalDotRead $counter
