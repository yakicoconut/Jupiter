#define PATTERN01
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

#region ヘッダ
/*
 * シングルトン002
 *   概要~staticクラスとの違い~
 *     ┌─────────────────────-┐
 *     │項目            │静的クラス│ シングルトン│
 *     │================│==========│=============│
 *     │継承            │できない  │できる       │
 *     │仮想メンバ      │持てない  │持てる       │
 *     │抽象メンバ      │持てない  │持てる       │
 *     │インターフェイス│持てない  │持てる       │
 *     └─────────────────────-┘
 *     ・データを読み書きする場合、プロセス中でかなからず唯一のデータ領域を扱える
 *       という意味で利用感は全く同じ    
 *     ・シングルトンは派生クラスによってメソッドをオーバーライドできるので、
 *       テストのときにダミーデータ応答をするテストオブジェクトに差し替えるなど柔軟な対応が可能
 *     ・静的クラスは実装が簡易
 *   サイト
 *     C# の static クラスとシングルトン考察 - PG日誌
 *	    http://takachan.hatenablog.com/entry/2016/01/04/211414
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
      #region パターン01
#if PATTERN01

      // シングルトンクラスのインスタンス取得静的メソッド使用
      SingletonClass instance1 = SingletonClass.GetInstance();
      SingletonClass instance2 = SingletonClass.GetInstance();

      // シングルトンされているか
      if (instance1 == instance2)
      {
        MessageBox.Show("一致");
      }
      else
      {
        MessageBox.Show("不一致");
      }

      // メンバ変数表示
      MessageBox.Show(instance1.var01 + "\r\n" + instance1.var02);

#endif
      #endregion
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 静的クラスメンバ表示
      MessageBox.Show(StaticClass.var01);


      #region エラーパターン
#if ERROR
      
      /*
       * 静的クラスはインスタンスを生成することが出来ない
       */
      StaticClass sclass = new StaticClass();

#endif
      #endregion
    }
    #endregion
  }


  #region シングルトンクラス
  /// <summary>
  /// シングルトンクラス
  /// </summary>
  public sealed class SingletonClass
  {
    // コンストラクタ
    private SingletonClass()
    {
      // メンバ変数に値を入れる
      var01 = "abc";
    }

    // 返却用インスタンス
    private static SingletonClass _singleton = new SingletonClass();

    /// <summary>
    /// インスタンス取得静的メソッド
    /// </summary>
    /// <returns></returns>
    public static SingletonClass GetInstance()
    {
      // インスタンスを返す
      return _singleton;
    }

    // メンバ変数
    public string var01;
    public string var02 = "def";
  }
  #endregion


  #region 静的クラス
  /// <summary>
  /// 静的クラス
  /// </summary>
  public static class StaticClass
  {
    /*
     * 静的クラスでは以下の制約が存在する
     *   ・コンストラクタを使用できない
     *   ・継承が禁止
     *   ・仮想メンバ、抽象メンバー、インターフェイスが持てない
     */

    // メンバ変数
    public static string var01 = "ghi";
  }
  #endregion
}
