$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�֐��e�X�g02_���C��"
Write-Host
# �ʃt�@�C���֐��Ăяo��


<# �N�����Z�q(&)����ǂݍ��� #>
  # �֐��t�@�C���ǂݍ���
  & "$PSScriptRoot\GlbFunc01.ps1"

  try
  {
    Write-Host "�G���[�p�^�[��"
    Write-Host "���ǂݍ��ݍς݊֐��t�@�C�����[�J���֐��Ăяo��"
    # �e�X�g���[�J���֐�01�g�p
    Test01 "abc"
  }
  catch
  {
    # �G���[���e
    Write-Host "  $error[0]"
    Write-Host
  }

  # �e�X�g�O���[�o���֐�02�g�p
  Test02 "def"


<# ���Z�q(.)����ǂݍ��� #>
  Write-Host
  # �֐��t�@�C���ǂݍ���
  . "$PSScriptRoot\GlbFunc02.ps1"

  # �e�X�g���[�J���֐�03�g�p
  # �u.�v���g�p���ăt�@�C���Ăяo�������ꍇ�A
  # ���[�J�������o�̎Q�Ƃ��\
  Test03 "abc"

  # �e�X�g�O���[�o���֐�04�g�p
  Test04 "def"