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
using System.Collections;
using ICalcPlugin;

/*
 * 拡張機能(プラグイン、アドイン、アドオン、エクステンション、スナップイン)
 *   ・プラグインをインストールすることにより、機能を追加できるアプリを実現する
 *     C#の場合、プラグインとは動的に参照するDllを変更すること
 *     参照先クラスと呼び出し元クラスが共通のインターフェイスクラスを
 *     継承していることで実現できる
 *   ・対象プラグイン(dll)は共通インターフェイスを継承し実装、
 *     プラグインフォルダに対象プラグインを配置しフォルダ内を全て取得
 *     共通インターフェイス型で対象プラグインのインスタンスを生成し使用する
 * 
 */
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

    // 対象プラグイン配列
    PluginInfo[] targetPulgins;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // 答え表示初期化
      label2.Text = "";
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // コンボボックス選択インデックス
      int comboxSelectIndex = comboBox1.SelectedIndex;

      // 選択プラグイン情報
      PluginInfo targetPlugin = targetPulgins[comboxSelectIndex];

      // プラグインクラスインスタンス生成メソッド使用
      ICalcClass calcIns = targetPlugin.CreateInstance();

      // 計算メソッド使用
      label2.Text = calcIns.Calc(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // プラグイン情報クラスインスタンス生成
      PluginInfo pluginInfo = new PluginInfo();

      if (targetPulgins != null)
      {
        targetPulgins = null;
      }

      try
      {
        // プラグイン探索メソッド使用
        targetPulgins = pluginInfo.FindPlugins();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
        return;
      }

      // 対象プラグインコンボボックス設定
      foreach (PluginInfo x in targetPulgins)
      {
        comboBox1.Items.Add(x.ClassName);
      }

      // 1項目を選択
      comboBox1.SelectedIndex = 0;
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }


  #region プラグイン情報クラス
  /// <summary>
  /// プラグイン情報クラス
  /// </summary>
  public class PluginInfo
  {
    #region デフォルトコンストラクタ
    /// <summary>
    /// デフォルトコンストラクタ
    /// </summary>
    public PluginInfo()
    {
      // 処理なし
    }
    #endregion

    #region プラグイン用コンストラクタ
    /// <summary>
    /// プラグイン用コンストラクタ
    /// </summary>
    /// <param name="path">アセンブリファイルのパス</param>
    /// <param name="cls">クラスの名前</param>
    private PluginInfo(string path, string cls)
    {
      // 変数格納
      Location = path;
      ClassName = cls;
    }
    #endregion


    #region プロパティ

    /// <summary>
    /// アセンブリファイルパス
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    /// 対象クラス名
    /// </summary>
    public string ClassName { get; set; }

    #endregion


    #region プラグイン探索メソッド
    /// <summary>
    /// プラグイン探索メソッド
    /// </summary>
    /// <returns>有効なプラグインのPluginInfo配列</returns>
    public PluginInfo[] FindPlugins()
    {
      // プラグインリスト
      ArrayList plugins = new ArrayList();
      // IPlugin型名称
      string ipluginName = typeof(ICalcClass).FullName;
      // プラグインフォルダ
      string folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      folder += "\\plugins";

      // ねずみ返し_フォルダが存在しない場合
      if (!Directory.Exists(folder))
      {
        throw new ApplicationException("プラグインフォルダ\"" + folder + "\"が見つかりませんでした。");
      }

      // .dllファイルを探す
      string[] dlls = Directory.GetFiles(folder, "*.dll");

      // dllから対象プラグイン抽出
      foreach (string x in dlls)
      {
        try
        {
          // アセンブリとして読み込む
          Assembly asm = Assembly.LoadFrom(x);

          // アセンブリ内のすべての型について検証、
          foreach (Type y in asm.GetTypes())
          {
            // プラグインとして有効か調べる
            // クラスかつプラグインかつ抽象クラスでないかつインターフェイス名が対象のものである
            if (y.IsClass && y.IsPublic && !y.IsAbstract && y.GetInterface(ipluginName) != null)
            {
              // 自身のクラスのコレクションとしてファイルパスと名称を追加
              plugins.Add(new PluginInfo(x, y.FullName));
            }
          }
        }
        catch
        {
        }
      }

      // コレクションを配列にして返す
      return (PluginInfo[])plugins.ToArray(typeof(PluginInfo));
    }
    #endregion

    #region プラグインクラスインスタンス生成メソッド
    /// <summary>
    /// プラグインクラスインスタンス生成メソッド
    /// </summary>
    /// <returns>プラグインクラスのインスタンス</returns>
    public ICalcClass CreateInstance()
    {
      try
      {
        // アセンブリを読み込む
        Assembly asm = Assembly.LoadFrom(Location);
        // クラス名からインスタンスを作成する
        return (ICalcClass)asm.CreateInstance(ClassName);
      }
      catch
      {
        return null;
      }
    }
    #endregion
  }
  #endregion
}
