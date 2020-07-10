namespace EasyPOS.Forms.Software.SysDispatchStation
{
    partial class SysDispatchStationForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysDispatchStationForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewSalesList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDeliveryMan = new System.Windows.Forms.Label();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCustomerAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelManualSalesNumber = new System.Windows.Forms.Label();
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonNewOrders = new System.Windows.Forms.Button();
            this.imageListDispatchStation = new System.Windows.Forms.ImageList(this.components);
            this.buttonDeliveredOrders = new System.Windows.Forms.Button();
            this.buttonDispatchedOrders = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonAutoRefresh = new System.Windows.Forms.Button();
            this.textBoxTimeOrdered = new System.Windows.Forms.TextBox();
            this.labelLastChange = new System.Windows.Forms.Label();
            this.ColumnButtonDispatch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTerminal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSalesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnManualSalesNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumberOfItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsTendered = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsCancelled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIsDispatched = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrepared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSalesLineItemDisplay)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 50);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Dispatch;
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
            this.label1.Size = new System.Drawing.Size(169, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dispatch Station";
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
            this.buttonClose.Location = new System.Drawing.Point(1016, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(70, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.ColumnButtonDispatch,
            this.ColumnId,
            this.ColumnTerminal,
            this.ColumnSalesDate,
            this.ColumnSalesNumber,
            this.ColumnManualSalesNumber,
            this.ColumnCustomer,
            this.ColumnCustomerAddress,
            this.ColumnDelivery,
            this.ColumnNumberOfItems,
            this.ColumnIsLocked,
            this.ColumnIsTendered,
            this.ColumnIsCancelled,
            this.ColumnIsDispatched,
            this.ColumnPrepared,
            this.ColumnStatus,
            this.ColumnSpace});
            this.dataGridViewSalesList.Location = new System.Drawing.Point(10, 126);
            this.dataGridViewSalesList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSalesList.MultiSelect = false;
            this.dataGridViewSalesList.Name = "dataGridViewSalesList";
            this.dataGridViewSalesList.ReadOnly = true;
            this.dataGridViewSalesList.RowHeadersVisible = false;
            this.dataGridViewSalesList.RowTemplate.Height = 35;
            this.dataGridViewSalesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesList.Size = new System.Drawing.Size(696, 337);
            this.dataGridViewSalesList.TabIndex = 4;
            this.dataGridViewSalesList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSalesList_CellClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.labelDeliveryMan);
            this.panel2.Controls.Add(this.labelCustomerName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxCustomerAddress);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelManualSalesNumber);
            this.panel2.Location = new System.Drawing.Point(715, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 158);
            this.panel2.TabIndex = 5;
            // 
            // labelDeliveryMan
            // 
            this.labelDeliveryMan.AutoSize = true;
            this.labelDeliveryMan.Location = new System.Drawing.Point(89, 55);
            this.labelDeliveryMan.Name = "labelDeliveryMan";
            this.labelDeliveryMan.Size = new System.Drawing.Size(130, 19);
            this.labelDeliveryMan.TabIndex = 7;
            this.labelDeliveryMan.Text = "Delivery Man Name";
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(89, 36);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(109, 19);
            this.labelCustomerName.TabIndex = 6;
            this.labelCustomerName.Text = "Customer Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(11, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Delivery:";
            // 
            // textBoxCustomerAddress
            // 
            this.textBoxCustomerAddress.BackColor = System.Drawing.Color.White;
            this.textBoxCustomerAddress.Location = new System.Drawing.Point(15, 96);
            this.textBoxCustomerAddress.Multiline = true;
            this.textBoxCustomerAddress.Name = "textBoxCustomerAddress";
            this.textBoxCustomerAddress.ReadOnly = true;
            this.textBoxCustomerAddress.Size = new System.Drawing.Size(343, 51);
            this.textBoxCustomerAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer:";
            // 
            // labelManualSalesNumber
            // 
            this.labelManualSalesNumber.AutoSize = true;
            this.labelManualSalesNumber.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.labelManualSalesNumber.Location = new System.Drawing.Point(10, 9);
            this.labelManualSalesNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelManualSalesNumber.Name = "labelManualSalesNumber";
            this.labelManualSalesNumber.Size = new System.Drawing.Size(112, 25);
            this.labelManualSalesNumber.TabIndex = 1;
            this.labelManualSalesNumber.Text = "0000000001";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSalesLineItemDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSalesLineItemDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSalesLineItemQuantity,
            this.ColumnSalesLineItem,
            this.ColumnSalesLlineAmount});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewSalesLineItemDisplay.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewSalesLineItemDisplay.Location = new System.Drawing.Point(715, 167);
            this.dataGridViewSalesLineItemDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSalesLineItemDisplay.Name = "dataGridViewSalesLineItemDisplay";
            this.dataGridViewSalesLineItemDisplay.ReadOnly = true;
            this.dataGridViewSalesLineItemDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSalesLineItemDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewSalesLineItemDisplay.RowHeadersVisible = false;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.Height = 45;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.ReadOnly = true;
            this.dataGridViewSalesLineItemDisplay.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSalesLineItemDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSalesLineItemDisplay.Size = new System.Drawing.Size(371, 296);
            this.dataGridViewSalesLineItemDisplay.TabIndex = 8;
            // 
            // ColumnSalesLineItemQuantity
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.ColumnSalesLineItemQuantity.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnSalesLineItemQuantity.HeaderText = "Qty.";
            this.ColumnSalesLineItemQuantity.Name = "ColumnSalesLineItemQuantity";
            this.ColumnSalesLineItemQuantity.ReadOnly = true;
            this.ColumnSalesLineItemQuantity.Width = 90;
            // 
            // ColumnSalesLineItem
            // 
            this.ColumnSalesLineItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.ColumnSalesLineItem.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnSalesLineItem.HeaderText = "Item";
            this.ColumnSalesLineItem.Name = "ColumnSalesLineItem";
            this.ColumnSalesLineItem.ReadOnly = true;
            // 
            // ColumnSalesLlineAmount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.ColumnSalesLlineAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnSalesLlineAmount.HeaderText = "Amount";
            this.ColumnSalesLlineAmount.Name = "ColumnSalesLlineAmount";
            this.ColumnSalesLlineAmount.ReadOnly = true;
            // 
            // dateTimePickerSalesDate
            // 
            this.dateTimePickerSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSalesDate.Location = new System.Drawing.Point(10, 96);
            this.dateTimePickerSalesDate.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerSalesDate.Name = "dateTimePickerSalesDate";
            this.dateTimePickerSalesDate.Size = new System.Drawing.Size(121, 26);
            this.dateTimePickerSalesDate.TabIndex = 6;
            this.dateTimePickerSalesDate.ValueChanged += new System.EventHandler(this.dateTimePickerSalesDate_ValueChanged);
            // 
            // textBoxSalesListFilter
            // 
            this.textBoxSalesListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSalesListFilter.Location = new System.Drawing.Point(278, 96);
            this.textBoxSalesListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSalesListFilter.Name = "textBoxSalesListFilter";
            this.textBoxSalesListFilter.Size = new System.Drawing.Size(428, 26);
            this.textBoxSalesListFilter.TabIndex = 7;
            this.textBoxSalesListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSalesListFilter_KeyDown);
            // 
            // comboBoxTerminal
            // 
            this.comboBoxTerminal.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.comboBoxTerminal.FormattingEnabled = true;
            this.comboBoxTerminal.Location = new System.Drawing.Point(134, 96);
            this.comboBoxTerminal.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTerminal.Name = "comboBoxTerminal";
            this.comboBoxTerminal.Size = new System.Drawing.Size(140, 25);
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
            this.buttonSalesListPageListFirst.Location = new System.Drawing.Point(10, 9);
            this.buttonSalesListPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesListPageListFirst.Name = "buttonSalesListPageListFirst";
            this.buttonSalesListPageListFirst.Size = new System.Drawing.Size(66, 26);
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
            this.buttonSalesListPageListPrevious.Location = new System.Drawing.Point(80, 9);
            this.buttonSalesListPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesListPageListPrevious.Name = "buttonSalesListPageListPrevious";
            this.buttonSalesListPageListPrevious.Size = new System.Drawing.Size(66, 26);
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
            this.buttonSalesListPageListNext.Location = new System.Drawing.Point(210, 9);
            this.buttonSalesListPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesListPageListNext.Name = "buttonSalesListPageListNext";
            this.buttonSalesListPageListNext.Size = new System.Drawing.Size(66, 26);
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
            this.buttonSalesListPageListLast.Location = new System.Drawing.Point(278, 9);
            this.buttonSalesListPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSalesListPageListLast.Name = "buttonSalesListPageListLast";
            this.buttonSalesListPageListLast.Size = new System.Drawing.Size(66, 26);
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
            this.textBoxPageNumber.Location = new System.Drawing.Point(150, 13);
            this.textBoxPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.ReadOnly = true;
            this.textBoxPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxPageNumber.TabIndex = 12;
            this.textBoxPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dataGridViewSalesLineItemDisplay);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.comboBoxTerminal);
            this.panel3.Controls.Add(this.dataGridViewSalesList);
            this.panel3.Controls.Add(this.textBoxSalesListFilter);
            this.panel3.Controls.Add(this.dateTimePickerSalesDate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1096, 510);
            this.panel3.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.panel5.Controls.Add(this.buttonNewOrders);
            this.panel5.Controls.Add(this.buttonDeliveredOrders);
            this.panel5.Controls.Add(this.buttonDispatchedOrders);
            this.panel5.Location = new System.Drawing.Point(10, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(696, 86);
            this.panel5.TabIndex = 23;
            // 
            // buttonNewOrders
            // 
            this.buttonNewOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonNewOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonNewOrders.FlatAppearance.BorderSize = 0;
            this.buttonNewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNewOrders.ForeColor = System.Drawing.Color.White;
            this.buttonNewOrders.ImageIndex = 1;
            this.buttonNewOrders.ImageList = this.imageListDispatchStation;
            this.buttonNewOrders.Location = new System.Drawing.Point(1, 1);
            this.buttonNewOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewOrders.Name = "buttonNewOrders";
            this.buttonNewOrders.Padding = new System.Windows.Forms.Padding(8);
            this.buttonNewOrders.Size = new System.Drawing.Size(150, 84);
            this.buttonNewOrders.TabIndex = 20;
            this.buttonNewOrders.Text = "\r\nNew Orders";
            this.buttonNewOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonNewOrders.UseVisualStyleBackColor = false;
            this.buttonNewOrders.Click += new System.EventHandler(this.buttonNewOrders_Click);
            // 
            // imageListDispatchStation
            // 
            this.imageListDispatchStation.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDispatchStation.ImageStream")));
            this.imageListDispatchStation.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDispatchStation.Images.SetKeyName(0, "Dispatch.png");
            this.imageListDispatchStation.Images.SetKeyName(1, "Orders.png");
            this.imageListDispatchStation.Images.SetKeyName(2, "Deliver.png");
            // 
            // buttonDeliveredOrders
            // 
            this.buttonDeliveredOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.buttonDeliveredOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonDeliveredOrders.FlatAppearance.BorderSize = 0;
            this.buttonDeliveredOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeliveredOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDeliveredOrders.ForeColor = System.Drawing.Color.White;
            this.buttonDeliveredOrders.ImageIndex = 2;
            this.buttonDeliveredOrders.ImageList = this.imageListDispatchStation;
            this.buttonDeliveredOrders.Location = new System.Drawing.Point(302, 1);
            this.buttonDeliveredOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeliveredOrders.Name = "buttonDeliveredOrders";
            this.buttonDeliveredOrders.Padding = new System.Windows.Forms.Padding(8);
            this.buttonDeliveredOrders.Size = new System.Drawing.Size(150, 84);
            this.buttonDeliveredOrders.TabIndex = 22;
            this.buttonDeliveredOrders.Text = "\r\nDelivered";
            this.buttonDeliveredOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDeliveredOrders.UseVisualStyleBackColor = false;
            this.buttonDeliveredOrders.Click += new System.EventHandler(this.buttonDeliveredOrders_Click);
            // 
            // buttonDispatchedOrders
            // 
            this.buttonDispatchedOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.buttonDispatchedOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonDispatchedOrders.FlatAppearance.BorderSize = 0;
            this.buttonDispatchedOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDispatchedOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDispatchedOrders.ForeColor = System.Drawing.Color.White;
            this.buttonDispatchedOrders.ImageIndex = 0;
            this.buttonDispatchedOrders.ImageList = this.imageListDispatchStation;
            this.buttonDispatchedOrders.Location = new System.Drawing.Point(151, 1);
            this.buttonDispatchedOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDispatchedOrders.Name = "buttonDispatchedOrders";
            this.buttonDispatchedOrders.Padding = new System.Windows.Forms.Padding(8);
            this.buttonDispatchedOrders.Size = new System.Drawing.Size(150, 84);
            this.buttonDispatchedOrders.TabIndex = 21;
            this.buttonDispatchedOrders.Text = "\r\nDispatched";
            this.buttonDispatchedOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDispatchedOrders.UseVisualStyleBackColor = false;
            this.buttonDispatchedOrders.Click += new System.EventHandler(this.buttonDispatchedOrders_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.buttonAutoRefresh);
            this.panel4.Controls.Add(this.textBoxTimeOrdered);
            this.panel4.Controls.Add(this.labelLastChange);
            this.panel4.Controls.Add(this.buttonSalesListPageListFirst);
            this.panel4.Controls.Add(this.buttonSalesListPageListNext);
            this.panel4.Controls.Add(this.buttonSalesListPageListLast);
            this.panel4.Controls.Add(this.buttonSalesListPageListPrevious);
            this.panel4.Controls.Add(this.textBoxPageNumber);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 468);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1096, 42);
            this.panel4.TabIndex = 19;
            // 
            // buttonAutoRefresh
            // 
            this.buttonAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(188)))), ((int)(((byte)(0)))));
            this.buttonAutoRefresh.FlatAppearance.BorderSize = 0;
            this.buttonAutoRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAutoRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonAutoRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonAutoRefresh.Location = new System.Drawing.Point(648, 9);
            this.buttonAutoRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAutoRefresh.Name = "buttonAutoRefresh";
            this.buttonAutoRefresh.Size = new System.Drawing.Size(58, 26);
            this.buttonAutoRefresh.TabIndex = 18;
            this.buttonAutoRefresh.TabStop = false;
            this.buttonAutoRefresh.Text = "Start";
            this.buttonAutoRefresh.UseVisualStyleBackColor = false;
            this.buttonAutoRefresh.Click += new System.EventHandler(this.buttonAutoRefresh_Click);
            // 
            // textBoxTimeOrdered
            // 
            this.textBoxTimeOrdered.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxTimeOrdered.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTimeOrdered.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTimeOrdered.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.textBoxTimeOrdered.ForeColor = System.Drawing.Color.Black;
            this.textBoxTimeOrdered.Location = new System.Drawing.Point(824, 6);
            this.textBoxTimeOrdered.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTimeOrdered.Name = "textBoxTimeOrdered";
            this.textBoxTimeOrdered.ReadOnly = true;
            this.textBoxTimeOrdered.Size = new System.Drawing.Size(262, 27);
            this.textBoxTimeOrdered.TabIndex = 17;
            this.textBoxTimeOrdered.Text = "HH:MM:SS";
            this.textBoxTimeOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelLastChange
            // 
            this.labelLastChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLastChange.AutoSize = true;
            this.labelLastChange.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelLastChange.ForeColor = System.Drawing.Color.Black;
            this.labelLastChange.Location = new System.Drawing.Point(711, 11);
            this.labelLastChange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastChange.Name = "labelLastChange";
            this.labelLastChange.Size = new System.Drawing.Size(109, 20);
            this.labelLastChange.TabIndex = 16;
            this.labelLastChange.Text = "Time Ordered:";
            // 
            // ColumnButtonDispatch
            // 
            this.ColumnButtonDispatch.DataPropertyName = "ColumnButtonDispatch";
            this.ColumnButtonDispatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnButtonDispatch.HeaderText = "";
            this.ColumnButtonDispatch.Name = "ColumnButtonDispatch";
            this.ColumnButtonDispatch.ReadOnly = true;
            this.ColumnButtonDispatch.Width = 80;
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
            this.ColumnTerminal.Visible = false;
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
            this.ColumnSalesDate.Visible = false;
            this.ColumnSalesDate.Width = 95;
            // 
            // ColumnSalesNumber
            // 
            this.ColumnSalesNumber.DataPropertyName = "ColumnSalesNumber";
            this.ColumnSalesNumber.HeaderText = "Order No.";
            this.ColumnSalesNumber.Name = "ColumnSalesNumber";
            this.ColumnSalesNumber.ReadOnly = true;
            // 
            // ColumnManualSalesNumber
            // 
            this.ColumnManualSalesNumber.DataPropertyName = "ColumnManualSalesNumber";
            this.ColumnManualSalesNumber.HeaderText = "Manual Orde No.";
            this.ColumnManualSalesNumber.Name = "ColumnManualSalesNumber";
            this.ColumnManualSalesNumber.ReadOnly = true;
            // 
            // ColumnCustomer
            // 
            this.ColumnCustomer.DataPropertyName = "ColumnCustomer";
            this.ColumnCustomer.HeaderText = "Customer";
            this.ColumnCustomer.Name = "ColumnCustomer";
            this.ColumnCustomer.ReadOnly = true;
            this.ColumnCustomer.Width = 130;
            // 
            // ColumnCustomerAddress
            // 
            this.ColumnCustomerAddress.DataPropertyName = "ColumnCustomerAddress";
            this.ColumnCustomerAddress.HeaderText = "Address";
            this.ColumnCustomerAddress.Name = "ColumnCustomerAddress";
            this.ColumnCustomerAddress.ReadOnly = true;
            this.ColumnCustomerAddress.Visible = false;
            // 
            // ColumnDelivery
            // 
            this.ColumnDelivery.DataPropertyName = "ColumnDelivery";
            this.ColumnDelivery.HeaderText = "Delivery";
            this.ColumnDelivery.Name = "ColumnDelivery";
            this.ColumnDelivery.ReadOnly = true;
            this.ColumnDelivery.Width = 130;
            // 
            // ColumnNumberOfItems
            // 
            this.ColumnNumberOfItems.DataPropertyName = "ColumnNumberOfItems";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnNumberOfItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnNumberOfItems.HeaderText = "No. of Items";
            this.ColumnNumberOfItems.Name = "ColumnNumberOfItems";
            this.ColumnNumberOfItems.ReadOnly = true;
            // 
            // ColumnIsLocked
            // 
            this.ColumnIsLocked.DataPropertyName = "ColumnIsLocked";
            this.ColumnIsLocked.HeaderText = "L";
            this.ColumnIsLocked.Name = "ColumnIsLocked";
            this.ColumnIsLocked.ReadOnly = true;
            this.ColumnIsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsLocked.Visible = false;
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
            this.ColumnIsTendered.Visible = false;
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
            this.ColumnIsCancelled.Visible = false;
            this.ColumnIsCancelled.Width = 35;
            // 
            // ColumnIsDispatched
            // 
            this.ColumnIsDispatched.DataPropertyName = "ColumnIsDispatched";
            this.ColumnIsDispatched.HeaderText = "D";
            this.ColumnIsDispatched.Name = "ColumnIsDispatched";
            this.ColumnIsDispatched.ReadOnly = true;
            this.ColumnIsDispatched.Visible = false;
            this.ColumnIsDispatched.Width = 35;
            // 
            // ColumnPrepared
            // 
            this.ColumnPrepared.DataPropertyName = "ColumnPrepared";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnPrepared.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnPrepared.HeaderText = "Prepared";
            this.ColumnPrepared.Name = "ColumnPrepared";
            this.ColumnPrepared.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "ColumnStatus";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Width = 140;
            // 
            // ColumnSpace
            // 
            this.ColumnSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSpace.DataPropertyName = "ColumnSpace";
            this.ColumnSpace.HeaderText = "";
            this.ColumnSpace.Name = "ColumnSpace";
            this.ColumnSpace.ReadOnly = true;
            // 
            // SysDispatchStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1096, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "SysDispatchStationForm";
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
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewSalesList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSalesDate;
        private System.Windows.Forms.TextBox textBoxSalesListFilter;
        private System.Windows.Forms.ComboBox comboBoxTerminal;
        private System.Windows.Forms.DataGridView dataGridViewSalesLineItemDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLineItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesLlineAmount;
        private System.Windows.Forms.Timer timerRefreshSalesListGrid;
        private System.Windows.Forms.Button buttonSalesListPageListFirst;
        private System.Windows.Forms.Button buttonSalesListPageListPrevious;
        private System.Windows.Forms.Button buttonSalesListPageListNext;
        private System.Windows.Forms.Button buttonSalesListPageListLast;
        private System.Windows.Forms.TextBox textBoxPageNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonNewOrders;
        private System.Windows.Forms.ImageList imageListDispatchStation;
        private System.Windows.Forms.Button buttonDispatchedOrders;
        private System.Windows.Forms.Button buttonDeliveredOrders;
        private System.Windows.Forms.TextBox textBoxTimeOrdered;
        private System.Windows.Forms.Label labelLastChange;
        private System.Windows.Forms.Label labelManualSalesNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCustomerAddress;
        private System.Windows.Forms.Label labelDeliveryMan;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Button buttonAutoRefresh;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnButtonDispatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTerminal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnManualSalesNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCustomerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberOfItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsLocked;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsTendered;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCancelled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsDispatched;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPrepared;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpace;
    }
}