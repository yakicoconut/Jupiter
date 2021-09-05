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
      this.btExec = new System.Windows.Forms.Button();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btExec
      // 
      this.btExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btExec.Location = new System.Drawing.Point(12, 38);
      this.btExec.Name = "btExec";
      this.btExec.Size = new System.Drawing.Size(75, 23);
      this.btExec.TabIndex = 1;
      this.btExec.Text = "実行";
      this.btExec.UseVisualStyleBackColor = true;
      this.btExec.Click += new System.EventHandler(this.btExec_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtPath.Location = new System.Drawing.Point(12, 12);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTgtPath.Size = new System.Drawing.Size(304, 19);
      this.tbTgtPath.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(328, 72);
      this.Controls.Add(this.tbTgtPath);
      this.Controls.Add(this.btExec);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btExec;
    private System.Windows.Forms.TextBox tbTgtPath;
  }
}

