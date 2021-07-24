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
 * ・「this」キーワードは記述されているクラスを返す
 * ・宣言されているメンバの名称に同一のものがある場合(クラスメンバ。メソッドメンバ等)も
 *   別の変数として扱われ「this」を接頭辞とした変数をクラスメンバとして扱う
 *   →「this」を使用したものはクラスメンバを指定、使用しないものはメソッドメンバを指定
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


    #region クラスメンバ

    // クラスのメンバとして宣言した「var」変数
    public string var;

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // thisキーワード検証メソッド使用
      ThisTestMeth();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion

    #region thisキーワード検証メソッド
    /// <summary>
    /// thisキーワード検証メソッド
    /// </summary>
    private void ThisTestMeth()
    {
      // メソッド内で宣言した「var」変数
      string var;

      // メソッド内
      var = "abc";
      // クラスメンバ
      this.var = "def";

      // メソッド内の変数を使用
      textBox1.AppendText(var);
      textBox1.AppendText("\r\n");

      // クラスメンバの変数を使用
      textBox1.AppendText(this.var);

      // 「this」は本クラスを指す
      textBox1.AppendText("\r\n\r\n");
      textBox1.AppendText(this.ToString());
    }
    #endregion
  }
}
