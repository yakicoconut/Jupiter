$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�t�@�C���ǂݍ���
# PowerShell - XML�t�@�C���̑��� | powershell Tutorial
# 	https://sodocumentation.net/ja/powershell/topic/4882/xml%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%E3%81%AE%E6%93%8D%E4%BD%9C


<# �ݒ� #>
  # �Ώۃt�@�C��
  $tgtXmlPath = ".\TestXml\TestXml01_Utf8.xml"
  # �G���R
  $enc = "UTF8"


<# XML�擾 #>
  # # XML�h�L�������g
    # XML�h�L�������g�I�u�W�F�N�g����
    $xml1 = New-Object System.Xml.XmlDocument
    # �t�@�C�����[�h
    $xml1.load($tgtXmlPath)
    $xml1

  # # �ϐ��^�w��
    [xml]$xml2 = Get-Content -Encoding $enc $tgtXmlPath
    $xml2

  # # �ǂݍ��݌^�w��
    $xml3 = [xml](Get-Content -Encoding $enc $tgtXmlPath)
    $xml3

  # # �I�[�v���e�L�X�g
    # �e�L�X�g�Ƃ��ēǂݍ���
    $sr = [System.IO.File]::OpenText($tgtXmlPath)
    $txt = $sr.ReadToEnd()
    $sr.Close()
    # XML�ϊ�
    $xml4 = [xml]$txt
    $xml4