namespace WFA
{
  partial class FrmPtMng
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
      this.toolStripMenuItemTra = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemTraGain = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemTraDec = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tbSelectItem = new System.Windows.Forms.TextBox();
      this.tbSaveName = new System.Windows.Forms.TextBox();
      this.tbPtCommentPreview = new System.Windows.Forms.TextBox();
      this.btOpen = new System.Windows.Forms.Button();
      this.btSaveXml = new System.Windows.Forms.Button();
      this.btInputXml = new System.Windows.Forms.Button();
      this.tbCommitPath = new System.Windows.Forms.TextBox();
      this.btConfirm = new System.Windows.Forms.Button();
      this.lvFileList = new System.Windows.Forms.ListView();
      this.tbSearchPath = new System.Windows.Forms.TextBox();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTra});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(123, 26);
      // 
      // toolStripMenuItemTra
      // 
      this.toolStripMenuItemTra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTraGain,
            this.toolStripMenuItemTraDec});
      this.toolStripMenuItemTra.Name = "toolStripMenuItemTra";
      this.toolStripMenuItemTra.Size = new System.Drawing.Size(122, 22);
      this.toolStripMenuItemTra.Text = "透明度";
      this.toolStripMenuItemTra.Click += new System.EventHandler(this.toolStripMenuItemTra_Click);
      // 
      // toolStripMenuItemTraGain
      // 
      this.toolStripMenuItemTraGain.Name = "toolStripMenuItemTraGain";
      this.toolStripMenuItemTraGain.Size = new System.Drawing.Size(96, 22);
      this.toolStripMenuItemTraGain.Text = "上げる";
      this.toolStripMenuItemTraGain.Click += new System.EventHandler(this.toolStripMenuItemTraGain_Click);
      // 
      // toolStripMenuItemTraDec
      // 
      this.toolStripMenuItemTraDec.Name = "toolStripMenuItemTraDec";
      this.toolStripMenuItemTraDec.Size = new System.Drawing.Size(96, 22);
      this.toolStripMenuItemTraDec.Text = "下げる";
      this.toolStripMenuItemTraDec.Click += new System.EventHandler(this.toolStripMenuItemTraDec_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.SystemColors.Window;
      this.panel1.Controls.Add(this.tbSelectItem);
      this.panel1.Controls.Add(this.tbSaveName);
      this.panel1.Controls.Add(this.tbPtCommentPreview);
      this.panel1.Controls.Add(this.btOpen);
      this.panel1.Controls.Add(this.btSaveXml);
      this.panel1.Controls.Add(this.btInputXml);
      this.panel1.Controls.Add(this.tbCommitPath);
      this.panel1.Controls.Add(this.btConfirm);
      this.panel1.Controls.Add(this.lvFileList);
      this.panel1.Controls.Add(this.tbSearchPath);
      this.panel1.Location = new System.Drawing.Point(10, 10);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(289, 500);
      this.panel1.TabIndex = 1;
      // 
      // tbSelectItem
      // 
      this.tbSelectItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSelectItem.BackColor = System.Drawing.SystemColors.Window;
      this.tbSelectItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbSelectItem.Location = new System.Drawing.Point(10, 479);
      this.tbSelectItem.Name = "tbSelectItem";
      this.tbSelectItem.ReadOnly = true;
      this.tbSelectItem.Size = new System.Drawing.Size(189, 12);
      this.tbSelectItem.TabIndex = 8;
      // 
      // tbSaveName
      // 
      this.tbSaveName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSaveName.Location = new System.Drawing.Point(10, 447);
      this.tbSaveName.Name = "tbSaveName";
      this.tbSaveName.Size = new System.Drawing.Size(189, 19);
      this.tbSaveName.TabIndex = 7;
      // 
      // tbPtCommentPreview
      // 
      this.tbPtCommentPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbPtCommentPreview.Location = new System.Drawing.Point(10, 383);
      this.tbPtCommentPreview.Multiline = true;
      this.tbPtCommentPreview.Name = "tbPtCommentPreview";
      this.tbPtCommentPreview.ReadOnly = true;
      this.tbPtCommentPreview.Size = new System.Drawing.Size(270, 56);
      this.tbPtCommentPreview.TabIndex = 6;
      // 
      // btOpen
      // 
      this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btOpen.Location = new System.Drawing.Point(237, 33);
      this.btOpen.Name = "btOpen";
      this.btOpen.Size = new System.Drawing.Size(43, 23);
      this.btOpen.TabIndex = 5;
      this.btOpen.Text = "開く";
      this.btOpen.UseVisualStyleBackColor = true;
      this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
      // 
      // btSaveXml
      // 
      this.btSaveXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btSaveXml.Location = new System.Drawing.Point(205, 445);
      this.btSaveXml.Name = "btSaveXml";
      this.btSaveXml.Size = new System.Drawing.Size(75, 23);
      this.btSaveXml.TabIndex = 4;
      this.btSaveXml.Text = "保存";
      this.btSaveXml.UseVisualStyleBackColor = true;
      this.btSaveXml.Click += new System.EventHandler(this.btSaveXml_Click);
      // 
      // btInputXml
      // 
      this.btInputXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btInputXml.Location = new System.Drawing.Point(205, 474);
      this.btInputXml.Name = "btInputXml";
      this.btInputXml.Size = new System.Drawing.Size(75, 23);
      this.btInputXml.TabIndex = 3;
      this.btInputXml.Text = "取込";
      this.btInputXml.UseVisualStyleBackColor = true;
      this.btInputXml.Click += new System.EventHandler(this.Com_InputXml);
      // 
      // tbCommitPath
      // 
      this.tbCommitPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbCommitPath.BackColor = System.Drawing.SystemColors.Window;
      this.tbCommitPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbCommitPath.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.tbCommitPath.Location = new System.Drawing.Point(10, 37);
      this.tbCommitPath.Name = "tbCommitPath";
      this.tbCommitPath.ReadOnly = true;
      this.tbCommitPath.Size = new System.Drawing.Size(230, 15);
      this.tbCommitPath.TabIndex = 2;
      this.tbCommitPath.Text = "-";
      // 
      // btConfirm
      // 
      this.btConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btConfirm.Location = new System.Drawing.Point(205, 10);
      this.btConfirm.Name = "btConfirm";
      this.btConfirm.Size = new System.Drawing.Size(75, 23);
      this.btConfirm.TabIndex = 1;
      this.btConfirm.Text = "確定";
      this.btConfirm.UseVisualStyleBackColor = true;
      this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
      // 
      // lvFileList
      // 
      this.lvFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lvFileList.ContextMenuStrip = this.contextMenuStrip1;
      this.lvFileList.HideSelection = false;
      this.lvFileList.Location = new System.Drawing.Point(10, 62);
      this.lvFileList.MultiSelect = false;
      this.lvFileList.Name = "lvFileList";
      this.lvFileList.Size = new System.Drawing.Size(270, 315);
      this.lvFileList.TabIndex = 0;
      this.lvFileList.UseCompatibleStateImageBehavior = false;
      this.lvFileList.View = System.Windows.Forms.View.List;
      this.lvFileList.SelectedIndexChanged += new System.EventHandler(this.lvFileList_SelectedIndexChanged);
      this.lvFileList.DoubleClick += new System.EventHandler(this.Com_InputXml);
      // 
      // tbSearchPath
      // 
      this.tbSearchPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbSearchPath.Location = new System.Drawing.Point(10, 12);
      this.tbSearchPath.Name = "tbSearchPath";
      this.tbSearchPath.Size = new System.Drawing.Size(189, 19);
      this.tbSearchPath.TabIndex = 0;
      // 
      // FrmPtMng
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
      this.ClientSize = new System.Drawing.Size(309, 520);
      this.ContextMenuStrip = this.contextMenuStrip1;
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmPtMng";
      this.Opacity = 0.8D;
      this.Text = "Form2";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPtMng_FormClosing);
      this.Load += new System.EventHandler(this.FrmPtMng_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTra;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraGain;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTraDec;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ListView lvFileList;
    private System.Windows.Forms.TextBox tbSearchPath;
    private System.Windows.Forms.TextBox tbCommitPath;
    private System.Windows.Forms.Button btConfirm;
    private System.Windows.Forms.Button btSaveXml;
    private System.Windows.Forms.Button btInputXml;
    private System.Windows.Forms.Button btOpen;
    private System.Windows.Forms.TextBox tbPtCommentPreview;
    private System.Windows.Forms.TextBox tbSelectItem;
    private System.Windows.Forms.TextBox tbSaveName;
  }
}