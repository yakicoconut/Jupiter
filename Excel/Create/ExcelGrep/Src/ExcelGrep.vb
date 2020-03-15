' メイン関数
Sub findAllBook()
  Dim rowNum As Long
  Dim path As String

  ' 対象フォルダパス
  path = ThisWorkbook.Worksheets("Sheet1").Cells(3, 9).MergeArea(1, 1).Value
  ' 結果出力開始行
  rowNum = 7

  ' ファイル検索関数使用
  Call FileSearch(path, rowNum)

End Sub


' ファイル検索関数
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

  ' 結果出力列初期値
  sheetColumn = 9

  '
  With ThisWorkbook
    ' FileSystemObjectオブジェクト作成
    Set FSO = CreateObject("Scripting.FileSystemObject")

    ' ファイル探索
    For Each x In FSO.GetFolder(path).Files
      ' 結果出力列初期値
      sheetColumn = 9

      ' ねずみ返し_対象がエクセルでない場合
      If InStr(x.Type, "Excel") <= 0 Then
        ' 次へ
        GoTo CONTINUE
      End If

      ' 対象ブック開閉判断関数使用
      bOpened = IsBookOpened(x)
      If (bOpened = False) Then
        ' 開く
        Set wb = Workbooks.Open(x, ReadOnly:=True)
      End If

      ' ブック操作の非表示
      ' ※以前は非表示にしても画面表示されていたができなくなったためコメントアウト
      ' Application.ScreenUpdating = False
      ' 完全に非表示にすると処理をしているかわかり辛いため
      ' 開いたブックの大きさを指定
      Application.WindowState = xlNormal
      Application.Height = 50
      Application.Width = 40
      Application.Top = 730
      Application.Left = 1340

      ' 対象ファイル名出力
      .Worksheets("Sheet1").Cells(rowNum, sheetColumn).Value = x.Name
      rowNum = rowNum + 1
      sheetColumn = sheetColumn + 1


      ' シート検索
      For Each y In wb.Worksheets
        ' シート内のセル使用範囲取得
        Set range = y.UsedRange

        ' 検索実行
        Set foundCell = range.Find(What:=.Worksheets("Sheet1").Cells(4, 9).MergeArea(1, 1).Value, LookIn:=xlValues)
        ' 検索結果が存在
        If Not foundCell Is Nothing Then
          ' 検索結果最上位位置
          firstAddress = foundCell.Address

          ' 該当シート名出力
          .Worksheets("Sheet1").Cells(rowNum, sheetColumn).Value = y.Name
          rowNum = rowNum + 1

          ' 検索結果ループ
          Do
            ' 検索結果(発見位置)出力
            .Worksheets("Sheet1").Cells(rowNum, sheetColumn + 1).Value = foundCell.Address(RowAbsolute:=False, ColumnAbsolute:=False)
            rowNum = rowNum + 1

            ' 次の検索結果位置へ
            Set foundCell = range.FindNext(foundCell)

            ' 検索結果最上位位置
            If foundCell Is Nothing Then Exit Do

          ' 最上位位置になるまでループ
          Loop Until foundCell.Address = firstAddress

        End If

      ' 次のシートへ
      Next y
      ' ブッククローズ
      wb.Close


CONTINUE:
    ' 次のファイルへ
    Next x

    ' サブフォルダ検索
    For Each x In FSO.GetFolder(path).SubFolders
      ' 本関数を回帰呼び出し
      Call FileSearch(x.path, rowNum)
    Next x

  End With
End Sub


' 対象ブック開閉判断関数
' a_sFilePath:
Function IsBookOpened(a_sFilePath) As Boolean
  ' エラー発生の場合、次の行から再スタートオプション
  On Error Resume Next

  ' 返り値初期化
  IsBookOpened = False

  ' 保存済みのブックか判定
  Open a_sFilePath For Append As #1
  Close #1

  ' 既に開かれている場合
  If Err.number > 0 Then
    IsBookOpened = True
  End If

End Function
