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
      Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
      Sgry.Azuki.FontInfo fontInfo2 = new Sgry.Azuki.FontInfo();
      this.btExec = new System.Windows.Forms.Button();
      this.azkTargetFileName = new Sgry.Azuki.WinForms.AzukiControl();
      this.azkChangedFileName = new Sgry.Azuki.WinForms.AzukiControl();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.btOpenExplorer = new System.Windows.Forms.Button();
      this.lbTargetPath = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.btPathConfirm = new System.Windows.Forms.Button();
      this.btReference = new System.Windows.Forms.Button();
      this.tbTargetPathText = new System.Windows.Forms.TextBox();
      this.btCallBackup = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btExec
      // 
      this.btExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btExec.Location = new System.Drawing.Point(642, 538);
      this.btExec.Name = "btExec";
      this.btExec.Size = new System.Drawing.Size(75, 23);
      this.btExec.TabIndex = 1;
      this.btExec.Text = "実行";
      this.btExec.UseVisualStyleBackColor = true;
      this.btExec.Click += new System.EventHandler(this.btExec_Click);
      // 
      // azkTargetFileName
      // 
      this.azkTargetFileName.AllowDrop = true;
      this.azkTargetFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.azkTargetFileName.BackColor = System.Drawing.Color.LightGray;
      this.azkTargetFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.azkTargetFileName.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab)
            | Sgry.Azuki.DrawingOption.DrawsEol)
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine)
            | Sgry.Azuki.DrawingOption.ShowsLineNumber)
            | Sgry.Azuki.DrawingOption.ShowsDirtBar)
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
      this.azkTargetFileName.FirstVisibleLine = 0;
      this.azkTargetFileName.Font = new System.Drawing.Font("MS UI Gothic", 14F);
      fontInfo1.Name = "MS UI Gothic";
      fontInfo1.Size = 14;
      fontInfo1.Style = System.Drawing.FontStyle.Regular;
      this.azkTargetFileName.FontInfo = fontInfo1;
      this.azkTargetFileName.ForeColor = System.Drawing.Color.Black;
      this.azkTargetFileName.IsReadOnly = true;
      this.azkTargetFileName.Location = new System.Drawing.Point(3, 3);
      this.azkTargetFileName.Name = "azkTargetFileName";
      this.azkTargetFileName.ScrollPos = new System.Drawing.Point(0, 0);
      this.azkTargetFileName.ShowsVScrollBar = false;
      this.azkTargetFileName.Size = new System.Drawing.Size(209, 436);
      this.azkTargetFileName.TabIndex = 4;
      this.azkTargetFileName.ViewWidth = 4142;
      this.azkTargetFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.azkTargetFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // azkChangedFileName
      // 
      this.azkChangedFileName.AllowDrop = true;
      this.azkChangedFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.azkChangedFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
      this.azkChangedFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
      this.azkChangedFileName.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab)
            | Sgry.Azuki.DrawingOption.DrawsEol)
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine)
            | Sgry.Azuki.DrawingOption.ShowsLineNumber)
            | Sgry.Azuki.DrawingOption.ShowsDirtBar)
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
      this.azkChangedFileName.FirstVisibleLine = 0;
      this.azkChangedFileName.Font = new System.Drawing.Font("MS UI Gothic", 14F);
      fontInfo2.Name = "MS UI Gothic";
      fontInfo2.Size = 14;
      fontInfo2.Style = System.Drawing.FontStyle.Regular;
      this.azkChangedFileName.FontInfo = fontInfo2;
      this.azkChangedFileName.ForeColor = System.Drawing.Color.Black;
      this.azkChangedFileName.Location = new System.Drawing.Point(3, 3);
      this.azkChangedFileName.Name = "azkChangedFileName";
      this.azkChangedFileName.ScrollPos = new System.Drawing.Point(0, 0);
      this.azkChangedFileName.Size = new System.Drawing.Size(486, 436);
      this.azkChangedFileName.TabIndex = 5;
      this.azkChangedFileName.ViewWidth = 4142;
      this.azkChangedFileName.VScroll += new System.EventHandler(this.azkChangedFileName_VScroll);
      this.azkChangedFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.azkChangedFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // splitContainer1
      // 
      this.splitContainer1.AllowDrop = true;
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(12, 90);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.azkTargetFileName);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.azkChangedFileName);
      this.splitContainer1.Size = new System.Drawing.Size(708, 442);
      this.splitContainer1.SplitterDistance = 212;
      this.splitContainer1.TabIndex = 6;
      this.splitContainer1.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.splitContainer1.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // btOpenExplorer
      // 
      this.btOpenExplorer.Location = new System.Drawing.Point(101, 35);
      this.btOpenExplorer.Name = "btOpenExplorer";
      this.btOpenExplorer.Size = new System.Drawing.Size(33, 20);
      this.btOpenExplorer.TabIndex = 11;
      this.btOpenExplorer.Text = "開く";
      this.btOpenExplorer.UseVisualStyleBackColor = true;
      this.btOpenExplorer.Click += new System.EventHandler(this.btOpenExplorer_Click);
      // 
      // lbTargetPath
      // 
      this.lbTargetPath.AllowDrop = true;
      this.lbTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lbTargetPath.BackColor = System.Drawing.SystemColors.Control;
      this.lbTargetPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lbTargetPath.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Underline);
      this.lbTargetPath.Location = new System.Drawing.Point(17, 61);
      this.lbTargetPath.Name = "lbTargetPath";
      this.lbTargetPath.ReadOnly = true;
      this.lbTargetPath.Size = new System.Drawing.Size(703, 23);
      this.lbTargetPath.TabIndex = 12;
      this.lbTargetPath.Text = "-";
      this.lbTargetPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.lbTargetPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // label12
      // 
      this.label12.AllowDrop = true;
      this.label12.AutoSize = true;
      this.label12.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.label12.Location = new System.Drawing.Point(8, 35);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(100, 23);
      this.label12.TabIndex = 7;
      this.label12.Text = "対象フォルダ";
      this.label12.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.label12.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // btPathConfirm
      // 
      this.btPathConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btPathConfirm.Location = new System.Drawing.Point(655, 10);
      this.btPathConfirm.Name = "btPathConfirm";
      this.btPathConfirm.Size = new System.Drawing.Size(62, 23);
      this.btPathConfirm.TabIndex = 8;
      this.btPathConfirm.Text = "位置確定";
      this.btPathConfirm.UseVisualStyleBackColor = true;
      this.btPathConfirm.Click += new System.EventHandler(this.btPathConfirm_Click);
      // 
      // btReference
      // 
      this.btReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btReference.Location = new System.Drawing.Point(616, 11);
      this.btReference.Name = "btReference";
      this.btReference.Size = new System.Drawing.Size(39, 20);
      this.btReference.TabIndex = 9;
      this.btReference.Text = "参照";
      this.btReference.UseVisualStyleBackColor = true;
      this.btReference.Click += new System.EventHandler(this.btReference_Click);
      // 
      // tbTargetPathText
      // 
      this.tbTargetPathText.AllowDrop = true;
      this.tbTargetPathText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbTargetPathText.Location = new System.Drawing.Point(12, 12);
      this.tbTargetPathText.Name = "tbTargetPathText";
      this.tbTargetPathText.Size = new System.Drawing.Size(605, 19);
      this.tbTargetPathText.TabIndex = 13;
      this.tbTargetPathText.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.tbTargetPathText.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      // 
      // btCallBackup
      // 
      this.btCallBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCallBackup.Location = new System.Drawing.Point(561, 538);
      this.btCallBackup.Name = "btCallBackup";
      this.btCallBackup.Size = new System.Drawing.Size(75, 23);
      this.btCallBackup.TabIndex = 14;
      this.btCallBackup.Text = "前回呼出";
      this.btCallBackup.UseVisualStyleBackColor = true;
      this.btCallBackup.Click += new System.EventHandler(this.btCallBackup_Click);
      // 
      // Form1
      // 
      this.AllowDrop = true;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(732, 573);
      this.Controls.Add(this.btCallBackup);
      this.Controls.Add(this.btOpenExplorer);
      this.Controls.Add(this.lbTargetPath);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.btPathConfirm);
      this.Controls.Add(this.btReference);
      this.Controls.Add(this.tbTargetPathText);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.btExec);
      this.Name = "Form1";
      this.Text = "Form1";
      this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CommonDropDropEv);
      this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDropEnterEv);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btExec;
    private Sgry.Azuki.WinForms.AzukiControl azkTargetFileName;
    private Sgry.Azuki.WinForms.AzukiControl azkChangedFileName;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Button btOpenExplorer;
    private System.Windows.Forms.TextBox lbTargetPath;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Button btPathConfirm;
    private System.Windows.Forms.Button btReference;
    private System.Windows.Forms.TextBox tbTargetPathText;
    private System.Windows.Forms.Button btCallBackup;
  }
}

