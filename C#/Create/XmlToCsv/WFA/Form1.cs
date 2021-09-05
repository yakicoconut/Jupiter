﻿using System;
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

    #region 実行ボタン押下イベント
    private void btExec_Click(object sender, EventArgs e)
    {
      bool bRet = true;
      // 対象パス
      string tgtPath = tbTgtPath.Text;
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
        for (int i = 0; i < ds.TotalRowNum - 1; i++)
        {
          // CSV変換後リスト
          swMain.WriteLine(ds.Xml2CsvList[i]);
          // 階層順要素情報リスト
          swSub.WriteLine(ds.ElemInfo2CsvList[i]);
        }
      }
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
        return false;
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

        // 要素名称カラムディクショナリ追加
        ds.ElemNmColDic.Add(ds.TotalRowNum, elemNm);

        #endregion
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        return false;
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
        return false;
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
        return false;
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
        string xmlHdrStr = "No,フルパス,要素名称,空要素,値";
        // 属性ヘッダ作成
        for (int i = 1; i <= ds.AttrMaxDepthNum; i++)
        {
          // 名称+二桁階層数
          xmlHdrStr += string.Format(",属性名{0,2},属性値{0,2}", i.ToString());
        }
        // CSV変換後リストにヘッダ追加
        ds.Xml2CsvList.Add(xmlHdrStr);

        // タグ行数ループ
        for (int i = 1; i <= ds.TotalRowNum; i++)
        {
          // ディクショナリに該当キーが存在するか
          bool valExistFlg = ds.ValColDic.ContainsKey(i);
          bool attrExistFlg = ds.AttrColDic.ContainsKey(i);
          bool dpElemInfoExistFlg = ds.DpElemInfoEmptyFlgColDic.ContainsKey(i);

          // 該当キー設定
          string valStr = string.Empty;
          string emptyFlgStr = string.Empty;
          if (valExistFlg)
          {
            // 値を設定
            valStr = ds.ValColDic[i];
            // 空要素フラグ設定
            emptyFlgStr = "値あり";
          }
          else if (dpElemInfoExistFlg)
          {
            emptyFlgStr = ds.DpElemInfoEmptyFlgColDic[i];
          }
          string attrStr = string.Empty;
          if (attrExistFlg)
          {
            attrStr = ds.AttrColDic[i];
          }

          // フルパス、要素名称取得
          string fullPathStr = ds.FullPathColDic[i];
          string elemNmStr = ds.ElemNmColDic[i];

          // CSV変換後リスト追加
          ds.Xml2CsvList.Add(string.Format("{0},{1},{2},{3},{4},{5}", i.ToString(), fullPathStr, elemNmStr, emptyFlgStr, valStr, attrStr));
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
        return false;
      }

      return bRet;
    }
    #endregion
  }
}