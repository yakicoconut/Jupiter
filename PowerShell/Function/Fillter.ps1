$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �t�B���^


<# ������t�B���^ #>
filter StrFillter
{
  # �ϐ��u_�v�ɔz����e���n�����
  if ( $_ -eq "def" )
  {
    return $_
  }
}


<# ���C�� #>
  # �z��쐬
  $ary = @("abc", "def", "ghi")
  
  # ������t�B���^�g�p
  $var = $ary | StrFillter
  Write-Host $var