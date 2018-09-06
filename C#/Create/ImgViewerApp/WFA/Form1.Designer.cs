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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItemIsModeZoom = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemIsModePageEject = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemFileListForm = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOptionForm = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemLaunchViewApp = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(348, 316);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
      this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemIsModeZoom,
            this.ToolStripMenuItemIsModePageEject,
            this.ToolStripMenuItemFileListForm,
            this.ToolStripMenuItemOptionForm,
            this.ToolStripMenuItemLaunchViewApp,
            this.ToolStripMenuItemConfig});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(185, 158);
      // 
      // ToolStripMenuItemIsModeZoom
      // 
      this.ToolStripMenuItemIsModeZoom.Name = "ToolStripMenuItemIsModeZoom";
      this.ToolStripMenuItemIsModeZoom.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemIsModeZoom.Text = "チェック拡張/縮小";
      this.ToolStripMenuItemIsModeZoom.Click += new System.EventHandler(this.ToolStripMenuItemIsModeZoom_Click);
      // 
      // ToolStripMenuItemIsModePageEject
      // 
      this.ToolStripMenuItemIsModePageEject.Name = "ToolStripMenuItemIsModePageEject";
      this.ToolStripMenuItemIsModePageEject.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemIsModePageEject.Text = "チェックページ送り";
      this.ToolStripMenuItemIsModePageEject.Click += new System.EventHandler(this.ToolStripMenuItemIsModePageEject_Click);
      // 
      // ToolStripMenuItemFileListForm
      // 
      this.ToolStripMenuItemFileListForm.Name = "ToolStripMenuItemFileListForm";
      this.ToolStripMenuItemFileListForm.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemFileListForm.Text = "ファイルリスト";
      this.ToolStripMenuItemFileListForm.Click += new System.EventHandler(this.ToolStripMenuItemFileListForm_Click);
      // 
      // ToolStripMenuItemOptionForm
      // 
      this.ToolStripMenuItemOptionForm.Name = "ToolStripMenuItemOptionForm";
      this.ToolStripMenuItemOptionForm.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemOptionForm.Text = "操作パネル";
      this.ToolStripMenuItemOptionForm.Click += new System.EventHandler(this.ToolStripMenuItemOptionForm_Click);
      // 
      // ToolStripMenuItemLaunchViewApp
      // 
      this.ToolStripMenuItemLaunchViewApp.Name = "ToolStripMenuItemLaunchViewApp";
      this.ToolStripMenuItemLaunchViewApp.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemLaunchViewApp.Text = "Viewアプリ起動";
      this.ToolStripMenuItemLaunchViewApp.Click += new System.EventHandler(this.ToolStripMenuItemLaunchViewApp_Click);
      // 
      // ToolStripMenuItemConfig
      // 
      this.ToolStripMenuItemConfig.Name = "ToolStripMenuItemConfig";
      this.ToolStripMenuItemConfig.Size = new System.Drawing.Size(184, 22);
      this.ToolStripMenuItemConfig.Text = "コンフィグ";
      this.ToolStripMenuItemConfig.Click += new System.EventHandler(this.ToolStripMenuItemConfig_Click);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(348, 316);
      this.Controls.Add(this.pictureBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFileListForm;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOptionForm;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIsModeZoom;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIsModePageEject;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLaunchViewApp;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemConfig;
  }
}

