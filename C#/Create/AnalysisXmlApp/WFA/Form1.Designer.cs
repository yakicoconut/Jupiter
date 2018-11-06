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
      this.btDig = new System.Windows.Forms.Button();
      this.tbTabDisplay = new System.Windows.Forms.TextBox();
      this.tbTargetPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbTargetKey = new System.Windows.Forms.TextBox();
      this.cbDigMode = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btCreate = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tbResultDisplay = new System.Windows.Forms.TextBox();
      this.cbOutFileName = new System.Windows.Forms.CheckBox();
      this.cbOutValue = new System.Windows.Forms.CheckBox();
      this.cbOutAttr = new System.Windows.Forms.CheckBox();
      this.cbHeader = new System.Windows.Forms.CheckBox();
      this.cbTab = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btDig
      // 
      this.btDig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btDig.Location = new System.Drawing.Point(12, 438);
      this.btDig.Name = "btDig";
      this.btDig.Size = new System.Drawing.Size(75, 23);
      this.btDig.TabIndex = 1;
      this.btDig.Text = "探索";
      this.btDig.UseVisualStyleBackColor = true;
      this.btDig.Click += new System.EventHandler(this.btDig_Click);
      // 
      // tbTabDisplay
      // 
      this.tbTabDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTabDisplay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbTabDisplay.Location = new System.Drawing.Point(3, 3);
      this.tbTabDisplay.Multiline = true;
      this.tbTabDisplay.Name = "tbTabDisplay";
      this.tbTabDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTabDisplay.Size = new System.Drawing.Size(241, 322);
      this.tbTabDisplay.TabIndex = 2;
      // 
      // tbTargetPath
      // 
      this.tbTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetPath.Location = new System.Drawing.Point(46, 12);
      this.tbTargetPath.Name = "tbTargetPath";
      this.tbTargetPath.Size = new System.Drawing.Size(499, 19);
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
      this.tbTargetKey.Size = new System.Drawing.Size(499, 19);
      this.tbTargetKey.TabIndex = 6;
      // 
      // cbDigMode
      // 
      this.cbDigMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbDigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDigMode.FormattingEnabled = true;
      this.cbDigMode.Location = new System.Drawing.Point(426, 62);
      this.cbDigMode.Name = "cbDigMode";
      this.cbDigMode.Size = new System.Drawing.Size(121, 20);
      this.cbDigMode.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(369, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(51, 12);
      this.label3.TabIndex = 9;
      this.label3.Text = "DigMode:";
      // 
      // btCreate
      // 
      this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCreate.Location = new System.Drawing.Point(93, 438);
      this.btCreate.Name = "btCreate";
      this.btCreate.Size = new System.Drawing.Size(75, 23);
      this.btCreate.TabIndex = 8;
      this.btCreate.Text = "作成";
      this.btCreate.UseVisualStyleBackColor = true;
      this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(12, 104);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tbTabDisplay);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tbResultDisplay);
      this.splitContainer1.Size = new System.Drawing.Size(533, 328);
      this.splitContainer1.SplitterDistance = 247;
      this.splitContainer1.SplitterWidth = 10;
      this.splitContainer1.TabIndex = 10;
      // 
      // tbResultDisplay
      // 
      this.tbResultDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbResultDisplay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbResultDisplay.Location = new System.Drawing.Point(5, 3);
      this.tbResultDisplay.Multiline = true;
      this.tbResultDisplay.Name = "tbResultDisplay";
      this.tbResultDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbResultDisplay.Size = new System.Drawing.Size(242, 322);
      this.tbResultDisplay.TabIndex = 3;
      // 
      // cbOutFileName
      // 
      this.cbOutFileName.AutoSize = true;
      this.cbOutFileName.Checked = true;
      this.cbOutFileName.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutFileName.Location = new System.Drawing.Point(46, 63);
      this.cbOutFileName.Margin = new System.Windows.Forms.Padding(2);
      this.cbOutFileName.Name = "cbOutFileName";
      this.cbOutFileName.Size = new System.Drawing.Size(70, 16);
      this.cbOutFileName.TabIndex = 11;
      this.cbOutFileName.Text = "ファイル名";
      this.cbOutFileName.UseVisualStyleBackColor = true;
      // 
      // cbOutValue
      // 
      this.cbOutValue.AutoSize = true;
      this.cbOutValue.Checked = true;
      this.cbOutValue.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutValue.Location = new System.Drawing.Point(117, 63);
      this.cbOutValue.Margin = new System.Windows.Forms.Padding(2);
      this.cbOutValue.Name = "cbOutValue";
      this.cbOutValue.Size = new System.Drawing.Size(36, 16);
      this.cbOutValue.TabIndex = 12;
      this.cbOutValue.Text = "値";
      this.cbOutValue.UseVisualStyleBackColor = true;
      // 
      // cbOutAttr
      // 
      this.cbOutAttr.AutoSize = true;
      this.cbOutAttr.Checked = true;
      this.cbOutAttr.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutAttr.Location = new System.Drawing.Point(151, 63);
      this.cbOutAttr.Margin = new System.Windows.Forms.Padding(2);
      this.cbOutAttr.Name = "cbOutAttr";
      this.cbOutAttr.Size = new System.Drawing.Size(48, 16);
      this.cbOutAttr.TabIndex = 13;
      this.cbOutAttr.Text = "属性";
      this.cbOutAttr.UseVisualStyleBackColor = true;
      // 
      // cbHeader
      // 
      this.cbHeader.AutoSize = true;
      this.cbHeader.Location = new System.Drawing.Point(46, 83);
      this.cbHeader.Margin = new System.Windows.Forms.Padding(2);
      this.cbHeader.Name = "cbHeader";
      this.cbHeader.Size = new System.Drawing.Size(60, 16);
      this.cbHeader.TabIndex = 14;
      this.cbHeader.Text = "ヘッダー";
      this.cbHeader.UseVisualStyleBackColor = true;
      // 
      // cbTab
      // 
      this.cbTab.AutoSize = true;
      this.cbTab.Checked = true;
      this.cbTab.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbTab.Location = new System.Drawing.Point(117, 83);
      this.cbTab.Margin = new System.Windows.Forms.Padding(2);
      this.cbTab.Name = "cbTab";
      this.cbTab.Size = new System.Drawing.Size(41, 16);
      this.cbTab.TabIndex = 15;
      this.cbTab.Text = "タブ";
      this.cbTab.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(559, 473);
      this.Controls.Add(this.cbTab);
      this.Controls.Add(this.cbHeader);
      this.Controls.Add(this.cbOutAttr);
      this.Controls.Add(this.cbOutValue);
      this.Controls.Add(this.cbOutFileName);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbDigMode);
      this.Controls.Add(this.btCreate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbTargetKey);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbTargetPath);
      this.Controls.Add(this.btDig);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btDig;
    private System.Windows.Forms.TextBox tbTabDisplay;
    private System.Windows.Forms.TextBox tbTargetPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbTargetKey;
    private System.Windows.Forms.Button btCreate;
    private System.Windows.Forms.ComboBox cbDigMode;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox tbResultDisplay;
    private System.Windows.Forms.CheckBox cbOutFileName;
    private System.Windows.Forms.CheckBox cbOutValue;
    private System.Windows.Forms.CheckBox cbOutAttr;
    private System.Windows.Forms.CheckBox cbHeader;
    private System.Windows.Forms.CheckBox cbTab;
  }
}

