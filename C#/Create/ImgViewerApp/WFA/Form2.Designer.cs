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
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.不透明度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.上げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.下げToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.nudDownDist = new System.Windows.Forms.NumericUpDown();
      this.nudRightDist = new System.Windows.Forms.NumericUpDown();
      this.nudLeftDist = new System.Windows.Forms.NumericUpDown();
      this.nudUpDist = new System.Windows.Forms.NumericUpDown();
      this.nudZoomOutRatio = new System.Windows.Forms.NumericUpDown();
      this.nudZoomInRatio = new System.Windows.Forms.NumericUpDown();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.byDown = new System.Windows.Forms.Button();
      this.btUp = new System.Windows.Forms.Button();
      this.btRight = new System.Windows.Forms.Button();
      this.btLeft = new System.Windows.Forms.Button();
      this.tbFileName = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.cbIsModeZeroPoint = new System.Windows.Forms.CheckBox();
      this.cbIsModeZoom = new System.Windows.Forms.CheckBox();
      this.cbIsModePageEject = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudDownDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRightDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLeftDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpDist)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomOutRatio)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomInRatio)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.ContextMenuStrip = this.contextMenuStrip1;
      this.panel1.Controls.Add(this.nudDownDist);
      this.panel1.Controls.Add(this.nudRightDist);
      this.panel1.Controls.Add(this.nudLeftDist);
      this.panel1.Controls.Add(this.nudUpDist);
      this.panel1.Controls.Add(this.nudZoomOutRatio);
      this.panel1.Controls.Add(this.nudZoomInRatio);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
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
      this.panel1.Size = new System.Drawing.Size(149, 384);
      this.panel1.TabIndex = 1;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.不透明度ToolStripMenuItem,
            this.開くToolStripMenuItem});
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
      // 開くToolStripMenuItem
      // 
      this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
      this.開くToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.開くToolStripMenuItem.Text = "開く";
      this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
      // 
      // nudDownDist
      // 
      this.nudDownDist.Location = new System.Drawing.Point(52, 268);
      this.nudDownDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDownDist.Name = "nudDownDist";
      this.nudDownDist.Size = new System.Drawing.Size(52, 19);
      this.nudDownDist.TabIndex = 26;
      this.nudDownDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudDownDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudRightDist
      // 
      this.nudRightDist.Location = new System.Drawing.Point(76, 247);
      this.nudRightDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudRightDist.Name = "nudRightDist";
      this.nudRightDist.Size = new System.Drawing.Size(52, 19);
      this.nudRightDist.TabIndex = 25;
      this.nudRightDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudRightDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudLeftDist
      // 
      this.nudLeftDist.Location = new System.Drawing.Point(22, 247);
      this.nudLeftDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudLeftDist.Name = "nudLeftDist";
      this.nudLeftDist.Size = new System.Drawing.Size(52, 19);
      this.nudLeftDist.TabIndex = 24;
      this.nudLeftDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudLeftDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudUpDist
      // 
      this.nudUpDist.Location = new System.Drawing.Point(50, 226);
      this.nudUpDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudUpDist.Name = "nudUpDist";
      this.nudUpDist.Size = new System.Drawing.Size(52, 19);
      this.nudUpDist.TabIndex = 23;
      this.nudUpDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudUpDist.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudZoomOutRatio
      // 
      this.nudZoomOutRatio.DecimalPlaces = 3;
      this.nudZoomOutRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.nudZoomOutRatio.Location = new System.Drawing.Point(52, 189);
      this.nudZoomOutRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomOutRatio.Name = "nudZoomOutRatio";
      this.nudZoomOutRatio.Size = new System.Drawing.Size(52, 19);
      this.nudZoomOutRatio.TabIndex = 22;
      this.nudZoomOutRatio.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // nudZoomInRatio
      // 
      this.nudZoomInRatio.DecimalPlaces = 3;
      this.nudZoomInRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
      this.nudZoomInRatio.Location = new System.Drawing.Point(52, 153);
      this.nudZoomInRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomInRatio.Name = "nudZoomInRatio";
      this.nudZoomInRatio.Size = new System.Drawing.Size(52, 19);
      this.nudZoomInRatio.TabIndex = 21;
      this.nudZoomInRatio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudZoomInRatio.ValueChanged += new System.EventHandler(this.Common_tb_ValueChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label7.Location = new System.Drawing.Point(20, 175);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(53, 12);
      this.label7.TabIndex = 19;
      this.label7.Text = "縮小倍率";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label6.Location = new System.Drawing.Point(18, 138);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 12);
      this.label6.TabIndex = 17;
      this.label6.Text = "拡大倍率";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label5.Location = new System.Drawing.Point(18, 211);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(53, 12);
      this.label5.TabIndex = 13;
      this.label5.Text = "移動距離";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label4.Location = new System.Drawing.Point(3, 126);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 12);
      this.label4.TabIndex = 12;
      this.label4.Text = "SET";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label3.Location = new System.Drawing.Point(3, 297);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 12);
      this.label3.TabIndex = 10;
      this.label3.Text = "OPETAION";
      // 
      // byDown
      // 
      this.byDown.Location = new System.Drawing.Point(39, 358);
      this.byDown.Name = "byDown";
      this.byDown.Size = new System.Drawing.Size(70, 23);
      this.byDown.TabIndex = 9;
      this.byDown.Text = " ↓";
      this.byDown.UseVisualStyleBackColor = true;
      this.byDown.Click += new System.EventHandler(this.byDown_Click);
      // 
      // btUp
      // 
      this.btUp.Location = new System.Drawing.Point(39, 312);
      this.btUp.Name = "btUp";
      this.btUp.Size = new System.Drawing.Size(70, 23);
      this.btUp.TabIndex = 8;
      this.btUp.Text = " ↑";
      this.btUp.UseVisualStyleBackColor = true;
      this.btUp.Click += new System.EventHandler(this.btUp_Click);
      // 
      // btRight
      // 
      this.btRight.Location = new System.Drawing.Point(76, 335);
      this.btRight.Name = "btRight";
      this.btRight.Size = new System.Drawing.Size(70, 23);
      this.btRight.TabIndex = 7;
      this.btRight.Text = "→";
      this.btRight.UseVisualStyleBackColor = true;
      this.btRight.Click += new System.EventHandler(this.btRight_Click);
      // 
      // btLeft
      // 
      this.btLeft.Location = new System.Drawing.Point(3, 335);
      this.btLeft.Name = "btLeft";
      this.btLeft.Size = new System.Drawing.Size(70, 23);
      this.btLeft.TabIndex = 6;
      this.btLeft.Text = "←";
      this.btLeft.UseVisualStyleBackColor = true;
      this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
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
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(173, 408);
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
      ((System.ComponentModel.ISupportInitialize)(this.nudDownDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRightDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudLeftDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudUpDist)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomOutRatio)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudZoomInRatio)).EndInit();
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
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
    public System.Windows.Forms.NumericUpDown nudZoomInRatio;
    public System.Windows.Forms.NumericUpDown nudZoomOutRatio;
    public System.Windows.Forms.NumericUpDown nudDownDist;
    public System.Windows.Forms.NumericUpDown nudRightDist;
    public System.Windows.Forms.NumericUpDown nudLeftDist;
    public System.Windows.Forms.NumericUpDown nudUpDist;
  }
}