using module "..\..\..\OwnLib\UsrInp.psm1"
using module "..\..\..\OwnLib\GetHash.psm1"
# # �n�b�V���ꗗ�쐬

# �^�C�g���ݒ�
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �v���I�łȂ��G���[�ŏ����I���ݒ�
$ErrorActionPreference = "Stop"


<# ������r�p�n�b�V���ꗗ�쐬�֐� #>
  # # ������r�p�n�b�V���ꗗ�쐬
  #   ����01:�����t�@�C���n�b�V���ꗗ���݃t���O
  #   ����02:�Ώۃt�H���_�p�X
  #   ����03:�o�̓t�@�C������
  #   ����04:�O�񎯕ʎq(�K��l:_PRE)
  #   �Ԃ�l:�Ȃ�
  function Cre8DiffHashList($isExistPreFile, $tgtRoot, $outFileName, $preIdentifier = "_PRE")
  {
    # �n�b�V���ꗗCSV�쐬�֘A�N���X�C���X�^���X����
    $getHashClass = [GetHashClass]::new()

    # �t�@�C���n�b�V���ꗗCSV�����ɑ��݂���ꍇ
    if ($isExistPreFile)
    {
      # �O�񎯕ʎq��t����
      $preFileName = [System.IO.Path]::GetFileNameWithoutExtension($outFileName) + $preIdentifier + [System.IO.Path]::GetExtension($outFileName)
      # �O�X��t�@�C���폜
      if (Test-Path $preFileName){Remove-Item $preFileName -Force}
      # �ޔ�
      Rename-Item $outFileName $preFileName
    }

    Write-Host "GetFileHashList�֐�"
    # �t�@�C���n�b�V���ꗗ�쐬���\�b�h�g�p
    $getHashClass.GetFileHashList($tgtRoot, $outFileName, "SHA1")
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
    # �Ώۃt�H���_�p�X����
    $retData = $usrInpClass.UserInput("�Ώۃt�H���_�p�X", $true, "PATH")
    $tgtRoot = $retData[0]
    # �o�̓t�@�C�����̓���
    $retData = $usrInpClass.UserInput("�n�b�V���t�@�C����(�v�g���q)", $false, "PATH")
    $outFileName = $retData[0]
    $isExistPreFile = [system.convert]::ToBoolean($retData[1])

    # ���͏ȗ��̂��ߑO�񎯕ʎq�͋K��ݒ�
    $preIdentifier = "_PRE"

    # �ԋp�p�J�X�^���I�u�W�F�N�g�z��
    $ret = @()
    $ret += $tgtRoot
    $ret += $outFileName
    $ret += $isExistPreFile
    $ret += $preIdentifier

    return $ret
  }


<# �Ăяo�����f #>
  # �Ăяo�������擾
  $callstack = Get-PsCallStack

  # �P�̎��s(�{�t�@�C��+�X�N���v�g�u���b�N�̓��)�̏ꍇ
  if($callstack.Length -eq 2)
  {
    Write-Host "�n�b�V���ꗗ�쐬�X�N���v�g"
    # �P�̌Ăяo�������֐��g�p
    $arg = SingleExec
    # ������r�p�n�b�V���ꗗ�쐬�֐��g�p
    Cre8DiffHashList $arg[0] $arg[1] $arg[2] $arg[3]
  }