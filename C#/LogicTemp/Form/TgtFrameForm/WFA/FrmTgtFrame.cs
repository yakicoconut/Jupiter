using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WFA
{
  /// <summary>
  /// 対象画面範囲取得フォーム
  /// </summary>
  public partial class FrmTgtFrame : Form
  {
    #region コンストラクタ
    public FrmTgtFrame()
    {
      InitializeComponent();
    }
    #endregion


    #region 宣言

    // 調整フォーム宣言
    FrmOption fmOption = new FrmOption();
    // プレビュフォーム宣言
    public FrmPreview fmPreview = new FrmPreview();

    // 不透明度退避
    double evacuateOpacity;

    // 親フォーム
    public Form1 form1 { get; set; }

    #endregion

    #region プロパティ

    /// <summary>
    /// 始点X座標
    /// </summary>
    public int LeftTopX { get; set; }

    /// <summary>
    /// 始点Y座標
    /// </summary>
    public int LeftTopY { get; set; }

    /// <summary>
    /// 終点X座標
    /// </summary>
    public int RightBottomX { get; set; }

    /// <summary>
    /// 終点Y座標
    /// </summary>
    public int RightBottomY { get; set; }

    /// <summary>
    /// テストポイントモードフラグ
    /// </summary>
    public bool isTestPointMode { get; set; }

    /// <summary>
    /// ズームフラグ
    /// </summary> 
    public bool isZoom { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmTgtFrame_Load(object sender, EventArgs e)
    {
      // オプションフォームのプロパティに本クラスを設定
      fmOption.frmTgtFrame = this;
      // 常にメインフォームの手前に表示
      fmOption.Owner = this;
      // フォーム2呼び出し
      fmOption.Show();

      // プレビュフォームのプロパティに本クラスを設定
      fmPreview.frmTgtFrame = this;
      // 常にメインフォームの手前に表示
      fmPreview.Owner = this;
      // プレビュフォーム呼び出し
      fmPreview.Show();
      // プレビュフォームは明示的に呼び出されるまで非表示
      fmPreview.Visible = false;

      // フォーム不透明度設定
      this.Opacity = 0.6;

      // タスクバーを覆って表示
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      // タスクバー表示
      this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);

      LeftTopX = 2;
      LeftTopY = 2;
      RightBottomX = 10;
      RightBottomY = 10;

      // ラジオボタンに座標を表示
      fmOption.rbLeftTop.Text = LeftTopX.ToString() + "×" + LeftTopY.ToString();
      fmOption.rbRightBottom.Text = RightBottomX.ToString() + "×" + RightBottomY.ToString();
      // 水平距離
      fmOption.lbHorizonDist.Text = Math.Abs(RightBottomX - LeftTopX).ToString();
      // 垂直距離
      fmOption.lbVerticalDist.Text = Math.Abs(RightBottomY - LeftTopY).ToString();
    }
    #endregion

    #region ロームショウイベント
    private void FrmTgtFrame_Shown(object sender, EventArgs e)
    {
      // 対象正方形描画メソッド使用
      DrawSquare();
    }
    #endregion

    #region マウスダブルクリックイベント
    private void FrmTgtFrame_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // 座標取得メソッド使用
      GetPosition();
    }
    #endregion


    #region 座標取得メソッド
    /// <summary>
    /// 座標取得メソッド
    /// </summary>
    private void GetPosition()
    {
      // クリック位置の座標取得
      int x = Cursor.Position.X;
      int y = Cursor.Position.Y;

      // テストポイントモードの場合
      if (isTestPointMode)
      {
        // ポイントテスト描画メソッド使用
        DrawPointTest(x, y);

        // テストポイント座標を表示
        fmOption.lbTestPoint.Text = x.ToString() + "×" + y.ToString();

        return;
      }

      // ラジオボタンで始点か終点を判断
      if (fmOption.rbLeftTop.Checked)
      {
        // プロパティ設定
        LeftTopX = x;
        LeftTopY = y;

        // ラジオボタンに始点座標を表示
        fmOption.rbLeftTop.Text = x.ToString() + "×" + y.ToString();

        // 右下ラジオボタンにチェック
        fmOption.rbRightBottom.Checked = true;
      }
      else if (fmOption.rbRightBottom.Checked)
      {
        RightBottomX = x;
        RightBottomY = y;

        fmOption.rbRightBottom.Text = x.ToString() + "×" + y.ToString();

        fmOption.rbLeftTop.Checked = true;

        // 終点のみの処理
        // 対象正方形描画メソッド使用
        DrawSquare();
        // 水平距離
        fmOption.lbHorizonDist.Text = Math.Abs(RightBottomX - LeftTopX).ToString();
        // 垂直距離
        fmOption.lbVerticalDist.Text = Math.Abs(RightBottomY - LeftTopY).ToString();

        // プレビュフォームが表示されている場合
        if (fmPreview.Visible)
        {
          // 画面コピー
          Bitmap btm = CopyScreen(new Point(LeftTopX, LeftTopY), new Point(RightBottomX, RightBottomY));

          // ズーム倍率初期値
          int widthZoomRatio = 1;
          int heightZoomRatio = 1;

          // ズームフラグ
          if (isZoom)
          {
            // ズーム倍率設定
            widthZoomRatio = 2;
            heightZoomRatio = 2;
          }

          // 画面表示
          fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
        }
      }

      return;
    }
    #endregion

    #region ポイントテスト描画メソッド
    /// <summary>
    /// ポイントテスト描画メソッド
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    private void DrawPointTest(int x, int y)
    {
      // 対象点作成
      Point targetPoint = new Point(x, y);

      // Graphicsオブジェクトの作成
      using (Graphics g = this.CreateGraphics())
      {
        // 白点画像を作成
        Bitmap p = new Bitmap(1, 1);
        p.SetPixel(0, 0, Color.White);

        // 点描画
        g.DrawImageUnscaled(p, targetPoint);

        return;
      }
    }
    #endregion

    #region 対象正方形描画メソッド
    /// <summary>
    /// 対象正方形描画メソッド
    /// </summary>
    public void DrawSquare()
    {
      // Graphicsオブジェクトの作成
      using (Graphics g = this.CreateGraphics())
      {
        // 色を初期化
        g.Clear(SystemColors.Control);

        // 直線型のインスタンス生成
        Pen frontCoverPen = new Pen(Color.Green, 1);

        // 表紙lineの始点と終点を設定
        Point leftTop = new Point(LeftTopX, LeftTopY);
        Point rightButtom = new Point(RightBottomX, RightBottomY);
        // 右上と左下は始点と終点の値をそのまま使用できる
        Point rightTop = new Point(RightBottomX, LeftTopY);
        Point leftButtom = new Point(LeftTopX, RightBottomY);

        // 正方形描画
        g.DrawLine(frontCoverPen, leftTop, rightTop);
        g.DrawLine(frontCoverPen, leftTop, leftButtom);
        g.DrawLine(frontCoverPen, rightButtom, rightTop);
        g.DrawLine(frontCoverPen, rightButtom, leftButtom);
      }
    }
    #endregion

    #region スクリーンコピーメソッド
    /// <summary>
    /// スクリーンコピーメソッド
    /// </summary>
    public Bitmap CopyScreen(Point top, Point bottom)
    {
      // 対象ポイントからサイズを取得
      int width = bottom.X - top.X;
      int height = bottom.Y - top.Y;

      // ビットマップ作成
      Bitmap bmp = new Bitmap(width + 10, height + 10);

      // Graphicsオブジェクトの作成
      using (Graphics g = Graphics.FromImage(bmp))
      {
        // コンボボックス選択色変換メソッド使用
        g.Clear(SelectColorConversion());

        // 画像表示
        g.CopyFromScreen(top, new Point(5, 5), new Size(width, height));
      }
      
      return bmp;
    }
    #endregion

    #region コンボボックス選択色変換メソッド
    private Color SelectColorConversion()
    {
      // 初期値:緑
      Color selectColor = Color.Green;

      // コンボボックスの設定に依存した色を設定
      switch (fmOption.cbPreviewBackColor.Text)
      {
        case "Green":
          selectColor = Color.Green;
          break;
        case "Black":
          selectColor = Color.Black;
          break;
        case "White":
          selectColor = Color.White;
          break;
        case "Blue":
          selectColor = Color.Blue;
          break;

        default:
          break;
      }

      return selectColor;
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      // 不透明度が0.8以上なら
      if (this.Opacity >= 0.8)
      {
        // ※Graphicsで黒塗りつぶしをしていると
        //   不透明度を100%から下げたあとにとなぜか色が元に戻ってしまうため最大99%とする
        this.Opacity = 0.99;
        return;
      }

      // 不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度を下げる
      this.Opacity -= 0.2;

      // 不透明度が0.1以下なら
      if (this.Opacity <= 0.1)
      {
        // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
        this.Opacity = 0.01;
      }
    }
    #endregion

    #region コンテキスト_透明押下イベント
    private void ToolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
    }
    #endregion

    #region コンテキスト_タスクバー押下イベント
    private void ToolStripMenuItemTaskBar_Click(object sender, EventArgs e)
    {
      // タスクバー非表示の場合
      if (this.Bounds.Height == SystemInformation.WorkingArea.Height)
      {
        // タスクバー非表示
        this.Bounds = Screen.PrimaryScreen.Bounds;
      }
      else
      {
        // タスクバー表示
        this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);
      }
    }
    #endregion

    #region コンテキスト_ポイントテスト押下イベント
    private void ToolStripMenuItemPointTest_Click(object sender, EventArgs e)
    {
      // 標準色の場合
      if (isTestPointMode)
      {
        // 色を元に戻す
        using (Graphics g = this.CreateGraphics())
        {
          g.Clear(SystemColors.Control);
        }

        // テストポイント座標を初期化
        fmOption.lbTestPoint.Text = "";

        // 不透明度を戻す
        this.Opacity = evacuateOpacity;

        // 対象正方形描画メソッド使用
        DrawSquare();

        isTestPointMode = false;
      }
      else
      {
        // 色を黒にする
        using (Graphics g = this.CreateGraphics())
        {
          g.Clear(Color.Black);
        }

        // 不透明度退避
        evacuateOpacity = this.Opacity;
        // 不透明度を設定
        this.Opacity = 0.8;

        isTestPointMode = true;
      }
    }
    #endregion

    #region コンテキスト_プレビュ押下イベント
    private void ToolStripMenuItemPreview_Click(object sender, EventArgs e)
    {
      // スクリーンキャプチャメソッド使用
      fmPreview.pbPreview.Image = CopyScreen(new Point(LeftTopX, LeftTopY), new Point(RightBottomX, RightBottomY));

      // 表示する
      fmPreview.Visible = true;
    }
    #endregion

    #region コンテキスト_閉じる押下イベント
    private void toolStripMenuItemClose_Click(object sender, EventArgs e)
    {
      // フォーム閉じる
      this.Close();
    }
    #endregion
  }
}