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
          this.lbDefaultOpenEncode = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // lbDefaultOpenEncode
          // 
          this.lbDefaultOpenEncode.AutoSize = true;
          this.lbDefaultOpenEncode.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
          this.lbDefaultOpenEncode.Location = new System.Drawing.Point(12, 9);
          this.lbDefaultOpenEncode.Name = "lbDefaultOpenEncode";
          this.lbDefaultOpenEncode.Size = new System.Drawing.Size(82, 24);
          this.lbDefaultOpenEncode.TabIndex = 0;
          this.lbDefaultOpenEncode.Text = "label1";
          // 
          // Form1
          // 
          this.AllowDrop = true;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Control;
          this.ClientSize = new System.Drawing.Size(1184, 767);
          this.Controls.Add(this.lbDefaultOpenEncode);
          this.Name = "Form1";
          this.Text = "Form1";
          this.Shown += new System.EventHandler(this.Form1_Shown);
          this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
          this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDefaultOpenEncode;
    }
  }

