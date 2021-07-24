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
 * ・ソフトウェアデザインパターンの一つ
 * ・複数のクラスで共通クラスを使用するときに
 *   共通クラスのインスタンスを引き継ぐ方法
 * ・特にデータ格納クラスは複数のクラスで共通の
 *   インスタンスを使用する必要がある
 *   また、処理クラスに関しても同じクラスの
 *   インスタンスを使用するクラスごとに
 *   複数生成するのはメモリの無駄遣いとなる
 * シングルトンクラス使用クラス_メイン
 * ・シングルトンクラスのインスタンス引き継ぎメソッドは
 *   静的に宣言しているためインスタンスを生成しなくても
 *   使用可能
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
      // シングルトンパターン01クラスインスタンス生成
      /*
       * コンストラクタをプライベートで宣言しているため
       * インスタンスの新規生成は行えない
       */
      //SingletonClass01 singletonClass01 = new SingletonClass01();

      // シングルトンインスタンス引継メソッド使用
      /*
       * インスタンス引き継ぎメソッドを使用して
       * 既に生成されているインスタンスを取得する
       */
      SingletonClass01 singletonClass01 = SingletonClass01.GetInstance();

      // テスト文字列プロパティ設定
      singletonClass01.TestStrProp = "test01";
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // シングルトンインスタンス引継メソッド使用
      SingletonClass01 singletonClass01 = SingletonClass01.GetInstance();

      // テスト文字列プロパティ使用
      /*
       * ボタン1で設定したプロパティは
       * 本メソッドで改めて取得したインスタンスでも
       * 引き継がれていることが確認できる
       */
      textBox1.Text = singletonClass01.TestStrProp;
    }
    #endregion
  }


  #region ヘッダ
  /*
   * シングルトンパターンクラス
   * ・コンストラクタをプライベートにすることによって
   *   外部クラスからのインスタンスの生成を不可にする
   * ・静的(※下記参照)にプライベートグローバル変数として
   *   自身のインスタンスを生成する
   * ・静的にパブリックメソッドとして
   *   上記のインスタンス変数を返すメソッドを追加する
   *   ※上記インスタンス変数はこのメソッドで使用するため
   *     静的に宣言を使用する必要がある
   */
  #endregion
  /// <summary>
  /// シングルトンパターン01クラス
  /// </summary>
  public class SingletonClass01
  {
    #region シングルトンパターン

    // シングルトン用インスタンス生成
    private static SingletonClass01 instance = new SingletonClass01();

    /// <summary>
    /// シングルトンインスタンス引継メソッド
    /// </summary>
    /// <returns></returns>
    public static SingletonClass01 GetInstance()
    {
      return instance;
    }

    #endregion

    #region プライベートコンストラクタ
    private SingletonClass01()
    {

    }
    #endregion


    #region プロパティ

    /// <summary>
    /// テスト文字列プロパティ
    /// </summary>
    public string TestStrProp { get; set; }

    #endregion
  }
}
