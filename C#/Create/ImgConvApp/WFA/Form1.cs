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
using System.Drawing.Imaging;

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
      string hoge01 = ConfigurationManager.AppSettings["Hoge01"];
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 画像フォーマット変数
    ImageFormat imageFormat;

    #endregion


    #region メインフォーム初期設定メソッド
    private void MainFormInitSeting()
    {
      // 変更後拡張子コンボボックス設定
      cbExtention.DataSource = new string[] { "jpg", "png", "bmp", "ico", "tif", "gif" };
      // 変更後拡張子コンボボックス選択
      cbExtention.SelectedItem = 0;
      // デフォルトフォーマット(拡張子コンボボックスの選択と合わせる)
      imageFormat = ImageFormat.Jpeg;
    }
    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // メインフォーム初期設定メソッド使用
      MainFormInitSeting();
    }
    #endregion

    #region コンボボックス値変更イベント
    private void cbExtention_Validated(object sender, EventArgs e)
    {
      // 拡張子コンボボックスからフォーマットを選判定する
      switch (cbExtention.Text)
      {
        case "jpg":
          imageFormat = ImageFormat.Jpeg;
          break;

        case "png":
          imageFormat = ImageFormat.Png;
          break;

        case "bmp":
          imageFormat = ImageFormat.Bmp;
          break;

        case "ico":
          imageFormat = ImageFormat.Icon;
          break;

        case "tif":
          imageFormat = ImageFormat.Tiff;
          break;

        case "gif":
          imageFormat = ImageFormat.Gif;
          break;
      }
    }
    #endregion

    #region ボタン1押下イベント
    private void button1_Click(object sender, EventArgs e)
    {
      // 画像変換メソッド使用
      ImgConversion();
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 画像変換メソッド
    public void ImgConversion()
    {
      // ターゲットフォルダを取得
      string targetFolder = tbTargetPath.Text;
      // 対象フォルダ内のファイルを取得
      string[] files = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
      // ねずみ返し_対象ファイルがない場合
      if (files.Length == 0)
      {
        MessageBox.Show("対象のファイルがありません");
        return;
      }

      // 全てのファイルを処理
      foreach (string x in files)
      {
        try
        {
          // ビットマップに変換
          using (Bitmap img = (Bitmap)Bitmap.FromFile(x))
          {
            // ファイル名取得(拡張子なし)
            string fileName = Path.GetFileNameWithoutExtension(x);
            // フォーマットを指定して保存
            img.Save(fileName + "." + cbExtention.Text, imageFormat);
          }
        }
        catch
        {
          continue;
        }
      }
      MessageBox.Show("完了しました");
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
