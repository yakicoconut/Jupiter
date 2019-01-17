namespace WFA
{
  partial class FrmTgtFrame
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOpacityTransparent = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSquareColor = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSquareGreen = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSquareBlack = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSquareWhite = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemSquareBlue = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemTaskBar = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemPointTest = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemPreview = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemSquareColor,
            this.ToolStripMenuItemTaskBar,
            this.ToolStripMenuItemPointTest,
            this.ToolStripMenuItemPreview,
            this.toolStripMenuItemClose});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(161, 158);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec,
            this.ToolStripMenuItemOpacityTransparent});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(160, 22);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // ToolStripMenuItemOpacityTransparent
      // 
      this.ToolStripMenuItemOpacityTransparent.Name = "ToolStripMenuItemOpacityTransparent";
      this.ToolStripMenuItemOpacityTransparent.Size = new System.Drawing.Size(100, 22);
      this.ToolStripMenuItemOpacityTransparent.Text = "透明";
      this.ToolStripMenuItemOpacityTransparent.Click += new System.EventHandler(this.ToolStripMenuItemOpacityTransparent_Click);
      // 
      // ToolStripMenuItemSquareColor
      // 
      this.ToolStripMenuItemSquareColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSquareGreen,
            this.ToolStripMenuItemSquareBlack,
            this.ToolStripMenuItemSquareWhite,
            this.ToolStripMenuItemSquareBlue});
      this.ToolStripMenuItemSquareColor.Name = "ToolStripMenuItemSquareColor";
      this.ToolStripMenuItemSquareColor.Size = new System.Drawing.Size(160, 22);
      this.ToolStripMenuItemSquareColor.Text = "対象正方形色";
      this.ToolStripMenuItemSquareColor.Click += new System.EventHandler(this.ToolStripMenuItemSquareGreen_Click);
      // 
      // ToolStripMenuItemSquareGreen
      // 
      this.ToolStripMenuItemSquareGreen.Name = "ToolStripMenuItemSquareGreen";
      this.ToolStripMenuItemSquareGreen.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemSquareGreen.Text = "緑";
      this.ToolStripMenuItemSquareGreen.Click += new System.EventHandler(this.ToolStripMenuItemSquareGreen_Click);
      // 
      // ToolStripMenuItemSquareBlack
      // 
      this.ToolStripMenuItemSquareBlack.Name = "ToolStripMenuItemSquareBlack";
      this.ToolStripMenuItemSquareBlack.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemSquareBlack.Text = "黒";
      this.ToolStripMenuItemSquareBlack.Click += new System.EventHandler(this.ToolStripMenuItemSquareBlack_Click);
      // 
      // ToolStripMenuItemSquareWhite
      // 
      this.ToolStripMenuItemSquareWhite.Name = "ToolStripMenuItemSquareWhite";
      this.ToolStripMenuItemSquareWhite.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemSquareWhite.Text = "白";
      this.ToolStripMenuItemSquareWhite.Click += new System.EventHandler(this.ToolStripMenuItemSquareWhite_Click);
      // 
      // ToolStripMenuItemSquareBlue
      // 
      this.ToolStripMenuItemSquareBlue.Name = "ToolStripMenuItemSquareBlue";
      this.ToolStripMenuItemSquareBlue.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemSquareBlue.Text = "青";
      this.ToolStripMenuItemSquareBlue.Click += new System.EventHandler(this.ToolStripMenuItemSquareBlue_Click);
      // 
      // ToolStripMenuItemTaskBar
      // 
      this.ToolStripMenuItemTaskBar.Name = "ToolStripMenuItemTaskBar";
      this.ToolStripMenuItemTaskBar.Size = new System.Drawing.Size(160, 22);
      this.ToolStripMenuItemTaskBar.Text = "タスクバー";
      this.ToolStripMenuItemTaskBar.Click += new System.EventHandler(this.ToolStripMenuItemTaskBar_Click);
      // 
      // ToolStripMenuItemPointTest
      // 
      this.ToolStripMenuItemPointTest.Name = "ToolStripMenuItemPointTest";
      this.ToolStripMenuItemPointTest.Size = new System.Drawing.Size(160, 22);
      this.ToolStripMenuItemPointTest.Text = "ポイントテスト";
      this.ToolStripMenuItemPointTest.Click += new System.EventHandler(this.ToolStripMenuItemPointTest_Click);
      // 
      // ToolStripMenuItemPreview
      // 
      this.ToolStripMenuItemPreview.Name = "ToolStripMenuItemPreview";
      this.ToolStripMenuItemPreview.Size = new System.Drawing.Size(160, 22);
      this.ToolStripMenuItemPreview.Text = "プレビュ";
      this.ToolStripMenuItemPreview.Click += new System.EventHandler(this.ToolStripMenuItemPreview_Click);
      // 
      // toolStripMenuItemClose
      // 
      this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
      this.toolStripMenuItemClose.Size = new System.Drawing.Size(160, 22);
      this.toolStripMenuItemClose.Text = "閉じる";
      this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
      // 
      // FrmTgtFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Name = "FrmTgtFrame";
      this.Text = "FrmTgtFrame";
      this.Load += new System.EventHandler(this.FrmTgtFrame_Load);
      this.Shown += new System.EventHandler(this.FrmTgtFrame_Shown);
      this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmTgtFrame_MouseDoubleClick);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPointTest;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPreview;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskBar;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpacityTransparent;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSquareColor;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSquareGreen;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSquareBlack;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSquareWhite;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSquareBlue;
  }
}