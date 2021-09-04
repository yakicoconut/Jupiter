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
      // データセットクラスインスタンス生成
      DataStore ds = new DataStore();

      // Xml要素探索メソッド使用
      DigXmlElem(ds, textBox1.Text);

      // CSV出力
      using (StreamWriter swMain = new StreamWriter(@"test.csv", false, Encoding.UTF8))
      using (StreamWriter swSub = new StreamWriter(@"test_ElemNm.csv", false, Encoding.UTF8))
      {
        // 階層数分ループ
        for (int i = 0; i < ds.CrDepthNum - 1; i++)
        {
          // CSV変換後値
          swMain.WriteLine(ds.ConvdCsvList[i]);
          // 階層順要素
          swSub.WriteLine(ds.DepthElemList[i]);
        }
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region Xml要素探索メソッド
    /// <summary>
    /// Xml要素探索メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="tgtPath">対象パス</param>
    private void DigXmlElem(DataStore ds, string tgtPath)
    {
      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader strmRdr = new StreamReader(tgtPath))
      using (XmlReader xmlRdr = XmlReader.Create(strmRdr, xmlSet))
      {
        // ノードループ
        while (xmlRdr.Read())
        {
          // ノードタイプで分岐
          switch (xmlRdr.NodeType)
          {
            case XmlNodeType.Element: // 開始タグ
              // タグ行数インクリメント
              ds.CrDepthNum++;

              // 要素解析メソッド使用
              AnlXmlElem(ds, xmlRdr);
              break;

            case XmlNodeType.Text: // 値
              // 値カラムディクショナリ追加
              ds.ValColDic.Add(ds.CrDepthNum, string.Format("\"{0}\"", xmlRdr.Value));
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
      }

      // CSV変換後リスト追加メソッド使用
      AddConvdCsvList(ds);
    }
    #endregion

    #region 要素解析メソッド
    /// <summary>
    /// 要素解析メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="xmlRdr">リーダ</param>
    private void AnlXmlElem(DataStore ds, XmlReader xmlRdr)
    {
      // 現在階層取得
      int depNum = xmlRdr.Depth;

      // 前回階層との差を取得
      int calcI = depNum - ds.PreDepthNum;
      // 前回より深くなった場合は「1」を設定
      int depI = calcI <= 0 ? calcI : 1;

      // 前回階層差ループ
      for (int i = depI; i <= 0; i++)
      {
        // 累計パスリストに要素がない場合
        int cnt = ds.CmlPathList.Count;
        if (cnt == 0)
        {
          break;
        }

        // 累計パスリストの後ろ1要素を削除
        ds.CmlPathList.RemoveAt(cnt - 1);
      }

      // 要素名取得
      string elemName = xmlRdr.Name;

      // 累計パスリストに追加
      ds.CmlPathList.Add(elemName);

      // 累計パスリストを「/」で結合
      string fullPathStr = string.Join("/", ds.CmlPathList);
      // フルパスカラムディクショナリ追加
      ds.FullPathColDic.Add(ds.CrDepthNum, string.Format("\"{0}\"", fullPathStr));

      // 階層数分カンマを頭につけて累計パスリストに追加
      ds.DepthElemList.Add(new string(',', depNum) + elemName);

      // 現在階層を前回階層変数に引継ぎ
      ds.PreDepthNum = depNum;

      // 属性がない場合
      if (!xmlRdr.HasAttributes)
      {
        return;
      }

      // 属性解析メソッド使用
      AnlXmlAttr(ds, xmlRdr);
    }
    #endregion

    #region 属性解析メソッド
    /// <summary>
    /// 属性解析メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="xmlRdr">リーダ</param>
    private void AnlXmlAttr(DataStore ds, XmlReader xmlRdr)
    {
      // 最大属性数を更新
      int attrCnt = xmlRdr.AttributeCount;
      if (ds.AttrMaxDepthNum < attrCnt)
      {
        ds.AttrMaxDepthNum = attrCnt;
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
      ds.AttrColDic.Add(ds.CrDepthNum, attrStr);
    }
    #endregion

    #region CSV変換後リスト追加メソッド
    /// <summary>
    /// CSV変換後リスト追加メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    private void AddConvdCsvList(DataStore ds)
    {
      // ヘッダ初期値
      string headerStr = "No,フルパス,値";
      // 属性ヘッダ作成
      for (int i = 1; i <= ds.AttrMaxDepthNum; i++)
      {
        // 名称+二桁階層数
        headerStr += string.Format(",属性名{0,2},属性値{0,2}", i.ToString());
      }
      // CSV変換後リストにヘッダ追加
      ds.ConvdCsvList.Add(headerStr);

      // タグ行数ループ
      for (int i = 1; i <= ds.CrDepthNum; i++)
      {
        string valStr = string.Empty;
        string attrStr = string.Empty;

        // 値カラムディクショナリに該当キーがある場合
        if (ds.ValColDic.ContainsKey(i))
        {
          // 値を設定
          valStr = ds.ValColDic[i];
        }
        if (ds.AttrColDic.ContainsKey(i))
        {
          attrStr = ds.AttrColDic[i];
        }

        // CSV変換後リスト追加
        ds.ConvdCsvList.Add(string.Format("{0},{1},{2},{3}", i.ToString(), ds.FullPathColDic[i], valStr, attrStr));
      }
    }
    #endregion
  }
}
