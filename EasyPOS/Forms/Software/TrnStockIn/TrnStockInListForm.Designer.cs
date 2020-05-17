namespace EasyPOS.Forms.Software.TrnStockIn
{
    partial class TrnStockInListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockInListForm));
            this.textBoxStockInListFilter = new System.Windows.Forms.TextBox();
            this.buttonStockInListPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockInListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockInListPageListNext = new System.Windows.Forms.Button();
            this.dataGridViewStockInList = new System.Windows.Forms.DataGridView();
            this.ColumnStockInListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockInListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockInListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInListStockInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInListStockInNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInListSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockInListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonStockInListPageListLast = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxStockInListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockInListFilter = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxStockInListFilter
            // 
            this.textBoxStockInListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockInListFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxStockInListFilter.Name = "textBoxStockInListFilter";
            this.textBoxStockInListFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxStockInListFilter.TabIndex = 1;
            this.textBoxStockInListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockInListFilter_KeyDown);
            // 
            // buttonStockInListPageListFirst
            // 
            this.buttonStockInListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInListPageListFirst.Enabled = false;
            this.buttonStockInListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockInListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInListPageListFirst.Location = new System.Drawing.Point(12, 11);
            this.buttonStockInListPageListFirst.Name = "buttonStockInListPageListFirst";
            this.buttonStockInListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInListPageListFirst.TabIndex = 13;
            this.buttonStockInListPageListFirst.Text = "First";
            this.buttonStockInListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockInListPageListFirst.Click += new System.EventHandler(this.buttonStockInListPageListFirst_Click);
            // 
            // buttonStockInListPageListPrevious
            // 
            this.buttonStockInListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInListPageListPrevious.Enabled = false;
            this.buttonStockInListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockInListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInListPageListPrevious.Location = new System.Drawing.Point(100, 11);
            this.buttonStockInListPageListPrevious.Name = "buttonStockInListPageListPrevious";
            this.buttonStockInListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInListPageListPrevious.TabIndex = 14;
            this.buttonStockInListPageListPrevious.Text = "Previous";
            this.buttonStockInListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockInListPageListPrevious.Click += new System.EventHandler(this.buttonStockInListPageListPrevious_Click);
            // 
            // buttonStockInListPageListNext
            // 
            this.buttonStockInListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockInListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInListPageListNext.Location = new System.Drawing.Point(263, 11);
            this.buttonStockInListPageListNext.Name = "buttonStockInListPageListNext";
            this.buttonStockInListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInListPageListNext.TabIndex = 15;
            this.buttonStockInListPageListNext.Text = "Next";
            this.buttonStockInListPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockInListPageListNext.Click += new System.EventHandler(this.buttonStockInListPageListNext_Click);
            // 
            // dataGridViewStockInList
            // 
            this.dataGridViewStockInList.AllowUserToAddRows = false;
            this.dataGridViewStockInList.AllowUserToDeleteRows = false;
            this.dataGridViewStockInList.AllowUserToResizeRows = false;
            this.dataGridViewStockInList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockInList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockInList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockInList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockInListButtonEdit,
            this.ColumnStockInListButtonDelete,
            this.ColumnStockInListId,
            this.ColumnStockInListStockInDate,
            this.ColumnStockInListStockInNumber,
            this.ColumnStockInListSupplier,
            this.ColumnStockInListRemarks,
            this.ColumnStockInListIsLocked});
            this.dataGridViewStockInList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockInList.MultiSelect = false;
            this.dataGridViewStockInList.Name = "dataGridViewStockInList";
            this.dataGridViewStockInList.ReadOnly = true;
            this.dataGridViewStockInList.RowTemplate.Height = 24;
            this.dataGridViewStockInList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockInList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockInList.TabIndex = 20;
            this.dataGridViewStockInList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockInList_CellClick);
            // 
            // ColumnStockInListButtonEdit
            // 
            this.ColumnStockInListButtonEdit.DataPropertyName = "ColumnStockInListButtonEdit";
            this.ColumnStockInListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockInListButtonEdit.HeaderText = "";
            this.ColumnStockInListButtonEdit.Name = "ColumnStockInListButtonEdit";
            this.ColumnStockInListButtonEdit.ReadOnly = true;
            this.ColumnStockInListButtonEdit.Width = 70;
            // 
            // ColumnStockInListButtonDelete
            // 
            this.ColumnStockInListButtonDelete.DataPropertyName = "ColumnStockInListButtonDelete";
            this.ColumnStockInListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockInListButtonDelete.HeaderText = "";
            this.ColumnStockInListButtonDelete.Name = "ColumnStockInListButtonDelete";
            this.ColumnStockInListButtonDelete.ReadOnly = true;
            this.ColumnStockInListButtonDelete.Width = 70;
            // 
            // ColumnStockInListId
            // 
            this.ColumnStockInListId.DataPropertyName = "ColumnStockInListId";
            this.ColumnStockInListId.HeaderText = "Id";
            this.ColumnStockInListId.Name = "ColumnStockInListId";
            this.ColumnStockInListId.ReadOnly = true;
            this.ColumnStockInListId.Visible = false;
            // 
            // ColumnStockInListStockInDate
            // 
            this.ColumnStockInListStockInDate.DataPropertyName = "ColumnStockInListStockInDate";
            this.ColumnStockInListStockInDate.HeaderText = "Stock-In Date";
            this.ColumnStockInListStockInDate.Name = "ColumnStockInListStockInDate";
            this.ColumnStockInListStockInDate.ReadOnly = true;
            this.ColumnStockInListStockInDate.Width = 95;
            // 
            // ColumnStockInListStockInNumber
            // 
            this.ColumnStockInListStockInNumber.DataPropertyName = "ColumnStockInListStockInNumber";
            this.ColumnStockInListStockInNumber.HeaderText = "Stock-In No.";
            this.ColumnStockInListStockInNumber.Name = "ColumnStockInListStockInNumber";
            this.ColumnStockInListStockInNumber.ReadOnly = true;
            // 
            // ColumnStockInListSupplier
            // 
            this.ColumnStockInListSupplier.DataPropertyName = "ColumnStockInListSupplier";
            this.ColumnStockInListSupplier.HeaderText = "Supplier";
            this.ColumnStockInListSupplier.Name = "ColumnStockInListSupplier";
            this.ColumnStockInListSupplier.ReadOnly = true;
            this.ColumnStockInListSupplier.Width = 200;
            // 
            // ColumnStockInListRemarks
            // 
            this.ColumnStockInListRemarks.DataPropertyName = "ColumnStockInListRemarks";
            this.ColumnStockInListRemarks.HeaderText = "Remarks";
            this.ColumnStockInListRemarks.Name = "ColumnStockInListRemarks";
            this.ColumnStockInListRemarks.ReadOnly = true;
            this.ColumnStockInListRemarks.Width = 300;
            // 
            // ColumnStockInListIsLocked
            // 
            this.ColumnStockInListIsLocked.DataPropertyName = "ColumnStockInListIsLocked";
            this.ColumnStockInListIsLocked.HeaderText = "L";
            this.ColumnStockInListIsLocked.Name = "ColumnStockInListIsLocked";
            this.ColumnStockInListIsLocked.ReadOnly = true;
            this.ColumnStockInListIsLocked.Width = 35;
            // 
            // buttonStockInListPageListLast
            // 
            this.buttonStockInListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockInListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockInListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockInListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockInListPageListLast.Location = new System.Drawing.Point(348, 11);
            this.buttonStockInListPageListLast.Name = "buttonStockInListPageListLast";
            this.buttonStockInListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockInListPageListLast.TabIndex = 16;
            this.buttonStockInListPageListLast.Text = "Last";
            this.buttonStockInListPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockInListPageListLast.Click += new System.EventHandler(this.buttonStockInListPageListLast_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockInListPageListFirst);
            this.panel3.Controls.Add(this.buttonStockInListPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockInListPageListNext);
            this.panel3.Controls.Add(this.buttonStockInListPageListLast);
            this.panel3.Controls.Add(this.textBoxStockInListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // textBoxStockInListPageNumber
            // 
            this.textBoxStockInListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockInListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockInListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockInListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockInListPageNumber.Location = new System.Drawing.Point(188, 16);
            this.textBoxStockInListPageNumber.Name = "textBoxStockInListPageNumber";
            this.textBoxStockInListPageNumber.ReadOnly = true;
            this.textBoxStockInListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockInListPageNumber.TabIndex = 17;
            this.textBoxStockInListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockInListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockInList);
            this.panel2.Controls.Add(this.textBoxStockInListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 7;
            // 
            // dateTimePickerStockInListFilter
            // 
            this.dateTimePickerStockInListFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockInListFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockInListFilter.Name = "dateTimePickerStockInListFilter";
            this.dateTimePickerStockInListFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockInListFilter.TabIndex = 0;
            this.dateTimePickerStockInListFilter.ValueChanged += new System.EventHandler(this.dateTimePickerStockInListFilter_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Stock_In;
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
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-In List";
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
            this.buttonClose.TabIndex = 21;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(1206, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 40);
            this.buttonAdd.TabIndex = 20;
            this.buttonAdd.TabStop = false;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 6;
            // 
            // TrnStockInListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1400, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TrnStockInListForm";
            this.Text = "Stock In List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockInList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxStockInListFilter;
        private System.Windows.Forms.Button buttonStockInListPageListFirst;
        private System.Windows.Forms.Button buttonStockInListPageListPrevious;
        private System.Windows.Forms.Button buttonStockInListPageListNext;
        private System.Windows.Forms.DataGridView dataGridViewStockInList;
        private System.Windows.Forms.Button buttonStockInListPageListLast;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxStockInListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockInListFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockInListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockInListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInListStockInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInListStockInNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInListSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockInListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockInListIsLocked;
    }
}