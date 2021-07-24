//#define ERROR
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
 * 継承_部分上書き
 *   ・オーバーライドしたメソッド内で上書き元メソッドを
 *     呼び出すことによって「元メソッド処理 + 派生先独自処理」と実装する
 *     →共通の処理は元メソッドで実装しオーバーライド先では独自処理を実装、
 *       元メソッドをその中で呼び出すことで共通処理の重複を防ぐ
 *       (Ex:デバイス連携の初期化処理を元メソッドで実装し
 *           プラスで必要な機種別の処理と元メソッド呼び出しを上書きメソッドで実装する
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


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 派生クラス01
      BaseClass derClass = new DerivationClass();
      textBox1.AppendText("派生クラス01" + Environment.NewLine);
      // 基底クラスメソッド使用
      textBox1.AppendText(derClass.Method01(1, 2).ToString() + Environment.NewLine);
      textBox1.AppendText(derClass.Method02(1, 2).ToString() + Environment.NewLine);
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion
  }


  #region 基底クラス
  /// <summary>
  /// 基底クラス
  /// </summary>
  class BaseClass
  {
    public int Method01(int a, int b)
    {
      return a + b;
    }

    public virtual int Method02(int a, int b)
    {
      return a - b;
    }
  }
  #endregion


  #region 派生クラス
  /// <summary>
  /// 派生クラス
  /// </summary>
  class DerivationClass : BaseClass
  {
    public override int Method02(int a, int b)
    {
      // 部分上書き処理
      a -= 1;
      b += 1;

      // 上書き元メソッド呼び出し
      return base.Method02(a, b);
    }

    public int Method03(int a, int b)
    {
      return a * b;
    }
  }
  #endregion
}
