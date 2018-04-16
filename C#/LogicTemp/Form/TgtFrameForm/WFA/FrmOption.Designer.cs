namespace WFA
{
  partial class FrmOption
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
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lbTestPoint = new System.Windows.Forms.Label();
      this.lbVerticalDist = new System.Windows.Forms.Label();
      this.lbHorizonDist = new System.Windows.Forms.Label();
      this.rbRightBottom = new System.Windows.Forms.RadioButton();
      this.rbLeftTop = new System.Windows.Forms.RadioButton();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
      // 
      // 不透明度ToolStripMenuItem
      // 
      this.不透明度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上げToolStripMenuItem,
            this.下げToolStripMenuItem});
      this.不透明度ToolStripMenuItem.Name = "不透明度ToolStripMenuItem";
      this.不透明度ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
      this.不透明度ToolStripMenuItem.Text = "不透明度";
      this.不透明度ToolStripMenuItem.Click += new System.EventHandler(this.不透明度ToolStripMenuItem_Click);
      // 
      // 上げToolStripMenuItem
      // 
      this.上げToolStripMenuItem.Name = "上げToolStripMenuItem";
      this.上げToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.上げToolStripMenuItem.Text = "上げ";
      this.上げToolStripMenuItem.Click += new System.EventHandler(this.上げToolStripMenuItem_Click);
      // 
      // 下げToolStripMenuItem
      // 
      this.下げToolStripMenuItem.Name = "下げToolStripMenuItem";
      this.下げToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.下げToolStripMenuItem.Text = "下げ";
      this.下げToolStripMenuItem.Click += new System.EventHandler(this.下げToolStripMenuItem_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.ContextMenuStrip = this.contextMenuStrip1;
      this.panel1.Controls.Add(this.lbTestPoint);
      this.panel1.Controls.Add(this.lbVerticalDist);
      this.panel1.Controls.Add(this.lbHorizonDist);
      this.panel1.Controls.Add(this.rbRightBottom);
      this.panel1.Controls.Add(this.rbLeftTop);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(150, 285);
      this.panel1.TabIndex = 1;
      // 
      // lbTestPoint
      // 
      this.lbTestPoint.AutoSize = true;
      this.lbTestPoint.Location = new System.Drawing.Point(16, 92);
      this.lbTestPoint.Name = "lbTestPoint";
      this.lbTestPoint.Size = new System.Drawing.Size(35, 12);
      this.lbTestPoint.TabIndex = 4;
      this.lbTestPoint.Text = "label3";
      // 
      // lbVerticalDist
      // 
      this.lbVerticalDist.AutoSize = true;
      this.lbVerticalDist.Location = new System.Drawing.Point(63, 66);
      this.lbVerticalDist.Name = "lbVerticalDist";
      this.lbVerticalDist.Size = new System.Drawing.Size(35, 12);
      this.lbVerticalDist.TabIndex = 3;
      this.lbVerticalDist.Text = "label2";
      // 
      // lbHorizonDist
      // 
      this.lbHorizonDist.AutoSize = true;
      this.lbHorizonDist.Location = new System.Drawing.Point(33, 56);
      this.lbHorizonDist.Name = "lbHorizonDist";
      this.lbHorizonDist.Size = new System.Drawing.Size(35, 12);
      this.lbHorizonDist.TabIndex = 2;
      this.lbHorizonDist.Text = "label1";
      // 
      // rbRightBottom
      // 
      this.rbRightBottom.AutoSize = true;
      this.rbRightBottom.Location = new System.Drawing.Point(18, 38);
      this.rbRightBottom.Name = "rbRightBottom";
      this.rbRightBottom.Size = new System.Drawing.Size(14, 13);
      this.rbRightBottom.TabIndex = 1;
      this.rbRightBottom.TabStop = true;
      this.rbRightBottom.UseVisualStyleBackColor = true;
      // 
      // rbLeftTop
      // 
      this.rbLeftTop.AutoSize = true;
      this.rbLeftTop.Location = new System.Drawing.Point(18, 16);
      this.rbLeftTop.Name = "rbLeftTop";
      this.rbLeftTop.Size = new System.Drawing.Size(14, 13);
      this.rbLeftTop.TabIndex = 0;
      this.rbLeftTop.TabStop = true;
      this.rbLeftTop.UseVisualStyleBackColor = true;
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(170, 305);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmOption";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 上げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 下げToolStripMenuItem;
    private System.Windows.Forms.Panel panel1;
    public System.Windows.Forms.RadioButton rbLeftTop;
    public System.Windows.Forms.RadioButton rbRightBottom;
    public System.Windows.Forms.Label lbVerticalDist;
    public System.Windows.Forms.Label lbHorizonDist;
    public System.Windows.Forms.Label lbTestPoint;
  }
}