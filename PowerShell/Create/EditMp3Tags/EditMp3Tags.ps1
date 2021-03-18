$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo ���f�B�A�t�@�C���̃v���p�e�B��CSV�t�@�C������擾���ĕҏW����
# �ҏW�ł���g���q��.mp3�̂�
# ����ȊO�̊g���q�ɖ��������s����ƃt�@�C���j������
# ���C�u����TagLib�g�p
#   TagLib
#   	http://taglib.org/
# Using PowerShell to edit MP3 tags - Todd Klindt's Office 365 Admin Blog
# 	https://www.toddklindt.com/blog/Lists/Posts/Post.aspx?ID=468
# taglib-sharp.dll Download for missing file error _ dll-found.com
# 	http://www.dll-found.com/taglib-sharp.dll_download.html


<# ���[�U���� #>
  Write-Host �Ώۃt�H���_����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetRootPath = $USR

  Write-Host ""
  Write-Host �Ώ�CSV����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $targetCsvPath = $USR


<# ���O���� #>
  # �t�@�C������z��Ŏ擾
  $items = @(Get-ChildItem -LiteralPath $targetRootPath -Recurse -File)
  # CSV�t�@�C���ǂݍ���
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default

  # �O��dll�utaglib-sharp.dll�v�̓ǂݍ���
  [Reflection.Assembly]::LoadFrom( (Resolve-Path ".\tablib\taglib-sharp.dll"))


<# �{���� #>
  foreach($x in $items)
  {
    # ���΃p�X�ϊ�
    $tgtName = $x.FullName.Replace($targetRootPath + "\","")

    # �v�f���ʌ���(�ŏ��̂��̂̂݁A�Ȃ���΁u-1�v)
    $ind = [Array]::IndexOf($csv.�Ώۃt�@�C����, $tgtName)

    # �˂��ݕԂ�_CSV�ɐݒ肪�Ȃ��ꍇ
    if ($ind -eq -1)
    {
      continue
    }

    # �Ώە\��
    Write-Host $tgtName


    # # �g���q�ύX
      # �ϐ�������
      $ext = ""
      $newFileName = ""

      # �Ώۃp�X�擾
      $targetPath = $x.FullName

    # taglib-sharp.dll��.mp3�̂ݑΉ��Ȃ̂�
      # �g���q��.mp3����Ȃ��ꍇ�A�ꎞ�I�Ɋg���q��.mp3�ɕύX����
      if ($x.Extension -ne ".mp3")
      {
        # �g���q�ޔ�
        $ext = $x.Extension

        # �ύX��t�@�C�����擾
        $newFileName = [System.IO.Path]::ChangeExtension($targetPath, ".mp3")

        # �ύX
        Rename-Item $targetPath $newFileName

        # �V�p�X��ϐ��Ɋi�[
        $targetPath = $newFileName
      }

      # �Ώۃt�@�C���̓ǂݍ���
      $media = [TagLib.File]::Create((resolve-path -LiteralPath $targetPath))
      # # �Ƃ肠�����\��_�S�^�O
      # Write-Host $media.tag


    # # �Ώۃv���p�e�B�̐ݒ�
      $media.Tag.Title = $csv[$ind].�^�C�g��
      $media.Tag.Artists = $csv[$ind].�Q���A�[�e�B�X�g
      $media.Tag.Album = $csv[$ind].�A���o��
      $media.Tag.Track = $csv[$ind].�g���b�N�ԍ�
      $media.Tag.Genres = $csv[$ind].�W������
      # �W���P�b�g�̒l������ꍇ
      if ($csv[$ind].�W���P�b�g -ne "")
      {
        # �W���P�b�g�̓s�N�e��ɕϊ�
        $pic = [taglib.picture]::createfrompath($targetRootPath + "\" + $csv[$ind].�W���P�b�g)
        $media.Tag.Pictures  = $pic
      }

      # �ۑ�
      $media.Save()


    # # �g���q���ύX���ꂽ�ꍇ
      if ($ext -ne "")
      {
        # �ύX��t�@�C�����쐬
        $newFileName = [System.IO.Path]::ChangeExtension($targetPath, $ext)
        # �g���q��߂�
        Rename-Item $targetPath $newFileName
      }
  }