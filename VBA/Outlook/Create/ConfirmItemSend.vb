Option Explicit


Rem ���M���m�F���b�Z�[�W�\��
Private Sub Application_ItemSend(ByVal Item As Object, Cancel As Boolean)
' �T�v
'   �������w��̂��̂̏ꍇ�A���b�Z�[�W��\��
' �ڍ�
'   �E�uRE: [������]�v
' �T�C�g
'  ���炻���둗�M�IOutlook �ő��M�m�F���b�Z�[�W���o�����@ ? hdc
'  	http://hdcinc.wp.xdomain.jp/?p=241


Rem �G���[�������̓G���[������
On Error GoTo Exception


Rem �錾
' ������
Dim strAddress, strMessage, RE, strPattern, subject As String
' ���K�\���ϐ�
Dim reMatch
' ���Đ�
Dim objRecipient As Recipient

' ���K�\�������Ώ�
strPattern = "RE: \[.*\]"
' ������(���s)
strAddress = vbCrLf


Rem ���O����
' ���ڎ擾
subject = Item.Subject


Rem ���K�\���C���X�^���X����
Set RE = CreateObject("VBScript.RegExp")
With RE
  .Pattern = strPattern           ' �����p�^�[����ݒ�
  .IgnoreCase = True              ' �啶���Ə���������ʂ��Ȃ�
  .Global = True                  ' ������S�̂�����
  Set reMatch = .Execute(subject) ' ���K�\���}�b�`���s

  ' �˂��ݕԂ�_�}�b�`���Ȃ��ꍇ
  If reMatch.Count = 0 Then
    ' �㏈����
    GoTo POSTPROCESS
  End If

  ' �\�����b�Z�[�W�쐬
  strMessage = "����:" & subject & vbCrLf & "��L�̌����ő��M���܂�" & vbCrLf & "��낵���ł���?"

  ' ���b�Z�[�W�{�b�N�X��[������]���I�����ꂽ�ꍇ
  If MsgBox(strMessage, vbExclamation + vbYesNo + vbDefaultButton2) <> vbYes Then
    ' �㏈��
    Set RE = Nothing
    ' ���M�L�����Z��
    Cancel = True
  End If

End With


Rem �㏈��
POSTPROCESS:
    ' ���K�\���C���X�^���X�I��
    Set RE = Nothing


' Rem �S���Đ�擾
' For Each objRecipient In Item.Recipients
'   ' �u���Ė��v+�u �v(���p�X�y�[�X)+�u�A�h���X�v+�u���s�v
'   strAddress = strAddress & objRecipient.Name & " " & objRecipient.Address & vbCrLf
' Next


Rem �G���[���Ȃ���ΏI��
On Error GoTo 0
  Exit Sub


Rem �G���[����
Exception:
  MsgBox CStr(Err.Number) & ":" & Err.Description, vbOKOnly + vbCritical
  Cancel = True
  Exit Sub


End Sub