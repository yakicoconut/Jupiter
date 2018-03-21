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
      this.cbIsFunctionShift = new System.Windows.Forms.CheckBox();
      this.cbIsFunctionCtrl = new System.Windows.Forms.CheckBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.cbIsFunctionShift);
      this.panel1.Controls.Add(this.cbIsFunctionCtrl);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(149, 285);
      this.panel1.TabIndex = 1;
      // 
      // cbIsFunctionShift
      // 
      this.cbIsFunctionShift.AutoSize = true;
      this.cbIsFunctionShift.Location = new System.Drawing.Point(20, 15);
      this.cbIsFunctionShift.Name = "cbIsFunctionShift";
      this.cbIsFunctionShift.Size = new System.Drawing.Size(48, 16);
      this.cbIsFunctionShift.TabIndex = 1;
      this.cbIsFunctionShift.Text = "Shift";
      this.cbIsFunctionShift.UseVisualStyleBackColor = true;
      this.cbIsFunctionShift.CheckedChanged += new System.EventHandler(this.cbIsFunctionShift_CheckedChanged);
      // 
      // cbIsFunctionCtrl
      // 
      this.cbIsFunctionCtrl.AutoSize = true;
      this.cbIsFunctionCtrl.Location = new System.Drawing.Point(20, 37);
      this.cbIsFunctionCtrl.Name = "cbIsFunctionCtrl";
      this.cbIsFunctionCtrl.Size = new System.Drawing.Size(43, 16);
      this.cbIsFunctionCtrl.TabIndex = 0;
      this.cbIsFunctionCtrl.Text = "Ctrl";
      this.cbIsFunctionCtrl.UseVisualStyleBackColor = true;
      this.cbIsFunctionCtrl.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
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
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    public System.Windows.Forms.CheckBox cbIsFunctionCtrl;
    public System.Windows.Forms.CheckBox cbIsFunctionShift;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 上げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 下げToolStripMenuItem;
  }
}