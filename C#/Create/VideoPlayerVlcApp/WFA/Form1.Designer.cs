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
      this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
      ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).BeginInit();
      this.SuspendLayout();
      // 
      // vlcControl1
      // 
      this.vlcControl1.BackColor = System.Drawing.Color.Black;
      this.vlcControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.vlcControl1.Location = new System.Drawing.Point(0, 0);
      this.vlcControl1.Name = "vlcControl1";
      this.vlcControl1.Size = new System.Drawing.Size(350, 200);
      this.vlcControl1.Spu = -1;
      this.vlcControl1.TabIndex = 4;
      this.vlcControl1.Text = "vlcControl1";
      this.vlcControl1.VlcLibDirectory = null;
      this.vlcControl1.VlcMediaplayerOptions = null;
      this.vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl1_VlcLibDirectoryNeeded);
      this.vlcControl1.VideoOutChanged += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerVideoOutChangedEventArgs>(this.vlcControl1_VideoOutChanged);
      this.vlcControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.window_Comm_MouseDown);
      this.vlcControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vlcControl1_MouseMove);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(350, 200);
      this.Controls.Add(this.vlcControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.vlcControl1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion
    private Vlc.DotNet.Forms.VlcControl vlcControl1;
  }
}

