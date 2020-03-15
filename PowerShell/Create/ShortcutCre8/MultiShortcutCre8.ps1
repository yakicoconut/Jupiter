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
  # �A�C�R���t�H���_�p�X�쐬(�A�C�R���͐�΃p�X�̕K�v������)
  $iconDirPath = (Split-Path( & { $myInvocation.ScriptName } ) -parent) + "\MyResorce\Icon\"
  # �V�F���ϐ�����
  $wshShell = New-Object -comObject WScript.Shell


<# CSV�t�@�C�����e���[�v #>
  Write-Host("")
  Write-Host("")
  Write-Host("�V���[�g�J�b�g�쐬")

  Write-Host("")
  foreach($x in $csv)
  {
    try
    {
      Write-Host($x.����)

      <# �V���[�g�J�b�g�쐬 #>
        # �o�̓t�H���_�w�肪����ꍇ
        $outFolder=$x.�o�̓t�H���_
        if($outFolder -ne "") {
          # �������u\�v�łȂ��ꍇ
          if($outFolder.Substring($outFolder.Length - 1, 1) -ne "\") {
            # �u\�v�ǋL
            $outFolder = $outFolder + "\"
          }

          # �o�͐�t�H���_���Ȃ��ꍇ
          if(-Not(Test-Path $outFolder)){
            # �t�H���_�쐬
            New-Item $outFolder -ItemType Directory
          }
        }

        # �˂��ݕԂ�_���̂̐ݒ肪�Ȃ��ꍇ
        if($x.���� -eq "") {
          # ��L�����̃t�H���_�쐬�͎��s����
          continue
        }

        # �V���[�g�J�b�g�t�@�C���쐬
        $shortcut = $wshShell.CreateShortcut($outFolder + $x.���� + "-ShortCut.lnk")

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