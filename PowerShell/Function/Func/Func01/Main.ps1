$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�֐��e�X�g01_���C��"
Write-Host
# �֐��@�\


<# �G���[�p�^�[�� #>
  try
  {
    # �e�X�g�֐�01�g�p
    Test01 "abc"
  }
  catch
  {
    # �G���[���e
    Write-Host "�G���[�p�^�[��"
    Write-Host "���֐��錾�O�ɌĂяo���L�q���s���ƃG���[�ƂȂ�"
   Write-Host "  $error[0]"
    Write-Host
  }


<# �֐��錾 #>
  # # �e�X�g�֐�01
  #   ����01:
  #   �Ԃ�l:
  function Test01
  {
    # �����ݒ�
    param ($arg01)

    Write-Host "�e�X�g�֐�01"
    Write-Host $arg01
    Write-Host
  }

  # �e�X�g�֐�02
  #   ����01:
  #   �Ԃ�l:
  function Test02 ($arg01)
  {
    # �����ݒ���uparam�v�L�[���[�h�Ȃ��ōs��
    Write-Host "�e�X�g�֐�02"
    Write-Host $arg01
    Write-Host
  }

  # # �e�X�g�֐�03
  # #   ����01:
  # #   �Ԃ�l:
  # function Test03 ([string]$arg01)
  # {
  #   # �����Ɍ^��ݒ�
  #   $calc = $arg01 / 2
  #   Write-Host "�e�X�g�֐�02"
  #   Write-Host $calc
  #   Write-Host
  # }


<# �֐��g�p #>
  # �e�X�g�֐�01�g�p
  Test01 "def"
  # �e�X�g�֐�02�g�p
  Test02 "ghi"
  # # �e�X�g�֐�03�g�p
  # Test03 "4"
  # Test03 4