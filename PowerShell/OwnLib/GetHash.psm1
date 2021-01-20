$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �n�b�V���ꗗCSV�쐬�֘A�N���X


class GetHashClass
{
  <# �R���X�g���N�^ #>
    # # �f�t�H���g�R���X�g���N�^
    #   ����01:�Ȃ�
    GetHashClass()
    {

    }

  <# �t�@�C���n�b�V���ꗗ�쐬���\�b�h #>
    # # �t�@�C���̃n�b�V���l�ꗗ��CSV�Ƃ��ďo��
    #   ����01:�Ώۃt�H���_�p�X
    #   ����02:�o�̓t�@�C������
    #   ����03:�n�b�V���v�Z�A���S���Y��
    #   �Ԃ�l:���ۃt���O
    [bool] GetFileHashList($tgtRoot, $outFileName, $alg)
    {
      # # �ݒ�
        # �o�͗p�J�X�^���I�u�W�F�N�g�z��
        $outCsvs = @()

      # # �Ώۃt�@�C������
        $items = Get-ChildItem $tgtRoot -Recurse
        foreach($x in $items)
        {
          # �n�b�V���ϐ�������
          $tgtHash = $null

          # �z��f�[�^����J�X�^���I�u�W�F�N�g�쐬
          $obj = [PSCustomObject]@{
            # ���΃p�X�ϊ�
            Path = $x.Fullname.Replace($tgtRoot, "")
            # �J����������
            Hash = ""
            Algorithm = ""
          }

          # �˂��ݕԂ�_�t�H���_�̏ꍇ
          if($x.PSIsContainer)
          {
            # �n�b�V�����ڂ�ݒ肹���ɃI�u�W�F�N�g�ǉ�
            $outCsvs += $obj
            continue
          }

          # # �n�b�V���l�擾
            # -Algorithm:SHA1�ASHA256�ASHA384�ASHA512�AMACTripleDES�AMD5�ARIPEMD160
            #            �f�t�H���g��SHA256
            $tgtHash = Get-FileHash -Algorithm $alg $x.Fullname

            # �n�b�V�����ڐݒ�
            $obj.Hash = $tgtHash.Hash
            $obj.Algorithm = $tgtHash.Algorithm
            $outCsvs += $obj
        }

      # # CSV�o��
        $outCsvs | Export-Csv $outFileName -Encoding Default -NoTypeInformation

      return $true
    }
}