namespace WFA
{
  partial class Form1
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
      this.btStart = new System.Windows.Forms.Button();
      this.pbGifPlayer = new System.Windows.Forms.PictureBox();
      this.btStop = new System.Windows.Forms.Button();
      this.nupSlowInterval = new System.Windows.Forms.NumericUpDown();
      this.cbDefSize = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.pbGifPlayer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nupSlowInterval)).BeginInit();
      this.SuspendLayout();
      // 
      // btStart
      // 
      this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btStart.Location = new System.Drawing.Point(20, 246);
      this.btStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(125, 34);
      this.btStart.TabIndex = 1;
      this.btStart.Text = "開始";
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.btStart_Click);
      // 
      // pbGifPlayer
      // 
      this.pbGifPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pbGifPlayer.Location = new System.Drawing.Point(20, 18);
      this.pbGifPlayer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.pbGifPlayer.Name = "pbGifPlayer";
      this.pbGifPlayer.Size = new System.Drawing.Size(540, 219);
      this.pbGifPlayer.TabIndex = 2;
      this.pbGifPlayer.TabStop = false;
      this.pbGifPlayer.DoubleClick += new System.EventHandler(this.pbGifPlayer_DoubleClick);
      // 
      // btStop
      // 
      this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btStop.Location = new System.Drawing.Point(155, 246);
      this.btStop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btStop.Name = "btStop";
      this.btStop.Size = new System.Drawing.Size(125, 34);
      this.btStop.TabIndex = 3;
      this.btStop.Text = "停止";
      this.btStop.UseVisualStyleBackColor = true;
      this.btStop.Click += new System.EventHandler(this.btStop_Click);
      // 
      // nupSlowInterval
      // 
      this.nupSlowInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.nupSlowInterval.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
      this.nupSlowInterval.Location = new System.Drawing.Point(432, 246);
      this.nupSlowInterval.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.nupSlowInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
      this.nupSlowInterval.Name = "nupSlowInterval";
      this.nupSlowInterval.Size = new System.Drawing.Size(128, 25);
      this.nupSlowInterval.TabIndex = 4;
      this.nupSlowInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.nupSlowInterval.ValueChanged += new System.EventHandler(this.nupSlowInterval_ValueChanged);
      this.nupSlowInterval.Enter += new System.EventHandler(this.nupSlowInterval_ValueChanged);
      // 
      // cbDefSize
      // 
      this.cbDefSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cbDefSize.AutoSize = true;
      this.cbDefSize.Location = new System.Drawing.Point(306, 254);
      this.cbDefSize.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbDefSize.Name = "cbDefSize";
      this.cbDefSize.Size = new System.Drawing.Size(116, 22);
      this.cbDefSize.TabIndex = 5;
      this.cbDefSize.Text = "デフォサイズ";
      this.cbDefSize.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(580, 298);
      this.Controls.Add(this.cbDefSize);
      this.Controls.Add(this.nupSlowInterval);
      this.Controls.Add(this.btStop);
      this.Controls.Add(this.pbGifPlayer);
      this.Controls.Add(this.btStart);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Form1_Shown);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      ((System.ComponentModel.ISupportInitialize)(this.pbGifPlayer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nupSlowInterval)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.PictureBox pbGifPlayer;
    private System.Windows.Forms.Button btStop;
    private System.Windows.Forms.NumericUpDown nupSlowInterval;
    private System.Windows.Forms.CheckBox cbDefSize;
  }
}

