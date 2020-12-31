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
      this.btConvert = new System.Windows.Forms.Button();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.cbChcp = new System.Windows.Forms.ComboBox();
      this.tbOutPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btConvert
      // 
      this.btConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btConvert.Location = new System.Drawing.Point(529, 114);
      this.btConvert.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btConvert.Name = "btConvert";
      this.btConvert.Size = new System.Drawing.Size(163, 46);
      this.btConvert.TabIndex = 1;
      this.btConvert.Text = "変換";
      this.btConvert.UseVisualStyleBackColor = true;
      this.btConvert.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtPath.Location = new System.Drawing.Point(95, 18);
      this.tbTgtPath.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(591, 31);
      this.tbTgtPath.TabIndex = 2;
      // 
      // cbChcp
      // 
      this.cbChcp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbChcp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbChcp.FormattingEnabled = true;
      this.cbChcp.Location = new System.Drawing.Point(20, 118);
      this.cbChcp.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.cbChcp.Name = "cbChcp";
      this.cbChcp.Size = new System.Drawing.Size(167, 32);
      this.cbChcp.TabIndex = 3;
      this.cbChcp.Validated += new System.EventHandler(this.cbChcp_Validated);
      // 
      // tbOutPath
      // 
      this.tbOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbOutPath.Location = new System.Drawing.Point(95, 68);
      this.tbOutPath.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.tbOutPath.Name = "tbOutPath";
      this.tbOutPath.Size = new System.Drawing.Size(591, 31);
      this.tbOutPath.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 24);
      this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(63, 24);
      this.label1.TabIndex = 5;
      this.label1.Text = "対象:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 74);
      this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 24);
      this.label2.TabIndex = 6;
      this.label2.Text = "出力:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 174);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbOutPath);
      this.Controls.Add(this.cbChcp);
      this.Controls.Add(this.tbTgtPath);
      this.Controls.Add(this.btConvert);
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.MinimumSize = new System.Drawing.Size(728, 179);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btConvert;
    private System.Windows.Forms.TextBox tbTgtPath;
    private System.Windows.Forms.ComboBox cbChcp;
    private System.Windows.Forms.TextBox tbOutPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

