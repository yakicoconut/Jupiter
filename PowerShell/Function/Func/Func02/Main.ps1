$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�֐��e�X�g02_���C��"
Write-Host
# �ʃt�@�C���Ăяo��


<# ���ʐݒ� #>
  # �J�E���^������
  $counter = 0


<# �t�@�C�����Ǝ��s #>
  Write-Host "-----------------"
    Write-Host "�t�@�C�����̂����s"
    $counter++
    # �t�@�C�����s
    .\GlbFile01.ps1 $counter "str$counter"


<# �N�����Z�q(&) #>
  # �N�����Z�q(&)����ǂݍ���
  & "$PSScriptRoot\GlbFunc01.ps1"

  Write-Host "-----------------"
    Write-Host "�N�����Z�q(&)�ǂݍ��݃��[�J���֐�"
    Write-Host "  �G���[�p�^�[��"
    Write-Host "  ���N�����Z�q(&)�œǂݍ��񂾃t�@�C����"
    Write-Host "    ���[�J���֐��͌Ăяo���Ȃ�"
    $counter++
    try
    {
      FnLocalAndRead $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "�N�����Z�q(&)�ǂݍ��݃O���[�o���֐�"
    $counter++
    FnGlbAndRead $counter


<# ���Z�q(.) #>
  # ���Z�q(.)����ǂݍ���
  . "$PSScriptRoot\GlbFunc02.ps1"

  Write-Host "-----------------"
    Write-Host "���Z�q(.)���[�J���֐�"
    Write-Host "  ���Z�q(.)�œǂݍ��񂾃t�@�C����"
    Write-Host "  ���[�J���֐����Ăяo���\"
    $counter++
    FnLocalDotRead $counter

  Write-Host "-----------------"
    Write-Host "���Z�q(.)�O���[�o���֐�"
    $counter++
    FnLocalDotRead $counter
