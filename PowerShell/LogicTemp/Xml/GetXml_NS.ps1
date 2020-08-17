$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾_���O��Ԃ���


<# �ݒ� #>
  # �Ώ�XML�p�X
  $tgtXmlPath = ".\TestXml\TestXml02.xml"
  # ���O��ԕϐ��ݒ�
  $nsAlias = "ns"
  # ���O��Ԏw��
  $nameSpace = "http://www.zzz.com/yyy/xxx.xsd"


<# Xml�擾 #>
  # XML�ǂݍ���
  $tgtXml = [xml](Get-Content $tgtXmlPath)

  # ���O��ԃI�u�W�F�N�g����
  $ns = New-Object Xml.XmlNamespaceManager $tgtXml.NameTable
  $ns.AddNamespace($nsAlias, $nameSpace)

  # �v�f����xPath�Ō���
  $xmlRoot = $tgtXml.SelectNodes("$($nsAlias):settings", $ns)
  # # �ʉ�
  # $xmlRoot = $tgtXml.SelectNodes("$nsAlias" + ":settings", $ns)

  # setting�v�f�擾
  $rootSetting = $xmlRoot.setting
  # key�����擾
  $rootSettingKey = $rootSetting.key
  # value�����擾
  $rootSettingValue = $rootSetting.value


<# �l�\�� #>
  Write-Host $rootSettingKey[1]
  Write-Host $rootSettingValue[2]