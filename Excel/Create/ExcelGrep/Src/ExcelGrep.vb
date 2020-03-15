Rem �����G�N�Z��������
' �T�v
'   �����̃G�N�Z���ΏۂɃZ���̓��e��������
'   �Y���̃t�@�C�����A�V�[�g���A�Z���ʒu���o�͂���
' �ڍ�
'   �E�ΏۃZ���͈͂̓V�[�g���̗L���Z���ʒu(���͂�����Z���ň�ԉE���̂���)��
'     �擾���Č������s���A�����͈͂̌������ɗ͏��Ȃ�����
' �T�C�g
'   Range.Find ���\�b�h (Excel)
'     https://msdn.microsoft.com/ja-jp/vba/excel-vba/articles/range-find-method-excel
'   Find�Ŋ��S��v�E������v���w�肵�Č�������ɂ�:ExcelVBA Range�I�u�W�F�N�g-�Z������
'     https://www.relief.jp/docs/excel-vba-range-find-whole-part.html
'   Excel VBA ����u�� ���� Find
'     http://excelvba.pc-users.net/fol7/7_1.html


Rem �O���[�o���ϐ��錾
' ��ƃ��[�N�V�[�g
Dim thisWorkSheet As Worksheet


Rem ���C���֐�
Sub findAllBook()
  Rem �錾
  Dim targetPath As String
  Dim rowNum As Long
  Dim path As String


  Rem �����l
  ' ��ƃ��[�N�V�[�g
  Set thisWorkSheet = ThisWorkbook.Worksheets("FindExcel")
  ' �Ώۃt�H���_�p�X
  targetPath = thisWorkSheet.Cells(3, 9).MergeArea(1, 1).Value
  ' �Ώۃ��[�g�t�H���_�p�X
  targetRootFolder = thisWorkSheet.Cells(3, 9).MergeArea(1, 1).Value
  ' �����l
  findValue = thisWorkSheet.Cells(4, 9).MergeArea(1, 1).Value
  ' ���ʏo�͊J�n�Z�������l
  rowNum = 11
  columnNum = 3


  ' �t�@�C�������֐��g�p
  Call FileSearch(targetPath, rowNum)

End Sub


Rem �t�@�C�������֐�
' path  :�Ώۃt�H���_�p�X
' rowNum:���ʏo�͊J�n�s
Sub FileSearch(path As String, rowNum As Long)
  Rem �錾
  Dim FSO As Object, Folder As Variant, File As Variant
  Dim bOpened As Boolean
  Dim wb As Workbook
  Dim range As range
  Dim foundCell As range
  Dim firstAddress As String
  Dim sheetColumn As Long
  Dim isOutFileName As Boolean

  ' ���ʏo�͗񏉊��l
  sheetColumn = 11

  ' FileSystemObject�I�u�W�F�N�g�쐬
  Set FSO = CreateObject("Scripting.FileSystemObject")

  Rem �t�@�C���T��
  For Each x In FSO.GetFolder(path).Files
    ' ���ʏo�͗񏉊��l
    sheetColumn = 9
    ' �t�@�C�����o�̓t���O�����l
    isOutFileName = True

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

    Rem �u�b�N����̔�\��
    '     ���S�ɔ�\���ɂ���Ə��������Ă��邩�킩��h������
    '     �J�����u�b�N�̑傫�����w��
    ' ���ȑO�͔�\���ɂ��Ă���ʕ\������Ă������ł��Ȃ��Ȃ������߃R�����g�A�E�g
    ' Application.ScreenUpdating = False
    Application.WindowState = xlNormal
    Application.Height = 50
    Application.Width = 40
    Application.Top = 730
    Application.Left = 1340


    Rem �V�[�g����
    For Each y In wb.Worksheets
      ' �V�[�g���̃Z���g�p�͈͎擾
      Set range = y.UsedRange

      ' �������s
      Set foundCell = range.Find(What:=thisWorkSheet.Cells(4, 9).MergeArea(1, 1).Value, lookIn:=xlValues)

      ' �˂��ݕԂ�_�������ʂ����݂��Ȃ��ꍇ
      If foundCell Is Nothing Then
        ' ���̃V�[�g��
        GoTo NEXTSEET
      End If

      ' �t�@�C�����o�̓t���O
      If isOutFileName Then
        ' �Ώۃt�@�C�����o��
        ' ����t�@�C����񂾂��o��
        thisWorkSheet.Cells(rowNum, sheetColumn).Value = x.Name
        rowNum = rowNum + 1
        sheetColumn = sheetColumn + 1

        isOutFileName = False
      End If

      ' �Y���V�[�g���o��
      thisWorkSheet.Cells(rowNum, sheetColumn).Value = y.Name
      rowNum = rowNum + 1

      ' �������ʍŏ�ʈʒu
      firstAddress = foundCell.Address

      ' �������ʃ��[�v
      Do
        ' ��������(�����ʒu)�o��
        thisWorkSheet.Cells(rowNum, sheetColumn + 1).Value = foundCell.Address(RowAbsolute:=False, ColumnAbsolute:=False)
        rowNum = rowNum + 1

        ' ���̌������ʈʒu��
        Set foundCell = range.FindNext(foundCell)

        ' �������ʍŏ�ʈʒu
        If foundCell Is Nothing Then Exit Do

      ' �ŏ�ʈʒu�ɂȂ�܂Ń��[�v
      Loop Until foundCell.Address = firstAddress


NEXTSEET:
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

End Sub


Rem �Ώۃu�b�N�J���f�֐�
' a_sFilePath:�Ώۃt�@�C���p�X
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


