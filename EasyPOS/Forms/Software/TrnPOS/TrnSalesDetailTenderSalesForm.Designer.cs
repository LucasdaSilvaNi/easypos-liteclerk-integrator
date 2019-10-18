namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnSalesDetailTenderSalesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesDetailTenderSalesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTenderSalesCustomer = new System.Windows.Forms.ComboBox();
            this.textBoxTenderSalesRewardAvailable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCustomerCode = new System.Windows.Forms.TextBox();
            this.comboBoxTenderSalesTerms = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTenderSalesRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTenderSalesUsers = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 63);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.POS;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(52)))), ((int)(((byte)(18)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(52)))), ((int)(((byte)(18)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(399, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(126)))), ((int)(((byte)(181)))));
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(126)))), ((int)(((byte)(181)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(305, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 40);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 28);
            this.label5.TabIndex = 18;
            this.label5.Text = "Reward Available:";
            // 
            // comboBoxTenderSalesCustomer
            // 
            this.comboBoxTenderSalesCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxTenderSalesCustomer.FormattingEnabled = true;
            this.comboBoxTenderSalesCustomer.Location = new System.Drawing.Point(163, 133);
            this.comboBoxTenderSalesCustomer.Name = "comboBoxTenderSalesCustomer";
            this.comboBoxTenderSalesCustomer.Size = new System.Drawing.Size(324, 36);
            this.comboBoxTenderSalesCustomer.TabIndex = 17;
            this.comboBoxTenderSalesCustomer.TabStop = false;
            this.comboBoxTenderSalesCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenderSalesCustomer_SelectedIndexChanged);
            // 
            // textBoxTenderSalesRewardAvailable
            // 
            this.textBoxTenderSalesRewardAvailable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxTenderSalesRewardAvailable.Location = new System.Drawing.Point(163, 170);
            this.textBoxTenderSalesRewardAvailable.Name = "textBoxTenderSalesRewardAvailable";
            this.textBoxTenderSalesRewardAvailable.ReadOnly = true;
            this.textBoxTenderSalesRewardAvailable.Size = new System.Drawing.Size(324, 34);
            this.textBoxTenderSalesRewardAvailable.TabIndex = 15;
            this.textBoxTenderSalesRewardAvailable.TabStop = false;
            this.textBoxTenderSalesRewardAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Customer:";
            // 
            // textBoxCustomerCode
            // 
            this.textBoxCustomerCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomerCode.BackColor = System.Drawing.Color.White;
            this.textBoxCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCustomerCode.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.textBoxCustomerCode.Location = new System.Drawing.Point(12, 75);
            this.textBoxCustomerCode.Name = "textBoxCustomerCode";
            this.textBoxCustomerCode.Size = new System.Drawing.Size(475, 43);
            this.textBoxCustomerCode.TabIndex = 0;
            this.textBoxCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCustomerCode_KeyDown);
            // 
            // comboBoxTenderSalesTerms
            // 
            this.comboBoxTenderSalesTerms.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxTenderSalesTerms.FormattingEnabled = true;
            this.comboBoxTenderSalesTerms.Location = new System.Drawing.Point(163, 205);
            this.comboBoxTenderSalesTerms.Name = "comboBoxTenderSalesTerms";
            this.comboBoxTenderSalesTerms.Size = new System.Drawing.Size(324, 36);
            this.comboBoxTenderSalesTerms.TabIndex = 21;
            this.comboBoxTenderSalesTerms.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(12, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Terms:";
            // 
            // textBoxTenderSalesRemarks
            // 
            this.textBoxTenderSalesRemarks.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxTenderSalesRemarks.Location = new System.Drawing.Point(163, 242);
            this.textBoxTenderSalesRemarks.Multiline = true;
            this.textBoxTenderSalesRemarks.Name = "textBoxTenderSalesRemarks";
            this.textBoxTenderSalesRemarks.Size = new System.Drawing.Size(324, 200);
            this.textBoxTenderSalesRemarks.TabIndex = 22;
            this.textBoxTenderSalesRemarks.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(12, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "Remarks:";
            // 
            // comboBoxTenderSalesUsers
            // 
            this.comboBoxTenderSalesUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxTenderSalesUsers.FormattingEnabled = true;
            this.comboBoxTenderSalesUsers.Location = new System.Drawing.Point(163, 448);
            this.comboBoxTenderSalesUsers.Name = "comboBoxTenderSalesUsers";
            this.comboBoxTenderSalesUsers.Size = new System.Drawing.Size(324, 36);
            this.comboBoxTenderSalesUsers.TabIndex = 25;
            this.comboBoxTenderSalesUsers.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(7, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 28);
            this.label6.TabIndex = 24;
            this.label6.Text = "Sales Agent:";
            // 
            // TrnSalesDetailTenderSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 500);
            this.Controls.Add(this.comboBoxTenderSalesUsers);
            this.Controls.Add(this.textBoxTenderSalesRemarks);
            this.Controls.Add(this.comboBoxTenderSalesTerms);
            this.Controls.Add(this.comboBoxTenderSalesCustomer);
            this.Controls.Add(this.textBoxTenderSalesRewardAvailable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxCustomerCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrnSalesDetailTenderSalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTenderSalesCustomer;
        private System.Windows.Forms.TextBox textBoxTenderSalesRewardAvailable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCustomerCode;
        private System.Windows.Forms.ComboBox comboBoxTenderSalesTerms;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTenderSalesRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTenderSalesUsers;
        private System.Windows.Forms.Label label6;
    }
}