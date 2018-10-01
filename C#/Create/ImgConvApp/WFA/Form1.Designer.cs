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
      this.tbTargetPath = new System.Windows.Forms.TextBox();
      this.cbExtention = new System.Windows.Forms.ComboBox();
      this.tbOutputPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btConvert
      // 
      this.btConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btConvert.Location = new System.Drawing.Point(244, 57);
      this.btConvert.Name = "btConvert";
      this.btConvert.Size = new System.Drawing.Size(75, 23);
      this.btConvert.TabIndex = 1;
      this.btConvert.Text = "変換";
      this.btConvert.UseVisualStyleBackColor = true;
      this.btConvert.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbTargetPath
      // 
      this.tbTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetPath.Location = new System.Drawing.Point(44, 9);
      this.tbTargetPath.Name = "tbTargetPath";
      this.tbTargetPath.Size = new System.Drawing.Size(275, 19);
      this.tbTargetPath.TabIndex = 2;
      // 
      // cbExtention
      // 
      this.cbExtention.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.cbExtention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbExtention.FormattingEnabled = true;
      this.cbExtention.Location = new System.Drawing.Point(9, 59);
      this.cbExtention.Name = "cbExtention";
      this.cbExtention.Size = new System.Drawing.Size(79, 20);
      this.cbExtention.TabIndex = 3;
      this.cbExtention.Validated += new System.EventHandler(this.cbExtention_Validated);
      // 
      // tbOutputPath
      // 
      this.tbOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbOutputPath.Location = new System.Drawing.Point(44, 34);
      this.tbOutputPath.Name = "tbOutputPath";
      this.tbOutputPath.Size = new System.Drawing.Size(275, 19);
      this.tbOutputPath.TabIndex = 4;
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
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(334, 87);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbOutputPath);
      this.Controls.Add(this.cbExtention);
      this.Controls.Add(this.tbTargetPath);
      this.Controls.Add(this.btConvert);
      this.MinimumSize = new System.Drawing.Size(350, 125);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btConvert;
    private System.Windows.Forms.TextBox tbTargetPath;
    private System.Windows.Forms.ComboBox cbExtention;
    private System.Windows.Forms.TextBox tbOutputPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

