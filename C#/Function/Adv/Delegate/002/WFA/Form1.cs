#define PATTERN003
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
 * デリゲート
 *   イベント内でデリゲートに格納したインスタンスによって
 *   どのメソッドを実行するか分岐する
 *   →共通のメソッドに対して渡すデリゲートを変えることによって分岐させる
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

    //　デリゲート宣言
    delegate void Pattern3Delegate(string dtn);

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      #region パターン001_基本処理
#if PATTERN001

      // 基本処理1メソッド使用
      Pattern1_bt1();

#endif
      #endregion

      #region パターン002_共通化
#if PATTERN002

      flg = "1";
      // 共通メソッド使用
      CommonMeth(flg);

#endif
      #endregion

      #region パターン003_デリゲート
#if PATTERN003

      // デリゲートインスタンス作成
      Pattern3Delegate dlgt = new Pattern3Delegate(bt1_ClickMeth);

      // 共通処理メソッドの使用
      CommonDele(dlgt);

#endif
      #endregion
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      #region パターン001_基本処理
#if PATTERN001

      // 基本処理2メソッド使用
      Pattern1_bt2();

#endif
      #endregion

      #region パターン002_共通化
#if PATTERN002

      flg = "2";
      // 共通メソッド使用
      CommonMeth(flg);

#endif
      #endregion

      #region パターン003_デリゲート
#if PATTERN003

      // デリゲートインスタンス作成
      Pattern3Delegate dlgt = new Pattern3Delegate(bt2_ClickMeth);

      // 共通処理メソッドの使用
      CommonDele(dlgt);

#endif
      #endregion
    }
    #endregion


    #region 基本処理

    // 基本処理1メソッド
    private void Pattern1_bt1()
    {
      // 共通処理
      string dtn = DateTime.Now.ToString("yyyyMMddHHmmssfff");

      // 個別処理
      textBox1.Text = "p1button1:" + dtn;
    }

    // 基本処理2メソッド
    private void Pattern1_bt2()
    {
      // 共通処理
      string dtn = DateTime.Now.ToString("yyyyMMddHHmmssfff");

      // 個別処理
      textBox1.Text = "p1button2:" + dtn;
    }

    #endregion

    #region 共通化

    // フラグ
    string flg;

    // 共通メソッド
    private void CommonMeth(string flg)
    {
      // 共通処理
      string dtn = DateTime.Now.ToString("yyyyMMddHHmmssfff");

      // 分岐先の初期化
      string btNum = null;

      // 個別処理
      if (flg == "1")
      {
        btNum = "p2button1:";
      }
      else if (flg == "2")
      {
        btNum = "p2button2:";
      }
      textBox1.Text = btNum + dtn;
    }

    #endregion

    #region デリゲート

    // 共通処理メソッド
    private void CommonDele(Pattern3Delegate dlgt)
    {
      // 共通処理
      string dtn = DateTime.Now.ToString("yyyyMMddHHmmssfff");

      // 引数で取得したデリゲートを使用
      dlgt(dtn);
    }

    // ボタン1の処理メソッド
    private void bt1_ClickMeth(string dtn)
    {
      // 個別処理
      textBox1.Text = "p3button1:" + dtn;
    }

    // ボタン2の処理メソッド
    private void bt2_ClickMeth(string dtn)
    {
      // 個別処理
      textBox1.Text = "p3button2:" + dtn;
    }

    #endregion
  }
}
