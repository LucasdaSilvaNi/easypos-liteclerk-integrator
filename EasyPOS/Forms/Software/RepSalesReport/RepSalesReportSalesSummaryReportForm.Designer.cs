namespace EasyPOS.Forms.Software.RepSalesReport
{
    partial class RepSalesReportSalesSummaryReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepSalesReportSalesSummaryReportForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSalesListPageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesListPageListNext = new System.Windows.Forms.Button();
            this.buttonSalesListPageListLast = new System.Windows.Forms.Button();
            this.buttonSalesListPageListPrevious = new System.Windows.Forms.Button();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewSalesSummaryReport = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPeriodId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManualInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTermId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscountId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPreparedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPreparedByUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesSummaryReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonView);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1482, 63);
            this.panel1.TabIndex = 8;
            // 
            // buttonView
            // 
            this.buttonView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonView.FlatAppearance.BorderSize = 0;
            this.buttonView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonView.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonView.ForeColor = System.Drawing.Color.White;
            this.buttonView.Location = new System.Drawing.Point(1287, 11);
            this.buttonView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(88, 40);
            this.buttonView.TabIndex = 5;
            this.buttonView.TabStop = false;
            this.buttonView.Text = "CSV";
            this.buttonView.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales Summary Report";
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
            this.buttonClose.Location = new System.Drawing.Point(1381, 11);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_OnClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dataGridViewSalesSummaryReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1482, 640);
            this.panel2.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textBoxTotalAmount);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.buttonSalesListPageListFirst);
            this.panel4.Controls.Add(this.buttonSalesListPageListNext);
            this.panel4.Controls.Add(this.buttonSalesListPageListLast);
            this.panel4.Controls.Add(this.buttonSalesListPageListPrevious);
            this.panel4.Controls.Add(this.textBoxPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 587);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1482, 53);
            this.panel4.TabIndex = 20;
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTotalAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotalAmount.Location = new System.Drawing.Point(1112, 14);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxTotalAmount.Size = new System.Drawing.Size(308, 23);
            this.textBoxTotalAmount.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(973, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Total Amount:";
            // 
            // buttonSalesListPageListFirst
            // 
            this.buttonSalesListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListFirst.Enabled = false;
            this.buttonSalesListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonSalesListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSalesListPageListFirst.Name = "buttonSalesListPageListFirst";
            this.buttonSalesListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListFirst.TabIndex = 8;
            this.buttonSalesListPageListFirst.Text = "First";
            this.buttonSalesListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListFirst.Click += new System.EventHandler(this.buttonSalesListPageListFirst_Click);
            // 
            // buttonSalesListPageListNext
            // 
            this.buttonSalesListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListNext.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonSalesListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSalesListPageListNext.Name = "buttonSalesListPageListNext";
            this.buttonSalesListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListNext.TabIndex = 10;
            this.buttonSalesListPageListNext.Text = "Next";
            this.buttonSalesListPageListNext.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListNext.Click += new System.EventHandler(this.buttonSalesListPageListNext_Click);
            // 
            // buttonSalesListPageListLast
            // 
            this.buttonSalesListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListLast.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonSalesListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSalesListPageListLast.Name = "buttonSalesListPageListLast";
            this.buttonSalesListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListLast.TabIndex = 11;
            this.buttonSalesListPageListLast.Text = "Last";
            this.buttonSalesListPageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListLast.Click += new System.EventHandler(this.buttonSalesListPageListLast_Click);
            // 
            // buttonSalesListPageListPrevious
            // 
            this.buttonSalesListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListPrevious.Enabled = false;
            this.buttonSalesListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.buttonSalesListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSalesListPageListPrevious.Name = "buttonSalesListPageListPrevious";
            this.buttonSalesListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListPrevious.TabIndex = 9;
            this.buttonSalesListPageListPrevious.Text = "Previous";
            this.buttonSalesListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListPrevious.Click += new System.EventHandler(this.buttonSalesListPageListPrevious_Click);
            // 
            // textBoxPageNumber
            // 
            this.textBoxPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.ReadOnly = true;
            this.textBoxPageNumber.Size = new System.Drawing.Size(69, 23);
            this.textBoxPageNumber.TabIndex = 12;
            this.textBoxPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewSalesSummaryReport
            // 
            this.dataGridViewSalesSummaryReport.AllowUserToAddRows = false;
            this.dataGridViewSalesSummaryReport.AllowUserToDeleteRows = false;
            this.dataGridViewSalesSummaryReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesSummaryReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesSummaryReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesSummaryReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnPeriodId,
            this.ColumnPeriod,
            this.ColumnTerminal,
            this.ColumnSalesDate,
            this.ColumnSalesNumber,
            this.ColumnManualInvoiceNumber,
            this.ColumnTableId,
            this.ColumnCustomerId,
            this.ColumnCustomer,
            this.ColumnAccountId,
            this.ColumnTermId,
            this.ColumnTerm,
            this.ColumnDiscountId,
            this.ColumnRemarks,
            this.ColumnPreparedBy,
            this.ColumnPreparedByUserName,
            this.ColumnAmount,
            this.ColumnTerminalId,
            this.ColumnPax,
            this.ColumnTable});
            this.dataGridViewSalesSummaryReport.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSalesSummaryReport.Name = "dataGridViewSalesSummaryReport";
            this.dataGridViewSalesSummaryReport.ReadOnly = true;
            this.dataGridViewSalesSummaryReport.RowHeadersVisible = false;
            this.dataGridViewSalesSummaryReport.RowTemplate.Height = 24;
            this.dataGridViewSalesSummaryReport.ShowEditingIcon = false;
            this.dataGridViewSalesSummaryReport.Size = new System.Drawing.Size(1482, 640);
            this.dataGridViewSalesSummaryReport.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ColumnId";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnPeriodId
            // 
            this.ColumnPeriodId.DataPropertyName = "ColumnPeriodId";
            this.ColumnPeriodId.HeaderText = "PeriodId";
            this.ColumnPeriodId.Name = "ColumnPeriodId";
            this.ColumnPeriodId.ReadOnly = true;
            this.ColumnPeriodId.Visible = false;
            // 
            // ColumnPeriod
            // 
            this.ColumnPeriod.DataPropertyName = "ColumnPeriod";
            this.ColumnPeriod.HeaderText = "Period";
            this.ColumnPeriod.Name = "ColumnPeriod";
            this.ColumnPeriod.ReadOnly = true;
            this.ColumnPeriod.Visible = false;
            // 
            // ColumnTerminal
            // 
            this.ColumnTerminal.DataPropertyName = "ColumnTerminal";
            this.ColumnTerminal.HeaderText = "Terminal";
            this.ColumnTerminal.Name = "ColumnTerminal";
            this.ColumnTerminal.ReadOnly = true;
            this.ColumnTerminal.Width = 75;
            // 
            // ColumnSalesDate
            // 
            this.ColumnSalesDate.DataPropertyName = "ColumnSalesDate";
            this.ColumnSalesDate.HeaderText = "Date";
            this.ColumnSalesDate.Name = "ColumnSalesDate";
            this.ColumnSalesDate.ReadOnly = true;
            // 
            // ColumnSalesNumber
            // 
            this.ColumnSalesNumber.DataPropertyName = "ColumnSalesNumber";
            this.ColumnSalesNumber.HeaderText = "SalesNumber";
            this.ColumnSalesNumber.Name = "ColumnSalesNumber";
            this.ColumnSalesNumber.ReadOnly = true;
            this.ColumnSalesNumber.Width = 120;
            // 
            // ColumnManualInvoiceNumber
            // 
            this.ColumnManualInvoiceNumber.DataPropertyName = "ColumnManualInvoiceNumber";
            this.ColumnManualInvoiceNumber.FillWeight = 150F;
            this.ColumnManualInvoiceNumber.HeaderText = "Manual Invoice No.";
            this.ColumnManualInvoiceNumber.Name = "ColumnManualInvoiceNumber";
            this.ColumnManualInvoiceNumber.ReadOnly = true;
            this.ColumnManualInvoiceNumber.Width = 150;
            // 
            // ColumnTableId
            // 
            this.ColumnTableId.DataPropertyName = "ColumnTableId";
            this.ColumnTableId.HeaderText = "TableId";
            this.ColumnTableId.Name = "ColumnTableId";
            this.ColumnTableId.ReadOnly = true;
            this.ColumnTableId.Visible = false;
            // 
            // ColumnCustomerId
            // 
            this.ColumnCustomerId.DataPropertyName = "ColumnCustomerId";
            this.ColumnCustomerId.HeaderText = "CustomerId";
            this.ColumnCustomerId.Name = "ColumnCustomerId";
            this.ColumnCustomerId.ReadOnly = true;
            this.ColumnCustomerId.Visible = false;
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.DataPropertyName = "ColumnCustomer";
            this.ColumnCustomer.FillWeight = 150F;
            this.ColumnCustomer.HeaderText = "Customer";
            this.ColumnCustomer.Name = "ColumnCustomer";
            this.ColumnCustomer.ReadOnly = true;
            this.ColumnCustomer.Width = 150;
            // 
            // ColumnAccountId
            // 
            this.ColumnAccountId.DataPropertyName = "ColumnAccountId";
            this.ColumnAccountId.HeaderText = "AccountId";
            this.ColumnAccountId.Name = "ColumnAccountId";
            this.ColumnAccountId.ReadOnly = true;
            this.ColumnAccountId.Visible = false;
            // 
            // ColumnTermId
            // 
            this.ColumnTermId.DataPropertyName = "ColumnTermId";
            this.ColumnTermId.HeaderText = "TermId";
            this.ColumnTermId.Name = "ColumnTermId";
            this.ColumnTermId.ReadOnly = true;
            this.ColumnTermId.Visible = false;
            // 
            // ColumnTerm
            // 
            this.ColumnTerm.DataPropertyName = "ColumnTerm";
            this.ColumnTerm.FillWeight = 75F;
            this.ColumnTerm.HeaderText = "Term";
            this.ColumnTerm.Name = "ColumnTerm";
            this.ColumnTerm.ReadOnly = true;
            this.ColumnTerm.Width = 75;
            // 
            // ColumnDiscountId
            // 
            this.ColumnDiscountId.DataPropertyName = "ColumnDiscountId";
            this.ColumnDiscountId.HeaderText = "DiscountId";
            this.ColumnDiscountId.Name = "ColumnDiscountId";
            this.ColumnDiscountId.ReadOnly = true;
            this.ColumnDiscountId.Visible = false;
            // 
            // ColumnRemarks
            // 
            this.ColumnRemarks.DataPropertyName = "ColumnRemarks";
            this.ColumnRemarks.HeaderText = "Remarks";
            this.ColumnRemarks.Name = "ColumnRemarks";
            this.ColumnRemarks.ReadOnly = true;
            // 
            // ColumnPreparedBy
            // 
            this.ColumnPreparedBy.DataPropertyName = "ColumnPreparedBy";
            this.ColumnPreparedBy.HeaderText = "ColumnPreparedBy";
            this.ColumnPreparedBy.Name = "ColumnPreparedBy";
            this.ColumnPreparedBy.ReadOnly = true;
            this.ColumnPreparedBy.Visible = false;
            // 
            // ColumnPreparedByUserName
            // 
            this.ColumnPreparedByUserName.DataPropertyName = "ColumnPreparedByUserName";
            this.ColumnPreparedByUserName.FillWeight = 120F;
            this.ColumnPreparedByUserName.HeaderText = "Prepared By";
            this.ColumnPreparedByUserName.Name = "ColumnPreparedByUserName";
            this.ColumnPreparedByUserName.ReadOnly = true;
            this.ColumnPreparedByUserName.Width = 120;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "ColumnAmount";
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // ColumnTerminalId
            // 
            this.ColumnTerminalId.DataPropertyName = "ColumnTerminalId";
            this.ColumnTerminalId.HeaderText = "TerminalId";
            this.ColumnTerminalId.Name = "ColumnTerminalId";
            this.ColumnTerminalId.ReadOnly = true;
            this.ColumnTerminalId.Visible = false;
            // 
            // ColumnPax
            // 
            this.ColumnPax.DataPropertyName = "ColumnPax";
            this.ColumnPax.FillWeight = 75F;
            this.ColumnPax.HeaderText = "Pax";
            this.ColumnPax.Name = "ColumnPax";
            this.ColumnPax.ReadOnly = true;
            this.ColumnPax.Width = 75;
            // 
            // ColumnTable
            // 
            this.ColumnTable.DataPropertyName = "ColumnTable";
            this.ColumnTable.FillWeight = 75F;
            this.ColumnTable.HeaderText = "Table";
            this.ColumnTable.Name = "ColumnTable";
            this.ColumnTable.ReadOnly = true;
            this.ColumnTable.Width = 75;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Reports;
            this.pictureBox1.Location = new System.Drawing.Point(14, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // RepSalesReportSalesSummaryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1482, 703);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RepSalesReportSalesSummaryReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Summary Report";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesSummaryReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewSalesSummaryReport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonSalesListPageListFirst;
        private System.Windows.Forms.Button buttonSalesListPageListNext;
        private System.Windows.Forms.Button buttonSalesListPageListLast;
        private System.Windows.Forms.Button buttonSalesListPageListPrevious;
        private System.Windows.Forms.TextBox textBoxPageNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPeriodId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManualInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTermId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscountId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPreparedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPreparedByUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTable;
    }
}