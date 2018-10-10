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
      Sgry.Azuki.FontInfo fontInfo2 = new Sgry.Azuki.FontInfo();
      this.azkAssist = new Sgry.Azuki.WinForms.AzukiControl();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // azkAssist
      // 
      this.azkAssist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.azkAssist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
      this.azkAssist.ContextMenuStrip = this.contextMenuStrip1;
      this.azkAssist.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.azkAssist.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
      this.azkAssist.FirstVisibleLine = 0;
      this.azkAssist.Font = new System.Drawing.Font("MS UI Gothic", 14F);
      fontInfo2.Name = "MS UI Gothic";
      fontInfo2.Size = 14;
      fontInfo2.Style = System.Drawing.FontStyle.Regular;
      this.azkAssist.FontInfo = fontInfo2;
      this.azkAssist.ForeColor = System.Drawing.Color.Black;
      this.azkAssist.Location = new System.Drawing.Point(20, 18);
      this.azkAssist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.azkAssist.Name = "azkAssist";
      this.azkAssist.ScrollPos = new System.Drawing.Point(0, 0);
      this.azkAssist.Size = new System.Drawing.Size(503, 598);
      this.azkAssist.TabIndex = 1;
      this.azkAssist.ViewWidth = 4142;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(166, 34);
      // 
      // 不透明度ToolStripMenuItem
      // 
      this.不透明度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上げToolStripMenuItem,
            this.下げToolStripMenuItem});
      this.不透明度ToolStripMenuItem.Name = "不透明度ToolStripMenuItem";
      this.不透明度ToolStripMenuItem.Size = new System.Drawing.Size(165, 30);
      this.不透明度ToolStripMenuItem.Text = "不透明度";
      this.不透明度ToolStripMenuItem.Click += new System.EventHandler(this.不透明度ToolStripMenuItem_Click);
      // 
      // 上げToolStripMenuItem
      // 
      this.上げToolStripMenuItem.Name = "上げToolStripMenuItem";
      this.上げToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
      this.上げToolStripMenuItem.Text = "上げ";
      this.上げToolStripMenuItem.Click += new System.EventHandler(this.上げToolStripMenuItem_Click);
      // 
      // 下げToolStripMenuItem
      // 
      this.下げToolStripMenuItem.Name = "下げToolStripMenuItem";
      this.下げToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
      this.下げToolStripMenuItem.Text = "下げ";
      this.下げToolStripMenuItem.Click += new System.EventHandler(this.下げToolStripMenuItem_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(543, 634);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.azkAssist);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.MaximizeBox = false;
      this.Name = "Form2";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Sgry.Azuki.WinForms.AzukiControl azkAssist;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 上げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 下げToolStripMenuItem;
  }
}