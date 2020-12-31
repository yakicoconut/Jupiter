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
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityTransparent = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemFolderList = new System.Windows.Forms.ToolStripMenuItem();
      this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpenDir = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btDefPlaySpd = new System.Windows.Forms.Button();
      this.nudBackPosSec = new System.Windows.Forms.NumericUpDown();
      this.btBack = new System.Windows.Forms.Button();
      this.nudPlaySpd = new System.Windows.Forms.NumericUpDown();
      this.cbIsNewLine = new System.Windows.Forms.CheckBox();
      this.nudGoPosSec = new System.Windows.Forms.NumericUpDown();
      this.btGetTime = new System.Windows.Forms.Button();
      this.lbPlayPos = new System.Windows.Forms.Label();
      this.btGo = new System.Windows.Forms.Button();
      this.btReadVideo = new System.Windows.Forms.Button();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.最前面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudBackPosSec)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpd)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGoPosSec)).BeginInit();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最前面ToolStripMenuItem,
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemFolderList,
            this.modeToolStripMenuItem,
            this.toolStripMenuItemOpenDir});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(301, 228);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec,
            this.toolStripMenuItemOpacityTransparent});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(300, 36);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(162, 38);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(162, 38);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // toolStripMenuItemOpacityTransparent
      // 
      this.toolStripMenuItemOpacityTransparent.Name = "toolStripMenuItemOpacityTransparent";
      this.toolStripMenuItemOpacityTransparent.Size = new System.Drawing.Size(162, 38);
      this.toolStripMenuItemOpacityTransparent.Text = "透明";
      this.toolStripMenuItemOpacityTransparent.Click += new System.EventHandler(this.toolStripMenuItemOpacityTransparent_Click);
      // 
      // ToolStripMenuItemFolderList
      // 
      this.ToolStripMenuItemFolderList.Name = "ToolStripMenuItemFolderList";
      this.ToolStripMenuItemFolderList.Size = new System.Drawing.Size(300, 36);
      this.ToolStripMenuItemFolderList.Text = "ファイルリスト";
      this.ToolStripMenuItemFolderList.Click += new System.EventHandler(this.ToolStripMenuItemFileList_Click);
      // 
      // modeToolStripMenuItem
      // 
      this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
      this.modeToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
      this.modeToolStripMenuItem.Text = "Mode";
      this.modeToolStripMenuItem.Click += new System.EventHandler(this.modeToolStripMenuItem_Click);
      // 
      // toolStripMenuItemOpenDir
      // 
      this.toolStripMenuItemOpenDir.Name = "toolStripMenuItemOpenDir";
      this.toolStripMenuItemOpenDir.Size = new System.Drawing.Size(300, 36);
      this.toolStripMenuItemOpenDir.Text = "開く";
      this.toolStripMenuItemOpenDir.Click += new System.EventHandler(this.toolStripMenuItemOpenDir_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.btDefPlaySpd);
      this.panel1.Controls.Add(this.nudBackPosSec);
      this.panel1.Controls.Add(this.btBack);
      this.panel1.Controls.Add(this.nudPlaySpd);
      this.panel1.Controls.Add(this.cbIsNewLine);
      this.panel1.Controls.Add(this.nudGoPosSec);
      this.panel1.Controls.Add(this.btGetTime);
      this.panel1.Controls.Add(this.lbPlayPos);
      this.panel1.Controls.Add(this.btGo);
      this.panel1.Controls.Add(this.btReadVideo);
      this.panel1.Controls.Add(this.tbTgtPath);
      this.panel1.Location = new System.Drawing.Point(22, 20);
      this.panel1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(821, 168);
      this.panel1.TabIndex = 0;
      // 
      // btDefPlaySpd
      // 
      this.btDefPlaySpd.Location = new System.Drawing.Point(462, 60);
      this.btDefPlaySpd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btDefPlaySpd.Name = "btDefPlaySpd";
      this.btDefPlaySpd.Size = new System.Drawing.Size(100, 42);
      this.btDefPlaySpd.TabIndex = 40;
      this.btDefPlaySpd.Text = "Def";
      this.btDefPlaySpd.UseVisualStyleBackColor = true;
      this.btDefPlaySpd.Click += new System.EventHandler(this.btDefPlaySpd_Click);
      // 
      // nudBackPosSec
      // 
      this.nudBackPosSec.Location = new System.Drawing.Point(124, 10);
      this.nudBackPosSec.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.nudBackPosSec.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
      this.nudBackPosSec.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            -2147483648});
      this.nudBackPosSec.Name = "nudBackPosSec";
      this.nudBackPosSec.Size = new System.Drawing.Size(100, 31);
      this.nudBackPosSec.TabIndex = 39;
      // 
      // btBack
      // 
      this.btBack.Location = new System.Drawing.Point(124, 60);
      this.btBack.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btBack.Name = "btBack";
      this.btBack.Size = new System.Drawing.Size(100, 42);
      this.btBack.TabIndex = 38;
      this.btBack.Text = "Back";
      this.btBack.UseVisualStyleBackColor = true;
      this.btBack.Click += new System.EventHandler(this.btBack_Click);
      // 
      // nudPlaySpd
      // 
      this.nudPlaySpd.DecimalPlaces = 1;
      this.nudPlaySpd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudPlaySpd.Location = new System.Drawing.Point(462, 10);
      this.nudPlaySpd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.nudPlaySpd.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudPlaySpd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudPlaySpd.Name = "nudPlaySpd";
      this.nudPlaySpd.Size = new System.Drawing.Size(100, 31);
      this.nudPlaySpd.TabIndex = 37;
      this.nudPlaySpd.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
      this.nudPlaySpd.ValueChanged += new System.EventHandler(this.nudPlaySpd_ValueChanged);
      // 
      // cbIsNewLine
      // 
      this.cbIsNewLine.AutoSize = true;
      this.cbIsNewLine.Location = new System.Drawing.Point(579, 64);
      this.cbIsNewLine.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.cbIsNewLine.Name = "cbIsNewLine";
      this.cbIsNewLine.Size = new System.Drawing.Size(90, 28);
      this.cbIsNewLine.TabIndex = 36;
      this.cbIsNewLine.Text = "改行";
      this.cbIsNewLine.UseVisualStyleBackColor = true;
      // 
      // nudGoPosSec
      // 
      this.nudGoPosSec.Location = new System.Drawing.Point(236, 10);
      this.nudGoPosSec.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.nudGoPosSec.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
      this.nudGoPosSec.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            -2147483648});
      this.nudGoPosSec.Name = "nudGoPosSec";
      this.nudGoPosSec.Size = new System.Drawing.Size(100, 31);
      this.nudGoPosSec.TabIndex = 33;
      // 
      // btGetTime
      // 
      this.btGetTime.Location = new System.Drawing.Point(349, 8);
      this.btGetTime.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btGetTime.Name = "btGetTime";
      this.btGetTime.Size = new System.Drawing.Size(100, 94);
      this.btGetTime.TabIndex = 30;
      this.btGetTime.Text = "Get\r\nTime";
      this.btGetTime.UseVisualStyleBackColor = true;
      this.btGetTime.Click += new System.EventHandler(this.btGetTime_Click);
      // 
      // lbPlayPos
      // 
      this.lbPlayPos.AutoSize = true;
      this.lbPlayPos.Location = new System.Drawing.Point(574, 24);
      this.lbPlayPos.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
      this.lbPlayPos.Name = "lbPlayPos";
      this.lbPlayPos.Size = new System.Drawing.Size(133, 24);
      this.lbPlayPos.TabIndex = 28;
      this.lbPlayPos.Text = "00:00:00.000";
      // 
      // btGo
      // 
      this.btGo.Location = new System.Drawing.Point(236, 60);
      this.btGo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btGo.Name = "btGo";
      this.btGo.Size = new System.Drawing.Size(100, 42);
      this.btGo.TabIndex = 27;
      this.btGo.Text = "Go";
      this.btGo.UseVisualStyleBackColor = true;
      this.btGo.Click += new System.EventHandler(this.btGo_Click);
      // 
      // btReadVideo
      // 
      this.btReadVideo.Location = new System.Drawing.Point(11, 8);
      this.btReadVideo.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btReadVideo.Name = "btReadVideo";
      this.btReadVideo.Size = new System.Drawing.Size(100, 94);
      this.btReadVideo.TabIndex = 26;
      this.btReadVideo.Text = "Read";
      this.btReadVideo.UseVisualStyleBackColor = true;
      this.btReadVideo.Click += new System.EventHandler(this.btStart_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Location = new System.Drawing.Point(11, 114);
      this.tbTgtPath.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(791, 31);
      this.tbTgtPath.TabIndex = 10;
      this.tbTgtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTgtPath_KeyUp);
      // 
      // 最前面ToolStripMenuItem
      // 
      this.最前面ToolStripMenuItem.Name = "最前面ToolStripMenuItem";
      this.最前面ToolStripMenuItem.Size = new System.Drawing.Size(300, 36);
      this.最前面ToolStripMenuItem.Text = "最前面";
      this.最前面ToolStripMenuItem.Click += new System.EventHandler(this.最前面ToolStripMenuItem_Click);
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(865, 208);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
      ((System.ComponentModel.ISupportInitialize)(this.nudBackPosSec)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpd)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGoPosSec)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFolderList;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDir;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityTransparent;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox tbTgtPath;
    private System.Windows.Forms.Button btReadVideo;
    private System.Windows.Forms.Button btGetTime;
    private System.Windows.Forms.Label lbPlayPos;
    private System.Windows.Forms.Button btGo;
    private System.Windows.Forms.NumericUpDown nudGoPosSec;
    private System.Windows.Forms.CheckBox cbIsNewLine;
    private System.Windows.Forms.NumericUpDown nudPlaySpd;
    private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
    private System.Windows.Forms.Button btDefPlaySpd;
    private System.Windows.Forms.NumericUpDown nudBackPosSec;
    private System.Windows.Forms.Button btBack;
    private System.Windows.Forms.ToolStripMenuItem 最前面ToolStripMenuItem;
  }
}