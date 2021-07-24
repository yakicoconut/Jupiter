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
using System.Configuration;
using System.Threading;

#region ヘッダ
/*
 * スレッド003
 *   一時停止
 *     
 *   終了
 * 
 * サイト
 *   スレッドの一時停止・再開について
 *    https://social.msdn.microsoft.com/Forums/ja-JP/ac772cbb-0ed9-40d4-a9d0-a72f305a54ee/12473125241248312489123981996826178205722749012539208773828312?forum=csharpgeneralja
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

    // スレッド
    Thread threadA;

    // 処理終了フラグ
    // true:終了、false:継続
    bool endFlag;
    // 一時停止フラグ
    // true:停止、false:実行
    bool pauseFlag;
    // 一時停止イベント
    AutoResetEvent autoResetEvent;

    // インヴォーク用デリゲート
    delegate void DlgtAppendTxt(string str);

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // フラグ初期化
      endFlag = false;
      pauseFlag = false;
      // 一時停止イベントインスタンス生成
      autoResetEvent = new AutoResetEvent(false);

      // テストメソッドのスレッドスタートデリゲート生成
      ThreadStart dlgtThreadTest = ThreadTest;

      // スレッド作成(スレッドクラスは引数にデリゲートを取る)
      threadA = new Thread(dlgtThreadTest);
      // スレッドスタート
      threadA.Start();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // ねずみ返し_一時停止フラグが実行の場合
      if (pauseFlag == false)
      {
        // フラグを停止にする
        pauseFlag = true;
        return;
      }

      // 対象スレッドがブロック(停止)ステータスの場合
      if (threadA.ThreadState == ThreadState.WaitSleepJoin)
      {
        // フラグを実行にする
        pauseFlag = false;

        // 待機していた別処理スレッドを再開
        autoResetEvent.Set();
      }
    }
    #endregion

    #region ボタン3押下イベント
    private void button3_Click(object sender, EventArgs e)
    {
      // 終了フラグを立てる
      endFlag = true;
    }
    #endregion

    #region ボタン4押下イベント
    private void button4_Click(object sender, EventArgs e)
    {
      textBox1.AppendText("bt4" + Environment.NewLine);
    }
    #endregion


    #region テストメソッド
    public void ThreadTest()
    {
      // テキストボックスアペンデントテキストデリゲート生成
      DlgtAppendTxt dlgtAppendTxt = textBox1.AppendText;

      // 2秒に一回書き込み
      for (int i = 1; i <= 30; i++)
      {
        // フラグが停止の場合
        if (pauseFlag == true)
        {
          // スレッドを無期限で待機
          autoResetEvent.WaitOne();
        }

        // 終了フラグが終了の場合
        // 一時停止後の終了に対応するため一時停止メソッドの後に記述
        if (endFlag == true)
        {
          // 処理終了
          return;
        }

        // テキストボックス操作をインヴォーク
        Invoke(dlgtAppendTxt, "bt1" + Environment.NewLine);
        Thread.Sleep(1000);
      }
    }
    #endregion
  }
}
