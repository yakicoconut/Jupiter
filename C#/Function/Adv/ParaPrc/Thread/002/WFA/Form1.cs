#define PATTERN001
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
using System.Threading;

#region ヘッダ
/*
 * スレッド002
 *   ・コントロールの操作は通常、生成されたスレッドからしか行えない
 *     別スレッドからコントロールを操作するにはInvokeメソッドを使用する
 *   ・コントロールのInvokeRequiredプロパティは参照を実行したスレッドが
 *     そのコントロールを生成したかどうかを取得できる
 *     →Invokeメソッドからコントロールの操作を行う必要があるか判断できる
 *   ・Invokeメソッドから実行するメソッドの引数は
 *     Invokeメソッドの第二引数以降に記述する
 *   ・スレッドが完了する前にフォームを終了させると
 *     フォームにアクセスする処理でエラーとなる
 * サイト
 *   Windowsフォームで別スレッドからコントロールを操作するには？：.NET TIPS - ＠IT
 *   	http://www.atmarkit.co.jp/ait/articles/0506/17/news111.html
 */
#endregion
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

    // インヴォーク用デリゲート
    delegate void DlgtAppendTxt(string str);

    string tb1InvokeRequired;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // テストメソッドのスレッドスタートデリゲート生成
      ThreadStart dlgtThreadTest = ThreadTest;

      // スレッド作成(スレッドクラスは引数にデリゲートを取る)
      Thread threadA = new Thread(dlgtThreadTest);
      // スレッドスタート
      threadA.Start();

      // テキストボックス1がインヴォークを必要かラベルに表示
      // ラベル表示をするのにインヴォークが必要なのが面倒なので
      // 変数を使用して値を引き継ぐ
      Thread.Sleep(500);
      label1.Text = tb1InvokeRequired;
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 2秒待ってから書き込み
      textBox1.AppendText("bt2" + Environment.NewLine);

      // テキストボックスを操作するのにインヴォークを使用する必要があるかどうか
      tb1InvokeRequired = textBox1.InvokeRequired.ToString();
    }
    #endregion


    #region テストメソッド
    public void ThreadTest()
    {
      // テキストボックスアペンデントテキストデリゲート生成
      DlgtAppendTxt dlgtAppendTxt = textBox1.AppendText;

      // テキストボックスを操作するのにインヴォークを使用する必要があるかどうか
      tb1InvokeRequired = textBox1.InvokeRequired.ToString();

      // 2秒に一回書き込み
      for (int i = 1; i <= 5; i++)
      {
        #region パターン001_デリゲート変数
#if PATTERN001

        Invoke(dlgtAppendTxt, "bt1" + Environment.NewLine);

#endif
        #endregion

        #region パターン002_ラムダ式
#if PATTERN002

        Invoke((Action)delegate
        {
          textBox1.AppendText("bt1" + Environment.NewLine);
        });

#endif
        #endregion


        Thread.Sleep(1000);
      }
    }
    #endregion
  }
}
