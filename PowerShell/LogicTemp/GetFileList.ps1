$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �w��t�H���_���t�@�C���擾
# �T�v
#   �w��t�H���_���̃t�@�C�����ꊇ�Ŏ擾����


<# �t�@�C�������֐� #>
  # # �t�@�C������
  # ����01:�����Ώۃt�H���_
  # �Ԃ�l:��������
  function GetChildItem ($tgtRootPath)
  {
    # �t�@�C������z��Ŏ擾
    $items = @(Get-ChildItem $tgtRootPath -Recurse)
    return $items
  }

<# ���K�\���t�@�C�������֐� #>
  # # ���K�\���t�@�C������
  # ����01:�����Ώۃt�H���_
  # ����02:���K�\��
  # �Ԃ�l:��������
  function GetChildMatchItem ($tgtRootPath, $regFileName)
  {
    # �t�@�C������z��Ŏ擾
    $items = Get-ChildItem $tgtRootPath -Recurse | Where-Object{$_.Name -match "$regFileName"}
    return $items
  }


<# ���C�� #>
  # # �Ώۃt�H���_�p�X����
    Write-Host �Ώۃt�H���_����
    $USR = (Read-Host ���͂��Ă�������)
    # �擪�����_�u���N�H�[�e�[�V�����폜
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    $tgtRootPath = $USR

  # �t�@�C�������֐��g�p
  $items = GetChildItem $tgtRootPath
  foreach($x in $items)
  {
    # �Ώە\��
    Write-Host $x.name
  }


  # # ���K�\������
    Write-Host
    Write-Host ���K�\������
    $USR = (Read-Host ���͂��Ă�������)
    # �擪�����_�u���N�H�[�e�[�V�����폜
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    $regFileName = $USR

  # ���K�\���t�@�C�������֐��g�p
  $items = GetChildMatchItem $tgtRootPath $regFileName
  # �˂��ݕԂ�_�Ώۃt�@�C�������݂��Ȃ��ꍇ
  if ($null -eq $items)
  {
    Write-Host �Ώۃt�@�C���Ȃ�
  }
  else
  {
    foreach($x in $items)
    {
      # �Ώە\��
      Write-Host $x.name
    }
  }