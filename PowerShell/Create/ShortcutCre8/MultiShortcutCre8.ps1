$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �V���[�g�J�b�g�쐬PS
echo ���A�C�R���t�H���_�͖{�X�N���v�g�́u\MyResorce\Icon�v�ɔz�u


<# ���O�ݒ� #>
  # ���s�\�G���[�ł��R�}���h���I������ݒ�
  $ErrorActionPreference = "Stop"


<# �Ώۃt�@�C������ #>
  Write-Host ""
  Write-Host �Ώ�CSV����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetCsvPath = $USR


<# ���O���� #>
  # CSV�t�@�C���ǂݍ���
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default
  # �A�C�R���t�H���_�p�X�쐬
  $iconDirPath = (Split-Path( & { $myInvocation.ScriptName } ) -parent) + "\MyResorce\Icon\"


<# CSV�t�@�C�����e���[�v #>
  Write-Host("")
  Write-Host("")
  Write-Host("�V���[�g�J�b�g�쐬")

  Write-Host("")
  foreach($x in $csv)
  {
    # �V�F���ϐ�����
    $wshShell = New-Object -comObject WScript.Shell

    try
    {
      Write-Host($x.����)

      <# �V���[�g�J�b�g�쐬 #>
        # �V���[�g�J�b�g�t�@�C���쐬
        $shortcut = $wshShell.CreateShortcut($x.���� + "-ShortCut.lnk")

        # ���΃p�X�ō쐬����ꍇ
        if($x.���΃t���O -eq $true) {
          # �V���[�g�J�b�g��ݒ�
          $shortcut.TargetPath = "%windir%\explorer.exe"
          # �����ݒ�
          $shortcut.Arguments = $x.�p�X
        }
        else {
          $shortcut.TargetPath = $x.�p�X
        }
        # �A�C�R���ݒ�
        $shortcut.IconLocation = ($iconDirPath + $x.�A�C�R��)

        # �ۑ�
        $shortcut.Save()
    }
    catch
    {
      Write-Host("")
      Write-Host("�y�G���[�z")
      Write-Host("$x")
      Write-Host("  " + $error[0])
      Write-Host("")
      continue
    }
  }