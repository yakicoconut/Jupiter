$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �z���r


<# �z���r��֐� #>
  # # �z���r��֐�
  #   ����01:�Ώ۔z��
  #   ����02:��r�z��
  #   �Ԃ�l:�Ȃ�
  function CompAry($tgtAry, $compAry)
  {
    # # ����
      # �Ώ۔z��̂����A��r�z��ɑ��݂��Ȃ����̂��擾
      # �T�C�g
      #   PowerShell �Ŕz��̒l���ʂ̔z��Ɋ܂܂�邩�ǂ����𒲂ׂ�
      #   	https://mseeeen.msen.jp/powershell-check-existance-of-elements-in-array/
  
      # ��r�z��ɂȂ����̂��擾
      $missing = $tgtAry | Where-Object { $compAry -notcontains $_ }
      Write-Host "-----------------"
      Write-Host "����"
      Write-Host "  ��r�z��ɂ́uC�v�ƁuD�v�����݂��Ȃ�"
      $missing
      Write-Host

    # # �W��
      # �W���֘A
      # �T�C�g
      #   Powershell�Ŕz��̎g�����܂Ƃ߁B�������A�v�f�ǉ��A��r�̕��@�܂ŁI | �Ԃ낮��܁[
	    #   	https://bgt-48.blogspot.com/2018/04/powershell.html#%EF%BC%92%E3%81%A4%E3%81%AE%E9%85%8D%E5%88%97%E3%81%AE%E9%9B%86%E5%90%88%EF%BC%88%E5%92%8C%E9%9B%86%E5%90%88%E3%80%81%E5%B7%AE%E9%9B%86%E5%90%88%E3%80%81%E7%A9%8D%E9%9B%86%E5%90%88%EF%BC%89%E3%82%92%E5%8F%96%E5%BE%97

      # �a�W��(Sort-Object -Unique�g�p)
      $unionUnique = $tgtAry + $compAry | Sort-Object -Unique
      Write-Host "-----------------"
      Write-Host "�a�W��(Sort-Object -Unique�g�p)"
      Write-Host "  �o���̒l���܂Ƃ߂�"
      $unionUnique
      Write-Host

      # �a�W��(Compare-Object�g�p)
      $unionComp = Compare-Object $tgtAry $compAry -IncludeEqual | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "�a�W��(Compare-Object�g�p)"
      $unionComp
      Write-Host

      # �ϏW��
      $Intersection = Compare-Object $tgtAry $compAry -IncludeEqual -ExcludeDifferent | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "�ϏW��"
      Write-Host "  �����ň�v�������"
      $Intersection
      Write-Host

      # ���W��
      $diff = Compare-Object $tgtAry $compAry | ForEach-Object inputobject | Sort-Object
      Write-Host "-----------------"
      Write-Host "���W��"
      Write-Host "  �ϏW���łȂ�����"
      $diff
      Write-Host
  }


<# ���C�� #>
  # # �ݒ�
    # �Ώ۔z��
    $tgtAry = @("B", "C", "D")
    # ��r�z��
    $compAry = @("A", "B", "E", "F", "G")

    Write-Host "-----------------"
    Write-Host "�Ώ۔z��"
    $tgtAry
    Write-Host
    Write-Host "-----------------"
    Write-Host "��r�z��"
    $compAry
    Write-Host

  # �z���r��֐��g�p
  CompAry $tgtAry $compAry