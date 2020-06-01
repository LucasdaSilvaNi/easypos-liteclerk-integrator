namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnPOSTenderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPOSTenderForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSales = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonTender = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxChangeAmount = new System.Windows.Forms.TextBox();
            this.textBoxTenderAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCustomerCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelInvoiceDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelInvoiceNumber = new System.Windows.Forms.Label();
            this.textBoxTotalSalesAmount = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewTenderPayType = new System.Windows.Forms.DataGridView();
            this.ColumnTenderListPayTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenderListPayTypePayTypeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenderListPayTypePayType = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnTenderListNumpad = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnTenderListPayTypeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTenderListPayTypeOtherInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenderPayType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonSales);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonTender);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 50);
            this.panel1.TabIndex = 3;
            // 
            // buttonSales
            // 
            this.buttonSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSales.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSales.FlatAppearance.BorderSize = 0;
            this.buttonSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSales.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSales.ForeColor = System.Drawing.Color.White;
            this.buttonSales.Location = new System.Drawing.Point(518, 10);
            this.buttonSales.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSales.Name = "buttonSales";
            this.buttonSales.Size = new System.Drawing.Size(70, 32);
            this.buttonSales.TabIndex = 4;
            this.buttonSales.TabStop = false;
            this.buttonSales.Text = "Sales";
            this.buttonSales.UseVisualStyleBackColor = false;
            this.buttonSales.Click += new System.EventHandler(this.buttonSales_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.POS;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
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
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tender";
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
            this.buttonClose.Location = new System.Drawing.Point(668, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonTender
            // 
            this.buttonTender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonTender.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonTender.FlatAppearance.BorderSize = 0;
            this.buttonTender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTender.ForeColor = System.Drawing.Color.White;
            this.buttonTender.Location = new System.Drawing.Point(593, 10);
            this.buttonTender.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTender.Name = "buttonTender";
            this.buttonTender.Size = new System.Drawing.Size(70, 32);
            this.buttonTender.TabIndex = 1;
            this.buttonTender.TabStop = false;
            this.buttonTender.Text = "Tender";
            this.buttonTender.UseVisualStyleBackColor = false;
            this.buttonTender.Click += new System.EventHandler(this.buttonTender_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.textBoxChangeAmount);
            this.panel3.Controls.Add(this.textBoxTenderAmount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 445);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 71);
            this.panel3.TabIndex = 6;
            // 
            // textBoxChangeAmount
            // 
            this.textBoxChangeAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChangeAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxChangeAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxChangeAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.textBoxChangeAmount.ForeColor = System.Drawing.Color.White;
            this.textBoxChangeAmount.Location = new System.Drawing.Point(301, 34);
            this.textBoxChangeAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxChangeAmount.Name = "textBoxChangeAmount";
            this.textBoxChangeAmount.ReadOnly = true;
            this.textBoxChangeAmount.Size = new System.Drawing.Size(431, 27);
            this.textBoxChangeAmount.TabIndex = 12;
            this.textBoxChangeAmount.TabStop = false;
            this.textBoxChangeAmount.Text = "0.00";
            this.textBoxChangeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxTenderAmount
            // 
            this.textBoxTenderAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTenderAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxTenderAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTenderAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.textBoxTenderAmount.ForeColor = System.Drawing.Color.White;
            this.textBoxTenderAmount.Location = new System.Drawing.Point(301, 9);
            this.textBoxTenderAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTenderAmount.Name = "textBoxTenderAmount";
            this.textBoxTenderAmount.ReadOnly = true;
            this.textBoxTenderAmount.Size = new System.Drawing.Size(431, 27);
            this.textBoxTenderAmount.TabIndex = 11;
            this.textBoxTenderAmount.TabStop = false;
            this.textBoxTenderAmount.Text = "0.00";
            this.textBoxTenderAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Change:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tender Amount:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.textBoxTotalSalesAmount);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.labelRemarks);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelCustomerCode);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelCustomer);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelInvoiceDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelInvoiceNumber);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 61);
            this.panel2.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.Location = new System.Drawing.Point(11, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Remarks:";
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelRemarks.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelRemarks.Location = new System.Drawing.Point(83, 37);
            this.labelRemarks.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(0, 15);
            this.labelRemarks.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Location = new System.Drawing.Point(171, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Code:";
            // 
            // labelCustomerCode
            // 
            this.labelCustomerCode.AutoSize = true;
            this.labelCustomerCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCustomerCode.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCustomerCode.Location = new System.Drawing.Point(236, 7);
            this.labelCustomerCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomerCode.Name = "labelCustomerCode";
            this.labelCustomerCode.Size = new System.Drawing.Size(0, 15);
            this.labelCustomerCode.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label6.Location = new System.Drawing.Point(171, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Customer:";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCustomer.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelCustomer.Location = new System.Drawing.Point(236, 22);
            this.labelCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(0, 15);
            this.labelCustomer.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Order Date:";
            // 
            // labelInvoiceDate
            // 
            this.labelInvoiceDate.AutoSize = true;
            this.labelInvoiceDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelInvoiceDate.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelInvoiceDate.Location = new System.Drawing.Point(83, 22);
            this.labelInvoiceDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvoiceDate.Name = "labelInvoiceDate";
            this.labelInvoiceDate.Size = new System.Drawing.Size(77, 15);
            this.labelInvoiceDate.TabIndex = 8;
            this.labelInvoiceDate.Text = "MM/dd/yyyy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label5.Location = new System.Drawing.Point(11, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Order No.:";
            // 
            // labelInvoiceNumber
            // 
            this.labelInvoiceNumber.AutoSize = true;
            this.labelInvoiceNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelInvoiceNumber.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.labelInvoiceNumber.Location = new System.Drawing.Point(83, 7);
            this.labelInvoiceNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvoiceNumber.Name = "labelInvoiceNumber";
            this.labelInvoiceNumber.Size = new System.Drawing.Size(77, 15);
            this.labelInvoiceNumber.TabIndex = 6;
            this.labelInvoiceNumber.Text = "0000000000";
            // 
            // textBoxTotalSalesAmount
            // 
            this.textBoxTotalSalesAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalSalesAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxTotalSalesAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalSalesAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 35F, System.Drawing.FontStyle.Bold);
            this.textBoxTotalSalesAmount.ForeColor = System.Drawing.Color.White;
            this.textBoxTotalSalesAmount.Location = new System.Drawing.Point(426, -3);
            this.textBoxTotalSalesAmount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTotalSalesAmount.Name = "textBoxTotalSalesAmount";
            this.textBoxTotalSalesAmount.ReadOnly = true;
            this.textBoxTotalSalesAmount.Size = new System.Drawing.Size(311, 63);
            this.textBoxTotalSalesAmount.TabIndex = 1;
            this.textBoxTotalSalesAmount.TabStop = false;
            this.textBoxTotalSalesAmount.Text = "0.00";
            this.textBoxTotalSalesAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewTenderPayType);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 111);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(748, 334);
            this.panel4.TabIndex = 8;
            // 
            // dataGridViewTenderPayType
            // 
            this.dataGridViewTenderPayType.AllowUserToAddRows = false;
            this.dataGridViewTenderPayType.AllowUserToDeleteRows = false;
            this.dataGridViewTenderPayType.AllowUserToResizeColumns = false;
            this.dataGridViewTenderPayType.AllowUserToResizeRows = false;
            this.dataGridViewTenderPayType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTenderPayType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTenderPayType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTenderPayType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTenderPayType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTenderListPayTypeId,
            this.ColumnTenderListPayTypePayTypeCode,
            this.ColumnTenderListPayTypePayType,
            this.ColumnTenderListNumpad,
            this.ColumnTenderListPayTypeAmount,
            this.ColumnTenderListPayTypeOtherInformation});
            this.dataGridViewTenderPayType.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewTenderPayType.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewTenderPayType.MultiSelect = false;
            this.dataGridViewTenderPayType.Name = "dataGridViewTenderPayType";
            this.dataGridViewTenderPayType.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTenderPayType.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTenderPayType.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.dataGridViewTenderPayType.RowTemplate.Height = 50;
            this.dataGridViewTenderPayType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTenderPayType.Size = new System.Drawing.Size(729, 325);
            this.dataGridViewTenderPayType.TabIndex = 0;
            this.dataGridViewTenderPayType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTenderPayType_CellClick);
            this.dataGridViewTenderPayType.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTenderPayType_CellEndEdit);
            // 
            // ColumnTenderListPayTypeId
            // 
            this.ColumnTenderListPayTypeId.HeaderText = "Id";
            this.ColumnTenderListPayTypeId.Name = "ColumnTenderListPayTypeId";
            this.ColumnTenderListPayTypeId.Visible = false;
            // 
            // ColumnTenderListPayTypePayTypeCode
            // 
            this.ColumnTenderListPayTypePayTypeCode.HeaderText = "Code";
            this.ColumnTenderListPayTypePayTypeCode.Name = "ColumnTenderListPayTypePayTypeCode";
            this.ColumnTenderListPayTypePayTypeCode.Visible = false;
            // 
            // ColumnTenderListPayTypePayType
            // 
            this.ColumnTenderListPayTypePayType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnTenderListPayTypePayType.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnTenderListPayTypePayType.FillWeight = 5.076141F;
            this.ColumnTenderListPayTypePayType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnTenderListPayTypePayType.HeaderText = "PayType";
            this.ColumnTenderListPayTypePayType.Name = "ColumnTenderListPayTypePayType";
            this.ColumnTenderListPayTypePayType.ReadOnly = true;
            this.ColumnTenderListPayTypePayType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnTenderListNumpad
            // 
            this.ColumnTenderListNumpad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnTenderListNumpad.HeaderText = "";
            this.ColumnTenderListNumpad.Name = "ColumnTenderListNumpad";
            this.ColumnTenderListNumpad.Width = 70;
            // 
            // ColumnTenderListPayTypeAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.ColumnTenderListPayTypeAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnTenderListPayTypeAmount.FillWeight = 194.9239F;
            this.ColumnTenderListPayTypeAmount.HeaderText = "Amount";
            this.ColumnTenderListPayTypeAmount.Name = "ColumnTenderListPayTypeAmount";
            this.ColumnTenderListPayTypeAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnTenderListPayTypeAmount.Width = 300;
            // 
            // ColumnTenderListPayTypeOtherInformation
            // 
            this.ColumnTenderListPayTypeOtherInformation.HeaderText = "Other Information";
            this.ColumnTenderListPayTypeOtherInformation.Name = "ColumnTenderListPayTypeOtherInformation";
            this.ColumnTenderListPayTypeOtherInformation.Visible = false;
            // 
            // TrnPOSTenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(748, 516);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "TrnPOSTenderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrnSalesDetailTenderForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTenderPayType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonTender;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelInvoiceDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelInvoiceNumber;
        private System.Windows.Forms.TextBox textBoxTotalSalesAmount;
        private System.Windows.Forms.TextBox textBoxChangeAmount;
        private System.Windows.Forms.TextBox textBoxTenderAmount;
        private System.Windows.Forms.Button buttonSales;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewTenderPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenderListPayTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenderListPayTypePayTypeCode;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTenderListPayTypePayType;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTenderListNumpad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenderListPayTypeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTenderListPayTypeOtherInformation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCustomerCode;
    }
}