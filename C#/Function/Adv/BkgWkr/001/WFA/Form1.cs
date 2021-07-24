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

#region ヘッダ
/*
 * バックグラウンドワーカー
 * 
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

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      //ProgressDialogオブジェクトを作成する
      using (Form2 pd = new Form2("進行状況ダイアログのテスト", new DoWorkEventHandler(ProgressDialog_DoWork), 100))
      {
        //進行状況ダイアログを表示する
        DialogResult result = pd.ShowDialog(this);
        //結果を取得する
        if (result == DialogResult.Cancel)
        {
          MessageBox.Show("キャンセルされました");
        }
        else if (result == DialogResult.Abort)
        {
          //エラー情報を取得する
          Exception ex = pd.Error;
          MessageBox.Show("エラー: " + ex.Message);
        }
        else if (result == DialogResult.OK)
        {
          //結果を取得する
          int stopTime = (int)pd.Result;
          MessageBox.Show("成功しました: " + stopTime.ToString());
        }
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region DoWorkイベント
    private void ProgressDialog_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bw = (BackgroundWorker)sender;

      //パラメータを取得する
      int stopTime = (int)e.Argument;

      //時間のかかる処理を開始する
      for (int i = 1; i <= 100; i++)
      {
        //キャンセルされたか調べる
        if (bw.CancellationPending)
        {
          //キャンセルされたとき
          e.Cancel = true;
          return;
        }

        //指定された時間待機する
        System.Threading.Thread.Sleep(stopTime);

        //ProgressChangedイベントハンドラを呼び出し、
        //コントロールの表示を変更する
        bw.ReportProgress(i, i.ToString() + "% 終了しました");
      }

      //結果を設定する
      e.Result = stopTime * 100;
    }
    #endregion
  }
}
