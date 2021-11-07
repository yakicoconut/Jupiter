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
      this.listView1 = new System.Windows.Forms.ListView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.AllowDrop = true;
      this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView1.HideSelection = false;
      this.listView1.LargeImageList = this.imageList1;
      this.listView1.Location = new System.Drawing.Point(12, 12);
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(730, 374);
      this.listView1.TabIndex = 4;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Com_DragDrop);
      this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.Com_DragEnter);
      this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
      // 
      // imageList1
      // 
      this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
      this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Delete});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(301, 84);
      // 
      // ToolStripMenuItem_Delete
      // 
      this.ToolStripMenuItem_Delete.Name = "ToolStripMenuItem_Delete";
      this.ToolStripMenuItem_Delete.Size = new System.Drawing.Size(300, 36);
      this.ToolStripMenuItem_Delete.Text = "削除";
      this.ToolStripMenuItem_Delete.Click += new System.EventHandler(this.ToolStripMenuItem_Delete_Click);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(754, 398);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.listView1);
      this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Com_DragDrop);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Com_DragEnter);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Delete;
  }
}

