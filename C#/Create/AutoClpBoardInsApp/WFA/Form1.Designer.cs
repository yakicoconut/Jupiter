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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.btOnOff = new System.Windows.Forms.Button();
      this.tbColl = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.cbIsReSendMode = new System.Windows.Forms.CheckBox();
      this.cbIsCollMode = new System.Windows.Forms.CheckBox();
      this.label3 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.lbOnOff = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.cbIsNewLine = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.panel4 = new System.Windows.Forms.Panel();
      this.tbRegStr = new System.Windows.Forms.TextBox();
      this.tbRepStr = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItem不透明度 = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem不透明度上げ = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem不透明度下げ = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem最前面 = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel4.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btOnOff
      // 
      this.btOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btOnOff.Location = new System.Drawing.Point(3, 26);
      this.btOnOff.Name = "btOnOff";
      this.btOnOff.Size = new System.Drawing.Size(75, 23);
      this.btOnOff.TabIndex = 1;
      this.btOnOff.Text = "ON/OFF";
      this.btOnOff.UseVisualStyleBackColor = true;
      this.btOnOff.Click += new System.EventHandler(this.btOnOff_Click);
      // 
      // tbColl
      // 
      this.tbColl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbColl.Location = new System.Drawing.Point(12, 201);
      this.tbColl.Multiline = true;
      this.tbColl.Name = "tbColl";
      this.tbColl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbColl.Size = new System.Drawing.Size(162, 93);
      this.tbColl.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.cbIsReSendMode);
      this.panel1.Controls.Add(this.cbIsCollMode);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(162, 70);
      this.panel1.TabIndex = 5;
      // 
      // cbIsReSendMode
      // 
      this.cbIsReSendMode.AutoSize = true;
      this.cbIsReSendMode.Location = new System.Drawing.Point(94, 28);
      this.cbIsReSendMode.Name = "cbIsReSendMode";
      this.cbIsReSendMode.Size = new System.Drawing.Size(60, 16);
      this.cbIsReSendMode.TabIndex = 6;
      this.cbIsReSendMode.Text = "再登録";
      this.cbIsReSendMode.UseVisualStyleBackColor = true;
      // 
      // cbIsCollMode
      // 
      this.cbIsCollMode.AutoSize = true;
      this.cbIsCollMode.Checked = true;
      this.cbIsCollMode.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsCollMode.Location = new System.Drawing.Point(94, 6);
      this.cbIsCollMode.Name = "cbIsCollMode";
      this.cbIsCollMode.Size = new System.Drawing.Size(48, 16);
      this.cbIsCollMode.TabIndex = 5;
      this.cbIsCollMode.Text = "採取";
      this.cbIsCollMode.UseVisualStyleBackColor = true;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(8, 6);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(49, 12);
      this.label3.TabIndex = 8;
      this.label3.Text = "ON/OFF";
      // 
      // panel3
      // 
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.lbOnOff);
      this.panel3.Controls.Add(this.btOnOff);
      this.panel3.Location = new System.Drawing.Point(5, 12);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(83, 54);
      this.panel3.TabIndex = 9;
      // 
      // lbOnOff
      // 
      this.lbOnOff.AutoSize = true;
      this.lbOnOff.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.lbOnOff.Location = new System.Drawing.Point(29, 8);
      this.lbOnOff.Name = "lbOnOff";
      this.lbOnOff.Size = new System.Drawing.Size(26, 13);
      this.lbOnOff.TabIndex = 2;
      this.lbOnOff.Text = "ON";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 6);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(32, 12);
      this.label1.TabIndex = 5;
      this.label1.Text = "Mode";
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.cbIsNewLine);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Controls.Add(this.panel4);
      this.panel2.Location = new System.Drawing.Point(12, 94);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(162, 101);
      this.panel2.TabIndex = 7;
      // 
      // cbIsNewLine
      // 
      this.cbIsNewLine.AutoSize = true;
      this.cbIsNewLine.Checked = true;
      this.cbIsNewLine.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbIsNewLine.Location = new System.Drawing.Point(8, 8);
      this.cbIsNewLine.Name = "cbIsNewLine";
      this.cbIsNewLine.Size = new System.Drawing.Size(48, 16);
      this.cbIsNewLine.TabIndex = 14;
      this.cbIsNewLine.Text = "改行";
      this.cbIsNewLine.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(8, 27);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 12);
      this.label6.TabIndex = 12;
      this.label6.Text = "正規表現";
      // 
      // panel4
      // 
      this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel4.Controls.Add(this.tbRegStr);
      this.panel4.Controls.Add(this.tbRepStr);
      this.panel4.Controls.Add(this.label5);
      this.panel4.Controls.Add(this.label4);
      this.panel4.Location = new System.Drawing.Point(5, 33);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(149, 63);
      this.panel4.TabIndex = 13;
      // 
      // tbRegStr
      // 
      this.tbRegStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbRegStr.Location = new System.Drawing.Point(61, 10);
      this.tbRegStr.Name = "tbRegStr";
      this.tbRegStr.Size = new System.Drawing.Size(83, 19);
      this.tbRegStr.TabIndex = 9;
      // 
      // tbRepStr
      // 
      this.tbRepStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbRepStr.Location = new System.Drawing.Point(61, 32);
      this.tbRepStr.Name = "tbRepStr";
      this.tbRepStr.Size = new System.Drawing.Size(83, 19);
      this.tbRepStr.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label5.Location = new System.Drawing.Point(16, 39);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(47, 12);
      this.label5.TabIndex = 10;
      this.label5.Text = "置換後:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label4.Location = new System.Drawing.Point(3, 17);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(60, 12);
      this.label4.TabIndex = 8;
      this.label4.Text = "検索対象:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 88);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(22, 12);
      this.label2.TabIndex = 8;
      this.label2.Text = "Set";
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem不透明度,
            this.ToolStripMenuItem最前面});
      this.contextMenuStrip1.Name = "ToolStripMenuItem最前面";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
      // 
      // ToolStripMenuItem不透明度
      // 
      this.ToolStripMenuItem不透明度.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem不透明度上げ,
            this.ToolStripMenuItem不透明度下げ});
      this.ToolStripMenuItem不透明度.Name = "ToolStripMenuItem不透明度";
      this.ToolStripMenuItem不透明度.Size = new System.Drawing.Size(122, 22);
      this.ToolStripMenuItem不透明度.Text = "不透明度";
      this.ToolStripMenuItem不透明度.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_Click);
      // 
      // ToolStripMenuItem不透明度上げ
      // 
      this.ToolStripMenuItem不透明度上げ.Name = "ToolStripMenuItem不透明度上げ";
      this.ToolStripMenuItem不透明度上げ.Size = new System.Drawing.Size(96, 22);
      this.ToolStripMenuItem不透明度上げ.Text = "上げ";
      this.ToolStripMenuItem不透明度上げ.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_上げ_Click);
      // 
      // ToolStripMenuItem不透明度下げ
      // 
      this.ToolStripMenuItem不透明度下げ.Name = "ToolStripMenuItem不透明度下げ";
      this.ToolStripMenuItem不透明度下げ.Size = new System.Drawing.Size(96, 22);
      this.ToolStripMenuItem不透明度下げ.Text = "下げ";
      this.ToolStripMenuItem不透明度下げ.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_下げ_Click);
      // 
      // ToolStripMenuItem最前面
      // 
      this.ToolStripMenuItem最前面.Name = "ToolStripMenuItem最前面";
      this.ToolStripMenuItem最前面.Size = new System.Drawing.Size(122, 22);
      this.ToolStripMenuItem最前面.Text = "最前面";
      this.ToolStripMenuItem最前面.Click += new System.EventHandler(this.ToolStripMenuItem最前面_Click);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(186, 306);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.label2);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.tbColl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.panel4.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOnOff;
    private System.Windows.Forms.TextBox tbColl;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.CheckBox cbIsReSendMode;
    private System.Windows.Forms.CheckBox cbIsCollMode;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label lbOnOff;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox tbRepStr;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbRegStr;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.CheckBox cbIsNewLine;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度上げ;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度下げ;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem最前面;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
  }
}

