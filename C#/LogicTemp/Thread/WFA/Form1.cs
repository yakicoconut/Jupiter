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
      firstThread = new FirstThread(this);
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
    FirstThread firstThread;
    // スレッド生成
    Thread threadA;

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // スレッドインスタンス生成
      threadA = new Thread(new ParameterizedThreadStart(firstThread.PrimeThread));
      // スレッドスタート
      threadA.Start();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 一時停止メソッド使用
      firstThread.PauseThread(threadA);
    }
    #endregion

    #region ボタン3押下イベント
    private void button3_Click(object sender, EventArgs e)
    {
      // 処理終了フラグを立てる
      firstThread.EndThread(threadA);
    }
    #endregion


    #region ラベル更新メソッド
    public void LabelUpdate(string str)
    {
      // ラベル更新
      label1.Text = str;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
