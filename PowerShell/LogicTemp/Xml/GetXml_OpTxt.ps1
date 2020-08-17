$Host.ui.RawUI.WindowTitle = $MyInvocation.MyCommand.Name
echo XML�擾
# �擾�Ώۗv�fXPath
# XPath �̗� | Microsoft Docs
# 	https://docs.microsoft.com/ja-jp/previous-versions/ms256086(v=vs.120)?redirectedfrom=MSDN
# powershell��XPath���g����XML�t�@�C����ǂ� : morituri�̃u���O
#   http://blog.livedoor.jp/morituri/archives/54105602.html
# �N���[���쐬�ɕK�{�IXPATH�̋L�@�܂Ƃ� - Qiita
#   https://qiita.com/rllllho/items/cb1187cec0fb17fc650a


<# �ݒ� #>
  # �Ώۃt�@�C��
  $tgtXmlPath = ".\TestXml\TestXml03.xml"
  # �G���R
  $enc = "UTF8"
  # ���ʏo�̓t�H���_
  $outDir = "Test\"
  # �֐����s���O���[�o���ϐ������l
  $global:i = 0


<# ���O���� #>
  # ���ʏo�̓t�H���_�쐬
  New-Item $outDir -ItemType Directory -Force
  Write-Host


<# XML�擾 #>
  # # XML�ǂݍ���
    $tgtXml = [XML](Get-Content -Encoding $enc $tgtXmlPath)
    # XPathNavigator�I�u�W�F�N�g����
    $xNavi = $tgtXml.CreateNavigator()


<# �֐� #>
  # # XPath�g�p�֐�
  function Xml-Select ($outFile, $xNavi, $xPath)
  {
    $global:i++

    # XPath�g�p
    $var = $xNavi.Select($xPath)

    # ���ʏo��
    Write-Host $global:i":$xPath"
    $var>$outFile
  }


<# XPath�g�p��ꗗ #>
  Write-Host "XPath�g�p��ꗗ"

  # ���[�g�v�f����S��
  #   NodeType :Root
  #   LocalName:�Ȃ�
  #   Name     :�Ȃ�
  $xNavi>$outDirroot.txt

  # XPath�g�p�֐��g�p
  # books�v�f����S��
  #   NodeType    :Element
  #   LocalName   :books
  #   NamespaceURI:�Ȃ�
  #   Name        :books
  Xml-Select $outDir"books.txt" $xNavi "books"
  Xml-Select $outDir"books_Slash.txt" $xNavi "/books"
  Xml-Select $outDir"books_DotSlash.txt" $xNavi "./books"
  Xml-Select $outDir"books_Asterisk.txt" $xNavi "*"

  # books/book�v�f
  #   NodeType    :Element
  #   LocalName   :book
  #   NamespaceURI:�Ȃ�
  #   Name        :book
  Xml-Select $outDir"book.txt" $xNavi "books/book"
  Xml-Select $outDir"book_Asterisk.txt" $xNavi "*/book"
  Xml-Select $outDir"book_WSlash.txt" $xNavi "//book"

  # books/book/author�v�f
  #   NodeType    :Element
  #   LocalName   :author
  #   NamespaceURI:�Ȃ�
  #   Name        :author
  # �S�Ă�author�v�f
  Xml-Select $outDir"author.txt" $xNavi "books/book/author"
  # ��ڂ�book��author�v�f
  Xml-Select $outDir"author01.txt" $xNavi "books/book[1]/author"
  Xml-Select $outDir"author01_pos.txt" $xNavi "books/book[position() = 1]/author"
  Xml-Select $outDir"author01_paren.txt" $xNavi "(books/book)[1]/author"
  # ��ڂ�book�̈�ڂ�author�v�f
  Xml-Select $outDir"author02_1.txt" $xNavi "books/book[2]/author[1]"

  # otherinfo�v�f
  #   NodeType    :Element
  #   LocalName   :otherinfo
  #   NamespaceURI:�Ȃ�
  #   Name        :otherinfo
  # books���̑Sotherinfo�v�f
  Xml-Select $outDir"otherinfo.txt" $xNavi "books//otherinfo"
  # books�̑��v�f�̑Sotherinfo�v�f
  Xml-Select $outDir"otherinfo_Asterisk.txt" $xNavi "books/*/otherinfo"
  # books�̂Б��v�f�̑Sotherinfo�v�f
  Xml-Select $outDir"otherinfo_WAsterisk.txt" $xNavi "books/*/*/otherinfo"
  # otherinfo�v�f���q�Ɂu����book�v�f
  Xml-Select $outDir"otherinfo_book.txt" $xNavi "*/book[otherinfo]"

  # ����
  # �S����
  Xml-Select $outDir"attr.txt" $xNavi "//@*"
  # genre�����S��
  Xml-Select $outDir"attr_genre.txt" $xNavi "//@genre"

  # ���������S�v�f(//:�S�v�f�A�u[�v�̑O�ɂ́u*�v������)
  Xml-Select $outDir"attr_elem.txt" $xNavi "//*[@*]"
  # genre���������S�v�f
  Xml-Select $outDir"attr_elem_genre.txt" $xNavi "//*[@genre]"
  # books�v�f��feature�����̒l�Ɠ���book�v�f
  Xml-Select $outDir"attr_elem_equal.txt" $xNavi "//*[/books/@feature=@genre]"
  Xml-Select $outDir"attr_elem_val.txt" $xNavi "//*[@genre='novel']"

  # �J�����g�ύX
  # books�v�f���J�����g�ɕύX
  $nextPath = $xNavi.Select("books")
  # book�v�f�S��
  Xml-Select $outDir"np_books.txt" $nextPath "book"
  Xml-Select $outDir"np_books_DotSlash.txt" $nextPath "./book"
  # �l�Ȃ�
  Xml-Select $outDir"np_books_Slash.txt" $nextPath "/book"
  # �v�f�S��(book��otherinfo)
  Xml-Select $outDir"np_books_Asterisk.txt" $nextPath "*"


  # $xNavi.Select("namesp:K")
    # $xNavi.Select("namesp:*")
    # $xNavi.Select("@namesp:*")

