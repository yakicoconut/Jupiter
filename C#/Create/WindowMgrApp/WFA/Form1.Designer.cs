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
      this.btRefresh.Location = new System.Drawing.Point(12, 899);
      this.btRefresh.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(125, 34);
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
      this.lvProcessList.Location = new System.Drawing.Point(12, 12);
      this.lvProcessList.Name = "lvProcessList";
      this.lvProcessList.Size = new System.Drawing.Size(378, 880);
      this.lvProcessList.TabIndex = 4;
      this.lvProcessList.UseCompatibleStateImageBehavior = false;
      this.lvProcessList.View = System.Windows.Forms.View.List;
      this.lvProcessList.SelectedIndexChanged += new System.EventHandler(this.lvProcessList_SelectedIndexChanged);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(402, 961);
      this.Controls.Add(this.lvProcessList);
      this.Controls.Add(this.btRefresh);
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btRefresh;
    private System.Windows.Forms.ListView lvProcessList;
  }
}

