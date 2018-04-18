namespace WFA
{
  partial class FrmPreview
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
      this.pbPreview = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.plParentPb = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.plParentPb.SuspendLayout();
      this.SuspendLayout();
      // 
      // pbPreview
      // 
      this.pbPreview.Location = new System.Drawing.Point(0, 0);
      this.pbPreview.Name = "pbPreview";
      this.pbPreview.Size = new System.Drawing.Size(284, 262);
      this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pbPreview.TabIndex = 0;
      this.pbPreview.TabStop = false;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(124, 22);
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
      // plParentPb
      // 
      this.plParentPb.AutoScroll = true;
      this.plParentPb.Controls.Add(this.pbPreview);
      this.plParentPb.Dock = System.Windows.Forms.DockStyle.Fill;
      this.plParentPb.Location = new System.Drawing.Point(0, 0);
      this.plParentPb.Name = "plParentPb";
      this.plParentPb.Size = new System.Drawing.Size(284, 262);
      this.plParentPb.TabIndex = 1;
      // 
      // FrmPreview
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.plParentPb);
      this.Name = "FrmPreview";
      this.Text = "FrmPreview";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPreview_FormClosing);
      this.Load += new System.EventHandler(this.FrmPreview_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.plParentPb.ResumeLayout(false);
      this.plParentPb.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.PictureBox pbPreview;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPointTest;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPreview;
    private System.Windows.Forms.Panel plParentPb;

  }
}