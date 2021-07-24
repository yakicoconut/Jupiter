namespace WFA
{
  partial class Form2
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
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.btCancel = new System.Windows.Forms.Button();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.lbProgress = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.progressBar1.Location = new System.Drawing.Point(12, 12);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(254, 23);
      this.progressBar1.TabIndex = 0;
      // 
      // btCancel
      // 
      this.btCancel.Location = new System.Drawing.Point(191, 53);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 26);
      this.btCancel.TabIndex = 1;
      this.btCancel.Text = "button1";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // lbProgress
      // 
      this.lbProgress.AutoSize = true;
      this.lbProgress.Location = new System.Drawing.Point(9, 53);
      this.lbProgress.Name = "lbProgress";
      this.lbProgress.Size = new System.Drawing.Size(52, 18);
      this.lbProgress.TabIndex = 2;
      this.lbProgress.Text = "label1";
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(278, 91);
      this.Controls.Add(this.lbProgress);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.progressBar1);
      this.Name = "Form2";
      this.Text = "Form2";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Button btCancel;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Label lbProgress;
  }
}