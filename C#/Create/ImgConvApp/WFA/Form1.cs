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
using ImageMagick;

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
      // 対象パス取得
      string targetPath = tbTargetPath.Text;
      // 出力パス取得
      string outputPath = tbOutputPath.Text;
      // 変換後拡張子取得
      string extention = cbExtention.Text;

      // ねずみ返し
      if (targetPath == string.Empty)
      {
        MessageBox.Show("対象パスがありません");
        return;
      }

      // 出力パスが設定されている場合
      if (outputPath != string.Empty)
      {
        // 最後一文字が「\」でない場合
        if (outputPath.Substring(outputPath.Length - 1, 1) != @"\")
          outputPath += @"\";
      }

      // ファイルの場合
      if (File.Exists(targetPath))
      {
        // 画像変換メソッド使用
        ImgConversion(targetPath, outputPath, extention);
      }
      else if (Directory.Exists(targetPath))
      {
        // フォルダからXMLファイルのパスだけ取得
        string[] targetFolder = Directory.GetFiles(targetPath, "*", SearchOption.TopDirectoryOnly);

        // ループ
        foreach (string x in targetFolder)
        {
          // 画像変換メソッド使用
          ImgConversion(x, outputPath, extention);
        }
      }
      else
      {
        MessageBox.Show("対象が存在しません");
        return;
      }

      MessageBox.Show("完了しました");
    }
    #endregion

    #region ボタン2押下イベント
    private void button2_Click(object sender, EventArgs e)
    {

    }
    #endregion


    #region 画像変換メソッド
    public void ImgConversion(string targetPath, string outputPath, string extention)
    {
      // 表示対象画像イメージマジック取り込み
      byte[] imgByte;
      using (MagickImage image = new MagickImage(targetPath))
      {
        // ビットマップに設定
        image.Format = MagickFormat.Bmp;
        // バイト変換
        imgByte = image.ToByteArray();
      }
      // 画像バイトストリーム取り込み
      using (MemoryStream ms = new MemoryStream(imgByte))
      {
        // ビットマップ変換
        using (Bitmap img = new Bitmap(ms))
        {
          // ファイル名取得(拡張子なし)
          string fileName = Path.GetFileNameWithoutExtension(targetPath);
          // フォーマットを指定して出力先に保存(出力パス設定がない場合、対象ファイル位置)
          img.Save(outputPath + fileName + "." + extention, imageFormat);
        }
      }
    }
    #endregion


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
