$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#   �P�̎��s/�Ăяo������
# �g�p�@
#   �E�{�t�@�C���P�̎��s�̏ꍇ�A���[�U���͂���
#   �E��������Ăяo���̏ꍇ�A���[�U���͂Ȃ�


<# ���[�U���͊֐� #>
  # # ���[�U���͊֐�
  #   ����01:�\������
  #   �Ԃ�l:���͕�����
  function UserInput($description)
  {
    # �����\��
    Write-Host $description
    $USR = (Read-Host ���͂��Ă�������)
    # �擪�����_�u���N�H�[�e�[�V�����폜
    if($USR.Substring(0, 1) -eq "`""){ $USR = $USR.Substring(1, $USR.Length - 1) }
    if($USR.Substring($USR.Length - 1, 1) -eq "`""){ $USR = $USR.Substring(0, $USR.Length - 1) }
  
    return $USR
  }


<# �������f #>
  # �����ݒ�
  $tgt = $Args[0]

  # �������Ȃ��ꍇ
  if($Args.Length -eq 0)
  {
    # ���[�U���͊֐��g�p
    $tgt = UserInput
  }

  # �\��
  Write-Host $tgt