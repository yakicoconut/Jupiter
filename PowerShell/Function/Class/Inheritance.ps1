$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#  �N���X�p��
# �T�C�g
#   ���ȒP�� PowerShell Class �̎g����(����4/�p��)
#   	http://www.vwnet.jp/Windows/PowerShell/2017082301/PSv5Class04.htm


<# ���N���X #>
  # �N���X��`
  class BaseClass
  {
    <# �R���X�g���N�^ #>
      # # �R���X�g���N�^
      #   ����01:���l
      #   �Ԃ�l:�Ȃ�
      BaseClass()
      {
        Write-Host "���N���X�R���X�g���N�^"
      }

    <# �����E�Ԃ�l�Ȃ����\�b�h #>
      # # �����E�Ԃ�l�Ȃ�
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth01()
      {
        Write-Host "���N���X���\�b�h"
        return
      }
  }


<# �h���N���X #>
  # �N���X��`
  class SubClass : BaseClass
  {
    <# �R���X�g���N�^ #>
      # # �R���X�g���N�^
      #   ����01:���l
      #   �Ԃ�l:�Ȃ�
      SubClass() : Base()
      {
        Write-Host "�h���N���X�R���X�g���N�^"
      }

    <# �I�[�o�[���C�h���\�b�h #>
      # # �I�[�o�[���C�h
      #   ���N���X�̓������\�b�h���`
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth01()
      {
        Write-Host "���\�b�h�I�[�o�[���C�h"
        Write-Host "  ���N���X�̃��\�b�h��"
        Write-Host "  �����̃��\�b�h"
        return
      }

    <# ���N���X���\�b�h�Ăяo�����\�b�h #>
      # # ���N���X���\�b�h�Ăяo��
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth02()
      {
        Write-Host "�h���N���X���\�b�h"
        Write-Host "  �h���N���X������N���X��"
        Write-Host "  ���\�b�h���Ăяo��"
        ([BaseClass]$this).TestMeth01()
        return
      }
  }

<# ���C�� #>
  # # �C���X�^���X����
    Write-Host "--------------------"
    Write-Host "���N���X�̃R���X�g���N�^��"
    Write-Host "�I�[�o�[���C�h����ƌĂяo������"
    Write-Host "�w��ꁨ�h���x�ƂȂ�"
    Write-Host
    # �e�X�g�N���X�C���X�^���X����
    $TestObject1 = [SubClass]::new()

  # # ���N���X���\�b�h�Ăяo��
    Write-Host "--------------------"
    # ���N���X���\�b�h�Ăяo�����\�b�h�g�p
    $TestObject1.TestMeth02()
    Write-Host

  # # �I�[�o�[���C�h
    Write-Host "--------------------"
    # �I�[�o�[���C�h���\�b�h�g�p
    $TestObject1.TestMeth01()
    Write-Host