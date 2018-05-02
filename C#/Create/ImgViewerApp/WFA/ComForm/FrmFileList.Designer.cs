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
      this.panel1 = new System.Windows.Forms.Panel();
      this.btReferenceDir = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.tbCommitDir = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
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
      this.contextMenuStrip1.Size = new System.Drawing.Size(153, 136);
      // 
      // toolStripMenuItemOpacity
      // 
      this.toolStripMenuItemOpacity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpacityGain,
            this.toolStripMenuItemOpacityDec});
      this.toolStripMenuItemOpacity.Name = "toolStripMenuItemOpacity";
      this.toolStripMenuItemOpacity.Size = new System.Drawing.Size(152, 22);
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
      this.ToolStripMenuItemMove.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemMove.Text = "移動";
      this.ToolStripMenuItemMove.Click += new System.EventHandler(this.ToolStripMenuItemMove_Click);
      // 
      // ToolStripMenuItemCopy
      // 
      this.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy";
      this.ToolStripMenuItemCopy.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemCopy.Text = "コピー";
      this.ToolStripMenuItemCopy.Click += new System.EventHandler(this.ToolStripMenuItemCopy_Click);
      // 
      // ToolStripMenuItemDelete
      // 
      this.ToolStripMenuItemDelete.Name = "ToolStripMenuItemDelete";
      this.ToolStripMenuItemDelete.Size = new System.Drawing.Size(152, 22);
      this.ToolStripMenuItemDelete.Text = "削除";
      this.ToolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDelete_Click);
      // 
      // ToolStripMenuItemOpen
      // 
      this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
      this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(152, 22);
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
      this.lvFileList.Location = new System.Drawing.Point(10, 62);
      this.lvFileList.Name = "lvFileList";
      this.lvFileList.Size = new System.Drawing.Size(166, 340);
      this.lvFileList.TabIndex = 0;
      this.lvFileList.UseCompatibleStateImageBehavior = false;
      this.lvFileList.View = System.Windows.Forms.View.List;
      this.lvFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvFileList_MouseDoubleClick);
      this.lvFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvFileList_MouseDown);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.btReferenceDir);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.tbCommitDir);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(164, 46);
      this.panel1.TabIndex = 1;
      // 
      // btReferenceDir
      // 
      this.btReferenceDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btReferenceDir.Location = new System.Drawing.Point(122, 18);
      this.btReferenceDir.Name = "btReferenceDir";
      this.btReferenceDir.Size = new System.Drawing.Size(39, 23);
      this.btReferenceDir.TabIndex = 2;
      this.btReferenceDir.Text = "参照";
      this.btReferenceDir.UseVisualStyleBackColor = true;
      this.btReferenceDir.Click += new System.EventHandler(this.btReferenceDir_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label1.Location = new System.Drawing.Point(6, 4);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 12);
      this.label1.TabIndex = 1;
      this.label1.Text = "コミット先";
      // 
      // tbCommitDir
      // 
      this.tbCommitDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbCommitDir.Location = new System.Drawing.Point(16, 20);
      this.tbCommitDir.Name = "tbCommitDir";
      this.tbCommitDir.Size = new System.Drawing.Size(100, 19);
      this.tbCommitDir.TabIndex = 0;
      // 
      // FrmFileList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(186, 412);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.lvFileList);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmFileList";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFileList_FormClosing);
      this.Load += new System.EventHandler(this.FrmFileList_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
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
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btReferenceDir;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbCommitDir;
  }
}