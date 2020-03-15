$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �t�H���_���̃t�@�C����臒l�̗e�ʂŕ�������
# PowerShell �� �t�H���_�̗e�ʈꗗ���擾������ - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/09/26/071905
# PowerShell��PSCustomObject�ɕ�����Object��ǉ����� - tech.guitarrapc.c?m
#   http://tech.guitarrapc.com/entry/2013/06/25/230640


<# ���O���� #>
  # 臒l(KB)
  # 1B=0.000001MB�A1KB=0.001MB�A1000MB=1GB
  $thresholdMB = 10
  $threshold = $thresholdMB * 1000KB

  # ������t�H���_��
  $destFolderName = "TestDest_"
  # ��t�H���_�ԍ�
  $Script:destFolderNum = 1
  # ��t�H���_�Ǘ��z��
  $Script:destDirMgr = @()
  $Script:destDirMgr += [PSCustomObject]@{
    DirName = $destFolderName + $Script:destFolderNum # �t�H���_��
    DirSize = 0                                       # ���݃t�H���_�T�C�Y
    CanAdd = $True                                    # �ǉ��\�t���O
  }


<# �����t�@�C�����擾�֐� #>
 # ����01:�Ώۃt�H���_�p�X
 # �߂�l:�t�@�C�����
function GetDirectlyFileInfo($targetPath)
{
  Write-Host $targetPath
  # �Ώۃt�H���_���̃t�@�C�����T�C�Y���ɕ��ёւ�
  # # -Force:�ʏ�+�B���t�@�C��
  # # �t�@�C���̂�
  # # Length:�T�C�Y
  # # �T�C�Y�Ń\�[�g
  $fileInfo = Get-ChildItem $targetPath -Force `
    | ? { -not $_.PSIsContainer } `
    | Select-Object fullname, Length `
    # | Sort-Object -Descending fullname # �\�[�g(�f�t�H���g�͏���)

  return $fileInfo
}


<# �����t�H���_���擾�֐� #>
 # ����01:�Ώۃt�H���_�p�X
 # �߂�l:�t�H���_���
 function GetDirectlyFolderInfo($targetPath)
{
  # �Ώۃt�H���_���̃t�H���_�T�C�Y��S�Ď擾
  # # �Ώۃt�H���_������A�I�ɏ���
  # # �t�H���_�̂݃t�B���^
  # # �I�u�W�F�N�g�Ƃ��Ēl��Fullname��MB�J�����ɐݒ�
  # # KB��Ń\�[�g
  $folderInfo = Get-ChildItem $targetPath -Force `
    | where PSIsContainer `
    | %{
         # �Ώۂ�ϐ��Ɋi�[
         $x=$_
         # �t�H���_�T�C�Y�v�Z
         $subFolderItems = (Get-ChildItem $x.FullName -Force -Recurse | where Length | measure Length -sum)

         # PS�I�u�W�F�N�g�ɕϊ�
         [PSCustomObject]@{
           Fullname = $x.FullName
           KB = $subFolderItems.sum
         }
       } `
  #  | sort Fullname -Descending ` # �\�[�g(�f�t�H���g�ŏ���)
  #  | format-Table -AutoSize # �\�������₷������(���������Ɣz��Ƃ��ăA�N�Z�X�ł��Ȃ��Ȃ�)
  #          MB = [decimal]("{0:N2}" -f ($subFolderItems.sum / 1MB)) # KB��MB�ɕϊ�

  return $folderInfo
}


<# �V�K�t�H���_�쐬�֐� #>
 # ����01:�ΏۃT�C�Y
 # ����02:�ǉ��\�t���O
 # �߂�l:�V�K��t�H���_��
 # ����:�Ăяo�����֐��ɓn���ꂽ�Q�Ɠn�������g�p
function CreateNewFolder($targetSize, $isCanAdd)
{
  # ��t�H���_�ԍ��C���N�������g
  $Script:destFolderNum += 1

  # ��t�H���_���쐬
  $destRoot = $destFolderName + $Script:destFolderNum

  # ��t�H���_�Ǘ��z��ɐV�����t�H���_��ǉ�
  $Script:destDirMgr += [PSCustomObject]@{
    DirName = $destRoot
    DirSize = $targetSize
    CanAdd = $isCanAdd
  }

  # ������t�H���_�쐬
  New-Item -Path $destRoot\ -ItemType Directory -Force

  return $destRoot
}


<# �t�@�C�������֐� #>
 # ����01:�Ώۃt�H���_�p�X
function ProcessFile($targetFolderPath)
{
  # �����t�@�C�����擾�֐��g�p
  $directlyFiles = GetDirectlyFileInfo $targetFolderPath

  # �t�@�C������
  foreach($x in $directlyFiles)
  {
    # �Ώۃt�@�C���T�C�Y��臒l���z���ꍇ
    if ($x.Length -gt $threshold)
    {
      # �����Ώۃp�X
      $source = $x.FullName

      # �V�K�t�H���_�쐬�֐��g�p
      $destRootFolder = CreateNewFolder $x.Length $False

      # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # ������t�@�C���p�X�쐬
      $destFilePath = $destRootFolder[1] + $destHierarchie

      # �e�t�H���_�p�X�쐬
      $destParentPath = Split-Path $destFilePath -Parent

      # �t�H���_�\���쐬
      New-Item -Path $destParentPath -ItemType Directory -Force
      # �Ώۃt�@�C���R�s�[
      Copy-Item -Path $source -Destination $destParentPath -Force

      continue
    }

    # ��t�H���_�Ǘ��z�񃋁[�v
    $isComp = $False
    foreach($y in $Script:destDirMgr)
    {
      # �˂��ݕԂ�_�����t���O���^
      if ($isComp)
      {
        break
      }
      # �˂��ݕԂ�_�ǉ��\�t���O���s��
      if (-not $y.CanAdd)
      {
        continue
      }
      # �˂��ݕԂ�_������v�Z�t�H���_�T�C�Y��臒l�𒴂���ꍇ
      if ($y.DirSize + $x.Length -gt $threshold)
      {
        continue
      }

      # # �e�ʂ��󂢂Ă����t�H���_�ɏ���
      # �����Ώۃp�X
      $source = $x.FullName
      $destRoot = $y.DirName
      # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # ������t�@�C���p�X�쐬
      $destFilePath = $destRoot + $destHierarchie
      # �e�t�H���_�p�X�쐬
      $destParentPath = Split-Path $destFilePath -Parent

      # �t�H���_�\���쐬
      New-Item -Path $destParentPath -ItemType Directory -Force
      # �Ώۃt�@�C���R�s�[
      Copy-Item -Path $x.FullName -Destination $destRoot$destHierarchie -Force
      # �ړ���T�C�Y�v��
      $y.DirSize += $x.Length
      # �����t���O�𗧂Ă�
      $isComp = $True
    }

    # �˂��ݕԂ�_�����t���O���^
    if ($isComp)
    {
      continue
    }

    # # �󂢂Ă���t�H���_���Ȃ��ꍇ�A�V�����t�H���_�ɏ�������
    # �����Ώۃp�X
    $source = $x.FullName
    # �V�K�t�H���_�쐬�֐��g�p
    $destRootFolder = CreateNewFolder $x.Length $True

    # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
    $destHierarchie = $source -replace $targetRootPathRep, ""
    # ������t�@�C���p�X�쐬
    $destFilePath = $destRootFolder[1] + $destHierarchie
    # �e�t�H���_�p�X�쐬
    $destParentPath = Split-Path $destFilePath -Parent

    # �t�H���_�\���쐬
    New-Item -Path $destParentPath -ItemType Directory -Force
    # �Ώۃt�@�C���R�s�[
    Copy-Item -Path $source -Destination $destParentPath -Force
  }
}


<# �t�H���_�����֐� #>
 # ����01:�Ώۃt�H���_�p�X
function ProcessFolder($targetFolderPath)
{
  # �����t�H���_���擾�֐��g�p
  $directlyFolders = GetDirectlyFolderInfo($targetFolderPath)

  # �t�H���_����
  foreach($x in $directlyFolders)
  {
    # �˂��ݕԂ�_�Ώۃt�H���_�T�C�Y��0�̏ꍇ
    if ([String]::IsNullOrEmpty($x.KB))
    {
      # ��t�H���_�쐬
      # �����Ώۃp�X
      $source = $x.FullName
      # ������͐�t�H���_1�ɌŒ�
      $destRoot = $Script:destDirMgr[0].DirName

      # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # ������t�@�C���p�X�쐬
      $destBlunkFolderPath = $destRoot + $destHierarchie

      # �t�H���_�쐬
      New-Item -Path $destBlunkFolderPath -ItemType Directory -Force

      continue
    }

    # �Ώۃt�H���_�T�C�Y��臒l���z���ꍇ
    if ($x.KB -gt $threshold)
    {
      # ���g����A�I�ɌĂяo��
      ProcessFolder $x.Fullname

      # �t�@�C�������֐��g�p
      ProcessFile $x.Fullname

      continue
    }

    # ��t�H���_�Ǘ��z�񃋁[�v
    $isComp = $False
    foreach($y in $Script:destDirMgr)
    {
      # �˂��ݕԂ�_�����t���O���^
      if ($isComp)
      {
        break
      }
      # �˂��ݕԂ�_�ǉ��\�t���O���s��
      if (-not $y.CanAdd)
      {
        continue
      }
      # �˂��ݕԂ�_������v�Z�t�H���_�T�C�Y��臒l�𒴂���ꍇ
      if ($y.DirSize + $x.KB -gt $threshold)
      {
        continue
      }

      # # �e�ʂ��󂢂Ă����t�H���_�ɏ���
      # �����Ώۃp�X
      $source = $x.FullName
      $destRoot = $y.DirName

      # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
      $destHierarchie = $source -replace $targetRootPathRep, ""
      # ������t�@�C���p�X�쐬
      $destFilePath = $destRoot + $destHierarchie

      # �Ώۃt�H���_��S�ăR�s�[
      Copy-Item -Path $x.Fullname -Destination $destFilePath -Recurse
      # �ړ���T�C�Y�v��
      $y.DirSize += $x.KB
      # �����t���O�𗧂Ă�
      $isComp = $True
    }

    # �˂��ݕԂ�_�����t���O���^
    if ($isComp)
    {
      continue
    }

    # # �󂢂Ă���t�H���_���Ȃ��ꍇ�A�V�����t�H���_�ɏ�������
    # �����Ώۃp�X
    $source = $x.FullName

    # �V�K�t�H���_�쐬�֐��g�p
    $destRootFolder = CreateNewFolder $x.KB $True

    # �Ώۃt�@�C���p�X����f�B���N�g���\�����擾
    $destHierarchie = $source -replace $targetRootPathRep, ""
    # ������t�@�C���p�X�쐬
    $destFilePath = $destRootFolder[1] + $destHierarchie
    # �Ώۃt�@�C���R�s�[
    Copy-Item -Path $source -Destination $destFilePath -Force -Recurse
  }
}


<# �Ώۃt�H���_���� #>
  # �Ώۃt�H���_�p�X����
  Write-Host("�Ώۃt�H���_���͂��Ă�������")
  $targetRootPath = (Read-Host ���͂��Ă�������)

<# �_�u���N�H�[�e�[�V�������f #>
  # �ꕶ���ڂ��u"�v�̏ꍇ
  if ($targetRootPath.Substring(0, 1) -eq "`"" )
  {
    # �擪�̃_�u���N�H�[�g�����
    $targetRootPath = $targetRootPath.Substring(1, $targetRootPath.Length - 1)
  }
  # �������u"�v�̏ꍇ
  if ($targetRootPath.Substring($targetRootPath.Length - 1, 1) -eq "`"" )
  {
    # �����̃_�u���N�H�[�g�����
    $targetRootPath = $targetRootPath.Substring(0, $targetRootPath.Length - 1)
  }


<# �{���� #>
  # �p�X�ł͒u�����s���Ȃ��̂ŉ~�}�[�N���G�X�P�[�v
  $targetRootPathRep = $targetRootPath -replace "\\", "\\"

  # ��ڂ̐�t�H���_�쐬
  $destRoot = $destFolderName + $Script:destFolderNum
  New-Item -Path $destRoot\ -ItemType Directory -Force

  # �t�H���_�����֐��g�p
  ProcessFolder $targetRootPath
  # �t�@�C�������֐��g�p
  ProcessFile $targetRootPath


  echo ""
  echo $threshold
  echo $destDirMgr
  echo �������������܂���