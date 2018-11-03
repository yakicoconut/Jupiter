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
      this.cbOutType = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btDig
      // 
      this.btDig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btDig.Location = new System.Drawing.Point(20, 657);
      this.btDig.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btDig.Name = "btDig";
      this.btDig.Size = new System.Drawing.Size(125, 34);
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
      this.tbTabDisplay.Location = new System.Drawing.Point(5, 4);
      this.tbTabDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbTabDisplay.Multiline = true;
      this.tbTabDisplay.Name = "tbTabDisplay";
      this.tbTabDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbTabDisplay.Size = new System.Drawing.Size(401, 505);
      this.tbTabDisplay.TabIndex = 2;
      // 
      // tbTargetPath
      // 
      this.tbTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetPath.Location = new System.Drawing.Point(77, 18);
      this.tbTargetPath.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbTargetPath.Name = "tbTargetPath";
      this.tbTargetPath.Size = new System.Drawing.Size(829, 25);
      this.tbTargetPath.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(17, 22);
      this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(47, 18);
      this.label1.TabIndex = 5;
      this.label1.Text = "Path:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(17, 60);
      this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 18);
      this.label2.TabIndex = 7;
      this.label2.Text = "Key:";
      // 
      // tbTargetKey
      // 
      this.tbTargetKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetKey.Location = new System.Drawing.Point(77, 56);
      this.tbTargetKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbTargetKey.Name = "tbTargetKey";
      this.tbTargetKey.Size = new System.Drawing.Size(829, 25);
      this.tbTargetKey.TabIndex = 6;
      // 
      // cbDigMode
      // 
      this.cbDigMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbDigMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbDigMode.FormattingEnabled = true;
      this.cbDigMode.Location = new System.Drawing.Point(710, 93);
      this.cbDigMode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.cbDigMode.Name = "cbDigMode";
      this.cbDigMode.Size = new System.Drawing.Size(199, 26);
      this.cbDigMode.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(615, 98);
      this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(76, 18);
      this.label3.TabIndex = 9;
      this.label3.Text = "DigMode:";
      // 
      // btCreate
      // 
      this.btCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCreate.Location = new System.Drawing.Point(155, 657);
      this.btCreate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btCreate.Name = "btCreate";
      this.btCreate.Size = new System.Drawing.Size(125, 34);
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
      this.splitContainer1.Location = new System.Drawing.Point(20, 132);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tbTabDisplay);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tbResultDisplay);
      this.splitContainer1.Size = new System.Drawing.Size(888, 516);
      this.splitContainer1.SplitterDistance = 413;
      this.splitContainer1.SplitterWidth = 17;
      this.splitContainer1.TabIndex = 10;
      // 
      // tbResultDisplay
      // 
      this.tbResultDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbResultDisplay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F);
      this.tbResultDisplay.Location = new System.Drawing.Point(8, 4);
      this.tbResultDisplay.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.tbResultDisplay.Multiline = true;
      this.tbResultDisplay.Name = "tbResultDisplay";
      this.tbResultDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbResultDisplay.Size = new System.Drawing.Size(432, 505);
      this.tbResultDisplay.TabIndex = 3;
      // 
      // cbOutFileName
      // 
      this.cbOutFileName.AutoSize = true;
      this.cbOutFileName.Checked = true;
      this.cbOutFileName.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutFileName.Location = new System.Drawing.Point(77, 94);
      this.cbOutFileName.Name = "cbOutFileName";
      this.cbOutFileName.Size = new System.Drawing.Size(103, 22);
      this.cbOutFileName.TabIndex = 11;
      this.cbOutFileName.Text = "ファイル名";
      this.cbOutFileName.UseVisualStyleBackColor = true;
      // 
      // cbOutValue
      // 
      this.cbOutValue.AutoSize = true;
      this.cbOutValue.Checked = true;
      this.cbOutValue.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutValue.Location = new System.Drawing.Point(311, 95);
      this.cbOutValue.Name = "cbOutValue";
      this.cbOutValue.Size = new System.Drawing.Size(52, 22);
      this.cbOutValue.TabIndex = 12;
      this.cbOutValue.Text = "値";
      this.cbOutValue.UseVisualStyleBackColor = true;
      // 
      // cbOutAttr
      // 
      this.cbOutAttr.AutoSize = true;
      this.cbOutAttr.Checked = true;
      this.cbOutAttr.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbOutAttr.Location = new System.Drawing.Point(369, 95);
      this.cbOutAttr.Name = "cbOutAttr";
      this.cbOutAttr.Size = new System.Drawing.Size(70, 22);
      this.cbOutAttr.TabIndex = 13;
      this.cbOutAttr.Text = "属性";
      this.cbOutAttr.UseVisualStyleBackColor = true;
      // 
      // cbOutType
      // 
      this.cbOutType.AutoSize = true;
      this.cbOutType.Location = new System.Drawing.Point(186, 94);
      this.cbOutType.Name = "cbOutType";
      this.cbOutType.Size = new System.Drawing.Size(109, 22);
      this.cbOutType.TabIndex = 14;
      this.cbOutType.Text = "要素タイプ";
      this.cbOutType.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(932, 710);
      this.Controls.Add(this.cbOutType);
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
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
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
    private System.Windows.Forms.CheckBox cbOutType;
  }
}

