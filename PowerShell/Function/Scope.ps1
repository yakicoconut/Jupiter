$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#   �X�R�[�v
# �T�C�g
#   ���ȒP�� PowerShell Class �̎g����(����5/�X�R�[�v)
#   	http://www.vwnet.jp/Windows/PowerShell/2017082302/PSv5Class05.htm
#   �ϐ��̃X�R�[�v
#   	http://suyamasoft.blue.coocan.jp/PowerShell/Tutorial/Scope/index.html#Script


<# �X�N���v�g�ϐ� #>
  # �X�N���v�g�����X�R�[�v
  $scriptVar1
  $scriptVar2


<# ���ؗp�֐� #>
  # #
  #   ����01:�Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnTest()
  {
    <# �֐��ϐ� #>
      # �֐������X�R�[�v
      $fnVar = "�֐��ϐ�"
      # �X�N���v�g�ϐ��ݒ�
      $scriptVar1 = "�X�N���v�g�ϐ�1_�֐����ݒ�"
      $Script:scriptVar2 = "�X�N���v�g�ϐ�2_�֐����ݒ�"
  }


<# ���ؗp�N���X #>
  # #
  class TestClass
  {
    <# �v���p�e�B #>
      #
      $ClsProp

    <# ���؃��\�b�h #>
      # #
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth01()
      {
        # �X�N���v�g���X�R�[�v
        $this.ClsProp = "�N���X�v���p�e�B"

        # ���\�b�h���X�R�[�v
        $methVar = "���\�b�h�ϐ�"

        # �X�N���v�g�ϐ��ݒ�
        $scriptVar1 = "�X�N���v�g�ϐ�1_�N���X���ݒ�"
        $Script:scriptVar2 = "�X�N���v�g�ϐ�2_�N���X���ݒ�"

        return
      }
  }


<# ���C�� #>
  # # �X�N���v�g�ϐ�
    Write-Host "--------------------"
    Write-Host "�X�N���v�g�ϐ���"
    Write-Host "�X�N���v�g���Őݒ�"
    Write-Host
    $scriptVar1 = "�X�N���v�g�ϐ�1"
    $scriptVar2 = "�X�N���v�g�ϐ�2"
    Write-Host $scriptVar1
    Write-Host $scriptVar2
    Write-Host

  # # �֐�
    FnTest
    Write-Host "--------------------"
    Write-Host "�֐��ϐ��͊֐����̂ݎg�p�\"
    Write-Host
    Write-Host $fnVar
    Write-Host
    Write-Host "--------------------"
    Write-Host "�X�N���v�g�ϐ��͕ʃX�R�[�v��"
    Write-Host "�P���ɂ͎g�p�ł��Ȃ�"
    Write-Host
    Write-Host $scriptVar1
    Write-Host
    Write-Host "--------------------"
    Write-Host "�X�N���v�g�ϐ���ʃX�R�[�v��"
    Write-Host "�g�p����ꍇ�A�u`$Script:�v������"
    Write-Host
    Write-Host $scriptVar2
    Write-Host

  # # �N���X
    # ���ؗp�N���X�C���X�^���X����
    $TestObject = [TestClass]::new()
    # �e�X�g���\�b�h�g�p
    $TestObject.TestMeth01()
    Write-Host "--------------------"
    Write-Host "�N���X�v���p�e�B��"
    Write-Host "�X�R�[�v�O�ł��g�p�\"
    Write-Host
    Write-Host $TestObject.ClsProp
    Write-Host
    Write-Host "--------------------"
    Write-Host "���\�b�h�ϐ��̓��\�b�h���̂ݗL��"
    Write-Host
    Write-Host $TestObject.$methVar
    Write-Host
    Write-Host "--------------------"
    Write-Host "�X�N���v�g�ϐ��u`$Script:�v�Ȃ�"
    Write-Host
    Write-Host $scriptVar1
    Write-Host
    Write-Host "--------------------"
    Write-Host "�X�N���v�g�ϐ��u`$Script:�v����"
    Write-Host
    Write-Host $scriptVar2
    Write-Host