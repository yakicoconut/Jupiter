$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#   �P�̎��s/�Ăяo������
# �g�p�@
#   �E�{�t�@�C���P�̎��s�̏ꍇ�A���[�U���͂���
#   �E��������Ăяo���̏ꍇ�A���[�U���͂Ȃ�


<# �����\���֐� #>
  # # �����\��
  #   ����01:�\������
  #   �Ԃ�l:�Ȃ�
  function EchoDesc($description)
  {
    # �����\��
    Write-Host $description
  }

<# �P�̌Ăяo�������֐� #>
  # # �P�̌Ăяo���ł̂ݎ��s���鏈��
  #   ����01:�Ȃ�
  #   �Ԃ�l:�Ȃ�
  function SingleExec()
  {
    Write-Host "�P�̎��s"
    Write-Host "�\����������"
    $USR = (Read-Host ���͂��Ă�������)
    Write-Host
    # �X�N���v�g�ϐ��ɒl�ݒ�
    $script:desc = $USR
  }

<# �Ăяo�����f #>
  # �Ăяo�������擾
  $callstack = Get-PsCallStack
  # �����ݒ�
  $desc = $Args[0]

  # �P�̎��s(�{�t�@�C��+�X�N���v�g�u���b�N�̓��)�̏ꍇ
  if($callstack.Length -eq 2)
  {
    # �P�̌Ăяo�������֐��g�p
    SingleExec
  }

  # �����\���֐��g�p
  EchoDesc $desc