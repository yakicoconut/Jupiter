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

#region ヘッダ
/*
 * デリゲート
 *   配列型(IOrderedEnumerable)のOrderByメソッドの引数の
 *   ラムダ式にデリゲートを使用する
 *   →デリゲートに格納するインスタンスは
 *     コンボボックスの値によって分岐する
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

    // デリゲート宣言
    delegate DateTime DlgtFileOrder(string path);

    #endregion

    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // コンボボックス値設定
      string[] array = { "作成日", "最終書込", "最終参照" };
      comboBox1.DataSource = array;
    }
    #endregion

    #region 実行ボタン押下イベント
    private void btExec_Click(object sender, EventArgs e)
    {
      // 結果テキストボックス初期化
      textBox2.Text = "";

      // ファイル一覧の取得はIEnumerable型
      IEnumerable files = null;
      // ファイル並び替えデリゲート切り替えメソッド使用
      DlgtFileOrder dlgtFileOrder = GetFileOrderDlgt();

      // 並べ替え
      files = Directory.GetFiles(textBox1.Text, "*", SearchOption.AllDirectories).OrderBy(f => dlgtFileOrder(f));

      // 結果表示
      foreach (var x in files)
      {
        textBox2.AppendText(x.ToString() + Environment.NewLine);
      }
    }
    #endregion

    #region ファイル並び替えデリゲート切り替えメソッド
    private DlgtFileOrder GetFileOrderDlgt()
    {
      // コンボボックスの値からスイッチ
      DlgtFileOrder dlgtFileOrder;
      switch (comboBox1.Text)
      {
        case "作成日":
          dlgtFileOrder = File.GetCreationTime;
          break;

        case "最終書込":
          dlgtFileOrder = File.GetLastWriteTime;
          break;

        case "最終参照":
          dlgtFileOrder = File.GetLastAccessTime;
          break;

        default:
          // デフォルト:作成日
          dlgtFileOrder = File.GetCreationTime;
          break;
      }
      return dlgtFileOrder;
    }
    #endregion
  }
}
