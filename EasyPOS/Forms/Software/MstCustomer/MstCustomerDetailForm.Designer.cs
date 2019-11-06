namespace EasyPOS.Forms.Software.MstCustomer
{
    partial class MstCustomerDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstCustomerDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxDefaultPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAvailableReward = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxRewardConversion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxRewardNumber = new System.Windows.Forms.TextBox();
            this.checkBoxWithReward = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTIN = new System.Windows.Forms.TextBox();
            this.comboBoxTerm = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCreditLimit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxContactNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxContactPerson = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCustomer = new System.Windows.Forms.TextBox();
            this.textBoxCustomerCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonLock);
            this.panel1.Controls.Add(this.buttonUnlock);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 5;
            // 
            // buttonLock
            // 
            this.buttonLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonLock.FlatAppearance.BorderSize = 0;
            this.buttonLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLock.ForeColor = System.Drawing.Color.White;
            this.buttonLock.Location = new System.Drawing.Point(1112, 12);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(88, 40);
            this.buttonLock.TabIndex = 6;
            this.buttonLock.TabStop = false;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = false;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonUnlock.FlatAppearance.BorderSize = 0;
            this.buttonUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnlock.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUnlock.ForeColor = System.Drawing.Color.White;
            this.buttonUnlock.Location = new System.Drawing.Point(1206, 12);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(88, 40);
            this.buttonUnlock.TabIndex = 5;
            this.buttonUnlock.TabStop = false;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Customer;
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
            this.label1.Size = new System.Drawing.Size(205, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer Detail";
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
            this.buttonClose.Location = new System.Drawing.Point(1300, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxDefaultPrice);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.textBoxAvailableReward);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.textBoxRewardConversion);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxRewardNumber);
            this.panel2.Controls.Add(this.checkBoxWithReward);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxTIN);
            this.panel2.Controls.Add(this.comboBoxTerm);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxCreditLimit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxContactNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxContactPerson);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxAddress);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxCustomer);
            this.panel2.Controls.Add(this.textBoxCustomerCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(1400, 619);
            this.panel2.TabIndex = 6;
            // 
            // textBoxDefaultPrice
            // 
            this.textBoxDefaultPrice.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxDefaultPrice.Location = new System.Drawing.Point(179, 509);
            this.textBoxDefaultPrice.Name = "textBoxDefaultPrice";
            this.textBoxDefaultPrice.Size = new System.Drawing.Size(214, 30);
            this.textBoxDefaultPrice.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label13.Location = new System.Drawing.Point(30, 476);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 23);
            this.label13.TabIndex = 48;
            this.label13.Text = "Available Reward:";
            // 
            // textBoxAvailableReward
            // 
            this.textBoxAvailableReward.Enabled = false;
            this.textBoxAvailableReward.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAvailableReward.Location = new System.Drawing.Point(179, 473);
            this.textBoxAvailableReward.Name = "textBoxAvailableReward";
            this.textBoxAvailableReward.Size = new System.Drawing.Size(214, 30);
            this.textBoxAvailableReward.TabIndex = 11;
            this.textBoxAvailableReward.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAvailableReward.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAvailableReward_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(62, 512);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 23);
            this.label12.TabIndex = 46;
            this.label12.Text = "Default Price:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label11.Location = new System.Drawing.Point(13, 440);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 23);
            this.label11.TabIndex = 44;
            this.label11.Text = "Reward Conversion:";
            // 
            // textBoxRewardConversion
            // 
            this.textBoxRewardConversion.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxRewardConversion.Location = new System.Drawing.Point(179, 437);
            this.textBoxRewardConversion.Name = "textBoxRewardConversion";
            this.textBoxRewardConversion.Size = new System.Drawing.Size(214, 30);
            this.textBoxRewardConversion.TabIndex = 10;
            this.textBoxRewardConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRewardConversion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRewardConversion_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label10.Location = new System.Drawing.Point(35, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 23);
            this.label10.TabIndex = 42;
            this.label10.Text = "Reward Number:";
            // 
            // textBoxRewardNumber
            // 
            this.textBoxRewardNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxRewardNumber.Location = new System.Drawing.Point(179, 401);
            this.textBoxRewardNumber.Name = "textBoxRewardNumber";
            this.textBoxRewardNumber.Size = new System.Drawing.Size(214, 30);
            this.textBoxRewardNumber.TabIndex = 9;
            // 
            // checkBoxWithReward
            // 
            this.checkBoxWithReward.AutoSize = true;
            this.checkBoxWithReward.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.checkBoxWithReward.Location = new System.Drawing.Point(179, 368);
            this.checkBoxWithReward.Name = "checkBoxWithReward";
            this.checkBoxWithReward.Size = new System.Drawing.Size(37, 27);
            this.checkBoxWithReward.TabIndex = 8;
            this.checkBoxWithReward.Text = " ";
            this.checkBoxWithReward.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label14.Location = new System.Drawing.Point(62, 369);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(111, 23);
            this.label14.TabIndex = 40;
            this.label14.Text = "With Reward:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(132, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 23);
            this.label9.TabIndex = 38;
            this.label9.Text = "TIN:";
            // 
            // textBoxTIN
            // 
            this.textBoxTIN.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxTIN.Location = new System.Drawing.Point(179, 332);
            this.textBoxTIN.Name = "textBoxTIN";
            this.textBoxTIN.Size = new System.Drawing.Size(214, 30);
            this.textBoxTIN.TabIndex = 7;
            // 
            // comboBoxTerm
            // 
            this.comboBoxTerm.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxTerm.FormattingEnabled = true;
            this.comboBoxTerm.Location = new System.Drawing.Point(179, 295);
            this.comboBoxTerm.Name = "comboBoxTerm";
            this.comboBoxTerm.Size = new System.Drawing.Size(214, 31);
            this.comboBoxTerm.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label8.Location = new System.Drawing.Point(122, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 23);
            this.label8.TabIndex = 36;
            this.label8.Text = "Term:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(71, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 23);
            this.label7.TabIndex = 14;
            this.label7.Text = "Credit Limit:";
            // 
            // textBoxCreditLimit
            // 
            this.textBoxCreditLimit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditLimit.Location = new System.Drawing.Point(179, 259);
            this.textBoxCreditLimit.Name = "textBoxCreditLimit";
            this.textBoxCreditLimit.Size = new System.Drawing.Size(214, 30);
            this.textBoxCreditLimit.TabIndex = 5;
            this.textBoxCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCreditLimit_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(31, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Contact Number:";
            // 
            // textBoxContactNumber
            // 
            this.textBoxContactNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxContactNumber.Location = new System.Drawing.Point(179, 223);
            this.textBoxContactNumber.Name = "textBoxContactNumber";
            this.textBoxContactNumber.Size = new System.Drawing.Size(214, 30);
            this.textBoxContactNumber.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(43, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contact Person:";
            // 
            // textBoxContactPerson
            // 
            this.textBoxContactPerson.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxContactPerson.Location = new System.Drawing.Point(179, 187);
            this.textBoxContactPerson.Name = "textBoxContactPerson";
            this.textBoxContactPerson.Size = new System.Drawing.Size(284, 30);
            this.textBoxContactPerson.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(99, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Address:";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAddress.Location = new System.Drawing.Point(179, 79);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(409, 102);
            this.textBoxAddress.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(85, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Customer:";
            // 
            // textBoxCustomer
            // 
            this.textBoxCustomer.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCustomer.Location = new System.Drawing.Point(179, 43);
            this.textBoxCustomer.Name = "textBoxCustomer";
            this.textBoxCustomer.Size = new System.Drawing.Size(284, 30);
            this.textBoxCustomer.TabIndex = 1;
            // 
            // textBoxCustomerCode
            // 
            this.textBoxCustomerCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCustomerCode.Location = new System.Drawing.Point(179, 7);
            this.textBoxCustomerCode.Name = "textBoxCustomerCode";
            this.textBoxCustomerCode.Size = new System.Drawing.Size(214, 30);
            this.textBoxCustomerCode.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(40, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Customer Code:";
            // 
            // MstCustomerDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MstCustomerDetailForm";
            this.Text = "MstCustomerDetailForm";
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
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxCustomerCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCreditLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxContactNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxContactPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTIN;
        private System.Windows.Forms.ComboBox comboBoxTerm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxRewardConversion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRewardNumber;
        private System.Windows.Forms.CheckBox checkBoxWithReward;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxAvailableReward;
        private System.Windows.Forms.TextBox textBoxDefaultPrice;
    }
}