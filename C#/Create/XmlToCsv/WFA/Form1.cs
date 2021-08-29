using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;

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
    public void GetConfig()
    {
      string hoge01 = _comLogic.GetConfigValue("Key01", "DefaultValue");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // StringReader設定
    XmlReaderSettings xmlSet;

    #endregion


    #region 初期設定メソッド
    private void SetInit()
    {
      /* StringReader設定 */
      xmlSet = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだが明示的に設定
      xmlSet.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだが明示的に設定
      xmlSet.IgnoreProcessingInstructions = false;
      // 意味のない空白を無視するかどうか
      xmlSet.IgnoreWhitespace = true;
    }
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 初期設定メソッド使用
      SetInit();
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // XmlCsv変換メソッド使用
      List<string> retList = ConvXmlToCsv(textBox1.Text);

      // CSV出力
      using (StreamWriter sw = new StreamWriter(@"test.csv", false, Encoding.UTF8))
      {
        foreach (string x in retList)
        {
          sw.WriteLine(x);
        }
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region XmlCsv変換メソッド
    private List<string> ConvXmlToCsv(string tgtPath)
    {
      // 返り値変数
      List<string> retList = new List<string>();

      // フルパスディクショナリ
      Dictionary<int, string> fullPathDic = new Dictionary<int, string>();
      // 属性ディクショナリ
      Dictionary<int, string> attrDic= new Dictionary<int, string>();
      // 値ディクショナリ
      Dictionary<int, string> valDic = new Dictionary<int, string>();

      // 累計パスリスト
      List<string> cmlPathList = new List<string>();

      // 階層順要素リスト
      List<string> depthElemList = new List<string>();

      // 最大属性数
      int attrMaxDepth = 0;
      // タグ行数
      int tagRow = 0;
      // 前回階層
      int preDepth = 0;

      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader strmRdr = new StreamReader(tgtPath))
      using (XmlReader xmlRdr = XmlReader.Create(strmRdr, xmlSet))
      {
        // XmlReader.Readメソッド使用パターン
        while (xmlRdr.Read())
        {
          // ノードタイプで分岐
          switch (xmlRdr.NodeType)
          {
            case XmlNodeType.Element: // 開始タグ
              // タグ行数インクリメント
              tagRow++;

              // 現在階層取得
              int dep = xmlRdr.Depth;

              // 前回階層との差を取得
              int calcI = dep - preDepth;
              // 前回より深くなった場合は「1」を設定
              int depI = calcI <= 0 ? calcI : 1;

              // 前回階層差ループ
              for (int i = depI; i <= 0; i++)
              {
                // 累計パスリストに要素がない場合
                int cnt = cmlPathList.Count;
                if(cnt == 0)
                {
                  break;
                }

                // 累計パスリストの後ろ1要素を削除
                cmlPathList.RemoveAt(cnt - 1);
              }

              // 要素名取得
              string pathName = xmlRdr.Name;

              // 累計パスリストに追加
              cmlPathList.Add(pathName);

              // 階層数分カンマを頭につけて累計パスリストに追加
              depthElemList.Add(new string(',', dep) + pathName);

              // 累計パスリストを「/」で結合
              string fullPathStr = string.Join("/", cmlPathList);

              // フルパスディクショナリ追加
              fullPathDic.Add(tagRow, string.Format("\"{0}\"", fullPathStr));

              // 現在階層を前回階層変数に引継ぎ
              preDepth = dep;

              // 属性がない場合
              if (!xmlRdr.HasAttributes)
              {
                break;
              }

              // 最大属性数を更新
              int attrCnt = xmlRdr.AttributeCount;
              if (attrMaxDepth < attrCnt)
              {
                attrMaxDepth = attrCnt;
              }

              // 属性をループ
              string attrStr = string.Empty;
              string attrStrFmt = "\"{0}\",\"{1}\"";
              for (int i = 0; i < attrCnt; i++)
              {
                // 属性へリーダを移動
                xmlRdr.MoveToAttribute(i);

                // 属性文字列設定
                attrStr += string.Format(attrStrFmt, xmlRdr.Name, xmlRdr.Value);
                // 次のフォーマット作成
                attrStrFmt = ",\"{0}\",\"{1}\"";
              }

              // 属性ディクショナリ追加
              attrDic.Add(tagRow, attrStr);
              break;

            case XmlNodeType.Text: // 値
              // 値ディクショナリ追加
              valDic.Add(tagRow, string.Format("\"{0}\"", xmlRdr.Value));
              break;

            case XmlNodeType.Comment: // コメントタグ
            case XmlNodeType.Attribute: // 属性
            case XmlNodeType.XmlDeclaration: // XML宣言
            case XmlNodeType.EndElement: // 終了タグ
            case XmlNodeType.None:
            default:
              continue;
          }
        }

        // ヘッダ初期値
        string headerStr = "ID,フルパス,値";
        // 属性ヘッダ作成
        for (int i = 1; i <= attrMaxDepth; i++)
        {
          // 名称+二桁階層数
          headerStr += string.Format(",属性名{0,2},属性値{0,2}", i.ToString());
        }

        // 返り値リストにヘッダ追加
        retList.Add(headerStr);
        // タグ行数ループ
        for (int i = 1; i <= tagRow; i++)
        {
          // 値ディクショナリに該当キーがある場合
          string valStr = string.Empty;
          if (valDic.ContainsKey(i))
          {
            // 値を設定
            valStr = valDic[i];
          }
          string attrStr = string.Empty;
          if (attrDic.ContainsKey(i))
          {
            attrStr = attrDic[i];
          }

          // 返り値リスト追加
          retList.Add(string.Format("{0},{1},{2},{3}", i.ToString(), fullPathDic[i], valStr, attrStr));
        }
      }

      // 階層順要素ループ
      foreach (string x in depthElemList)
      {
        // テキストボックスに出力
        textBox2.AppendText(x + Environment.NewLine);
      }

      return retList;
    }
    #endregion
  }
}
