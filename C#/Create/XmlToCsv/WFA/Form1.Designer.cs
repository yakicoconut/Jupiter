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
      this.btXmlToCsv = new System.Windows.Forms.Button();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.btRestoreCsv = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btXmlToCsv
      // 
      this.btXmlToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btXmlToCsv.Location = new System.Drawing.Point(26, 72);
      this.btXmlToCsv.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btXmlToCsv.Name = "btXmlToCsv";
      this.btXmlToCsv.Size = new System.Drawing.Size(163, 46);
      this.btXmlToCsv.TabIndex = 1;
      this.btXmlToCsv.Text = "CSV出力";
      this.btXmlToCsv.UseVisualStyleBackColor = true;
      this.btXmlToCsv.Click += new System.EventHandler(this.btXmlToCsv_Click);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtPath.Location = new System.Drawing.Point(26, 24);
      this.tbTgtPath.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTgtPath.Size = new System.Drawing.Size(654, 31);
      this.tbTgtPath.TabIndex = 2;
      // 
      // btRestoreCsv
      // 
      this.btRestoreCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btRestoreCsv.Location = new System.Drawing.Point(202, 72);
      this.btRestoreCsv.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.btRestoreCsv.Name = "btRestoreCsv";
      this.btRestoreCsv.Size = new System.Drawing.Size(163, 46);
      this.btRestoreCsv.TabIndex = 3;
      this.btRestoreCsv.Text = "XML復元";
      this.btRestoreCsv.UseVisualStyleBackColor = true;
      this.btRestoreCsv.Click += new System.EventHandler(this.btRestoreCsv_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(711, 140);
      this.Controls.Add(this.btRestoreCsv);
      this.Controls.Add(this.tbTgtPath);
      this.Controls.Add(this.btXmlToCsv);
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btXmlToCsv;
    private System.Windows.Forms.TextBox tbTgtPath;
    private System.Windows.Forms.Button btRestoreCsv;
  }
}

