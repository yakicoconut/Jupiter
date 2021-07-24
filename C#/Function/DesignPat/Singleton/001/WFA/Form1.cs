#define PATTERN01
#define PATTERN02
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
 * シングルトン001
 *   概要
 *     ・GoFパターンの内の一つ
 *     ・インスタンスの生成を一つのみに保障する
 *     ・C#では専用機能は存在しないため
 *       メソッドを使用する方法と
 *       プロパティを使用する方法で実装する
 *   
 *   目的
 *     インスタンスを一つしか生成したくないクラスを作成できる
 *     絶対にアプリケーション全体で統一しなければならない仕組みの実装
 *    
 *   サイト
 *     デザインパターン「Singleton」
 *     	https://qiita.com/shoheiyokoyama/items/c16fd547a77773c0ccc1
 *     C# で シングルトンパターン - Qiita
 *      https://qiita.com/rohinomiya/items/6bca22211d1bddf581c4
 * 
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
      SingletonMethClass instance1 = SingletonMethClass.GetInstance();
      SingletonMethClass instance2 = SingletonMethClass.GetInstance();

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


      #region パターン02
#if PATTERN02

      // シングルトンクラスプロパティからインスタンス取得
      MessageBox.Show(SingletonPropClass.singletonProp.ToString());
      MessageBox.Show(SingletonPropClass.singletonProp.var01 + "\r\n" + SingletonPropClass.singletonProp.var02);

#endif
      #endregion


      #region エラーパターン
#if ERROR
      
      /*
       * シングルトンクラスのコンストラクタは
       * プライベート設定のためインスタンスを作成できない
       */
      SingletonMethClass instance3 = new SingletonMethClass();
      SingletonPropClass instance4 = new SingletonPropClass();

#endif
      #endregion
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // 通常クラスインスタンス生成
      NonSingletonClass instance1 = new NonSingletonClass();
      NonSingletonClass instance2 = new NonSingletonClass();

      // シングルトンされているか
      if (instance1 == instance2)
      {
        MessageBox.Show("一致");
      }
      else
      {
        MessageBox.Show("不一致");
      }
    }
    #endregion
  }


  #region シングルトンクラス_メソッド
  /// <summary>
  /// シングルトンクラス
  /// </summary>
  public sealed class SingletonMethClass
  {
    // コンストラクタ
    private SingletonMethClass()
    {
      // メンバ変数に値を入れる
      var01 = "abc";
    }

    // 返却用インスタンス
    private static SingletonMethClass _singleton = new SingletonMethClass();

    /// <summary>
    /// インスタンス取得静的メソッド
    /// </summary>
    /// <returns></returns>
    public static SingletonMethClass GetInstance()
    {
      // インスタンスを返す
      return _singleton;
    }

    // メンバ変数
    public string var01;
    public string var02 = "def";
  }
  #endregion


  #region シングルトンクラス_プロパティ
  /// <summary>
  /// シングルトンクラス_プロパティ
  /// </summary>
  public sealed class SingletonPropClass
  {
    // コンストラクタ
    private SingletonPropClass()
    {
      // メンバ変数に値を入れる
      var01 = "ghi";
    }

    // バッキングフィールド(返却用インスタンス)
    private static SingletonPropClass instance;

    /// <summary>
    /// シングルトンインスタンス用プロパティ
    /// </summary>
    public static SingletonPropClass singletonProp
    {
      // 取得のみ宣言
      get
      {
        // インスタンスが設定されていない場合
        if (SingletonPropClass.instance == null)
        {
          // バッキングフィールドにインスタンスを設定
          SingletonPropClass.instance = new SingletonPropClass();
        }

        // バッキングフィールドを返却
        return SingletonPropClass.instance;
      }
    }

    // メンバ変数
    public string var01;
    public string var02 = "jkl";
  }
  #endregion


  #region 通常クラス
  /// <summary>
  /// 通常クラス
  /// </summary>
  public class NonSingletonClass
  {
    // コンストラクタ
    public NonSingletonClass()
    {
      // TODO:initialization
    }
  }
  #endregion
}
