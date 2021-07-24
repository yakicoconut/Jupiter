using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Threading;

#region ヘッダ
/*
 * プログレスバー
 * 
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

    #region プロパティ

    // ラベル更新文字列
    public string str { get; set; }

    #endregion


    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // バックグラウンド処理クラスインスタンス生成
      BackGroundClass1 bgclss = new BackGroundClass1(this);

      // スタートメソッド使用
      Thread threadA = bgclss.Start();

      // スレッド終了待ち
      // ※終了待ちしない場合はコメント
      threadA.Join();

      // バックグラウンド処理で更新されたプロパティ使用
      label1.Text = str;
    }
    #endregion
  }
}
