Rem �Ώۃt�H���_���̃G�N�Z������w��Z���̒l���擾����
' �T�v
'   ExecuteExcel4Macro�֐����g�p����
'   �u�b�N���I�[�v�������Ɏ擾����
' �T�C�g
'   Excel�t�@�C�����J�����ɃV�[�g�����`�F�b�N�bVBA�T���v���W
'     https://excel-ubara.com/excelvba5/EXCEL122.html
'   Excel�t�@�C�����J�����ɃV�[�g�����擾�bVBA�T���v���W
'     https://excel-ubara.com/excelvba5/EXCEL121.html
'   A1 �`���� R1C1 �`���̕ϊ��A���ΎQ�ƂƐ�ΎQ�Ƃ�ϊ� ConvertFormula | ExcelWork.info
'     https://excelwork.info/excel/cellconvertformula/
'   ExecuteExcel4Macro�ɂ��ābVBA�Z�p���
'     https://excel-ubara.com/excelvba4/EXCEL219.html
'   �wExecuteExcel4Macro�̎g�p���@�x�i�킩����j �G�N�Z�� Excel [�G�N�Z���̊w�Z]
'     http://www.excel.studio-kazu.jp/kw/20100208214907.html
'   Excel��ADO�EADODB�ւ̎Q�Ɛݒ��:ADO�̎g����
'     https://www.relief.jp/docs/excel-vba-referencing-to-adodb-library.html
Sub Main()
  Rem �錾
  ' �o�͓��e
  Dim targetVal As String
  ' �Ώۃt�H���_
  Dim targetDir As String
  ' �ΏۃV�[�g��
  Dim targetSheet As String
  ' �ΏۃZ��
  Dim rcCell As String


  Rem �����l
  ' �t�H���_�̃p�X���擾
  targetDir = Worksheets("FindExcel").Cells(3, 9).Value
  ' ��t�H���_(F2)�̍Ō�̕������u\�v�łȂ��ꍇ
  If Right(targetDir, 1) <> "\" Then
    ' �u\�v�Ō�ɒǉ�����
    targetDir = targetDir & "\"
  End If

  ' �ΏۃV�[�g�����擾
  targetSheet = Worksheets("FindExcel").Cells(5, 9).Value

  ' �ΏۃZ��
  targetCell = Worksheets("FindExcel").Cells(4, 9).Value
  ' �ΏۃZ����A1�`����R1C1�`���ɕϊ�
  rcCell = Application.ConvertFormula( _
              Formula:=targetCell, _
              fromreferencestyle:=xlA1, _
              toreferencestyle:=xlR1C1, _
              toabsolute:=xlAbsolute, _
              relativeto:=[A1])

  ' �O���u�b�N�Z���擾�֐��g�p
  Call GetExtBookCell(targetDir, targetSheet, rcCell)

End Sub


Rem �O���u�b�N�Z���擾�֐�
' targetDir  :�Ώۃt�H���_
' targetSheet:�ΏۃV�[�g��
' targetCell :���ؑΏۃZ��
Private Function GetExtBookCell(targetDir As String, targetSheet As String, rcCell As String)
  Rem
  ' �C���X�^���X�̍쐬
  Set FS = CreateObject("Scripting.FileSystemObject")
  ' �w��t�H���_��Folder�I�u�W�F�N�g���擾
  Set Fol = FS.GetFolder(targetDir)
  ' �t�@�C�����擾
  Set Fil = Fol.Files


  Rem �t�@�C������
  ' 14�s�ڂ���X�^�[�g
  i = 14
  For Each Fx In Fil
    ' �t�@�C�����擾
    sFile = Fx.Name

    ' �Y���t�@�C���̎c�Ǝ��Ԃ�\��
    targetVal = ExecuteExcel4Macro("'" & targetDir & "[" & sFile & "]" & targetSheet & "'!" & rcCell)
    Cells(i, 3) = targetVal

    ' �s����1���v���X
    i = i + 1
  Next

End Function


''''''''''''''''''''''''''''''''''''''�ȉ�������''''''''''''''''''''''''''''''''''''''
Rem �V�[�g���݊m�F�֐�
' ���O
'   �Q�Ɛݒ�ǉ�
'     [�c�[��]�W�J-[�Q�Ɛݒ�]-[Microsoft ActiveX Data Objects 2.X Library]�ǉ�
' ����
'   targetFile:�Ώۃt�@�C��
'   sName     :���؃V�[�g��
Private Function SheetExist(ByVal targetFile As String, ByVal sName As String) As Boolean
  Rem �錾
  Dim objCn As New ADODB.Connection
  Dim objRS As ADODB.Recordset
  Dim sSheet As String


  Rem ���O����
  ' �Ԃ�l�t���O������
  SheetExist = False
  '
  On Error Resume Next


  Rem ����
  ' �Ώۃt�@�C���I�[�v��
  sFile = Application.GetOpenFilename(targetFile)
  If sFile = "False" Then
      Exit Function
  End If

  '
  With objCn
    .Provider = "Microsoft.ACE.OLEDB.12.0"
    .Properties("Extended Properties") = "Excel 12.0"
    .Open sFile

    '
    Set objRS = .OpenSchema(ADODB.adSchemaTables)
  End With

  ' �G���[�łȂ��ꍇ
  If Err.Number = 0 Then
    ' �V�[�g���́u!�v���u_�v�ɕϊ�
    sName = Replace(sName, "!", "_")
    MsgBox sName
    '
    Do Until objRS.EOF
      ' ���V�[�g���̎擾
      sSheet = objRS.Fields("TABLE_NAME").Value

      ' ���V�[�g���̂̉E�������u$�v���u$'�v�̏ꍇ
      If Right(sSheet, 1) = "$" Or Right(sSheet, 2) = "$'" Then
        ' �]�v�ȕ���������
        If Right(sSheet, 1) = "$" Then
          sSheet = Left(sSheet, Len(sSheet) - 1)
        End If
        If Right(sSheet, 2) = "$'" Then
          sSheet = Left(sSheet, Len(sSheet) - 2)
        End If
        If Left(sSheet, 1) = "'" Then
          sSheet = Mid(sSheet, 2)
        End If

        ' �u''�v���u'�v�ɕϊ�
        sSheet = Replace(sSheet, "''", "'")

        ' ���؃V�[�g�����ƍ��v����ꍇ
        If sName = sSheet Then
          ' �t���O�𗧂Ă�
          SheetExist = True
          Exit Do
        End If
      End If

      objRS.MoveNext
    Loop
  End If


  Rem ���㏈��
  objRS.Close
  objCn.Close
  Set objRS = Nothing
  Set objCn = Nothing
  On Error GoTo 0

End Function