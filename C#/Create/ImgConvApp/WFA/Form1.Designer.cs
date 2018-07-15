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
      this.tbTargetFolder = new System.Windows.Forms.TextBox();
      this.cbExtention = new System.Windows.Forms.ComboBox();
      this.SuspendLayout();
      // 
      // btConvert
      // 
      this.btConvert.Location = new System.Drawing.Point(303, 43);
      this.btConvert.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btConvert.Name = "btConvert";
      this.btConvert.Size = new System.Drawing.Size(125, 34);
      this.btConvert.TabIndex = 1;
      this.btConvert.Text = "変換";
      this.btConvert.UseVisualStyleBackColor = true;
      this.btConvert.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbTargetFolder
      // 
      this.tbTargetFolder.Location = new System.Drawing.Point(14, 13);
      this.tbTargetFolder.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbTargetFolder.Name = "tbTargetFolder";
      this.tbTargetFolder.Size = new System.Drawing.Size(414, 25);
      this.tbTargetFolder.TabIndex = 2;
      // 
      // cbExtention
      // 
      this.cbExtention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbExtention.FormattingEnabled = true;
      this.cbExtention.Location = new System.Drawing.Point(14, 51);
      this.cbExtention.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbExtention.Name = "cbExtention";
      this.cbExtention.Size = new System.Drawing.Size(122, 26);
      this.cbExtention.TabIndex = 3;
      this.cbExtention.Validated += new System.EventHandler(this.comboBox1_Validated);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(445, 97);
      this.Controls.Add(this.cbExtention);
      this.Controls.Add(this.tbTargetFolder);
      this.Controls.Add(this.btConvert);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btConvert;
    private System.Windows.Forms.TextBox tbTargetFolder;
    private System.Windows.Forms.ComboBox cbExtention;
  }
}

