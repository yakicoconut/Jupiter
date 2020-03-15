$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo ���f�B�A�t�@�C���̃v���p�e�B��CSV�t�@�C���ɏo�͂���
#


<# ���[�U���� #>
  Write-Host �Ώۃt�H���_����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetRootPath = $USR


<# ���O���� #>
  # �V�F���C���X�^���X����
  $sh = New-Object -ComObject Shell.Application
  # �Ώۃt�@�C���擾
  $items = Get-ChildItem -Path $targetRootPath -Recurse
  # �o�̓t�@�C����
  $outFileName = "CsvOutSample.csv"
  # �o�͗p�J�X�^���I�u�W�F�N�g�z��
  $outCsvs = @()


<# �{���� #>
  # �t�@�C�����[�v
  foreach($x in $items)
  {
    # �˂��ݕԂ�_�Ώۂ̊g���q��.mp3�łȂ��ꍇ
    if ($x.Extension -ne ".mp3")
    {
      continue
    }

    # �e�t�H���_�擾
    $pathName = Split-Path $x.FullName -Parent
    # �e�t�H���_���疼�O��Ԏ擾
    $folder = $sh.Namespace($pathName)
    # ���O��Ԃ���p�[�X
    $file = $folder.ParseName($x.Name)

    # # �Ƃ肠�����\��
    # # �t�@�C����
    # Write-Host $folder.GetDetailsOf($file, 0)
    # Write-Host "�g���b�N�ԍ�    :"$folder.GetDetailsOf($file, 26).PadLeft(2, "0")
    # Write-Host "�^�C�g��        :"$folder.GetDetailsOf($file, 21)
    # Write-Host "�A���o��        :"$folder.GetDetailsOf($file, 14)
    # Write-Host "�Q���A�[�e�B�X�g:"$folder.GetDetailsOf($file, 13)
    # Write-Host "����            :"$folder.GetDetailsOf($file, 27)
    # Write-Host "�T�C�Y          :"$folder.GetDetailsOf($file, 1)
    # Write-Host "�W������        :"$folder.GetDetailsOf($file, 16)

    # �z��f�[�^����J�X�^���I�u�W�F�N�g�쐬
    $obj = [PSCustomObject]@{
      FileName = $folder.GetDetailsOf($file, 0)
      Title = $folder.GetDetailsOf($file, 21)
      Artists = $folder.GetDetailsOf($file, 13)
      Album = $folder.GetDetailsOf($file, 14)
      Track = $folder.GetDetailsOf($file, 26)
      Genres = $folder.GetDetailsOf($file, 16)
    }
    $outCsvs += $obj
  }

  # CSV�o��
  $outCsvs | Export-Csv $outFileName -Encoding Default -NoTypeInformation