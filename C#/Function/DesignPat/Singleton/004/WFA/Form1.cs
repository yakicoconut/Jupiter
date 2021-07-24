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
 * Singleton
 * ・複数のクラスで相互的に
 *   シングルトンインスタンスを取得する
 * C# での Singleton についてまとめ - やこ～ん SuperNova2
 * 	http://d.hatena.ne.jp/saiya_moebius/20091017/1255799846
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


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // シングルトンインスタンス引継メソッド使用
      SingletonClass01 singletonClass01 = SingletonClass01.GetInstance();
      // シングルトンインスタンス引継メソッド使用
      SingletonClass02 singletonClass02 = SingletonClass02.GetInstance();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion
  }


  #region シングルトンパターン01クラス
  /// <summary>
  /// シングルトンパターン01クラス
  /// </summary>
  public class SingletonClass01
  {
    #region シングルトンパターン

    // シングルトン用インスタンス生成①
    private static SingletonClass01 instance = new SingletonClass01();

    /// <summary>
    /// シングルトンインスタンス引継メソッド
    /// </summary>
    /// <returns></returns>
    public static SingletonClass01 GetInstance()
    {
      // ⑥
      return instance;
    }

    #endregion

    #region プライベートコンストラクタ
    private SingletonClass01()
    {
      // ②
      singletonClass02 = SingletonClass02.GetInstance();

      // テスト数値プロパティに値を設定
      singletonClass02.TestIntProp = 1;
    }
    #endregion


    #region 宣言

    // シングルトンインスタンス引継メソッド使用
    SingletonClass02 singletonClass02;

    #endregion

    #region プロパティ

    /// <summary>
    /// テスト文字列プロパティ
    /// </summary>
    public string TestStrProp { get; set; }

    #endregion
  }
  #endregion


  #region シングルトンパターン02クラス
  /// <summary>
  /// シングルトンパターン02クラス
  /// </summary>
  public class SingletonClass02
  {
    #region シングルトンパターン

    // シングルトン用インスタンス生成③
    private static SingletonClass02 instance = new SingletonClass02();

    /// <summary>
    /// シングルトンインスタンス引継メソッド
    /// </summary>
    /// <returns></returns>
    public static SingletonClass02 GetInstance()
    {
      return instance;
    }

    #endregion

    #region プライベートコンストラクタ
    private SingletonClass02()
    {
      // ④
      singletonClass01 = SingletonClass01.GetInstance();

      // テスト文字列プロパティに値を設定
      singletonClass01.TestStrProp = "test02";
    }
    #endregion


    #region 宣言

    // シングルトンインスタンス引継メソッド使用
    SingletonClass01 singletonClass01;

    #endregion

    #region プロパティ

    /// <summary>
    /// テスト数値プロパティ
    /// </summary>
    public int TestIntProp { get; set; }

    #endregion
  }
  #endregion
}
