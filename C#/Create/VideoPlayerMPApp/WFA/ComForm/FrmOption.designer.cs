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
      this.toolStripMenuItemOpenDir = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.nudPlaySpd = new System.Windows.Forms.NumericUpDown();
      this.cbIsNewLine = new System.Windows.Forms.CheckBox();
      this.nudGetAftBackPos = new System.Windows.Forms.NumericUpDown();
      this.nudCmtPosRange = new System.Windows.Forms.NumericUpDown();
      this.nudGoPosSec = new System.Windows.Forms.NumericUpDown();
      this.btMode = new System.Windows.Forms.Button();
      this.btGetTime = new System.Windows.Forms.Button();
      this.lbPlayPos = new System.Windows.Forms.Label();
      this.btGo = new System.Windows.Forms.Button();
      this.btReadVideo = new System.Windows.Forms.Button();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpd)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGetAftBackPos)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCmtPosRange)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGoPosSec)).BeginInit();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemFolderList,
            this.toolStripMenuItemOpenDir});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(134, 70);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec,
            this.toolStripMenuItemOpacityTransparent});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(133, 22);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(98, 22);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(98, 22);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // toolStripMenuItemOpacityTransparent
      // 
      this.toolStripMenuItemOpacityTransparent.Name = "toolStripMenuItemOpacityTransparent";
      this.toolStripMenuItemOpacityTransparent.Size = new System.Drawing.Size(98, 22);
      this.toolStripMenuItemOpacityTransparent.Text = "透明";
      this.toolStripMenuItemOpacityTransparent.Click += new System.EventHandler(this.toolStripMenuItemOpacityTransparent_Click);
      // 
      // ToolStripMenuItemFolderList
      // 
      this.ToolStripMenuItemFolderList.Name = "ToolStripMenuItemFolderList";
      this.ToolStripMenuItemFolderList.Size = new System.Drawing.Size(133, 22);
      this.ToolStripMenuItemFolderList.Text = "ファイルリスト";
      this.ToolStripMenuItemFolderList.Click += new System.EventHandler(this.ToolStripMenuItemFileList_Click);
      // 
      // toolStripMenuItemOpenDir
      // 
      this.toolStripMenuItemOpenDir.Name = "toolStripMenuItemOpenDir";
      this.toolStripMenuItemOpenDir.Size = new System.Drawing.Size(133, 22);
      this.toolStripMenuItemOpenDir.Text = "開く";
      this.toolStripMenuItemOpenDir.Click += new System.EventHandler(this.toolStripMenuItemOpenDir_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.nudPlaySpd);
      this.panel1.Controls.Add(this.cbIsNewLine);
      this.panel1.Controls.Add(this.nudGetAftBackPos);
      this.panel1.Controls.Add(this.nudCmtPosRange);
      this.panel1.Controls.Add(this.nudGoPosSec);
      this.panel1.Controls.Add(this.btMode);
      this.panel1.Controls.Add(this.btGetTime);
      this.panel1.Controls.Add(this.lbPlayPos);
      this.panel1.Controls.Add(this.btGo);
      this.panel1.Controls.Add(this.btReadVideo);
      this.panel1.Controls.Add(this.tbTgtPath);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(379, 84);
      this.panel1.TabIndex = 0;
      // 
      // nudPlaySpd
      // 
      this.nudPlaySpd.DecimalPlaces = 1;
      this.nudPlaySpd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.nudPlaySpd.Location = new System.Drawing.Point(252, 9);
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
      this.nudPlaySpd.Size = new System.Drawing.Size(49, 19);
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
      this.cbIsNewLine.Location = new System.Drawing.Point(253, 34);
      this.cbIsNewLine.Name = "cbIsNewLine";
      this.cbIsNewLine.Size = new System.Drawing.Size(48, 16);
      this.cbIsNewLine.TabIndex = 36;
      this.cbIsNewLine.Text = "改行";
      this.cbIsNewLine.UseVisualStyleBackColor = true;
      // 
      // nudGetAftBackPos
      // 
      this.nudGetAftBackPos.Location = new System.Drawing.Point(147, 33);
      this.nudGetAftBackPos.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
      this.nudGetAftBackPos.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            -2147483648});
      this.nudGetAftBackPos.Name = "nudGetAftBackPos";
      this.nudGetAftBackPos.Size = new System.Drawing.Size(47, 19);
      this.nudGetAftBackPos.TabIndex = 35;
      // 
      // nudCmtPosRange
      // 
      this.nudCmtPosRange.Location = new System.Drawing.Point(147, 8);
      this.nudCmtPosRange.Maximum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
      this.nudCmtPosRange.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            -2147483648});
      this.nudCmtPosRange.Name = "nudCmtPosRange";
      this.nudCmtPosRange.Size = new System.Drawing.Size(47, 19);
      this.nudCmtPosRange.TabIndex = 34;
      // 
      // nudGoPosSec
      // 
      this.nudGoPosSec.Location = new System.Drawing.Point(76, 8);
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
      this.nudGoPosSec.Size = new System.Drawing.Size(65, 19);
      this.nudGoPosSec.TabIndex = 33;
      // 
      // btMode
      // 
      this.btMode.Location = new System.Drawing.Point(5, 33);
      this.btMode.Name = "btMode";
      this.btMode.Size = new System.Drawing.Size(65, 21);
      this.btMode.TabIndex = 31;
      this.btMode.Text = "Mode";
      this.btMode.UseVisualStyleBackColor = true;
      this.btMode.Click += new System.EventHandler(this.btMode_Click);
      // 
      // btGetTime
      // 
      this.btGetTime.Location = new System.Drawing.Point(200, 7);
      this.btGetTime.Name = "btGetTime";
      this.btGetTime.Size = new System.Drawing.Size(46, 47);
      this.btGetTime.TabIndex = 30;
      this.btGetTime.Text = "Get\r\nTime";
      this.btGetTime.UseVisualStyleBackColor = true;
      this.btGetTime.Click += new System.EventHandler(this.btGetTime_Click);
      // 
      // lbPlayPos
      // 
      this.lbPlayPos.AutoSize = true;
      this.lbPlayPos.Location = new System.Drawing.Point(307, 12);
      this.lbPlayPos.Name = "lbPlayPos";
      this.lbPlayPos.Size = new System.Drawing.Size(65, 12);
      this.lbPlayPos.TabIndex = 28;
      this.lbPlayPos.Text = "00:00:00.000";
      // 
      // btGo
      // 
      this.btGo.Location = new System.Drawing.Point(76, 33);
      this.btGo.Name = "btGo";
      this.btGo.Size = new System.Drawing.Size(65, 21);
      this.btGo.TabIndex = 27;
      this.btGo.Text = "Go";
      this.btGo.UseVisualStyleBackColor = true;
      this.btGo.Click += new System.EventHandler(this.btGo_Click);
      // 
      // btReadVideo
      // 
      this.btReadVideo.Location = new System.Drawing.Point(5, 7);
      this.btReadVideo.Name = "btReadVideo";
      this.btReadVideo.Size = new System.Drawing.Size(65, 21);
      this.btReadVideo.TabIndex = 26;
      this.btReadVideo.Text = "Read";
      this.btReadVideo.UseVisualStyleBackColor = true;
      this.btReadVideo.Click += new System.EventHandler(this.btStart_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Location = new System.Drawing.Point(5, 57);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(367, 19);
      this.tbTgtPath.TabIndex = 10;
      this.tbTgtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTgtPath_KeyUp);
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(399, 104);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
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
      ((System.ComponentModel.ISupportInitialize)(this.nudPlaySpd)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudGetAftBackPos)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCmtPosRange)).EndInit();
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
    private System.Windows.Forms.Button btMode;
    private System.Windows.Forms.NumericUpDown nudGoPosSec;
    private System.Windows.Forms.NumericUpDown nudGetAftBackPos;
    private System.Windows.Forms.NumericUpDown nudCmtPosRange;
    private System.Windows.Forms.CheckBox cbIsNewLine;
    private System.Windows.Forms.NumericUpDown nudPlaySpd;
  }
}