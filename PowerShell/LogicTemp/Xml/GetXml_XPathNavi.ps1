$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML取得
# 取得対象要素XPath
# XPath の例 | Microsoft Docs
# 	https://docs.microsoft.com/ja-jp/previous-versions/ms256086(v=vs.120)?redirectedfrom=MSDN
# powershellでXPathを使ってXMLファイルを読む : morituriのブログ
#   http://blog.livedoor.jp/morituri/archives/54105602.html
# クローラ作成に必須！XPATHの記法まとめ - Qiita
#   https://qiita.com/rllllho/items/cb1187cec0fb17fc650a


<# 設定 #>
  # 対象ファイル
  $tgtXmlPath = ".\TestXml\TestXml03.xml"
  # エンコ
  $enc = "UTF8"
  # 結果出力フォルダ
  $outDir = "Test\"
  # 関数実行数グローバル変数初期値
  $global:i = 0


<# 事前準備 #>
  # 結果出力フォルダ作成
  New-Item $outDir -ItemType Directory -Force
  Write-Host


<# XML取得 #>
  # # XML読み込み
    $tgtXml = [XML](Get-Content -Encoding $enc $tgtXmlPath)
    # XPathNavigatorオブジェクト生成
    $xNavi = $tgtXml.CreateNavigator()


<# 関数 #>
  # # XPath使用関数
  function Xml-Select ($outFile, $xNavi, $xPath)
  {
    $global:i++

    # XPath使用
    $var = $xNavi.Select($xPath)

    # 結果出力
    Write-Host $global:i":$xPath"
    $var>$outFile
  }


<# XPath使用例一覧 #>
  Write-Host "XPath使用例一覧"

  # ルート要素から全て
  #   NodeType :Root
  #   LocalName:なし
  #   Name     :なし
  $xNavi>$outDirroot.txt

  # XPath使用関数使用
  # books要素から全て
  #   NodeType    :Element
  #   LocalName   :books
  #   NamespaceURI:なし
  #   Name        :books
  Xml-Select $outDir"books.txt" $xNavi "books"
  Xml-Select $outDir"books_Slash.txt" $xNavi "/books"
  Xml-Select $outDir"books_DotSlash.txt" $xNavi "./books"
  Xml-Select $outDir"books_Asterisk.txt" $xNavi "*"

  # books/book要素
  #   NodeType    :Element
  #   LocalName   :book
  #   NamespaceURI:なし
  #   Name        :book
  Xml-Select $outDir"book.txt" $xNavi "books/book"
  Xml-Select $outDir"book_Asterisk.txt" $xNavi "*/book"
  Xml-Select $outDir"book_WSlash.txt" $xNavi "//book"

  # books/book/author要素
  #   NodeType    :Element
  #   LocalName   :author
  #   NamespaceURI:なし
  #   Name        :author
  # 全てのauthor要素
  Xml-Select $outDir"author.txt" $xNavi "books/book/author"
  # 一つ目のbookのauthor要素
  Xml-Select $outDir"author01.txt" $xNavi "books/book[1]/author"
  Xml-Select $outDir"author01_pos.txt" $xNavi "books/book[position() = 1]/author"
  Xml-Select $outDir"author01_paren.txt" $xNavi "(books/book)[1]/author"
  # 二つ目のbookの一つ目のauthor要素
  Xml-Select $outDir"author02_1.txt" $xNavi "books/book[2]/author[1]"

  # otherinfo要素
  #   NodeType    :Element
  #   LocalName   :otherinfo
  #   NamespaceURI:なし
  #   Name        :otherinfo
  # books下の全otherinfo要素
  Xml-Select $outDir"otherinfo.txt" $xNavi "books//otherinfo"
  # booksの孫要素の全otherinfo要素
  Xml-Select $outDir"otherinfo_Asterisk.txt" $xNavi "books/*/otherinfo"
  # booksのひ孫要素の全otherinfo要素
  Xml-Select $outDir"otherinfo_WAsterisk.txt" $xNavi "books/*/*/otherinfo"
  # otherinfo要素を子に「持つbook要素
  Xml-Select $outDir"otherinfo_book.txt" $xNavi "*/book[otherinfo]"

  # 属性
  # 全属性
  Xml-Select $outDir"attr.txt" $xNavi "//@*"
  # genre属性全て
  Xml-Select $outDir"attr_genre.txt" $xNavi "//@genre"

  # 属性を持つ全要素(//:全要素、「[」の前には「*」をつける)
  Xml-Select $outDir"attr_elem.txt" $xNavi "//*[@*]"
  # genre属性を持つ全要素
  Xml-Select $outDir"attr_elem_genre.txt" $xNavi "//*[@genre]"
  # books要素のfeature属性の値と同じbook要素
  Xml-Select $outDir"attr_elem_equal.txt" $xNavi "//*[/books/@feature=@genre]"
  Xml-Select $outDir"attr_elem_val.txt" $xNavi "//*[@genre='novel']"

  # カレント変更
  # books要素をカレントに変更
  $nextPath = $xNavi.Select("books")
  # book要素全て
  Xml-Select $outDir"np_books.txt" $nextPath "book"
  Xml-Select $outDir"np_books_DotSlash.txt" $nextPath "./book"
  # 値なし
  Xml-Select $outDir"np_books_Slash.txt" $nextPath "/book"
  # 要素全て(bookとotherinfo)
  Xml-Select $outDir"np_books_Asterisk.txt" $nextPath "*"


  # $xNavi.Select("namesp:K")
    # $xNavi.Select("namesp:*")
    # $xNavi.Select("@namesp:*")

