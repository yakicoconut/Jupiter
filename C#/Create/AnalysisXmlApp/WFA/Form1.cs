using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    public Form1()
    {
      InitializeComponent();

      #region 【論理雛形】
      WFAComLogic WFACL = new WFAComLogic();
      // アプリ名設定
      Text = WFACL.GetAppName();
      #endregion

      // コンフィグ取得メソッド使用
      GetConfig();
    }
    #endregion

    #region コンフィグ取得メソッド
    private void GetConfig()
    {
      // 区切り文字
      searchKeySpr = _comLogic.GetConfigValue("SearchKeySpr", "; ");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 区切り文字
    string searchKeySpr;

    // ファイル名出力カウンタ(「1」の場合、出力)
    int fileCnt = 1;

    #endregion


    #region 初期設定メソッド
    private void SetInit()
    {
      // 変更後拡張子コンボボックス設定
      cbDigMode.DataSource = new string[] { "Raw", "Key" };
      // 変更後拡張子コンボボックス選択
      cbDigMode.SelectedItem = 0;
      // 区切り文字を表示
      cbIsUseSearchKeySpr.Text = string.Format(cbIsUseSearchKeySpr.Text, searchKeySpr);
    }
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 初期設定メソッド使用
      SetInit();
    }
    #endregion


    #region 共通_表示系テキストボックスキーダウンイベント
    private void Com_DspTextbox_KeyDown(object sender, KeyEventArgs e)
    {
      // Ctrl+Aの場合
      if (e.Control && e.KeyCode == Keys.A)
        // 発生元テキストボックスの内容を全選択
        ((TextBox)sender).SelectAll();
    }
    #endregion


    #region 検索ボタン押下イベント
    private void btDig_Click(object sender, EventArgs e)
    {
      // 対象パス取得
      string tgtPath = tbTgtPath.Text;
      // ねずみ返し
      if (tgtPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      /* 検索対象キー */
      // 変数スコープの都合上、配列として取得
      string[] searchKeys = { tbSearchKey.Text };
      // 値が存在するかつ区切り文字チェックがされている場合
      if (searchKeys[0] != string.Empty&& cbIsUseSearchKeySpr.Checked)
      {
        // 区切り文字配列変換
        string[] del = { searchKeySpr };
        // 区切り文字で検索対象キーを分割
        searchKeys = searchKeys[0].Split(del, StringSplitOptions.None);
      }

      /* StringReader設定 */
      XmlReaderSettings xmlSet = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだが明示的に設定
      xmlSet.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだが明示的に設定
      xmlSet.IgnoreProcessingInstructions = false;
      // 意味のない空白を無視するかどうか
      xmlSet.IgnoreWhitespace = true;

      // 表示用変数
      string tabDspStr = string.Empty;
      string rsltDspStr = string.Empty;

      // ファイルかフォルダか
      if (File.Exists(tgtPath))
      {
        // 山括弧抜き検索メソッド使用
        tabDspStr = DigWithoutThanSign(tgtPath, xmlSet);

        // 検索対象キーをループ
        foreach (string x in searchKeys)
        {
          // コンボボックスの値分岐
          switch (cbDigMode.Text)
          {
            case "Raw":
              // 生Xml取得メソッド使用
              rsltDspStr += GetRawXml(tgtPath);
              break;
            case "Key":
              // キー検索メソッド使用
              rsltDspStr += DigKey(tgtPath, xmlSet, x);
              break;
          }
        }
      }
      else if (Directory.Exists(tgtPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] tgtFldr = Directory.GetFiles(tgtPath, "*.xml", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in tgtFldr)
        {
          // 山括弧抜き検索メソッド使用
          tabDspStr += DigWithoutThanSign(x, xmlSet);
          // 検索対象キーをループ
          foreach (string y in searchKeys)
          {
            // コンボボックスの値分岐
            switch (cbDigMode.Text)
            {
              case "Raw":
                // 生Xml取得メソッド使用
                rsltDspStr += GetRawXml(tgtPath);
                break;
              case "Key":
                // キー検索メソッド使用
                rsltDspStr += DigKey(tgtPath, xmlSet, x);
                break;
            }

            // ファイル名出力カウンタ更新
            ++fileCnt;
          }

          // ファイル名出力カウンタ初期化
          fileCnt = 1;
        }
      }

      // 結果表示
      tbTabDsp.Text = tabDspStr;
      tbRsltDsp.Text = rsltDspStr;

      // 結果がない場合
      if (rsltDspStr == string.Empty)
      {
        tbRsltDsp.Text = "結果なし";
      }
    }
    #endregion

    #region 作成ボタン押下イベント
    private void btCreate_Click(object sender, EventArgs e)
    {
      string tgtPath = tbTgtPath.Text;

      // ねずみ返し
      if (tgtPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // XML作成メソッド使用
      CreateXml(tgtPath);
    }
    #endregion


    #region XML作成メソッド
    private void CreateXml(string savePath)
    {
      // XML型のインスタンス生成
      XmlDocument xmlDoc = new XmlDocument();
      // 要素変数
      XmlElement nestElem;

      // XML宣言
      XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
      // 追加
      xmlDoc.AppendChild(xmlDecl);

      // 基底タグの作成
      XmlElement baseElem = xmlDoc.CreateElement("catalog");
      // 追加
      xmlDoc.AppendChild(baseElem);

      // 1階層目の作成
      XmlElement nestElem1_1 = xmlDoc.CreateElement("book");
      // 属性の付加
      nestElem1_1.SetAttribute("id", "bk101");
      // 追加
      baseElem.AppendChild(nestElem1_1);
      // 2階層目の作成
      // タグの追加
      nestElem = xmlDoc.CreateElement("author");
      nestElem.InnerText = "Gambardella, Matthew";
      nestElem1_1.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("title");
      nestElem.InnerText = "XML Developer's Guide";
      nestElem1_1.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("genre");
      nestElem.InnerText = "Computer";
      nestElem1_1.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("price");
      nestElem.InnerText = "44.95";
      nestElem1_1.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("publish_date");
      nestElem.InnerText = "2000-10-01";
      nestElem1_1.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("description");
      nestElem.InnerText = "test description bk101";
      nestElem1_1.AppendChild(nestElem);

      // 1階層目の作成
      XmlElement nestElem1_2 = xmlDoc.CreateElement("book");
      // 属性の付加
      nestElem1_2.SetAttribute("id", "bk102");
      // 追加
      baseElem.AppendChild(nestElem1_2);
      // 2階層目の作成
      // タグの追加
      nestElem = xmlDoc.CreateElement("author");
      nestElem.InnerText = "Ralls, Kim";
      nestElem1_2.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("title");
      nestElem.InnerText = "Midnight Rain";
      nestElem1_2.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("genre");
      nestElem.InnerText = "Fantasy";
      nestElem1_2.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("price");
      nestElem.InnerText = "5.95";
      nestElem1_2.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("publish_date");
      nestElem.InnerText = "2000-12-16";
      nestElem1_2.AppendChild(nestElem);
      // タグの追加
      nestElem = xmlDoc.CreateElement("description");
      nestElem.InnerText = "test description bk102";
      nestElem1_2.AppendChild(nestElem);

      // XMLの保存
      xmlDoc.Save(savePath);
    }
    #endregion


    #region 山括弧抜き検索メソッド
    private string DigWithoutThanSign(string tgtPath, XmlReaderSettings xmlSet)
    {
      // 返り値変数
      string retStr = string.Empty;

      // ファイル名
      retStr += Path.GetFileName(tgtPath) + "\r\n";

      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader strmRdr = new StreamReader(tgtPath))
      using (XmlReader xmlStrmRdr = XmlReader.Create(strmRdr, xmlSet))
      using (XmlReader xmlRdr = xmlStrmRdr)
      {
        // XmlReader.Readメソッド使用パターン
        while (xmlRdr.Read())
        {
          // 階層の深さ基底より下の場合
          string depth = "";
          if (xmlRdr.Depth >= 1)
          {
            // インデントを作成
            depth = " ".PadRight(xmlRdr.Depth * 2);
          }

          // ノードタイプで分岐
          switch (xmlRdr.NodeType)
          {
            case XmlNodeType.Attribute:
              break;
            case XmlNodeType.XmlDeclaration: // XML宣言
              retStr += "?" + xmlRdr.Name;
              retStr += " " + xmlRdr.Value + "?";
              retStr += "\r\n";
              break;
            case XmlNodeType.Element: // 開始タグ
              retStr += depth + xmlRdr.Name;

              // 属性がある場合
              for (int i = 0; i < xmlRdr.AttributeCount; i++)
              {
                // 属性へリーダを移動
                xmlRdr.MoveToAttribute(i);
                retStr += " " + xmlRdr.Name;
                retStr += @"=""" + xmlRdr.Value + @"""";
              }
              retStr += "\r\n";
              break;
            case XmlNodeType.Text: // 値
              retStr += depth + xmlRdr.Value + "\r\n";
              break;
            case XmlNodeType.EndElement: // 終了タグ
              retStr += depth + "/" + xmlRdr.Name + "\r\n";
              break;
            case XmlNodeType.Comment: // コメントタグ
              retStr += depth + "!--" + xmlRdr.Value + "--" + "\r\n";
              break;
            case XmlNodeType.None:
              break;
            default:
              break;
          }
        }
      }

      // 改行
      retStr += "\r\n";

      return retStr;
    }
    #endregion

    #region 生Xml取得メソッド
    private string GetRawXml(string tgtStr)
    {
      // 返り値変数
      string retStr = string.Empty;

      // ファイルからXmlReaderでXMLを取得
      using (StreamReader strmRdr = new StreamReader(tgtStr))
      {
        retStr += strmRdr.ReadToEnd();
      }

      // 改行
      retStr += "\r\n";

      return retStr;
    }
    #endregion

    #region キー検索メソッド
    private string DigKey(string tgtStr, XmlReaderSettings xmlSet, string searchKey)
    {
      // 返り値変数
      string retStr = string.Empty;
      // 対象ファイル名
      string fileName = Path.GetFileName(tgtStr);

      // ファイル名出力チェックボックスかつファイル名出力カウンタが「1」の場合
      if (cbIsOutFileName.Checked && fileCnt == 1)
      {
        // ファイル名出力
        retStr += fileName + "\r\n";
      }

      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader strmRdr = new StreamReader(tgtStr))
      using (XmlReader xmlStrmRdr = XmlReader.Create(strmRdr, xmlSet))
      using (XmlReader xmlRdr = xmlStrmRdr)
      {
        // 要素ループ
        while (xmlRdr.ReadToFollowing(searchKey))
        {
          // 属性チェックボックス
          if (cbIsOutAttr.Checked)
          {
            // 属性取得メソッド使用
            retStr += GetAttr(xmlRdr);
          }
          // 値出力チェックボックス
          if (cbIsOutVal.Checked)
          {
            // 返り値フォーマット
            string RETURN_FORMAT = "{0}\r\n";
            // キー名称チェックボックス
            if (cbIsOutKeyName.Checked)
            {
              RETURN_FORMAT = searchKey + "\t:" + RETURN_FORMAT;
            }
            // タブチェックボックス
            if (cbIsTab.Checked)
            {
              RETURN_FORMAT = "\t" + RETURN_FORMAT;
            }

            // 値追加
            string value = xmlRdr.ReadString();
            retStr += string.Format(RETURN_FORMAT, value);
          }
        }
      }

      // 検索対象なし出力チェックボックス
      if (cbIsNoting.Checked)
      {
        // 検索結果が存在しない場合
        if (retStr == fileName + "\r\n" || retStr == string.Empty)
        {
          // 返り値フォーマット
          string RETURN_FORMAT = "検索対象なし\r\n";
          // キー名称チェックボックス
          if (cbIsOutKeyName.Checked)
          {
            RETURN_FORMAT = searchKey + "\t:" + RETURN_FORMAT;
          }
          // タブチェックボックス
          if (cbIsTab.Checked)
          {
            RETURN_FORMAT = "\t" + RETURN_FORMAT;
          }

          retStr += RETURN_FORMAT;
        }
      }

      return retStr;
    }
    #endregion


    #region 属性取得メソッド
    private string GetAttr(XmlReader xmlRdr)
    {
      string preRetStr = string.Empty;
      string retStr = string.Empty;
      string outHead = string.Empty;
      string HEAD_FORMAT = "値{0}\r\n";
      // キー名称チェックボックス
      if (cbIsOutKeyName.Checked)
      {
        HEAD_FORMAT = "キー名称\t:" + HEAD_FORMAT;
      }
      // タブチェックボックス
      if (cbIsTab.Checked)
      {
        HEAD_FORMAT = "\t" + HEAD_FORMAT;
      }

      // 属性ループ
      int ii = 0;
      while (xmlRdr.MoveToNextAttribute())
      {
        // 返り値フォーマット
        string RETURN_FORMAT = "{0}\r\n";
        // 属性名取得
        string AttrName = xmlRdr.Name;
        // 属性取得
        string Attr = xmlRdr.GetAttribute(ii);

        // タブチェック
        if (cbIsTab.Checked)
        {
          // 属性が一つしかない
          if (xmlRdr.AttributeCount == 1)
          {
            // タブ、改行複合
            RETURN_FORMAT = "\t\t{0}\r\n";
          }
          else if (ii == 0) // 最初の属性
          {
            // タブ二個追加
            RETURN_FORMAT = "\t\t{0}";
          }
          else if (ii == xmlRdr.AttributeCount - 1) // 最後の属性
          {
            // 更に改行追加
            RETURN_FORMAT = "\t{0}\r\n";
          }
        }

        // 属性名追加
        outHead += "\t" + AttrName;
        // 属性追加
        preRetStr += string.Format(RETURN_FORMAT, Attr);

        ++ii;
      }

      // タブチェックかつヘッダー出力かつファイル名出力カウンタ「1」の場合
      if (cbIsTab.Checked && cbIsHeader.Checked && fileCnt == 1)
      {
        retStr += string.Format(HEAD_FORMAT, outHead);
      }
      retStr += preRetStr;

      return retStr;
    }
    #endregion
  }
}
