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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.btStart = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
      this.btStyle = new System.Windows.Forms.Button();
      this.btGetTime = new System.Windows.Forms.Button();
      this.lbTime = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
      this.SuspendLayout();
      // 
      // btStart
      // 
      this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btStart.Location = new System.Drawing.Point(12, 320);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(56, 23);
      this.btStart.TabIndex = 1;
      this.btStart.Text = "Start";
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.btStart_Click);
      // 
      // textBox1
      // 
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Location = new System.Drawing.Point(12, 12);
      this.textBox1.Name = "textBox1";
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox1.Size = new System.Drawing.Size(555, 19);
      this.textBox1.TabIndex = 2;
      // 
      // axWindowsMediaPlayer1
      // 
      this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.axWindowsMediaPlayer1.Enabled = true;
      this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 36);
      this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
      this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
      this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
      this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(557, 279);
      this.axWindowsMediaPlayer1.TabIndex = 3;
      // 
      // btStyle
      // 
      this.btStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btStyle.Location = new System.Drawing.Point(74, 320);
      this.btStyle.Name = "btStyle";
      this.btStyle.Size = new System.Drawing.Size(52, 23);
      this.btStyle.TabIndex = 4;
      this.btStyle.Text = "Style";
      this.btStyle.UseVisualStyleBackColor = true;
      this.btStyle.Click += new System.EventHandler(this.btStyle_Click);
      // 
      // btGetTime
      // 
      this.btGetTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btGetTime.Location = new System.Drawing.Point(132, 320);
      this.btGetTime.Name = "btGetTime";
      this.btGetTime.Size = new System.Drawing.Size(60, 23);
      this.btGetTime.TabIndex = 5;
      this.btGetTime.Text = "GetTime";
      this.btGetTime.UseVisualStyleBackColor = true;
      this.btGetTime.Click += new System.EventHandler(this.btGetTime_Click);
      // 
      // lbTime
      // 
      this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lbTime.AutoSize = true;
      this.lbTime.Location = new System.Drawing.Point(198, 325);
      this.lbTime.Name = "lbTime";
      this.lbTime.Size = new System.Drawing.Size(65, 12);
      this.lbTime.TabIndex = 6;
      this.lbTime.Text = "00:00:00.000";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(579, 355);
      this.Controls.Add(this.lbTime);
      this.Controls.Add(this.btGetTime);
      this.Controls.Add(this.btStyle);
      this.Controls.Add(this.axWindowsMediaPlayer1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.btStart);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.TextBox textBox1;
    private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    private System.Windows.Forms.Button btStyle;
    private System.Windows.Forms.Button btGetTime;
    private System.Windows.Forms.Label lbTime;
  }
}

