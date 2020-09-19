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
      this.nudDelayedPlay = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.nudMilliSec = new System.Windows.Forms.NumericUpDown();
      this.nudVolume = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.dtpTime = new System.Windows.Forms.DateTimePicker();
      this.nudCngLocationY = new System.Windows.Forms.NumericUpDown();
      this.nudCngLocationX = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.nudCngSizeH = new System.Windows.Forms.NumericUpDown();
      this.nudCngSizeW = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbDuration = new System.Windows.Forms.TextBox();
      this.btPauseStart = new WFA.ButtonEx();
      this.btGoTime = new WFA.ButtonEx();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudDelayedPlay)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMilliSec)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngLocationY)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngLocationX)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngSizeH)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngSizeW)).BeginInit();
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
      this.panel1.Controls.Add(this.tbDuration);
      this.panel1.Controls.Add(this.nudDelayedPlay);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.nudMilliSec);
      this.panel1.Controls.Add(this.nudVolume);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.dtpTime);
      this.panel1.Controls.Add(this.nudCngLocationY);
      this.panel1.Controls.Add(this.nudCngLocationX);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.tbTgtPath);
      this.panel1.Controls.Add(this.btPauseStart);
      this.panel1.Controls.Add(this.btGoTime);
      this.panel1.Controls.Add(this.nudCngSizeH);
      this.panel1.Controls.Add(this.nudCngSizeW);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(369, 108);
      this.panel1.TabIndex = 0;
      // 
      // nudDelayedPlay
      // 
      this.nudDelayedPlay.Location = new System.Drawing.Point(118, 59);
      this.nudDelayedPlay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudDelayedPlay.Name = "nudDelayedPlay";
      this.nudDelayedPlay.Size = new System.Drawing.Size(45, 19);
      this.nudDelayedPlay.TabIndex = 24;
      this.nudDelayedPlay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(110, 44);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 12);
      this.label1.TabIndex = 23;
      this.label1.Text = "遅延再生";
      // 
      // nudMilliSec
      // 
      this.nudMilliSec.DecimalPlaces = 3;
      this.nudMilliSec.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
      this.nudMilliSec.Location = new System.Drawing.Point(240, 32);
      this.nudMilliSec.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
      this.nudMilliSec.Name = "nudMilliSec";
      this.nudMilliSec.Size = new System.Drawing.Size(74, 19);
      this.nudMilliSec.TabIndex = 22;
      // 
      // nudVolume
      // 
      this.nudVolume.Location = new System.Drawing.Point(118, 21);
      this.nudVolume.Name = "nudVolume";
      this.nudVolume.Size = new System.Drawing.Size(45, 19);
      this.nudVolume.TabIndex = 21;
      this.nudVolume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudVolume.ValueChanged += new System.EventHandler(this.nudVolume_ValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label3.Location = new System.Drawing.Point(110, 6);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(29, 12);
      this.label3.TabIndex = 20;
      this.label3.Text = "音量";
      // 
      // dtpTime
      // 
      this.dtpTime.CustomFormat = "HH:mm:ss";
      this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTime.Location = new System.Drawing.Point(240, 7);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.ShowUpDown = true;
      this.dtpTime.Size = new System.Drawing.Size(74, 19);
      this.dtpTime.TabIndex = 17;
      this.dtpTime.Value = new System.DateTime(2020, 9, 15, 0, 0, 0, 0);
      // 
      // nudCngLocationY
      // 
      this.nudCngLocationY.Location = new System.Drawing.Point(67, 22);
      this.nudCngLocationY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudCngLocationY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngLocationY.Name = "nudCngLocationY";
      this.nudCngLocationY.Size = new System.Drawing.Size(45, 19);
      this.nudCngLocationY.TabIndex = 15;
      this.nudCngLocationY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngLocationY.ValueChanged += new System.EventHandler(this.nudCngLocationY_ValueChanged);
      // 
      // nudCngLocationX
      // 
      this.nudCngLocationX.Location = new System.Drawing.Point(11, 22);
      this.nudCngLocationX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudCngLocationX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngLocationX.Name = "nudCngLocationX";
      this.nudCngLocationX.Size = new System.Drawing.Size(45, 19);
      this.nudCngLocationX.TabIndex = 14;
      this.nudCngLocationX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngLocationX.ValueChanged += new System.EventHandler(this.nudCngLocationX_ValueChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label7.Location = new System.Drawing.Point(3, 7);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(53, 12);
      this.label7.TabIndex = 13;
      this.label7.Text = "画面位置";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label8.Location = new System.Drawing.Point(54, 24);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(17, 12);
      this.label8.TabIndex = 12;
      this.label8.Text = "×";
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Location = new System.Drawing.Point(5, 84);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(355, 19);
      this.tbTgtPath.TabIndex = 10;
      this.tbTgtPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTgtPath_KeyUp);
      // 
      // nudCngSizeH
      // 
      this.nudCngSizeH.Location = new System.Drawing.Point(67, 59);
      this.nudCngSizeH.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudCngSizeH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngSizeH.Name = "nudCngSizeH";
      this.nudCngSizeH.Size = new System.Drawing.Size(45, 19);
      this.nudCngSizeH.TabIndex = 6;
      this.nudCngSizeH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngSizeH.ValueChanged += new System.EventHandler(this.nudCngSizeH_ValueChanged);
      // 
      // nudCngSizeW
      // 
      this.nudCngSizeW.Location = new System.Drawing.Point(11, 59);
      this.nudCngSizeW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
      this.nudCngSizeW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngSizeW.Name = "nudCngSizeW";
      this.nudCngSizeW.Size = new System.Drawing.Size(45, 19);
      this.nudCngSizeW.TabIndex = 5;
      this.nudCngSizeW.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudCngSizeW.ValueChanged += new System.EventHandler(this.nudCngSizeW_ValueChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label5.Location = new System.Drawing.Point(3, 44);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(58, 12);
      this.label5.TabIndex = 4;
      this.label5.Text = "画面サイズ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label2.Location = new System.Drawing.Point(54, 61);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(17, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "×";
      // 
      // tbDuration
      // 
      this.tbDuration.BackColor = System.Drawing.SystemColors.Window;
      this.tbDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbDuration.Location = new System.Drawing.Point(169, 62);
      this.tbDuration.Name = "tbDuration";
      this.tbDuration.ReadOnly = true;
      this.tbDuration.Size = new System.Drawing.Size(191, 12);
      this.tbDuration.TabIndex = 25;
      // 
      // btPauseStart
      // 
      this.btPauseStart.Location = new System.Drawing.Point(169, 7);
      this.btPauseStart.Name = "btPauseStart";
      this.btPauseStart.Size = new System.Drawing.Size(65, 45);
      this.btPauseStart.TabIndex = 8;
      this.btPauseStart.Text = "PAUSE\r\nSTART";
      this.btPauseStart.UseVisualStyleBackColor = true;
      this.btPauseStart.Click += new System.EventHandler(this.btPauseStart_Click);
      // 
      // btGoTime
      // 
      this.btGoTime.Location = new System.Drawing.Point(316, 7);
      this.btGoTime.Name = "btGoTime";
      this.btGoTime.Size = new System.Drawing.Size(44, 45);
      this.btGoTime.TabIndex = 7;
      this.btGoTime.Text = "GO!";
      this.btGoTime.UseVisualStyleBackColor = true;
      this.btGoTime.Click += new System.EventHandler(this.btGoTime_Click);
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(389, 128);
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
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOption_ComKeyDown);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudDelayedPlay)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudMilliSec)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngLocationY)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngLocationX)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngSizeH)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudCngSizeW)).EndInit();
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
    public System.Windows.Forms.NumericUpDown nudCngSizeH;
    public System.Windows.Forms.NumericUpDown nudCngSizeW;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
    private ButtonEx btGoTime;
    private ButtonEx btPauseStart;
    private System.Windows.Forms.TextBox tbTgtPath;
    public System.Windows.Forms.NumericUpDown nudCngLocationY;
    public System.Windows.Forms.NumericUpDown nudCngLocationX;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.DateTimePicker dtpTime;
    public System.Windows.Forms.NumericUpDown nudVolume;
    private System.Windows.Forms.Label label3;
    public System.Windows.Forms.NumericUpDown nudMilliSec;
    public System.Windows.Forms.NumericUpDown nudDelayedPlay;
    private System.Windows.Forms.Label label1;
    public System.Windows.Forms.TextBox tbDuration;
  }
}