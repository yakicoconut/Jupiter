using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFA
{
  /// <summary>
  /// パターンコメントフォーム
  /// </summary>
  public partial class FrmPtCmt : Form
  {
    #region コンストラクタ
    public FrmPtCmt(FrmMain _frmMain)
    {
      InitializeComponent();

      // 親フォーム設定
      frmMain = _frmMain;
    }
    #endregion


    #region 宣言

    // 親フォーム
    private FrmMain frmMain;

    #endregion


    #region フォームロードイベント
    private void FrmPtCmt_Load(object sender, EventArgs e)
    {
      this.Text = "コメント";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = frmMain.Location.X;
      int parentY = frmMain.Location.Y;
      int parentH = frmMain.Height;
      int parentW = frmMain.Width;
      // 縦幅は85(三行分)固定
      this.Size = new Size(parentW, 95);
      this.Location = new Point(parentX, parentY + parentH);

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion


    #region コンテキスト_透明度押下イベント
    private void toolStripMenuItemTra_Click(object sender, EventArgs e)
    {
      // デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_透明度_上げる押下イベント
    private void toolStripMenuItemTraGain_Click(object sender, EventArgs e)
    {
      // より透明にする
      this.Opacity -= 0.2;
    }
    #endregion

    #region コンテキスト_透明度_下げる押下イベント
    private void toolStripMenuItemTraDec_Click(object sender, EventArgs e)
    {
      // より不透明にする
      this.Opacity += 0.2;
    }
    #endregion


    #region フォームクロージングイベント
    private void FrmPtCmt_FormClosing(object sender, FormClosingEventArgs e)
    {
      // クローズキャンセル
      if (e.CloseReason == CloseReason.UserClosing)
        e.Cancel = true;
    }
    #endregion
  }
}