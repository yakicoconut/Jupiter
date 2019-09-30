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
' �Ώۃ��[�g�t�H���_�p�X
Dim targetRootFolder As String
' ��v�t���O
Dim lookAt As Variant
' �召����
Dim matchCase As Boolean
' �T�u�t�H���_�����t���O
Dim isSubFolder As Boolean
' �����t�@�C���J�E���^
Dim factCounter As Integer
' �S�t�@�C���J�E���^
Dim denomCounter As Integer
' �S�t�@�C���J�E���^�o�͍s
Dim denomCounterRow As Integer
' �S�t�@�C���J�E���^�o�͗�
Dim denomCounterColumn As Integer


Rem ���C���֐�
Sub FindAllBook()
  Rem �錾
  Dim targetPath As String
  Dim findValue As String
  Dim rowNum As Long
  Dim columnNum As Long
  Dim isLookAtFlg As String
  Dim isMatchCaseFlg As String
  Dim isSubFolderFlg As String
  Dim exclude() As String
  Dim strPt As String


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
  rowNum = 15
  columnNum = 3
  ' ���S��v�t���O
  isLookAtFlg = thisWorkSheet.Cells(5, 9).MergeArea(1, 1).Value
  ' �召������ʃt���O
  isMatchCaseFlg = thisWorkSheet.Cells(6, 9).MergeArea(1, 1).Value
  ' �T�u�t�H���_�����t���O
  isSubFolderFlg = thisWorkSheet.Cells(7, 9).MergeArea(1, 1).Value
  ' ���O�t�@�C���g���q�z��
  exclude = Split(thisWorkSheet.Cells(8, 9).MergeArea(1, 1).Value, ",")
  ' �Ώۃt�@�C�����K�\��
  strPt = thisWorkSheet.Cells(9, 9).MergeArea(1, 1).Value
  ' �����t�@�C���J�E���^
  factCounter = 0
  ' �S�t�@�C���J�E���^
  denomCounter = 0
  ' �����t�@�C���J�E���^�o�͍s(�����t�@�C���J�E���^�̏o�͈ʒu�͂��̕ϐ�����v�Z)
  denomCounterRow = 13
  ' �S�t�@�C���J�E���^�o�͗�(�����t�@�C���J�E���^�̏o�͈ʒu�͂��̕ϐ�����v�Z)
  denomCounterColumn = 5


  Rem �I�v�V����
  '���S��v�t���O
  ' xlPart:������v
  lookAt = XlLookAt.xlPart
  If LCase(isLookAtFlg) = "true" Then
    ' xlWhole:���S��v
    lookAt = xlWhole
  End If

  ' �召������ʃt���O
  ' False:�召������ʂ��Ȃ�
  matchCase = False
  If LCase(isMatchCaseFlg) = "true" Then
    ' True :�召������ʂ���
    matchCase = True
  End If

  ' �T�u�t�H���_�����t���O
  ' False:�������Ȃ�
  isSubFolder = False
  If LCase(isSubFolderFlg) = "true" Then
    ' True :��������
    isSubFolder = True
  End If


  ' �t�@�C���J�E���^�Z��������
  thisWorkSheet.Cells(denomCounterRow - 1, denomCounterColumn).Value = "0"
  thisWorkSheet.Cells(denomCounterRow, denomCounterColumn).Value = "0"

  ' �t�@�C�������֐��g�p
  Call FileSearch(targetPath, findValue, rowNum, columnNum, exclude, strPt)

End Sub


Rem �t�@�C�������֐�
' targetPath :�Ώۃt�H���_�p�X
' findValue  :�����l
' rowNum     :���ʏo�͊J�n�s
' columnNum  :���ʏo�͊J�n��
' exclude    :���O�t�@�C���g���q�z��
' strPt      :�Ώۃt�@�C�����K�\��
Sub FileSearch(targetPath As String, findValue As String, rowNum As Long, columnNum As Long, exclude() As String, strPt As String)
  Rem �錾
  Dim FSO As Object, Folder As Variant, File As Variant
  Dim bOpened As Boolean
  Dim wb As Workbook
  Dim range As range
  Dim foundCell As range
  Dim firstAddress As String
  Dim sheetColumn As Long
  Dim isOutFileName As Boolean
  Dim excludeFilterResult() As String
  Dim RE As Object
  Dim matches As Variant


  Rem ���
  ' FileSystemObject�I�u�W�F�N�g�쐬
  Set FSO = CreateObject("Scripting.FileSystemObject")
  ' ���K�\���I�u�W�F�N�g�쐬
  Set RE = CreateObject("VBScript.RegExp")
  ' �����p�^�[���ݒ�
  RE.Pattern = strPt


  Rem �t�@�C���T��
  For Each x In FSO.GetFolder(targetPath).Files
    ' ���ʏo�͗񏉊��l
    sheetColumn = columnNum
    ' �t�@�C�����o�̓t���O�����l
    isOutFileName = True

    ' �˂��ݕԂ�_�Ώۂ��G�N�Z���łȂ��ꍇ
    If InStr(x.Type, "Excel") <= 0 Then
      ' ����
      GoTo CONTINUE
    End If

    ' �˂��ݕԂ�_�Ώۃt�@�C���g���q�����O�t�@�C���g���q�̏ꍇ
    excludeFilterResult = Filter(exclude, "." + FSO.GetExtensionName(x))
    If UBound(excludeFilterResult) <> -1 Then
      GoTo CONTINUE
    End If

    ' �˂��ݕԂ�_���K�\���Ɉ�v���Ȃ��ꍇ
    Set matches = RE.Execute(x)
    If matches.Count <= 0 Then
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
      Set foundCell = range.Find(What:=findValue, lookIn:=xlValues, lookAt:=lookAt, matchCase:=matchCase)

      ' �˂��ݕԂ�_�������ʂ����݂��Ȃ��ꍇ
      If foundCell Is Nothing Then
        ' ���̃V�[�g��
        GoTo NEXTSEET
      End If

      ' ��t�@�C����񂾂�����
      If isOutFileName Then
        ' �Ώۃt�@�C�����o��
        ' ����t�@�C����񂾂��o��
        thisWorkSheet.Cells(rowNum, sheetColumn).Value = Replace(targetPath, targetRootFolder, "") + "\" + x.Name
        rowNum = rowNum + 1
        sheetColumn = sheetColumn + 1

        isOutFileName = False

        ' �����t�@�C���J�E���g
        factCounter = factCounter + 1
        thisWorkSheet.Cells(denomCounterRow - 1, denomCounterColumn).Value = Str(factCounter)

      End If

      ' �Y���V�[�g���o��
      thisWorkSheet.Cells(rowNum, sheetColumn).Value = y.Name
      rowNum = rowNum + 1

      ' �o�͌��ʂ�����̃Z������ɂ��邽�߈�߂�
      Set foundCell = range.FindPrevious(foundCell)
      ' �������ʍŏ�ʈʒu�擾
      firstAddress = foundCell.Address


      Rem �������ʃ��[�v
      Do
        ' ��������(�����ʒu)�o��
        thisWorkSheet.Cells(rowNum, sheetColumn + 1).Value = foundCell.Address(RowAbsolute:=False, ColumnAbsolute:=False)
        rowNum = rowNum + 1

        ' ���̌������ʈʒu��
        Set foundCell = range.FindNext(foundCell)

      ' �ŏ�ʈʒu�ɂȂ�܂Ń��[�v
      Loop Until foundCell.Address = firstAddress


NEXTSEET:
    ' ���̃V�[�g��
    Next y


    Rem �u�b�N�N���[�Y
    ' �ۑ��ς݃t���O�������Ă�(���ۂɂ͕ۑ�����Ă��Ȃ�)
    wb.Saved = True
    wb.Close


CONTINUE:
  ' �S�t�@�C���J�E���g
  denomCounter = denomCounter + 1
  thisWorkSheet.Cells(denomCounterRow, denomCounterColumn).Value = Str(denomCounter)

  ' ���̃t�@�C����
  Next x


  Rem �T�u�t�H���_����
  If isSubFolder Then
    For Each x In FSO.GetFolder(targetPath).SubFolders
      ' �{�֐�����A�Ăяo��
      Call FileSearch(x.path, findValue, rowNum, columnNum, exclude, strPt)
    Next x
  End If

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
