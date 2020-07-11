$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得
# 取得対象要素ベタ書き


<# 設定 #>
  # 対象ファイル
  $tgtXmlPath = ".\TestXml\TestXml01_Utf8.xml"
  # エンコ
  $enc = "UTF8"


<# XML取得 #>
  # # 準備
    # XML設定値エラーフラグ
    $errFlg = $true

  # # XML読み込み
    $tgtXml = [XML](Get-Content -Encoding $enc $tgtXmlPath)

  # # ルート要素取得
    # 「root」要素内の「B」要素取得
    $tgtRoot = $tgtXml.root.B
    # ねずみ返し
    if ($tgtRoot -eq $null)
    {
      Write-Host 指定したXMLルートが取得できていません
      Write-Host 終了します
      return
    }

  # # 要素取得
    # 「い」属性内容全取得
    $tgtAttr_1 = $tgtRoot.い
    # 「は」属性内容全取得
    $tgtAttr_2 = $tgtRoot.は

    # 対象要素のインデックス取得
    $tgtAttrId_1 = [Array]::IndexOf($tgtAttr_1, 'ろ')
    $tgtAttrId_2 = [Array]::IndexOf($tgtAttr_2, 'に')
    # 値取得
    # インデックスが「-1」の場合、エラーフラグを立てる
    $valAttr_1 = if ($tgtAttrId_1 -eq -1){ $errFlg= $false } else { Write-Output $tgtAttr_1[$tgtAttrId_1] }
    $valAttr_2 = if ($tgtAttrId_2 -eq -1){ $errFlg= $false } else { Write-Output $tgtAttr_2[$tgtAttrId_2] }


<# 値表示 #>
  # Xml設定値エラーでない場合
  if ($errFlg)
  {
    Write-Host $valAttr_1
    Write-Host $valAttr_2
  }