using module "..\OwnLib\UsrInp.psm1"
# # ���[�U���͊֘A�֐��N���X�T���v��

# �^�C�g���ݒ�
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �v���I�łȂ��G���[�ŏ����I���ݒ�
$ErrorActionPreference = "Stop"


# ���[�U���͊֘A�֐��N���X�C���X�^���X����
$usrInpClass = [UsrInpClass]::new()

Write-Host "--------------------"
# ���[�U���̓��\�b�h�g�p
$inpData = $usrInpClass.UserInput("������-���[�v�I��", $true, "STR")
$inpData
Write-Host

Write-Host "--------------------"
$inpData = $usrInpClass.UserInput("�p�X-���[�v�I��", $true, "PATH")
$inpData
Write-Host

Write-Host "--------------------"
$inpData = $usrInpClass.UserInput("�p�X-���[�v�I�t", $false, "PATH")
$inpData
Write-Host