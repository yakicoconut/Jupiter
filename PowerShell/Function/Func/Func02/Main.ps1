$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "関数テスト02_メイン"
Write-Host
# 別ファイル関数呼び出し


<# 起動演算子(&)から読み込み #>
  # 関数ファイル読み込み
  & "$PSScriptRoot\GlbFunc01.ps1"

  try
  {
    Write-Host "エラーパターン"
    Write-Host "※読み込み済み関数ファイルローカル関数呼び出し"
    # テストローカル関数01使用
    Test01 "abc"
  }
  catch
  {
    # エラー内容
    Write-Host "  $error[0]"
    Write-Host
  }

  # テストグローバル関数02使用
  Test02 "def"


<# 演算子(.)から読み込み #>
  Write-Host
  # 関数ファイル読み込み
  . "$PSScriptRoot\GlbFunc02.ps1"

  # テストローカル関数03使用
  # 「.」を使用してファイル呼び出しした場合、
  # ローカルメンバの参照も可能
  Test03 "abc"

  # テストグローバル関数04使用
  Test04 "def"