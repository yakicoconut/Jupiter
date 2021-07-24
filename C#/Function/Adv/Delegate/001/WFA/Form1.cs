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
 *   概要
 *     ・デリゲート型はメソッドを代入するための変数の型
 *     ・C#ではメソッドも、変数代入や他メソッドの引数、戻り値として使用することが出来る
 *     ・デリゲートの宣言は名前空間内もしくはクラス内、かつメソッド外で行う
 *     ・戻り値と引数リストの型がすべて同一のメソッドのみ格納が出来る
 *   宣言
 *     delegate 返り値型 デリゲート名(引数リスト)
 *   代入
 *     C#1.0ではnewが必要
 *       デリゲート名 変数名 = new デリゲート名(メソッド名)
 *     C#2.0以降はnew不要
 *       デリゲート名 変数名 = メソッド名
 *   複数代入
 *     デリゲート名 変数名  = メソッド名
 *                  変数名 += メソッド名
 *   使用
 *     変数名(引数リスト)
 *   サイト
 *     [C#] デリゲート(delegate)とはなんぞや – gomokulog
 *     	http://gomocool.net/gomokulog/?p=250
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

    // 返り値なし、引数なしデリゲート
    delegate void DlgtVoid();

    // 返り値なし、文字列デリゲート
    delegate void DlgtVoidStr(string str);

    // 数値、引数なしデリゲート
    delegate int DlgtInt();

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 返り値なし、引数なしデリゲートにメソッド代入
      DlgtVoid dlgtVoid = VoidMeth;
      // 返り値なし、引数なしデリゲート使用
      dlgtVoid();

      // 返り値なし、文字列デリゲート
      DlgtVoidStr dlgtVoidStr = VoidStr;
      dlgtVoidStr("VoidStr\r\n");

      // 数値、引数なしデリゲート
      DlgtInt dlgtIntMeth = IntMeth;
      textBox1.AppendText(" → " + dlgtIntMeth().ToString() + "\r\n");

      // 返り値なし、文字列デリゲートに複数のメソッド代入
      DlgtVoidStr delMulti = VoidStr;
      delMulti += VoidStr2;
      delMulti("VoidStr\r\n");
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 返り値なし、引数なしメソッド
    public void VoidMeth()
    {
      textBox1.AppendText("VoidMeth\r\n");
    }
    #endregion

    #region 返り値なし、文字列メソッド
    public void VoidStr(string str)
    {
      textBox1.AppendText("1:" + str);
    }
    #endregion

    #region 数値、引数なしメソッド
    public int IntMeth()
    {
      textBox1.AppendText("IntMeth");
      return 0;
    }
    #endregion

    #region 返り値なし、文字列メソッド2
    public void VoidStr2(string str)
    {
      textBox1.AppendText("2:" + str);
    }
    #endregion
  }
}
