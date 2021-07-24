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
      this.SEventButton = new System.Windows.Forms.Button();
      this.TEventButton = new System.Windows.Forms.Button();
      this.AllEventButton = new System.Windows.Forms.Button();
      this.SAttachButton = new System.Windows.Forms.Button();
      this.TAttachButton = new System.Windows.Forms.Button();
      this.SDetachButton = new System.Windows.Forms.Button();
      this.TDetachButton = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // SEventButton
      // 
      this.SEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.SEventButton.Location = new System.Drawing.Point(13, 13);
      this.SEventButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.SEventButton.Name = "SEventButton";
      this.SEventButton.Size = new System.Drawing.Size(125, 34);
      this.SEventButton.TabIndex = 1;
      this.SEventButton.Text = "SEventButton";
      this.SEventButton.UseVisualStyleBackColor = true;
      this.SEventButton.Click += new System.EventHandler(this.SEventButton_Click);
      // 
      // TEventButton
      // 
      this.TEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.TEventButton.Location = new System.Drawing.Point(14, 55);
      this.TEventButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.TEventButton.Name = "TEventButton";
      this.TEventButton.Size = new System.Drawing.Size(125, 34);
      this.TEventButton.TabIndex = 3;
      this.TEventButton.Text = "TEventButton";
      this.TEventButton.UseVisualStyleBackColor = true;
      this.TEventButton.Click += new System.EventHandler(this.TEventButton_Click);
      // 
      // AllEventButton
      // 
      this.AllEventButton.Location = new System.Drawing.Point(14, 97);
      this.AllEventButton.Name = "AllEventButton";
      this.AllEventButton.Size = new System.Drawing.Size(125, 35);
      this.AllEventButton.TabIndex = 4;
      this.AllEventButton.Text = "AllEventButton";
      this.AllEventButton.UseVisualStyleBackColor = true;
      this.AllEventButton.Click += new System.EventHandler(this.AllEventButton_Click);
      // 
      // SAttachButton
      // 
      this.SAttachButton.Location = new System.Drawing.Point(14, 138);
      this.SAttachButton.Name = "SAttachButton";
      this.SAttachButton.Size = new System.Drawing.Size(125, 35);
      this.SAttachButton.TabIndex = 5;
      this.SAttachButton.Text = "SAttachButton";
      this.SAttachButton.UseVisualStyleBackColor = true;
      this.SAttachButton.Click += new System.EventHandler(this.SAttachButton_Click);
      // 
      // TAttachButton
      // 
      this.TAttachButton.Location = new System.Drawing.Point(13, 179);
      this.TAttachButton.Name = "TAttachButton";
      this.TAttachButton.Size = new System.Drawing.Size(125, 35);
      this.TAttachButton.TabIndex = 6;
      this.TAttachButton.Text = "TAttachButton";
      this.TAttachButton.UseVisualStyleBackColor = true;
      this.TAttachButton.Click += new System.EventHandler(this.TAttachButton_Click);
      // 
      // SDetachButton
      // 
      this.SDetachButton.Location = new System.Drawing.Point(13, 220);
      this.SDetachButton.Name = "SDetachButton";
      this.SDetachButton.Size = new System.Drawing.Size(125, 36);
      this.SDetachButton.TabIndex = 7;
      this.SDetachButton.Text = "SDetachButton";
      this.SDetachButton.UseVisualStyleBackColor = true;
      this.SDetachButton.Click += new System.EventHandler(this.SDetachButton_Click);
      // 
      // TDetachButton
      // 
      this.TDetachButton.Location = new System.Drawing.Point(13, 262);
      this.TDetachButton.Name = "TDetachButton";
      this.TDetachButton.Size = new System.Drawing.Size(124, 35);
      this.TDetachButton.TabIndex = 8;
      this.TDetachButton.Text = "TDetachButton";
      this.TDetachButton.UseVisualStyleBackColor = true;
      this.TDetachButton.Click += new System.EventHandler(this.TDetachButton_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(146, 12);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(422, 285);
      this.textBox1.TabIndex = 9;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(580, 304);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.TDetachButton);
      this.Controls.Add(this.SDetachButton);
      this.Controls.Add(this.TAttachButton);
      this.Controls.Add(this.SAttachButton);
      this.Controls.Add(this.AllEventButton);
      this.Controls.Add(this.TEventButton);
      this.Controls.Add(this.SEventButton);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "SEventButton";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SEventButton;
        private System.Windows.Forms.Button TEventButton;
    private System.Windows.Forms.Button AllEventButton;
    private System.Windows.Forms.Button SAttachButton;
    private System.Windows.Forms.Button TAttachButton;
    private System.Windows.Forms.Button SDetachButton;
    private System.Windows.Forms.Button TDetachButton;
    public System.Windows.Forms.TextBox textBox1;
  }
}

