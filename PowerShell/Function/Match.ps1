$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# ���K�\��


<# ���K�\���g�p�֐� #>
  # # ���K�\���g�p�֐�
  #   ����01:�����Ώە�����
  #   ����02:���K�\��������
  #   �Ԃ�l:
  function ExecMatch
  {
    # �����ݒ�
    param ($tgtStr, $reg)
    Write-Host "-----------------"
    Write-Host $tgtStr
    Write-Host $reg

    # �v���I�łȂ��G���[����
    "$tgtStr" -match "$reg"

    $Matches
  }


<# Continue(�K��l) #>
  $tgt = "abcdef"
  ExecMatch $tgt "(.)(.)"
  # $tgt -match "(.)(.)"
  # $Matches