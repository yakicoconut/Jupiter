$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得_名前空間あり


<# 設定 #>
  # 対象XMLパス
  $tgtXmlPath = ".\TestXml\TestXml02.xml"
  # エンコ
  $enc = "UTF8"
  # 名前空間変数設定
  $nsAlias = "ns"
  # 名前空間指定
  $nameSpace = "http://www.zzz.com/yyy/xxx.xsd"
  # XPath指定
  $xPath = "settings"


<# Xml取得 #>
  # # XML読み込み
    $tgtXml = [xml](Get-Content -Encoding $enc $tgtXmlPath)

    # 名前空間オブジェクト生成
    $ns = New-Object Xml.XmlNamespaceManager $tgtXml.NameTable
    $ns.AddNamespace($nsAlias, $nameSpace)

  # # ルート要素取得
    # 要素名をxPathで検索
    $tgtRoot = $tgtXml.SelectNodes("$nsAlias" + ":" + $xPath, $ns)
    # # 別解
    # $tgtRoot = $tgtXml.SelectNodes("$($nsAlias):settings", $ns)
    # ねずみ返し
    if ($tgtRoot -eq $null)
    {
      Write-Host 指定したXMLルートが取得できていません
      Write-Host 終了します
      return
    }

  # # 要素取得
    # setting要素取得
    $rootSetting = $tgtRoot.setting
    # key属性取得
    $rootSettingKey = $rootSetting.key
    # value属性取得
    $rootSettingValue = $rootSetting.value


<# 値表示 #>
  Write-Host $rootSettingKey[1]
  Write-Host $rootSettingValue[2]