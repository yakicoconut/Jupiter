﻿namespace WFA
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
          this.textBox1 = new System.Windows.Forms.TextBox();
          this.button2 = new System.Windows.Forms.Button();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(11, 400);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 1;
          this.button1.Text = "button1";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // textBox1
          // 
          this.textBox1.Location = new System.Drawing.Point(11, 428);
          this.textBox1.Multiline = true;
          this.textBox1.Name = "textBox1";
          this.textBox1.Size = new System.Drawing.Size(329, 24);
          this.textBox1.TabIndex = 2;
          // 
          // button2
          // 
          this.button2.Location = new System.Drawing.Point(92, 400);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(75, 23);
          this.button2.TabIndex = 3;
          this.button2.Text = "button2";
          this.button2.UseVisualStyleBackColor = true;
          // 
          // Form1
          // 
          this.AllowDrop = true;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Control;
          this.ClientSize = new System.Drawing.Size(499, 461);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.textBox1);
          this.Controls.Add(this.button1);
          this.Name = "Form1";
          this.Text = "Form1";
          this.Shown += new System.EventHandler(this.Form1_Shown);
          this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
          this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
  }


