$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
# # ���[�U���͊֘A�֐��N���X

class UsrInpClass
{
  <# �R���X�g���N�^ #>
    # # �R���X�g���N�^
    UsrInpClass()
    {

    }

  <# ���[�U���̓��\�b�h #>
    # # ���[�U����
    #   ����
    #     01:�\������
    #     02:�s�����̓��[�v
    #     03:���f���[�h
    #   �Ԃ�l
    #     01:���͒l(������)
    #     02:���f����(������)
    #          0   :���f���s
    #          1   :���f����
    #          �ȊO:�Y�����f�̕Ԃ�l
    [Object] UserInput([string] $description, [bool] $isInvalidLoop, [string] $mode)
    {
      # # ���O����
        # �ԋp�p���͒l������
        $usr = ""
        # �ԋp�p���茋�ʏ�����(1:����)
        $jdgResult = 1
        # ���͏������s�t���O������
        $isExec = $true
        # �\��������
        $desc = $description

      # # ��A���s���[�v
        while ($isExec)
        {
          # ���͏������\�b�h�g�p
          $inpData = $this.ExecInput($desc, $isInvalidLoop, $mode)
          # �ē��̓t���O
          $isExec = $inpData[0]
          if($isExec)
          {
            # �\�������X�V
            $desc = $inpData[1]
            continue
          }

          # ���͕�����ݒ�
          $usr = $inpData[1]
          # �ԋp�p���茋�ʐݒ�
          $jdgResult = $inpData[2]
        }

      # �ԋp�z��ǉ�
      $ret = @()
      $ret += $usr
      $ret += $jdgResult

      return $ret
    }

  <# ���͏������\�b�h #>
    # # ���[�U���͏���
    #   ����
    #     01:�\������
    #     02:�s�����̓��[�v
    #     03:���f���[�h
    #   �Ԃ�l
    #     01:�ē��̓t���O(bool)
    #          �^:�ē��͂���
    #          �U:�ē��͂��Ȃ�
    #     02:���ȉ������ꂩ
    #        �\������(string)
    #        ���͒l
    #     03:
    [object] ExecInput([string] $description, [bool] $isInvalidLoop, [string] $mode)
    {
      # # ���O����
        # �ԋp�p�z��
        $ret = @()
        # �ē��̓t���O������
        $reInpFlg = $isInvalidLoop
        # �ԋp�p���茋�ʏ�����(1:����)
        $jdgResult = 1

      # # ���͏���
        # �����\��
        Write-Host $description
        $usr = (Read-Host ���͂��Ă�������)
        Write-Host
        # �˂��ݕԂ�_�����͂̏ꍇ
        if($usr.length -eq 0)
        {
          # �ԋp�z��ǉ�
          $ret += $reInpFlg
          $ret += "���͒l������܂���"
          return $ret
        }

      # # �擪����W�N�H�[�g�폜
        if($usr.Substring(0, 1) -eq "`""){ $usr = $usr.Substring(1, $usr.Length - 1) }
        if($usr.Substring($usr.Length - 1, 1) -eq "`""){ $usr = $usr.Substring(0, $usr.Length - 1) }
    
      # # ���[�h�X�C�b�`
        switch ($mode)
        {
          "STR"
          {
            # ������̏ꍇ�A�s�����̓��[�v�t���O��
            # �g�p����Ȃ�
          }
          "PATH"
          {
            # �p�X���݃t���O�ݒ�
            $isExist = Test-Path($usr)
            # ���݂��Ȃ�
            if(-not $isExist)
            {
              # �s�����̓��[�v�L��
              IF($reInpFlg)
              {
                # �ԋp�z��ǉ�
                $ret += $reInpFlg
                $ret += "�Ώۃp�X�����݂��܂���"
                return $ret
                # ��L�ȊO�̃p�^�[��(�ȉ�)�͂��ׂĂ˂��ݕԂ�����K�v���Ȃ�
                # �E�p�X�����݂���
                # �E�s�����̓��[�v�������ȏꍇ
              }

              # �ԋp�p���茋�ʂ����s�ɐݒ�
              $jdgResult = 0
            }
          }
          "NUM"
          {

          }
          "DATE"
          {

          }
          "TIME"
          {

          }
  
          default
          {
            Write-Host "���[�h�����̒l����`�ƈقȂ邽��" -ForegroundColor red
            Write-Host "�I�����܂�" -ForegroundColor red
            exit
          }
        }
  
      # �ԋp�z��ǉ�
      $ret += $false
      $ret += $usr
      $ret += $jdgResult
  
      return $ret
    }
  }