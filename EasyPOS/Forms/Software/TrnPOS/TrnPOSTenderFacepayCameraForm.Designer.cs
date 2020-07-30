namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnPOSTenderFacepayCameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPOSTenderFacepayCameraForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBoxTappedCardNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxTotalSalesAmount = new System.Windows.Forms.TextBox();
            this.videoSourcePlayerCamera = new AForge.Controls.VideoSourcePlayer();
            this.comboBoxCameraDevices = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonPay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 50);
            this.panel1.TabIndex = 5;
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
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Facepay Camera";
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
            this.buttonClose.Location = new System.Drawing.Point(404, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonPay.FlatAppearance.BorderSize = 0;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.ForeColor = System.Drawing.Color.White;
            this.buttonPay.Location = new System.Drawing.Point(328, 10);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(70, 32);
            this.buttonPay.TabIndex = 20;
            this.buttonPay.TabStop = false;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonOpen);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.videoSourcePlayerCamera);
            this.panel2.Controls.Add(this.comboBoxCameraDevices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 456);
            this.panel2.TabIndex = 6;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOpen.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonOpen.ForeColor = System.Drawing.Color.Black;
            this.buttonOpen.Location = new System.Drawing.Point(404, 109);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOpen.Size = new System.Drawing.Size(70, 29);
            this.buttonOpen.TabIndex = 22;
            this.buttonOpen.TabStop = false;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.textBoxTappedCardNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 66);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 38);
            this.panel5.TabIndex = 43;
            // 
            // textBoxTappedCardNumber
            // 
            this.textBoxTappedCardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTappedCardNumber.BackColor = System.Drawing.Color.White;
            this.textBoxTappedCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTappedCardNumber.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxTappedCardNumber.Location = new System.Drawing.Point(10, 8);
            this.textBoxTappedCardNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTappedCardNumber.Name = "textBoxTappedCardNumber";
            this.textBoxTappedCardNumber.PasswordChar = '•';
            this.textBoxTappedCardNumber.Size = new System.Drawing.Size(464, 22);
            this.textBoxTappedCardNumber.TabIndex = 0;
            this.textBoxTappedCardNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTappedCardNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTappedCardNumber_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.textBoxTotalSalesAmount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(484, 66);
            this.panel3.TabIndex = 42;
            // 
            // textBoxTotalSalesAmount
            // 
            this.textBoxTotalSalesAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalSalesAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxTotalSalesAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalSalesAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold);
            this.textBoxTotalSalesAmount.ForeColor = System.Drawing.Color.White;
            this.textBoxTotalSalesAmount.Location = new System.Drawing.Point(-11, 5);
            this.textBoxTotalSalesAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxTotalSalesAmount.Name = "textBoxTotalSalesAmount";
            this.textBoxTotalSalesAmount.ReadOnly = true;
            this.textBoxTotalSalesAmount.Size = new System.Drawing.Size(485, 54);
            this.textBoxTotalSalesAmount.TabIndex = 1;
            this.textBoxTotalSalesAmount.TabStop = false;
            this.textBoxTotalSalesAmount.Text = "0.00";
            this.textBoxTotalSalesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // videoSourcePlayerCamera
            // 
            this.videoSourcePlayerCamera.BackColor = System.Drawing.Color.White;
            this.videoSourcePlayerCamera.Location = new System.Drawing.Point(10, 142);
            this.videoSourcePlayerCamera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.videoSourcePlayerCamera.Name = "videoSourcePlayerCamera";
            this.videoSourcePlayerCamera.Size = new System.Drawing.Size(463, 302);
            this.videoSourcePlayerCamera.TabIndex = 3;
            this.videoSourcePlayerCamera.Text = "videoSourcePlayer1";
            this.videoSourcePlayerCamera.VideoSource = null;
            this.videoSourcePlayerCamera.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayerCamera_NewFrame);
            // 
            // comboBoxCameraDevices
            // 
            this.comboBoxCameraDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCameraDevices.FormattingEnabled = true;
            this.comboBoxCameraDevices.Location = new System.Drawing.Point(10, 110);
            this.comboBoxCameraDevices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCameraDevices.Name = "comboBoxCameraDevices";
            this.comboBoxCameraDevices.Size = new System.Drawing.Size(388, 27);
            this.comboBoxCameraDevices.TabIndex = 0;
            // 
            // TrnPOSTenderFacepayCameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(484, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "TrnPOSTenderFacepayCameraForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facepay Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrnSalesDetailTenderFacepayCameraForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxCameraDevices;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerCamera;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBoxTappedCardNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxTotalSalesAmount;
        private System.Windows.Forms.Button buttonOpen;
    }
}