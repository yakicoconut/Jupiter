namespace WFA
{
  partial class FrmFileList
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemOpacity = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemOpacityDec = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemMove = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
      this.lvFileList = new System.Windows.Forms.ListView();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacity,
            this.ToolStripMenuItemMove,
            this.ToolStripMenuItemCopy,
            this.ToolStripMenuItemDelete,
            this.ToolStripMenuItemOpen});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(125, 114);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(124, 22);
      this.toolStripMenuItemOpacity.Text = "不透明度";
      this.toolStripMenuItemOpacity.Click += new System.EventHandler(this.toolStripMenuItemOpacity_Click);
      // 
      // toolStripMenuItemOpacityGain
      // 
      this.toolStripMenuItemOpacityGain.Name = "toolStripMenuItemOpacityGain";
      this.toolStripMenuItemOpacityGain.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityGain.Text = "上げ";
      this.toolStripMenuItemOpacityGain.Click += new System.EventHandler(this.toolStripMenuItemOpacityGain_Click);
      // 
      // toolStripMenuItemOpacityDec
      // 
      this.toolStripMenuItemOpacityDec.Name = "toolStripMenuItemOpacityDec";
      this.toolStripMenuItemOpacityDec.Size = new System.Drawing.Size(100, 22);
      this.toolStripMenuItemOpacityDec.Text = "下げ";
      this.toolStripMenuItemOpacityDec.Click += new System.EventHandler(this.toolStripMenuItemOpacityDec_Click);
      // 
      // ToolStripMenuItemMove
      // 
      this.ToolStripMenuItemMove.Name = "ToolStripMenuItemMove";
      this.ToolStripMenuItemMove.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItemMove.Text = "移動";
      this.ToolStripMenuItemMove.Click += new System.EventHandler(this.ToolStripMenuItemMove_Click);
      // 
      // ToolStripMenuItemCopy
      // 
      this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
      this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItemCopy.Text = "コピー";
      this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
      // 
      // ToolStripMenuItemDelete
      // 
      this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
      this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItemDelete.Text = "削除";
      this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
      // 
      // ToolStripMenuItemOpen
      // 
      this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
      this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(124, 22);
      this.ToolStripMenuItemOpen.Text = "開く";
      this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
      // 
      // lvFileList
      // 
      this.lvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvFileList.CheckBoxes = true;
      this.lvFileList.ContextMenuStrip = this.contextMenuStrip1;
      this.lvFileList.Location = new System.Drawing.Point(10, 10);
      this.lvFileList.Name = "lvFileList";
      this.lvFileList.Size = new System.Drawing.Size(150, 285);
      this.lvFileList.TabIndex = 0;
      this.lvFileList.UseCompatibleStateImageBehavior = false;
      this.lvFileList.View = System.Windows.Forms.View.List;
      this.lvFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFileList_MouseDoubleClick);
      this.lvFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvFileList_MouseDown);
      // 
      // FrmFileList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(170, 305);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.lvFileList);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmFileList";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileList_FormClosing);
      this.Load += new System.EventHandler(this.FrmFileList_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacity;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpacityDec;
    public System.Windows.Forms.ListView lvFileList;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCopy;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMove;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDelete;
    private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpen;
  }
}