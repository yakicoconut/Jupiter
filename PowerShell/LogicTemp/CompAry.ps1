$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# 配列比較


<# 配列比較例関数 #>
  # # 配列比較例関数
  #   引数01:対象配列
  #   引数02:比較配列
  #   返り値:なし
  function CompAry($tgtAry, $compAry)
  {
    # # 差分
      # 対象配列のうち、比較配列に存在しないものを取得
      # サイト
      #   PowerShell で配列の値が別の配列に含まれるかどうかを調べる
      #   	https://mseeeen.msen.jp/powershell-check-existance-of-elements-in-array/
  
      # 比較配列にないものを取得
      $missing = $tgtAry | Where-Object { $compAry -notcontains $_ }
      Write-Host "-----------------"
      Write-Host "差分"
      Write-Host "  比較配列には「C」と「D」が存在しない"
      $missing
      Write-Host

    # # 集合
      # 集合関連
      # サイト
      #   Powershellで配列の使い方まとめ。初期化、要素追加、比較の方法まで！ | ぶろぐらまー
	    #   	https://bgt-48.blogspot.com/2018/04/powershell.html#%EF%BC%92%E3%81%A4%E3%81%AE%E9%85%8D%E5%88%97%E3%81%AE%E9%9B%86%E5%90%88%EF%BC%88%E5%92%8C%E9%9B%86%E5%90%88%E3%80%81%E5%B7%AE%E9%9B%86%E5%90%88%E3%80%81%E7%A9%8D%E9%9B%86%E5%90%88%EF%BC%89%E3%82%92%E5%8F%96%E5%BE%97

      # 和集合(Sort-Object -Unique使用)
      $unionUnique = $tgtAry + $compAry | Sort-Object -Unique
      Write-Host "-----------------"
      Write-Host "和集合(Sort-Object -Unique使用)"
      Write-Host "  双方の値をまとめる"
      $unionUnique
      Write-Host

      # 和集合(Compare-Object使用)
      $unionComp = Compare-Object $tgtAry $compAry -IncludeEqual | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "和集合(Compare-Object使用)"
      $unionComp
      Write-Host

      # 積集合
      $Intersection = Compare-Object $tgtAry $compAry -IncludeEqual -ExcludeDifferent | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "積集合"
      Write-Host "  両方で一致するもの"
      $Intersection
      Write-Host

      # 差集合
      $diff = Compare-Object $tgtAry $compAry | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "差集合"
      Write-Host "  積集合でないもの"
      $diff
      Write-Host
  }


<# メイン #>
  # # 設定
    # 対象配列
    $tgtAry = @("B", "C", "D")
    # 比較配列
    $compAry = @("A", "B", "E", "F", "G")

    Write-Host "-----------------"
    Write-Host "対象配列"
    $tgtAry
    Write-Host
    Write-Host "-----------------"
    Write-Host "比較配列"
    $compAry
    Write-Host

  # 配列比較例関数使用
  CompAry $tgtAry $compAry