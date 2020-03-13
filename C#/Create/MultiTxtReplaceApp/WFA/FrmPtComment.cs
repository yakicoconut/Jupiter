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
    public FrmPtComment(Form1 fm1)
    {
      InitializeComponent();

      // 親フォーム設定
      form1 = fm1;
    }
    #endregion


    #region 宣言

    // 親フォーム
    public Form1 form1 { get; set; }

    #endregion


    #region フォームロードイベント
    private void Form2_Load(object sender, EventArgs e)
    {
      this.Text = "コメント";
      // 親コントロールのサイズと位置からサイズ・出現位置設定
      int parentX = form1.Location.X;
      int parentY = form1.Location.Y;
      int parentH = form1.Height;
      int parentW = form1.Width;
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