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
      this.btRefresh = new System.Windows.Forms.Button();
      this.lvProcessList = new System.Windows.Forms.ListView();
      this.SuspendLayout();
      // 
      // btRefresh
      // 
      this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btRefresh.Location = new System.Drawing.Point(7, 599);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(75, 23);
      this.btRefresh.TabIndex = 1;
      this.btRefresh.Text = "更新";
      this.btRefresh.UseVisualStyleBackColor = true;
      this.btRefresh.Click += new System.EventHandler(this.button1_Click);
      // 
      // lvProcessList
      // 
      this.lvProcessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvProcessList.CheckBoxes = true;
      this.lvProcessList.Location = new System.Drawing.Point(7, 8);
      this.lvProcessList.Margin = new System.Windows.Forms.Padding(2);
      this.lvProcessList.Name = "lvProcessList";
      this.lvProcessList.Size = new System.Drawing.Size(228, 588);
      this.lvProcessList.TabIndex = 4;
      this.lvProcessList.UseCompatibleStateImageBehavior = false;
      this.lvProcessList.View = System.Windows.Forms.View.List;
      this.lvProcessList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvProcessList_ItemDrag);
      this.lvProcessList.SelectedIndexChanged += new System.EventHandler(this.lvProcessList_SelectedIndexChanged);
      this.lvProcessList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvProcessList_DragDrop);
      this.lvProcessList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvProcessList_DragEnter);
      this.lvProcessList.DragOver += new System.Windows.Forms.DragEventHandler(this.lvProcessList_DragOver);
      this.lvProcessList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvProcessList_KeyDown);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(241, 641);
      this.Controls.Add(this.lvProcessList);
      this.Controls.Add(this.btRefresh);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btRefresh;
    private System.Windows.Forms.ListView lvProcessList;
  }
}

