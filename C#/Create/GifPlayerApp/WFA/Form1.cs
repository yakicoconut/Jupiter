//#define DEBUG02
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
using System.Threading;

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
      // サイズ
      widthZoom = double.Parse(_comLogic.GetConfigValue("WidthZoom", "1"));
      heightZoom = double.Parse(_comLogic.GetConfigValue("HeightZoom", "1"));
      widthZoomRatio = double.Parse(_comLogic.GetConfigValue("WidthZoomRatio", "0.2"));
      heightZoomRatio = double.Parse(_comLogic.GetConfigValue("HeightZoomRatio", "0.2"));
      widthReductRatio = double.Parse(_comLogic.GetConfigValue("WidthReductRatio", "0.25"));
      heightReductRatio = double.Parse(_comLogic.GetConfigValue("HeightReductRatio", "0.25"));
      // デフォルト縦サイズ(横は比率に従う)
      defHightSize = double.Parse(_comLogic.GetConfigValue("DefHightSize", "500"));
    }
    #endregion


    #region 宣言

    // 共通ロジッククラスインスタンス
    MCSComLogic _comLogic = new MCSComLogic();

    // 対象画像Bitmap
    Bitmap animatedImage;

    // スローモーション間隔
    int slowmotionTime;
    // サイズ
    double widthZoom;
    double heightZoom;
    double widthZoomRatio;
    double heightZoomRatio;
    double widthReductRatio;
    double heightReductRatio;
    // デフォルト縦サイズ(横は比率に従う)
    double defHightSize;

    #endregion


    #region フォームロードイベント
    private void Form1_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region フォームドラッグエンターイベント
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      // ファイルの場合
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
        // コピー
        e.Effect = DragDropEffects.Copy;
      else
        // ファイル以外は受け付けない
        e.Effect = DragDropEffects.None;
    }
    #endregion

    #region フォームドラッグドロップイベント
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      // ファイル名取得
      string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

      // ねずみ返し_ファイルが存在しない場合
      if (!File.Exists(fileName[0]))
      {
        return;
      }
      // ねずみ返し_ファイル拡張子がGifでない場合
      if (Path.GetExtension(fileName[0]).ToLower() == "gif")
      {
        return;
      }

      // ピクチャボックス初期化
      pbGifPlayer.Image = null;

      // 画像読み込み
      animatedImage = new Bitmap(fileName[0]);

      // デフォサイズチェックボックス
      if (cbDefSize.Checked)
      {
        // 画像比率算出(縦のサイズに対する横の比率)
        double targetRatio = (double)animatedImage.Width / (double)animatedImage.Height;
        // デフォルト縦サイズに合わせる
        heightZoom = defHightSize / animatedImage.Height;
        widthZoom = heightZoom * targetRatio;
      }

      // アニメ開始
      ImageAnimator.Animate(animatedImage, new EventHandler(Image_FrameChanged));
    }
    #endregion


    #region 開始ボタン押下イベント
    private void btStart_Click(object sender, EventArgs e)
    {
      // アニメ開始
      ImageAnimator.Animate(animatedImage, new EventHandler(this.Image_FrameChanged));
    }
    #endregion

    #region 停止ボタン押下イベント
    private void btStop_Click(object sender, EventArgs e)
    {
      // アニメ停止
      ImageAnimator.StopAnimate(animatedImage, new EventHandler(this.Image_FrameChanged));
    }
    #endregion

    #region スローモーション間隔数値ボックス変更イベント
    private void nupSlowInterval_ValueChanged(object sender, EventArgs e)
    {
      // スローモーション間隔設定
      slowmotionTime = (int)nupSlowInterval.Value;
    }
    #endregion


    #region ピクチャボックスWクリックイベント
    private void pbGifPlayer_DoubleClick(object sender, EventArgs e)
    {
      // ピクチャボックスサイズを取得
      Size ctrlSize = pbGifPlayer.Size;
      // ピクチャボックス上のクリック位置取得
      Point clickPosition = pbGifPlayer.PointToClient(MousePosition);

      // 有効範囲クリック判断用変数
      bool upSideClick = false;
      bool downSideClick = false;
      bool rightSideClick = false;
      bool leftSideClick = false;

      // 有効範囲算出横五縦十メソッド使用
      EffectiveRangeFullTen(ctrlSize, clickPosition, out upSideClick, out downSideClick, out rightSideClick, out leftSideClick);

      // 有効範囲クリック判断
      if (upSideClick)
      {
        // 上操作メソッド使用
        UpSideOperation();
      }
      else if (downSideClick)
      {
        // 下操作メソッド使用
        DownSideOperation();
      }
      else if (rightSideClick)
      {

      }
      else if (leftSideClick)
      {

      }
    }
    #endregion

    #region 有効範囲算出横五縦十メソッド
    private void EffectiveRangeFiveTen(Size ctrlSize, Point clickPosition, out bool upSideClick, out bool downSideClick, out bool rightSideClick, out bool leftSideClick)
    {
      #region メモ
      /*
       *     1 2 3 4 5
       *  1 ┌┬┬┬┬┐
       *  2 ├┼┼┼┼┤
       *  3 ├┼┼┼┼┤
       *  4 ├┼┼┼┼┤←//ここから//
       *  5 ├┼┼┼┼┤    有効縦幅
       *  6 ├┼┼┼┼┤←//ここまで//
       *  7 ├┼┼┼┼┤
       *  8 ├┼┼┼┼┤
       *  9 ├┼┼┼┼┤
       * 10 └┴┴┴┴┘
       *         ↑
       *         有効横幅
       */
      #endregion

      // 横幅の有効横幅作成(四捨五入)
      int widthBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Width / 5));
      // 実際の有効横幅を作成
      int beginWidthBelt = 2 * widthBeltSize;
      int endWidthBelt = 3 * widthBeltSize;

      // 縦の有効縦幅作成(四捨五入)
      int heightBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Height / 10));
      // 実際の有効縦幅を作成
      int beginHeightBelt = 4 * heightBeltSize;
      int endHeightBelt = 6 * heightBeltSize;

      #region デバッグ02_クリック操作有効幅表示
#if DEBUG02
      // 描画先するImageオブジェクト作成
      Bitmap canvas = new Bitmap(pbGifPlayer.Width, pbGifPlayer.Height);
      // ImageオブジェクトのGraphicsオブジェクト作成
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 横幅の描写
        for (int i = 1; i < 5 + 1; i++)
        {
          g.DrawLine(Pens.Black, i * widthBeltSize, 0, i * widthBeltSize, ctrlSize.Height);
        }

        // 縦の描写
        for (int i = 1; i < 10 + 1; i++)
        {
          g.DrawLine(Pens.Black, 0, i * heightBeltSize, ctrlSize.Width, i * heightBeltSize);
        }

        // 中心線
        g.DrawLine(Pens.Green, 0, ctrlSize.Height / 2, ctrlSize.Width, ctrlSize.Height / 2);
        g.DrawLine(Pens.Green, ctrlSize.Width / 2, 0, ctrlSize.Width / 2, ctrlSize.Height);

        // 有効線横
        g.DrawLine(Pens.Blue, 0, 4 * heightBeltSize, ctrlSize.Width, 4 * heightBeltSize);
        g.DrawLine(Pens.Blue, 0, 6 * heightBeltSize, ctrlSize.Width, 6 * heightBeltSize);
        // 有効線縦
        g.DrawLine(Pens.Blue, 2 * widthBeltSize, 0, 2 * widthBeltSize, ctrlSize.Height);
        g.DrawLine(Pens.Blue, 3 * widthBeltSize, 0, 3 * widthBeltSize, ctrlSize.Height);
      }
      // 描画
      pbGifPlayer.Image = canvas;
#endif
      #endregion

      // 上側の有効縦幅判定
      upSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y <= beginHeightBelt;
      // 下側の有効縦幅判定
      downSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y >= endHeightBelt;
      // 右側の有効縦幅判定
      rightSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X >= endWidthBelt;
      // 左側の有効縦幅判定
      leftSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X <= beginWidthBelt;
    }
    #endregion

    #region 有効範囲算出横全縦十メソッド
    private void EffectiveRangeFullTen(Size ctrlSize, Point clickPosition, out bool upSideClick, out bool downSideClick, out bool rightSideClick, out bool leftSideClick)
    {
      #region メモ
      /*
       *  1 ┌────┐←//ここから//
       *  2 ├────┤    有効横幅
       *  3 ├────┤←//ここまで//
       *  4 ├────┤←//ここから//
       *  5 ├────┤    有効縦幅
       *  6 ├────┤←//ここまで//
       *  7 ├────┤←//ここから//
       *  8 ├────┤    有効横幅
       *  9 ├────┤    有効横幅
       * 10 └────┘←//ここまで//
       */
      #endregion

      //// 横幅の有効横幅作成(四捨五入)
      //int widthBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Width / 5));
      // 実際の有効横幅を作成
      int beginWidthBelt = 0;
      int endWidthBelt = ctrlSize.Width;

      // 縦の有効縦幅作成(四捨五入)
      int heightBeltSize = Convert.ToInt32(Math.Round((double)ctrlSize.Height / 10));
      // 実際の有効縦幅を作成
      int beginHeightBelt = 4 * heightBeltSize;
      int endHeightBelt = 6 * heightBeltSize;

      #region デバッグ02_クリック操作有効幅表示
#if DEBUG02
      // 描画先するImageオブジェクト作成
      Bitmap canvas = new Bitmap(pbGifPlayer.Width, pbGifPlayer.Height);
      // ImageオブジェクトのGraphicsオブジェクト作成
      using (Graphics g = Graphics.FromImage(canvas))
      {
        // 縦の描写
        for (int i = 1; i < 10 + 1; i++)
        {
          g.DrawLine(Pens.Black, 0, i * heightBeltSize, ctrlSize.Width, i * heightBeltSize);
        }

        // 中心線
        g.DrawLine(Pens.Green, 0, ctrlSize.Height / 2, ctrlSize.Width, ctrlSize.Height / 2);
        g.DrawLine(Pens.Green, ctrlSize.Width / 2, 0, ctrlSize.Width / 2, ctrlSize.Height);

        // 有効線横
        g.DrawLine(Pens.Blue, 0, 4 * heightBeltSize, ctrlSize.Width, 4 * heightBeltSize);
        g.DrawLine(Pens.Blue, 0, 6 * heightBeltSize, ctrlSize.Width, 6 * heightBeltSize);
        // 有効線縦は有効線横と同じになる
      }
      // 描画
      pbGifPlayer.Image = canvas;
#endif
      #endregion

      // 上側の有効縦幅判定
      upSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y <= beginHeightBelt;
      // 下側の有効縦幅判定
      downSideClick = clickPosition.X >= beginWidthBelt && clickPosition.X <= endWidthBelt && clickPosition.Y >= endHeightBelt;
      // 右側の有効縦幅判定
      rightSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X >= ctrlSize.Width / 2;
      // 左側の有効縦幅判定
      leftSideClick = clickPosition.Y >= beginHeightBelt && clickPosition.Y <= endHeightBelt && clickPosition.X <= ctrlSize.Width / 2;
    }
    #endregion

    #region 上操作メソッド
    public void UpSideOperation()
    {
      // 画像拡大
      widthZoom += widthZoomRatio;
      heightZoom += heightZoomRatio;

      // 画像初期化
      pbGifPlayer.Image = null;
    }
    #endregion

    #region 下操作メソッド
    public void DownSideOperation()
    {
      // 画像縮小
      widthZoom -= widthReductRatio;
      heightZoom -= heightReductRatio;

      // 画像初期化
      pbGifPlayer.Image = null;

      // 下げた結果が0の場合
      if (widthZoom <= 0 || heightZoom <= 0)
      {
        // 縮小値に合わせる
        widthZoom = widthReductRatio;
        heightZoom = heightReductRatio;
      }
    }
    #endregion


    #region 画像変更イベント
    private void Image_FrameChanged(object o, EventArgs e)
    {
      // スローモーション設定
      Thread.Sleep(slowmotionTime);

      try
      {
        // 次のフレームに更新
        ImageAnimator.UpdateFrames(animatedImage);

        // ピクチャボックス表示
        using (Graphics g = pbGifPlayer.CreateGraphics())
        {
          g.DrawImage(animatedImage, 0, 0, (float)(animatedImage.Width * widthZoom), (float)(animatedImage.Height * heightZoom));
        }
      }
      catch (Exception ex)
      {

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
