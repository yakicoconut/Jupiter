$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "グローバル関数ファイル02"
Write-Host


<# ローカル関数 #>
  # # テスト関数03
  #   引数01:
  #   返り値:
  function Test03 ($arg01)
  {
    Write-Host "テスト関数03_ローカル"
    Write-Host $arg01
    Write-Host
  }


# テストグローバル関数04
#   引数01:
#   引数02:
#   返り値:
function global:Test04
{
  param ([string]$arg01)
  Write-Host "テスト関数04_グローバル"
  Write-Host $arg01
  Write-Host
}


