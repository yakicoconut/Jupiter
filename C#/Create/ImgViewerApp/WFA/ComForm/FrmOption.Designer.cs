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
      this.ToolStripMenuItemFolderList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpenDir = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbChkImg = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.cbIsModePageEject = new System.Windows.Forms.CheckBox();
      this.cbIsModeZoom = new System.Windows.Forms.CheckBox();
      this.cbIsModeZeroPoint = new System.Windows.Forms.CheckBox();
      this.tbFileName = new System.Windows.Forms.TextBox();
      this.btUp = new WFA.ButtonEx();
      this.btDown = new WFA.ButtonEx();
      this.btRight = new WFA.ButtonEx();
      this.btLeft = new WFA.ButtonEx();
      this.nudUpDist = new System.Windows.Forms.NumericUpDown();
      this.nudDownDist = new System.Windows.Forms.NumericUpDown();
      this.nudRightDist = new System.Windows.Forms.NumericUpDown();
      this.nudLeftDist = new System.Windows.Forms.NumericUpDown();
      this.nudZoomInRatio = new System.Windows.Forms.NumericUpDown();
      this.nudZoomOutRatio = new System.Windows.Forms.NumericUpDown();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDownDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRightDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLeftDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomInRatio)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomOutRatio)).BeginInit();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemFolderList,
            this.toolStripMenuItemOpenDir});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(161, 70);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(160, 22);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // ToolStripMenuItemFolderList
      // 
      this.ToolStripMenuItemFolderList.Name = "ToolStripMenuItemFolderList";
      this.ToolStripMenuItemFolderList.Size = new System.Drawing.Size(160, 22);
      this.ToolStripMenuItemFolderList.Text = "ファイルリスト";
      this.ToolStripMenuItemFolderList.Click += new System.EventHandler(this.ToolStripMenuItemFileList_Click);
      // 
      // toolStripMenuItemOpenDir
      // 
      this.toolStripMenuItemOpenDir.Name = "toolStripMenuItemOpenDir";
      this.toolStripMenuItemOpenDir.Size = new System.Drawing.Size(160, 22);
      this.toolStripMenuItemOpenDir.Text = "開く";
      this.toolStripMenuItemOpenDir.Click += new System.EventHandler(this.toolStripMenuItemOpenDir_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.cbChkImg);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.cbIsModePageEject);
      this.panel1.Controls.Add(this.cbIsModeZoom);
      this.panel1.Controls.Add(this.cbIsModeZeroPoint);
      this.panel1.Controls.Add(this.tbFileName);
      this.panel1.Controls.Add(this.btUp);
      this.panel1.Controls.Add(this.btDown);
      this.panel1.Controls.Add(this.btRight);
      this.panel1.Controls.Add(this.btLeft);
      this.panel1.Controls.Add(this.nudUpDist);
      this.panel1.Controls.Add(this.nudDownDist);
      this.panel1.Controls.Add(this.nudRightDist);
      this.panel1.Controls.Add(this.nudLeftDist);
      this.panel1.Controls.Add(this.nudZoomInRatio);
      this.panel1.Controls.Add(this.nudZoomOutRatio);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(150, 412);
      this.panel1.TabIndex = 0;
      // 
      // cbChkImg
      // 
      this.cbChkImg.AutoSize = true;
      this.cbChkImg.Location = new System.Drawing.Point(20, 99);
      this.cbChkImg.Name = "cbChkImg";
      this.cbChkImg.Size = new System.Drawing.Size(63, 16);
      this.cbChkImg.TabIndex = 0;
      this.cbChkImg.TabStop = false;
      this.cbChkImg.Text = "チェック()";
      this.cbChkImg.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(3, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(41, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "MODE";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label2.Location = new System.Drawing.Point(3, 119);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(35, 12);
      this.label2.TabIndex = 0;
      this.label2.Text = "INFO";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label3.Location = new System.Drawing.Point(3, 320);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 12);
      this.label3.TabIndex = 0;
      this.label3.Text = "OPETAION";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label4.Location = new System.Drawing.Point(3, 149);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 12);
      this.label4.TabIndex = 0;
      this.label4.Text = "SET";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label5.Location = new System.Drawing.Point(18, 234);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 12);
      this.label5.TabIndex = 0;
      this.label5.Text = "移動距離";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label6.Location = new System.Drawing.Point(18, 161);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 12);
      this.label6.TabIndex = 0;
      this.label6.Text = "拡大倍率";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label7.Location = new System.Drawing.Point(20, 198);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(53, 12);
      this.label7.TabIndex = 0;
      this.label7.Text = "縮小倍率";
      // 
      // cbIsModePageEject
      // 
      this.cbIsModePageEject.AutoSize = true;
      this.cbIsModePageEject.Location = new System.Drawing.Point(20, 55);
      this.cbIsModePageEject.Name = "cbIsModePageEject";
      this.cbIsModePageEject.Size = new System.Drawing.Size(82, 16);
      this.cbIsModePageEject.TabIndex = 0;
      this.cbIsModePageEject.TabStop = false;
      this.cbIsModePageEject.Text = "ページ送り()";
      this.cbIsModePageEject.UseVisualStyleBackColor = true;
      this.cbIsModePageEject.CheckedChanged += new System.EventHandler(this.cbIsModePageEject_CheckedChanged);
      // 
      // cbIsModeZoom
      // 
      this.cbIsModeZoom.AutoSize = true;
      this.cbIsModeZoom.Location = new System.Drawing.Point(20, 33);
      this.cbIsModeZoom.Name = "cbIsModeZoom";
      this.cbIsModeZoom.Size = new System.Drawing.Size(86, 16);
      this.cbIsModeZoom.TabIndex = 0;
      this.cbIsModeZoom.TabStop = false;
      this.cbIsModeZoom.Text = "拡張/縮小()";
      this.cbIsModeZoom.UseVisualStyleBackColor = true;
      this.cbIsModeZoom.CheckedChanged += new System.EventHandler(this.cbIsModeZoom_CheckedChanged);
      // 
      // cbIsModeZeroPoint
      // 
      this.cbIsModeZeroPoint.AutoSize = true;
      this.cbIsModeZeroPoint.Location = new System.Drawing.Point(20, 77);
      this.cbIsModeZeroPoint.Name = "cbIsModeZeroPoint";
      this.cbIsModeZeroPoint.Size = new System.Drawing.Size(64, 16);
      this.cbIsModeZeroPoint.TabIndex = 0;
      this.cbIsModeZeroPoint.TabStop = false;
      this.cbIsModeZeroPoint.Text = "0Point()";
      this.cbIsModeZeroPoint.UseVisualStyleBackColor = true;
      // 
      // tbFileName
      // 
      this.tbFileName.BackColor = System.Drawing.Color.White;
      this.tbFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbFileName.ForeColor = System.Drawing.Color.Black;
      this.tbFileName.Location = new System.Drawing.Point(20, 134);
      this.tbFileName.Name = "tbFileName";
      this.tbFileName.ReadOnly = true;
      this.tbFileName.Size = new System.Drawing.Size(126, 12);
      this.tbFileName.TabIndex = 0;
      // 
      // btUp
      // 
      this.btUp.Location = new System.Drawing.Point(39, 335);
      this.btUp.Name = "btUp";
      this.btUp.Size = new System.Drawing.Size(70, 23);
      this.btUp.TabIndex = 0;
      this.btUp.Text = " ↑";
      this.btUp.UseVisualStyleBackColor = true;
      this.btUp.Click += new System.EventHandler(this.btUp_Click);
      this.btUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOption_ComKeyDown);
      // 
      // btDown
      // 
      this.btDown.Location = new System.Drawing.Point(39, 381);
      this.btDown.Name = "btDown";
      this.btDown.Size = new System.Drawing.Size(70, 23);
      this.btDown.TabIndex = 0;
      this.btDown.Text = " ↓";
      this.btDown.UseVisualStyleBackColor = true;
      this.btDown.Click += new System.EventHandler(this.btDown_Click);
      this.btDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOption_ComKeyDown);
      // 
      // btRight
      // 
      this.btRight.Location = new System.Drawing.Point(76, 358);
      this.btRight.Name = "btRight";
      this.btRight.Size = new System.Drawing.Size(70, 23);
      this.btRight.TabIndex = 0;
      this.btRight.Text = "→";
      this.btRight.UseVisualStyleBackColor = true;
      this.btRight.Click += new System.EventHandler(this.btRight_Click);
      this.btRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOption_ComKeyDown);
      // 
      // btLeft
      // 
      this.btLeft.Location = new System.Drawing.Point(3, 358);
      this.btLeft.Name = "btLeft";
      this.btLeft.Size = new System.Drawing.Size(70, 23);
      this.btLeft.TabIndex = 0;
      this.btLeft.Text = "←";
      this.btLeft.UseVisualStyleBackColor = true;
      this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
      this.btLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOption_ComKeyDown);
      // 
      // nudUpDist
      // 
      this.nudUpDist.Location = new System.Drawing.Point(50, 249);
      this.nudUpDist.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudUpDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudUpDist.Name = "nudUpDist";
      this.nudUpDist.Size = new System.Drawing.Size(52, 19);
      this.nudUpDist.TabIndex = 0;
      this.nudUpDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudUpDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudDownDist
      // 
      this.nudDownDist.Location = new System.Drawing.Point(52, 291);
      this.nudDownDist.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudDownDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDownDist.Name = "nudDownDist";
      this.nudDownDist.Size = new System.Drawing.Size(52, 19);
      this.nudDownDist.TabIndex = 0;
      this.nudDownDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDownDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudRightDist
      // 
      this.nudRightDist.Location = new System.Drawing.Point(76, 270);
      this.nudRightDist.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudRightDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudRightDist.Name = "nudRightDist";
      this.nudRightDist.Size = new System.Drawing.Size(52, 19);
      this.nudRightDist.TabIndex = 0;
      this.nudRightDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudRightDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudLeftDist
      // 
      this.nudLeftDist.Location = new System.Drawing.Point(22, 270);
      this.nudLeftDist.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudLeftDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudLeftDist.Name = "nudLeftDist";
      this.nudLeftDist.Size = new System.Drawing.Size(52, 19);
      this.nudLeftDist.TabIndex = 0;
      this.nudLeftDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudLeftDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudZoomInRatio
      // 
      this.nudZoomInRatio.DecimalPlaces = 3;
      this.nudZoomInRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.nudZoomInRatio.Location = new System.Drawing.Point(52, 176);
      this.nudZoomInRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomInRatio.Name = "nudZoomInRatio";
      this.nudZoomInRatio.Size = new System.Drawing.Size(52, 19);
      this.nudZoomInRatio.TabIndex = 0;
      this.nudZoomInRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomInRatio.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudZoomOutRatio
      // 
      this.nudZoomOutRatio.DecimalPlaces = 3;
      this.nudZoomOutRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.nudZoomOutRatio.Location = new System.Drawing.Point(52, 212);
      this.nudZoomOutRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomOutRatio.Name = "nudZoomOutRatio";
      this.nudZoomOutRatio.Size = new System.Drawing.Size(52, 19);
      this.nudZoomOutRatio.TabIndex = 0;
      this.nudZoomOutRatio.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(170, 432);
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
      ((System.ComponentModel.ISupportInitialize)(this.nudUpDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudDownDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRightDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLeftDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomInRatio)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomOutRatio)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFolderList;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDir;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    public System.Windows.Forms.CheckBox cbIsModePageEject;
    public System.Windows.Forms.CheckBox cbIsModeZoom;
    public System.Windows.Forms.CheckBox cbIsModeZeroPoint;
    public System.Windows.Forms.TextBox tbFileName;
    private ButtonEx btUp;
    private ButtonEx btDown;
    private ButtonEx btRight;
    private ButtonEx btLeft;
    public System.Windows.Forms.NumericUpDown nudZoomInRatio;
    public System.Windows.Forms.NumericUpDown nudZoomOutRatio;
    public System.Windows.Forms.NumericUpDown nudUpDist;
    public System.Windows.Forms.NumericUpDown nudDownDist;
    public System.Windows.Forms.NumericUpDown nudRightDist;
    public System.Windows.Forms.NumericUpDown nudLeftDist;
    public System.Windows.Forms.CheckBox cbChkImg;
  }
}