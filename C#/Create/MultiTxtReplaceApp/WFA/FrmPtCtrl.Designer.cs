namespace WFA
{
  partial class FrmPtCtrl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbIgnoreCase = new System.Windows.Forms.CheckBox();
      this.cbNewLine = new System.Windows.Forms.CheckBox();
      this.btPattern = new System.Windows.Forms.Button();
      this.btReplace = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(122, 22);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(96, 22);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(96, 22);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(460, 224);
      this.panel1.TabIndex = 1;
      // 
      // cbIgnoreCase
      // 
      this.cbIgnoreCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbIgnoreCase.AutoSize = true;
      this.cbIgnoreCase.Checked = true;
      this.cbIgnoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIgnoreCase.Location = new System.Drawing.Point(6, 21);
      this.cbIgnoreCase.Name = "cbIgnoreCase";
      this.cbIgnoreCase.Size = new System.Drawing.Size(56, 19);
      this.cbIgnoreCase.TabIndex = 14;
      this.cbIgnoreCase.Text = "大小";
      this.cbIgnoreCase.UseVisualStyleBackColor = true;
      // 
      // cbNewLine
      // 
      this.cbNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbNewLine.AutoSize = true;
      this.cbNewLine.Checked = true;
      this.cbNewLine.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbNewLine.Location = new System.Drawing.Point(68, 21);
      this.cbNewLine.Name = "cbNewLine";
      this.cbNewLine.Size = new System.Drawing.Size(56, 19);
      this.cbNewLine.TabIndex = 11;
      this.cbNewLine.Text = "改行";
      this.cbNewLine.UseVisualStyleBackColor = true;
      // 
      // btPattern
      // 
      this.btPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btPattern.Location = new System.Drawing.Point(286, 21);
      this.btPattern.Name = "btPattern";
      this.btPattern.Size = new System.Drawing.Size(75, 23);
      this.btPattern.TabIndex = 12;
      this.btPattern.Text = "パターン";
      this.btPattern.UseVisualStyleBackColor = true;
      this.btPattern.Click += new System.EventHandler(this.btPattern_Click);
      // 
      // btReplace
      // 
      this.btReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btReplace.Location = new System.Drawing.Point(367, 21);
      this.btReplace.Name = "btReplace";
      this.btReplace.Size = new System.Drawing.Size(75, 23);
      this.btReplace.TabIndex = 13;
      this.btReplace.Text = "置換";
      this.btReplace.UseVisualStyleBackColor = true;
      this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.cbIgnoreCase);
      this.groupBox1.Controls.Add(this.cbNewLine);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(454, 150);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "オプション";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.btReplace);
      this.groupBox2.Controls.Add(this.btPattern);
      this.groupBox2.Location = new System.Drawing.Point(9, 159);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(448, 59);
      this.groupBox2.TabIndex = 16;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "実行";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(62, 21);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
      this.textBox1.Size = new System.Drawing.Size(374, 39);
      this.textBox1.TabIndex = 15;
      this.textBox1.WordWrap = false;
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.textBox2);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Controls.Add(this.textBox1);
      this.groupBox3.Location = new System.Drawing.Point(6, 46);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(442, 98);
      this.groupBox3.TabIndex = 15;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "ファイル一括置換";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 33);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 15);
      this.label1.TabIndex = 16;
      this.label1.Text = "フォルダ:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 69);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 15);
      this.label2.TabIndex = 17;
      this.label2.Text = "フィルタ:";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(62, 66);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(374, 22);
      this.textBox2.TabIndex = 18;
      // 
      // FrmPtCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(484, 248);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("MS UI Gothic", 11F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmPtCtrl";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
      this.Load += new System.EventHandler(this.Form2_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbIgnoreCase;
    private System.Windows.Forms.CheckBox cbNewLine;
    private System.Windows.Forms.Button btPattern;
    private System.Windows.Forms.Button btReplace;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
  }
}