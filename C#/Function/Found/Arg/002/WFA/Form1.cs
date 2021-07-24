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
 * 引数002
 *   ・クラスは参照型のため、別クラスへの渡し時も
 *     デフォルトで参照渡しされる
 *   ・コンストラクタで別クラスに渡されたクラスに対して
 *     行った変更は特別に別クラスで更新を行わなくても反映される
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

      // 値設定
      str = "ABC";

      // 別クラスインスタンスに自身を渡す
      clss = new Class1(this);
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

    // 文字列変数
    public string str;

    // 別クラス変数
    Class1 clss;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 文字列変数値変更
      str = "DEF";

      // 別クラスに渡した自身のクラスから文字列変数を呼び出す
      // クラスは参照型のため上記の値変更が反映されている
      textBox1.Text = clss.fm1.str;
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
}
