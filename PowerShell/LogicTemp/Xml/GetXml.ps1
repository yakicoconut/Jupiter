$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾


<# �ݒ� #>
  # Xml�ݒ�l�G���[�t���O
  $errFlg = $true


<# Xml�擾 #>
  $tgtXml = [XML](Get-Content ".\TestXml\TestXml01.xml")
  # �uroot�v�v�f���́uB�v�v�f�擾
  $tgtXmlRootB = $tgtXml.root.B
  # �u���v�������e�S�擾
  $tgtXmlRootBAttr_1 = $tgtXmlRootB.��
  # �u�́v�������e�S�擾
  $tgtXmlRootBAttr_2 = $tgtXmlRootB.��

  # �Ώۗv�f�̃C���f�b�N�X�擾
  $idRootBAttr_1 = [Array]::IndexOf($tgtXmlRootBAttr_1, '��')
  $idRootBAttr_2 = [Array]::IndexOf($tgtXmlRootBAttr_2, '��')
  # �l�擾
  # �C���f�b�N�X���u-1�v�̏ꍇ�A�G���[�t���O�𗧂Ă�
  $rootBAttr_1 = if ($idRootBAttr_1 -eq -1){ $errFlg= $false } else { Write-Output $tgtXmlRootBAttr_1[$idRootBAttr_1] }
  $rootBAttr_2 = if ($idRootBAttr_2 -eq -1){ $errFlg= $false } else { Write-Output $tgtXmlRootBAttr_2[$idRootBAttr_2] }


<# �l�\�� #>
  # Xml�ݒ�l�G���[�łȂ��ꍇ
  if ($errFlg)
  {
    Write-Host $rootBAttr_1
    Write-Host $rootBAttr_2
  }