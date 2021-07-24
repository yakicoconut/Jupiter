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

#region ヘッド
/*
 * イベント
 *   概要
 *     ・デリゲートを使用してハンドラと呼ばれるメソッドを
 *       複数格納したメソッドをイベントという
 *     ・イベントは宣言したクラスでのみ実行可能で
 *       それ以外のクラスからはハンドラの追加、削除しか行えない
 *   サイト
 *     [C#]イベントハンドラとはなんぞや – gomokulog
 *     	http://gomocool.net/gomokulog/?p=255
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


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // イベントクラスインスタンス生成
      EventClass targetClass = new EventClass();

      // イベント発火メソッド使用
      targetClass.ExecEvent();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion
  }


  #region イベントクラス
  /// <summary>
  /// イベントクラス
  /// </summary>
  class EventClass
  {
    #region 宣言

    // サンプルイベントデリゲート宣言
    public delegate void SampleEventHandler(object sender, EventArgs e);

    // サンプルイベント定義
    public event SampleEventHandler sampleEvent;

    // インクリメント用変数
    int incI = 0;

    #endregion


    #region ハンドラ「い」メソッド
    private void HandlerI(object o, EventArgs e)
    {
      // インクリメント
      incI += 1;
    }
    #endregion

    #region ハンドラ「ろ」メソッド
    private void HandlerRO(object o, EventArgs e)
    {
      // インクリメント
      incI += 1;
    }
    #endregion

    #region ハンドラ「は」メソッド
    private void HandlerHA(object o, EventArgs e)
    {
      // 表示
      MessageBox.Show(incI.ToString());
    }
    #endregion


    #region イベント発火メソッド
    public void ExecEvent()
    {
      // 本クラスインスタンス生成
      EventClass eventClass = new EventClass();

      // イベント追加
      eventClass.sampleEvent += new SampleEventHandler(eventClass.HandlerI);
      eventClass.sampleEvent += new SampleEventHandler(eventClass.HandlerRO);
      eventClass.sampleEvent += new SampleEventHandler(eventClass.HandlerHA);

      // イベント発火
      eventClass.sampleEvent(eventClass, EventArgs.Empty);
    }
    #endregion
  }
  #endregion
}
