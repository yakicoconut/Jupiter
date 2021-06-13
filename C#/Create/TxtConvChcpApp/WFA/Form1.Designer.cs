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
      this.cbSrcChcp = new System.Windows.Forms.ComboBox();
      this.tbOutPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cbDestChcp = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btConvert
      // 
      this.btConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btConvert.Location = new System.Drawing.Point(239, 57);
      this.btConvert.Name = "btConvert";
      this.btConvert.Size = new System.Drawing.Size(75, 23);
      this.btConvert.TabIndex = 1;
      this.btConvert.Text = "変換";
      this.btConvert.UseVisualStyleBackColor = true;
      this.btConvert.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtPath.Location = new System.Drawing.Point(44, 9);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(270, 19);
      this.tbTgtPath.TabIndex = 2;
      // 
      // cbSrcChcp
      // 
      this.cbSrcChcp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbSrcChcp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSrcChcp.FormattingEnabled = true;
      this.cbSrcChcp.Location = new System.Drawing.Point(9, 59);
      this.cbSrcChcp.Name = "cbSrcChcp";
      this.cbSrcChcp.Size = new System.Drawing.Size(79, 20);
      this.cbSrcChcp.TabIndex = 3;
      // 
      // tbOutPath
      // 
      this.tbOutPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbOutPath.Location = new System.Drawing.Point(44, 34);
      this.tbOutPath.Name = "tbOutPath";
      this.tbOutPath.Size = new System.Drawing.Size(270, 19);
      this.tbOutPath.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 12);
      this.label1.TabIndex = 5;
      this.label1.Text = "対象:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(31, 12);
      this.label2.TabIndex = 6;
      this.label2.Text = "出力:";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(94, 62);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(17, 12);
      this.label3.TabIndex = 7;
      this.label3.Text = "→";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // cbDestChcp
      // 
      this.cbDestChcp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbDestChcp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDestChcp.FormattingEnabled = true;
      this.cbDestChcp.Location = new System.Drawing.Point(117, 59);
      this.cbDestChcp.Name = "cbDestChcp";
      this.cbDestChcp.Size = new System.Drawing.Size(79, 20);
      this.cbDestChcp.TabIndex = 8;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(329, 87);
      this.Controls.Add(this.cbDestChcp);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbOutPath);
      this.Controls.Add(this.cbSrcChcp);
      this.Controls.Add(this.tbTgtPath);
      this.Controls.Add(this.btConvert);
      this.MinimumSize = new System.Drawing.Size(345, 109);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btConvert;
    private System.Windows.Forms.TextBox tbTgtPath;
    private System.Windows.Forms.ComboBox cbSrcChcp;
    private System.Windows.Forms.TextBox tbOutPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cbDestChcp;
  }
}

