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
      this.btDig = new System.Windows.Forms.Button();
      this.tbDisplay = new System.Windows.Forms.TextBox();
      this.tbTargetPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbTargetKey = new System.Windows.Forms.TextBox();
      this.cbDigMode = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btCreate = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btDig
      // 
      this.btDig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btDig.Location = new System.Drawing.Point(12, 301);
      this.btDig.Name = "btDig";
      this.btDig.Size = new System.Drawing.Size(75, 23);
      this.btDig.TabIndex = 1;
      this.btDig.Text = "探索";
      this.btDig.UseVisualStyleBackColor = true;
      this.btDig.Click += new System.EventHandler(this.btDig_Click);
      // 
      // tbDisplay
      // 
      this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbDisplay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbDisplay.Location = new System.Drawing.Point(12, 88);
      this.tbDisplay.Multiline = true;
      this.tbDisplay.Name = "tbDisplay";
      this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbDisplay.Size = new System.Drawing.Size(417, 207);
      this.tbDisplay.TabIndex = 2;
      // 
      // tbTargetPath
      // 
      this.tbTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetPath.Location = new System.Drawing.Point(46, 12);
      this.tbTargetPath.Name = "tbTargetPath";
      this.tbTargetPath.Size = new System.Drawing.Size(381, 19);
      this.tbTargetPath.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 12);
      this.label1.TabIndex = 5;
      this.label1.Text = "Path:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 40);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 12);
      this.label2.TabIndex = 7;
      this.label2.Text = "Key:";
      // 
      // tbTargetKey
      // 
      this.tbTargetKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetKey.Location = new System.Drawing.Point(46, 37);
      this.tbTargetKey.Name = "tbTargetKey";
      this.tbTargetKey.Size = new System.Drawing.Size(381, 19);
      this.tbTargetKey.TabIndex = 6;
      // 
      // cbDigMode
      // 
      this.cbDigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDigMode.FormattingEnabled = true;
      this.cbDigMode.Location = new System.Drawing.Point(308, 62);
      this.cbDigMode.Name = "cbDigMode";
      this.cbDigMode.Size = new System.Drawing.Size(121, 20);
      this.cbDigMode.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(251, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 12);
      this.label3.TabIndex = 9;
      this.label3.Text = "DigMode:";
      // 
      // btCreate
      // 
      this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCreate.Location = new System.Drawing.Point(93, 301);
      this.btCreate.Name = "btCreate";
      this.btCreate.Size = new System.Drawing.Size(75, 23);
      this.btCreate.TabIndex = 8;
      this.btCreate.Text = "作成";
      this.btCreate.UseVisualStyleBackColor = true;
      this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(441, 336);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbDigMode);
      this.Controls.Add(this.btCreate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbTargetKey);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbTargetPath);
      this.Controls.Add(this.tbDisplay);
      this.Controls.Add(this.btDig);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btDig;
    private System.Windows.Forms.TextBox tbDisplay;
    private System.Windows.Forms.TextBox tbTargetPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbTargetKey;
    private System.Windows.Forms.Button btCreate;
    private System.Windows.Forms.ComboBox cbDigMode;
    private System.Windows.Forms.Label label3;
  }
}

