using module "..\..\..\OwnLib\UsrInp.psm1"
using module "..\..\..\OwnLib\DiffAry.psm1"
# # �n�b�V���ꗗ���獷�����o

# �^�C�g���ݒ�
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �v���I�łȂ��G���[�ŏ����I���ݒ�
$ErrorActionPreference = "Stop"


<# �n�b�V���������o�֐� #>
  # # �n�b�V���ꗗ���獷���t�@�C���R�s�[����
  #   ����01:����n�b�V���ꗗCSV�p�X
  #   ����02:�O��n�b�V���ꗗCSV�p�X
  #   ����03:�R�s�[���t�H���_�p�X
  #   ����04:�R�s�[��t�H���_�p�X
  #   �Ԃ�l:�Ȃ�
  function ExtraDiffFromHash($crCsvPath, $preCsvPath, $copyOrigin, $copyDist)
  {
    # # �˂��ݕԂ�_�n�b�V���ꗗ���O��ƈ�v����ꍇ�A�I��
      $crCsvHash = Get-FileHash -Algorithm SHA1 $crCsvPath
      $preCsvHash = Get-FileHash -Algorithm SHA1 $preCsvPath
      if($preCsvHash.Hash -eq $crCsvHash.Hash)
      {
        Write-Host "�n�b�V���ꗗ���O��Ɠ�������" -ForegroundColor Yellow
        Write-Host "�I�����܂�" -ForegroundColor Yellow
        exit
      }

    # # �R�s�[��t�H���_�쐬
      if (!(Test-Path $copyDist)){New-Item $copyDist -ItemType Directory}

    # # CSV�ǂݍ���
      $crCsv = Import-Csv $crCsvPath -Delimiter "," -Encoding Default
      $preCsv = Import-Csv $preCsvPath -Delimiter "," -Encoding Default

    # # �폜�t�@�C���ꗗ�쐬
      # �z�񍷕��擾�֘A�N���X�C���X�^���X����
      $diffAryClass = [DiffAryClass]::new()
      # �폜�Ώێ擾
      $delFileList = $diffAryClass.LackDiff($preCsv.Path, $crCsv.Path)

      # �폜�Ώۂ�����ꍇ
      if($delFileList.Length -ge 1)
      {
        # �폜�Ώۃe�L�X�g�o��
        $delFileList | out-file -filepath ($copyDist + "\DELTARGET.txt")
        # �폜�o�b�`�R�s�[
        Copy-Item ($PSScriptRoot + "\DelFiles.bat") $copyDist
      }

    # # �R�s�[����
      # ����n�b�V���ꗗCSV���[�v
      foreach ($x in $crCsv)
      {
        # �Ώۃp�X�擾
        $tgtPath = $x.Path

        # �O��CSV����C���f�b�N�X�擾
        $indPrePath = [Array]::IndexOf($preCsv.Path, $tgtPath)

        # # �O��n�b�V���l�Ɠ���̏ꍇ
          # ���ݗL��
          if($indPrePath -ge 0)
          {
            # �n�b�V��������
            if($x.Hash -eq $preCsv[$indPrePath].Hash)
            {
              continue
            }
          }

        # # �R�s�[
          # �t�H���_�쐬
          $distDir = $copyDist + (Split-Path -Parent $tgtPath)
          if (!(Test-Path ($distDir))){New-Item $distDir -ItemType Directory}
          # �t�@�C���R�s�[
          Copy-Item ($copyOrigin + $tgtPath) $distDir
      }

      # CSV�R�s�[
      Copy-Item $crCsvPath $copyDist
      Copy-Item $preCsvPath $copyDist
    }


<# �P�̌Ăяo�������֐� #>
  # # �P�̌Ăяo���ł̂ݎ��s���鏈��
  #   ����01:�Ȃ�
  #   �Ԃ�l:�Ȃ�
  function SingleExec()
  {
    # ���[�U���͊֘A�֐��N���X�C���X�^���X����
    $usrInpClass = [UsrInpClass]::new()
    # ���[�U���̓��\�b�h�g�p
    # ����n�b�V���ꗗCSV����
    $retData = $usrInpClass.UserInput("����n�b�V���ꗗCSV�p�X", $true, "PATH")
    $crCsvPath = $retData[0]
    # �R�s�[���t�H���_�p�X����
    $retData = $usrInpClass.UserInput("�R�s�[���t�H���_�p�X", $true, "PATH")
    $copyOrigin = $retData[0]

    # �R�s�[��t�H���_�p�X�ݒ�
    $crDateTime = Get-Date -Format "yyyyMMddHHmmss"
    $copyDist = "Diff_" + $crDateTime
    # ���͏ȗ��̂��ߑO��n�b�V���ꗗCSV�t�@�C�������쐬
    $preCsvPath = (Split-Path -Parent $crCsvPath) + "\" + [System.IO.Path]::GetFileNameWithoutExtension($crCsvPath) + "_PRE" + [System.IO.Path]::GetExtension($crCsvPath)

    # �ԋp�p�J�X�^���I�u�W�F�N�g�z��
    $ret = @()
    $ret += $crCsvPath
    $ret += $preCsvPath
    $ret += $copyOrigin
    $ret += $copyDist

    return $ret
  }


<# �Ăяo�����f #>
  # �Ăяo�������擾
  $callstack = Get-PsCallStack

  # �P�̎��s(�{�t�@�C��+�X�N���v�g�u���b�N�̓��)�̏ꍇ
  if($callstack.Length -eq 2)
  {
    Write-Host "�n�b�V���ꗗ���獷���t�@�C���R�s�[�X�N���v�g"
    # �P�̌Ăяo�������֐��g�p
    $arg = SingleExec
    # �n�b�V���������o�֐��g�p
    ExtraDiffFromHash $arg[0] $arg[1] $arg[2] $arg[3]
  }