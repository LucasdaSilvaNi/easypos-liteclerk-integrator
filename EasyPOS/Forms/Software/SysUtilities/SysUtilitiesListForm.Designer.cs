namespace EasyPOS.Forms.Software.SysUtilities
{
    partial class SysUtilitiesListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysUtilitiesListForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAuditTrailListPageListFirst = new System.Windows.Forms.Button();
            this.buttonAuditTrailListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonAuditTrailListPageListNext = new System.Windows.Forms.Button();
            this.buttonAuditTrailListPageListLast = new System.Windows.Forms.Button();
            this.textBoxAuditTrailListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonView = new System.Windows.Forms.Button();
            this.comboBoxUserFilter = new System.Windows.Forms.ComboBox();
            this.dateTimePickerSysAuditTrailListEndDateFilter = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSysAuditTrailListStartDateFilter = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewAuditTrailList = new System.Windows.Forms.DataGridView();
            this.ColumnAuditTrailListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListAuditDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListTableInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListActionInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListRecordInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListFormInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuditTrailListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControlSystemTable = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tabPageBarcodePrinting = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonItemListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemListPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewItemList = new System.Windows.Forms.DataGridView();
            this.ColumnItemListButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemListIsInventory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnItemListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnItemListSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxItemListFilter = new System.Windows.Forms.TextBox();
            this.folderBrowserDialogGenerateCSV = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditTrailList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControlSystemTable.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPageBarcodePrinting.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonAuditTrailListPageListFirst);
            this.panel3.Controls.Add(this.buttonAuditTrailListPageListPrevious);
            this.panel3.Controls.Add(this.buttonAuditTrailListPageListNext);
            this.panel3.Controls.Add(this.buttonAuditTrailListPageListLast);
            this.panel3.Controls.Add(this.textBoxAuditTrailListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 542);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1386, 53);
            this.panel3.TabIndex = 21;
            // 
            // buttonAuditTrailListPageListFirst
            // 
            this.buttonAuditTrailListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAuditTrailListPageListFirst.Enabled = false;
            this.buttonAuditTrailListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonAuditTrailListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuditTrailListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAuditTrailListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonAuditTrailListPageListFirst.Name = "buttonAuditTrailListPageListFirst";
            this.buttonAuditTrailListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonAuditTrailListPageListFirst.TabIndex = 13;
            this.buttonAuditTrailListPageListFirst.TabStop = false;
            this.buttonAuditTrailListPageListFirst.Text = "First";
            this.buttonAuditTrailListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonAuditTrailListPageListFirst.Click += new System.EventHandler(this.buttonAudiTrailListPageListLastFirst_Click);
            // 
            // buttonAuditTrailListPageListPrevious
            // 
            this.buttonAuditTrailListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAuditTrailListPageListPrevious.Enabled = false;
            this.buttonAuditTrailListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonAuditTrailListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuditTrailListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAuditTrailListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonAuditTrailListPageListPrevious.Name = "buttonAuditTrailListPageListPrevious";
            this.buttonAuditTrailListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonAuditTrailListPageListPrevious.TabIndex = 14;
            this.buttonAuditTrailListPageListPrevious.TabStop = false;
            this.buttonAuditTrailListPageListPrevious.Text = "Previous";
            this.buttonAuditTrailListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonAuditTrailListPageListPrevious.Click += new System.EventHandler(this.buttonAudiTrailListPageListLastPrevious_Click);
            // 
            // buttonAuditTrailListPageListNext
            // 
            this.buttonAuditTrailListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAuditTrailListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonAuditTrailListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuditTrailListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAuditTrailListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonAuditTrailListPageListNext.Name = "buttonAuditTrailListPageListNext";
            this.buttonAuditTrailListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonAuditTrailListPageListNext.TabIndex = 15;
            this.buttonAuditTrailListPageListNext.TabStop = false;
            this.buttonAuditTrailListPageListNext.Text = "Next";
            this.buttonAuditTrailListPageListNext.UseVisualStyleBackColor = false;
            this.buttonAuditTrailListPageListNext.Click += new System.EventHandler(this.buttonAudiTrailListPageListLastNext_Click);
            // 
            // buttonAuditTrailListPageListLast
            // 
            this.buttonAuditTrailListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAuditTrailListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonAuditTrailListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuditTrailListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAuditTrailListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonAuditTrailListPageListLast.Name = "buttonAuditTrailListPageListLast";
            this.buttonAuditTrailListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonAuditTrailListPageListLast.TabIndex = 16;
            this.buttonAuditTrailListPageListLast.TabStop = false;
            this.buttonAuditTrailListPageListLast.Text = "Last";
            this.buttonAuditTrailListPageListLast.UseVisualStyleBackColor = false;
            this.buttonAuditTrailListPageListLast.Click += new System.EventHandler(this.buttonAudiTrailListPageListLastLast_Click);
            // 
            // textBoxAuditTrailListPageNumber
            // 
            this.textBoxAuditTrailListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAuditTrailListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxAuditTrailListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAuditTrailListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxAuditTrailListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxAuditTrailListPageNumber.Name = "textBoxAuditTrailListPageNumber";
            this.textBoxAuditTrailListPageNumber.ReadOnly = true;
            this.textBoxAuditTrailListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxAuditTrailListPageNumber.TabIndex = 17;
            this.textBoxAuditTrailListPageNumber.TabStop = false;
            this.textBoxAuditTrailListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonView);
            this.panel2.Controls.Add(this.comboBoxUserFilter);
            this.panel2.Controls.Add(this.dateTimePickerSysAuditTrailListEndDateFilter);
            this.panel2.Controls.Add(this.dateTimePickerSysAuditTrailListStartDateFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewAuditTrailList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1386, 595);
            this.panel2.TabIndex = 9;
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
            this.buttonView.Location = new System.Drawing.Point(1293, 5);
            this.buttonView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(88, 31);
            this.buttonView.TabIndex = 22;
            this.buttonView.TabStop = false;
            this.buttonView.Text = "CSV";
            this.buttonView.UseVisualStyleBackColor = false;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // comboBoxUserFilter
            // 
            this.comboBoxUserFilter.FormattingEnabled = true;
            this.comboBoxUserFilter.Location = new System.Drawing.Point(298, 5);
            this.comboBoxUserFilter.Name = "comboBoxUserFilter";
            this.comboBoxUserFilter.Size = new System.Drawing.Size(264, 31);
            this.comboBoxUserFilter.TabIndex = 2;
            this.comboBoxUserFilter.SelectedIndexChanged += new System.EventHandler(this.AuditTrailList_Filter);
            // 
            // dateTimePickerSysAuditTrailListEndDateFilter
            // 
            this.dateTimePickerSysAuditTrailListEndDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSysAuditTrailListEndDateFilter.Location = new System.Drawing.Point(151, 6);
            this.dateTimePickerSysAuditTrailListEndDateFilter.Name = "dateTimePickerSysAuditTrailListEndDateFilter";
            this.dateTimePickerSysAuditTrailListEndDateFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerSysAuditTrailListEndDateFilter.TabIndex = 1;
            this.dateTimePickerSysAuditTrailListEndDateFilter.ValueChanged += new System.EventHandler(this.dateTimePickerSysAuditTrailListEndDateFilter_ValueChanged);
            // 
            // dateTimePickerSysAuditTrailListStartDateFilter
            // 
            this.dateTimePickerSysAuditTrailListStartDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerSysAuditTrailListStartDateFilter.Location = new System.Drawing.Point(5, 6);
            this.dateTimePickerSysAuditTrailListStartDateFilter.Name = "dateTimePickerSysAuditTrailListStartDateFilter";
            this.dateTimePickerSysAuditTrailListStartDateFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerSysAuditTrailListStartDateFilter.TabIndex = 0;
            this.dateTimePickerSysAuditTrailListStartDateFilter.ValueChanged += new System.EventHandler(this.dateTimePickerSysAuditTrailListStartDateFilter_ValueChanged);
            // 
            // dataGridViewAuditTrailList
            // 
            this.dataGridViewAuditTrailList.AllowUserToAddRows = false;
            this.dataGridViewAuditTrailList.AllowUserToDeleteRows = false;
            this.dataGridViewAuditTrailList.AllowUserToResizeRows = false;
            this.dataGridViewAuditTrailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAuditTrailList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAuditTrailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuditTrailList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAuditTrailListId,
            this.ColumnAuditTrailListUserId,
            this.ColumnAuditTrailListAuditDate,
            this.ColumnAuditTrailListUser,
            this.ColumnAuditTrailListTableInformation,
            this.ColumnAuditTrailListActionInformation,
            this.ColumnAuditTrailListRecordInformation,
            this.ColumnAuditTrailListFormInformation,
            this.ColumnAuditTrailListSpace});
            this.dataGridViewAuditTrailList.Location = new System.Drawing.Point(5, 42);
            this.dataGridViewAuditTrailList.MultiSelect = false;
            this.dataGridViewAuditTrailList.Name = "dataGridViewAuditTrailList";
            this.dataGridViewAuditTrailList.ReadOnly = true;
            this.dataGridViewAuditTrailList.RowHeadersVisible = false;
            this.dataGridViewAuditTrailList.RowTemplate.Height = 24;
            this.dataGridViewAuditTrailList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAuditTrailList.Size = new System.Drawing.Size(1376, 494);
            this.dataGridViewAuditTrailList.TabIndex = 20;
            // 
            // ColumnAuditTrailListId
            // 
            this.ColumnAuditTrailListId.DataPropertyName = "ColumnAuditTrailListId";
            this.ColumnAuditTrailListId.HeaderText = "Id";
            this.ColumnAuditTrailListId.Name = "ColumnAuditTrailListId";
            this.ColumnAuditTrailListId.ReadOnly = true;
            this.ColumnAuditTrailListId.Visible = false;
            // 
            // ColumnAuditTrailListUserId
            // 
            this.ColumnAuditTrailListUserId.DataPropertyName = "ColumnAuditTrailListUserId";
            this.ColumnAuditTrailListUserId.HeaderText = "UserId";
            this.ColumnAuditTrailListUserId.Name = "ColumnAuditTrailListUserId";
            this.ColumnAuditTrailListUserId.ReadOnly = true;
            this.ColumnAuditTrailListUserId.Visible = false;
            // 
            // ColumnAuditTrailListAuditDate
            // 
            this.ColumnAuditTrailListAuditDate.DataPropertyName = "ColumnAuditTrailListAuditDate";
            this.ColumnAuditTrailListAuditDate.HeaderText = "Date";
            this.ColumnAuditTrailListAuditDate.Name = "ColumnAuditTrailListAuditDate";
            this.ColumnAuditTrailListAuditDate.ReadOnly = true;
            this.ColumnAuditTrailListAuditDate.Width = 150;
            // 
            // ColumnAuditTrailListUser
            // 
            this.ColumnAuditTrailListUser.DataPropertyName = "ColumnAuditTrailListUser";
            this.ColumnAuditTrailListUser.HeaderText = "User";
            this.ColumnAuditTrailListUser.Name = "ColumnAuditTrailListUser";
            this.ColumnAuditTrailListUser.ReadOnly = true;
            this.ColumnAuditTrailListUser.Width = 150;
            // 
            // ColumnAuditTrailListTableInformation
            // 
            this.ColumnAuditTrailListTableInformation.DataPropertyName = "ColumnAuditTrailListTableInformation";
            this.ColumnAuditTrailListTableInformation.HeaderText = "Module";
            this.ColumnAuditTrailListTableInformation.Name = "ColumnAuditTrailListTableInformation";
            this.ColumnAuditTrailListTableInformation.ReadOnly = true;
            this.ColumnAuditTrailListTableInformation.Width = 200;
            // 
            // ColumnAuditTrailListActionInformation
            // 
            this.ColumnAuditTrailListActionInformation.DataPropertyName = "ColumnAuditTrailListActionInformation";
            this.ColumnAuditTrailListActionInformation.HeaderText = "Action Taken";
            this.ColumnAuditTrailListActionInformation.Name = "ColumnAuditTrailListActionInformation";
            this.ColumnAuditTrailListActionInformation.ReadOnly = true;
            this.ColumnAuditTrailListActionInformation.Width = 150;
            // 
            // ColumnAuditTrailListRecordInformation
            // 
            this.ColumnAuditTrailListRecordInformation.DataPropertyName = "ColumnAuditTrailListRecordInformation";
            this.ColumnAuditTrailListRecordInformation.HeaderText = "Old Value";
            this.ColumnAuditTrailListRecordInformation.Name = "ColumnAuditTrailListRecordInformation";
            this.ColumnAuditTrailListRecordInformation.ReadOnly = true;
            this.ColumnAuditTrailListRecordInformation.Width = 320;
            // 
            // ColumnAuditTrailListFormInformation
            // 
            this.ColumnAuditTrailListFormInformation.DataPropertyName = "ColumnAuditTrailListFormInformation";
            this.ColumnAuditTrailListFormInformation.HeaderText = "New Value";
            this.ColumnAuditTrailListFormInformation.Name = "ColumnAuditTrailListFormInformation";
            this.ColumnAuditTrailListFormInformation.ReadOnly = true;
            this.ColumnAuditTrailListFormInformation.Width = 320;
            // 
            // ColumnAuditTrailListSpace
            // 
            this.ColumnAuditTrailListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAuditTrailListSpace.DataPropertyName = "ColumnAuditTrailListSpace";
            this.ColumnAuditTrailListSpace.HeaderText = "";
            this.ColumnAuditTrailListSpace.Name = "ColumnAuditTrailListSpace";
            this.ColumnAuditTrailListSpace.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Utilities;
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
            this.label1.Size = new System.Drawing.Size(197, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "System Utilities";
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
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // tabControlSystemTable
            // 
            this.tabControlSystemTable.Controls.Add(this.tabPage1);
            this.tabControlSystemTable.Controls.Add(this.tabPageBarcodePrinting);
            this.tabControlSystemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSystemTable.Location = new System.Drawing.Point(0, 63);
            this.tabControlSystemTable.Name = "tabControlSystemTable";
            this.tabControlSystemTable.SelectedIndex = 0;
            this.tabControlSystemTable.Size = new System.Drawing.Size(1400, 637);
            this.tabControlSystemTable.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 601);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Audit Trail";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1386, 595);
            this.panel9.TabIndex = 1;
            // 
            // tabPageBarcodePrinting
            // 
            this.tabPageBarcodePrinting.Controls.Add(this.panel4);
            this.tabPageBarcodePrinting.Location = new System.Drawing.Point(4, 32);
            this.tabPageBarcodePrinting.Name = "tabPageBarcodePrinting";
            this.tabPageBarcodePrinting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBarcodePrinting.Size = new System.Drawing.Size(1392, 601);
            this.tabPageBarcodePrinting.TabIndex = 1;
            this.tabPageBarcodePrinting.Text = "Barcode Printing";
            this.tabPageBarcodePrinting.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.dataGridViewItemList);
            this.panel4.Controls.Add(this.textBoxItemListFilter);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1386, 595);
            this.panel4.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.buttonItemListPageListFirst);
            this.panel5.Controls.Add(this.buttonItemListPageListPrevious);
            this.panel5.Controls.Add(this.buttonItemListPageListNext);
            this.panel5.Controls.Add(this.buttonItemListPageListLast);
            this.panel5.Controls.Add(this.textBoxItemListPageNumber);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 542);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1386, 53);
            this.panel5.TabIndex = 18;
            // 
            // buttonItemListPageListFirst
            // 
            this.buttonItemListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListFirst.Enabled = false;
            this.buttonItemListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonItemListPageListFirst.Name = "buttonItemListPageListFirst";
            this.buttonItemListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListFirst.TabIndex = 13;
            this.buttonItemListPageListFirst.TabStop = false;
            this.buttonItemListPageListFirst.Text = "First";
            this.buttonItemListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonItemListPageListFirst.Click += new System.EventHandler(this.buttonItemListPageListFirst_Click);
            // 
            // buttonItemListPageListPrevious
            // 
            this.buttonItemListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListPrevious.Enabled = false;
            this.buttonItemListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonItemListPageListPrevious.Name = "buttonItemListPageListPrevious";
            this.buttonItemListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListPrevious.TabIndex = 14;
            this.buttonItemListPageListPrevious.TabStop = false;
            this.buttonItemListPageListPrevious.Text = "Previous";
            this.buttonItemListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonItemListPageListPrevious.Click += new System.EventHandler(this.buttonItemListPageListPrevious_Click);
            // 
            // buttonItemListPageListNext
            // 
            this.buttonItemListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonItemListPageListNext.Name = "buttonItemListPageListNext";
            this.buttonItemListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListNext.TabIndex = 15;
            this.buttonItemListPageListNext.TabStop = false;
            this.buttonItemListPageListNext.Text = "Next";
            this.buttonItemListPageListNext.UseVisualStyleBackColor = false;
            this.buttonItemListPageListNext.Click += new System.EventHandler(this.buttonItemListPageListNext_Click);
            // 
            // buttonItemListPageListLast
            // 
            this.buttonItemListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonItemListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonItemListPageListLast.Name = "buttonItemListPageListLast";
            this.buttonItemListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonItemListPageListLast.TabIndex = 16;
            this.buttonItemListPageListLast.TabStop = false;
            this.buttonItemListPageListLast.Text = "Last";
            this.buttonItemListPageListLast.UseVisualStyleBackColor = false;
            this.buttonItemListPageListLast.Click += new System.EventHandler(this.buttonItemListPageListLast_Click);
            // 
            // textBoxItemListPageNumber
            // 
            this.textBoxItemListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxItemListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxItemListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxItemListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxItemListPageNumber.Name = "textBoxItemListPageNumber";
            this.textBoxItemListPageNumber.ReadOnly = true;
            this.textBoxItemListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxItemListPageNumber.TabIndex = 17;
            this.textBoxItemListPageNumber.TabStop = false;
            this.textBoxItemListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewItemList
            // 
            this.dataGridViewItemList.AllowUserToAddRows = false;
            this.dataGridViewItemList.AllowUserToDeleteRows = false;
            this.dataGridViewItemList.AllowUserToResizeRows = false;
            this.dataGridViewItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemListButtonPick,
            this.ColumnItemListId,
            this.ColumnItemListCode,
            this.ColumnItemListDescription,
            this.ColumnItemListBarcode,
            this.ColumnItemListUnit,
            this.ColumnItemListCategory,
            this.ColumnItemListAlias,
            this.ColumnItemListPrice,
            this.ColumnItemListIsInventory,
            this.ColumnItemListIsLocked,
            this.ColumnItemListSpace});
            this.dataGridViewItemList.Location = new System.Drawing.Point(5, 42);
            this.dataGridViewItemList.MultiSelect = false;
            this.dataGridViewItemList.Name = "dataGridViewItemList";
            this.dataGridViewItemList.ReadOnly = true;
            this.dataGridViewItemList.RowHeadersVisible = false;
            this.dataGridViewItemList.RowTemplate.Height = 24;
            this.dataGridViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemList.Size = new System.Drawing.Size(1369, 494);
            this.dataGridViewItemList.TabIndex = 9;
            this.dataGridViewItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemList_CellClick);
            // 
            // ColumnItemListButtonPick
            // 
            this.ColumnItemListButtonPick.DataPropertyName = "ColumnItemListButtonPick";
            this.ColumnItemListButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemListButtonPick.HeaderText = "";
            this.ColumnItemListButtonPick.Name = "ColumnItemListButtonPick";
            this.ColumnItemListButtonPick.ReadOnly = true;
            this.ColumnItemListButtonPick.Width = 70;
            // 
            // ColumnItemListId
            // 
            this.ColumnItemListId.DataPropertyName = "ColumnItemListId";
            this.ColumnItemListId.HeaderText = "Id";
            this.ColumnItemListId.Name = "ColumnItemListId";
            this.ColumnItemListId.ReadOnly = true;
            this.ColumnItemListId.Visible = false;
            // 
            // ColumnItemListCode
            // 
            this.ColumnItemListCode.DataPropertyName = "ColumnItemListCode";
            this.ColumnItemListCode.HeaderText = "Code";
            this.ColumnItemListCode.Name = "ColumnItemListCode";
            this.ColumnItemListCode.ReadOnly = true;
            this.ColumnItemListCode.Width = 150;
            // 
            // ColumnItemListDescription
            // 
            this.ColumnItemListDescription.DataPropertyName = "ColumnItemListDescription";
            this.ColumnItemListDescription.HeaderText = "Description";
            this.ColumnItemListDescription.Name = "ColumnItemListDescription";
            this.ColumnItemListDescription.ReadOnly = true;
            this.ColumnItemListDescription.Width = 250;
            // 
            // ColumnItemListBarcode
            // 
            this.ColumnItemListBarcode.DataPropertyName = "ColumnItemListBarcode";
            this.ColumnItemListBarcode.HeaderText = "Barcode";
            this.ColumnItemListBarcode.Name = "ColumnItemListBarcode";
            this.ColumnItemListBarcode.ReadOnly = true;
            this.ColumnItemListBarcode.Width = 200;
            // 
            // ColumnItemListUnit
            // 
            this.ColumnItemListUnit.DataPropertyName = "ColumnItemListUnit";
            this.ColumnItemListUnit.HeaderText = "Unit";
            this.ColumnItemListUnit.Name = "ColumnItemListUnit";
            this.ColumnItemListUnit.ReadOnly = true;
            this.ColumnItemListUnit.Width = 70;
            // 
            // ColumnItemListCategory
            // 
            this.ColumnItemListCategory.DataPropertyName = "ColumnItemListCategory";
            this.ColumnItemListCategory.HeaderText = "Category";
            this.ColumnItemListCategory.Name = "ColumnItemListCategory";
            this.ColumnItemListCategory.ReadOnly = true;
            this.ColumnItemListCategory.Width = 250;
            // 
            // ColumnItemListAlias
            // 
            this.ColumnItemListAlias.DataPropertyName = "ColumnItemListAlias";
            this.ColumnItemListAlias.HeaderText = "Alias";
            this.ColumnItemListAlias.Name = "ColumnItemListAlias";
            this.ColumnItemListAlias.ReadOnly = true;
            this.ColumnItemListAlias.Width = 250;
            // 
            // ColumnItemListPrice
            // 
            this.ColumnItemListPrice.DataPropertyName = "ColumnItemListPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnItemListPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnItemListPrice.HeaderText = "Price";
            this.ColumnItemListPrice.Name = "ColumnItemListPrice";
            this.ColumnItemListPrice.ReadOnly = true;
            // 
            // ColumnItemListIsInventory
            // 
            this.ColumnItemListIsInventory.DataPropertyName = "ColumnItemListIsInventory";
            this.ColumnItemListIsInventory.HeaderText = "I";
            this.ColumnItemListIsInventory.Name = "ColumnItemListIsInventory";
            this.ColumnItemListIsInventory.ReadOnly = true;
            this.ColumnItemListIsInventory.Width = 35;
            // 
            // ColumnItemListIsLocked
            // 
            this.ColumnItemListIsLocked.DataPropertyName = "ColumnItemListIsLocked";
            this.ColumnItemListIsLocked.HeaderText = "L";
            this.ColumnItemListIsLocked.Name = "ColumnItemListIsLocked";
            this.ColumnItemListIsLocked.ReadOnly = true;
            this.ColumnItemListIsLocked.Width = 35;
            // 
            // ColumnItemListSpace
            // 
            this.ColumnItemListSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnItemListSpace.HeaderText = "";
            this.ColumnItemListSpace.Name = "ColumnItemListSpace";
            this.ColumnItemListSpace.ReadOnly = true;
            // 
            // textBoxItemListFilter
            // 
            this.textBoxItemListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemListFilter.Location = new System.Drawing.Point(5, 6);
            this.textBoxItemListFilter.Name = "textBoxItemListFilter";
            this.textBoxItemListFilter.Size = new System.Drawing.Size(1369, 30);
            this.textBoxItemListFilter.TabIndex = 8;
            this.textBoxItemListFilter.TabStop = false;
            this.textBoxItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemListFilter_KeyDown);
            // 
            // SysUtilitiesListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.tabControlSystemTable);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SysUtilitiesListForm";
            this.Text = "SysAuditTrailList";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditTrailList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControlSystemTable.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tabPageBarcodePrinting.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAuditTrailListPageListFirst;
        private System.Windows.Forms.Button buttonAuditTrailListPageListPrevious;
        private System.Windows.Forms.Button buttonAuditTrailListPageListNext;
        private System.Windows.Forms.Button buttonAuditTrailListPageListLast;
        private System.Windows.Forms.TextBox textBoxAuditTrailListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerSysAuditTrailListStartDateFilter;
        private System.Windows.Forms.DataGridView dataGridViewAuditTrailList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DateTimePicker dateTimePickerSysAuditTrailListEndDateFilter;
        private System.Windows.Forms.ComboBox comboBoxUserFilter;
        private System.Windows.Forms.TabControl tabControlSystemTable;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListUserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListAuditDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListTableInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListActionInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListRecordInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListFormInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuditTrailListSpace;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGenerateCSV;
        private System.Windows.Forms.TabPage tabPageBarcodePrinting;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button buttonItemListPageListFirst;
        private System.Windows.Forms.Button buttonItemListPageListPrevious;
        private System.Windows.Forms.Button buttonItemListPageListNext;
        private System.Windows.Forms.Button buttonItemListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemListPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewItemList;
        private System.Windows.Forms.TextBox textBoxItemListFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemListButtonPick;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListPrice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnItemListIsInventory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnItemListIsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemListSpace;
    }
}