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
 * 継承_型
 *   ・基底クラスを継承した派生クラスのインスタンスは
 *     基底クラス型の変数に格納することが可能
 *   ・基底クラス型の派生クラスインスタンスは
 *     基底クラスで宣言されているメンバしか使用できない
 *   ・派生クラスで隠蔽かオーバーライドされたメソッドは異なる動作をする
 *     隠蔽
 *       基底クラスと派生クラスのメソッドを別物として扱うため
 *       基底クラス型の派生クラスインスタンスで
 *       使用できるのは基底クラスのものとなる
 *     オーバーライド
 *       基底クラスのメソッドが派生クラスのメソッドで上書かれるため
 *       基底クラス型の派生クラスインスタンスで
 *       使用できるのは派生クラスのものとなる
 *
 * ⇒
 *   ・基底クラス型の変数に派生クラスのインスタンスを代入するということは
 *     言い換えると同じ型でもインスタンスが変われば
 *     メンバーの振る舞い(処理)も変わるということ
 *     →この性質はインターフェイス機能で有効に使用できる
 *       インターフェイスに宣言したメンバは継承したクラスで
 *       必ず実装が必要になるためインターフェイス型変数に
 *       派生クラスインスタンスを代入したものは
 *       必ずインターフェイスに宣言したメンバが使用でき
 *       そのメンバはインスタンス化したクラスの内容に依存する
 *   ・上記のため、インスタンスからアクセスることができるメンバは
 *     インスタンスが格納されている変数の型によるということがわかる
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
      BaseCls derCls01 = new DerivationCls01();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス01"));

      // メソッド01_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls01.Meth01(1, 2).ToString()));
      // メソッド02_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls01.Meth02(1, 2).ToString()));

      // メソッド03は基底クラスで宣言していないためエラーとなる
#if ERROR
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass01.Meth03(1, 2).ToString()));
#endif

      #endregion

      #region 派生クラス02

      BaseCls derCls02 = new DerivationCls02();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス02"));

      // メソッド01_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth01(1, 2).ToString()));
      // メソッド02_基底オリジナル
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls02.Meth02(1, 2).ToString()));

      // メソッド03、04は基底クラスで宣言していないためエラーとなる
#if ERROR
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass02.Meth03(1, 2).ToString()));
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derClass02.Meth04(1, 2).ToString()));
#endif

      #endregion

      #region 派生クラス03

      BaseCls derCls03 = new DerivationCls03();
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, "派生クラス03"));

      // メソッド01_派生先(隠蔽)ではなく基底クラスのものが使用される
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth01(1, 2).ToString()));
      // メソッド02_派生先(オーバーライド)のものが使用される
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth02(1, 2).ToString()));

      // メソッド03は基底クラスで宣言していないためエラーとなる
#if ERROR
      textBox1.AppendText(string.Format(OUT_STR_FORMAT, derCls03.Meth03(1, 2).ToString()));
#endif

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

    #region オリジナルメソッド03
    /// <summary>
    /// オリジナルメソッド04_派生クラス02
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
}
