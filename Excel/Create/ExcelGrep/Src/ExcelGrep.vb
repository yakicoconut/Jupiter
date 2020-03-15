' ���C���֐�
Sub findAllBook()
  Dim rowNum As Long
  Dim path As String

  ' �Ώۃt�H���_�p�X
  path = ThisWorkbook.Worksheets("Sheet1").Cells(3, 9).MergeArea(1, 1).Value
  ' ���ʏo�͊J�n�s
  rowNum = 7

  ' �t�@�C�������֐��g�p
  Call FileSearch(path, rowNum)

End Sub


' �t�@�C�������֐�
' path  :
' rowNum:
Sub FileSearch(path As String, rowNum As Long)
  Dim FSO As Object, Folder As Variant, File As Variant
  Dim bOpened As Boolean
  Dim wb As Workbook
  Dim range As range
  Dim foundCell As range
  Dim firstAddress As String
  Dim sheetColumn As Long

  ' ���ʏo�͗񏉊��l
  sheetColumn = 9

  '
  With ThisWorkbook
    ' FileSystemObject�I�u�W�F�N�g�쐬
    Set FSO = CreateObject("Scripting.FileSystemObject")

    ' �t�@�C���T��
    For Each x In FSO.GetFolder(path).Files
      ' ���ʏo�͗񏉊��l
      sheetColumn = 9

      ' �˂��ݕԂ�_�Ώۂ��G�N�Z���łȂ��ꍇ
      If InStr(x.Type, "Excel") <= 0 Then
        ' ����
        GoTo CONTINUE
      End If

      ' �Ώۃu�b�N�J���f�֐��g�p
      bOpened = IsBookOpened(x)
      If (bOpened = False) Then
        ' �J��
        Set wb = Workbooks.Open(x, ReadOnly:=True)
      End If

      ' �u�b�N����̔�\��
      ' ���ȑO�͔�\���ɂ��Ă���ʕ\������Ă������ł��Ȃ��Ȃ������߃R�����g�A�E�g
      ' Application.ScreenUpdating = False
      ' ���S�ɔ�\���ɂ���Ə��������Ă��邩�킩��h������
      ' �J�����u�b�N�̑傫�����w��
      Application.WindowState = xlNormal
      Application.Height = 50
      Application.Width = 40
      Application.Top = 730
      Application.Left = 1340

      ' �Ώۃt�@�C�����o��
      .Worksheets("Sheet1").Cells(rowNum, sheetColumn).Value = x.Name
      rowNum = rowNum + 1
      sheetColumn = sheetColumn + 1


      ' �V�[�g����
      For Each y In wb.Worksheets
        ' �V�[�g���̃Z���g�p�͈͎擾
        Set range = y.UsedRange

        ' �������s
        Set foundCell = range.Find(What:=.Worksheets("Sheet1").Cells(4, 9).MergeArea(1, 1).Value, LookIn:=xlValues)
        ' �������ʂ�����
        If Not foundCell Is Nothing Then
          ' �������ʍŏ�ʈʒu
          firstAddress = foundCell.Address

          ' �Y���V�[�g���o��
          .Worksheets("Sheet1").Cells(rowNum, sheetColumn).Value = y.Name
          rowNum = rowNum + 1

          ' �������ʃ��[�v
          Do
            ' ��������(�����ʒu)�o��
            .Worksheets("Sheet1").Cells(rowNum, sheetColumn + 1).Value = foundCell.Address(RowAbsolute:=False, ColumnAbsolute:=False)
            rowNum = rowNum + 1

            ' ���̌������ʈʒu��
            Set foundCell = range.FindNext(foundCell)

            ' �������ʍŏ�ʈʒu
            If foundCell Is Nothing Then Exit Do

          ' �ŏ�ʈʒu�ɂȂ�܂Ń��[�v
          Loop Until foundCell.Address = firstAddress

        End If

      ' ���̃V�[�g��
      Next y
      ' �u�b�N�N���[�Y
      wb.Close


CONTINUE:
    ' ���̃t�@�C����
    Next x

    ' �T�u�t�H���_����
    For Each x In FSO.GetFolder(path).SubFolders
      ' �{�֐�����A�Ăяo��
      Call FileSearch(x.path, rowNum)
    Next x

  End With
End Sub


' �Ώۃu�b�N�J���f�֐�
' a_sFilePath:
Function IsBookOpened(a_sFilePath) As Boolean
  ' �G���[�����̏ꍇ�A���̍s����ăX�^�[�g�I�v�V����
  On Error Resume Next

  ' �Ԃ�l������
  IsBookOpened = False

  ' �ۑ��ς݂̃u�b�N������
  Open a_sFilePath For Append As #1
  Close #1

  ' ���ɊJ����Ă���ꍇ
  If Err.number > 0 Then
    IsBookOpened = True
  End If

End Function
