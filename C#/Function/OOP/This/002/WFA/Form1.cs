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

#region ヘッダ
/*
 * Thisキーワード
 * ・デバッグ時の「this」の紛らわしさ
 *   継承先クラスで再定義していないメンバを使用すると
 *   継承元クラスのものが処理される
 *   そのためデバッグでブレークすると継承元クラスのメンバにステップインされる
 *   このとき、this修飾子を使用して継承先で再定義しているメンバを呼び出すと紛らわしい
 *   →下記のDerivate01Class.Exec()でブレークしBaseClass.Vir01Meth()にステップイン、「this.Vir02Meth()」の呼び出しを行うと
 *     Derivate01Class.Vir02Meth()にステップインする
 *     ⇒この挙動は処理の途中のBaseClass.Vir01Meth()からブレークしていると
 *       thisを使用しているのに別クラスのメソッドを呼び出すため混乱しやすいので注意
 */
#endregion
namespace WFA
{
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
    }
    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 継承先クラスの実行メソッド呼び出し
      Derivate01Class d01c = new Derivate01Class();
      d01c.Exec();
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
  public class BaseClass
  {
    /// <summary>
    /// 継承元メソッド01
    /// </summary>
    /// <returns></returns>
    protected virtual void Vir01Meth()
    {
      MessageBox.Show("Base01");

      // 「this」を使用しているが実際に呼び出すのは
      // 継承先クラスのメソッド
      this.Vir02Meth();
    }

    /// <summary>
    /// 継承元メソッド02
    /// </summary>
    /// <returns></returns>
    protected virtual void Vir02Meth()
    {
      MessageBox.Show("Base02");
    }
  }
  #endregion


  #region 継承先クラス01
  /// <summary>
  /// 継承先クラス01
  /// </summary>
  public class Derivate01Class : BaseClass
  {
    /// <summary>
    /// 実行メソッド
    /// </summary>
    public void Exec()
    {
      // 本クラスにメソッドが存在しない(コメントアウト中の)ため
      // 継承元クラスのメソッドを使用する       
      this.Vir01Meth();
    }

    ///// <summary>
    ///// 継承先メソッド01
    ///// </summary>
    //protected override void Vir01Meth()
    //{
    //  MessageBox.Show("Derivate01");
    //  this.Vir02Meth();
    //}

    /// <summary>
    /// 継承先メソッド02
    /// </summary>
    protected override void Vir02Meth()
    {
      MessageBox.Show("Derivate02");
    }
  }
  #endregion
}
