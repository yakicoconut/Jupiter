. ".\Tools\GetHashList.ps1"
. ".\Tools\ExtraHashDiff.ps1"
# # �t�@�C���������o
# �T�C�g
#   Copy-item���g�����f�B���N�g���R�s�[�͂��Ȃ��ق�������Ȃ̂ł́A�Ƃ����b - mk_55's diary
#   	https://mk-55.hatenablog.com/entry/2016/09/19/155051
#   Copy-Item -Recurse �̐U��
#   	http://www.vwnet.jp/Windows/PowerShell/copy/Copy-Recurse.htm
#   powershell�̃N���[�W���𗝉����� - Qiita
#   	https://qiita.com/jca02266/items/ad35844ca6fcd2103185

# �^�C�g���ݒ�
$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �v���I�łȂ��G���[�ŏ����I���ݒ�
$ErrorActionPreference = "Stop"


<# ���O���� #>
  # # �ݒ�
    # �Ώۃt�H���_
    $tgtRoot = "D:\_Git\Cal_Bare"
    # �t�@�C���n�b�V���ꗗCSV��
    $outFileName = "HashList.csv"
    # �O�񎯕ʎq
    $preIdentifier = "_PRE"
    # �R�s�[��t�H���_�p�X�ݒ�
    $crDateTime = "_" + (Get-Date -Format "yyyyMMddHHmmss")
    $copyDist = "Diff" + $crDateTime

  # # ���I�ݒ�
    # �˂��ݕԂ�_�Ώۃt�H���_�����݂��Ȃ��ꍇ
    if (!(Test-Path($tgtRoot)))
    {
      Write-Host "$tgtRoot �����݂��܂���"
      Write-Host "�I�����܂�"
      exit
    }
    # �����n�b�V���ꗗ�t�@�C�����݊m�F
    $isExistPreFile = Test-Path($outFileName)


<# ���C�� #>
  # # �t�@�C���n�b�V���ꗗ�쐬
    # ������r�p�n�b�V���ꗗ�쐬�֐��g�p
    Cre8DiffHashList $isExistPreFile $tgtRoot $outFileName $preIdentifier

    # �����n�b�V���ꗗ�t�@�C�������݂��Ȃ��ꍇ
    if (!$isExistPreFile)
    {
      Write-Host "�����S�R�s�["
      # �Ώۃt�H���_���ƃR�s�[
      Copy-Item $tgtRoot $copyDist -Recurse
      # CSV�R�s�[
      Copy-Item $outFileName $copyDist
      exit
    }

  # # �����R�s�[
    # �n�b�V���������o�֐��g�p
    ExtraDiffFromHash $outFileName ([System.IO.Path]::GetFileNameWithoutExtension($outFileName) + "_PRE" + [System.IO.Path]::GetExtension($outFileName)) $tgtRoot $copyDist