namespace WFA
{
  partial class FrmTgtFrame
  {
    /// <summary>
    /// 必要なデザイナー変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 使用中のリソースをすべてクリーンアップします。
    /// </summary>
    /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows フォーム デザイナーで生成されたコード

    /// <summary>
    /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディターで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.rbLeftTop = new System.Windows.Forms.RadioButton();
      this.rbRightBottom = new System.Windows.Forms.RadioButton();
      this.lbHorizonDist = new System.Windows.Forms.Label();
      this.lbVerticalDist = new System.Windows.Forms.Label();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemPointTest = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // rbLeftTop
      // 
      this.rbLeftTop.AutoSize = true;
      this.rbLeftTop.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.rbLeftTop.Location = new System.Drawing.Point(12, 12);
      this.rbLeftTop.Name = "rbLeftTop";
      this.rbLeftTop.Size = new System.Drawing.Size(14, 13);
      this.rbLeftTop.TabIndex = 0;
      this.rbLeftTop.TabStop = true;
      this.rbLeftTop.UseVisualStyleBackColor = true;
      // 
      // rbRightBottom
      // 
      this.rbRightBottom.AutoSize = true;
      this.rbRightBottom.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.rbRightBottom.Location = new System.Drawing.Point(12, 31);
      this.rbRightBottom.Name = "rbRightBottom";
      this.rbRightBottom.Size = new System.Drawing.Size(14, 13);
      this.rbRightBottom.TabIndex = 1;
      this.rbRightBottom.TabStop = true;
      this.rbRightBottom.UseVisualStyleBackColor = true;
      // 
      // lbHorizonDist
      // 
      this.lbHorizonDist.AutoSize = true;
      this.lbHorizonDist.Location = new System.Drawing.Point(42, 55);
      this.lbHorizonDist.Name = "lbHorizonDist";
      this.lbHorizonDist.Size = new System.Drawing.Size(35, 12);
      this.lbHorizonDist.TabIndex = 2;
      this.lbHorizonDist.Text = "label1";
      // 
      // lbVerticalDist
      // 
      this.lbVerticalDist.AutoSize = true;
      this.lbVerticalDist.Location = new System.Drawing.Point(12, 67);
      this.lbVerticalDist.Name = "lbVerticalDist";
      this.lbVerticalDist.Size = new System.Drawing.Size(35, 12);
      this.lbVerticalDist.TabIndex = 3;
      this.lbVerticalDist.Text = "label1";
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemPointTest,
            this.toolStripMenuItemClose});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
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
      // toolStripMenuItemClose
      // 
      this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
      this.toolStripMenuItemClose.Size = new System.Drawing.Size(122, 22);
      this.toolStripMenuItemClose.Text = "閉じる";
      this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
      // 
      // ポイントテストToolStripMenuItem
      // 
      this.ToolStripMenuItemPointTest.Name = "ポイントテストToolStripMenuItem";
      this.ToolStripMenuItemPointTest.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemPointTest.Text = "ポイントテスト";
      this.ToolStripMenuItemPointTest.Click += new System.EventHandler(this.ToolStripMenuItemPointTest_Click);
      // 
      // FrmTgtFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.lbVerticalDist);
      this.Controls.Add(this.lbHorizonDist);
      this.Controls.Add(this.rbRightBottom);
      this.Controls.Add(this.rbLeftTop);
      this.Name = "FrmTgtFrame";
      this.Text = "FrmTgtFrame";
      this.Load += new System.EventHandler(this.FrmTgtFrame_Load);
      this.Shown += new System.EventHandler(this.FrmTgtFrame_Shown);
      this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmTgtFrame_MouseDoubleClick);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RadioButton rbLeftTop;
    private System.Windows.Forms.RadioButton rbRightBottom;
    private System.Windows.Forms.Label lbHorizonDist;
    private System.Windows.Forms.Label lbVerticalDist;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPointTest;
  }
}