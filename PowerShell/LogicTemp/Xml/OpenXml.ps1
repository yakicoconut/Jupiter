$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XMLファイル読み込み
# PowerShell - XMLファイルの操作 | powershell Tutorial
# 	https://sodocumentation.net/ja/powershell/topic/4882/xml%E3%83%95%E3%82%A1%E3%82%A4%E3%83%AB%E3%81%AE%E6%93%8D%E4%BD%9C


<# 設定 #>
  # 対象ファイル
  $tgtXmlPath = ".\TestXml\TestXml01_Utf8.xml"
  # エンコ
  $enc = "UTF8"


<# XML取得 #>
  # # XMLドキュメント
    # XMLドキュメントオブジェクト生成
    $xml1 = New-Object System.Xml.XmlDocument
    # ファイルロード
    $xml1.load($tgtXmlPath)
    $xml1

  # # 変数型指定
    [xml]$xml2 = Get-Content -Encoding $enc $tgtXmlPath
    $xml2

  # # 読み込み型指定
    $xml3 = [xml](Get-Content -Encoding $enc $tgtXmlPath)
    $xml3

  # # オープンテキスト
    # テキストとして読み込み
    $sr = [System.IO.File]::OpenText($tgtXmlPath)
    $txt = $sr.ReadToEnd()
    $sr.Close()
    # XML変換
    $xml4 = [xml]$txt
    $xml4