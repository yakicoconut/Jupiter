$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# フィルタ


<# 文字列フィルタ #>
filter StrFillter
{
  # 変数「_」に配列内容が渡される
  if ( $_ -eq "def" )
  {
    return $_
  }
}


<# メイン #>
  # 配列作成
  $ary = @("abc", "def", "ghi")
  
  # 文字列フィルタ使用
  $var = $ary | StrFillter
  Write-Host $var