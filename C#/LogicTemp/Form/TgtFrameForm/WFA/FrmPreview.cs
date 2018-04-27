using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace WFA
{
  /// <summary>
  /// プレビュフォーム
  /// </summary>
  public partial class FrmPreview : Form
  {
    #region コンストラクタ
    public FrmPreview()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "Preview";
    }
    #endregion

    #region 宣言

    // 親フォーム
    public FrmTgtFrame frmTgtFrame { get; set; }

    #endregion


    #region フォームロードイベント
    private void FrmPreview_Load(object sender, EventArgs e)
    {
      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion

    #region フォーム非表示変更イベント
    private void FrmPreview_VisibleChanged(object sender, EventArgs e)
    {
      // 非表示になった場合
      if (!this.Visible)
      {
        // ズームフラグを下ろす
        frmTgtFrame.isZoom = false;
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

    #region コンテキスト_キャプチャ押下イベント
    private void ToolStripMenuItemCapture_Click(object sender, EventArgs e)
    {
      // ファイル名用に現在時刻をミリ秒まで取得
      string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString("000");

      // 保存フォルダがない場合
      if (!Directory.Exists("CapReview"))
      {
        // フォルダ作成
        Directory.CreateDirectory("CapReview");
      }

      // 画像を保存
      pbPreview.Image.Save(string.Format(@"CapReview\{0}.png", fileName), ImageFormat.Png);
    }
    #endregion

    #region コンテキスト_拡大押下イベント
    private void ToolStripMenuItemZoomIn_Click(object sender, EventArgs e)
    {
      // ズーム済みの場合
      if (frmTgtFrame.isZoom)
      {
        // 追いズームはしない
        return;
      }

      // 拡大
      Bitmap zoomBmp = new Bitmap(pbPreview.Image, pbPreview.Image.Width * 2, pbPreview.Image.Height * 2);

      pbPreview.Image = zoomBmp;

      // ズームフラグを立てる
      frmTgtFrame.isZoom = true;
    }
    #endregion

    #region コンテキスト_縮小押下イベント
    private void ToolStripMenuItemZoomOut_Click(object sender, EventArgs e)
    {
      // ズームアウト済みの場合
      if (!frmTgtFrame.isZoom)
      {
        // 追いズームアウトはしない
        return;
      }

      // 縮小
      Bitmap zoomBmp = new Bitmap(pbPreview.Image, pbPreview.Image.Width / 2, pbPreview.Image.Height / 2);

      pbPreview.Image = zoomBmp;

      // ズームフラグを立てる
      frmTgtFrame.isZoom = false;
    }
    #endregion


    #region フォームクロージングイベント
    private void FrmPreview_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
      {
        e.Cancel = true;

        // 非表示
        this.Visible = false;
      }
    }
    #endregion
  }
}
