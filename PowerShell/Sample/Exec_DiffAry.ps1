using module "..\OwnLib\DiffAry.psm1"
# # �z�񍷕��擾�֘A�N���X�g�p��

# �^�C�g���ݒ�
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �v���I�łȂ��G���[�ŏ����I���ݒ�
$ErrorActionPreference = "Stop"


<# ���O���� #>
  # �Ώ۔z��
  $tgtAry = @("B", "C", "D")
  # ��r�z��
  $compAry = @("A", "B", "E", "F", "G")

<# �g�p�� #>
  # �z�񍷕��擾�֘A�N���X�C���X�^���X����
  $diffAryClass = [DiffAryClass]::new()

  # # �z�񌇔@���o���\�b�h
    $lack = $diffAryClass.LackDiff($tgtAry, $compAry)
    Write-Host $lack