namespace hansot_pos
{
    partial class Payment
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
            this.OrderedMenuListBox = new System.Windows.Forms.ListBox();
            this.Pay = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // OrderedMenuListBox
            // 
            this.OrderedMenuListBox.FormattingEnabled = true;
            this.OrderedMenuListBox.ItemHeight = 12;
            this.OrderedMenuListBox.Location = new System.Drawing.Point(12, 12);
            this.OrderedMenuListBox.Name = "OrderedMenuListBox";
            this.OrderedMenuListBox.Size = new System.Drawing.Size(450, 424);
            this.OrderedMenuListBox.TabIndex = 0;
            // 
            // Pay
            // 
            this.Pay.Font = new System.Drawing.Font("Gulim", 20F);
            this.Pay.Location = new System.Drawing.Point(468, 376);
            this.Pay.Name = "Pay";
            this.Pay.Size = new System.Drawing.Size(157, 60);
            this.Pay.TabIndex = 1;
            this.Pay.Text = "결제";
            this.Pay.UseVisualStyleBackColor = true;
            this.Pay.Click += new System.EventHandler(this.Pay_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Gulim", 20F);
            this.Cancel.Location = new System.Drawing.Point(631, 376);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(157, 60);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "취소";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Gulim", 20F);
            this.radioButton1.Location = new System.Drawing.Point(585, 243);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(84, 31);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "현금";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Gulim", 20F);
            this.radioButton2.Location = new System.Drawing.Point(585, 299);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(84, 31);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "카드";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Pay);
            this.Controls.Add(this.OrderedMenuListBox);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox OrderedMenuListBox;
        private System.Windows.Forms.Button Pay;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}