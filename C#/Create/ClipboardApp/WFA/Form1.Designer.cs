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
      this.btCopy = new System.Windows.Forms.Button();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItem不透明度 = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem不透明度_上げ = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem不透明度_下げ = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItem最前面 = new System.Windows.Forms.ToolStripMenuItem();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.btSaveVal = new System.Windows.Forms.Button();
      this.btOpenExplorer = new System.Windows.Forms.Button();
      this.gbGetPath = new System.Windows.Forms.GroupBox();
      this.cbSelectMode = new System.Windows.Forms.ComboBox();
      this.lbCopyComp = new System.Windows.Forms.Label();
      this.cbIsDirPathMode = new System.Windows.Forms.CheckBox();
      this.cbCopyTgt = new System.Windows.Forms.ComboBox();
      this.contextMenuStrip1.SuspendLayout();
      this.gbGetPath.SuspendLayout();
      this.SuspendLayout();
      // 
      // btCopy
      // 
      this.btCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btCopy.Location = new System.Drawing.Point(149, 112);
      this.btCopy.Name = "btCopy";
      this.btCopy.Size = new System.Drawing.Size(75, 23);
      this.btCopy.TabIndex = 6;
      this.btCopy.TabStop = false;
      this.btCopy.Text = "Copy";
      this.btCopy.UseVisualStyleBackColor = true;
      this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem不透明度,
            this.ToolStripMenuItem最前面});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
      // 
      // ToolStripMenuItem不透明度
      // 
      this.ToolStripMenuItem不透明度.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem不透明度_上げ,
            this.ToolStripMenuItem不透明度_下げ});
      this.ToolStripMenuItem不透明度.Name = "ToolStripMenuItem不透明度";
      this.ToolStripMenuItem不透明度.Size = new System.Drawing.Size(122, 22);
      this.ToolStripMenuItem不透明度.Text = "不透明度";
      this.ToolStripMenuItem不透明度.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_Click);
      // 
      // ToolStripMenuItem不透明度_上げ
      // 
      this.ToolStripMenuItem不透明度_上げ.Name = "ToolStripMenuItem不透明度_上げ";
      this.ToolStripMenuItem不透明度_上げ.Size = new System.Drawing.Size(96, 22);
      this.ToolStripMenuItem不透明度_上げ.Text = "上げ";
      this.ToolStripMenuItem不透明度_上げ.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_上げ_Click);
      // 
      // ToolStripMenuItem不透明度_下げ
      // 
      this.ToolStripMenuItem不透明度_下げ.Name = "ToolStripMenuItem不透明度_下げ";
      this.ToolStripMenuItem不透明度_下げ.Size = new System.Drawing.Size(96, 22);
      this.ToolStripMenuItem不透明度_下げ.Text = "下げ";
      this.ToolStripMenuItem不透明度_下げ.Click += new System.EventHandler(this.ToolStripMenuItem不透明度_下げ_Click);
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
      // btSaveVal
      // 
      this.btSaveVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btSaveVal.Location = new System.Drawing.Point(116, 141);
      this.btSaveVal.Name = "btSaveVal";
      this.btSaveVal.Size = new System.Drawing.Size(51, 23);
      this.btSaveVal.TabIndex = 21;
      this.btSaveVal.TabStop = false;
      this.btSaveVal.Text = "値保存";
      this.btSaveVal.UseVisualStyleBackColor = true;
      this.btSaveVal.Click += new System.EventHandler(this.btSaveVal_Click);
      // 
      // btOpenExplorer
      // 
      this.btOpenExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOpenExplorer.Location = new System.Drawing.Point(173, 141);
      this.btOpenExplorer.Name = "btOpenExplorer";
      this.btOpenExplorer.Size = new System.Drawing.Size(51, 23);
      this.btOpenExplorer.TabIndex = 22;
      this.btOpenExplorer.TabStop = false;
      this.btOpenExplorer.Text = "開く";
      this.btOpenExplorer.UseVisualStyleBackColor = true;
      this.btOpenExplorer.Click += new System.EventHandler(this.btOpenExplorer_Click);
      // 
      // gbGetPath
      // 
      this.gbGetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gbGetPath.Controls.Add(this.cbSelectMode);
      this.gbGetPath.Controls.Add(this.lbCopyComp);
      this.gbGetPath.Location = new System.Drawing.Point(15, 34);
      this.gbGetPath.Name = "gbGetPath";
      this.gbGetPath.Size = new System.Drawing.Size(209, 71);
      this.gbGetPath.TabIndex = 23;
      this.gbGetPath.TabStop = false;
      this.gbGetPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.gbGetPath_DragDrop);
      this.gbGetPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.gbGetPath_DragEnter);
      // 
      // cbSelectMode
      // 
      this.cbSelectMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbSelectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSelectMode.FormattingEnabled = true;
      this.cbSelectMode.Location = new System.Drawing.Point(18, 0);
      this.cbSelectMode.Name = "cbSelectMode";
      this.cbSelectMode.Size = new System.Drawing.Size(173, 20);
      this.cbSelectMode.TabIndex = 1;
      // 
      // lbCopyComp
      // 
      this.lbCopyComp.AutoSize = true;
      this.lbCopyComp.Location = new System.Drawing.Point(16, 33);
      this.lbCopyComp.Name = "lbCopyComp";
      this.lbCopyComp.Size = new System.Drawing.Size(0, 12);
      this.lbCopyComp.TabIndex = 0;
      // 
      // cbIsDirPathMode
      // 
      this.cbIsDirPathMode.AutoSize = true;
      this.cbIsDirPathMode.Location = new System.Drawing.Point(15, 12);
      this.cbIsDirPathMode.Name = "cbIsDirPathMode";
      this.cbIsDirPathMode.Size = new System.Drawing.Size(87, 16);
      this.cbIsDirPathMode.TabIndex = 24;
      this.cbIsDirPathMode.Text = "フォルダモード";
      this.cbIsDirPathMode.UseVisualStyleBackColor = true;
      // 
      // cbCopyTgt
      // 
      this.cbCopyTgt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbCopyTgt.FormattingEnabled = true;
      this.cbCopyTgt.Location = new System.Drawing.Point(15, 114);
      this.cbCopyTgt.Name = "cbCopyTgt";
      this.cbCopyTgt.Size = new System.Drawing.Size(128, 20);
      this.cbCopyTgt.TabIndex = 25;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(234, 175);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.cbCopyTgt);
      this.Controls.Add(this.cbIsDirPathMode);
      this.Controls.Add(this.gbGetPath);
      this.Controls.Add(this.btOpenExplorer);
      this.Controls.Add(this.btSaveVal);
      this.Controls.Add(this.btCopy);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
      this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
      this.contextMenuStrip1.ResumeLayout(false);
      this.gbGetPath.ResumeLayout(false);
      this.gbGetPath.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度_上げ;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem不透明度_下げ;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem最前面;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btSaveVal;
        private System.Windows.Forms.Button btOpenExplorer;
    private System.Windows.Forms.GroupBox gbGetPath;
    private System.Windows.Forms.CheckBox cbIsDirPathMode;
    private System.Windows.Forms.Label lbCopyComp;
    private System.Windows.Forms.ComboBox cbSelectMode;
    private System.Windows.Forms.ComboBox cbCopyTgt;
  }
}

