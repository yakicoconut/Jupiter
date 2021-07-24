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
 * 抽象クラス
 *   ・メンバを定義することはできるがインスタンスを生成して
 *     使用することができない(当然静的にも宣言できない)不完全な状態のクラス
 *     →継承で使用する前提の機構という点が通常のクラスと異なる
 *   ・抽象メソッド
 *     ・シグネチャのみ定義された実体のないメソッド
 *     ・抽象クラスでのみ宣言が可能
 *     ・派生先クラスで処理の実体を実装しなければならないが
 *       overrideの記述が必須な点、アクセシビリティは
 *       抽象メソッドのものを引き継ぐ(publicかprotected、インターフェイスでは全てpublicとなる)点が
 *       インターフェイス内のメソッドと異なる
 *         protected:自クラス、または派生クラスのみアクセス可能
 *   ・あくまでクラスのため多重継承は行えない
 *     →インターフェイスとの違い
 * ⇒
 *   ・処理を含むメンバを実装できるが
 *     直接インスタンスとして使用できないため、あくまで継承関係の上で使用する構想となる
 *   ・また、通常のメソッドと共存して継承先で実装が必須なメソッド(抽象メソッド)も定義できるため
 *     通常のクラスとインターフェイルの中間のような機構だが
 *     C#では多重継承を行えないためクラスと別に継承を行え、さらに多重に継承できる
 *     インターフェイスを以下のように
 *     「抽象メソッドを含む抽象クラス」⇒「通常クラス + インターフェイス」
 *     として使用するほうが推奨される?
 *     →インターフェースと抽象クラスの使い分け、活用方法
 *       	https://qiita.com/IganinTea/items/e1d35db0a14a84bda452
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
      // 抽象からの派生クラスインスタンス生成
      DerivationClass derClass = new DerivationClass();
      // 派生クラスの計算メソッド使用
      textBox1.AppendText(derClass.calcMeth(1, 2).ToString());
      textBox1.AppendText(Environment.NewLine);
      // 派生クラスの抽象上書きメソッド使用
      textBox1.AppendText(derClass.Minus(1, 2).ToString());

      #region パターン_エラー
#if ERROR

      // インスタンスは生成できない(直接使用ができない)
      AbClass abClass = new AbClass();

#endif
      #endregion

    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }


  #region 抽象クラス
  /// <summary>
  /// 抽象クラス
  /// </summary>
  abstract class AbClass
  {
    // プロテクテッドメソッド
    // protected:自クラス、または派生クラスのみアクセス可能
    protected int Plus(int a, int b)
    {
      return a + b;
    }

    // 抽象メソッド
    abstract public int Minus(int a, int b);

    // プライベートメソッド
    // private:自クラスのみアクセス可能、派生クラスでも使用できない
    private int Mul(int a, int b)
    {
      return a * b;
    }
  }
  #endregion


  #region 派生クラス
  /// <summary>
  /// 派生クラス
  /// </summary>
  class DerivationClass : AbClass
  {
    // 計算メソッド
    public int calcMeth(int a, int b)
    {
      // 基底クラスのプロテクテッドメソッド使用
      // 抽象クラスを継承しているため基底クラスのメソッドが使用可能
      int answerPlus = Plus(a, b);

      #region パターン_エラー
#if ERROR

      // 基底クラスのプライベートメソッドはアクセス不可
      int answerMul = Mul(a, b);

#endif
      #endregion

      return answerPlus;
    }

    // 抽象メソッドの上書き
    // 抽象メソッドのため必ずこのクラスに記述が必要
    // また、overrideは必須で、アクセシビリティは変えられない
    public override int Minus(int a, int b)
    {
      return a - b;
    }
  }
  #endregion
}