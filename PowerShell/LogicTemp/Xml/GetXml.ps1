$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾
# �擾�Ώۗv�f�x�^����


<# �ݒ� #>
  # �Ώۃt�@�C��
  $tgtXmlPath = ".\TestXml\TestXml01_Utf8.xml"
  # �G���R
  $enc = "UTF8"


<# XML�擾 #>
  # # ����
    # XML�ݒ�l�G���[�t���O
    $errFlg = $true

  # # XML�ǂݍ���
    $tgtXml = [XML](Get-Content -Encoding $enc $tgtXmlPath)

  # # ���[�g�v�f�擾
    # �uroot�v�v�f���́uB�v�v�f�擾
    $tgtRoot = $tgtXml.root.B
    # �˂��ݕԂ�
    if ($tgtRoot -eq $null)
    {
      Write-Host �w�肵��XML���[�g���擾�ł��Ă��܂���
      Write-Host �I�����܂�
      return
    }

  # # �v�f�擾
    # �u���v�������e�S�擾
    $tgtAttr_1 = $tgtRoot.��
    # �u�́v�������e�S�擾
    $tgtAttr_2 = $tgtRoot.��

    # �Ώۗv�f�̃C���f�b�N�X�擾
    $tgtAttrId_1 = [Array]::IndexOf($tgtAttr_1, '��')
    $tgtAttrId_2 = [Array]::IndexOf($tgtAttr_2, '��')
    # �l�擾
    # �C���f�b�N�X���u-1�v�̏ꍇ�A�G���[�t���O�𗧂Ă�
    $valAttr_1 = if ($tgtAttrId_1 -eq -1){ $errFlg= $false } else { Write-Output $tgtAttr_1[$tgtAttrId_1] }
    $valAttr_2 = if ($tgtAttrId_2 -eq -1){ $errFlg= $false } else { Write-Output $tgtAttr_2[$tgtAttrId_2] }


<# �l�\�� #>
  # Xml�ݒ�l�G���[�łȂ��ꍇ
  if ($errFlg)
  {
    Write-Host $valAttr_1
    Write-Host $valAttr_2
  }