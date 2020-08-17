$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾_���O��Ԃ���


<# �ݒ� #>
  # �Ώ�XML�p�X
  $tgtXmlPath = ".\TestXml\TestXml02.xml"
  # �G���R
  $enc = "UTF8"
  # ���O��ԕϐ��ݒ�
  $nsAlias = "ns"
  # ���O��Ԏw��
  $nameSpace = "http://www.zzz.com/yyy/xxx.xsd"
  # XPath�w��
  $xPath = "settings"


<# Xml�擾 #>
  # # XML�ǂݍ���
    $tgtXml = [xml](Get-Content -Encoding $enc $tgtXmlPath)

    # ���O��ԃI�u�W�F�N�g����
    $ns = New-Object Xml.XmlNamespaceManager $tgtXml.NameTable
    $ns.AddNamespace($nsAlias, $nameSpace)

  # # ���[�g�v�f�擾
    # �v�f����xPath�Ō���
    $tgtRoot = $tgtXml.SelectNodes("$nsAlias" + ":" + $xPath, $ns)
    # # �ʉ�
    # $tgtRoot = $tgtXml.SelectNodes("$($nsAlias):settings", $ns)
    # �˂��ݕԂ�
    if ($tgtRoot -eq $null)
    {
      Write-Host �w�肵��XML���[�g���擾�ł��Ă��܂���
      Write-Host �I�����܂�
      return
    }

  # # �v�f�擾
    # setting�v�f�擾
    $rootSetting = $tgtRoot.setting
    # key�����擾
    $rootSettingKey = $rootSetting.key
    # value�����擾
    $rootSettingValue = $rootSetting.value


<# �l�\�� #>
  Write-Host $rootSettingKey[1]
  Write-Host $rootSettingValue[2]