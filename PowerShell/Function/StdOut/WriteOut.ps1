$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �T�v
#   �uWrite-Output�v�͕W���o�͂ւ̏o�͂��s���A
#   �p�C�v���C���̍Ō�̃R�}���h�̏ꍇ�A��ʕ\���������
# �T�C�g
#   Write-Host��Write-Output�̈Ⴂ - ���΂��e�b�N�u���O
#   	https://blog.shibata.tech/entry/2016/01/11/151201
#   Powershell�ł̊֐���return�ƃN���X�ł�return�̈Ⴂ - Qiita
#   	https://qiita.com/sunoko/items/7c6e936fdf82a69a0ee6


<# Write-Output���؊֐� #>
  # # Write-Output
  #   ����01:�Ȃ�
  #   ����02:�Ȃ�
  #   �Ԃ�l:�Ȃ�
  function TestWriteOut
  {
    Write-Host "�\��1"
    Write-Output "abc"
    echo "def"
    "ghi"
    Write-Host "�\��2"
    return "jkl"
  }


<# �e�X�g�N���X #>
  # �N���X��`
  class TestClass
  {
    <# Write-Output���؃��\�b�h #>
      # # Write-Output����
      #   ����01:�Ȃ�
      #   �Ԃ�l:������
      [string] TestMeth()
      {
        Write-Host "�\��1"
        Write-Output "abc"
        echo "def"
        "ghi"
        Write-Host "�\��2"
        return "jkl"
      }
  }


<# �֐��g�p #>
  Write-Host "--------------------"
  Write-Host "�E�֐��̕Ԃ�l���󂯂Ȃ��ꍇ�A"
  Write-Host "  ��ʏo�͂����"
  Write-Host "�E�uecho�v�́uWrite-Output�v�̃G�C���A�X"
  Write-Host "�E�R�}���h�Ȃ��Œl���L�q�����ꍇ�����l�̓���ƂȂ�"
  Write-Host
  # Write-Output���؊֐��g�p
  TestWriteOut

  Write-Host "--------------------"
  Write-Host "�Ԃ�l���󂯎��ꍇ��"
  Write-Host "��ʏo�͂��ꂸ�A"
  Write-Host "Write-Output��return�̕��p��"
  Write-Host "�Ԃ�l�������ɂȂ�"
  Write-Host
  $ret = TestWriteOut
  Write-Host
  Write-Host $ret

  Write-Host "--------------------"
  Write-Host "���\�b�h�ł�return��"
  Write-Host "�w�肳�ꂽ���̂����Ԃ����"
  Write-Host
  $TestObject = [TestClass]::new()
  $TestObject.TestMeth()
  Write-Host "----------"
  $ret2 = $TestObject.TestMeth()
  Write-Host $ret2
