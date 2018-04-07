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
      this.panel1 = new System.Windows.Forms.Panel();
      this.tbFileName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cbIsModeZeroPoint = new System.Windows.Forms.CheckBox();
      this.cbIsModeZoom = new System.Windows.Forms.CheckBox();
      this.cbIsModePageEject = new System.Windows.Forms.CheckBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.btLeft = new System.Windows.Forms.Button();
      this.btRight = new System.Windows.Forms.Button();
      this.btUp = new System.Windows.Forms.Button();
      this.byDown = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.byDown);
      this.panel1.Controls.Add(this.btUp);
      this.panel1.Controls.Add(this.btRight);
      this.panel1.Controls.Add(this.btLeft);
      this.panel1.Controls.Add(this.tbFileName);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cbIsModeZeroPoint);
      this.panel1.Controls.Add(this.cbIsModeZoom);
      this.panel1.Controls.Add(this.cbIsModePageEject);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(149, 285);
      this.panel1.TabIndex = 1;
      // 
      // tbFileName
      // 
      this.tbFileName.BackColor = System.Drawing.Color.White;
      this.tbFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbFileName.ForeColor = System.Drawing.Color.Black;
      this.tbFileName.Location = new System.Drawing.Point(20, 111);
      this.tbFileName.Name = "tbFileName";
      this.tbFileName.ReadOnly = true;
      this.tbFileName.Size = new System.Drawing.Size(126, 12);
      this.tbFileName.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label2.Location = new System.Drawing.Point(3, 96);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 12);
      this.label2.TabIndex = 4;
      this.label2.Text = "INFO";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(3, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 3;
      this.label1.Text = "MODE";
      // 
      // cbIsModeZeroPoint
      // 
      this.cbIsModeZeroPoint.AutoSize = true;
      this.cbIsModeZeroPoint.Location = new System.Drawing.Point(20, 77);
      this.cbIsModeZeroPoint.Name = "cbIsModeZeroPoint";
      this.cbIsModeZeroPoint.Size = new System.Drawing.Size(64, 16);
      this.cbIsModeZeroPoint.TabIndex = 2;
      this.cbIsModeZeroPoint.Text = "0Point()";
      this.cbIsModeZeroPoint.UseVisualStyleBackColor = true;
      // 
      // cbIsModeZoom
      // 
      this.cbIsModeZoom.AutoSize = true;
      this.cbIsModeZoom.Location = new System.Drawing.Point(20, 33);
      this.cbIsModeZoom.Name = "cbIsModeZoom";
      this.cbIsModeZoom.Size = new System.Drawing.Size(86, 16);
      this.cbIsModeZoom.TabIndex = 1;
      this.cbIsModeZoom.Text = "拡張/縮小()";
      this.cbIsModeZoom.UseVisualStyleBackColor = true;
      this.cbIsModeZoom.CheckedChanged += new System.EventHandler(this.cbIsModeZoom_CheckedChanged);
      // 
      // cbIsModePageEject
      // 
      this.cbIsModePageEject.AutoSize = true;
      this.cbIsModePageEject.Location = new System.Drawing.Point(20, 55);
      this.cbIsModePageEject.Name = "cbIsModePageEject";
      this.cbIsModePageEject.Size = new System.Drawing.Size(82, 16);
      this.cbIsModePageEject.TabIndex = 0;
      this.cbIsModePageEject.Text = "ページ送り()";
      this.cbIsModePageEject.UseVisualStyleBackColor = true;
      this.cbIsModePageEject.CheckedChanged += new System.EventHandler(this.cbIsModePageEject_CheckedChanged);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
      // 
      // 不透明度ToolStripMenuItem
      // 
      this.不透明度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上げToolStripMenuItem,
            this.下げToolStripMenuItem});
      this.不透明度ToolStripMenuItem.Name = "不透明度ToolStripMenuItem";
      this.不透明度ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.不透明度ToolStripMenuItem.Text = "不透明度";
      this.不透明度ToolStripMenuItem.Click += new System.EventHandler(this.不透明度ToolStripMenuItem_Click);
      // 
      // 上げToolStripMenuItem
      // 
      this.上げToolStripMenuItem.Name = "上げToolStripMenuItem";
      this.上げToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
      this.上げToolStripMenuItem.Text = "上げ";
      this.上げToolStripMenuItem.Click += new System.EventHandler(this.上げToolStripMenuItem_Click);
      // 
      // 下げToolStripMenuItem
      // 
      this.下げToolStripMenuItem.Name = "下げToolStripMenuItem";
      this.下げToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
      this.下げToolStripMenuItem.Text = "下げ";
      this.下げToolStripMenuItem.Click += new System.EventHandler(this.下げToolStripMenuItem_Click);
      // 
      // btLeft
      // 
      this.btLeft.Location = new System.Drawing.Point(3, 236);
      this.btLeft.Name = "btLeft";
      this.btLeft.Size = new System.Drawing.Size(70, 23);
      this.btLeft.TabIndex = 6;
      this.btLeft.Text = "←";
      this.btLeft.UseVisualStyleBackColor = true;
      this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
      // 
      // btRight
      // 
      this.btRight.Location = new System.Drawing.Point(76, 236);
      this.btRight.Name = "btRight";
      this.btRight.Size = new System.Drawing.Size(70, 23);
      this.btRight.TabIndex = 7;
      this.btRight.Text = "→";
      this.btRight.UseVisualStyleBackColor = true;
      this.btRight.Click += new System.EventHandler(this.btRight_Click);
      // 
      // btUp
      // 
      this.btUp.Location = new System.Drawing.Point(39, 213);
      this.btUp.Name = "btUp";
      this.btUp.Size = new System.Drawing.Size(70, 23);
      this.btUp.TabIndex = 8;
      this.btUp.Text = " ↑";
      this.btUp.UseVisualStyleBackColor = true;
      this.btUp.Click += new System.EventHandler(this.btUp_Click);
      // 
      // byDown
      // 
      this.byDown.Location = new System.Drawing.Point(39, 259);
      this.byDown.Name = "byDown";
      this.byDown.Size = new System.Drawing.Size(70, 23);
      this.byDown.TabIndex = 9;
      this.byDown.Text = " ↓";
      this.byDown.UseVisualStyleBackColor = true;
      this.byDown.Click += new System.EventHandler(this.byDown_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(173, 309);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form2";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    public System.Windows.Forms.CheckBox cbIsModePageEject;
    public System.Windows.Forms.CheckBox cbIsModeZoom;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 上げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 下げToolStripMenuItem;
    public System.Windows.Forms.CheckBox cbIsModeZeroPoint;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox tbFileName;
    private System.Windows.Forms.Button byDown;
    private System.Windows.Forms.Button btUp;
    private System.Windows.Forms.Button btRight;
    private System.Windows.Forms.Button btLeft;
  }
}