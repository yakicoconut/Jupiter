namespace WFA
{
  partial class Form2
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOpacityTransparent = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemTaskBar = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemCapture = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemSize = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemSizeUp = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemSizeDown = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemColor = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemBlack = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemRed = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemBlue = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemEraser = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemMin = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemTaskBar,
            this.toolStripMenuItemCapture,
            this.toolStripMenuItemSize,
            this.toolStripMenuItemColor,
            this.toolStripMenuItemClear,
            this.toolStripMenuItemMin,
            this.toolStripMenuItemClose});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(153, 158);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec,
            this.ToolStripMenuItemOpacityTransparent});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(152, 22);
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
      // ToolStripMenuItemTaskBar
      // 
      this.ToolStripMenuItemTaskBar.Name = "ToolStripMenuItemTaskBar";
      this.ToolStripMenuItemTaskBar.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemTaskBar.Text = "タスクバー";
      this.ToolStripMenuItemTaskBar.Click += new System.EventHandler(this.ToolStripMenuItemTaskBar_Click);
      // 
      // toolStripMenuItemCapture
      // 
      this.toolStripMenuItemCapture.Name = "toolStripMenuItemCapture";
      this.toolStripMenuItemCapture.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemCapture.Text = "キャプチャ";
      this.toolStripMenuItemCapture.Click += new System.EventHandler(this.ToolStripMenuItemCapture_Click);
      // 
      // toolStripMenuItemSize
      // 
      this.toolStripMenuItemSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSizeUp,
            this.toolStripMenuItemSizeDown});
      this.toolStripMenuItemSize.Name = "toolStripMenuItemSize";
      this.toolStripMenuItemSize.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemSize.Text = "サイズ";
      this.toolStripMenuItemSize.Click += new System.EventHandler(this.toolStripMenuItemSize_Click);
      // 
      // toolStripMenuItemSizeUp
      // 
      this.toolStripMenuItemSizeUp.Name = "toolStripMenuItemSizeUp";
      this.toolStripMenuItemSizeUp.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemSizeUp.Text = "上げ";
      this.toolStripMenuItemSizeUp.Click += new System.EventHandler(this.toolStripMenuItemSizeUp_Click);
      // 
      // toolStripMenuItemSizeDown
      // 
      this.toolStripMenuItemSizeDown.Name = "toolStripMenuItemSizeDown";
      this.toolStripMenuItemSizeDown.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemSizeDown.Text = "下げ";
      this.toolStripMenuItemSizeDown.Click += new System.EventHandler(this.toolStripMenuItemSizeDown_Click);
      // 
      // toolStripMenuItemColor
      // 
      this.toolStripMenuItemColor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBlack,
            this.toolStripMenuItemRed,
            this.toolStripMenuItemBlue,
            this.toolStripMenuItemEraser});
      this.toolStripMenuItemColor.Name = "toolStripMenuItemColor";
      this.toolStripMenuItemColor.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemColor.Text = "カラー";
      // 
      // toolStripMenuItemBlack
      // 
      this.toolStripMenuItemBlack.Name = "toolStripMenuItemBlack";
      this.toolStripMenuItemBlack.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemBlack.Text = "Black";
      this.toolStripMenuItemBlack.Click += new System.EventHandler(this.toolStripMenuItemBlack_Click);
      // 
      // toolStripMenuItemRed
      // 
      this.toolStripMenuItemRed.Name = "toolStripMenuItemRed";
      this.toolStripMenuItemRed.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemRed.Text = "Red";
      this.toolStripMenuItemRed.Click += new System.EventHandler(this.toolStripMenuItemRed_Click);
      // 
      // toolStripMenuItemBlue
      // 
      this.toolStripMenuItemBlue.Name = "toolStripMenuItemBlue";
      this.toolStripMenuItemBlue.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemBlue.Text = "Blue";
      this.toolStripMenuItemBlue.Click += new System.EventHandler(this.toolStripMenuItemBlue_Click);
      // 
      // toolStripMenuItemEraser
      // 
      this.toolStripMenuItemEraser.Name = "toolStripMenuItemEraser";
      this.toolStripMenuItemEraser.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemEraser.Text = "消しゴム";
      this.toolStripMenuItemEraser.Click += new System.EventHandler(this.toolStripMenuItemEraser_Click);
      // 
      // toolStripMenuItemClear
      // 
      this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
      this.toolStripMenuItemClear.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemClear.Text = "クリア";
      this.toolStripMenuItemClear.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
      // 
      // toolStripMenuItemMin
      // 
      this.toolStripMenuItemMin.Name = "toolStripMenuItemMin";
      this.toolStripMenuItemMin.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemMin.Text = "最小化";
      this.toolStripMenuItemMin.Click += new System.EventHandler(this.toolStripMenuItemMin_Click);
      // 
      // toolStripMenuItemClose
      // 
      this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
      this.toolStripMenuItemClose.Size = new System.Drawing.Size(152, 22);
      this.toolStripMenuItemClose.Text = "閉じる";
      this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(198, 173);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Name = "Form2";
      this.Text = "Form2";
      this.Load += new System.EventHandler(this.Form2_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTaskBar;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpacityTransparent;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMin;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCapture;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSize;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemColor;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlack;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRed;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlue;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSizeUp;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSizeDown;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEraser;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
  }
}