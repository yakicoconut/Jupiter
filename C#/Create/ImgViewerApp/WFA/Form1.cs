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
      // 倍率関連
      zoomInRatio = double.Parse(ConfigurationManager.AppSettings["ZoomInRatio"]);
      zoomOutRatio = double.Parse(ConfigurationManager.AppSettings["ZoomOutRatio"]);
      defaultZoomRatio = double.Parse(ConfigurationManager.AppSettings["DefaultZoomRatio"]);
      //
      functionKey = ConfigurationManager.AppSettings["FunctionKey"].ToLower();
    }
    #endregion

    #region 宣言

    // 表示する画像
    private Bitmap currentImage;
    // 初期表示ズーム倍率
    private double defaultZoomRatio = 1;
    // ズームイン倍率
    private double zoomInRatio = 1;
    // ズームアウト倍率
    private double zoomOutRatio = 1;
    // 倍率変更後の画像のサイズと位置
    private Rectangle drawRectangle;
    // 
    Dictionary<int, string> dicPath = new Dictionary<int, string>();
    // 
    string functionKey;

    int currentImageWidth;
    int currentImageHeight;

    // 
    int pointX = 0;
    int pointY = 0;

    //
    int currentImageKey = 0;
    //
    int maxImageKey = 0;

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
      //ドラッグ&ドロップされたファイルの一つ目を取得
      string dropItem = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
      string targetDirPath = string.Empty;

      // フォルダの場合
      if (Directory.Exists(dropItem))
      {
        // 
        targetDirPath = dropItem;
      }
      else
      {
        // 
        targetDirPath = System.IO.Path.GetDirectoryName(dropItem);
      }

      //
      string[] files = Directory.GetFiles(targetDirPath, "*", SearchOption.AllDirectories);
      // 大文字小文字を区別しない序数比較で並び替える
      StringComparer cmp = StringComparer.OrdinalIgnoreCase;
      Array.Sort(files, cmp);

      // 
      int i = 0;
      foreach (string x in files)
      {
        i = i + 1;
        dicPath.Add(i, x);
      }
      //
      maxImageKey = files.Length;

      // 表示する画像を読み込む
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

      // フォルダの場合
      if (Directory.Exists(dropItem))
      {
        //
        currentImageKey = 1;
      }
      else
      {
        //
        currentImageKey = dicPath.First(x => x.Value == dropItem).Key;
      }

      //// 
      //currentImageKey = currentImageKey + 1;

      // 画像初期化メソッド使用
      InitImade();
    }
    #endregion

    #endregion

    #region キー押下イベント
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // 
      bool isFunctionOn = false;
      switch (functionKey)
      {
        case "ctrl":
          isFunctionOn = e.Control;
          break;
        case "shift":
          isFunctionOn = e.Shift;
          break;

        default:
          break;
      }

      // コントロール押下の場合
      if (isFunctionOn)
      {
        // Ctrl + ↑
        if (e.KeyCode == Keys.Up)
        {
          // 
          currentImageWidth = (int)Math.Round(currentImageWidth * zoomInRatio);
          currentImageHeight = (int)Math.Round(currentImageHeight * zoomInRatio);
        }

        // Ctrl + ↓
        if (e.KeyCode == Keys.Down)
        {
          // 
          currentImageWidth = (int)Math.Round(currentImageWidth * zoomOutRatio);
          currentImageHeight = (int)Math.Round(currentImageHeight * zoomOutRatio);
        }

        // ズームメソッドの実行有無
        if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
        {
          // ズーム
          Zoom(currentImageWidth, currentImageHeight);
        }

        // Ctrl + →
        if (e.KeyCode == Keys.Right)
        {
          // 
          if (currentImageKey == maxImageKey)
          {
            currentImageKey = 1;
          }
          else
          {
            // 
            currentImageKey = currentImageKey + 1;
          }

          // 画像初期化メソッド使用
          InitImade();

          //
          pointX = 0;
          pointY = 0;
        }

        // Ctrl + ←
        if (e.KeyCode == Keys.Left)
        {
          // 
          if (currentImageKey == 1)
          {
            currentImageKey = maxImageKey;
          }
          else
          {
            // 
            currentImageKey = currentImageKey - 1;
          }

          // 画像初期化メソッド使用
          InitImade();

          //
          pointX = 0;
          pointY = 0;
        }

        return;
      }

      // 押下キー振り分け
      switch (e.KeyCode)
      {
        case Keys.Up:
          // 上に移動
          pointX = pointX + 0;
          pointY = pointY + 100;
          break;
        case Keys.Down:
          // 下に移動
          pointX = pointX + 0;
          pointY = pointY - 100;
          break;
        case Keys.Right:
          // 右に移動
          pointX = pointX - 100;
          pointY = pointY + 0;
          break;
        case Keys.Left:
          // 左に移動
          pointX = pointX + 100;
          pointY = pointY + 0;
          break;
        default:
          break;
      }

      // 移動メソッド
      MoveImg(pointX, pointY);

      //switch (e.KeyData)
      //{
      //  case Keys.Up:
      //    // コントロールと同時押しの場合
      //    if (e.KeyData == Keys.Up && e.Control)
      //      break;
      //}
    }
    #endregion


    #region 画像初期化メソッド
    private void InitImade()
    {
      // 
      currentImage = new Bitmap(dicPath[currentImageKey]);

      // 
      currentImageWidth = (int)Math.Round(currentImage.Width * defaultZoomRatio);
      currentImageHeight = (int)Math.Round(currentImage.Height * defaultZoomRatio);

      //初期化
      drawRectangle = new Rectangle(0, 0, currentImageWidth, currentImageHeight);

      //画像を表示する
      pictureBox1.Invalidate();
    }
    #endregion

    #region ズームメソッド
    private void Zoom(int currentImageWudth, int currentImageHeight)
    {
      PictureBox pb = pictureBox1;

      // 倍率変更後の画像のサイズと位置を計算する
      drawRectangle.Width = currentImageWudth;
      drawRectangle.Height = currentImageHeight;
      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(0d);

      // 移動位置をリセット
      pointX = 0;
      pointY = 0;

      //画像を表示する
      pictureBox1.Invalidate();
    }
    #endregion

    #region 移動メソッド
    private void MoveImg(int pointX, int pointY)
    {
      PictureBox pb = pictureBox1;

      drawRectangle.X = pointX;
      drawRectangle.Y = pointY;

      //画像を表示する
      pictureBox1.Invalidate();
    }
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


    #region 雛形メソッド
    public void template()
    {

    }
    #endregion
  }
}
