$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#  �N���X��b
#    �E��`
#    �E�v���p�e�B
#    �E�R���X�g���N�^
#    �E���\�b�h
#    �E�C���X�^���X
#    �Ehidden
#    �E�I�[�o�[���[�h
#    �Estatic
# �T�C�g
#   ���ȒP�� PowerShell Class �̎g����(����1)
#   	https://www.vwnet.jp/Windows/PowerShell/2017082001/PSv5Class01.htm
#   PowerShell�̃R���X�g���N�^�܂Ƃ� - Qiita
#   	https://qiita.com/nimzo6689/items/06b0fc08448ad1aab8ed
#   PowerShell v5�̐V�@�\�ƁA����Ŏg���Ăق����@�\ - Build Insider
#     https://www.buildinsider.net/enterprise/powershelldsc/03


<# �e�X�g�N���X #>
  # �N���X��`
  class TestClass
  {
    <# �v���p�e�B #>
      $Prop01
      $Prop02
      hidden $Prop03
      static $Prop04

    <# �R���X�g���N�^ #>
      # # �R���X�g���N�^
      #   ����01:�^�w��Ȃ�
      TestClass($arg)
      {
        # �v���p�e�B�ݒ�
        $this.Prop01 = $arg
      }

    <# �����E�Ԃ�l���胁�\�b�h #>
      # # �����E�Ԃ�l����
      #   ����01:�^�w��Ȃ�
      #   �Ԃ�l:������
      [string] TestMeth01($str)
      {
        return $str + $this.Prop01 + $this.Prop02
      }

    <# �����E�Ԃ�l�Ȃ����\�b�h #>
      # # �����E�Ԃ�l�Ȃ�
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth02()
      {
        Write-Host "�����E�Ԃ�l�Ȃ�"
        return
      }

    <# ���[�J�����\�b�h�Ăяo�����\�b�h #>
      # # ���[�J�����\�b�h�Ăяo��
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth03()
      {
        Write-Host "���[�J�����\�b�h�Ăяo��"
        $this.TestMeth02()
        return
      }

    <# �I�[�o�[���[�h���\�b�h #>
      # # �I�[�o�[���[�h1
      #   ����01:������
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth04([string]$arg)
      {
        Write-Host $arg
        return
      }

      # # �I�[�o�[���[�h1
      #   ����01:���l
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth04([int]$arg)
      {
        Write-Host $arg.GetType()
        return
      }

    <# static #>
      # # static�w�胁�\�b�h
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      static [void] TestMeth05()
      {
        Write-Host "�ÓI���\�b�h"
        return
      }

      # # static�v���p�e�B���상�\�b�h
      #   ����01:�Ȃ�
      #   �Ԃ�l:�Ȃ�
      [void] TestMeth06()
      {
        [TestClass]::Prop04 += 1
        Write-Host ([TestClass]::Prop04)
        return
      }

    <# hidden���؃��\�b�h #>
      # # hidden����
      #   ����01:�Ȃ�
      #   �Ԃ�l:������
      hidden [string] HiddenTestMeth()
      {
        return "hidden����" + $this.Prop03
      }
  }


<# ���C�� #>
  # # New-Object�R�}���h���b�g
    # �e�X�g�N���X�C���X�^���X����
    $TestObject1 = New-Object TestClass -ArgumentList "123"
    # �v���p�e�B�A�N�Z�X
    $TestObject1.Prop02 = "def"
    # �e�X�g���\�b�h���s
    $ret01 = $TestObject1.TestMeth01("abc")
    Write-Host "--------------------"
    Write-Host $ret01
    Write-Host

  # # new���\�b�h
    # �e�X�g�N���X�C���X�^���X����
    $TestObject2 = [TestClass]::new("456")
    # �e�X�g���\�b�h�g�p
    $ret02 = $TestObject2.TestMeth01("ghi")
    Write-Host "--------------------"
    Write-Host $ret02
    Write-Host
    Write-Host "--------------------"
    $TestObject2.TestMeth02()
    Write-Host

  # # hidden����
    # hidden�L�[���[�h��p���������o��
    # �C���e���Z���X��Get-Memeber�ŉ{���o���Ȃ��Ȃ�
    Write-Host "--------------------"
    Write-Host "�uHiddenTestMeth�v�ƁuProp03�v�͕\������Ȃ�"
    $member = Get-Member -InputObject $TestObject1
    Write-Host $member.Name
    Write-Host

    Write-Host "--------------------"
    Write-Host "C#��private�̂悤�ɃA�N�Z�X���o���Ȃ��Ȃ�킯�ł͂Ȃ�"
    $TestObject3 = [TestClass]::new("")
    # hidden�v���p�e�B�A�N�Z�X
    $TestObject3.Prop03 = "jkl"
    # �e�X�g���\�b�h�g�p
    $ret03 = $TestObject3.HiddenTestMeth()
    Write-Host $ret03
    Write-Host

  # # ���[�J�����\�b�h
    Write-Host "--------------------"
    Write-Host "�N���X���Ń��[�J�����\�b�h���Ăяo���̂�"
    Write-Host "�u`$this�v�ϐ����w�肷��"
    # ���[�J�����\�b�h�Ăяo�����\�b�h�g�p
    $TestObject3.TestMeth03()
    Write-Host

  # # �I�[�o�[���[�h
    Write-Host "--------------------"
    Write-Host "���\�b�h�̓I�[�o�[���[�h��"
    Write-Host "�\(�֐��ł͕s��)"
    # ���[�J�����\�b�h�Ăяo�����\�b�h�g�p
    $TestObject3.TestMeth04("123")
    $TestObject3.TestMeth04(123)
    Write-Host

  # # �ÓI�����o
    Write-Host "--------------------"
    Write-Host "�ÓI���\�b�h�̓N���X��"
    Write-Host "�C���X�^���X�������Ɏg�p�\"
    [TestClass]::TestMeth05()
    Write-Host

    Write-Host "--------------------"
    Write-Host "�ÓI�v���p�e�B"
    Write-Host "�C���X�^���X�������Ɏg�p"
    [TestClass]::Prop04 = 1
    Write-Host ([TestClass]::Prop04)

    Write-Host "--------------------"
    Write-Host "�C���X�^���X���ׂ��Ŏg�p�\"
    # �C���X�^���X�����~2
    $TestObject4 = [TestClass]::new("")
    $TestObject5 = [TestClass]::new("")

    # static�v���p�e�B���상�\�b�h�g�p
    Write-Host $TestObject4.TestMeth06()
    Write-Host $TestObject5.TestMeth06()
    Write-Host