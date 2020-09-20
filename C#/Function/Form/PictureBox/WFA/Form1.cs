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

#region ヘッダ
/*
 * 概要
 *   ・PictureBox関連
 *   ・ビットマップ取り込み
 *     Dispose(解放)を行わないとファイルロックされる
 *     →取り込んだ画像をピクチャボックスで表示していると
 *       解放時にエラーとなる
 *   ・ストリーム取り込み
 *     ストリーム取り込みで取り込んだ後、
 *     画像変数にコピーし、ストリームを開放することで
 *     ファイルロックを回避
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
      // 対象画像変数
      Image img;
      // ストリーム取り込み
      using (FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read))
      {
        // 画像変換
        img = Image.FromStream(fs);
      }

      // 画像表示
      pictureBox1.Image = img;
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {
      // ビットマップ取り込み
      Bitmap img = new Bitmap(textBox1.Text);

      // 画像表示
      pictureBox1.Image = img;

      // ビットマップ開放
      /*
       * !!!エラー!!!
       * ピクチャボックスで使用しているため、解放できない
       */
      //img.Dispose();
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
