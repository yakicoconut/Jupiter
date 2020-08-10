$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 正規表現


<# 正規表現使用関数 #>
  # # 正規表現使用関数
  #   引数01:検索対象文字列
  #   引数02:正規表現文字列
  #   返り値:
  function ExecMatch
  {
    # 引数設定
    param ($tgtStr, $reg)
    Write-Host "-----------------"
    Write-Host $tgtStr
    Write-Host $reg

    # 致命的でないエラー発生
    "$tgtStr" -match "$reg"

    $Matches
  }


<# Continue(規定値) #>
  $tgt = "abcdef"
  ExecMatch $tgt "(.)(.)"
  # $tgt -match "(.)(.)"
  # $Matches