using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Imaging;

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

    // 値連携クラスインスタンス取得
    TgtFrameLogic tgtFrameLogic = TgtFrameLogic.GetInstance();

    // プレビュフォームインスタンス取得
    FrmPreview fmPreview = FrmPreview.GetInstance();

    // 調整フォーム宣言
    FrmOption fmOption = new FrmOption();

    // 不透明度退避
    double evacuateOpacity;

    #endregion


    /* イベント */
    #region フォームロードイベント
    private void FrmTgtFrame_Load(object sender, EventArgs e)
    {
      // 不透明度
      this.Opacity = tgtFrameLogic.TgtFrameOpacity;
      // 対象正方形色
      tgtFrameLogic.SquareColor = Color.Green;

      // オプションフォームのプロパティに本クラスを設定
      fmOption.frmTgtFrame = this;
      // 常にメインフォームの手前に表示
      fmOption.Owner = this;
      // オプションフォーム呼び出し
      fmOption.Show();

      // 常にメインフォームの手前に表示
      fmPreview.Owner = this;
      // プレビュフォーム呼び出し
      fmPreview.Show();
      // プレビュフォームは明示的に呼び出されるまで非表示
      fmPreview.Visible = false;

      // タスクバーを覆って表示
      this.WindowState = FormWindowState.Normal;
      this.FormBorderStyle = FormBorderStyle.None;
      // タスクバー表示
      this.Bounds = new Rectangle(0, 0, SystemInformation.PrimaryMonitorSize.Width, SystemInformation.WorkingArea.Height);

      /* 共有プロパティ初期設定 */
      // 境界色
      tgtFrameLogic.BoundaryColor = Color.Green;
      // キャプチャ画像拡張子
      tgtFrameLogic.CapImgEx = ImageFormat.Png;
    }
    #endregion

    #region フォームショウイベント
    private void FrmTgtFrame_Shown(object sender, EventArgs e)
    {
      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(this);
    }
    #endregion

    #region マウスダブルクリックイベント
    private void FrmTgtFrame_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      // クリック座標取得
      int x = Cursor.Position.X;
      int y = Cursor.Position.Y;

      // ねずみ返し_テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        // テストポイントに設定
        tgtFrameLogic.TestPoint = new Point(x, y);
        // ポイントテスト描画メソッド使用
        tgtFrameLogic.DrawTestPoint(this);

        // テストポイントラベル更新メソッド使用
        fmOption.UpdTestPointLblTxt();

        return;
      }

      // 座標取得メソッド使用
      GetPosition(x, y);
    }
    #endregion


    /* コンテキスト */
    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
      // ピクチャボックス画像更新メソッド使用
      fmPreview.UpdPicBoxImg();
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
      }
      else
      {
        // 不透明度を上げる
        this.Opacity += 0.2;
      }

      // ピクチャボックス画像更新メソッド使用
      fmPreview.UpdPicBoxImg();
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      // 不透明度が0.2以下なら
      if (this.Opacity <= 0.2)
      {
        // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
        this.Opacity = 0.01;
      }
      else
      {
        // 不透明度を下げる
        this.Opacity -= 0.2;
      }

      // ピクチャボックス画像更新メソッド使用
      fmPreview.UpdPicBoxImg();
    }
    #endregion

    #region コンテキスト_透明押下イベント
    private void ToolStripMenuItemOpacityTransparent_Click(object sender, EventArgs e)
    {
      // 不透明度を0%にするとフォームが非表示扱いとなってしまうため
      this.Opacity = 0.01;
      // ピクチャボックス画像更新メソッド使用
      fmPreview.UpdPicBoxImg();
    }
    #endregion

    #region コンテキスト_正方形色_緑
    private void ToolStripMenuItemSquareGreen_Click(object sender, EventArgs e)
    {
      // 対象正方形色
      tgtFrameLogic.SquareColor = Color.Green;

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(this);
    }
    #endregion

    #region コンテキスト_正方形色_黒
    private void ToolStripMenuItemSquareBlack_Click(object sender, EventArgs e)
    {
      tgtFrameLogic.SquareColor = Color.Black;
      tgtFrameLogic.DrawSquare(this);
    }
    #endregion

    #region コンテキスト_正方形色_白
    private void ToolStripMenuItemSquareWhite_Click(object sender, EventArgs e)
    {
      tgtFrameLogic.SquareColor = Color.White;
      tgtFrameLogic.DrawSquare(this);
    }
    #endregion

    #region コンテキスト_正方形色_青
    private void ToolStripMenuItemSquareBlue_Click(object sender, EventArgs e)
    {
      tgtFrameLogic.SquareColor = Color.Blue;
      tgtFrameLogic.DrawSquare(this);
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
      // テストポイントモードの場合
      if (tgtFrameLogic.IsTestPointMode)
      {
        // 色を元に戻す
        using (Graphics g = this.CreateGraphics())
        {
          g.Clear(SystemColors.Control);
        }

        // 不透明度を戻す
        this.Opacity = evacuateOpacity;

        // 対象正方形描画メソッド使用
        tgtFrameLogic.DrawSquare(this);

        // フラグを折る
        tgtFrameLogic.IsTestPointMode = false;

        // テストポイントラベル更新メソッド使用
        fmOption.UpdTestPointLblTxt();

        return;
      }

      // 色を黒にする
      using (Graphics g = this.CreateGraphics())
      {
        g.Clear(Color.Black);
      }

      // 不透明度退避
      evacuateOpacity = this.Opacity;
      // 不透明度を設定
      this.Opacity = 0.8;

      // フラグを立てる
      tgtFrameLogic.IsTestPointMode = true;
    }
    #endregion

    #region コンテキスト_プレビュ押下イベント
    private void ToolStripMenuItemPreview_Click(object sender, EventArgs e)
    {
      // ピクチャボックス画像更新メソッド使用
      fmPreview.UpdPicBoxImg();

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


    /* プライベートメソッド */
    #region 座標取得メソッド
    /// <summary>
    /// 座標取得メソッド
    /// </summary>
    private void GetPosition(int x, int y)
    {
      // ねずみ返し_始点判断フラグ
      if (tgtFrameLogic.IsChkLeftTop)
      {
        // 始点プロパティ設定
        tgtFrameLogic.LeftTopX = x;
        tgtFrameLogic.LeftTopY = y;

        // ラジオボタン内容更新メソッド使用
        fmOption.UpdRdioBtnTxt();
        // ラジオボタンチェック更新メソッド使用
        fmOption.UpdRdioBtnChk();

        return;
      }

      // 終点プロパティ設定
      tgtFrameLogic.RightBottomX = x;
      tgtFrameLogic.RightBottomY = y;

      // ラジオボタン内容更新メソッド使用
      fmOption.UpdRdioBtnTxt();
      // ラジオボタンチェック更新メソッド使用
      fmOption.UpdRdioBtnChk();

      // 距離ラベル更新メソッド使用
      fmOption.UpdDistLblTxt();

      // 対象正方形描画メソッド使用
      tgtFrameLogic.DrawSquare(this);

      // プレビュフォームが表示されている場合
      if (fmPreview.Visible)
      {
        // ピクチャボックス画像更新メソッド使用
        fmPreview.UpdPicBoxImg();
      }
    }
    #endregion
  }
}