$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# "グローバル関数ファイル01"


<# 文字コード用コメント #>
  # この位置に「<##>」形式のコメントがないと
  # VSCodeがSJISで自動判別してくれない?


<# ローカル関数 #>
  # # 起動演算子(&)読み込みローカル関数
  #   引数01:型指定なし
  #   返り値:なし
  function FnLocalAndRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


<# グローバル関数 #>
  # 起動演算子(&)読み込みグローバル関数
  #   引数01:型指定なし
  #   返り値:なし
  function global:FnGlbAndRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


