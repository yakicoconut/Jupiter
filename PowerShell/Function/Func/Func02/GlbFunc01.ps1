$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "グローバル関数ファイル01"
Write-Host


<# ローカル関数 #>
  # # テスト関数01
  #   引数01:
  #   返り値:
  function Test01 ($arg01)
  {
    Write-Host "テスト関数01_ローカル"
    Write-Host $arg01
    Write-Host
  }


# テストグローバル関数02
#   引数01:
#   引数02:
#   返り値:
function global:Test02
{
  param ([string]$arg01)
  Write-Host "テスト関数02_グローバル"
  Write-Host $arg01
  Write-Host
}


