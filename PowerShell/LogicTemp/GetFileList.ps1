$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �w��t�H���_���t�@�C���擾
# �T�v
#   �w��t�H���_���̃t�@�C�����ꊇ�Ŏ擾����


<# ���[�U���� #>
  Write-Host �Ώۃt�H���_����
  $USR = (Read-Host ���͂��Ă�������)
  # �擪�����_�u���N�H�[�e�[�V�����폜
  if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
  if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  $tgtRootPath = $USR


<# ���O���� #>
  # �t�@�C������z��Ŏ擾
  $items = @(Get-ChildItem $tgtRootPath -Recurse)


<# �{���� #>
  foreach($x in $items)
  {
    # �Ώە\��
    Write-Host
    Write-Host $x.name
  }