namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnSalesListForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonTender = new System.Windows.Forms.Button();
            this.buttonReprint = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSales = new System.Windows.Forms.Button();
            this.dataGridViewSalesList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.labelReceiptInvoiceNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTransactionDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelInvoiceNumber = new System.Windows.Forms.Label();
            this.labelPreparedBy = new System.Windows.Forms.Label();
            this.labelTerminal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewSalesLineItemDisplay = new System.Windows.Forms.DataGridView();
            this.ColumnSalesLineItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesLineItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesLlineAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerSalesDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxSalesListFilter = new System.Windows.Forms.TextBox();
            this.comboBoxTerminal = new System.Windows.Forms.ComboBox();
            this.timerRefreshSalesListGrid = new System.Windows.Forms.Timer(this.components);
            this.buttonSalesListPageListFirst = new System.Windows.Forms.Button();
            this.buttonSalesListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSalesListPageListNext = new System.Windows.Forms.Button();
            this.buttonSalesListPageListLast = new System.Windows.Forms.Button();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.buttonAutoRefresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxLastChange = new System.Windows.Forms.TextBox();
            this.labelLastChange = new System.Windows.Forms.Label();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRececiptInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsTendered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsCancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesLineItemDisplay)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonTender);
            this.panel1.Controls.Add(this.buttonReprint);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonSales);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 3;
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
            this.buttonTender.Location = new System.Drawing.Point(924, 12);
            this.buttonTender.Name = "buttonTender";
            this.buttonTender.Size = new System.Drawing.Size(88, 40);
            this.buttonTender.TabIndex = 6;
            this.buttonTender.Text = "Tender";
            this.buttonTender.UseVisualStyleBackColor = false;
            this.buttonTender.Click += new System.EventHandler(this.buttonTender_Click);
            // 
            // buttonReprint
            // 
            this.buttonReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonReprint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonReprint.FlatAppearance.BorderSize = 0;
            this.buttonReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReprint.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprint.ForeColor = System.Drawing.Color.White;
            this.buttonReprint.Location = new System.Drawing.Point(1018, 12);
            this.buttonReprint.Name = "buttonReprint";
            this.buttonReprint.Size = new System.Drawing.Size(88, 40);
            this.buttonReprint.TabIndex = 5;
            this.buttonReprint.Text = "Reprint";
            this.buttonReprint.UseVisualStyleBackColor = false;
            this.buttonReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(1112, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 40);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            this.label1.Size = new System.Drawing.Size(122, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sales List";
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
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.buttonSales.Location = new System.Drawing.Point(1206, 12);
            this.buttonSales.Name = "buttonSales";
            this.buttonSales.Size = new System.Drawing.Size(88, 40);
            this.buttonSales.TabIndex = 0;
            this.buttonSales.Text = "Sales";
            this.buttonSales.UseVisualStyleBackColor = false;
            this.buttonSales.Click += new System.EventHandler(this.buttonSales_Click);
            // 
            // dataGridViewSalesList
            // 
            this.dataGridViewSalesList.AllowUserToAddRows = false;
            this.dataGridViewSalesList.AllowUserToDeleteRows = false;
            this.dataGridViewSalesList.AllowUserToResizeRows = false;
            this.dataGridViewSalesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEdit,
            this.ColumnDelete,
            this.ColumnId,
            this.ColumnTerminal,
            this.ColumnSalesDate,
            this.ColumnSalesNumber,
            this.ColumnRececiptInvoiceNumber,
            this.ColumnCustomer,
            this.ColumnSalesAgent,
            this.ColumnAmount,
            this.ColumnIsLocked,
            this.ColumnIsTendered,
            this.ColumnIsCancelled,
            this.ColumnSpace});
            this.dataGridViewSalesList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSalesList.MultiSelect = false;
            this.dataGridViewSalesList.Name = "dataGridViewSalesList";
            this.dataGridViewSalesList.ReadOnly = true;
            this.dataGridViewSalesList.RowHeadersVisible = false;
            this.dataGridViewSalesList.RowTemplate.Height = 35;
            this.dataGridViewSalesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesList.Size = new System.Drawing.Size(900, 536);
            this.dataGridViewSalesList.TabIndex = 4;
            this.dataGridViewSalesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesList_CellClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.labelReceiptInvoiceNumber);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.labelCustomer);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labelTransactionDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelInvoiceNumber);
            this.panel2.Controls.Add(this.labelPreparedBy);
            this.panel2.Controls.Add(this.labelTerminal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(924, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 148);
            this.panel2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Receipt / Invoice No.:";
            // 
            // labelReceiptInvoiceNumber
            // 
            this.labelReceiptInvoiceNumber.AutoSize = true;
            this.labelReceiptInvoiceNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiptInvoiceNumber.Location = new System.Drawing.Point(183, 74);
            this.labelReceiptInvoiceNumber.Name = "labelReceiptInvoiceNumber";
            this.labelReceiptInvoiceNumber.Size = new System.Drawing.Size(0, 20);
            this.labelReceiptInvoiceNumber.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Customer:";
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomer.Location = new System.Drawing.Point(183, 92);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(0, 20);
            this.labelCustomer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Order Taker:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Order No.:";
            // 
            // labelTransactionDate
            // 
            this.labelTransactionDate.AutoSize = true;
            this.labelTransactionDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionDate.Location = new System.Drawing.Point(183, 32);
            this.labelTransactionDate.Name = "labelTransactionDate";
            this.labelTransactionDate.Size = new System.Drawing.Size(0, 20);
            this.labelTransactionDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Terminal:";
            // 
            // labelInvoiceNumber
            // 
            this.labelInvoiceNumber.AutoSize = true;
            this.labelInvoiceNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvoiceNumber.Location = new System.Drawing.Point(183, 54);
            this.labelInvoiceNumber.Name = "labelInvoiceNumber";
            this.labelInvoiceNumber.Size = new System.Drawing.Size(0, 20);
            this.labelInvoiceNumber.TabIndex = 4;
            // 
            // labelPreparedBy
            // 
            this.labelPreparedBy.AutoSize = true;
            this.labelPreparedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreparedBy.Location = new System.Drawing.Point(183, 112);
            this.labelPreparedBy.Name = "labelPreparedBy";
            this.labelPreparedBy.Size = new System.Drawing.Size(0, 20);
            this.labelPreparedBy.TabIndex = 6;
            // 
            // labelTerminal
            // 
            this.labelTerminal.AutoSize = true;
            this.labelTerminal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTerminal.Location = new System.Drawing.Point(183, 11);
            this.labelTerminal.Name = "labelTerminal";
            this.labelTerminal.Size = new System.Drawing.Size(0, 20);
            this.labelTerminal.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sales Date:";
            // 
            // dataGridViewSalesLineItemDisplay
            // 
            this.dataGridViewSalesLineItemDisplay.AllowUserToAddRows = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToDeleteRows = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToResizeColumns = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToResizeRows = false;
            this.dataGridViewSalesLineItemDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesLineItemDisplay.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSalesLineItemDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesLineItemDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesLineItemDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesLineItemQuantity,
            this.ColumnSalesLineItem,
            this.ColumnSalesLlineAmount});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewSalesLineItemDisplay.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSalesLineItemDisplay.Location = new System.Drawing.Point(924, 160);
            this.dataGridViewSalesLineItemDisplay.Name = "dataGridViewSalesLineItemDisplay";
            this.dataGridViewSalesLineItemDisplay.ReadOnly = true;
            this.dataGridViewSalesLineItemDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewSalesLineItemDisplay.RowHeadersVisible = false;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.Height = 45;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.ReadOnly = true;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSalesLineItemDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesLineItemDisplay.Size = new System.Drawing.Size(464, 418);
            this.dataGridViewSalesLineItemDisplay.TabIndex = 8;
            // 
            // ColumnSalesLineItemQuantity
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.ColumnSalesLineItemQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSalesLineItemQuantity.HeaderText = "Qty.";
            this.ColumnSalesLineItemQuantity.Name = "ColumnSalesLineItemQuantity";
            this.ColumnSalesLineItemQuantity.ReadOnly = true;
            this.ColumnSalesLineItemQuantity.Width = 90;
            // 
            // ColumnSalesLineItem
            // 
            this.ColumnSalesLineItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.ColumnSalesLineItem.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnSalesLineItem.HeaderText = "Item";
            this.ColumnSalesLineItem.Name = "ColumnSalesLineItem";
            this.ColumnSalesLineItem.ReadOnly = true;
            // 
            // ColumnSalesLlineAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.ColumnSalesLlineAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnSalesLlineAmount.HeaderText = "Amount";
            this.ColumnSalesLlineAmount.Name = "ColumnSalesLlineAmount";
            this.ColumnSalesLlineAmount.ReadOnly = true;
            // 
            // dateTimePickerSalesDate
            // 
            this.dateTimePickerSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesDate.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerSalesDate.Name = "dateTimePickerSalesDate";
            this.dateTimePickerSalesDate.Size = new System.Drawing.Size(150, 30);
            this.dateTimePickerSalesDate.TabIndex = 6;
            this.dateTimePickerSalesDate.ValueChanged += new System.EventHandler(this.dateTimePickerSalesDate_ValueChanged);
            // 
            // textBoxSalesListFilter
            // 
            this.textBoxSalesListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesListFilter.Location = new System.Drawing.Point(348, 6);
            this.textBoxSalesListFilter.Name = "textBoxSalesListFilter";
            this.textBoxSalesListFilter.Size = new System.Drawing.Size(564, 30);
            this.textBoxSalesListFilter.TabIndex = 7;
            this.textBoxSalesListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSalesListFilter_KeyDown);
            // 
            // comboBoxTerminal
            // 
            this.comboBoxTerminal.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.comboBoxTerminal.FormattingEnabled = true;
            this.comboBoxTerminal.Location = new System.Drawing.Point(168, 6);
            this.comboBoxTerminal.Name = "comboBoxTerminal";
            this.comboBoxTerminal.Size = new System.Drawing.Size(174, 29);
            this.comboBoxTerminal.TabIndex = 0;
            this.comboBoxTerminal.SelectedIndexChanged += new System.EventHandler(this.comboBoxTerminal_SelectedIndexChanged);
            // 
            // timerRefreshSalesListGrid
            // 
            this.timerRefreshSalesListGrid.Interval = 3000;
            this.timerRefreshSalesListGrid.Tick += new System.EventHandler(this.timerRefreshSalesListGrid_Tick);
            // 
            // buttonSalesListPageListFirst
            // 
            this.buttonSalesListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListFirst.Enabled = false;
            this.buttonSalesListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSalesListPageListFirst.Name = "buttonSalesListPageListFirst";
            this.buttonSalesListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListFirst.TabIndex = 8;
            this.buttonSalesListPageListFirst.Text = "First";
            this.buttonSalesListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListFirst.Click += new System.EventHandler(this.buttonSalesListPageListFirst_Click);
            // 
            // buttonSalesListPageListPrevious
            // 
            this.buttonSalesListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListPrevious.Enabled = false;
            this.buttonSalesListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSalesListPageListPrevious.Name = "buttonSalesListPageListPrevious";
            this.buttonSalesListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListPrevious.TabIndex = 9;
            this.buttonSalesListPageListPrevious.Text = "Previous";
            this.buttonSalesListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListPrevious.Click += new System.EventHandler(this.buttonSalesListPageListPrevious_Click);
            // 
            // buttonSalesListPageListNext
            // 
            this.buttonSalesListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSalesListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSalesListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSalesListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            this.buttonSalesListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSalesListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSalesListPageListLast.Name = "buttonSalesListPageListLast";
            this.buttonSalesListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSalesListPageListLast.TabIndex = 11;
            this.buttonSalesListPageListLast.Text = "Last";
            this.buttonSalesListPageListLast.UseVisualStyleBackColor = false;
            this.buttonSalesListPageListLast.Click += new System.EventHandler(this.buttonSalesListPageListLast_Click);
            // 
            // textBoxPageNumber
            // 
            this.textBoxPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.ReadOnly = true;
            this.textBoxPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxPageNumber.TabIndex = 12;
            this.textBoxPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAutoRefresh
            // 
            this.buttonAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.buttonAutoRefresh.FlatAppearance.BorderSize = 0;
            this.buttonAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonAutoRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonAutoRefresh.Location = new System.Drawing.Point(840, 11);
            this.buttonAutoRefresh.Name = "buttonAutoRefresh";
            this.buttonAutoRefresh.Size = new System.Drawing.Size(72, 32);
            this.buttonAutoRefresh.TabIndex = 13;
            this.buttonAutoRefresh.TabStop = false;
            this.buttonAutoRefresh.Text = "Start";
            this.buttonAutoRefresh.UseVisualStyleBackColor = false;
            this.buttonAutoRefresh.Click += new System.EventHandler(this.buttonAutoRefresh_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dataGridViewSalesLineItemDisplay);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.comboBoxTerminal);
            this.panel3.Controls.Add(this.dataGridViewSalesList);
            this.panel3.Controls.Add(this.textBoxSalesListFilter);
            this.panel3.Controls.Add(this.dateTimePickerSalesDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 637);
            this.panel3.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textBoxLastChange);
            this.panel4.Controls.Add(this.labelLastChange);
            this.panel4.Controls.Add(this.buttonSalesListPageListFirst);
            this.panel4.Controls.Add(this.buttonSalesListPageListNext);
            this.panel4.Controls.Add(this.buttonAutoRefresh);
            this.panel4.Controls.Add(this.buttonSalesListPageListLast);
            this.panel4.Controls.Add(this.buttonSalesListPageListPrevious);
            this.panel4.Controls.Add(this.textBoxPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 584);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1400, 53);
            this.panel4.TabIndex = 19;
            // 
            // textBoxLastChange
            // 
            this.textBoxLastChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxLastChange.BackColor = System.Drawing.Color.White;
            this.textBoxLastChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastChange.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.textBoxLastChange.ForeColor = System.Drawing.Color.Black;
            this.textBoxLastChange.Location = new System.Drawing.Point(1049, 7);
            this.textBoxLastChange.Name = "textBoxLastChange";
            this.textBoxLastChange.ReadOnly = true;
            this.textBoxLastChange.Size = new System.Drawing.Size(339, 34);
            this.textBoxLastChange.TabIndex = 15;
            this.textBoxLastChange.Text = "0.00";
            this.textBoxLastChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelLastChange
            // 
            this.labelLastChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastChange.AutoSize = true;
            this.labelLastChange.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelLastChange.ForeColor = System.Drawing.Color.Black;
            this.labelLastChange.Location = new System.Drawing.Point(919, 13);
            this.labelLastChange.Name = "labelLastChange";
            this.labelLastChange.Size = new System.Drawing.Size(124, 25);
            this.labelLastChange.TabIndex = 14;
            this.labelLastChange.Text = "Last Change:";
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.DataPropertyName = "ColumnEdit";
            this.ColumnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnEdit.Frozen = true;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            this.ColumnEdit.Width = 70;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.DataPropertyName = "ColumnDelete";
            this.ColumnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDelete.Frozen = true;
            this.ColumnDelete.HeaderText = "";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Width = 70;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "ColumnId";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnTerminal
            // 
            this.ColumnTerminal.DataPropertyName = "ColumnTerminal";
            this.ColumnTerminal.HeaderText = "Terminal";
            this.ColumnTerminal.Name = "ColumnTerminal";
            this.ColumnTerminal.ReadOnly = true;
            this.ColumnTerminal.Width = 70;
            // 
            // ColumnSalesDate
            // 
            this.ColumnSalesDate.DataPropertyName = "ColumnSalesDate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSalesDate.HeaderText = "Order Date";
            this.ColumnSalesDate.Name = "ColumnSalesDate";
            this.ColumnSalesDate.ReadOnly = true;
            this.ColumnSalesDate.Width = 95;
            // 
            // ColumnSalesNumber
            // 
            this.ColumnSalesNumber.DataPropertyName = "ColumnSalesNumber";
            this.ColumnSalesNumber.HeaderText = "Order No.";
            this.ColumnSalesNumber.Name = "ColumnSalesNumber";
            this.ColumnSalesNumber.ReadOnly = true;
            // 
            // ColumnRececiptInvoiceNumber
            // 
            this.ColumnRececiptInvoiceNumber.DataPropertyName = "ColumnRececiptInvoiceNumber";
            this.ColumnRececiptInvoiceNumber.HeaderText = "Receipt / Invoice No.";
            this.ColumnRececiptInvoiceNumber.Name = "ColumnRececiptInvoiceNumber";
            this.ColumnRececiptInvoiceNumber.ReadOnly = true;
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.DataPropertyName = "ColumnCustomer";
            this.ColumnCustomer.HeaderText = "Customer";
            this.ColumnCustomer.Name = "ColumnCustomer";
            this.ColumnCustomer.ReadOnly = true;
            this.ColumnCustomer.Width = 130;
            // 
            // ColumnSalesAgent
            // 
            this.ColumnSalesAgent.DataPropertyName = "ColumnSalesAgent";
            this.ColumnSalesAgent.HeaderText = "Order Taker";
            this.ColumnSalesAgent.Name = "ColumnSalesAgent";
            this.ColumnSalesAgent.ReadOnly = true;
            this.ColumnSalesAgent.Width = 120;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "ColumnAmount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 120;
            // 
            // ColumnIsLocked
            // 
            this.ColumnIsLocked.DataPropertyName = "ColumnIsLocked";
            this.ColumnIsLocked.HeaderText = "L";
            this.ColumnIsLocked.Name = "ColumnIsLocked";
            this.ColumnIsLocked.ReadOnly = true;
            this.ColumnIsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsLocked.Width = 35;
            // 
            // ColumnIsTendered
            // 
            this.ColumnIsTendered.DataPropertyName = "ColumnIsTendered";
            this.ColumnIsTendered.HeaderText = "T";
            this.ColumnIsTendered.Name = "ColumnIsTendered";
            this.ColumnIsTendered.ReadOnly = true;
            this.ColumnIsTendered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsTendered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsTendered.Width = 35;
            // 
            // ColumnIsCancelled
            // 
            this.ColumnIsCancelled.DataPropertyName = "ColumnIsCancelled";
            this.ColumnIsCancelled.HeaderText = "C";
            this.ColumnIsCancelled.Name = "ColumnIsCancelled";
            this.ColumnIsCancelled.ReadOnly = true;
            this.ColumnIsCancelled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsCancelled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsCancelled.Width = 35;
            // 
            // ColumnSpace
            // 
            this.ColumnSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSpace.DataPropertyName = "ColumnSpace";
            this.ColumnSpace.HeaderText = "";
            this.ColumnSpace.Name = "ColumnSpace";
            this.ColumnSpace.ReadOnly = true;
            // 
            // TrnSalesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrnSalesListForm";
            this.Text = "Sales List";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesLineItemDisplay)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSales;
        private System.Windows.Forms.DataGridView dataGridViewSalesList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesDate;
        private System.Windows.Forms.TextBox textBoxSalesListFilter;
        private System.Windows.Forms.ComboBox comboBoxTerminal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTransactionDate;
        private System.Windows.Forms.Label labelPreparedBy;
        private System.Windows.Forms.Label labelTerminal;
        private System.Windows.Forms.Label labelInvoiceNumber;
        private System.Windows.Forms.DataGridView dataGridViewSalesLineItemDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLineItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLlineAmount;
        private System.Windows.Forms.Button buttonTender;
        private System.Windows.Forms.Button buttonReprint;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Timer timerRefreshSalesListGrid;
        private System.Windows.Forms.Button buttonSalesListPageListFirst;
        private System.Windows.Forms.Button buttonSalesListPageListPrevious;
        private System.Windows.Forms.Button buttonSalesListPageListNext;
        private System.Windows.Forms.Button buttonSalesListPageListLast;
        private System.Windows.Forms.TextBox textBoxPageNumber;
        private System.Windows.Forms.Button buttonAutoRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelLastChange;
        private System.Windows.Forms.TextBox textBoxLastChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelReceiptInvoiceNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRececiptInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsLocked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsTendered;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpace;
    }
}