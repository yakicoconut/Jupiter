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
      this.listView1 = new System.Windows.Forms.ListView();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.閉じるToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView1.CheckBoxes = true;
      this.listView1.ContextMenuStrip = this.contextMenuStrip1;
      this.listView1.Location = new System.Drawing.Point(12, 12);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(149, 285);
      this.listView1.TabIndex = 0;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.List;
      this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
      this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem,
            this.閉じるToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
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
      // 閉じるToolStripMenuItem
      // 
      this.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem";
      this.閉じるToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
      this.閉じるToolStripMenuItem.Text = "閉じる";
      this.閉じるToolStripMenuItem.Click += new System.EventHandler(this.閉じるToolStripMenuItem_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(173, 309);
      this.Controls.Add(this.listView1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form2";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem 不透明度ToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 上げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 下げToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem 閉じるToolStripMenuItem;
  }
}