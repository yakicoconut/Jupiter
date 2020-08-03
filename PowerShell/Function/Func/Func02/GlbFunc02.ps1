$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# "グローバル関数ファイル02"


<# 文字コード用コメント #>
  # この位置に「<##>」形式のコメントがないと
  # VSCodeがSJISで自動判別してくれない?


<# ローカル関数 #>
  # # ローカル関数
  #   引数01:型指定なし
  #   返り値:なし
  function FnLocalDotRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


# テストグローバル関数04
#   引数01:
#   返り値:
function global:FnGlbDotRead ($arg01)
{
  Write-Host
  Write-Host $arg01
  Write-Host
}


