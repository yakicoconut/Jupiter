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

      // コンフィグ取得メソッド使用
      GetConfig();

      // コマンドライン引数取得
      string[] cmdArgs = Environment.GetCommandLineArgs();
      // 引数がある場合(自身のexeパスが1つ目なので2以上のとき)
      if (cmdArgs.Length >= 2)
      {
        // ドラッグ&ドロップされたファイルの一つ目を取得
        string dropItem = Environment.GetCommandLineArgs()[1];
        // ファイル読み込みメソッド使用
        ReadFile(dropItem);
      }
    }
    #endregion

    #region コンフィグ取得メソッド
    public void GetConfig()
    {
      // 初期フォーム位置
      defaultLocationX = int.Parse(ConfigurationManager.AppSettings["DefaultLocationX"]);
      defaultLocationY = int.Parse(ConfigurationManager.AppSettings["DefaultLocationY"]);
      // 初期フォームサイズ
      defaultWidth = int.Parse(ConfigurationManager.AppSettings["DefaultWidth"]);
      defaultHeight = int.Parse(ConfigurationManager.AppSettings["DefaultHeight"]);
      // 移動距離
      upMoveDistance = int.Parse(ConfigurationManager.AppSettings["UpMoveDistance"]);
      downMoveDistance = int.Parse(ConfigurationManager.AppSettings["DownMoveDistance"]);
      rightMoveDistance = int.Parse(ConfigurationManager.AppSettings["RightMoveDistance"]);
      leftMoveDistance = int.Parse(ConfigurationManager.AppSettings["LeftMoveDistance"]);
      // 倍率関連
      zoomInRatio = double.Parse(ConfigurationManager.AppSettings["ZoomInRatio"]);
      zoomOutRatio = double.Parse(ConfigurationManager.AppSettings["ZoomOutRatio"]);
      defaultZoomRatio = double.Parse(ConfigurationManager.AppSettings["DefaultZoomRatio"]);
      zoomZoomRatio = double.Parse(ConfigurationManager.AppSettings["ZoomZoomRatio"]);
    }
    #endregion

    #region 宣言

    //フォーム2インスタンス生成
    Form2 form2 = new Form2();

    // 表示する画像
    private Bitmap currentImage;
    // 初期表示ズーム倍率
    private double defaultZoomRatio = 1;
    // ズームイン倍率
    private double zoomInRatio = 1;
    // ズームアウト倍率
    private double zoomOutRatio = 1;
    // Shift押下時の倍率の倍率
    private double zoomZoomRatio = 2;
    // 倍率変更後の画像のサイズと位置
    private Rectangle drawRectangle;
    // 
    Dictionary<int, string> dicPath = new Dictionary<int, string>();

    //
    int defaultLocationX;
    int defaultLocationY;
    //
    int defaultWidth;
    int defaultHeight;
    //
    int upMoveDistance;
    int downMoveDistance;
    int rightMoveDistance;
    int leftMoveDistance;

    int currentImageWidth;
    int currentImageHeight;

    // 
    int pointX = 0;
    int pointY = 0;

    //
    int currentImageKey = 0;
    //
    int maxImageKey = 0;

    public bool ctrlCheck { get; set; }

    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      this.Location = new Point(defaultLocationX, defaultLocationY);
      this.Width = defaultWidth;
      this.Height = defaultHeight;

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

    #region キー押下イベント
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // 
      if (e.Control)
      {
        // 
        form2.cbIsFunctionCtrl.Checked = !form2.cbIsFunctionCtrl.Checked;
        return;
      }

      // 
      if (e.Shift)
      {
        // 
        form2.cbIsFunctionShift.Checked = !form2.cbIsFunctionShift.Checked;
        return;
      }

      // コントロール押下の場合
      if (form2.cbIsFunctionCtrl.Checked)
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
          pointY = pointY + upMoveDistance;
          break;
        case Keys.Down:
          // 下に移動
          pointX = pointX + 0;
          pointY = pointY - downMoveDistance;
          break;
        case Keys.Right:
          // 右に移動
          pointX = pointX - rightMoveDistance;
          pointY = pointY + 0;
          break;
        case Keys.Left:
          // 左に移動
          pointX = pointX + leftMoveDistance;
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


    #region ファイル読み込みメソッド
    private void ReadFile(string dropItem)
    {
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

      // 画像初期化メソッド使用
      InitImade();
    }
    #endregion

    #region 画像初期化メソッド
    private void InitImade()
    {
      // 
      double initZoomRatio;

      // コントロール押下の場合
      if (form2.cbIsFunctionShift.Checked)
      {
        initZoomRatio = zoomZoomRatio;
      }
      else
      {
        initZoomRatio = defaultZoomRatio;
      }

      // 
      currentImage = new Bitmap(dicPath[currentImageKey]);

      // 
      currentImageWidth = (int)Math.Round(currentImage.Width * initZoomRatio);
      currentImageHeight = (int)Math.Round(currentImage.Height * initZoomRatio);

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
