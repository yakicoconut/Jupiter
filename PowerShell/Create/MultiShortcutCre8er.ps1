$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �V���[�g�J�b�g�쐬PS


<# ���O�ݒ� #>
  # ���s�\�G���[�ł��R�}���h���I������ݒ�
  $ErrorActionPreference = "Stop"


<# �Ώۃt�@�C������ #>
  # �Ώۃe�L�X�g�t�@�C���p�X����
  Write-Host("�Ώۃt�H���_���L�q�����t�@�C�����w�肵�Ă�������")
  $targetFilePath = (Read-Host ���͂��Ă�������)


<# �_�u���N�H�[�e�[�V�������f #>
  # �ꕶ���ڂ��u"�v�̏ꍇ
  if ($targetFilePath.Substring(0, 1) -eq "`"" )
  {
    # �擪�̃_�u���N�H�[�g�����
    $targetFilePath = $targetFilePath.Substring(1, $targetFilePath.Length - 1)
  }
  # �������u"�v�̏ꍇ
  if ($targetFilePath.Substring($targetFilePath.Length - 1, 1) -eq "`"" )
  {
    # �����̃_�u���N�H�[�g�����
    $targetFilePath = $targetFilePath.Substring(0, $targetFilePath.Length - 1)
  }


<# �V���[�g�J�b�g�쐬 #>
  Write-Host("")
  Write-Host("")
  Write-Host("�V���[�g�J�b�g�쐬")

  # Shift-JIS�Ńt�@�C���ǂݍ���
  $targetFile = New-Object System.IO.StreamReader($targetFilePath, [System.Text.Encoding]::GetEncoding("sjis"))

  Write-Host("")
  # �t�@�C�����e���[�v
  while (($x = $targetFile.ReadLine()) -ne $null)
  {
    # �C�ӂ̃t�@�C������C�ӂ̈ʒu�ɃV���[�g�J�b�g���쐬
    # �V�F���ϐ�����
    $wshShell = New-Object -comObject WScript.Shell

    try{
      # �t�@�C�����̂ݎ擾
      $createFileName = $(Get-ChildItem $x).Name
      Write-Host("$x")

      # �V���[�g�J�b�g�t�@�C���쐬
      $shortcut = $wshShell.CreateShortcut($createFileName + "-ShortCut.lnk")
      # �V���[�g�J�b�g��ݒ�
      $shortcut.TargetPath = $x
      # �ۑ�
      $shortcut.Save()
    }catch{
      Write-Host("")
      Write-Host("�y�G���[�z")
      Write-Host("$x")
      Write-Host("  " + $error[0])
      Write-Host("")
      continue
    }
  }

  # �N���[�Y����
  $targetFile.Close()