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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesListForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSales = new System.Windows.Forms.Button();
            this.dataGridViewSalesList = new System.Windows.Forms.DataGridView();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesAgent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsTendered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsCancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTransactionDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPreparedBy = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTerminal = new System.Windows.Forms.Label();
            this.labelInvoiceNumber = new System.Windows.Forms.Label();
            this.dataGridViewSalesLineItemDisplay = new System.Windows.Forms.DataGridView();
            this.ColumnSalesLineItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesLlineAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerSalesDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxSalesListFilter = new System.Windows.Forms.TextBox();
            this.comboBoxTerminal = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesList)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesLineItemDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
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
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(52)))), ((int)(((byte)(18)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(52)))), ((int)(((byte)(18)))));
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
            this.buttonSales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(126)))), ((int)(((byte)(181)))));
            this.buttonSales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(126)))), ((int)(((byte)(181)))));
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
            this.ColumnCustomer,
            this.ColumnSalesAgent,
            this.ColumnAmount,
            this.ColumnIsLocked,
            this.ColumnIsTendered,
            this.ColumnIsCancelled});
            this.dataGridViewSalesList.Location = new System.Drawing.Point(12, 100);
            this.dataGridViewSalesList.MultiSelect = false;
            this.dataGridViewSalesList.Name = "dataGridViewSalesList";
            this.dataGridViewSalesList.ReadOnly = true;
            this.dataGridViewSalesList.RowHeadersVisible = false;
            this.dataGridViewSalesList.RowTemplate.Height = 24;
            this.dataGridViewSalesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesList.Size = new System.Drawing.Size(1042, 588);
            this.dataGridViewSalesList.TabIndex = 4;
            this.dataGridViewSalesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesList_CellClick);
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnEdit.Frozen = true;
            this.ColumnEdit.HeaderText = "Edit";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.ReadOnly = true;
            this.ColumnEdit.Width = 70;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDelete.Frozen = true;
            this.ColumnDelete.HeaderText = "Delete";
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.ReadOnly = true;
            this.ColumnDelete.Width = 70;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnTerminal
            // 
            this.ColumnTerminal.HeaderText = "Terminal";
            this.ColumnTerminal.Name = "ColumnTerminal";
            this.ColumnTerminal.ReadOnly = true;
            this.ColumnTerminal.Width = 70;
            // 
            // ColumnSalesDate
            // 
            this.ColumnSalesDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSalesDate.HeaderText = "Sales Date";
            this.ColumnSalesDate.Name = "ColumnSalesDate";
            this.ColumnSalesDate.ReadOnly = true;
            this.ColumnSalesDate.Width = 118;
            // 
            // ColumnSalesNumber
            // 
            this.ColumnSalesNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSalesNumber.HeaderText = "Sales No.";
            this.ColumnSalesNumber.Name = "ColumnSalesNumber";
            this.ColumnSalesNumber.ReadOnly = true;
            this.ColumnSalesNumber.Width = 109;
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCustomer.HeaderText = "Customer";
            this.ColumnCustomer.Name = "ColumnCustomer";
            this.ColumnCustomer.ReadOnly = true;
            // 
            // ColumnSalesAgent
            // 
            this.ColumnSalesAgent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSalesAgent.HeaderText = "Sales";
            this.ColumnSalesAgent.Name = "ColumnSalesAgent";
            this.ColumnSalesAgent.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 101;
            // 
            // ColumnIsLocked
            // 
            this.ColumnIsLocked.HeaderText = "L";
            this.ColumnIsLocked.Name = "ColumnIsLocked";
            this.ColumnIsLocked.ReadOnly = true;
            this.ColumnIsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsLocked.Width = 30;
            // 
            // ColumnIsTendered
            // 
            this.ColumnIsTendered.HeaderText = "T";
            this.ColumnIsTendered.Name = "ColumnIsTendered";
            this.ColumnIsTendered.ReadOnly = true;
            this.ColumnIsTendered.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsTendered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsTendered.Width = 30;
            // 
            // ColumnIsCancelled
            // 
            this.ColumnIsCancelled.HeaderText = "C";
            this.ColumnIsCancelled.Name = "ColumnIsCancelled";
            this.ColumnIsCancelled.ReadOnly = true;
            this.ColumnIsCancelled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsCancelled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsCancelled.Width = 30;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewSalesLineItemDisplay);
            this.panel2.Location = new System.Drawing.Point(1060, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 619);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.labelTransactionDate);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.labelPreparedBy);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.labelTerminal);
            this.panel3.Controls.Add(this.labelInvoiceNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 102);
            this.panel3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Prepared by:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Invoice No.:";
            // 
            // labelTransactionDate
            // 
            this.labelTransactionDate.AutoSize = true;
            this.labelTransactionDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionDate.Location = new System.Drawing.Point(140, 68);
            this.labelTransactionDate.Name = "labelTransactionDate";
            this.labelTransactionDate.Size = new System.Drawing.Size(0, 20);
            this.labelTransactionDate.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Terminal:";
            // 
            // labelPreparedBy
            // 
            this.labelPreparedBy.AutoSize = true;
            this.labelPreparedBy.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreparedBy.Location = new System.Drawing.Point(140, 48);
            this.labelPreparedBy.Name = "labelPreparedBy";
            this.labelPreparedBy.Size = new System.Drawing.Size(0, 20);
            this.labelPreparedBy.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Transaction Date:";
            // 
            // labelTerminal
            // 
            this.labelTerminal.AutoSize = true;
            this.labelTerminal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTerminal.Location = new System.Drawing.Point(140, 28);
            this.labelTerminal.Name = "labelTerminal";
            this.labelTerminal.Size = new System.Drawing.Size(0, 20);
            this.labelTerminal.TabIndex = 5;
            // 
            // labelInvoiceNumber
            // 
            this.labelInvoiceNumber.AutoSize = true;
            this.labelInvoiceNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvoiceNumber.Location = new System.Drawing.Point(140, 10);
            this.labelInvoiceNumber.Name = "labelInvoiceNumber";
            this.labelInvoiceNumber.Size = new System.Drawing.Size(0, 20);
            this.labelInvoiceNumber.TabIndex = 4;
            // 
            // dataGridViewSalesLineItemDisplay
            // 
            this.dataGridViewSalesLineItemDisplay.AllowUserToAddRows = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToDeleteRows = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToResizeColumns = false;
            this.dataGridViewSalesLineItemDisplay.AllowUserToResizeRows = false;
            this.dataGridViewSalesLineItemDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSalesLineItemDisplay.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSalesLineItemDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSalesLineItemDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesLineItemDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesLineItem,
            this.ColumnSalesLlineAmount});
            this.dataGridViewSalesLineItemDisplay.GridColor = System.Drawing.Color.White;
            this.dataGridViewSalesLineItemDisplay.Location = new System.Drawing.Point(7, 108);
            this.dataGridViewSalesLineItemDisplay.Name = "dataGridViewSalesLineItemDisplay";
            this.dataGridViewSalesLineItemDisplay.ReadOnly = true;
            this.dataGridViewSalesLineItemDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewSalesLineItemDisplay.RowHeadersVisible = false;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.Height = 24;
            this.dataGridViewSalesLineItemDisplay.Size = new System.Drawing.Size(312, 345);
            this.dataGridViewSalesLineItemDisplay.TabIndex = 8;
            // 
            // ColumnSalesLineItem
            // 
            this.ColumnSalesLineItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSalesLineItem.HeaderText = "Item";
            this.ColumnSalesLineItem.Name = "ColumnSalesLineItem";
            this.ColumnSalesLineItem.ReadOnly = true;
            // 
            // ColumnSalesLlineAmount
            // 
            this.ColumnSalesLlineAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSalesLlineAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSalesLlineAmount.HeaderText = "Amount";
            this.ColumnSalesLlineAmount.Name = "ColumnSalesLlineAmount";
            this.ColumnSalesLlineAmount.ReadOnly = true;
            // 
            // dateTimePickerSalesDate
            // 
            this.dateTimePickerSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesDate.Location = new System.Drawing.Point(12, 69);
            this.dateTimePickerSalesDate.Name = "dateTimePickerSalesDate";
            this.dateTimePickerSalesDate.Size = new System.Drawing.Size(150, 30);
            this.dateTimePickerSalesDate.TabIndex = 6;
            this.dateTimePickerSalesDate.ValueChanged += new System.EventHandler(this.dateTimePickerSalesDate_ValueChanged);
            // 
            // textBoxSalesListFilter
            // 
            this.textBoxSalesListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesListFilter.Location = new System.Drawing.Point(348, 69);
            this.textBoxSalesListFilter.Name = "textBoxSalesListFilter";
            this.textBoxSalesListFilter.Size = new System.Drawing.Size(706, 30);
            this.textBoxSalesListFilter.TabIndex = 7;
            this.textBoxSalesListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSalesListFilter_KeyDown);
            // 
            // comboBoxTerminal
            // 
            this.comboBoxTerminal.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.comboBoxTerminal.FormattingEnabled = true;
            this.comboBoxTerminal.Location = new System.Drawing.Point(168, 69);
            this.comboBoxTerminal.Name = "comboBoxTerminal";
            this.comboBoxTerminal.Size = new System.Drawing.Size(174, 29);
            this.comboBoxTerminal.TabIndex = 0;
            this.comboBoxTerminal.SelectedIndexChanged += new System.EventHandler(this.comboBoxTerminal_SelectedIndexChanged);
            // 
            // TrnSalesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.comboBoxTerminal);
            this.Controls.Add(this.textBoxSalesListFilter);
            this.Controls.Add(this.dateTimePickerSalesDate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewSalesList);
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesLineItemDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewButtonColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsLocked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsTendered;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCancelled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTransactionDate;
        private System.Windows.Forms.Label labelPreparedBy;
        private System.Windows.Forms.Label labelTerminal;
        private System.Windows.Forms.Label labelInvoiceNumber;
        private System.Windows.Forms.DataGridView dataGridViewSalesLineItemDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLlineAmount;
        private System.Windows.Forms.Panel panel3;
    }
}