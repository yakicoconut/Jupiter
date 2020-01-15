Rem 対象フォルダ内のエクセルから指定セルの値を取得する
' 概要
'   ExecuteExcel4Macro関数を使用して
'   ブックをオープンせずに取得する
' サイト
'   Excelファイルを開かずにシート名をチェック｜VBAサンプル集
'     https://excel-ubara.com/excelvba5/EXCEL122.html
'   Excelファイルを開かずにシート名を取得｜VBAサンプル集
'     https://excel-ubara.com/excelvba5/EXCEL121.html
'   A1 形式と R1C1 形式の変換、相対参照と絶対参照を変換 ConvertFormula | ExcelWork.info
'     https://excelwork.info/excel/cellconvertformula/
'   ExecuteExcel4Macroについて｜VBA技術解説
'     https://excel-ubara.com/excelvba4/EXCEL219.html
'   『ExecuteExcel4Macroの使用方法』（わかあゆ） エクセル Excel [エクセルの学校]
'     http://www.excel.studio-kazu.jp/kw/20100208214907.html
'   ExcelでADO・ADODBへの参照設定を:ADOの使い方
'     https://www.relief.jp/docs/excel-vba-referencing-to-adodb-library.html
Sub Main()
  Rem 宣言
  ' 出力内容
  Dim targetVal As String
  ' 対象フォルダ
  Dim targetDir As String
  ' 対象シート名
  Dim targetSheet As String
  ' 対象セル
  Dim rcCell As String


  Rem 初期値
  ' フォルダのパスを取得
  targetDir = Worksheets("FindExcel").Cells(3, 9).Value
  ' 先フォルダ(F2)の最後の文字が「\」でない場合
  If Right(targetDir, 1) <> "\" Then
    ' 「\」最後に追加する
    targetDir = targetDir & "\"
  End If

  ' 対象シート名を取得
  targetSheet = Worksheets("FindExcel").Cells(5, 9).Value

  ' 対象セル
  targetCell = Worksheets("FindExcel").Cells(4, 9).Value
  ' 対象セルのA1形式をR1C1形式に変換
  rcCell = Application.ConvertFormula( _
              Formula:=targetCell, _
              fromreferencestyle:=xlA1, _
              toreferencestyle:=xlR1C1, _
              toabsolute:=xlAbsolute, _
              relativeto:=[A1])

  ' 外部ブックセル取得関数使用
  Call GetExtBookCell(targetDir, targetSheet, rcCell)

End Sub


Rem 外部ブックセル取得関数
' targetDir  :対象フォルダ
' targetSheet:対象シート名
' targetCell :検証対象セル
Private Function GetExtBookCell(targetDir As String, targetSheet As String, rcCell As String)
  Rem
  ' インスタンスの作成
  Set FS = CreateObject("Scripting.FileSystemObject")
  ' 指定フォルダのFolderオブジェクトを取得
  Set Fol = FS.GetFolder(targetDir)
  ' ファイルを取得
  Set Fil = Fol.Files


  Rem ファイル処理
  ' 14行目からスタート
  i = 14
  For Each Fx In Fil
    ' ファイル名取得
    sFile = Fx.Name

    ' 該当ファイルの残業時間を表示
    targetVal = ExecuteExcel4Macro("'" & targetDir & "[" & sFile & "]" & targetSheet & "'!" & rcCell)
    Cells(i, 3) = targetVal

    ' 行数に1をプラス
    i = i + 1
  Next

End Function


''''''''''''''''''''''''''''''''''''''以下未検証''''''''''''''''''''''''''''''''''''''
Rem シート存在確認関数
' 事前
'   参照設定追加
'     [ツール]展開-[参照設定]-[Microsoft ActiveX Data Objects 2.X Library]追加
' 引数
'   targetFile:対象ファイル
'   sName     :検証シート名
Private Function SheetExist(ByVal targetFile As String, ByVal sName As String) As Boolean
  Rem 宣言
  Dim objCn As New ADODB.Connection
  Dim objRS As ADODB.Recordset
  Dim sSheet As String


  Rem 事前準備
  ' 返り値フラグ初期化
  SheetExist = False
  '
  On Error Resume Next


  Rem 処理
  ' 対象ファイルオープン
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

  ' エラーでない場合
  If Err.Number = 0 Then
    ' シート名の「!」を「_」に変換
    sName = Replace(sName, "!", "_")
    MsgBox sName
    '
    Do Until objRS.EOF
      ' 実シート名称取得
      sSheet = objRS.Fields("TABLE_NAME").Value

      ' 実シート名称の右末尾が「$」か「$'」の場合
      If Right(sSheet, 1) = "$" Or Right(sSheet, 2) = "$'" Then
        ' 余計な文字を除去
        If Right(sSheet, 1) = "$" Then
          sSheet = Left(sSheet, Len(sSheet) - 1)
        End If
        If Right(sSheet, 2) = "$'" Then
          sSheet = Left(sSheet, Len(sSheet) - 2)
        End If
        If Left(sSheet, 1) = "'" Then
          sSheet = Mid(sSheet, 2)
        End If

        ' 「''」を「'」に変換
        sSheet = Replace(sSheet, "''", "'")

        ' 検証シート名がと合致する場合
        If sName = sSheet Then
          ' フラグを立てる
          SheetExist = True
          Exit Do
        End If
      End If

      objRS.MoveNext
    Loop
  End If


  Rem 事後処理
  objRS.Close
  objCn.Close
  Set objRS = Nothing
  Set objCn = Nothing
  On Error GoTo 0

End Function