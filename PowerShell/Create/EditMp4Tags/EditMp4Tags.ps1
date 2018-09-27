$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo .mp4�t�@�C���̃^�O�v���p�e�B��CSV�t�@�C������擾���ĕҏW����
# ����
#  �E�A�[�g���[�N
#    �Ώۃt�@�C�������݂��Ȃ��ꍇ�AAtomicParsley.exe��������
#    �ݒ��ɉ摜�t�@�C�����폜���Ă�����ɐݒ肵���摜�͌Œ肳���
#
# �T�C�g
#   AAC�̃^�O��� - �T���I�v���O���}���L
#     http://posaune.hatenablog.com/entry/20091212/1260628232
#   AtomicParsley
#     http://www.xucker.jpn.org/keyword/atomicparsley.html
#   iPod touch�Ńr�f�I�̎�������: �A�C�X�e�B�[�����݂Ȃ���...
#     http://iced.tea-nifty.com/lemon/2008/09/ipod-touch-a3ec.html


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
  $items = @(Get-ChildItem $targetRootPath -Recurse)
  # CSV�t�@�C���ǂݍ���
  $csv = Import-Csv $targetCsvPath -Delimiter "," -Encoding Default


<# �{���� #>
  foreach($x in $items)
  {
    # �v�f���ʌ���(�ŏ��̂��̂̂݁A�Ȃ���΁u-1�v)
    $ind = [Array]::IndexOf($csv.�Ώۃt�@�C����, $x.name)
    # �˂��ݕԂ�_CSV�ɐݒ肪�Ȃ��ꍇ
    if ($ind -eq -1)
    {
      continue
    }

    # �Ώە\��
    Write-Host $x.name


    # # �ݒ�擾
      $title    = $csv[$ind].�^�C�g��
      $artist   = $csv[$ind].�Q���A�[�e�B�X�g
      $album    = $csv[$ind].�A���o��
      $tracknum = $csv[$ind].�g���b�N�ԍ�
      $genre    = $csv[$ind].�W������
      $artwork  = $csv[$ind].�A�[�g���[�N
      # ��̏ꍇ�A�uUNKNOWN�v�Ƃ���
      if($title -eq "")   { $title = "UNKNOWN" }
      if($artist -eq "")  { $artist = "UNKNOWN" }
      if($album -eq "")   { $album = "UNKNOWN" }
      if($tracknum -eq ""){ $tracknum = "UNKNOWN" }
      if($genre -eq "")   { $genre = "UNKNOWN" }


    # # �R�}���h���s
      # �A�[�g���[�N�ݒ肪�Ȃ��ꍇ
      if($artwork -eq "") {
        .\AtomicParsley\win32-0.9.0\AtomicParsley.exe `
        $x.FullName                                   `
        --overWrite                                   `
        --title     $title                            `
        --artist    $artist                           `
        --album     $album                            `
        --tracknum  $tracknum                         `
        --genre     $genre
      } else {
        .\AtomicParsley\win32-0.9.0\AtomicParsley.exe `
        $x.FullName                                   `
        --overWrite                                   `
        --title     $title                            `
        --artist    $artist                           `
        --album     $album                            `
        --tracknum  $tracknum                         `
        --genre     $genre                            `
        --artwork   $artwork
      }
  }