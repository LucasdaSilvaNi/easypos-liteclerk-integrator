namespace EasyPOS.Forms.Software.TrnCollection
{
    partial class TrnCollectionLineDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnCollectionLineDetailForm));
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.comboBoxPayType = new System.Windows.Forms.ComboBox();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.textBoxGiftCertificateNumber = new System.Windows.Forms.TextBox();
            this.dateTimePickerCheckDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxCheckBank = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardVerificationCode = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardNumber = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardType = new System.Windows.Forms.TextBox();
            this.textBoxCreditCardBank = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxOtherInformation = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCreditCardExpiry = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCreditCardHolderName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxCreditCardReferenceNumber = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(126, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Pay Type:";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.AcceptsTab = true;
            this.textBoxAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxAmount.HideSelection = false;
            this.textBoxAmount.Location = new System.Drawing.Point(196, 88);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(206, 26);
            this.textBoxAmount.TabIndex = 39;
            this.textBoxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmount_KeyPress);
            // 
            // comboBoxPayType
            // 
            this.comboBoxPayType.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxPayType.FormattingEnabled = true;
            this.comboBoxPayType.Location = new System.Drawing.Point(196, 57);
            this.comboBoxPayType.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxPayType.Name = "comboBoxPayType";
            this.comboBoxPayType.Size = new System.Drawing.Size(206, 27);
            this.comboBoxPayType.TabIndex = 41;
            this.comboBoxPayType.TabStop = false;
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.AcceptsTab = true;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCheckNumber.HideSelection = false;
            this.textBoxCheckNumber.Location = new System.Drawing.Point(196, 118);
            this.textBoxCheckNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(206, 26);
            this.textBoxCheckNumber.TabIndex = 42;
            // 
            // textBoxGiftCertificateNumber
            // 
            this.textBoxGiftCertificateNumber.AcceptsTab = true;
            this.textBoxGiftCertificateNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxGiftCertificateNumber.HideSelection = false;
            this.textBoxGiftCertificateNumber.Location = new System.Drawing.Point(196, 208);
            this.textBoxGiftCertificateNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxGiftCertificateNumber.Name = "textBoxGiftCertificateNumber";
            this.textBoxGiftCertificateNumber.Size = new System.Drawing.Size(206, 26);
            this.textBoxGiftCertificateNumber.TabIndex = 43;
            // 
            // dateTimePickerCheckDate
            // 
            this.dateTimePickerCheckDate.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.dateTimePickerCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerCheckDate.Location = new System.Drawing.Point(196, 148);
            this.dateTimePickerCheckDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerCheckDate.Name = "dateTimePickerCheckDate";
            this.dateTimePickerCheckDate.Size = new System.Drawing.Size(166, 26);
            this.dateTimePickerCheckDate.TabIndex = 44;
            // 
            // textBoxCheckBank
            // 
            this.textBoxCheckBank.AcceptsTab = true;
            this.textBoxCheckBank.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCheckBank.HideSelection = false;
            this.textBoxCheckBank.Location = new System.Drawing.Point(196, 178);
            this.textBoxCheckBank.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCheckBank.Name = "textBoxCheckBank";
            this.textBoxCheckBank.Size = new System.Drawing.Size(206, 26);
            this.textBoxCheckBank.TabIndex = 45;
            // 
            // textBoxCreditCardVerificationCode
            // 
            this.textBoxCreditCardVerificationCode.AcceptsTab = true;
            this.textBoxCreditCardVerificationCode.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardVerificationCode.HideSelection = false;
            this.textBoxCreditCardVerificationCode.Location = new System.Drawing.Point(612, 237);
            this.textBoxCreditCardVerificationCode.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardVerificationCode.Name = "textBoxCreditCardVerificationCode";
            this.textBoxCreditCardVerificationCode.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardVerificationCode.TabIndex = 46;
            // 
            // textBoxCreditCardNumber
            // 
            this.textBoxCreditCardNumber.AcceptsTab = true;
            this.textBoxCreditCardNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardNumber.HideSelection = false;
            this.textBoxCreditCardNumber.Location = new System.Drawing.Point(611, 57);
            this.textBoxCreditCardNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardNumber.Name = "textBoxCreditCardNumber";
            this.textBoxCreditCardNumber.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardNumber.TabIndex = 47;
            // 
            // textBoxCreditCardType
            // 
            this.textBoxCreditCardType.AcceptsTab = true;
            this.textBoxCreditCardType.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardType.HideSelection = false;
            this.textBoxCreditCardType.Location = new System.Drawing.Point(612, 147);
            this.textBoxCreditCardType.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardType.Name = "textBoxCreditCardType";
            this.textBoxCreditCardType.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardType.TabIndex = 48;
            // 
            // textBoxCreditCardBank
            // 
            this.textBoxCreditCardBank.AcceptsTab = true;
            this.textBoxCreditCardBank.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardBank.HideSelection = false;
            this.textBoxCreditCardBank.Location = new System.Drawing.Point(612, 177);
            this.textBoxCreditCardBank.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardBank.Name = "textBoxCreditCardBank";
            this.textBoxCreditCardBank.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardBank.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(130, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(89, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 51;
            this.label4.Text = "Check Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label5.Location = new System.Drawing.Point(110, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 52;
            this.label5.Text = "Check Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label6.Location = new System.Drawing.Point(109, 181);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 53;
            this.label6.Text = "Check Bank:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label7.Location = new System.Drawing.Point(422, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 19);
            this.label7.TabIndex = 54;
            this.label7.Text = "Credit Card Verification Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label8.Location = new System.Drawing.Point(471, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 19);
            this.label8.TabIndex = 55;
            this.label8.Text = "Credit Card Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(494, 150);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 19);
            this.label9.TabIndex = 56;
            this.label9.Text = "Credit Card Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label10.Location = new System.Drawing.Point(492, 180);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 19);
            this.label10.TabIndex = 57;
            this.label10.Text = "Credit Card Bank:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label11.Location = new System.Drawing.Point(39, 211);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 19);
            this.label11.TabIndex = 58;
            this.label11.Text = "Gift Certificate Number:";
            // 
            // textBoxOtherInformation
            // 
            this.textBoxOtherInformation.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxOtherInformation.Location = new System.Drawing.Point(196, 238);
            this.textBoxOtherInformation.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxOtherInformation.Multiline = true;
            this.textBoxOtherInformation.Name = "textBoxOtherInformation";
            this.textBoxOtherInformation.Size = new System.Drawing.Size(206, 76);
            this.textBoxOtherInformation.TabIndex = 59;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label12.Location = new System.Drawing.Point(68, 241);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 19);
            this.label12.TabIndex = 60;
            this.label12.Text = "Other Information:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label13.Location = new System.Drawing.Point(486, 211);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 19);
            this.label13.TabIndex = 62;
            this.label13.Text = "Credit Card Expiry:";
            // 
            // textBoxCreditCardExpiry
            // 
            this.textBoxCreditCardExpiry.AcceptsTab = true;
            this.textBoxCreditCardExpiry.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardExpiry.HideSelection = false;
            this.textBoxCreditCardExpiry.Location = new System.Drawing.Point(612, 207);
            this.textBoxCreditCardExpiry.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardExpiry.Name = "textBoxCreditCardExpiry";
            this.textBoxCreditCardExpiry.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardExpiry.TabIndex = 63;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label14.Location = new System.Drawing.Point(440, 90);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(167, 19);
            this.label14.TabIndex = 65;
            this.label14.Text = "Credit Card Holder Name:";
            // 
            // textBoxCreditCardHolderName
            // 
            this.textBoxCreditCardHolderName.AcceptsTab = true;
            this.textBoxCreditCardHolderName.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardHolderName.HideSelection = false;
            this.textBoxCreditCardHolderName.Location = new System.Drawing.Point(611, 87);
            this.textBoxCreditCardHolderName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardHolderName.Name = "textBoxCreditCardHolderName";
            this.textBoxCreditCardHolderName.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardHolderName.TabIndex = 64;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label15.Location = new System.Drawing.Point(408, 120);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(199, 19);
            this.label15.TabIndex = 67;
            this.label15.Text = "Credit Card Reference Number:";
            // 
            // textBoxCreditCardReferenceNumber
            // 
            this.textBoxCreditCardReferenceNumber.AcceptsTab = true;
            this.textBoxCreditCardReferenceNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxCreditCardReferenceNumber.HideSelection = false;
            this.textBoxCreditCardReferenceNumber.Location = new System.Drawing.Point(611, 117);
            this.textBoxCreditCardReferenceNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCreditCardReferenceNumber.Name = "textBoxCreditCardReferenceNumber";
            this.textBoxCreditCardReferenceNumber.Size = new System.Drawing.Size(206, 26);
            this.textBoxCreditCardReferenceNumber.TabIndex = 66;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(673, 10);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(70, 32);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
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
            this.buttonClose.Location = new System.Drawing.Point(748, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Collection Line Detail";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.PurchaseOrder;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 50);
            this.panel1.TabIndex = 68;
            // 
            // TrnCollectionLineDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBoxCreditCardReferenceNumber);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxCreditCardHolderName);
            this.Controls.Add(this.textBoxCreditCardExpiry);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxOtherInformation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCreditCardBank);
            this.Controls.Add(this.textBoxCreditCardType);
            this.Controls.Add(this.textBoxCreditCardNumber);
            this.Controls.Add(this.textBoxCreditCardVerificationCode);
            this.Controls.Add(this.textBoxCheckBank);
            this.Controls.Add(this.dateTimePickerCheckDate);
            this.Controls.Add(this.textBoxGiftCertificateNumber);
            this.Controls.Add(this.textBoxCheckNumber);
            this.Controls.Add(this.comboBoxPayType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAmount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnCollectionLineDetailForm";
            this.Text = "Collection Line Detail";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.ComboBox comboBoxPayType;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.TextBox textBoxGiftCertificateNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerCheckDate;
        private System.Windows.Forms.TextBox textBoxCheckBank;
        private System.Windows.Forms.TextBox textBoxCreditCardVerificationCode;
        private System.Windows.Forms.TextBox textBoxCreditCardNumber;
        private System.Windows.Forms.TextBox textBoxCreditCardType;
        private System.Windows.Forms.TextBox textBoxCreditCardBank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxOtherInformation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCreditCardExpiry;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCreditCardHolderName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxCreditCardReferenceNumber;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}