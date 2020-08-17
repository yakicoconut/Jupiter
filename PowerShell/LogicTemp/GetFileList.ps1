$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo �w��t�H���_���t�@�C���擾
# �T�v
#   �E�w��t�H���_���̃t�@�C�����ꊇ�Ŏ擾����
#   �Epowershell��Win�Ńt�@�C�����Ɏw��\��
#     �u[]�v�����C���h�J�[�h�Ȃ��߁uGet-ChildItem�v��
#     �u-Path�v�I�v�V�����ł͗\�����ʓ����ƂȂ邽��
#     �u-literalpath�v���g�p����
# �T�C�g
#   PowerShell�́A�p�X�w��܂��̂�₱�����b Get-ChildItem (dir/ls) �� : �݂��݂̂Ă��Ɓ[���O
#   	https://kanamiyuki.exblog.jp/9447561/
#   PowerShell�̃����`Path��LiteralPath�p�����[�^�ɂ��� - Qiita
#     https://qiita.com/mima_ita/items/486566b717743e9d2626


<# �t�@�C�������֐� #>
  # # �t�@�C������
  # ����01:�����Ώۃt�H���_
  # �Ԃ�l:��������
  function GetChildItem ($tgtRootPath)
  {
    # �t�@�C������z��Ŏ擾
    # Get-ChildItem
    #       -Path:�Ώۃp�X�L�q(�ȗ���)
    #             ���C���h�J�[�h���󂯕t����
    #   -literal~:���C���h�J�[�h���󂯕t���Ȃ��Ώۃp�X
    #    -Recurse:��A�I
    $items = @(Get-ChildItem -LiteralPath $tgtRootPath -Recurse)
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
    $items = Get-ChildItem -LiteralPath $tgtRootPath -Recurse | Where-Object{$_.Name -match "$regFileName"}
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