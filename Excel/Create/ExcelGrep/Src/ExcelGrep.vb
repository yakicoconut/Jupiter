Rem 複数エクセル内検索
' 概要
'   複数のエクセル対象にセルの内容を検索し
'   該当のファイル名、シート名、セル位置を出力する
' 詳細
'   ・対象セル範囲はシート内の有効セル位置(入力があるセルで一番右下のもの)を
'     取得して検索を行い、無効範囲の検索を極力少なくする
' サイト
'   Range.Find メソッド (Excel)
'     https://msdn.microsoft.com/ja-jp/vba/excel-vba/articles/range-find-method-excel
'   Findで完全一致・部分一致を指定して検索するには:ExcelVBA Rangeオブジェクト-セル検索
'     https://www.relief.jp/docs/excel-vba-range-find-whole-part.html
'   Excel VBA 入門講座 検索 Find
'     http://excelvba.pc-users.net/fol7/7_1.html


Rem グローバル変数宣言
' 作業ワークシート
Dim thisWorkSheet As Worksheet
' 対象ルートフォルダパス
Dim targetRootFolder As String
' 一致フラグ
Dim lookAt As Variant
' 大小文字
Dim matchCase As Boolean
' サブフォルダ検索フラグ
Dim isSubFolder As Boolean


Rem メイン関数
Sub findAllBook()
  Rem 宣言
  Dim targetPath As String
  Dim findValue As String
  Dim rowNum As Long
  Dim columnNum As Long
  Dim isLookAtFlg As String
  Dim isMatchCaseFlg As String
  Dim isSubFolderFlg As String


  Rem 初期値
  ' 作業ワークシート
  Set thisWorkSheet = ThisWorkbook.Worksheets("FindExcel")
  ' 対象フォルダパス
  targetPath = thisWorkSheet.Cells(3, 9).MergeArea(1, 1).Value
  ' 対象ルートフォルダパス
  targetRootFolder = thisWorkSheet.Cells(3, 9).MergeArea(1, 1).Value
  ' 検索値
  findValue = thisWorkSheet.Cells(4, 9).MergeArea(1, 1).Value
  ' 結果出力開始セル初期値
  rowNum = 11
  columnNum = 3
  ' 完全一致フラグ
  isLookAtFlg = thisWorkSheet.Cells(5, 9).MergeArea(1, 1).Value
  ' 大小文字区別フラグ
  isMatchCaseFlg = thisWorkSheet.Cells(6, 9).MergeArea(1, 1).Value
  ' サブフォルダ検索フラグ
  isSubFolderFlg = thisWorkSheet.Cells(7, 9).MergeArea(1, 1).Value


  Rem オプション
  '完全一致フラグ
  ' xlPart:部分一致
  lookAt = XlLookAt.xlPart
  If LCase(isLookAtFlg) = "true" Then
    ' xlWhole:完全一致
    lookAt = xlWhole
  End If

  ' 大小文字区別フラグ
  ' False:大小文字区別しない
  matchCase = False
  If LCase(isMatchCaseFlg) = "true" Then
    ' True :大小文字区別する
    matchCase = True
  End If

  ' サブフォルダ検索フラグ
  ' False:検索しない
  isSubFolder = False
  If LCase(isSubFolderFlg) = "true" Then
    ' True :検索する
    isSubFolder = True
  End If


  ' ファイル検索関数使用
  Call FileSearch(targetPath, findValue, rowNum, columnNum)

End Sub


Rem ファイル検索関数
' targetPath :対象フォルダパス
' findValue  :検索値
' rowNum     :結果出力開始行
' columnNum  :結果出力開始列
Sub FileSearch(targetPath As String, findValue As String, rowNum As Long, columnNum As Long)
  Rem 宣言
  Dim FSO As Object, Folder As Variant, File As Variant
  Dim bOpened As Boolean
  Dim wb As Workbook
  Dim range As range
  Dim foundCell As range
  Dim firstAddress As String
  Dim sheetColumn As Long
  Dim isOutFileName As Boolean


  Rem 代入
  ' FileSystemObjectオブジェクト作成
  Set FSO = CreateObject("Scripting.FileSystemObject")


  Rem ファイル探索
  For Each x In FSO.GetFolder(targetPath).Files
    ' 結果出力列初期値
    sheetColumn = columnNum
    ' ファイル名出力フラグ初期値
    isOutFileName = True

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


    Rem ブック操作の非表示
    '     完全に非表示にすると処理をしているかわかり辛いため
    '     開いたブックの大きさを指定
    ' ※以前は非表示にしても画面表示されていたができなくなったためコメントアウト
    ' Application.ScreenUpdating = False
    Application.WindowState = xlNormal
    Application.Height = 50
    Application.Width = 40
    Application.Top = 730
    Application.Left = 1340


    Rem シート検索
    For Each y In wb.Worksheets
      ' シート内のセル使用範囲取得
      Set range = y.UsedRange

      ' 検索実行
      Set foundCell = range.Find(What:=findValue, lookIn:=xlValues, lookAt:=lookAt, matchCase:=matchCase)

      ' ねずみ返し_検索結果が存在しない場合
      If foundCell Is Nothing Then
        ' 次のシートへ
        GoTo NEXTSEET
      End If

      ' 一ファイル一回だけ処理
      If isOutFileName Then
        ' 対象ファイル名出力
        ' ※一ファイル一回だけ出力
        thisWorkSheet.Cells(rowNum, sheetColumn).Value = Replace(targetPath, targetRootFolder, "") + "\" + x.Name
        rowNum = rowNum + 1
        sheetColumn = sheetColumn + 1

        isOutFileName = False
      End If

      ' 該当シート名出力
      thisWorkSheet.Cells(rowNum, sheetColumn).Value = y.Name
      rowNum = rowNum + 1

      ' 出力結果を左上のセルからにするため一つ戻る
      Set foundCell = range.FindPrevious(foundCell)
      ' 検索結果最上位位置取得
      firstAddress = foundCell.Address


      Rem 検索結果ループ
      Do
        ' 検索結果(発見位置)出力
        thisWorkSheet.Cells(rowNum, sheetColumn + 1).Value = foundCell.Address(RowAbsolute:=False, ColumnAbsolute:=False)
        rowNum = rowNum + 1

        ' 次の検索結果位置へ
        Set foundCell = range.FindNext(foundCell)

      ' 最上位位置になるまでループ
      Loop Until foundCell.Address = firstAddress


NEXTSEET:
    ' 次のシートへ
    Next y

    ' ブッククローズ
    wb.Close


CONTINUE:
  ' 次のファイルへ
  Next x


  Rem サブフォルダ検索
  If isSubFolder Then
    For Each x In FSO.GetFolder(targetPath).SubFolders
      ' 本関数を回帰呼び出し
      Call FileSearch(x.path, findValue, rowNum, columnNum)
    Next x
  End If

End Sub


Rem 対象ブック開閉判断関数
' a_sFilePath:対象ファイルパス
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


