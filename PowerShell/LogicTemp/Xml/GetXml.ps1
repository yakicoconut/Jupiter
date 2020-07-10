$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得


<# 設定 #>
  # Xml設定値エラーフラグ
  $errFlg = $true


<# Xml取得 #>
  $tgtXml = [XML](Get-Content ".\TestXml\TestXml01.xml")
  # 「root」要素内の「B」要素取得
  $tgtXmlRootB = $tgtXml.root.B
  # 「い」属性内容全取得
  $tgtXmlRootBAttr_1 = $tgtXmlRootB.い
  # 「は」属性内容全取得
  $tgtXmlRootBAttr_2 = $tgtXmlRootB.は

  # 対象要素のインデックス取得
  $idRootBAttr_1 = [Array]::IndexOf($tgtXmlRootBAttr_1, 'ろ')
  $idRootBAttr_2 = [Array]::IndexOf($tgtXmlRootBAttr_2, 'に')
  # 値取得
  # インデックスが「-1」の場合、エラーフラグを立てる
  $rootBAttr_1 = if ($idRootBAttr_1 -eq -1){ $errFlg= $false } else { Write-Output $tgtXmlRootBAttr_1[$idRootBAttr_1] }
  $rootBAttr_2 = if ($idRootBAttr_2 -eq -1){ $errFlg= $false } else { Write-Output $tgtXmlRootBAttr_2[$idRootBAttr_2] }


<# 値表示 #>
  # Xml設定値エラーでない場合
  if ($errFlg)
  {
    Write-Host $rootBAttr_1
    Write-Host $rootBAttr_2
  }