$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾
# �擾�Ώۗv�fXPath
# XPath �̗� | Microsoft Docs
# 	https://docs.microsoft.com/ja-jp/previous-versions/ms256086(v=vs.120)?redirectedfrom=MSDN
# powershell��XPath���g����XML�t�@�C����ǂ� : morituri�̃u���O
#   http://blog.livedoor.jp/morituri/archives/54105602.html


<# �ݒ� #>
  # �Ώۃt�@�C��
  $tgtXmlPath = ".\TestXml\TestXml01.xml"


<# XML�擾 #>
  # # ����
    # XML�ݒ�l�G���[�t���O
    $errFlg = $true

  # # XML�ǂݍ���
    # �e�L�X�g�I�[�v��
    $sr = [System.IO.File]::OpenText($tgtXmlPath)
    $xml = $sr.ReadToEnd()
    $sr.Close()

    # XML�ϊ�
    $tgtXml = [xml]$xml
    # XPathNavigator�I�u�W�F�N�g����
    $xNavi = $tgtXml.CreateNavigator()

  # # ���[�g�v�f�擾
    $root = $xNavi.Select("*")

  # # �q�S�v�f
    $elem = $root.Select("*")
    # �\��
    $elem

  # # �v�f�uB�v
    Write-Host "##########################"
    Write-Host
    $elem2 = $root.Select("B")
    # �\��
    $elem2