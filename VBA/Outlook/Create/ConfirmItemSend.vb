Option Explicit


Rem 送信時確認メッセージ表示
Private Sub Application_ItemSend(ByVal Item As Object, Cancel As Boolean)
' 概要
'   件名が指定のものの場合、メッセージを表示
' 詳細
'   ・「RE: [○○○]」
' サイト
'  減らそう誤送信！Outlook で送信確認メッセージを出す方法 ? hdc
'  	http://hdcinc.wp.xdomain.jp/?p=241


Rem エラー発生時はエラー処理へ
On Error GoTo Exception


Rem 宣言
' 文字列
Dim strAddress, strMessage, RE, strPattern, subject As String
' 正規表現変数
Dim reMatch
' あて先
Dim objRecipient As Recipient

' 正規表現検索対象
strPattern = "RE: \[.*\]"
' 初期化(改行)
strAddress = vbCrLf


Rem 事前処理
' 件目取得
subject = Item.Subject


Rem 正規表現インスタンス生成
Set RE = CreateObject("VBScript.RegExp")
With RE
  .Pattern = strPattern           ' 検索パターンを設定
  .IgnoreCase = True              ' 大文字と小文字を区別しない
  .Global = True                  ' 文字列全体を検索
  Set reMatch = .Execute(subject) ' 正規表現マッチ実行

  ' ねずみ返し_マッチしない場合
  If reMatch.Count = 0 Then
    ' 後処理へ
    GoTo POSTPROCESS
  End If

  ' 表示メッセージ作成
  strMessage = "件名:" & subject & vbCrLf & "上記の件名で送信します" & vbCrLf & "よろしいですか?"

  ' メッセージボックスで[いいえ]が選択された場合
  If MsgBox(strMessage, vbExclamation + vbYesNo + vbDefaultButton2) <> vbYes Then
    ' 後処理
    Set RE = Nothing
    ' 送信キャンセル
    Cancel = True
  End If

End With


Rem 後処理
POSTPROCESS:
    ' 正規表現インスタンス終了
    Set RE = Nothing


' Rem 全あて先取得
' For Each objRecipient In Item.Recipients
'   ' 「あて名」+「 」(半角スペース)+「アドレス」+「改行」
'   strAddress = strAddress & objRecipient.Name & " " & objRecipient.Address & vbCrLf
' Next


Rem エラーがなければ終了
On Error GoTo 0
  Exit Sub


Rem エラー処理
Exception:
  MsgBox CStr(Err.Number) & ":" & Err.Description, vbOKOnly + vbCritical
  Cancel = True
  Exit Sub


End Sub