$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �A�v���̃A�C�R�����擾����
# PowerShell �Ńv���O�����̃A�C�R���𒊏o����
# 	https://www.vwnet.jp/Windows/PowerShell/2017122001/ExtractionIcon.htm


<# �Ώۃt�@�C������ #>
  Write-Host ""
  Write-Host �Ώ�App����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetAppPath = $USR


<# ���O���� #>
  # �t�@�C�����̂ݎ擾
  $createFileName = $(Get-ChildItem $targetAppPath).Name + ".ico"


<# �A�C�R���擾 #>
  # �A�Z���u�����[�h
  Add-Type -AssemblyName System.Drawing
  # �ΏۃA�v���̃A�C�R���f�[�^���o
  $iconData = [System.Drawing.Icon]::ExtractAssociatedIcon( $targetAppPath )

  # �o�͗p�t�@�C���X�g���[��
  $fs = New-Object System.IO.FileStream($createFileName, [System.IO.FileMode]::Create)

  # �ۑ�
  $iconData.Save( $fs )
  # �I�u�W�F�N�g�n��
  $fs.Close()
  $fs.Dispose()
  $iconData.Dispose()


echo ""
echo �������������܂���