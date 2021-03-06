﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Xml;
using System.Collections;
using System.Configuration;

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
      // 区切り文字
      delimiter = _comLogic.GetConfigValue("Delimiter", "; ");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // XML探索デリゲート宣言
    delegate string DlgtDigXml(string targetStr, XmlReaderSettings setting, string targetKey);

    // 区切り文字
    string delimiter;

    // ファイル名出力カウンタ(「1」の場合、出力)
    int i = 1;

    #endregion


    #region メインフォーム初期設定メソッド
    private void MainFormInitSeting()
    {
      // 変更後拡張子コンボボックス設定
      cbDigMode.DataSource = new string[] { "Raw", "Key" };
      // 変更後拡張子コンボボックス選択
      cbDigMode.SelectedItem = 0;
      // 区切り文字を表示
      cbIsDelimiterMode.Text = string.Format(cbIsDelimiterMode.Text, delimiter);
    }
    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // メインフォーム初期設定メソッド使用
      MainFormInitSeting();
    }
    #endregion


    #region 内容表示テキストボックスキーダウンイベント
    private void tbTabDisplay_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.KeyCode == Keys.A)
        tbTabDisplay.SelectAll();
    }
    #endregion

    #region 結果表示テキストボックスキーダウンイベント
    private void tbResultDisplay_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control && e.KeyCode == Keys.A)
        tbResultDisplay.SelectAll();
    }
    #endregion


    #region ボタン1押下イベント
    private void btDig_Click(object sender, EventArgs e)
    {
      // 対象パス取得
      string targetPath = tbTargetPath.Text;

      // 検索対象キーを配列として取得
      string[] targetKey = { tbTargetKey.Text };
      // 区切り文字チェックがされている場合
      if (cbIsDelimiterMode.Checked)
      {
        // 区切り文字配列変換
        string[] del = { delimiter };
        // 区切り文字で検索対象キーを分割
        targetKey = targetKey[0].Split(del, StringSplitOptions.None);
      }

      // ねずみ返し
      if (targetPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // XML探索デリゲート切り替えメソッド使用
      DlgtDigXml dlgtDigXml = GetDlgtDigXml();

      /* StringReader設定 */
      XmlReaderSettings setting = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreProcessingInstructions = false;
      // 意味のない空白を無視するかどうか
      setting.IgnoreWhitespace = true;

      // 表示用変数
      string tabDisplayStr = string.Empty;
      string resultDisplayStr = string.Empty;

      // ファイルかフォルダか
      if (File.Exists(targetPath))
      {
        // 山括弧抜き検索メソッド使用
        tabDisplayStr = DigWithoutThanSign(targetPath, setting);

        // 検索対象キーをループ
        foreach (string x in targetKey)
        {
          // XML探索デリゲート使用
          resultDisplayStr += dlgtDigXml(targetPath, setting, x);
        }
      }
      else if (Directory.Exists(targetPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(targetPath, "*.xml", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // 山括弧抜き検索メソッド使用
          tabDisplayStr += DigWithoutThanSign(x, setting);
          // 検索対象キーをループ
          foreach (string y in targetKey)
          {
            // XML探索デリゲート使用
            resultDisplayStr += dlgtDigXml(x, setting, y);

            // ファイル名出力カウンタ更新
            ++i;
          }

          // ファイル名出力カウンタ初期化
          i = 1;
        }
      }

      // 結果表示
      tbTabDisplay.Text = tabDisplayStr;
      tbResultDisplay.Text = resultDisplayStr;

      // 結果がない場合
      if (resultDisplayStr == string.Empty)
      {
        tbResultDisplay.Text = "結果なし";
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void btCreate_Click(object sender, EventArgs e)
    {
      string targetPath = tbTargetPath.Text;

      // ねずみ返し
      if (targetPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // XML作成メソッド使用
      CreateXml(targetPath);
    }
    #endregion


    #region XML作成メソッド
    public void CreateXml(string savePath)
    {
      //XML型のインスタンス生成
      XmlDocument xmlDocument = new XmlDocument();
      //要素変数
      XmlElement nestElem;

      //XML宣言
      XmlDeclaration xmlDecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
      //追加
      xmlDocument.AppendChild(xmlDecl);

      //基底タグの作成
      XmlElement baseElem = xmlDocument.CreateElement("catalog");
      //追加
      xmlDocument.AppendChild(baseElem);

      //1階層目の作成
      XmlElement nestElem1_1 = xmlDocument.CreateElement("book");
      //属性の付加
      nestElem1_1.SetAttribute("id", "bk101");
      //追加
      baseElem.AppendChild(nestElem1_1);
      //2階層目の作成
      //タグの追加
      nestElem = xmlDocument.CreateElement("author");
      nestElem.InnerText = "Gambardella, Matthew";
      nestElem1_1.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("title");
      nestElem.InnerText = "XML Developer's Guide";
      nestElem1_1.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("genre");
      nestElem.InnerText = "Computer";
      nestElem1_1.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("price");
      nestElem.InnerText = "44.95";
      nestElem1_1.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("publish_date");
      nestElem.InnerText = "2000-10-01";
      nestElem1_1.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("description");
      nestElem.InnerText = "test description bk101";
      nestElem1_1.AppendChild(nestElem);

      //1階層目の作成
      XmlElement nestElem1_2 = xmlDocument.CreateElement("book");
      //属性の付加
      nestElem1_2.SetAttribute("id", "bk102");
      //追加
      baseElem.AppendChild(nestElem1_2);
      //2階層目の作成
      //タグの追加
      nestElem = xmlDocument.CreateElement("author");
      nestElem.InnerText = "Ralls, Kim";
      nestElem1_2.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("title");
      nestElem.InnerText = "Midnight Rain";
      nestElem1_2.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("genre");
      nestElem.InnerText = "Fantasy";
      nestElem1_2.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("price");
      nestElem.InnerText = "5.95";
      nestElem1_2.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("publish_date");
      nestElem.InnerText = "2000-12-16";
      nestElem1_2.AppendChild(nestElem);
      //タグの追加
      nestElem = xmlDocument.CreateElement("description");
      nestElem.InnerText = "test description bk102";
      nestElem1_2.AppendChild(nestElem);

      //XMLの保存
      xmlDocument.Save(savePath);
    }
    #endregion


    #region XML探索デリゲート切り替えメソッド
    private DlgtDigXml GetDlgtDigXml()
    {
      // コンボボックスの値からスイッチ
      DlgtDigXml dlgtDigXml = null;
      switch (cbDigMode.Text)
      {
        case "Raw":
          dlgtDigXml = GetRawXml;
          break;

        case "Key":
          dlgtDigXml = DigKey;
          break;
      }
      return dlgtDigXml;
    }
    #endregion


    #region 山括弧抜き検索メソッド
    private string DigWithoutThanSign(string targetPath, XmlReaderSettings setting)
    {
      // 返り値変数
      string returnStr = string.Empty;

      // ファイル名
      returnStr += Path.GetFileName(targetPath) + "\r\n";

      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader streamReader = new StreamReader(targetPath))
      using (XmlReader xmlStreamReader = XmlReader.Create(streamReader, setting))
      using (XmlReader xmlReader = xmlStreamReader)
      {
        // XmlReader.Readメソッド使用パターン
        while (xmlReader.Read())
        {
          // 階層の深さ基底より下の場合
          string depth = "";
          if (xmlReader.Depth >= 1)
          {
            // インデントを作成
            depth = " ".PadRight(xmlReader.Depth * 2);
          }

          // ノードタイプで分岐
          switch (xmlReader.NodeType)
          {
            case XmlNodeType.Attribute:
              break;
            case XmlNodeType.XmlDeclaration: // XML宣言
              returnStr += "?" + xmlReader.Name;
              returnStr += " " + xmlReader.Value + "?";
              returnStr += "\r\n";
              break;
            case XmlNodeType.Element: // 開始タグ
              returnStr += depth + xmlReader.Name;

              // 属性がある場合
              for (int i = 0; i < xmlReader.AttributeCount; i++)
              {
                // 属性へリーダを移動
                xmlReader.MoveToAttribute(i);
                returnStr += " " + xmlReader.Name;
                returnStr += @"=""" + xmlReader.Value + @"""";
              }
              returnStr += "\r\n";
              break;
            case XmlNodeType.Text: // 値
              returnStr += depth + xmlReader.Value + "\r\n";
              break;
            case XmlNodeType.EndElement: // 終了タグ
              returnStr += depth + "/" + xmlReader.Name + "\r\n";
              break;
            case XmlNodeType.Comment: // コメントタグ
              returnStr += depth + "!--" + xmlReader.Value + "--" + "\r\n";
              break;
            case XmlNodeType.None:
              break;
            default:
              break;
          }
        }
      }

      // 改行
      returnStr += "\r\n";

      return returnStr;
    }
    #endregion

    #region 生Xml取得メソッド
    public string GetRawXml(string targetPath, XmlReaderSettings setting, string targetKey)
    {
      // 返り値変数
      string returnStr = string.Empty;

      // ファイルからXmlReaderでXMLを取得
      using (StreamReader reader = new StreamReader(targetPath))
      {
        returnStr += reader.ReadToEnd();
      }

      // 改行
      returnStr += "\r\n";

      return returnStr;
    }
    #endregion


    #region キー検索メソッド
    private string DigKey(string targetPath, XmlReaderSettings setting, string targetKey)
    {
      // 返り値変数
      string returnStr = string.Empty;
      // 対象ファイル名
      string fileName = Path.GetFileName(targetPath);

      // ファイル名出力チェックボックスかつファイル名出力カウンタが「1」の場合
      if (cbOutFileName.Checked && i == 1)
      {
        // ファイル名出力
        returnStr += fileName + "\r\n";
      }

      // ファイルからXMLを取得
      // インスタンスを生成する全てのクラスをusing化(しないとファイルが開放されない)
      using (StreamReader streamReader = new StreamReader(targetPath))
      using (XmlReader xmlStreamReader = XmlReader.Create(streamReader, setting))
      using (XmlReader xmlReader = xmlStreamReader)
      {
        // 要素ループ
        while (xmlReader.ReadToFollowing(targetKey))
        {
          // 属性チェックボックス
          if (cbOutAttr.Checked)
          {
            // 属性取得メソッド使用
            returnStr += GetAttr(xmlReader);
          }
          // 値出力チェックボックス
          if (cbOutValue.Checked)
          {
            // 返り値フォーマット
            string RETURN_FORMAT = "{0}\r\n";
            // キー名称チェックボックス
            if (cbOutKeyName.Checked)
            {
              RETURN_FORMAT = targetKey + "\t:" + RETURN_FORMAT;
            }
            // タブチェックボックス
            if (cbTab.Checked)
            {
              RETURN_FORMAT = "\t" + RETURN_FORMAT;
            }

            // 値追加
            string value = xmlReader.ReadString();
            returnStr += string.Format(RETURN_FORMAT, value);
          }
        }
      }

      // 検索対象なし出力チェックボックス
      if (cbNoting.Checked)
      {
        // 検索結果が存在しない場合
        if (returnStr == fileName + "\r\n" || returnStr == string.Empty)
        {
          // 返り値フォーマット
          string RETURN_FORMAT = "検索対象なし\r\n";
          // キー名称チェックボックス
          if (cbOutKeyName.Checked)
          {
            RETURN_FORMAT = targetKey + "\t:" + RETURN_FORMAT;
          }
          // タブチェックボックス
          if (cbTab.Checked)
          {
            RETURN_FORMAT = "\t" + RETURN_FORMAT;
          }

          returnStr += RETURN_FORMAT;
        }
      }

      return returnStr;
    }
    #endregion


    #region 属性取得メソッド
    private string GetAttr(XmlReader xmlReader)
    {
      string preReturnStr = string.Empty;
      string returnStr = string.Empty;
      string outHead = string.Empty;
      string HEAD_FORMAT = "値{0}\r\n";
      // キー名称チェックボックス
      if (cbOutKeyName.Checked)
      {
        HEAD_FORMAT = "キー名称\t:" + HEAD_FORMAT;
      }
      // タブチェックボックス
      if (cbTab.Checked)
      {
        HEAD_FORMAT = "\t" + HEAD_FORMAT;
      }

      // 属性ループ
      int ii = 0;
      while (xmlReader.MoveToNextAttribute())
      {
        // 返り値フォーマット
        string RETURN_FORMAT = "{0}\r\n";
        // 属性名取得
        string AttrName = xmlReader.Name;
        // 属性取得
        string Attr = xmlReader.GetAttribute(ii);

        // タブチェック
        if (cbTab.Checked)
        {
          // 属性が一つしかない
          if (xmlReader.AttributeCount == 1)
          {
            // タブ、改行複合
            RETURN_FORMAT = "\t\t{0}\r\n";
          }
          else if (ii == 0) // 最初の属性
          {
            // タブ二個追加
            RETURN_FORMAT = "\t\t{0}";
          }
          else if (ii == xmlReader.AttributeCount - 1) // 最後の属性
          {
            // 更に改行追加
            RETURN_FORMAT = "\t{0}\r\n";
          }
        }

        // 属性名追加
        outHead += "\t" + AttrName;
        // 属性追加
        preReturnStr += string.Format(RETURN_FORMAT, Attr);

        ++ii;
      }

      // タブチェックかつヘッダー出力かつファイル名出力カウンタ「1」の場合
      if (cbTab.Checked && cbHeader.Checked && i == 1)
      {
        returnStr += string.Format(HEAD_FORMAT, outHead);
      }
      returnStr += preReturnStr;

      return returnStr;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
