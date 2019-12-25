Rem エクセル非表示名前定義表示VBA
' 概要
'   エクセルで非表示となっている名前定義を表示する
' サイト
'   Excelの見えない名前定義を削除する方法?Excel|?システム開発ブログ(システム開発のアイロベックス｜東京都中央区の業務システム開発会社)
'   	https://www.ilovex.co.jp/blog/system/excel/excel-9.html


Rem メイン関数
Public Sub VisibleNames()
  Rem 宣言
  ' 取り出し名前項目
  Dim wName As Object
  ' カウンタ
  Dim wCnt As Long

  ' 名前定義取り出し
  For Each wName In Names
    ' 非表示の場合
    If wName.Visible = False Then
      ' 表示設定
      wName.Visible = True
      ' カウンタインクリメント
      wCnt = wCnt + 1
    End If
  Next

  ' カウンタが0の場合
  If wCnt == 0 Then
      MsgBox "非表示の名前定義はありません。",vbExclamation
  End If
End Sub
