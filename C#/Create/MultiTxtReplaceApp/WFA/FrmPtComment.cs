using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFA
{
  public partial class FrmPtComment : Form
  {
    #region コンストラクタ
    public FrmPtComment(Form1 _fm1)
    {
      InitializeComponent();

      // 親フォーム設定
      fm1 = _fm1;
    }
    #endregion


    #region 宣言

    // 親フォーム
    private Form1 fm1;

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      this.Text = "コメント";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = fm1.Location.X;
      int parentY = fm1.Location.Y;
      int parentH = fm1.Height;
      int parentW = fm1.Width;
      // 横幅は85(二行分)固定
      this.Size = new Size(parentW, 85);
      this.Location = new Point(parentX, parentY + parentH);

      // タスクバーにアイコンを表示しない
      this.ShowInTaskbar = false;
    }
    #endregion


    #region コンテキスト_不透明度押下イベント
    private void toolStripMenuItemOpacity_Click(object sender, EventArgs e)
    {
      //デフォルトに戻す
      this.Opacity = 0.8;
    }
    #endregion

    #region コンテキスト_上げ押下イベント
    private void toolStripMenuItemOpacityGain_Click(object sender, EventArgs e)
    {
      //不透明度を上げる
      this.Opacity += 0.2;
    }
    #endregion

    #region コンテキスト_下げ押下イベント
    private void toolStripMenuItemOpacityDec_Click(object sender, EventArgs e)
    {
      //不透明度を下げる
      this.Opacity -= 0.2;
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