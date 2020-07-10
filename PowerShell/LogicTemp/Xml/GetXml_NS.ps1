$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得_名前空間あり


<# 設定 #>
  # 対象XMLパス
  $tgtXmlPath = ".\TestXml\TestXml02.xml"
  # 名前空間変数設定
  $nsAlias = "ns"
  # 名前空間指定
  $nameSpace = "http://www.zzz.com/yyy/xxx.xsd"


<# Xml取得 #>
  # XML読み込み
  $tgtXml = [xml](Get-Content $tgtXmlPath)

  # 名前空間オブジェクト生成
  $ns = New-Object Xml.XmlNamespaceManager $tgtXml.NameTable
  $ns.AddNamespace($nsAlias, $nameSpace)

  # 要素名をxPathで検索
  $xmlRoot = $tgtXml.SelectNodes("$($nsAlias):settings", $ns)
  # # 別解
  # $xmlRoot = $tgtXml.SelectNodes("$nsAlias" + ":settings", $ns)

  # setting要素取得
  $rootSetting = $xmlRoot.setting
  # key属性取得
  $rootSettingKey = $rootSetting.key
  # value属性取得
  $rootSettingValue = $rootSetting.value


<# 値表示 #>
  Write-Host $rootSettingKey[1]
  Write-Host $rootSettingValue[2]