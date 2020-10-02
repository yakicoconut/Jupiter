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

      // 主スレッド処理クラスインスタンス
      fm2 = new Form2(this);
      //fm2.Show();
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

    // 主スレッド処理クラス変数
    Form2 fm2;
    // スレッド生成
    Thread threadA;

    #endregion

    #region プロパティ

    // 
    public string str { get; set; }

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // スレッドインスタンス生成
      threadA = new Thread(new ParameterizedThreadStart(PrimeThread));
      // スレッドスタート
      threadA.Start();
      fm2.ShowDialog(this);
      threadA.Join();
      label1.Text = str;
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      threadA.Join();
    }
    #endregion

    #region 主要スレッド処理メソッド
    /// <summary>
    /// 主要スレッドメソッド
    /// </summary>
    /// <param name="obj"></param>
    public void PrimeThread(Object obj)
    {
      // 処理サンプル
      for (int i = 0; i <= 5; i++)
      {
        // ラベル更新操作メソッド使用
        fm2.UpdLabelOprt(i.ToString());

        // 待機
        Thread.Sleep(1000);
      }

      //MessageBox.Show("完了");
    }
    #endregion



    #region 雛形メソッド
    private void template()
    {

    }
    #endregion
  }
}
