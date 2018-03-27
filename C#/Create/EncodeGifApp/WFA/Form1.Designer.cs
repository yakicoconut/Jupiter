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
      this.button1 = new System.Windows.Forms.Button();
      this.tbTargetPath = new System.Windows.Forms.TextBox();
      this.tbDelayTime = new System.Windows.Forms.TextBox();
      this.tbLoopCount = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(124, 90);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "実行";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbTargetPath
      // 
      this.tbTargetPath.Location = new System.Drawing.Point(73, 12);
      this.tbTargetPath.Multiline = true;
      this.tbTargetPath.Name = "tbTargetPath";
      this.tbTargetPath.Size = new System.Drawing.Size(126, 20);
      this.tbTargetPath.TabIndex = 2;
      // 
      // tbDelayTime
      // 
      this.tbDelayTime.Location = new System.Drawing.Point(124, 38);
      this.tbDelayTime.Multiline = true;
      this.tbDelayTime.Name = "tbDelayTime";
      this.tbDelayTime.Size = new System.Drawing.Size(75, 20);
      this.tbDelayTime.TabIndex = 4;
      // 
      // tbLoopCount
      // 
      this.tbLoopCount.Location = new System.Drawing.Point(124, 64);
      this.tbLoopCount.Multiline = true;
      this.tbLoopCount.Name = "tbLoopCount";
      this.tbLoopCount.Size = new System.Drawing.Size(75, 20);
      this.tbLoopCount.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 41);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 12);
      this.label1.TabIndex = 6;
      this.label1.Text = "待機時間:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(64, 12);
      this.label2.TabIndex = 7;
      this.label2.Text = "ループ回数 :";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(17, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(50, 12);
      this.label3.TabIndex = 8;
      this.label3.Text = "対象パス:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(211, 124);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbLoopCount);
      this.Controls.Add(this.tbDelayTime);
      this.Controls.Add(this.tbTargetPath);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTargetPath;
        private System.Windows.Forms.TextBox tbDelayTime;
        private System.Windows.Forms.TextBox tbLoopCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

