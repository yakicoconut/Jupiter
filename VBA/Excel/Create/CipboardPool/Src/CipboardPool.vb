Sub A4�{�^��_Click()

'A4�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A4").Value
copyText.PutInClipboard
End Sub
Sub A5�{�^��_Click()

'A5�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A5").Value
copyText.PutInClipboard
End Sub
Sub A6�{�^��_Click()

'A6�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A6").Value
copyText.PutInClipboard
End Sub
Sub A7�{�^��_Click()

'A7�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A7").Value
copyText.PutInClipboard
End Sub
Sub A8�{�^��_Click()

'A8�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A8").Value
copyText.PutInClipboard
End Sub
Sub A9�{�^��_Click()

'A9�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A9").Value
copyText.PutInClipboard
End Sub
Sub A10�{�^��_Click()

'A10�̒l���R�s�[
Dim copyText As New DataObject
copyText.SetText Range("A10").Value
copyText.PutInClipboard
End Sub
Sub �N���A�{�^��_Click()

'A4:A10�N���A
Range("A4:A10").ClearContents
End Sub
Sub �Z�b�g�{�^��_Click()

'[�v�[��]�V�[�g[A4:A10]�R�s�[

set1_A4 = Sheets("�v�[��").Range("B2").Value
set1_A5 = Sheets("�v�[��").Range("B3").Value
set1_A6 = Sheets("�v�[��").Range("B4").Value
set1_A7 = Sheets("�v�[��").Range("B5").Value
set1_A8 = Sheets("�v�[��").Range("B6").Value
set1_A9 = Sheets("�v�[��").Range("B7").Value
set1_A10 = Sheets("�v�[��").Range("B8").Value

Range("A4") = set1_A4
Range("A5") = set1_A5
Range("A6") = set1_A6
Range("A7") = set1_A7
Range("A8") = set1_A8
Range("A9") = set1_A9
Range("A10") = set1_A10

End Sub
Sub �T�C�Y�{�^��_Click()

'�Ώۂ̃��[�N�u�b�N��ʏ�\������
Application.WindowState = xlNormal
'�G�N�Z���̃E�B���h�E�T�C�Y��ύX
Application.Height = 396
Application.Width = 600
Application.Top = 385
Application.Left = 840

End Sub
