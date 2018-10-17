#define para_04
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
      string targetPath = tbTargetPath.Text;

      // ねずみ返し
      if (targetPath == "")
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // ファイルかフォルダか
      if (File.Exists(targetPath))
      {

      }
      else if (Directory.Exists(targetPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(targetPath, "*.xml", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {

        }
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void btCreate_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region XML作成メソッド
    public void CreateXML()
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
      xmlDocument.Save("test.xml");
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
