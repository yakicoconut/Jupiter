$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �V���[�g�J�b�g�A�C�R���ύXPS
echo ���A�C�R���t�H���_�͖{�X�N���v�g�́u\MyResorce\Icon�v�ɔz�u
# powershell�ŃV���[�g�J�b�g�̃����N��ύX - Qiita
# 	https://qiita.com/z0189/items/e661185477888e6e0025


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
  Write-Host("�V���[�g�J�b�g�A�C�R���ύX")

  Write-Host("")
  foreach($x in $csv)
  {
    try
    {
      # csv������ۂ̃t�@�C��������
      $targetFile = Get-ChildItem $x.�p�X
      # �˂��ݕԂ�_�Ώۃt�@�C�������݂��Ȃ��ꍇ
      if ($targetFile -eq "")
      {
        continue
      }

      # �t�@�C������V���[�g�J�b�g�I�u�W�F�N�g����
      $shortcut=$wshShell.createshortcut($targetFile)
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