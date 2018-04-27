using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace WFA
{
  public partial class FrmOption : Form
  {
    #region コンストラクタ
    public FrmOption()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "Option";
    }
    #endregion


    #region 宣言

    // 親フォーム
    public FrmTgtFrame frmTgtFrame { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      // テストポイント座標を初期化
      lbTestPoint.Text = "";

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
      // 始点ラジオボックスにチェック
      rbLeftTop.Checked = true;

      #region 【未使用】Drawing.Colorの内容を全て設定
      //ArrayList ColorList = new ArrayList();
      //Type colorType = typeof(Color);
      //PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
      //foreach (PropertyInfo x in propInfoList)
      //{
      //  cbReviewBackColor.Items.Add(x.Name);
      //}
      #endregion

      // プレビュフォームバックグラウンドカラーコンボボックスのソース設定
      string[] colorList = { "Green", "Black", "White", "Blue" };
      cbPreviewBackColor.Items.AddRange(colorList);
      cbPreviewBackColor.SelectedIndex = 0;
    }
    #endregion

    #region ↑ボタン押下イベント
    private void btUp_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 上へ移動
        frmTgtFrame.LeftTopY -= (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomY -= (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を上へ縮小
        frmTgtFrame.RightBottomY -= (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();

      // プレビュフォームが表示されている場合
      if (frmTgtFrame.fmPreview.Visible)
      {
        // 画面コピー
        Bitmap btm = frmTgtFrame.CopyScreen(new Point(frmTgtFrame.LeftTopX, frmTgtFrame.LeftTopY), new Point(frmTgtFrame.RightBottomX, frmTgtFrame.RightBottomY));

        // ズーム倍率初期値
        int widthZoomRatio = 1;
        int heightZoomRatio = 1;

        // ズームフラグ
        if (frmTgtFrame.isZoom)
        {
          // ズーム倍率設定
          widthZoomRatio = 2;
          heightZoomRatio = 2;
        }

        // 画面表示
        frmTgtFrame.fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
      }
    }
    #endregion

    #region ↓ボタン押下イベント
    private void btDown_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 下へ移動
        frmTgtFrame.LeftTopY += (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomY += (int)nudMoveDist.Value;
      }
      else
      {
        // 底辺を下へ拡大
        frmTgtFrame.RightBottomY += (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();

      // プレビュフォームが表示されている場合
      if (frmTgtFrame.fmPreview.Visible)
      {
        // 画面コピー
        Bitmap btm = frmTgtFrame.CopyScreen(new Point(frmTgtFrame.LeftTopX, frmTgtFrame.LeftTopY), new Point(frmTgtFrame.RightBottomX, frmTgtFrame.RightBottomY));

        // ズーム倍率初期値
        int widthZoomRatio = 1;
        int heightZoomRatio = 1;

        // ズームフラグ
        if (frmTgtFrame.isZoom)
        {
          // ズーム倍率設定
          widthZoomRatio = 2;
          heightZoomRatio = 2;
        }

        // 画面表示
        frmTgtFrame.fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
      }
    }
    #endregion

    #region ←ボタン押下イベント
    private void btLeft_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 左へ移動
        frmTgtFrame.LeftTopX -= (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomX -= (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を左へ縮小
        frmTgtFrame.RightBottomX -= (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();

      // プレビュフォームが表示されている場合
      if (frmTgtFrame.fmPreview.Visible)
      {
        // 画面コピー
        Bitmap btm = frmTgtFrame.CopyScreen(new Point(frmTgtFrame.LeftTopX, frmTgtFrame.LeftTopY), new Point(frmTgtFrame.RightBottomX, frmTgtFrame.RightBottomY));

        // ズーム倍率初期値
        int widthZoomRatio = 1;
        int heightZoomRatio = 1;

        // ズームフラグ
        if (frmTgtFrame.isZoom)
        {
          // ズーム倍率設定
          widthZoomRatio = 2;
          heightZoomRatio = 2;
        }

        // 画面表示
        frmTgtFrame.fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
      }
    }
    #endregion

    #region →ボタン押下イベント
    private void btRight_Click(object sender, EventArgs e)
    {
      // ねずみ返し_テストポイントモードの場合
      if (frmTgtFrame.isTestPointMode)
      {
        return;
      }

      // 移動にチェックの場合
      if (cbIsMove.Checked)
      {
        // 右へ移動
        frmTgtFrame.LeftTopX += (int)nudMoveDist.Value;
        frmTgtFrame.RightBottomX += (int)nudMoveDist.Value;
      }
      else
      {
        // 右辺を右へ拡大
        frmTgtFrame.RightBottomX += (int)nudMoveDist.Value;
      }

      // 対象正方形描画メソッド使用
      frmTgtFrame.DrawSquare();

      // プレビュフォームが表示されている場合
      if (frmTgtFrame.fmPreview.Visible)
      {
        // 画面コピー
        Bitmap btm = frmTgtFrame.CopyScreen(new Point(frmTgtFrame.LeftTopX, frmTgtFrame.LeftTopY), new Point(frmTgtFrame.RightBottomX, frmTgtFrame.RightBottomY));

        // ズーム倍率初期値
        int widthZoomRatio = 1;
        int heightZoomRatio = 1;

        // ズームフラグ
        if (frmTgtFrame.isZoom)
        {
          // ズーム倍率設定
          widthZoomRatio = 2;
          heightZoomRatio = 2;
        }

        // 画面表示
        frmTgtFrame.fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
      }
    }
    #endregion

    #region プレビュバックカラーコンボボックス値変更イベント
    private void cbReviewBackColor_SelectedIndexChanged(object sender, EventArgs e)
    {
      // プレビュフォームが表示されている場合
      if (frmTgtFrame.fmPreview.Visible)
      {
        // 画面コピー
        Bitmap btm = frmTgtFrame.CopyScreen(new Point(frmTgtFrame.LeftTopX, frmTgtFrame.LeftTopY), new Point(frmTgtFrame.RightBottomX, frmTgtFrame.RightBottomY));

        // ズーム倍率初期値
        int widthZoomRatio = 1;
        int heightZoomRatio = 1;

        // ズームフラグ
        if (frmTgtFrame.isZoom)
        {
          // ズーム倍率設定
          widthZoomRatio = 2;
          heightZoomRatio = 2;
        }

        // 画面表示
        frmTgtFrame.fmPreview.pbPreview.Image = new Bitmap(btm, btm.Width * widthZoomRatio, btm.Height * heightZoomRatio);
      }
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


    #region フォームクロージングイベント
    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion
  }
}