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
      this.tbLeftElem = new System.Windows.Forms.TextBox();
      this.tbRightElem = new System.Windows.Forms.TextBox();
      this.btPlus = new System.Windows.Forms.Button();
      this.btMinus = new System.Windows.Forms.Button();
      this.btTimes = new System.Windows.Forms.Button();
      this.btDivided = new System.Windows.Forms.Button();
      this.tbAnswer = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // tbLeftElem
      // 
      this.tbLeftElem.Location = new System.Drawing.Point(20, 18);
      this.tbLeftElem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbLeftElem.Name = "tbLeftElem";
      this.tbLeftElem.Size = new System.Drawing.Size(104, 25);
      this.tbLeftElem.TabIndex = 0;
      this.tbLeftElem.Text = "0";
      this.tbLeftElem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // tbRightElem
      // 
      this.tbRightElem.Location = new System.Drawing.Point(138, 18);
      this.tbRightElem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbRightElem.Name = "tbRightElem";
      this.tbRightElem.Size = new System.Drawing.Size(104, 25);
      this.tbRightElem.TabIndex = 1;
      this.tbRightElem.Text = "0";
      this.tbRightElem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btPlus
      // 
      this.btPlus.Location = new System.Drawing.Point(20, 56);
      this.btPlus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btPlus.Name = "btPlus";
      this.btPlus.Size = new System.Drawing.Size(48, 34);
      this.btPlus.TabIndex = 2;
      this.btPlus.Text = "+";
      this.btPlus.UseVisualStyleBackColor = true;
      this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
      // 
      // btMinus
      // 
      this.btMinus.Location = new System.Drawing.Point(78, 56);
      this.btMinus.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btMinus.Name = "btMinus";
      this.btMinus.Size = new System.Drawing.Size(48, 34);
      this.btMinus.TabIndex = 3;
      this.btMinus.Text = "-";
      this.btMinus.UseVisualStyleBackColor = true;
      this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
      // 
      // btTimes
      // 
      this.btTimes.Location = new System.Drawing.Point(138, 56);
      this.btTimes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btTimes.Name = "btTimes";
      this.btTimes.Size = new System.Drawing.Size(48, 34);
      this.btTimes.TabIndex = 4;
      this.btTimes.Text = "×";
      this.btTimes.UseVisualStyleBackColor = true;
      this.btTimes.Click += new System.EventHandler(this.btTimes_Click);
      // 
      // btDivided
      // 
      this.btDivided.Location = new System.Drawing.Point(197, 56);
      this.btDivided.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btDivided.Name = "btDivided";
      this.btDivided.Size = new System.Drawing.Size(48, 34);
      this.btDivided.TabIndex = 5;
      this.btDivided.Text = "÷";
      this.btDivided.UseVisualStyleBackColor = true;
      this.btDivided.Click += new System.EventHandler(this.btDivided_Click);
      // 
      // tbAnswer
      // 
      this.tbAnswer.Location = new System.Drawing.Point(20, 99);
      this.tbAnswer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbAnswer.Name = "tbAnswer";
      this.tbAnswer.ReadOnly = true;
      this.tbAnswer.Size = new System.Drawing.Size(222, 25);
      this.tbAnswer.TabIndex = 6;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(263, 141);
      this.Controls.Add(this.tbAnswer);
      this.Controls.Add(this.btDivided);
      this.Controls.Add(this.btTimes);
      this.Controls.Add(this.btMinus);
      this.Controls.Add(this.btPlus);
      this.Controls.Add(this.tbRightElem);
      this.Controls.Add(this.tbLeftElem);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbLeftElem;
    private System.Windows.Forms.TextBox tbRightElem;
    private System.Windows.Forms.Button btPlus;
    private System.Windows.Forms.Button btMinus;
    private System.Windows.Forms.Button btTimes;
    private System.Windows.Forms.Button btDivided;
    private System.Windows.Forms.TextBox tbAnswer;
  }
}

