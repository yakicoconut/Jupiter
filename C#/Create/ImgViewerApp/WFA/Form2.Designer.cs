﻿namespace WFA
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
      this.cbIsModeZeroPoint = new System.Windows.Forms.CheckBox();
      this.cbIsModeZoom = new System.Windows.Forms.CheckBox();
      this.cbIsModePageEject = new System.Windows.Forms.CheckBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.label1 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.cbIsModeZeroPoint);
      this.panel1.Controls.Add(this.cbIsModeZoom);
      this.panel1.Controls.Add(this.cbIsModePageEject);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(149, 285);
      this.panel1.TabIndex = 1;
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
      this.cbIsModeZoom.CheckedChanged += new System.EventHandler(this.cbIsFunctionShift_CheckedChanged);
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
      this.cbIsModePageEject.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
  }
}