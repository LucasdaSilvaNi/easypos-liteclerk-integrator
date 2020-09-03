namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnPOSDeliveryCustomerInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPOSDeliveryCustomerInformation));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTenderSalesCustomer = new System.Windows.Forms.ComboBox();
            this.textBoxCustomerPhoneNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCustomerCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCustomerAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCustomerContactName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 50);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.POS;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Delivery Customer Information";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(79)))), ((int)(((byte)(28)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(512, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(109, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Esc - Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonOK.FlatAppearance.BorderSize = 0;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.Location = new System.Drawing.Point(396, 10);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(112, 32);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.TabStop = false;
            this.buttonOK.Text = "Ent - OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(23, 75);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Phone Number:";
            // 
            // comboBoxTenderSalesCustomer
            // 
            this.comboBoxTenderSalesCustomer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboBoxTenderSalesCustomer.FormattingEnabled = true;
            this.comboBoxTenderSalesCustomer.Location = new System.Drawing.Point(146, 39);
            this.comboBoxTenderSalesCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxTenderSalesCustomer.Name = "comboBoxTenderSalesCustomer";
            this.comboBoxTenderSalesCustomer.Size = new System.Drawing.Size(475, 29);
            this.comboBoxTenderSalesCustomer.TabIndex = 17;
            this.comboBoxTenderSalesCustomer.TabStop = false;
            this.comboBoxTenderSalesCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenderSalesCustomer_SelectedIndexChanged);
            // 
            // textBoxCustomerPhoneNumber
            // 
            this.textBoxCustomerPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxCustomerPhoneNumber.Location = new System.Drawing.Point(146, 73);
            this.textBoxCustomerPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerPhoneNumber.Name = "textBoxCustomerPhoneNumber";
            this.textBoxCustomerPhoneNumber.ReadOnly = true;
            this.textBoxCustomerPhoneNumber.Size = new System.Drawing.Size(475, 29);
            this.textBoxCustomerPhoneNumber.TabIndex = 15;
            this.textBoxCustomerPhoneNumber.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(62, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "Customer:";
            // 
            // textBoxCustomerCode
            // 
            this.textBoxCustomerCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustomerCode.BackColor = System.Drawing.Color.White;
            this.textBoxCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCustomerCode.Font = new System.Drawing.Font("Segoe UI Semibold", 13.2F, System.Drawing.FontStyle.Bold);
            this.textBoxCustomerCode.Location = new System.Drawing.Point(10, 5);
            this.textBoxCustomerCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerCode.Name = "textBoxCustomerCode";
            this.textBoxCustomerCode.Size = new System.Drawing.Size(611, 31);
            this.textBoxCustomerCode.TabIndex = 0;
            this.textBoxCustomerCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCustomerCode_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxCustomerAddress);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxCustomerContactName);
            this.panel2.Controls.Add(this.textBoxCustomerCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxTenderSalesCustomer);
            this.panel2.Controls.Add(this.textBoxCustomerPhoneNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 307);
            this.panel2.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(73, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 22;
            this.label4.Text = "Address:";
            // 
            // textBoxCustomerAddress
            // 
            this.textBoxCustomerAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxCustomerAddress.Location = new System.Drawing.Point(146, 137);
            this.textBoxCustomerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerAddress.Multiline = true;
            this.textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            this.textBoxCustomerAddress.ReadOnly = true;
            this.textBoxCustomerAddress.Size = new System.Drawing.Size(475, 161);
            this.textBoxCustomerAddress.TabIndex = 21;
            this.textBoxCustomerAddress.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(29, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Contact Name:";
            // 
            // textBoxCustomerContactName
            // 
            this.textBoxCustomerContactName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxCustomerContactName.Location = new System.Drawing.Point(146, 105);
            this.textBoxCustomerContactName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCustomerContactName.Name = "textBoxCustomerContactName";
            this.textBoxCustomerContactName.ReadOnly = true;
            this.textBoxCustomerContactName.Size = new System.Drawing.Size(475, 29);
            this.textBoxCustomerContactName.TabIndex = 19;
            this.textBoxCustomerContactName.TabStop = false;
            // 
            // TrnPOSDeliveryCustomerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(629, 357);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "TrnPOSDeliveryCustomerInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Customer Information";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTenderSalesCustomer;
        private System.Windows.Forms.TextBox textBoxCustomerPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCustomerCode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCustomerAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCustomerContactName;
    }
}