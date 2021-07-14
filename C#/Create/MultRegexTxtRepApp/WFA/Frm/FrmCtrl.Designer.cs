namespace WFA
{
  partial class FrmCtrl
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btOpen = new System.Windows.Forms.Button();
      this.btReplace = new System.Windows.Forms.Button();
      this.btPattern = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.cbIsTab = new System.Windows.Forms.CheckBox();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.tbDestDirPath = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cbIsMultRep = new System.Windows.Forms.CheckBox();
      this.cbChcp = new System.Windows.Forms.ComboBox();
      this.tbFileFilter = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.tbTgtDirPath = new System.Windows.Forms.TextBox();
      this.cbIsCaseSens = new System.Windows.Forms.CheckBox();
      this.cbIsNewLine = new System.Windows.Forms.CheckBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTra});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
      // 
      // toolStripMenuItemTra
      // 
      this.toolStripMenuItemTra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTraGain,
            this.toolStripMenuItemTraDec});
      this.toolStripMenuItemTra.Name = "toolStripMenuItemTra";
      this.toolStripMenuItemTra.Size = new System.Drawing.Size(110, 22);
      this.toolStripMenuItemTra.Text = "透明度";
      this.toolStripMenuItemTra.Click += new System.EventHandler(this.toolStripMenuItemTra_Click);
      // 
      // toolStripMenuItemTraGain
      // 
      this.toolStripMenuItemTraGain.Name = "toolStripMenuItemTraGain";
      this.toolStripMenuItemTraGain.Size = new System.Drawing.Size(105, 22);
      this.toolStripMenuItemTraGain.Text = "上げる";
      this.toolStripMenuItemTraGain.Click += new System.EventHandler(this.toolStripMenuItemTraGain_Click);
      // 
      // toolStripMenuItemTraDec
      // 
      this.toolStripMenuItemTraDec.Name = "toolStripMenuItemTraDec";
      this.toolStripMenuItemTraDec.Size = new System.Drawing.Size(105, 22);
      this.toolStripMenuItemTraDec.Text = "下げる";
      this.toolStripMenuItemTraDec.Click += new System.EventHandler(this.toolStripMenuItemTraDec_Click);
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
      this.panel1.Size = new System.Drawing.Size(460, 239);
      this.panel1.TabIndex = 1;
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.btOpen);
      this.groupBox2.Controls.Add(this.btReplace);
      this.groupBox2.Controls.Add(this.btPattern);
      this.groupBox2.Location = new System.Drawing.Point(9, 174);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(448, 59);
      this.groupBox2.TabIndex = 16;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "実行";
      // 
      // btOpen
      // 
      this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOpen.Location = new System.Drawing.Point(230, 21);
      this.btOpen.Name = "btOpen";
      this.btOpen.Size = new System.Drawing.Size(50, 23);
      this.btOpen.TabIndex = 14;
      this.btOpen.Text = "開く";
      this.btOpen.UseVisualStyleBackColor = true;
      this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
      // 
      // btReplace
      // 
      this.btReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btReplace.Location = new System.Drawing.Point(367, 21);
      this.btReplace.Name = "btReplace";
      this.btReplace.Size = new System.Drawing.Size(75, 23);
      this.btReplace.TabIndex = 13;
      this.btReplace.Text = "置換";
      this.btReplace.UseVisualStyleBackColor = true;
      this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
      // 
      // btPattern
      // 
      this.btPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btPattern.Location = new System.Drawing.Point(286, 21);
      this.btPattern.Name = "btPattern";
      this.btPattern.Size = new System.Drawing.Size(75, 23);
      this.btPattern.TabIndex = 12;
      this.btPattern.Text = "パターン";
      this.btPattern.UseVisualStyleBackColor = true;
      this.btPattern.Click += new System.EventHandler(this.btPattern_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.cbIsTab);
      this.groupBox1.Controls.Add(this.groupBox3);
      this.groupBox1.Controls.Add(this.cbIsCaseSens);
      this.groupBox1.Controls.Add(this.cbIsNewLine);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(454, 165);
      this.groupBox1.TabIndex = 15;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "オプション";
      // 
      // cbIsTab
      // 
      this.cbIsTab.AutoSize = true;
      this.cbIsTab.Location = new System.Drawing.Point(139, 21);
      this.cbIsTab.Name = "cbIsTab";
      this.cbIsTab.Size = new System.Drawing.Size(47, 19);
      this.cbIsTab.TabIndex = 16;
      this.cbIsTab.Text = "タブ";
      this.cbIsTab.UseVisualStyleBackColor = true;
      this.cbIsTab.CheckedChanged += new System.EventHandler(this.Com_ChekBox_CheckedChanged);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.tbDestDirPath);
      this.groupBox3.Controls.Add(this.label3);
      this.groupBox3.Controls.Add(this.cbIsMultRep);
      this.groupBox3.Controls.Add(this.cbChcp);
      this.groupBox3.Controls.Add(this.tbFileFilter);
      this.groupBox3.Controls.Add(this.label2);
      this.groupBox3.Controls.Add(this.label1);
      this.groupBox3.Controls.Add(this.tbTgtDirPath);
      this.groupBox3.Location = new System.Drawing.Point(6, 46);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(442, 113);
      this.groupBox3.TabIndex = 15;
      this.groupBox3.TabStop = false;
      // 
      // tbDestDirPath
      // 
      this.tbDestDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbDestDirPath.Location = new System.Drawing.Point(62, 82);
      this.tbDestDirPath.Name = "tbDestDirPath";
      this.tbDestDirPath.Size = new System.Drawing.Size(374, 22);
      this.tbDestDirPath.TabIndex = 23;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(1, 82);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(55, 15);
      this.label3.TabIndex = 22;
      this.label3.Text = "出力先:";
      // 
      // cbIsMultRep
      // 
      this.cbIsMultRep.AutoSize = true;
      this.cbIsMultRep.Checked = true;
      this.cbIsMultRep.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsMultRep.Location = new System.Drawing.Point(9, 0);
      this.cbIsMultRep.Name = "cbIsMultRep";
      this.cbIsMultRep.Size = new System.Drawing.Size(128, 19);
      this.cbIsMultRep.TabIndex = 21;
      this.cbIsMultRep.Text = "ファイル一括置換";
      this.cbIsMultRep.UseVisualStyleBackColor = true;
      this.cbIsMultRep.CheckedChanged += new System.EventHandler(this.Com_ChekBox_CheckedChanged);
      // 
      // cbChcp
      // 
      this.cbChcp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbChcp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbChcp.FormattingEnabled = true;
      this.cbChcp.Location = new System.Drawing.Point(327, 53);
      this.cbChcp.Name = "cbChcp";
      this.cbChcp.Size = new System.Drawing.Size(109, 23);
      this.cbChcp.TabIndex = 20;
      this.cbChcp.SelectedIndexChanged += new System.EventHandler(this.cbChcp_SelectedIndexChanged);
      // 
      // tbFileFilter
      // 
      this.tbFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbFileFilter.Location = new System.Drawing.Point(62, 53);
      this.tbFileFilter.Name = "tbFileFilter";
      this.tbFileFilter.Size = new System.Drawing.Size(259, 22);
      this.tbFileFilter.TabIndex = 18;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 56);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 15);
      this.label2.TabIndex = 17;
      this.label2.Text = "フィルタ:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 28);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 15);
      this.label1.TabIndex = 16;
      this.label1.Text = "フォルダ:";
      // 
      // tbTgtDirPath
      // 
      this.tbTgtDirPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtDirPath.Location = new System.Drawing.Point(62, 25);
      this.tbTgtDirPath.Name = "tbTgtDirPath";
      this.tbTgtDirPath.Size = new System.Drawing.Size(374, 22);
      this.tbTgtDirPath.TabIndex = 15;
      this.tbTgtDirPath.WordWrap = false;
      // 
      // cbIsCaseSens
      // 
      this.cbIsCaseSens.AutoSize = true;
      this.cbIsCaseSens.Location = new System.Drawing.Point(6, 21);
      this.cbIsCaseSens.Name = "cbIsCaseSens";
      this.cbIsCaseSens.Size = new System.Drawing.Size(56, 19);
      this.cbIsCaseSens.TabIndex = 14;
      this.cbIsCaseSens.Text = "大小";
      this.cbIsCaseSens.UseVisualStyleBackColor = true;
      this.cbIsCaseSens.CheckedChanged += new System.EventHandler(this.Com_ChekBox_CheckedChanged);
      // 
      // cbIsNewLine
      // 
      this.cbIsNewLine.AutoSize = true;
      this.cbIsNewLine.Location = new System.Drawing.Point(68, 21);
      this.cbIsNewLine.Name = "cbIsNewLine";
      this.cbIsNewLine.Size = new System.Drawing.Size(56, 19);
      this.cbIsNewLine.TabIndex = 11;
      this.cbIsNewLine.Text = "改行";
      this.cbIsNewLine.UseVisualStyleBackColor = true;
      this.cbIsNewLine.CheckedChanged += new System.EventHandler(this.Com_ChekBox_CheckedChanged);
      // 
      // FrmCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(484, 263);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("MS UI Gothic", 11F);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "FrmCtrl";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCtrl_FormClosing);
      this.Load += new System.EventHandler(this.FrmCtrl_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTra;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraDec;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbIsCaseSens;
    private System.Windows.Forms.CheckBox cbIsNewLine;
    private System.Windows.Forms.Button btPattern;
    private System.Windows.Forms.Button btReplace;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox tbTgtDirPath;
    private System.Windows.Forms.TextBox tbFileFilter;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox cbIsTab;
    private System.Windows.Forms.ComboBox cbChcp;
    private System.Windows.Forms.CheckBox cbIsMultRep;
    private System.Windows.Forms.Button btOpen;
    private System.Windows.Forms.TextBox tbDestDirPath;
    private System.Windows.Forms.Label label3;
  }
}