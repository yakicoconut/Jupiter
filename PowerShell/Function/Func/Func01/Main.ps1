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
  #   �Ԃ�l:�Ȃ�
  function Test01
  {
    # �����ݒ�
    param ($arg01)

    Write-Host "�e�X�g�֐�01_�ʏ�"
    Write-Host $arg01
    Write-Host
  }

  # # �e�X�g�֐�02
  #   ����01:
  #   �Ԃ�l:�Ȃ�
  function Test02 ($arg01)
  {
    Write-Host "�e�X�g�֐�02_�uparam�v�����ݒ�"
    Write-Host $arg01
    Write-Host
  }

  # # �e�X�g�֐�03
  #   ����01:int16�^
  #   �Ԃ�l:�Ȃ�
  function Test03 ([int16]$arg01)
  {
    Write-Host "�e�X�g�֐�02_�����^�ݒ�"
    Write-Host $arg01
    Write-Host
  }

  # # �e�X�g�֐�04
  #   ����01:
  #   ����02:
  #   �Ԃ�l:�������v�Z�����l
  function Test04 ($arg01, $arg02)
  {
    # �l�v�Z
    $calc = $arg01 + $arg02
    Write-Host "�e�X�g�֐�04_�Ԃ�l����"
    Write-Host "$arg01 + $arg02"

    return $calc
  }

  # # �e�X�g�֐�05
  #   ����01:
  #   ����02:
  #   �Ԃ�l:�������v�Z�����z��
  function Test05 ($arg01, $arg02)
  {
    # �l�v�Z
    $plus = $arg01 + $arg02
    $minus = $arg01 - $arg02
    Write-Host "�e�X�g�֐�05_�����Ԃ�l"
    Write-Host "$arg01 + $arg02"
    Write-Host "$arg01 - $arg02"

    # �ԋp�z��ǉ�
    $ret = @()
    $ret += $plus
    $ret += $minus

    return $ret
  }


<# �֐��g�p #>
  # �e�X�g�֐�01�g�p
  Test01 "def"
  # �e�X�g�֐�02�g�p
  Test02 "ghi"
  # �e�X�g�֐�03�g�p
  try
  {
    Test03 "jkl"
  }
  catch
  {
    # �G���[���e
    Write-Host "�G���[�p�^�[��"
    Write-Host "���ݒ肳��Ă���^�ɕϊ��ł��Ȃ��l��n���ƃG���[�ƂȂ�"
    Write-Host "  $error[0]"
    Write-Host
  }
  # �e�X�g�֐�04�g�p
  $test04Answer = Test04 1 2
  Write-Host "�e�X�g�֐�04�̌���:$test04Answer"
  Write-Host
  # �e�X�g�֐�05�g�p
  $test05Answer = Test05 1 2
  Write-Host "�e�X�g�֐�05�̌���:"
  foreach ($x in $test05Answer)
  {
    Write-Host "  "$x
  }
  Write-Host
