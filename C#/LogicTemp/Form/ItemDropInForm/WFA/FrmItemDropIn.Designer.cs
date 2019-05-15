namespace WFA
{
  partial class FrmItemDropIn
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
      this.groupBox = new System.Windows.Forms.GroupBox();
      this.lblProgress = new System.Windows.Forms.Label();
      this.groupBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox
      // 
      this.groupBox.Controls.Add(this.lblProgress);
      this.groupBox.Location = new System.Drawing.Point(3, 6);
      this.groupBox.Name = "groupBox";
      this.groupBox.Size = new System.Drawing.Size(311, 57);
      this.groupBox.TabIndex = 6;
      this.groupBox.TabStop = false;
      this.groupBox.Text = "def";
      this.groupBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox_DragDrop);
      this.groupBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox_DragEnter);
      // 
      // lblProgress
      // 
      this.lblProgress.AutoSize = true;
      this.lblProgress.Location = new System.Drawing.Point(23, 33);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(0, 12);
      this.lblProgress.TabIndex = 12;
      // 
      // FrmItemDropIn
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(321, 68);
      this.Controls.Add(this.groupBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FrmItemDropIn";
      this.Text = "abc";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.FrmItemDropIn_Load);
      this.groupBox.ResumeLayout(false);
      this.groupBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox;
    private System.Windows.Forms.Label lblProgress;
  }
}