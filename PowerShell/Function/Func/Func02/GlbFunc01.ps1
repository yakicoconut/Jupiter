$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# "�O���[�o���֐��t�@�C��01"


<# �����R�[�h�p�R�����g #>
  # ���̈ʒu�Ɂu<##>�v�`���̃R�����g���Ȃ���
  # VSCode��SJIS�Ŏ������ʂ��Ă���Ȃ�?


<# ���[�J���֐� #>
  # # �N�����Z�q(&)�ǂݍ��݃��[�J���֐�
  #   ����01:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnLocalAndRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


<# �O���[�o���֐� #>
  # �N�����Z�q(&)�ǂݍ��݃O���[�o���֐�
  #   ����01:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function global:FnGlbAndRead ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


