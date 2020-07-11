$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得
# 取得対象要素XPath
# XPath の例 | Microsoft Docs
# 	https://docs.microsoft.com/ja-jp/previous-versions/ms256086(v=vs.120)?redirectedfrom=MSDN
# powershellでXPathを使ってXMLファイルを読む : morituriのブログ
#   http://blog.livedoor.jp/morituri/archives/54105602.html


<# 設定 #>
  # 対象ファイル
  $tgtXmlPath = ".\TestXml\TestXml01.xml"


<# XML取得 #>
  # # 準備
    # XML設定値エラーフラグ
    $errFlg = $true

  # # XML読み込み
    # テキストオープン
    $sr = [System.IO.File]::OpenText($tgtXmlPath)
    $xml = $sr.ReadToEnd()
    $sr.Close()

    # XML変換
    $tgtXml = [xml]$xml
    # XPathNavigatorオブジェクト生成
    $xNavi = $tgtXml.CreateNavigator()

  # # ルート要素取得
    $root = $xNavi.Select("*")

  # # 子全要素
    $elem = $root.Select("*")
    # 表示
    $elem

  # # 要素「B」
    Write-Host "##########################"
    Write-Host
    $elem2 = $root.Select("B")
    # 表示
    $elem2