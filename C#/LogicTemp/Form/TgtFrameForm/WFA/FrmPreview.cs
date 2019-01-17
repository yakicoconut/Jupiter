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

/*
 * ・複数のクラスから呼び出すためインスタンスの生成は
 *   シングルトンデザインパターンを使用する
 */
namespace WFA
{
  /// <summary>
  /// プレビュフォーム
  /// </summary>
  public partial class FrmPreview : Form
  {
    #region シングルトンパターン

    // シングルトン用インスタンス生成
    private static FrmPreview instance = new FrmPreview();

    /// <summary>
    /// シングルトンインスタンス引継メソッド
    /// </summary>
    /// <returns></returns>
    public static FrmPreview GetInstance()
    {
      return instance;
    }

    #endregion

    #region コンストラクタ
    private FrmPreview()
    {
      InitializeComponent();

      // タイトル設定
      this.Text = "Preview";
    }
    #endregion


    #region 宣言

    // 値連携クラスインスタンス取得
    TgtFrameLogic tgtFrameLogic = TgtFrameLogic.GetInstance();

    #endregion


    /* イベント */
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


    /* コンテキスト */
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
      // 保存フォルダがない場合
      if (!Directory.Exists(tgtFrameLogic.CaptureDirName))
      {
        // フォルダ作成
        Directory.CreateDirectory(tgtFrameLogic.CaptureDirName);
      }

      // ファイル名用に現在時刻をミリ秒まで取得
      string fileEx = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString("000") + "." + ImageFormat.Png.ToString().ToLower();

      // 画像を保存
      pbPreview.Image.Save(tgtFrameLogic.CaptureFileName + fileEx, ImageFormat.Png);
    }
    #endregion

    #region コンテキスト_拡大/縮小押下イベント
    private void ToolStripMenuItemZoom_Click(object sender, EventArgs e)
    {
      // 倍率を初期化
      tgtFrameLogic.ZoomRatio = 1.00;

      // ピクチャボックス画像更新メソッド使用
      UpdPicBoxImg();
    }
    #endregion

    #region コンテキスト_拡大押下イベント
    private void ToolStripMenuItemZoomIn_Click(object sender, EventArgs e)
    {
      // 拡大倍率を増加
      tgtFrameLogic.ZoomRatio += 0.25;

      // ピクチャボックス画像更新メソッド使用
      UpdPicBoxImg();
    }
    #endregion

    #region コンテキスト_縮小押下イベント
    private void ToolStripMenuItemZoomOut_Click(object sender, EventArgs e)
    {
      // 拡大倍率を増加
      tgtFrameLogic.ZoomRatio -= 0.25;
      if (tgtFrameLogic.ZoomRatio <= 0)
      {
        // 最小値は0.25
        tgtFrameLogic.ZoomRatio = 0.25;
      }

      // ピクチャボックス画像更新メソッド使用
      UpdPicBoxImg();
    }
    #endregion


    /* パブリックメソッド */
    #region ピクチャボックス画像更新メソッド
    /// <summary>
    /// ピクチャボックス画像更新メソッド
    /// </summary>
    public void UpdPicBoxImg()
    {
      // スクリーンコピーメソッド使用
      Bitmap btm = tgtFrameLogic.CopyScreen();

      // 画像表示
      pbPreview.Image = new Bitmap(btm, (int)Math.Round(btm.Width * tgtFrameLogic.ZoomRatio, 2), (int)Math.Round(btm.Height * tgtFrameLogic.ZoomRatio, 2));
    }
    #endregion
  }
}
