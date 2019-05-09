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
      this.btOnOff = new System.Windows.Forms.Button();
      this.tbReadOnly = new System.Windows.Forms.TextBox();
      this.tbInsStr = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbInsPosition = new System.Windows.Forms.TextBox();
      this.cbIsStrFormat = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btOnOff
      // 
      this.btOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btOnOff.Location = new System.Drawing.Point(12, 160);
      this.btOnOff.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btOnOff.Name = "btOnOff";
      this.btOnOff.Size = new System.Drawing.Size(125, 34);
      this.btOnOff.TabIndex = 1;
      this.btOnOff.UseVisualStyleBackColor = true;
      this.btOnOff.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbReadOnly
      // 
      this.tbReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbReadOnly.Location = new System.Drawing.Point(12, 12);
      this.tbReadOnly.Multiline = true;
      this.tbReadOnly.Name = "tbReadOnly";
      this.tbReadOnly.ReadOnly = true;
      this.tbReadOnly.Size = new System.Drawing.Size(283, 25);
      this.tbReadOnly.TabIndex = 2;
      this.tbReadOnly.TextChanged += new System.EventHandler(this.tbReadOnly_TextChanged);
      // 
      // tbInsStr
      // 
      this.tbInsStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbInsStr.Location = new System.Drawing.Point(107, 117);
      this.tbInsStr.Name = "tbInsStr";
      this.tbInsStr.Size = new System.Drawing.Size(188, 25);
      this.tbInsStr.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(12, 83);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 18);
      this.label1.TabIndex = 5;
      this.label1.Text = "挿入位置:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label2.Location = new System.Drawing.Point(12, 120);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 18);
      this.label2.TabIndex = 6;
      this.label2.Text = "挿入文字:";
      // 
      // tbInsPosition
      // 
      this.tbInsPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbInsPosition.Location = new System.Drawing.Point(107, 83);
      this.tbInsPosition.Name = "tbInsPosition";
      this.tbInsPosition.Size = new System.Drawing.Size(188, 25);
      this.tbInsPosition.TabIndex = 7;
      // 
      // cbIsStrFormat
      // 
      this.cbIsStrFormat.AutoSize = true;
      this.cbIsStrFormat.Location = new System.Drawing.Point(12, 43);
      this.cbIsStrFormat.Name = "cbIsStrFormat";
      this.cbIsStrFormat.Size = new System.Drawing.Size(106, 22);
      this.cbIsStrFormat.TabIndex = 8;
      this.cbIsStrFormat.Text = "書式指定";
      this.cbIsStrFormat.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(307, 207);
      this.Controls.Add(this.cbIsStrFormat);
      this.Controls.Add(this.tbInsPosition);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbInsStr);
      this.Controls.Add(this.tbReadOnly);
      this.Controls.Add(this.btOnOff);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOnOff;
    private System.Windows.Forms.TextBox tbReadOnly;
    private System.Windows.Forms.TextBox tbInsStr;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbInsPosition;
    private System.Windows.Forms.CheckBox cbIsStrFormat;
  }
}

