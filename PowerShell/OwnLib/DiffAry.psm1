$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# # �z�񍷕��擾�֘A�N���X


class DiffAryClass
{
  <# �R���X�g���N�^ #>
    # # �R���X�g���N�^
    DiffAryClass()
    {

    }

  <# �z�񌇔@���o���\�b�h #>
    # # ��̔z�񂩂猇�@���Ă��鍀�ڂ𒊏o
    #   ����01:�Ώ۔z��
    #   ����02:��r�z��
    #   �Ԃ�l:����
    [object] LackDiff([object] $tgtAry, [object] $compAry)
    {
      # ��r�z��ɂȂ����̂��擾
      $lack = $tgtAry | Where-Object { $compAry -notcontains $_ }
      # �Ώۂ��Ȃ��ꍇ�Areturn���G���[�ƂȂ邽��?null�𖾎��I�ɐݒ�
      if($null -eq $lack){$lack = $null}

      return $lack
    }}