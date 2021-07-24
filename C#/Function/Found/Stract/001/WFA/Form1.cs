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
 * 構造体
 *   ・クラスとの違いは値型か参照型か
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
      // 返却クラス返却メソッド使用
      ReturnClass clss = Reclass();
      // 返却構造体返却メソッド使用
      ReturnStruct strct = ReStruct();


      /* インスタンスから値取得 */
      // 返却クラス型の値表示
      textBox1.AppendText(clss.var01 + Environment.NewLine);
      textBox1.AppendText(clss.var02.ToString() + Environment.NewLine);
      foreach (int x in clss.array03)
      {
        textBox1.AppendText(x.ToString() + Environment.NewLine);
      }
      // 返却構造体型の値表示
      textBox1.AppendText(strct.var04 + Environment.NewLine);
      textBox1.AppendText(strct.var05.ToString() + Environment.NewLine);
      foreach (int x in strct.array06)
      {
        textBox1.AppendText(x.ToString() + Environment.NewLine);
      }


      /* インスタンスを引数にメソッド内で値変更 */
      textBox1.AppendText("-------------------------------------" + Environment.NewLine);
      // インスタンス値変更メソッド使用
      ChangeIns(clss, strct);
      // 値表示
      textBox1.AppendText(clss.var01 + Environment.NewLine);
      textBox1.AppendText(strct.var04 + Environment.NewLine);
      textBox1.AppendText(strct.array06[1] + Environment.NewLine);


      /* 変数を引数にメソッド内で値変更 */
      textBox1.AppendText("-------------------------------------" + Environment.NewLine);
      // 変数値変更メソッド使用
      ChangeVar(clss.var01, clss.array03, strct.var04, strct.array06);
      // 返却クラス型の値表示
      textBox1.AppendText(clss.var01 + Environment.NewLine);
      foreach (int x in clss.array03)
      {
        textBox1.AppendText(x.ToString() + Environment.NewLine);
      }
      // 返却構造体型の値表示
      textBox1.AppendText(strct.var04 + Environment.NewLine);
      foreach (int x in strct.array06)
      {
        textBox1.AppendText(x.ToString() + Environment.NewLine);
      }
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 返却クラス返却メソッド
    public ReturnClass Reclass()
    {
      // 返却クラスインスタンス生成
      ReturnClass rClass = new ReturnClass();

      // 返却クラスの変数に値を格納
      rClass.var01 = "1";
      rClass.var02 = 2;
      rClass.array03 = new int[] { 3, 33, 333 };

      // 返却クラス返却
      return rClass;
    }
    #endregion

    #region 返却構造体返却メソッド
    public ReturnStruct ReStruct()
    {
      // 返却構造体インスタンス生成
      ReturnStruct rStruct = new ReturnStruct();

      // 返却構造体の変数に値を格納
      rStruct.var04 = "4";
      rStruct.var05 = 5;
      rStruct.array06 = new int[] { 6, 66, 666 };

      // 返却構造体返却
      return rStruct;
    }
    #endregion


    #region インスタンス値変更メソッド
    public void ChangeIns(ReturnClass clss, ReturnStruct strct)
    {
      // 値変更
      clss.var01 = "a";
      strct.var04 = "b";
      strct.array06[1] = 10000;
    }
    #endregion

    #region 変数値変更メソッド
    public void ChangeVar(string clssStr, int[] clssArray, string strctStr, int[] strctArray)
    {
      // 値変更
      clssStr = "z";
      clssArray[1] = 99;
      strctStr = "y";
      strctArray[1] = 98;
    }
    #endregion
  }


  #region 返却クラス
  /// <summary>
  /// 返却クラス
  /// </summary>
  public class ReturnClass
  {
    public string var01;
    public int var02;
    public int[] array03;
  }
  #endregion


  #region 返却構造体
  /// <summary>
  /// 返却構造体
  /// </summary>
  public struct ReturnStruct
  {
    public string var04;
    public int var05;
    public int[] array06;
  }
  #endregion
}
