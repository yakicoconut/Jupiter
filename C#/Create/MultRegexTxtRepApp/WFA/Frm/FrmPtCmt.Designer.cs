namespace WFA
{
  partial class FrmPtCmt
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
      this.toolStripMenuItemTra = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemTraGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemTraDec = new System.Windows.Forms.ToolStripMenuItem();
      this.tbComment = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTra});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
      // 
      // toolStripMenuItemTra
      // 
      this.toolStripMenuItemTra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTraGain,
            this.toolStripMenuItemTraDec});
      this.toolStripMenuItemTra.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemTra.Size = new System.Drawing.Size(124, 22);
      this.toolStripMenuItemTra.Text = "透明度";
      this.toolStripMenuItemTra.Click += new System.EventHandler(this.toolStripMenuItemTra_Click);
      // 
      // toolStripMenuItemTraGain
      // 
      this.toolStripMenuItemTraGain.Name = "toolStripMenuItemTraGain";
      this.toolStripMenuItemTraGain.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemTraGain.Text = "上げる";
      this.toolStripMenuItemTraGain.Click += new System.EventHandler(this.toolStripMenuItemTraGain_Click);
      // 
      // toolStripMenuItemTraDec
      // 
      this.toolStripMenuItemTraDec.Name = "toolStripMenuItemTraDec";
      this.toolStripMenuItemTraDec.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemTraDec.Text = "下げる";
      this.toolStripMenuItemTraDec.Click += new System.EventHandler(this.toolStripMenuItemTraDec_Click);
      // 
      // tbComment
      // 
      this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbComment.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbComment.Location = new System.Drawing.Point(7, 6);
      this.tbComment.Margin = new System.Windows.Forms.Padding(4);
      this.tbComment.Multiline = true;
      this.tbComment.Name = "tbComment";
      this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbComment.Size = new System.Drawing.Size(410, 29);
      this.tbComment.TabIndex = 1;
      // 
      // FrmPtCmt
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(423, 42);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.tbComment);
      this.Font = new System.Drawing.Font("MS UI Gothic", 11F);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmPtCmt";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPtCmt_FormClosing);
      this.Load += new System.EventHandler(this.FrmPtCmt_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTra;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraDec;
    public System.Windows.Forms.TextBox tbComment;
  }
}