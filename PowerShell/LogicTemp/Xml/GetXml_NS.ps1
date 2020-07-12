$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得_名前空間あり


<# 設定 #>
  # # 共通設定
    # エンコ
    $enc = "UTF8"
    # 名前空間変数設定
    $nsAlias = "ns"

  # # エイリアスあり名前空間
    # 対象XMLパス
    $tgtXmlPath1 = ".\TestXml\TestXml04.xml"
    # 名前空間指定
    $nameSpace1 = "uri:namespace_uri"
    # XPath指定
    $xPath1 = "//$($nsAlias):book/$($nsAlias):title"
    $xPath2 = "//book/title"

  # # xmlns名前空間
    # 対象XMLパス
    $tgtXmlPath2 = ".\TestXml\TestXml02.xml"
    # 名前空間指定
    $nameSpace2 = "http://www.zzz.com/yyy/xxx.xsd"
    # XPath指定
    $xPath3 = "//$($nsAlias):settings"
    $xPath4 = "//$($nsAlias):settings/$($nsAlias):setting"


<# Xml取得 #>
  # # エイリアスあり名前空間
    $tgtXml1 = [xml](Get-Content -Encoding $enc $tgtXmlPath1)

    # 名前空間オブジェクト生成
    $ns1 = New-Object Xml.XmlNamespaceManager $tgtXml1.NameTable
    $ns1.AddNamespace($nsAlias, $nameSpace1)

    # XPathNavigatorオブジェクト生成
    $xNavi1 = $tgtXml1.CreateNavigator()

    # 名前空間要素XPath使用
    $xml1 = $xNavi1.Select($xPath1, $ns1)
    Write-Host "###########################"
    $xml1

    # 名前空間でない要素
    $xml2 = $xNavi1.Select($xPath2, $ns1)
    Write-Host "###########################"
    $xml2

  # # xmlns名前空間
    $tgtXml2 = [xml](Get-Content -Encoding $enc $tgtXmlPath2)
    $ns2 = New-Object Xml.XmlNamespaceManager $tgtXml2.NameTable
    $ns2.AddNamespace($nsAlias, $nameSpace2)
    $xNavi2 = $tgtXml2.CreateNavigator()

    $xml3 = $xNavi2.Select($xPath3, $ns2)
    Write-Host "###########################"
    $xml3

    $xml4 = $xNavi2.Select($xPath4, $ns2)
    Write-Host "###########################"
    $xml4