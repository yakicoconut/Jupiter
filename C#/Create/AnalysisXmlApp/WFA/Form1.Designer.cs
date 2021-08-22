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
      this.tbTabDsp = new System.Windows.Forms.TextBox();
      this.tbTgtPath = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.tbSearchKeySpr = new System.Windows.Forms.TextBox();
      this.cbDigMode = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btCreate = new System.Windows.Forms.Button();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tbRsltDsp = new System.Windows.Forms.TextBox();
      this.cbIsOutFileName = new System.Windows.Forms.CheckBox();
      this.cbIsOutVal = new System.Windows.Forms.CheckBox();
      this.cbIsOutAttr = new System.Windows.Forms.CheckBox();
      this.cbIsHeader = new System.Windows.Forms.CheckBox();
      this.cbIsTab = new System.Windows.Forms.CheckBox();
      this.cbIsNoting = new System.Windows.Forms.CheckBox();
      this.cbIsUseSearchKeySpr = new System.Windows.Forms.CheckBox();
      this.cbIsOutKeyName = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btDig
      // 
      this.btDig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btDig.Location = new System.Drawing.Point(469, 438);
      this.btDig.Name = "btDig";
      this.btDig.Size = new System.Drawing.Size(75, 23);
      this.btDig.TabIndex = 1;
      this.btDig.Text = "探索";
      this.btDig.UseVisualStyleBackColor = true;
      this.btDig.Click += new System.EventHandler(this.btDig_Click);
      // 
      // tbTabDsp
      // 
      this.tbTabDsp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTabDsp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbTabDsp.Location = new System.Drawing.Point(3, 3);
      this.tbTabDsp.Multiline = true;
      this.tbTabDsp.Name = "tbTabDsp";
      this.tbTabDsp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTabDsp.Size = new System.Drawing.Size(241, 322);
      this.tbTabDsp.TabIndex = 2;
      this.tbTabDsp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Com_DspTextbox_KeyDown);
      // 
      // tbTgtPath
      // 
      this.tbTgtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTgtPath.Location = new System.Drawing.Point(46, 12);
      this.tbTgtPath.Name = "tbTgtPath";
      this.tbTgtPath.Size = new System.Drawing.Size(501, 19);
      this.tbTgtPath.TabIndex = 4;
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
      // tbSearchKeySpr
      // 
      this.tbSearchKeySpr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSearchKeySpr.Location = new System.Drawing.Point(46, 37);
      this.tbSearchKeySpr.Name = "tbSearchKeySpr";
      this.tbSearchKeySpr.Size = new System.Drawing.Size(501, 19);
      this.tbSearchKeySpr.TabIndex = 6;
      // 
      // cbDigMode
      // 
      this.cbDigMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbDigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDigMode.FormattingEnabled = true;
      this.cbDigMode.Location = new System.Drawing.Point(426, 61);
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
      this.btCreate.Location = new System.Drawing.Point(12, 438);
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
      this.splitContainer1.Panel1.Controls.Add(this.tbTabDsp);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tbRsltDsp);
      this.splitContainer1.Size = new System.Drawing.Size(535, 328);
      this.splitContainer1.SplitterDistance = 247;
      this.splitContainer1.SplitterWidth = 10;
      this.splitContainer1.TabIndex = 10;
      // 
      // tbRsltDsp
      // 
      this.tbRsltDsp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbRsltDsp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbRsltDsp.Location = new System.Drawing.Point(5, 3);
      this.tbRsltDsp.Multiline = true;
      this.tbRsltDsp.Name = "tbRsltDsp";
      this.tbRsltDsp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbRsltDsp.Size = new System.Drawing.Size(258, 322);
      this.tbRsltDsp.TabIndex = 3;
      this.tbRsltDsp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Com_DspTextbox_KeyDown);
      // 
      // cbIsOutFileName
      // 
      this.cbIsOutFileName.AutoSize = true;
      this.cbIsOutFileName.Checked = true;
      this.cbIsOutFileName.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsOutFileName.Location = new System.Drawing.Point(46, 63);
      this.cbIsOutFileName.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsOutFileName.Name = "cbIsOutFileName";
      this.cbIsOutFileName.Size = new System.Drawing.Size(70, 16);
      this.cbIsOutFileName.TabIndex = 11;
      this.cbIsOutFileName.Text = "ファイル名";
      this.cbIsOutFileName.UseVisualStyleBackColor = true;
      // 
      // cbIsOutVal
      // 
      this.cbIsOutVal.AutoSize = true;
      this.cbIsOutVal.Checked = true;
      this.cbIsOutVal.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsOutVal.Location = new System.Drawing.Point(117, 83);
      this.cbIsOutVal.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsOutVal.Name = "cbIsOutVal";
      this.cbIsOutVal.Size = new System.Drawing.Size(36, 16);
      this.cbIsOutVal.TabIndex = 12;
      this.cbIsOutVal.Text = "値";
      this.cbIsOutVal.UseVisualStyleBackColor = true;
      // 
      // cbIsOutAttr
      // 
      this.cbIsOutAttr.AutoSize = true;
      this.cbIsOutAttr.Checked = true;
      this.cbIsOutAttr.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsOutAttr.Location = new System.Drawing.Point(181, 83);
      this.cbIsOutAttr.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsOutAttr.Name = "cbIsOutAttr";
      this.cbIsOutAttr.Size = new System.Drawing.Size(48, 16);
      this.cbIsOutAttr.TabIndex = 13;
      this.cbIsOutAttr.Text = "属性";
      this.cbIsOutAttr.UseVisualStyleBackColor = true;
      // 
      // cbIsHeader
      // 
      this.cbIsHeader.AutoSize = true;
      this.cbIsHeader.Location = new System.Drawing.Point(117, 63);
      this.cbIsHeader.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsHeader.Name = "cbIsHeader";
      this.cbIsHeader.Size = new System.Drawing.Size(60, 16);
      this.cbIsHeader.TabIndex = 14;
      this.cbIsHeader.Text = "ヘッダー";
      this.cbIsHeader.UseVisualStyleBackColor = true;
      // 
      // cbIsTab
      // 
      this.cbIsTab.AutoSize = true;
      this.cbIsTab.Checked = true;
      this.cbIsTab.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsTab.Location = new System.Drawing.Point(46, 83);
      this.cbIsTab.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsTab.Name = "cbIsTab";
      this.cbIsTab.Size = new System.Drawing.Size(41, 16);
      this.cbIsTab.TabIndex = 15;
      this.cbIsTab.Text = "タブ";
      this.cbIsTab.UseVisualStyleBackColor = true;
      // 
      // cbIsNoting
      // 
      this.cbIsNoting.AutoSize = true;
      this.cbIsNoting.Checked = true;
      this.cbIsNoting.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsNoting.Location = new System.Drawing.Point(181, 63);
      this.cbIsNoting.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsNoting.Name = "cbIsNoting";
      this.cbIsNoting.Size = new System.Drawing.Size(67, 16);
      this.cbIsNoting.TabIndex = 16;
      this.cbIsNoting.Text = "対象なし";
      this.cbIsNoting.UseVisualStyleBackColor = true;
      // 
      // cbIsUseSearchKeySpr
      // 
      this.cbIsUseSearchKeySpr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbIsUseSearchKeySpr.AutoSize = true;
      this.cbIsUseSearchKeySpr.Checked = true;
      this.cbIsUseSearchKeySpr.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsUseSearchKeySpr.Location = new System.Drawing.Point(426, 86);
      this.cbIsUseSearchKeySpr.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsUseSearchKeySpr.Name = "cbIsUseSearchKeySpr";
      this.cbIsUseSearchKeySpr.Size = new System.Drawing.Size(91, 16);
      this.cbIsUseSearchKeySpr.TabIndex = 17;
      this.cbIsUseSearchKeySpr.Text = "複数Key「{0}」";
      this.cbIsUseSearchKeySpr.UseVisualStyleBackColor = true;
      // 
      // cbIsOutKeyName
      // 
      this.cbIsOutKeyName.AutoSize = true;
      this.cbIsOutKeyName.Location = new System.Drawing.Point(252, 63);
      this.cbIsOutKeyName.Margin = new System.Windows.Forms.Padding(2);
      this.cbIsOutKeyName.Name = "cbIsOutKeyName";
      this.cbIsOutKeyName.Size = new System.Drawing.Size(68, 16);
      this.cbIsOutKeyName.TabIndex = 18;
      this.cbIsOutKeyName.Text = "キー名称";
      this.cbIsOutKeyName.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(559, 473);
      this.Controls.Add(this.cbIsOutKeyName);
      this.Controls.Add(this.cbIsUseSearchKeySpr);
      this.Controls.Add(this.cbIsNoting);
      this.Controls.Add(this.cbIsTab);
      this.Controls.Add(this.cbIsHeader);
      this.Controls.Add(this.cbIsOutAttr);
      this.Controls.Add(this.cbIsOutVal);
      this.Controls.Add(this.cbIsOutFileName);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cbDigMode);
      this.Controls.Add(this.btCreate);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.tbSearchKeySpr);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tbTgtPath);
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
    private System.Windows.Forms.TextBox tbTabDsp;
    private System.Windows.Forms.TextBox tbTgtPath;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbSearchKeySpr;
    private System.Windows.Forms.Button btCreate;
    private System.Windows.Forms.ComboBox cbDigMode;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox tbRsltDsp;
    private System.Windows.Forms.CheckBox cbIsOutFileName;
    private System.Windows.Forms.CheckBox cbIsOutVal;
    private System.Windows.Forms.CheckBox cbIsOutAttr;
    private System.Windows.Forms.CheckBox cbIsHeader;
    private System.Windows.Forms.CheckBox cbIsTab;
    private System.Windows.Forms.CheckBox cbIsNoting;
    private System.Windows.Forms.CheckBox cbIsUseSearchKeySpr;
    private System.Windows.Forms.CheckBox cbIsOutKeyName;
  }
}

