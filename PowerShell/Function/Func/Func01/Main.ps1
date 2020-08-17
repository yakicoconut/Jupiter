$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
Write-Host "�֐��e�X�g01_���C��"
Write-Host
# Powershell�ň������󂯎�� | �}�C�N���\�t�}�u���O
# 	https://microsoftou.com/ps-arguments/


<# �G���[�p�^�[�� #>
  try
  {
    # �e�X�g�֐�01�g�p
    FnNoArg "abc"
  }
  catch
  {
    # �G���[���e
    Write-Host "-----------------"
    Write-Host "�錾�O�֐��g�p"
    Write-Host "  �G���[�p�^�[��"
    Write-Host "  ���֐��錾�O�ɌĂяo���L�q���s���ƃG���[�ƂȂ�"
    Write-Host
    Write-Host "  $error[0]"
    Write-Host
  }


<# �֐��錾 #>
  # # �����ݒ�Ȃ��֐�
  #   ����01:�Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnNoArg
  {
    Write-Host
    Write-Host $Args[0]
    Write-Host $Args[1]
    Write-Host
  }

  # # �����ݒ肠��֐�
  #   ����01:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  #   
  function FnOneArg ($arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # �����ݒ蕡���֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  #   
  function FnMultiArg ($arg01, $arg02 = "abc")
  {
    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }
  
  # # Param�����ݒ�֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnParam
  {
    # �����ݒ�
    param ($arg01, $arg02)

    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }

  # # �����^�ݒ�֐�
  #   ����01:int16�^
  #   �Ԃ�l:�Ȃ�
  function FnTypeSet ([int16]$arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # �����f�t�H���g�l�ݒ�֐�
  #   ����01:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnDefValSet ($arg01 = "DefaultValue")
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }

  # # �����K�{�ݒ�֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnMandatorySet ($arg01, [parameter(mandatory)]$arg02)
  {
    Write-Host
    Write-Host $arg01
    Write-Host $arg02
    Write-Host
  }

  # # �����l�w��ݒ�֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ȃ�
  function FnValSet ([ValidateSet("abc","def")]$arg01)
  {
    Write-Host
    Write-Host $arg01
    Write-Host
  }


  # # �P���Ԃ�l�֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ԃ�l
  function FnOneRet ($arg01, $arg02)
  {
    # �l����
    $retVal = "$arg01" + "$arg02"

    return $retVal
  }

  # # �����Ԃ�l�֐�
  #   ����01:�^�w��Ȃ�
  #   ����02:�^�w��Ȃ�
  #   �Ԃ�l:�Ԃ�l�z��
  function FnMultiRet ($arg01, $arg02)
  {
    # �l����
    $retVal1 = "$arg01" + "+" + "$arg02"
    $retVal2 = "$arg01" + "-" + "$arg02"

    # �ԋp�z��ǉ�
    $ret = @()
    $ret += $retVal1
    $ret += $retVal2

    return $ret
  }


<# �֐��g�p #>
  # �J�E���^������
  $counter = 0

  Write-Host "-----------------"
    Write-Host "�����Ȃ��֐��Ɉ�����n��"
    Write-Host "  �֐��ɂ͈����ݒ���s���Ă��Ȃ���"
    Write-Host "  ������Args�ϐ��ɔz��Ƃ��Ċi�[�����"
    $counter++
    # �֐��g�p
    FnNoArg $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "�����ݒ肠��֐��Ɉ�����n��"
    $counter++
    FnOneArg $counter
 
  Write-Host "-----------------"
    Write-Host "���������ݒ�֐��Ɉ����𕡐��n��"
    $counter++
    FnMultiArg $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "���������ݒ�֐��Ɉ����𕡐��n��"
    Write-Host "  �֐��g�p���ɃI�v�V�����Ƃ���"
    Write-Host "  ���������w��\"
    $counter++
    FnMultiArg -arg02 $counter -arg01 "str$counter"

  Write-Host "-----------------"
    Write-Host "param�����ݒ�"
    $counter++
    FnParam $counter "str$counter"

  Write-Host "-----------------"
    Write-Host "�����^�ݒ�ݒ�"
    Write-Host "  �G���[�p�^�[��"
    Write-Host "  ���ݒ肳��Ă���^�ɕϊ��ł��Ȃ��l��n���ƃG���[�ƂȂ�"
    $counter++
    try
    {
      FnTypeSet "str$counter"
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }
    
  Write-Host "-----------------"
    Write-Host "�����f�t�H���g�l�ݒ�"
    FnDefValSet

  Write-Host "-----------------"
    Write-Host "�K�{�ݒ����"
    Write-Host "  �G���[�p�^�[��"
    Write-Host "  ���K�{�ݒ�������n����Ȃ��ꍇ�A�G���["
    $counter++
    try
    {
      FnMandatorySet $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "�����l�w��ݒ�"
    Write-Host "  �G���[�p�^�[��"
    Write-Host "  ���w��̒l�ȊO��n�����ꍇ�A�G���["
    $counter++
    try
    {
      FnValSet $counter
    }
    catch
    {
      Write-Host
      Write-Host "  $error[0]"
      Write-Host
    }

  Write-Host "-----------------"
    Write-Host "�P���Ԃ�l"
    $counter++
    $var = FnOneRet $counter "str$counter"
    Write-Host
    Write-Host $var
    Write-Host
  
  Write-Host "-----------------"
    Write-Host "�����Ԃ�l"
    $counter++
    $var = FnMultiRet $counter "str$counter"
    Write-Host
    foreach ($x in $var)
    {
      Write-Host $x
    }
    Write-Host