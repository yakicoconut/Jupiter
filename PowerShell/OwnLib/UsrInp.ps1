$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#   ���[�U���͊֘A�֐��W


<# ���[�U���͊֐� #>
  # # ���[�U���͊֐�
  #     ����01:�\������
  #     ����02:�s�����̓��[�v
  #     ����03:���f���[�h
  #   �Ԃ�l01:���͒l
  #   �Ԃ�l02:���f����
  function UserInput($description, $isInvalidLoop, $mode)
  {
    # �����\��
    Write-Host $description
    $USR = (Read-Host ���͂��Ă�������)
    # �擪�����_�u���N�H�[�e�[�V�����폜
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
    Write-Host

    # �ԋp�z��ǉ�
    $ret = @()
    $ret += $USR
    $ret += $jdgResult

    return $ret
  }