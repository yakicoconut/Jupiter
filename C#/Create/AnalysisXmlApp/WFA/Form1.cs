using System;
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
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region ボタン1押下イベント
    private void btDig_Click(object sender, EventArgs e)
    {
      // 入力値
      string targetPath = tbTargetPath.Text;
      string targetKey = tbTargetKey.Text;

      // ねずみ返し
      if (targetPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      /* StringReader設定 */
      XmlReaderSettings setting = new XmlReaderSettings();
      // コメントを無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreComments = false;
      // 処理命令(スタイルシートの宣言等)を無視するかどうか
      // ※デフォルトもfalseだがサンプルのため明示的に設定
      setting.IgnoreProcessingInstructions = false;
      //意味のない空白を無視するかどうか
      setting.IgnoreWhitespace = true;

      // 表示用変数
      string displayStr = string.Empty;

      // ファイルかフォルダか
      if (File.Exists(targetPath))
      {
        // キー検索メソッド使用
        displayStr = DigKey(targetPath, setting, targetKey);
      }
      else if (Directory.Exists(targetPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(targetPath, "*.xml", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // キー検索メソッド使用
          displayStr = DigKey(x, setting, targetKey);
        }
      }

      // 結果表示
      tbDisplay.Text = displayStr;

      // 結果がない場合
      if (displayStr == string.Empty)
      {
        tbDisplay.Text = "結果なし";
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


    #region キー検索メソッド
    private string DigKey(string targetPath, XmlReaderSettings setting, string targetKey)
    {
      // 返り値変数
      string returnStr = string.Empty;

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StreamReader(targetPath), setting))
      {
        // 要素ループ
        while (xmlReader.Read())
        {
          // ねずみ返し_対象タグが存在しない場合
          if (!xmlReader.ReadToFollowing(targetKey))
          {
            continue;
          }

          // 属性ループ
          for (int i = 0; i < xmlReader.AttributeCount; i++)
          {
            // 返り値に格納
            returnStr += xmlReader.GetAttribute(i) + Environment.NewLine;
          }
        }
      }

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
