$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# �G���[�������̋����ݒ�
# $ErrorActionPreference
#   Continue        :����A�G���[�\���A���s
#   Stop            :�G���[�\���A��~
#   Inquire         :�G���[�\���A���s�m�F
#   Suspend         :����Ȃ钲���̂��߁A���[�N�t���[ �W���u�������I�ɒ��f���܂��B
#                    �����̌�ŁA���[�N�t���[���ĊJ�ł��܂��B
#   SilentlyContinue:�G���[�\���Ȃ��A���f�Ȃ�
# �T�C�g
#   PowerShell�ł̃G���[�n���h�����O�ɂ��� - Qiita
#   	https://qiita.com/toshihirock/items/936b33f0c15723565dce


<# �G���[�p�֐� #>
  # # �G���[�p�֐�
  #   ����01:�J�E���^
  #   �Ԃ�l:�J�E���^
  function ErrorOccur
  {
    # �����ݒ�
    param ($i)
    Write-Host "-----------------"

    # �G���[�O�\��
    $i++
    Write-Host $i

    # �v���I�łȂ��G���[����
    Get-ChildItem "ABC:\"

    # �G���[��\��
    $i++
    Write-Host $i

    return $i
  }


<# �ݒ� #>
  # �J�E���^
  $counter = 0


<# Continue(�K��l) #>
  # �ݒ�Ȃ��̏ꍇ�AContinue�ƂȂ�
  # �G���[�p�֐��g�p
  $counter = ErrorOccur($counter)

<# Inquire #>
  # �G���[�\���A���s�m�F
  $ErrorActionPreference = "Inquire"
  # �G���[�p�֐��g�p
  $counter = ErrorOccur($counter)

<# Inquire #>
  # �v����
  $ErrorActionPreference = "Suspend"
  # �G���[�p�֐��g�p
  $counter = ErrorOccur($counter)

<# SilentlyContinue #>
  # �G���[�\���Ȃ��A���f�Ȃ�
  $ErrorActionPreference = "SilentlyContinue"
  # �G���[�p�֐��g�p
  $counter = ErrorOccur($counter)

<# Stop #>
  # �v���I�łȂ��G���[�ŏ����I���ݒ�
  $ErrorActionPreference = "Stop"
  # �G���[�p�֐��g�p
  $counter = ErrorOccur($counter)