$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�O���[�o���֐��t�@�C��02"
Write-Host


<# ���[�J���֐� #>
  # # �e�X�g�֐�03
  #   ����01:
  #   �Ԃ�l:
  function Test03 ($arg01)
  {
    Write-Host "�e�X�g�֐�03_���[�J��"
    Write-Host $arg01
    Write-Host
  }


# �e�X�g�O���[�o���֐�04
#   ����01:
#   ����02:
#   �Ԃ�l:
function global:Test04
{
  param ([string]$arg01)
  Write-Host "�e�X�g�֐�04_�O���[�o��"
  Write-Host $arg01
  Write-Host
}


