$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�O���[�o���֐��t�@�C��01"
Write-Host


<# ���[�J���֐� #>
  # # �e�X�g�֐�01
  #   ����01:
  #   �Ԃ�l:
  function Test01 ($arg01)
  {
    Write-Host "�e�X�g�֐�01_���[�J��"
    Write-Host $arg01
    Write-Host
  }


# �e�X�g�O���[�o���֐�02
#   ����01:
#   ����02:
#   �Ԃ�l:
function global:Test02
{
  param ([string]$arg01)
  Write-Host "�e�X�g�֐�02_�O���[�o��"
  Write-Host $arg01
  Write-Host
}


