$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# "�O���[�o���֐��t�@�C��02"


<# �����R�[�h�p�R�����g #>
  # ���̈ʒu�Ɂu<##>�v�`���̃R�����g���Ȃ���
  # VSCode��SJIS�Ŏ������ʂ��Ă���Ȃ�?


<# ���[�J���֐� #>
  # # ���[�J���֐�
  #   ����01:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnLocalDotRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


# �e�X�g�O���[�o���֐�04
#   ����01:
#   �Ԃ�l:
function global:FnGlbDotRead ($arg01)
{
  Write-Host
  Write-Host $arg01
  Write-Host
}


