namespace WFA
{
  partial class FrmPrgBar
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
      this.prgBar = new System.Windows.Forms.ProgressBar();
      this.lbPrg = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // prgBar
      // 
      this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
      this.prgBar.Location = new System.Drawing.Point(6, 6);
      this.prgBar.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
      this.prgBar.Name = "prgBar";
      this.prgBar.Size = new System.Drawing.Size(165, 36);
      this.prgBar.TabIndex = 0;
      // 
      // lbPrg
      // 
      this.lbPrg.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.lbPrg.AutoSize = true;
      this.lbPrg.BackColor = System.Drawing.Color.Transparent;
      this.lbPrg.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.lbPrg.ForeColor = System.Drawing.Color.Black;
      this.lbPrg.Location = new System.Drawing.Point(82, 18);
      this.lbPrg.Name = "lbPrg";
      this.lbPrg.Size = new System.Drawing.Size(17, 16);
      this.lbPrg.TabIndex = 1;
      this.lbPrg.Text = "-";
      // 
      // FrmPrgBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(176, 48);
      this.Controls.Add(this.lbPrg);
      this.Controls.Add(this.prgBar);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
      this.Name = "FrmPrgBar";
      this.Text = "Form2";
      this.Shown += new System.EventHandler(this.FrmPrgBar_Shown);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    protected System.Windows.Forms.ProgressBar prgBar;
    private System.Windows.Forms.Label lbPrg;
  }
}