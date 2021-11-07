using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Linq;

namespace WFA
{
  /// <summary>
  /// メインフォーム
  /// </summary>
  public partial class Form1 : Form
  {
    #region コンストラクタ
    /// <summary>
    /// コンストラクタ
    /// </summary>
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
    /// <summary>
    /// コンフィグ取得メソッド
    /// </summary>
    private void GetConfig()
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
    /// <summary>
    /// 初期設定メソッド
    /// </summary>
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
    /// <summary>
    /// フォームロードイベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
      // 初期設定メソッド使用
      SetInit();
    }
    #endregion

    #region CSV出力ボタン押下イベント
    /// <summary>
    /// CSV出力ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btXmlToCsv_Click(object sender, EventArgs e)
    {
      bool bRet = true;
      // 対象パス
      string tgtPath = _comLogic.ExclIniEndWQuot(tbTgtPath.Text);
      // データセットクラスインスタンス生成
      DataStore ds = new DataStore();

      // Xml採掘メソッド使用
      bRet = MiningXml(ds, tgtPath);
      if (!bRet)
      {
        return;
      }

      // ファイル名称取得
      string tgtName = Path.GetFileName(tgtPath);

      // CSV出力
      using (StreamWriter swMain = new StreamWriter(tgtName + ".csv", false, Encoding.UTF8))
      using (StreamWriter swSub = new StreamWriter(tgtName + "_ElemInfo.csv", false, Encoding.UTF8))
      {
        // 階層数分ループ
        for (int i = 0; i <= ds.TotalRowNum; i++)
        {
          // CSV変換後リスト
          swMain.WriteLine(ds.Xml2CsvList[i]);
          // 階層順要素情報リスト
          swSub.WriteLine(ds.ElemInfo2CsvList[i]);
        }
      }
    }
    #endregion

    #region XML復元ボタン押下イベント
    /// <summary>
    /// XML復元ボタン押下イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btRestoreCsv_Click(object sender, EventArgs e)
    {
      // 対象パス
      string tgtPath = _comLogic.ExclIniEndWQuot(tbTgtPath.Text);
      // ファイル名称取得
      string tgtName = Path.GetFileName(tgtPath);

      // CSV読み込みメソッド
      List<List<string>> csvContents = DumpCsv(tgtPath);

      #region ヘッダ確認

      // ヘッダ行ループ
      int colIdx = 0;
      bool isErrColOrder = false;
      foreach (string x in csvContents[0])
      {
        colIdx++;

        // 列名分岐
        switch (x)
        {
          case "No":
            // 列番号が正しくない場合、エラーフラグを立てる
            if (colIdx != 1) isErrColOrder = true;
            break;
          case "フルパス":
            if (colIdx != 2) isErrColOrder = true;
            break;
          case "階層数":
            if (colIdx != 3) isErrColOrder = true;
            break;
          case "空要素":
            if (colIdx != 4) isErrColOrder = true;
            break;
          case "要素名称":
            if (colIdx != 5) isErrColOrder = true;
            break;
          case "値":
            if (colIdx != 6) isErrColOrder = true;
            break;

          default:
            // 属性系の場合
            if (x.Contains("属性"))
            {
              break;
            }
            isErrColOrder = true;
            break;
        }

        // 列エラーフラグが立っている場合
        if (isErrColOrder)
        {
          MessageBox.Show("ヘッダ列エラー");
          return;
        }
      }

      // ヘッダの内容が問題なかった場合、ヘッダ行削除
      csvContents.RemoveAt(0);

      #endregion

      // XML復元メソッド
      RestoreXml(csvContents, tgtName + ".xml");
    }
    #endregion


    #region Xml採掘メソッド
    /// <summary>
    /// Xml採掘メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="tgtPath">対象パス</param>
    private bool MiningXml(DataStore ds, string tgtPath)
    {
      bool bRet = true;

      try
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
                // 現在階層取得
                int depNum = xmlRdr.Depth;
                // 要素名取得
                string elemNm = xmlRdr.Name;
                // 空要素フラグ
                bool isEmptyElem = xmlRdr.IsEmptyElement;
                // 属性存在フラグ
                bool hasAttr = xmlRdr.HasAttributes;

                // 合計行数インクリメント
                ds.TotalRowNum++;

                // 要素解析メソッド使用
                bRet = AnlXmlElem(ds, depNum, elemNm);
                if (!bRet)
                {
                  return bRet;
                }

                // 要素情報解析メソッド使用
                bRet = AnlXmlElemInfo(ds, isEmptyElem, depNum, elemNm);
                if (!bRet)
                {
                  return bRet;
                }

                // 現在階層数を前回階層変数に引継ぎ
                ds.PreDepthNum = depNum;

                /* 属性系 */
                // 属性がない場合
                if (!hasAttr)
                {
                  break;
                }

                // 属性解析メソッド使用
                bRet = AnlXmlAttr(ds, xmlRdr);
                if (!bRet)
                {
                  return bRet;
                }
                break;

              case XmlNodeType.Text: // 値
                // 値カラムディクショナリ追加
                ds.ValColDic.Add(ds.TotalRowNum, string.Format("\"{0}\"", xmlRdr.Value));
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
        bRet = AddConvdCsvList(ds);
        if (!bRet)
        {
          return bRet;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        bRet = false;
      }

      return bRet;
    }
    #endregion

    #region 要素解析メソッド
    /// <summary>
    /// 要素解析メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="depNum">現在階層数</param>
    /// <param name="elemNm">要素名称</param>
    /// <returns>成否</returns>
    private bool AnlXmlElem(DataStore ds, int depNum, string elemNm)
    {
      bool bRet = true;

      try
      {
        #region 階層数処理

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

        #endregion

        #region パス系

        // 累計パスリストに追加
        ds.CmlPathList.Add(elemNm);

        // 累計パスリストを「/」で結合
        string fullPathStr = string.Join("/", ds.CmlPathList);
        // フルパスカラムディクショナリ追加
        ds.FullPathColDic.Add(ds.TotalRowNum, string.Format("\"{0}\"", fullPathStr));

        // 要素階層数カラムディクショナリ追加
        ds.ElemDepthColDic.Add(ds.TotalRowNum, depNum.ToString());

        // 要素名称カラムディクショナリ追加
        ds.ElemNmColDic.Add(ds.TotalRowNum, elemNm);

        #endregion
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        bRet = false;
      }

      return bRet;
    }
    #endregion

    #region 要素情報解析メソッド
    /// <summary>
    /// 要素情報解析メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="IsEmptyElem">対象要素が空要素かどうか</param>
    /// <param name="elemNm">要素名称</param>
    /// <param name="depNum">現在階層数</param>
    /// <returns>成否</returns>
    private bool AnlXmlElemInfo(DataStore ds, bool isEmptyElem, int depNum, string elemNm)
    {
      bool bRet = true;

      try
      {
        // 最大要素階層数を更新
        if (ds.ElemMaxDepthNum < depNum)
        {
          ds.ElemMaxDepthNum = depNum;
        }

        // 要素の階層数分カンマをつけて空白パディング
        string depElemColStr = string.Format("{0}{1}", new string(',', depNum), elemNm);

        // 階層順要素情報階層カラムディクショナリ追加
        ds.DpElemInfoElemColDic.Add(ds.TotalRowNum, depElemColStr);

        // 空要素の場合
        string isEmptyStr = string.Empty;
        if (isEmptyElem)
        {
          // 空要素判定設定
          isEmptyStr = "空";
        }

        // 階層順要素情報空要素フラグカラムディクショナリ追加
        ds.DpElemInfoEmptyFlgColDic.Add(ds.TotalRowNum, isEmptyStr);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        bRet = false;
      }

      return bRet;
    }
    #endregion

    #region 属性解析メソッド
    /// <summary>
    /// 属性解析メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <param name="xmlRdr">リーダ</param>
    /// <returns>成否</returns>
    private bool AnlXmlAttr(DataStore ds, XmlReader xmlRdr)
    {
      bool bRet = true;

      try
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
        ds.AttrColDic.Add(ds.TotalRowNum, attrStr);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        bRet = false;
      }

      return bRet;
    }
    #endregion


    #region CSV変換後リスト追加メソッド
    /// <summary>
    /// CSV変換後リスト追加メソッド
    /// </summary>
    /// <param name="ds">データストア</param>
    /// <returns>成否</returns>
    private bool AddConvdCsvList(DataStore ds)
    {
      bool bRet = true;

      try
      {
        #region CSV変換後リスト

        // ヘッダ初期値
        string xmlHdrStr = "No,フルパス,階層数,空要素,要素名称,値";
        // 属性ヘッダ作成
        for (int i = 1; i <= ds.AttrMaxDepthNum; i++)
        {
          // 名称+二桁階層数
          xmlHdrStr += string.Format(",属性名{0},属性値{0}", i.ToString());
        }
        // CSV変換後リストにヘッダ追加
        ds.Xml2CsvList.Add(xmlHdrStr);

        // タグ行数ループ
        for (int i = 1; i <= ds.TotalRowNum; i++)
        {
          // ディクショナリに該当キーが存在するか
          bool isExistVal = ds.ValColDic.ContainsKey(i);
          bool isExistAttr = ds.AttrColDic.ContainsKey(i);
          bool isExistDpElemInfo = ds.DpElemInfoEmptyFlgColDic.ContainsKey(i);

          // 該当キー設定
          string valStr = string.Empty;
          string emptyFlgStr = string.Empty;
          if (isExistVal)
          {
            // 値を設定
            valStr = ds.ValColDic[i];
            // 空要素フラグ設定
            emptyFlgStr = "値あり";
          }
          else if (isExistDpElemInfo)
          {
            emptyFlgStr = ds.DpElemInfoEmptyFlgColDic[i];
          }
          string attrStr = string.Empty;
          if (isExistAttr)
          {
            attrStr = ds.AttrColDic[i];
          }

          // フルパス、階層数、要素名称取得
          string fullPathStr = ds.FullPathColDic[i];
          string elemDepthStr = ds.ElemDepthColDic[i];
          string elemNmStr = ds.ElemNmColDic[i];

          // 出力行内容作成
          string outRow = string.Format("{0},{1},{2},{3},{4},{5},{6}"
            , i.ToString()
            , fullPathStr
            , elemDepthStr
            , emptyFlgStr
            , elemNmStr
            , valStr
            , attrStr);

          // CSV変換後リスト追加
          ds.Xml2CsvList.Add(outRow);
        }

        #endregion

        #region 階層順要素情報リスト

        // ヘッダ初期値
        string elemInfoHdrStr = string.Empty;
        // 要素ヘッダ作成
        for (int i = 0; i <= ds.ElemMaxDepthNum; i++)
        {
          // 階層数0パディング
          string iStr = (i + 1).ToString();
          string hierarchyStr = iStr.PadLeft(ds.ElemMaxDepthNum.ToString().Length);

          // 階層数
          elemInfoHdrStr += string.Format("階層{0},", hierarchyStr, '0');
        }

        // 階層順要素情報リストにヘッダ追加
        ds.ElemInfo2CsvList.Add(elemInfoHdrStr);

        // タグ行数ループ
        for (int i = 1; i <= ds.TotalRowNum; i++)
        {
          // CSV変換後リスト追加
          ds.ElemInfo2CsvList.Add(ds.DpElemInfoElemColDic[i]);
        }

        #endregion
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        bRet = false;
      }

      return bRet;
    }
    #endregion


    #region CSV読み込みメソッド
    /// <summary>
    /// CSV読み込みメソッド
    /// </summary>
    /// <param name="file"></param>
    /// <returns>CSV内容二次元配列</returns>
    private List<List<string>> DumpCsv(string file)
    {
      // 戻り値リスト
      List<List<string>> retList = new List<List<string>>();

      using (TextFieldParser csvRdr = new TextFieldParser(file))
      {
        // コメント判断文字
        csvRdr.CommentTokens = new string[] { "#" };
        // 区切り文字
        csvRdr.SetDelimiters(new string[] { "," });
        // クォーテーション有無
        csvRdr.HasFieldsEnclosedInQuotes = true;

        // 行ループ
        while (!csvRdr.EndOfData)
        {
          // 行読み込み
          List<string> row = new List<string>(csvRdr.ReadFields());

          // 戻り値リスト追加
          retList.Add(row);
        }
      }

      return retList;
    }
    #endregion


    #region XML復元メソッド
    /// <summary>
    /// XML復元メソッド
    /// </summary>
    /// <param name="csvContents">CSV内容二次元配列</param>
    /// <param name="savePath">保存パス</param>
    private void RestoreXml(List<List<string>> csvContents, string savePath)
    {
      // XMLドキュメント
      XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));

      // 内容ループ
      int cntr = 0;
      foreach (List<string> tgtRow in csvContents)
      {
        cntr++;

        // フルパス
        string fullPath = tgtRow[1];

        // 行データXML要素変換
        XElement elem = CngRowToXmlElem(tgtRow);

        // 初回ループの場合
        if (cntr == 1)
        {
          // ルート要素として設定
          doc.Add(elem);
          continue;
        }

        // 親パス作成
        List<string> parentPathList = new List<string>(fullPath.Split('/'));
        parentPathList.RemoveAt(parentPathList.Count - 1);
        string parentPath = "/" + string.Join("/", parentPathList);

        // 親要素取得
        IEnumerable<XElement> parents = doc.XPathSelectElements(parentPath);
        List<XElement> elemList = new List<XElement>(parents);

        // 最終要素取得
        XElement parentElem = elemList[elemList.Count - 1];

        // 親要素に追加
        parentElem.Add(elem);
      }

      // XMLの保存
      doc.Save(savePath);
    }
    #endregion

    #region 行データXML要素変換メソッド
    /// <summary>
    /// 行データXML要素変換メソッド
    /// </summary>
    /// <param name="tgtRow">CSV行</param>
    /// <returns>復元XML要素</returns>
    private XElement CngRowToXmlElem(List<string> tgtRow)
    {
      #region 各値取得

      // 要素名
      string elemNm = tgtRow[4];
      // 値
      string val = tgtRow[5];
      // 属性
      List<string> attrNmList = new List<string>();
      List<string> attrValList = new List<string>();
      for (int i = 6; i < tgtRow.Count; i++)
      {
        // 属性名取得
        string attrNmOrVal = tgtRow[i];

        // 偶数(属性名)の場合
        if (i % 2 == 0)
        {
          // 値が空の場合
          if (string.IsNullOrEmpty(attrNmOrVal))
          {
            break;
          }

          // 属性名追加
          attrNmList.Add(attrNmOrVal);
          continue;
        }

        // 属性値追加
        attrValList.Add(attrNmOrVal);
      }

      #endregion

      // 返却用要素作成
      XElement elem = new XElement(elemNm);

      // 値設定
      elem.SetValue(val);

      // 属性付加
      for (int i = 0; i <= attrNmList.Count - 1; i++)
      {
        string attrNm = attrNmList[i];
        string attrVal = attrValList[i];
        XNamespace ns = XNamespace.None;

        // 属性名に「:」が存在する場合
        if (attrNm.Contains(':'))
        {
          // 「:」で分割
          string[] attrNmDivColon = attrNm.Split(':');
          attrNm = attrNmDivColon[1];

          // XML名前空間の場合
          if (attrNmDivColon[0] == "xmlns")
          {
            // XML名前空間文字列設定
            ns = XNamespace.Xmlns;
          }
        }

        // 名前空間属性設定
        elem.SetAttributeValue(ns + attrNm, attrVal);
      }

      return elem;
    }
    #endregion
  }
}
