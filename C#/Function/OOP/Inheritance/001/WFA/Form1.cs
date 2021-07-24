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
 * 継承
 *   ・あるクラスを継承した派生クラスでは
 *     継承元クラスのメンバを使用することができる
 *   ・基底クラスのメンバと同じ名前のメンバを定義することは
 *     隠蔽かオーバーライドとなる
 *     →単に同じ名前のメンバを定義すると暗黙隠蔽
 *     →「new」キーワードをつけて同名メンバを定義すると明示隠蔽
 *     →基底クラスでのvirtual宣言を行い、「override」キーワードをつけるとオーバーライド
 *   ・隠蔽とオーバーライドは基底クラス型に派生クラスのインスタンスを
 *     代入する場合に振る舞いが変わる
 *     →本サンプルではこの検証は行わない
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

    // 出力文字列フォーマット
    string OUT_STR_FORMAT = "{0}" + Environment.NewLine;

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      #region 派生クラス01

      // インスタンス生成
      DerivationCls01 derCls01 = new DerivationCls01();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス01"));

      // メソッド01_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls01.Meth01(1, 2).ToString()));
      // メソッド02_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls01.Meth02(1, 2).ToString()));
      // メソッド03_派生オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls01.Meth03(1, 2).ToString()));

      #endregion

      #region 派生クラス02

      DerivationCls02 derCls02 = new DerivationCls02();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス02"));

      // メソッド01_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth01(1, 2).ToString()));
      // メソッド02_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth02(1, 2).ToString()));
      // メソッド03_派生オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth03(1, 2).ToString()));
      // メソッド04_派生オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth04(1, 2).ToString()));

      #endregion

      #region 派生クラス03

      DerivationCls03 derCls03 = new DerivationCls03();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス03"));

      // メソッド01_派生new
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth01(1, 2).ToString()));
      // メソッド02_派生オーバーライド
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth02(1, 2).ToString()));
      // メソッド03_派生オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth03(1, 2).ToString()));

      #endregion

      #region 派生クラス11

      DerivationCls11 derClass11 = new DerivationCls11();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス11"));

      // メソッド01_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass11.Meth01(1, 2).ToString()));
      // メソッド02_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass11.Meth02(1, 2).ToString()));
      // メソッド03_派生オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass11.Meth03(1, 2).ToString()));
      // メソッド11_派生オリジナル(孫クラス)
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass11.Meth11(1, 2).ToString()));

      #endregion
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
  class BaseCls
  {
    #region オリジナルメソッド01
    /// <summary>
    /// オリジナルメソッド01
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth01(int a, int b)
    {
      return a + b;
    }
    #endregion

    #region オリジナルメソッド02
    /// <summary>
    /// オリジナルメソッド02
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public virtual int Meth02(int a, int b)
    {
      return a - b;
    }
    #endregion
  }
  #endregion


  #region 派生クラス01
  /// <summary>
  /// 派生クラス01
  /// </summary>
  class DerivationCls01 : BaseCls
  {
    #region オリジナルメソッド03
    /// <summary>
    /// オリジナルメソッド03_派生クラス01
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth03(int a, int b)
    {
      return a * b;
    }
    #endregion
  }
  #endregion


  #region 派生クラス02
  /// <summary>
  /// 派生クラス02
  /// </summary>
  class DerivationCls02 : BaseCls
  {
    #region オリジナルメソッド03
    /// <summary>
    /// オリジナルメソッド03_派生クラス02
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth03(int a, int b)
    {
      return a * b + 10;
    }
    #endregion

    #region オリジナルメソッド04
    /// <summary>
    /// オリジナルメソッド03_派生クラス02
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth04(int a, int b)
    {
      return a / b;
    }
    #endregion
  }
  #endregion


  #region 派生クラス03
  /// <summary>
  /// 派生クラス03
  /// </summary>
  class DerivationCls03 : BaseCls
  {
    #region newメソッド01
    /// <summary>
    /// newメソッド01_派生クラス03
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public new int Meth01(int a, int b)
    {
      return a + b + 100;
    }
    #endregion

    #region overrideメソッド02
    /// <summary>
    /// overrideメソッド02_派生クラス03
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public override int Meth02(int a, int b)
    {
      return a - b + 100;
    }
    #endregion

    #region オリジナルメソッド03
    /// <summary>
    /// オリジナルメソッド03_派生クラス03
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth03(int a, int b)
    {
      return a * b + 100;
    }
    #endregion
  }
  #endregion


  #region 派生クラス11
  /// <summary>
  /// 派生クラス11
  /// </summary>
  class DerivationCls11 : DerivationCls01
  {
    #region オリジナルメソッド1
    /// <summary>
    /// オリジナルメソッド1_派生クラス11
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int Meth11(int a, int b)
    {
      return a + b + 1000;
    }
    #endregion
  }
  #endregion
}
