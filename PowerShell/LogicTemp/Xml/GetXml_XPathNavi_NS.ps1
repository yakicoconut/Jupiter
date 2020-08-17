$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾_���O��Ԃ���


<# �ݒ� #>
  # # ���ʐݒ�
    # �G���R
    $enc = "UTF8"
    # ���O��ԕϐ��ݒ�
    $nsAlias = "ns"

  # # �G�C���A�X���薼�O���
    # �Ώ�XML�p�X
    $tgtXmlPath1 = ".\TestXml\TestXml04.xml"
    # ���O��Ԏw��
    $nameSpace1 = "uri:namespace_uri"
    # XPath�w��
    $xPath1 = "//$($nsAlias):book/$($nsAlias):title"
    $xPath2 = "//book/title"

  # # xmlns���O���
    # �Ώ�XML�p�X
    $tgtXmlPath2 = ".\TestXml\TestXml02.xml"
    # ���O��Ԏw��
    $nameSpace2 = "http://www.zzz.com/yyy/xxx.xsd"
    # XPath�w��
    $xPath3 = "//$($nsAlias):settings"
    $xPath4 = "//$($nsAlias):settings/$($nsAlias):setting"


<# Xml�擾 #>
  # # �G�C���A�X���薼�O���
    $tgtXml1 = [xml](Get-Content -Encoding $enc $tgtXmlPath1)

    # ���O��ԃI�u�W�F�N�g����
    $ns1 = New-Object Xml.XmlNamespaceManager $tgtXml1.NameTable
    $ns1.AddNamespace($nsAlias, $nameSpace1)

    # XPathNavigator�I�u�W�F�N�g����
    $xNavi1 = $tgtXml1.CreateNavigator()

    # ���O��ԗv�fXPath�g�p
    $xml1 = $xNavi1.Select($xPath1, $ns1)
    Write-Host "###########################"
    $xml1

    # ���O��ԂłȂ��v�f
    $xml2 = $xNavi1.Select($xPath2, $ns1)
    Write-Host "###########################"
    $xml2

  # # xmlns���O���
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