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
    // 画像パスディクショナリ
    Dictionary<int, string> dicImgPath = new Dictionary<int, string>();

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

    // 移動用変数
    int movePointX = 0;
    int movePointY = 0;

    //
    int currentImageKey = 0;
    //
    int maxImageKey = 0;

    //
    int pictureBoxLocationX;
    int pictureBoxLocationY;

    public bool ctrlCheck { get; set; }

    #endregion


    #region ロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {
      // アプリの開始位置
      this.Location = new Point(defaultLocationX, defaultLocationY);
      // アプリの開始サイズ
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
      // コントロールの場合
      if (e.Control)
      {
        // チェック
        form2.cbIsFunctionCtrl.Checked = !form2.cbIsFunctionCtrl.Checked;
        return;
      }

      // シフトの場合
      if (e.Shift)
      {
        form2.cbIsFunctionShift.Checked = !form2.cbIsFunctionShift.Checked;
        return;
      }

      // 押下キー振り分け
      switch (e.KeyCode)
      {
        #region ↑
        case Keys.Up:
          // シフトチェックの場合
          if (form2.cbIsFunctionShift.Checked)
          {
            // ズーム値設定
            currentImageWidth = (int)Math.Round(currentImageWidth * zoomInRatio);
            currentImageHeight = (int)Math.Round(currentImageHeight * zoomInRatio);

            // 画像ズームメソッド使用
            ImgZoom(currentImageWidth, currentImageHeight);
          }
          else
          {
            // 上に移動
            movePointX = movePointX + 0;
            movePointY = movePointY + upMoveDistance;

            // 移動メソッド使用
            MoveImg(movePointX, movePointY);
          }
          break;
        #endregion

        #region ↓
        case Keys.Down:
          // シフトチェックの場合
          if (form2.cbIsFunctionShift.Checked)
          {
            currentImageWidth = (int)Math.Round(currentImageWidth * zoomOutRatio);
            currentImageHeight = (int)Math.Round(currentImageHeight * zoomOutRatio);

            ImgZoom(currentImageWidth, currentImageHeight);
          }
          else
          {
            // 下に移動
            movePointX = movePointX + 0;
            movePointY = movePointY - downMoveDistance;

            MoveImg(movePointX, movePointY);
          }
          break;
        #endregion

        #region →
        case Keys.Right:
          // コントロールチェックの場合
          if (form2.cbIsFunctionCtrl.Checked)
          {
            // 現ページが最後の場合
            if (currentImageKey == maxImageKey)
            {
              // 最初のページへ
              currentImageKey = 1;
            }
            else
            {
              // 次のページへ
              currentImageKey = currentImageKey + 1;
            }

            // 表示画像取得
            currentImage = new Bitmap(dicImgPath[currentImageKey]);
            // 画像サイズ設定
            currentImageWidth = currentImage.Width;
            currentImageHeight = currentImage.Height;

            // 画像初期化メソッド使用
            InitImg(currentImage);
            //// 移動用の変数も初期化
            //movePointX = 0;
            //movePointY = 0;
          }
          else
          {
            // 右に移動
            movePointX = movePointX - rightMoveDistance;
            movePointY = movePointY + 0;

            MoveImg(movePointX, movePointY);
          }
          break;
        #endregion

        #region ←
        case Keys.Left:
          // コントロールチェックの場合
          if (form2.cbIsFunctionCtrl.Checked)
          {
            // 現ページが最初の場合
            if (currentImageKey == 1)
            {
              currentImageKey = maxImageKey;
            }
            else
            {
              // 左のページへ
              currentImageKey = currentImageKey - 1;
            }

            currentImage = new Bitmap(dicImgPath[currentImageKey]);
            currentImageWidth = currentImage.Width;
            currentImageHeight = currentImage.Height;

            InitImg(currentImage);
            movePointX = 0;
            movePointY = 0;
          }
          else
          {
            // 左に移動
            movePointX = movePointX + leftMoveDistance;
            movePointY = movePointY + 0;

            MoveImg(movePointX, movePointY);
          }
          break;
        #endregion

        default:
          break;
      }

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
        // ドロップされたアイテムをそのまま使用
        targetDirPath = dropItem;
      }
      else
      {
        // ドロップされたアイテムからフォルダを取得
        targetDirPath = System.IO.Path.GetDirectoryName(dropItem);
      }

      // 対象フォルダの中身をすべて取得
      string[] files = Directory.GetFiles(targetDirPath, "*", SearchOption.AllDirectories);
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

      // 表示する画像を読み込む
      if (currentImage != null)
      {
        currentImage.Dispose();
      }

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

      // 表示画像取得
      currentImage = new Bitmap(dicImgPath[currentImageKey]);
      // 画像サイズ設定
      currentImageWidth = currentImage.Width;
      currentImageHeight = currentImage.Height;

      // 画像初期化メソッド使用
      InitImg(currentImage);
    }
    #endregion

    #region 画像初期化メソッド
    private void InitImg(Bitmap currentImage)
    {
      // 初期化
      drawRectangle = new Rectangle(0, 0, currentImageWidth, currentImageHeight);
      // 画像を表示する
      pictureBox1.Invalidate();
    }
    #endregion

    #region 画像ズームメソッド
    private void ImgZoom(int currentImageWudth, int currentImageHeight)
    {
      PictureBox pb = pictureBox1;

      // 倍率変更後の画像のサイズと位置を計算する
      drawRectangle.Width = currentImageWudth;
      drawRectangle.Height = currentImageHeight;
      drawRectangle.X = (int)Math.Round(0d);
      drawRectangle.Y = (int)Math.Round(0d);

      // 移動位置をリセット
      movePointX = 0;
      movePointY = 0;

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
