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
      this.btZero = new System.Windows.Forms.Button();
      this.btLeft = new System.Windows.Forms.Button();
      this.tbEntry = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btEqual = new System.Windows.Forms.Button();
      this.btPlus = new System.Windows.Forms.Button();
      this.btMinus = new System.Windows.Forms.Button();
      this.btTimes = new System.Windows.Forms.Button();
      this.btDivision = new System.Windows.Forms.Button();
      this.btThree = new System.Windows.Forms.Button();
      this.btTwo = new System.Windows.Forms.Button();
      this.btOne = new System.Windows.Forms.Button();
      this.btSix = new System.Windows.Forms.Button();
      this.btFive = new System.Windows.Forms.Button();
      this.btFour = new System.Windows.Forms.Button();
      this.btNine = new System.Windows.Forms.Button();
      this.btEight = new System.Windows.Forms.Button();
      this.btSeven = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.btCancelEntry = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btZero
      // 
      this.btZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btZero.Location = new System.Drawing.Point(7, 138);
      this.btZero.Name = "btZero";
      this.btZero.Size = new System.Drawing.Size(63, 30);
      this.btZero.TabIndex = 1;
      this.btZero.Text = "0";
      this.btZero.UseVisualStyleBackColor = true;
      this.btZero.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btLeft
      // 
      this.btLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btLeft.Location = new System.Drawing.Point(7, 6);
      this.btLeft.Name = "btLeft";
      this.btLeft.Size = new System.Drawing.Size(30, 30);
      this.btLeft.TabIndex = 3;
      this.btLeft.Text = "←";
      this.btLeft.UseVisualStyleBackColor = true;
      this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
      // 
      // tbEntry
      // 
      this.tbEntry.Location = new System.Drawing.Point(12, 12);
      this.tbEntry.Name = "tbEntry";
      this.tbEntry.Size = new System.Drawing.Size(143, 19);
      this.tbEntry.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.btEqual);
      this.panel1.Controls.Add(this.btPlus);
      this.panel1.Controls.Add(this.btMinus);
      this.panel1.Controls.Add(this.btTimes);
      this.panel1.Controls.Add(this.btDivision);
      this.panel1.Controls.Add(this.btThree);
      this.panel1.Controls.Add(this.btTwo);
      this.panel1.Controls.Add(this.btOne);
      this.panel1.Controls.Add(this.btSix);
      this.panel1.Controls.Add(this.btFive);
      this.panel1.Controls.Add(this.btFour);
      this.panel1.Controls.Add(this.btNine);
      this.panel1.Controls.Add(this.btEight);
      this.panel1.Controls.Add(this.btSeven);
      this.panel1.Controls.Add(this.btCancel);
      this.panel1.Controls.Add(this.btCancelEntry);
      this.panel1.Controls.Add(this.btLeft);
      this.panel1.Controls.Add(this.btZero);
      this.panel1.Location = new System.Drawing.Point(12, 37);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(143, 175);
      this.panel1.TabIndex = 5;
      // 
      // btEqual
      // 
      this.btEqual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btEqual.Location = new System.Drawing.Point(73, 138);
      this.btEqual.Name = "btEqual";
      this.btEqual.Size = new System.Drawing.Size(63, 30);
      this.btEqual.TabIndex = 24;
      this.btEqual.Text = "=";
      this.btEqual.UseVisualStyleBackColor = true;
      this.btEqual.Click += new System.EventHandler(this.btEqual_Click);
      // 
      // btPlus
      // 
      this.btPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btPlus.Location = new System.Drawing.Point(106, 105);
      this.btPlus.Name = "btPlus";
      this.btPlus.Size = new System.Drawing.Size(30, 30);
      this.btPlus.TabIndex = 23;
      this.btPlus.Text = "+";
      this.btPlus.UseVisualStyleBackColor = true;
      this.btPlus.Click += new System.EventHandler(this.btPlus_Click);
      // 
      // btMinus
      // 
      this.btMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btMinus.Location = new System.Drawing.Point(106, 72);
      this.btMinus.Name = "btMinus";
      this.btMinus.Size = new System.Drawing.Size(30, 30);
      this.btMinus.TabIndex = 18;
      this.btMinus.Text = "-";
      this.btMinus.UseVisualStyleBackColor = true;
      this.btMinus.Click += new System.EventHandler(this.btMinus_Click);
      // 
      // btTimes
      // 
      this.btTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btTimes.Location = new System.Drawing.Point(106, 39);
      this.btTimes.Name = "btTimes";
      this.btTimes.Size = new System.Drawing.Size(30, 30);
      this.btTimes.TabIndex = 16;
      this.btTimes.Text = "*";
      this.btTimes.UseVisualStyleBackColor = true;
      this.btTimes.Click += new System.EventHandler(this.btTimes_Click);
      // 
      // btDivision
      // 
      this.btDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btDivision.Location = new System.Drawing.Point(106, 6);
      this.btDivision.Name = "btDivision";
      this.btDivision.Size = new System.Drawing.Size(30, 30);
      this.btDivision.TabIndex = 15;
      this.btDivision.Text = "/";
      this.btDivision.UseVisualStyleBackColor = true;
      this.btDivision.Click += new System.EventHandler(this.btDivision_Click);
      // 
      // btThree
      // 
      this.btThree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btThree.Location = new System.Drawing.Point(73, 105);
      this.btThree.Name = "btThree";
      this.btThree.Size = new System.Drawing.Size(30, 30);
      this.btThree.TabIndex = 14;
      this.btThree.Text = "3";
      this.btThree.UseVisualStyleBackColor = true;
      this.btThree.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btTwo
      // 
      this.btTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btTwo.Location = new System.Drawing.Point(40, 105);
      this.btTwo.Name = "btTwo";
      this.btTwo.Size = new System.Drawing.Size(30, 30);
      this.btTwo.TabIndex = 13;
      this.btTwo.Text = "2";
      this.btTwo.UseVisualStyleBackColor = true;
      this.btTwo.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btOne
      // 
      this.btOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btOne.Location = new System.Drawing.Point(7, 105);
      this.btOne.Name = "btOne";
      this.btOne.Size = new System.Drawing.Size(30, 30);
      this.btOne.TabIndex = 1;
      this.btOne.Text = "1";
      this.btOne.UseVisualStyleBackColor = true;
      this.btOne.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btSix
      // 
      this.btSix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btSix.Location = new System.Drawing.Point(73, 72);
      this.btSix.Name = "btSix";
      this.btSix.Size = new System.Drawing.Size(30, 30);
      this.btSix.TabIndex = 11;
      this.btSix.Text = "6";
      this.btSix.UseVisualStyleBackColor = true;
      this.btSix.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btFive
      // 
      this.btFive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btFive.Location = new System.Drawing.Point(40, 72);
      this.btFive.Name = "btFive";
      this.btFive.Size = new System.Drawing.Size(30, 30);
      this.btFive.TabIndex = 10;
      this.btFive.Text = "5";
      this.btFive.UseVisualStyleBackColor = true;
      this.btFive.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btFour
      // 
      this.btFour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btFour.Location = new System.Drawing.Point(7, 72);
      this.btFour.Name = "btFour";
      this.btFour.Size = new System.Drawing.Size(30, 30);
      this.btFour.TabIndex = 9;
      this.btFour.Text = "4";
      this.btFour.UseVisualStyleBackColor = true;
      this.btFour.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btNine
      // 
      this.btNine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btNine.Location = new System.Drawing.Point(73, 39);
      this.btNine.Name = "btNine";
      this.btNine.Size = new System.Drawing.Size(30, 30);
      this.btNine.TabIndex = 8;
      this.btNine.Text = "9";
      this.btNine.UseVisualStyleBackColor = true;
      this.btNine.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btEight
      // 
      this.btEight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btEight.Location = new System.Drawing.Point(40, 39);
      this.btEight.Name = "btEight";
      this.btEight.Size = new System.Drawing.Size(30, 30);
      this.btEight.TabIndex = 7;
      this.btEight.Text = "8";
      this.btEight.UseVisualStyleBackColor = true;
      this.btEight.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btSeven
      // 
      this.btSeven.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btSeven.Location = new System.Drawing.Point(7, 39);
      this.btSeven.Name = "btSeven";
      this.btSeven.Size = new System.Drawing.Size(30, 30);
      this.btSeven.TabIndex = 6;
      this.btSeven.Text = "7";
      this.btSeven.UseVisualStyleBackColor = true;
      this.btSeven.Click += new System.EventHandler(this.com_NumberButton_Click);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCancel.Location = new System.Drawing.Point(73, 6);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(30, 30);
      this.btCancel.TabIndex = 5;
      this.btCancel.Text = "C";
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
      // 
      // btCancelEntry
      // 
      this.btCancelEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btCancelEntry.Location = new System.Drawing.Point(40, 6);
      this.btCancelEntry.Name = "btCancelEntry";
      this.btCancelEntry.Size = new System.Drawing.Size(30, 30);
      this.btCancelEntry.TabIndex = 4;
      this.btCancelEntry.Text = "CE";
      this.btCancelEntry.UseVisualStyleBackColor = true;
      this.btCancelEntry.Click += new System.EventHandler(this.btCancelEntry_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(165, 218);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.tbEntry);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbEntry;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btCancelEntry;
        private System.Windows.Forms.Button btEqual;
        private System.Windows.Forms.Button btPlus;
        private System.Windows.Forms.Button btMinus;
        private System.Windows.Forms.Button btTimes;
        private System.Windows.Forms.Button btDivision;
        private System.Windows.Forms.Button btThree;
        private System.Windows.Forms.Button btTwo;
        private System.Windows.Forms.Button btOne;
        private System.Windows.Forms.Button btSix;
        private System.Windows.Forms.Button btFive;
        private System.Windows.Forms.Button btFour;
        private System.Windows.Forms.Button btNine;
        private System.Windows.Forms.Button btEight;
        private System.Windows.Forms.Button btSeven;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btZero;
    }
}

