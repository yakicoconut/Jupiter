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
      ////XML作成メソッド使用
      //CreateXML();

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
        // XmlReader調査メソッド使用
        XmlReader_ReadMeth_(targetPath);
      }
      else if (Directory.Exists(targetPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(targetPath, "*.xml", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // XmlReader調査メソッド使用
          XmlReader_ReadMeth_(x);
        }
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void btCreate_Click(object sender, EventArgs e)
    {
      string targetStr = null;

      #region #if_パラメータ

#if para_01
      targetStr =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
  <catalog>
    <!-- テストコメント01 -->
    <book id=""bk101"">
      <abc def=""001"" ghi=""002"" zyx=""003"">jkl</abc>
      <author>Gambardella, Matthew</author>
      <title>XML Developer's Guide</title>
      <genre>Computer</genre>
      <price>44.95</price>
      <!-- テストコメント02 -->
      <publish_date>2000-10-01</publish_date>
      <description>test description bk101</description>
    </book>
    <book id=""bk102"">
      <author>Ralls, Kim</author>
      <title>Midnight Rain</title>
      <genre>Fantasy</genre>
      <price>5.95</price>
      <publish_date>2000-12-16</publish_date>
      <description>test description bk102</description>
    </book>
  </catalog>
";
#endif

#if para_02
      targetStr =
@"<?xml version=""1.0"" encoding=""utf-8"" ?>
  <Books>
    <Book>
      <Title>A Brief History of Time</Title>
    </Book>
    <Book>
      <Title>Principle Of Relativity</Title>
    </Book>
    <Book>
      <Title>Victory of Reason</Title>
    </Book>
    <Book>
      <Title>The Unicorn that did not Fail</Title>
    </Book>
    <Book>
      <Title>Rational Ontology</Title>
    </Book>
    <Book>
      <Title>The Meaning of Pizza</Title>
    </Book>
  </Books>
";
#endif

#if para_03
      targetStr =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
  <root>
    <A />
    <B い=""ろ"" は=""に"" />
    <C>ほ</C>
    <D へ=""と"">ち<E り=""ぬ"">る</E><F /></D>
    <G>を<わ xmlns=""か"">よ</わ></G>
  </root>
";
#endif

#if para_04
      targetStr =
@"<?xml version=""1.0"" encoding=""UTF-8""?>
  <TestRun id=""b5b6c1a9-aeff-4e38-bfe3-55a65bc8dcee"" name=""p00486@PPC4861 2017-10-10 17:28:17"" runUser=""PNET\p00486"" xmlns=""http://microsoft.com/schemas/VisualStudio/TeamTest/2010"">
    <TestSettings name=""ローカル"" id=""651f2b6d-8de9-484b-b1c9-28766cfd250e"">
      <Description>これらはローカル テスト実行用の既定のテスト設定です。</Description>
      <Deployment enabled=""false"" runDeploymentRoot=""p00486_PPC4861 2017-10-10 17_28_17"">
        <DeploymentItem filename=""\CSVR連携\YamauchiWcfTestService\YamauchiWcfTestService\bin\Debug\POS4U.Framework.Utility.dll"" />
        <DeploymentItem filename=""\CSVR連携\YamauchiWcfTestService\YamauchiWcfTestService\bin\Debug\YamauchiWcfTestService.exe"" />
      </Deployment>
      <Execution>
        <!-- テストコメント01 -->
        <TestTypeSpecific />
        <AgentRule name=""Execution Agents"">
        </AgentRule>
      </Execution>
    </TestSettings>
    <Times creation=""2017-10-10T17:28:17.7738669+09:00"" queuing=""2017-10-10T17:28:18.9838669+09:00"" start=""2017-10-10T17:28:19.0138669+09:00"" finish=""2017-10-10T17:28:19.3638669+09:00"" />
    <ResultSummary outcome=""Completed"">
      <Counters total=""1"" executed=""1"" passed=""1"" error=""0"" failed=""0"" timeout=""0"" aborted=""0"" inconclusive=""0"" passedButRunAborted=""0"" notRunnable=""0"" notExecuted=""0"" disconnected=""0"" warning=""0"" completed=""0"" inProgress=""0"" pending=""0"" />
    </ResultSummary>
    <TestDefinitions>
      <UnitTest name=""RetrunXmlToRPointInfo_XmlReader_AnalysisTest"" storage=""\csvr連携\yamauchiwcftestservice\testproject1\bin\debug\testproject1.dll"" id=""b58d4be9-69a9-2c46-3156-48d303e9eb01"">
        <Execution id=""5458a91f-b87e-4451-8345-f70a449566a9"" />
        <TestMethod codeBase=""/CSVR連携/YamauchiWcfTestService/TestProject1/bin/Debug/TestProject1.DLL"" adapterTypeName=""Microsoft.VisualStudio.TestTools.TestTypes.Unit.UnitTestAdapter, Microsoft.VisualStudio.QualityTools.Tips.UnitTest.Adapter, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" className=""TestProject1.WcfTestServiceTest, TestProject1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" name=""RetrunXmlToRPointInfo_XmlReader_AnalysisTest"" />
      </UnitTest>
    </TestDefinitions>
    <TestLists>
      <TestList name=""一覧に存在しない結果"" id=""8c84fa94-04c1-424b-9868-57a2d4851a1d"" />
      <TestList name=""読み込まれたすべての結果"" id=""19431567-8539-422a-85d7-44ee4e166bda"" />
    </TestLists>
    <TestEntries>
      <TestEntry testId=""b58d4be9-69a9-2c46-3156-48d303e9eb01"" executionId=""5458a91f-b87e-4451-8345-f70a449566a9"" testListId=""8c84fa94-04c1-424b-9868-57a2d4851a1d"" />
    </TestEntries>
    <Results>
      <UnitTestResult executionId=""5458a91f-b87e-4451-8345-f70a449566a9"" testId=""b58d4be9-69a9-2c46-3156-48d303e9eb01"" testName=""RetrunXmlToRPointInfo_XmlReader_AnalysisTest"" computerName=""PPC4861"" duration=""00:00:00.0306222"" startTime=""2017-10-10T17:28:19.0538669+09:00"" endTime=""2017-10-10T17:28:19.3338669+09:00"" testType=""13cdc9d9-ddb5-4fa4-a97d-d965ccfc6d4b"" outcome=""Passed"" testListId=""8c84fa94-04c1-424b-9868-57a2d4851a1d"" relativeResultsDirectory=""5458a91f-b87e-4451-8345-f70a449566a9"">
      </UnitTestResult>
    </Results>
  </TestRun>
";
#endif

      #endregion

      // XmlReader調査メソッド使用
      XmlReader_ReadMeth(targetStr);

      //// XmlReader.Read関連・Move関連メソッド調査メソッド使用
      //XmlReader_ReadMoveMeth(targetStr);
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


    #region 今回用メソッド
    /// <summary>
    /// XmlReader.Read調査メソッド
    /// </summary>
    public void XmlReader_ReadMeth_(string targetStr)
    {
      /*
       * StringReaderを使用して文字列からXmlReaderを作成する
       */

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

      textBox1.AppendText("----Read----");
      textBox1.AppendText("\r\n");

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StreamReader(targetStr), setting))
      {
        // 「<>」抜き表示
        #region Readメソッド

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
              textBox1.AppendText("?" + xmlReader.Name);
              textBox1.AppendText(" " + xmlReader.Value + "?");
              textBox1.AppendText("\r\n");
              break;
            case XmlNodeType.Element: // 開始タグ
              textBox1.AppendText(depth + xmlReader.Name);

              // 属性がある場合
              for (int i = 0; i < xmlReader.AttributeCount; i++)
              {
                // 属性へリーダを移動
                xmlReader.MoveToAttribute(i);
                textBox1.AppendText(" " + xmlReader.Name);
                textBox1.AppendText(@"=""" + xmlReader.Value + @"""");
              }
              textBox1.AppendText("\r\n");
              break;
            case XmlNodeType.Text: // 値
              textBox1.AppendText(depth + xmlReader.Value + "\r\n");
              break;
            case XmlNodeType.EndElement: // 終了タグ
              textBox1.AppendText(depth + "/" + xmlReader.Name + "\r\n");
              break;
            case XmlNodeType.Comment: // コメントタグ
              textBox1.AppendText(depth + "!--" + xmlReader.Value + "--" + "\r\n");
              break;
            case XmlNodeType.None:
              break;
            default:
              break;
          }
        }
        #endregion
      }
    }
    #endregion


    #region XmlReader.Read調査メソッド
    /// <summary>
    /// XmlReader.Read調査メソッド
    /// </summary>
    public void XmlReader_ReadMeth(string targetStr)
    {
      /*
       * StringReaderを使用して文字列からXmlReaderを作成する
       */

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

      textBox1.AppendText("----Read----");
      textBox1.AppendText("\r\n");

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StringReader(targetStr), setting))
      {
        // 「<>」抜き表示
        #region Readメソッド

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
              textBox1.AppendText("?" + xmlReader.Name);
              textBox1.AppendText(" " + xmlReader.Value + "?");
              textBox1.AppendText("\r\n");
              break;
            case XmlNodeType.Element: // 開始タグ
              textBox1.AppendText(depth + xmlReader.Name);

              // 属性がある場合
              for (int i = 0; i < xmlReader.AttributeCount; i++)
              {
                // 属性へリーダを移動
                xmlReader.MoveToAttribute(i);
                textBox1.AppendText(" " + xmlReader.Name);
                textBox1.AppendText(@"=""" + xmlReader.Value + @"""");
              }
              textBox1.AppendText("\r\n");
              break;
            case XmlNodeType.Text: // 値
              textBox1.AppendText(depth + xmlReader.Value + "\r\n");
              break;
            case XmlNodeType.EndElement: // 終了タグ
              textBox1.AppendText(depth + "/" + xmlReader.Name + "\r\n");
              break;
            case XmlNodeType.Comment: // コメントタグ
              textBox1.AppendText(depth + "!--" + xmlReader.Value + "--" + "\r\n");
              break;
            case XmlNodeType.None:
              break;
            default:
              break;
          }
        }
        #endregion
      }
    }
    #endregion

    #region XmlReader.Read関連・Move関連メソッド調査メソッド
    /// <summary>
    /// XmlReader.Read関連・Move関連メソッド調査メソッド
    /// </summary>
    public void XmlReader_ReadMoveMeth(string targetStr)
    {
      /*
       * StringReaderを使用して文字列からXmlReaderを作成する
       */

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

      textBox1.AppendText("----ReadMove----");
      textBox1.AppendText("\r\n");

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StringReader(targetStr), setting))
      {
        // 「<>」抜き表示
        #region ReadStartElementメソッド

        // XML宣言等をスキップ
        xmlReader.MoveToContent();

        // XmlReader.Readメソッド使用パターン
        while (!xmlReader.EOF)
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
              textBox1.AppendText("?" + xmlReader.Name);
              textBox1.AppendText(" " + xmlReader.Value + "?");
              textBox1.AppendText("\r\n");
              break;
            case XmlNodeType.Element: // 開始タグ
              textBox1.AppendText(depth + xmlReader.Name);

              // ねずみ返し_属性が無い場合
              if (!xmlReader.MoveToFirstAttribute())
              {
                textBox1.AppendText("\r\n");
                xmlReader.ReadStartElement();
                continue;
              }

              textBox1.AppendText(" " + xmlReader.Name + @"=""" + xmlReader.Value + @"""");
              // 属性が複数ある場合、全てに移動
              while (xmlReader.MoveToNextAttribute())
              {
                textBox1.AppendText(" " + xmlReader.Name + @"=""" + xmlReader.Value + @"""");
              }


#if 別解_属性取り出しループ
              // 属性がある場合
              for (int i = 0; i < xmlReader.AttributeCount; i++)
              {
                // 属性へリーダを移動
                xmlReader.MoveToAttribute(i);
                textBox1.AppendText(" " + xmlReader.Name + @"=""" + xmlReader.Value + @"""");
              }
#endif
              textBox1.AppendText("\r\n");
              xmlReader.ReadStartElement();
              break;
            case XmlNodeType.Text: // 値
              textBox1.AppendText(depth + xmlReader.Value + "\r\n");
              xmlReader.ReadString();
              break;
            case XmlNodeType.EndElement: // 終了タグ
              textBox1.AppendText(depth + "/" + xmlReader.Name + "\r\n");
              xmlReader.ReadEndElement();
              break;
            case XmlNodeType.Comment: // コメントタグ
              textBox1.AppendText(depth + "!--" + xmlReader.Value + "--" + "\r\n");
              // カレントがコメントでReadStartElementを使用すると二つ進めてしまう?
              //xmlReader.ReadStartElement();
              xmlReader.Read();
              break;
            case XmlNodeType.None:
              break;
            default:
              break;
          }
        }
        #endregion
      }
    }
    #endregion

    #region XmlReader.ReadSubtreeメソッド調査メソッド
    /// <summary>
    /// XmlReader.ReadSubtreeメソッド調査メソッド
    /// </summary>
    /// <param name="targetStr"></param>
    public void XmlReader_ReadSubtreeMeth(string targetStr)
    {
      /*
       * StringReaderを使用して文字列からXmlReaderを作成する
       */

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

      textBox1.AppendText("----ReadSubtree----");
      textBox1.AppendText("\r\n");

      // ファイルからXmlReaderでXMLを取得
      using (XmlReader xmlReader = XmlReader.Create(new StringReader(targetStr), setting))
      {
        // 指定タグまで移動
        xmlReader.ReadToFollowing("book");

        // 指定タグの内容をXmlReaderに格納
        using (XmlReader inner1 = xmlReader.ReadSubtree())
        {
          // 最初のコンテンツノードまで移動
          // ※移動処理を行わないとXmlReaderはNoneとなる
          inner1.MoveToContent();
        }

        // 元のXmlReaderを操作(非推奨)
        xmlReader.Skip();

        // 指定タグの兄弟タグ読み込み
        using (XmlReader inner2 = xmlReader.ReadSubtree())
        {
          // 最初のコンテンツノードまで移動
          inner2.MoveToContent();
        }
      }
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
