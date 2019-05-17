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
      string hoge01 = _comLogic.GetConfigValue("Key01", "DefaultValue");
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // コマンドライン引数取得
      string[] cmdArgs = Environment.GetCommandLineArgs();

      // ねずみ返し_引数が1以下の場合(一つ目は自身のパス固定)
      if (cmdArgs.Length <= 1)
      {
        return;
      }

      // ループ
      foreach (string x in cmdArgs)
      {
        // テキスト表示
        textBox1.AppendText(x);
        textBox1.AppendText(Environment.NewLine);
      }
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 起動テスト
      Process.Start(Assembly.GetExecutingAssembly().Location, @"ab c ""d e");
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 起動テスト
      string testPath = @"test 01Folder\test02.txt";
      Process.Start(Assembly.GetExecutingAssembly().Location, "\"" + testPath + "\"");
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
