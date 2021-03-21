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
      this.lbInsPos = new System.Windows.Forms.Label();
      this.lbInsStr = new System.Windows.Forms.Label();
      this.tbInsPos = new System.Windows.Forms.TextBox();
      this.cbIsStrFｍtMode = new System.Windows.Forms.CheckBox();
      this.cbIsRepMode = new System.Windows.Forms.CheckBox();
      this.tbColl = new System.Windows.Forms.TextBox();
      this.cbColl = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // btOnOff
      // 
      this.btOnOff.Location = new System.Drawing.Point(7, 123);
      this.btOnOff.Name = "btOnOff";
      this.btOnOff.Size = new System.Drawing.Size(75, 23);
      this.btOnOff.TabIndex = 1;
      this.btOnOff.UseVisualStyleBackColor = true;
      this.btOnOff.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbReadOnly
      // 
      this.tbReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbReadOnly.Location = new System.Drawing.Point(7, 8);
      this.tbReadOnly.Margin = new System.Windows.Forms.Padding(2);
      this.tbReadOnly.Multiline = true;
      this.tbReadOnly.Name = "tbReadOnly";
      this.tbReadOnly.ReadOnly = true;
      this.tbReadOnly.Size = new System.Drawing.Size(131, 18);
      this.tbReadOnly.TabIndex = 2;
      this.tbReadOnly.TextChanged += new System.EventHandler(this.tbReadOnly_TextChanged);
      // 
      // tbInsStr
      // 
      this.tbInsStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbInsStr.Location = new System.Drawing.Point(71, 99);
      this.tbInsStr.Margin = new System.Windows.Forms.Padding(2);
      this.tbInsStr.Name = "tbInsStr";
      this.tbInsStr.Size = new System.Drawing.Size(67, 19);
      this.tbInsStr.TabIndex = 4;
      // 
      // lbInsPos
      // 
      this.lbInsPos.AutoSize = true;
      this.lbInsPos.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.lbInsPos.Location = new System.Drawing.Point(7, 77);
      this.lbInsPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lbInsPos.Name = "lbInsPos";
      this.lbInsPos.Size = new System.Drawing.Size(60, 12);
      this.lbInsPos.TabIndex = 5;
      this.lbInsPos.Text = "挿入位置:";
      // 
      // lbInsStr
      // 
      this.lbInsStr.AutoSize = true;
      this.lbInsStr.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.lbInsStr.Location = new System.Drawing.Point(7, 102);
      this.lbInsStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.lbInsStr.Name = "lbInsStr";
      this.lbInsStr.Size = new System.Drawing.Size(60, 12);
      this.lbInsStr.TabIndex = 6;
      this.lbInsStr.Text = "挿入文字:";
      // 
      // tbInsPos
      // 
      this.tbInsPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbInsPos.Location = new System.Drawing.Point(71, 74);
      this.tbInsPos.Margin = new System.Windows.Forms.Padding(2);
      this.tbInsPos.Name = "tbInsPos";
      this.tbInsPos.Size = new System.Drawing.Size(67, 19);
      this.tbInsPos.TabIndex = 7;
      // 
      // cbIsStrFｍtMode
      // 
      this.cbIsStrFｍtMode.AutoSize = true;
      this.cbIsStrFｍtMode.Location = new System.Drawing.Point(7, 29);
      this.cbIsStrFｍtMode.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsStrFｍtMode.Name = "cbIsStrFｍtMode";
      this.cbIsStrFｍtMode.Size = new System.Drawing.Size(72, 16);
      this.cbIsStrFｍtMode.TabIndex = 8;
      this.cbIsStrFｍtMode.Text = "書式指定";
      this.cbIsStrFｍtMode.UseVisualStyleBackColor = true;
      this.cbIsStrFｍtMode.CheckedChanged += new System.EventHandler(this.cbIsStrFｍtMode_CheckedChanged);
      // 
      // cbIsRepMode
      // 
      this.cbIsRepMode.AutoSize = true;
      this.cbIsRepMode.Location = new System.Drawing.Point(74, 29);
      this.cbIsRepMode.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsRepMode.Name = "cbIsRepMode";
      this.cbIsRepMode.Size = new System.Drawing.Size(66, 16);
      this.cbIsRepMode.TabIndex = 9;
      this.cbIsRepMode.Text = "置き換え";
      this.cbIsRepMode.UseVisualStyleBackColor = true;
      this.cbIsRepMode.CheckedChanged += new System.EventHandler(this.cbIsRepMode_CheckedChanged);
      // 
      // tbColl
      // 
      this.tbColl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbColl.Location = new System.Drawing.Point(7, 151);
      this.tbColl.Margin = new System.Windows.Forms.Padding(2);
      this.tbColl.Multiline = true;
      this.tbColl.Name = "tbColl";
      this.tbColl.Size = new System.Drawing.Size(131, 119);
      this.tbColl.TabIndex = 10;
      this.tbColl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbColl_KeyDown);
      // 
      // cbColl
      // 
      this.cbColl.AutoSize = true;
      this.cbColl.Location = new System.Drawing.Point(7, 49);
      this.cbColl.Margin = new System.Windows.Forms.Padding(2);
      this.cbColl.Name = "cbColl";
      this.cbColl.Size = new System.Drawing.Size(48, 16);
      this.cbColl.TabIndex = 11;
      this.cbColl.Text = "採取";
      this.cbColl.UseVisualStyleBackColor = true;
      this.cbColl.CheckedChanged += new System.EventHandler(this.cbColl_CheckedChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(144, 281);
      this.Controls.Add(this.cbColl);
      this.Controls.Add(this.tbColl);
      this.Controls.Add(this.cbIsRepMode);
      this.Controls.Add(this.cbIsStrFｍtMode);
      this.Controls.Add(this.tbInsPos);
      this.Controls.Add(this.lbInsStr);
      this.Controls.Add(this.lbInsPos);
      this.Controls.Add(this.tbInsStr);
      this.Controls.Add(this.tbReadOnly);
      this.Controls.Add(this.btOnOff);
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
    private System.Windows.Forms.Label lbInsPos;
    private System.Windows.Forms.Label lbInsStr;
    private System.Windows.Forms.TextBox tbInsPos;
    private System.Windows.Forms.CheckBox cbIsStrFｍtMode;
    private System.Windows.Forms.CheckBox cbIsRepMode;
    private System.Windows.Forms.TextBox tbColl;
    private System.Windows.Forms.CheckBox cbColl;
  }
}

