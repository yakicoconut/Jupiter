Rem �G�N�Z����\�����O��`�\��VBA
' �T�v
'   �G�N�Z���Ŕ�\���ƂȂ��Ă��閼�O��`��\������
' �T�C�g
'   Excel�̌����Ȃ����O��`���폜������@?Excel|?�V�X�e���J���u���O(�V�X�e���J���̃A�C���x�b�N�X�b�����s������̋Ɩ��V�X�e���J�����)
'   	https://www.ilovex.co.jp/blog/system/excel/excel-9.html


Rem ���C���֐�
Public Sub VisibleNames()
  Rem �錾
  ' ���o�����O����
  Dim wName As Object
  ' �J�E���^
  Dim wCnt As Long

  ' ���O��`���o��
  For Each wName In Names
    ' ��\���̏ꍇ
    If wName.Visible = False Then
      ' �\���ݒ�
      wName.Visible = True
      ' �J�E���^�C���N�������g
      wCnt = wCnt + 1
    End If
  Next

  ' �J�E���^��0�̏ꍇ
  If wCnt == 0 Then
      MsgBox "��\���̖��O��`�͂���܂���B",vbExclamation
  End If
End Sub
