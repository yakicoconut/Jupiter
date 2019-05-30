Sub A4ボタン_Click()

'A4の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A4").Value
copyText.PutInClipboard
End Sub
Sub A5ボタン_Click()

'A5の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A5").Value
copyText.PutInClipboard
End Sub
Sub A6ボタン_Click()

'A6の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A6").Value
copyText.PutInClipboard
End Sub
Sub A7ボタン_Click()

'A7の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A7").Value
copyText.PutInClipboard
End Sub
Sub A8ボタン_Click()

'A8の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A8").Value
copyText.PutInClipboard
End Sub
Sub A9ボタン_Click()

'A9の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A9").Value
copyText.PutInClipboard
End Sub
Sub A10ボタン_Click()

'A10の値をコピー
Dim copyText As New DataObject
copyText.SetText Range("A10").Value
copyText.PutInClipboard
End Sub
Sub クリアボタン_Click()

'A4:A10クリア
Range("A4:A10").ClearContents
End Sub
Sub セットボタン_Click()

'[プール]シート[A4:A10]コピー

set1_A4 = Sheets("プール").Range("B2").Value
set1_A5 = Sheets("プール").Range("B3").Value
set1_A6 = Sheets("プール").Range("B4").Value
set1_A7 = Sheets("プール").Range("B5").Value
set1_A8 = Sheets("プール").Range("B6").Value
set1_A9 = Sheets("プール").Range("B7").Value
set1_A10 = Sheets("プール").Range("B8").Value

Range("A4") = set1_A4
Range("A5") = set1_A5
Range("A6") = set1_A6
Range("A7") = set1_A7
Range("A8") = set1_A8
Range("A9") = set1_A9
Range("A10") = set1_A10

End Sub
Sub サイズボタン_Click()

'対象のワークブックを通常表示する
Application.WindowState = xlNormal
'エクセルのウィンドウサイズを変更
Application.Height = 396
Application.Width = 600
Application.Top = 385
Application.Left = 840

End Sub
