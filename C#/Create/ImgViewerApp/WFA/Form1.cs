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
        //ファイル以外であればイベント・ハンドラを抜ける
        if (!System.IO.File.Exists(d))
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
      //ドラッグ&ドロップされたファイルの取得
      string[] args = (string[])e.Data.GetData(DataFormats.FileDrop);

      // 単純表示
      //pictureBox1.ImageLocation = args[0];

      //表示する画像を読み込む
      if (currentImage != null)
      {
        currentImage.Dispose();
      }
      currentImage = new Bitmap(args[0]);
      //初期化
      drawRectangle = new Rectangle(0, 0, currentImage.Width, currentImage.Height);
      zoomRatio = 1d;
      //画像を表示する
      pictureBox1.Invalidate();

    }
    #endregion

    #endregion


    //表示する画像
    private Bitmap currentImage;
    //倍率
    private double zoomRatio = 1d;
    //倍率変更後の画像のサイズと位置
    private Rectangle drawRectangle;
    private void ZoomIn()
    {
      PictureBox pb = pictureBox1;

      zoomRatio *= 2d;

      // 倍率変更後の画像のサイズと位置を計算する
      drawRectangle.Width = (int)Math.Round(currentImage.Width * zoomRatio);
      drawRectangle.Height = (int)Math.Round(currentImage.Height * zoomRatio);
      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(0d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    private void ZoomOut()
    {
      PictureBox pb = pictureBox1;

      zoomRatio *= 0.5d;

      //倍率変更後の画像のサイズと位置を計算する
      drawRectangle.Width = (int)Math.Round(currentImage.Width * zoomRatio);
      drawRectangle.Height = (int)Math.Round(currentImage.Height * zoomRatio);
      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(0d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    //PictureBox1のPaintイベントハンドラ
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      if (currentImage != null)
      {
        //画像を指定された位置、サイズで描画する
        e.Graphics.DrawImage(currentImage, drawRectangle);
      }
    }

    private void Up()
    {
      PictureBox pb = pictureBox1;

      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(0d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    private void Down()
    {
      PictureBox pb = pictureBox1;

      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(100d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    private void Right()
    {
      PictureBox pb = pictureBox1;

      drawRectangle.X = (int)Math.Round(-100d);
      drawRectangle.Y = (int)Math.Round(0d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    private void Left()
    {
      PictureBox pb = pictureBox1;

      drawRectangle.X = (int)Math.Round(100d);
      drawRectangle.Y = (int)Math.Round(0d);

      //画像を表示する
      pictureBox1.Invalidate();
    }

    #region 雛形メソッド
    public void template()
    {

    }
    #endregion

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {

      if (e.KeyCode == Keys.Up && e.Control)
      {
        // ズーム
        ZoomIn();
      }
      else if (e.KeyCode == Keys.Up)
      {
        // 
        Up();
      }

      if (e.KeyCode == Keys.Down && e.Control)
      {
        // ズームアウト
        ZoomOut();
      }
      else if (e.KeyCode == Keys.Down)
      {
        // 
        Down();
      }

      if (e.KeyCode == Keys.Right)
      {
        // 
        Right();
      }

      if (e.KeyCode == Keys.Left)
      {
        // 
        Left();
      }



      //switch (e.KeyData)
      //{
      //  case Keys.Up:
      //    // コントロールと同時押しの場合
      //    if (e.KeyData == Keys.Up && e.Control)
      //    {
      //      // ズーム
      //      ZoomIn();
      //      break;
      //    }

      //    break;
      //  case Keys.Down:
      //    if (e.Control)
      //    {
      //      // ズームアウト
      //      ZoomOut();
      //      break;
      //    }

      //    // 
      //    Down();
      //    break;
      //  case Keys.Right:
      //    break;
      //  case Keys.Left:
      //    break;
      //  default:
      //    break;
      //}
    }

  }
}
