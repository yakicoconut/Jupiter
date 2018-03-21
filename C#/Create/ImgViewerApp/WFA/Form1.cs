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

      // 他クラスのプロパティに本クラスを設定
      form2.form1 = this;

      // コマンドライン引数取得
      string[] cmdArgs = Environment.GetCommandLineArgs();
      // 引数がある場合(自身のexeパスが1つ目なので2以上のとき)
      if (cmdArgs.Length >= 2)
      {
        // ドラッグ&ドロップされたファイルの一つ目を取得
        string dropItem = Environment.GetCommandLineArgs()[1];
        //// ファイル読み込みメソッド使用
        //ReadFile(dropItem);
      }

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

    //フォーム2インスタンス生成
    Form2 form2 = new Form2();

    // 表示対象画像
    private Bitmap currentImage;
    // 画像パスディクショナリ
    Dictionary<int, string> dicImgPath = new Dictionary<int, string>();
    // 最大ページ数
    int maxImageKey = 0;
    // 現在表示ページ数
    int currentImageKey = 0;
    // 現在の開始位置(画像の左上)
    Point currentZeroPoint;
    // 現在のズーム倍率
    double currentZoomRatio;
    // 倍率変更後の画像のサイズと位置
    Rectangle drawRectangle;

    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      //常にメインフォームの手前に表示
      form2.Owner = this;
      //フォーム2呼び出し
      form2.Show();
    }
    #endregion

    #region マウスインされるファイルを開くイベント

    #region フォームドラッグエンターイベント
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      //AllowDropプロパティの許可が必要

      //ねずみ返し_マウスがファイルを持っていない場合、イベント・ハンドラを抜ける
      if (!e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        return;
      }

      //ドラッグ中のファイルの取得
      string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

      //ねずみ返し_ファイルのみを条件とする
      foreach (string d in drags)
      {
        //ファイルまたはフォルダ以外であればイベント・ハンドラを抜ける
        if (!(File.Exists(d) || Directory.Exists(d)))
        {
          return;
        }
      }

      //マウスの表示を「+」に変更する
      e.Effect = DragDropEffects.Copy;
    }
    #endregion

    #region フォームドラッグドロップイベント
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      // ドラッグ&ドロップされたファイルの一つ目を取得
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

      // ファイル読み込みメソッド使用
      ReadFile(dropItem);
    }
    #endregion

    #endregion

    #region Paintイベント
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      if (currentImage != null)
      {
        //画像を指定された位置、サイズで描画する
        e.Graphics.DrawImage(currentImage, drawRectangle);
      }
    }
    #endregion


    #region ファイル読み込みメソッド
    private void ReadFile(string dropItem)
    {
      string targetDirPath = string.Empty;

      // フォルダの場合
      if (Directory.Exists(dropItem))
      {
        // ドロップされたアイテムをそのまま使用
        targetDirPath = dropItem;
      }
      else
      {
        // ドロップされたアイテムからフォルダを取得
        targetDirPath = System.IO.Path.GetDirectoryName(dropItem);
      }

      // 対象フォルダの中身をすべて取得
      string[] files = Directory.GetFiles(targetDirPath, "*", SearchOption.TopDirectoryOnly);
      // 大文字小文字を区別しない序数比較で並び替える
      StringComparer cmp = StringComparer.OrdinalIgnoreCase;
      Array.Sort(files, cmp);

      // 画像パスディクショナリに変換
      int i = 0;
      foreach (string x in files)
      {
        i = i + 1;
        dicImgPath.Add(i, x);
      }
      // 最終ページ数を設定
      maxImageKey = files.Length;

      // ドロップされたのがフォルダの場合
      if (Directory.Exists(dropItem))
      {
        // 表示するファイルのページを1に設定
        currentImageKey = 1;
      }
      else
      {
        // 表示するファイルにドロップしたファイルを設定
        currentImageKey = dicImgPath.First(x => x.Value == dropItem).Key;
      }

      // 画像初期化メソッド使用
      InitImage(currentImage);
    }
    #endregion

    #region 画像初期化メソッド
    private void InitImage(Bitmap currentImage)
    {
      // 表示する画像を読み込む
      if (currentImage != null)
      {
        currentImage.Dispose();
      }
      // 表示対象画像取得
      currentImage = new Bitmap(dicImgPath[currentImageKey]);

      // 初期化用設定
      drawRectangle = new Rectangle(currentZeroPoint.X, currentZeroPoint.Y, (int)Math.Round(currentImage.Width * currentZoomRatio), (int)Math.Round(currentImage.Width * currentZoomRatio));

      // 画像を表示する
      pictureBox1.Invalidate();
    }
    #endregion

    #region 雛形メソッド
    public void template()
    {

    }
    #endregion

  }
}
