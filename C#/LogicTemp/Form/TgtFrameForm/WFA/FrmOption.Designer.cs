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
      this.ToolStripMenuItemOpacityTransparent = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbCapFileEx = new System.Windows.Forms.ComboBox();
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.cbPreviewBackColor = new System.Windows.Forms.ComboBox();
      this.cbIsMove = new System.Windows.Forms.CheckBox();
      this.btDown = new System.Windows.Forms.Button();
      this.btRight = new System.Windows.Forms.Button();
      this.btLeft = new System.Windows.Forms.Button();
      this.btUp = new System.Windows.Forms.Button();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.nudMoveDist = new System.Windows.Forms.NumericUpDown();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lbTestPoint = new System.Windows.Forms.Label();
      this.lbVerticalDist = new System.Windows.Forms.Label();
      this.lbHorizonDist = new System.Windows.Forms.Label();
      this.rbRightBottom = new System.Windows.Forms.RadioButton();
      this.rbLeftTop = new System.Windows.Forms.RadioButton();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudMoveDist)).BeginInit();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(166, 34);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec,
            this.ToolStripMenuItemOpacityTransparent});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(165, 30);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(129, 30);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(129, 30);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // ToolStripMenuItemOpacityTransparent
      // 
      this.ToolStripMenuItemOpacityTransparent.Name = "ToolStripMenuItemOpacityTransparent";
      this.ToolStripMenuItemOpacityTransparent.Size = new System.Drawing.Size(129, 30);
      this.ToolStripMenuItemOpacityTransparent.Text = "透明";
      this.ToolStripMenuItemOpacityTransparent.Click += new System.EventHandler(this.ToolStripMenuItemOpacityTransparent_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.ContextMenuStrip = this.contextMenuStrip1;
      this.panel1.Controls.Add(this.cbCapFileEx);
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.cbPreviewBackColor);
      this.panel1.Controls.Add(this.cbIsMove);
      this.panel1.Controls.Add(this.btDown);
      this.panel1.Controls.Add(this.btRight);
      this.panel1.Controls.Add(this.btLeft);
      this.panel1.Controls.Add(this.btUp);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.nudMoveDist);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.lbTestPoint);
      this.panel1.Controls.Add(this.lbVerticalDist);
      this.panel1.Controls.Add(this.lbHorizonDist);
      this.panel1.Controls.Add(this.rbRightBottom);
      this.panel1.Controls.Add(this.rbLeftTop);
      this.panel1.Location = new System.Drawing.Point(17, 15);
      this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(250, 598);
      this.panel1.TabIndex = 1;
      // 
      // cbCapFileEx
      // 
      this.cbCapFileEx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbCapFileEx.FormattingEnabled = true;
      this.cbCapFileEx.Location = new System.Drawing.Point(40, 306);
      this.cbCapFileEx.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbCapFileEx.Name = "cbCapFileEx";
      this.cbCapFileEx.Size = new System.Drawing.Size(199, 26);
      this.cbCapFileEx.TabIndex = 23;
      this.cbCapFileEx.SelectedIndexChanged += new System.EventHandler(this.cbCapFileEx_SelectedIndexChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label9.Location = new System.Drawing.Point(17, 284);
      this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(162, 18);
      this.label9.TabIndex = 22;
      this.label9.Text = "キャプチャファイル種類";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label8.Location = new System.Drawing.Point(17, 220);
      this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(115, 18);
      this.label8.TabIndex = 19;
      this.label8.Text = "プレビュ境界色";
      // 
      // cbPreviewBackColor
      // 
      this.cbPreviewBackColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPreviewBackColor.FormattingEnabled = true;
      this.cbPreviewBackColor.Location = new System.Drawing.Point(40, 243);
      this.cbPreviewBackColor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbPreviewBackColor.Name = "cbPreviewBackColor";
      this.cbPreviewBackColor.Size = new System.Drawing.Size(199, 26);
      this.cbPreviewBackColor.TabIndex = 18;
      this.cbPreviewBackColor.SelectedIndexChanged += new System.EventHandler(this.cbReviewBackColor_SelectedIndexChanged);
      // 
      // cbIsMove
      // 
      this.cbIsMove.AutoSize = true;
      this.cbIsMove.Checked = true;
      this.cbIsMove.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsMove.Location = new System.Drawing.Point(18, 377);
      this.cbIsMove.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbIsMove.Name = "cbIsMove";
      this.cbIsMove.Size = new System.Drawing.Size(70, 22);
      this.cbIsMove.TabIndex = 17;
      this.cbIsMove.Text = "移動";
      this.cbIsMove.UseVisualStyleBackColor = true;
      // 
      // btDown
      // 
      this.btDown.Location = new System.Drawing.Point(73, 554);
      this.btDown.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btDown.Name = "btDown";
      this.btDown.Size = new System.Drawing.Size(105, 30);
      this.btDown.TabIndex = 16;
      this.btDown.Text = "↓";
      this.btDown.UseVisualStyleBackColor = true;
      this.btDown.Click += new System.EventHandler(this.btDown_Click);
      // 
      // btRight
      // 
      this.btRight.Location = new System.Drawing.Point(127, 524);
      this.btRight.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btRight.Name = "btRight";
      this.btRight.Size = new System.Drawing.Size(105, 30);
      this.btRight.TabIndex = 15;
      this.btRight.Text = "→";
      this.btRight.UseVisualStyleBackColor = true;
      this.btRight.Click += new System.EventHandler(this.btRight_Click);
      // 
      // btLeft
      // 
      this.btLeft.Location = new System.Drawing.Point(23, 524);
      this.btLeft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btLeft.Name = "btLeft";
      this.btLeft.Size = new System.Drawing.Size(105, 30);
      this.btLeft.TabIndex = 14;
      this.btLeft.Text = "←";
      this.btLeft.UseVisualStyleBackColor = true;
      this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
      // 
      // btUp
      // 
      this.btUp.Location = new System.Drawing.Point(73, 494);
      this.btUp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btUp.Name = "btUp";
      this.btUp.Size = new System.Drawing.Size(105, 30);
      this.btUp.TabIndex = 13;
      this.btUp.Text = "↑";
      this.btUp.UseVisualStyleBackColor = true;
      this.btUp.Click += new System.EventHandler(this.btUp_Click);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label7.Location = new System.Drawing.Point(15, 472);
      this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(44, 18);
      this.label7.TabIndex = 12;
      this.label7.Text = "調整";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label6.Location = new System.Drawing.Point(5, 345);
      this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(113, 18);
      this.label6.TabIndex = 11;
      this.label6.Text = "OPERATION";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label5.Location = new System.Drawing.Point(15, 414);
      this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(80, 18);
      this.label5.TabIndex = 10;
      this.label5.Text = "移動距離";
      // 
      // nudMoveDist
      // 
      this.nudMoveDist.Location = new System.Drawing.Point(35, 436);
      this.nudMoveDist.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.nudMoveDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.nudMoveDist.Name = "nudMoveDist";
      this.nudMoveDist.Size = new System.Drawing.Size(133, 25);
      this.nudMoveDist.TabIndex = 9;
      this.nudMoveDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label4.Location = new System.Drawing.Point(5, 192);
      this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(43, 18);
      this.label4.TabIndex = 8;
      this.label4.Text = "SET";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label3.Location = new System.Drawing.Point(17, 146);
      this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(103, 18);
      this.label3.TabIndex = 7;
      this.label3.Text = "テストポイント";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label2.Location = new System.Drawing.Point(17, 33);
      this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "始点/終点";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(5, 15);
      this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(51, 18);
      this.label1.TabIndex = 5;
      this.label1.Text = "INFO";
      // 
      // lbTestPoint
      // 
      this.lbTestPoint.AutoSize = true;
      this.lbTestPoint.Location = new System.Drawing.Point(37, 168);
      this.lbTestPoint.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lbTestPoint.Name = "lbTestPoint";
      this.lbTestPoint.Size = new System.Drawing.Size(52, 18);
      this.lbTestPoint.TabIndex = 4;
      this.lbTestPoint.Text = "label3";
      // 
      // lbVerticalDist
      // 
      this.lbVerticalDist.AutoSize = true;
      this.lbVerticalDist.Location = new System.Drawing.Point(115, 128);
      this.lbVerticalDist.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lbVerticalDist.Name = "lbVerticalDist";
      this.lbVerticalDist.Size = new System.Drawing.Size(52, 18);
      this.lbVerticalDist.TabIndex = 3;
      this.lbVerticalDist.Text = "label2";
      // 
      // lbHorizonDist
      // 
      this.lbHorizonDist.AutoSize = true;
      this.lbHorizonDist.Location = new System.Drawing.Point(65, 112);
      this.lbHorizonDist.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lbHorizonDist.Name = "lbHorizonDist";
      this.lbHorizonDist.Size = new System.Drawing.Size(52, 18);
      this.lbHorizonDist.TabIndex = 2;
      this.lbHorizonDist.Text = "label1";
      // 
      // rbRightBottom
      // 
      this.rbRightBottom.AutoSize = true;
      this.rbRightBottom.Location = new System.Drawing.Point(40, 88);
      this.rbRightBottom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.rbRightBottom.Name = "rbRightBottom";
      this.rbRightBottom.Size = new System.Drawing.Size(21, 20);
      this.rbRightBottom.TabIndex = 1;
      this.rbRightBottom.TabStop = true;
      this.rbRightBottom.UseVisualStyleBackColor = true;
      // 
      // rbLeftTop
      // 
      this.rbLeftTop.AutoSize = true;
      this.rbLeftTop.Location = new System.Drawing.Point(40, 56);
      this.rbLeftTop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.rbLeftTop.Name = "rbLeftTop";
      this.rbLeftTop.Size = new System.Drawing.Size(21, 20);
      this.rbLeftTop.TabIndex = 0;
      this.rbLeftTop.TabStop = true;
      this.rbLeftTop.UseVisualStyleBackColor = true;
      this.rbLeftTop.CheckedChanged += new System.EventHandler(this.rbLeftTop_CheckedChanged);
      // 
      // FrmOption
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(283, 626);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
      ((System.ComponentModel.ISupportInitialize)(this.nudMoveDist)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.RadioButton rbLeftTop;
    private System.Windows.Forms.RadioButton rbRightBottom;
    private System.Windows.Forms.Label lbVerticalDist;
    private System.Windows.Forms.Label lbHorizonDist;
    private System.Windows.Forms.Label lbTestPoint;
    private System.Windows.Forms.CheckBox cbIsMove;
    private System.Windows.Forms.Button btDown;
    private System.Windows.Forms.Button btRight;
    private System.Windows.Forms.Button btLeft;
    private System.Windows.Forms.Button btUp;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.NumericUpDown nudMoveDist;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label8;
    public System.Windows.Forms.ComboBox cbPreviewBackColor;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpacityTransparent;
    public System.Windows.Forms.ComboBox cbCapFileEx;
    private System.Windows.Forms.Label label9;
  }
}