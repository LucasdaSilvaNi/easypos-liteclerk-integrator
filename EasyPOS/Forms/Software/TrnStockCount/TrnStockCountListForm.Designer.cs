namespace EasyPOS.Forms.Software.TrnStockCount
{
    partial class TrnStockCountListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockCountListForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonStockCountListPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockCountListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockCountListPageListNext = new System.Windows.Forms.Button();
            this.buttonStockCountListPageListLast = new System.Windows.Forms.Button();
            this.textBoxStockCountListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockCountListFilter = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewStockCountList = new System.Windows.Forms.DataGridView();
            this.ColumnStockCountListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockCountListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockCountListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCountListStockCountDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCountListStockCountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCountListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockCountListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxStockCountListFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCountList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockCountListPageListFirst);
            this.panel3.Controls.Add(this.buttonStockCountListPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockCountListPageListNext);
            this.panel3.Controls.Add(this.buttonStockCountListPageListLast);
            this.panel3.Controls.Add(this.textBoxStockCountListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // buttonStockCountListPageListFirst
            // 
            this.buttonStockCountListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCountListPageListFirst.Enabled = false;
            this.buttonStockCountListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockCountListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCountListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockCountListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockCountListPageListFirst.Name = "buttonStockCountListPageListFirst";
            this.buttonStockCountListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCountListPageListFirst.TabIndex = 13;
            this.buttonStockCountListPageListFirst.TabStop = false;
            this.buttonStockCountListPageListFirst.Text = "First";
            this.buttonStockCountListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockCountListPageListFirst.Click += new System.EventHandler(this.buttonStockCountListPageListFirst_Click);
            // 
            // buttonStockCountListPageListPrevious
            // 
            this.buttonStockCountListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCountListPageListPrevious.Enabled = false;
            this.buttonStockCountListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockCountListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCountListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockCountListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockCountListPageListPrevious.Name = "buttonStockCountListPageListPrevious";
            this.buttonStockCountListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCountListPageListPrevious.TabIndex = 14;
            this.buttonStockCountListPageListPrevious.TabStop = false;
            this.buttonStockCountListPageListPrevious.Text = "Previous";
            this.buttonStockCountListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockCountListPageListPrevious.Click += new System.EventHandler(this.buttonStockCountListPageListPrevious_Click);
            // 
            // buttonStockCountListPageListNext
            // 
            this.buttonStockCountListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCountListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockCountListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCountListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockCountListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockCountListPageListNext.Name = "buttonStockCountListPageListNext";
            this.buttonStockCountListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCountListPageListNext.TabIndex = 15;
            this.buttonStockCountListPageListNext.TabStop = false;
            this.buttonStockCountListPageListNext.Text = "Next";
            this.buttonStockCountListPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockCountListPageListNext.Click += new System.EventHandler(this.buttonStockCountListPageListNext_Click);
            // 
            // buttonStockCountListPageListLast
            // 
            this.buttonStockCountListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockCountListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockCountListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockCountListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockCountListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockCountListPageListLast.Name = "buttonStockCountListPageListLast";
            this.buttonStockCountListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockCountListPageListLast.TabIndex = 16;
            this.buttonStockCountListPageListLast.TabStop = false;
            this.buttonStockCountListPageListLast.Text = "Last";
            this.buttonStockCountListPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockCountListPageListLast.Click += new System.EventHandler(this.buttonStockCountListPageListLast_Click);
            // 
            // textBoxStockCountListPageNumber
            // 
            this.textBoxStockCountListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockCountListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockCountListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockCountListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockCountListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockCountListPageNumber.Name = "textBoxStockCountListPageNumber";
            this.textBoxStockCountListPageNumber.ReadOnly = true;
            this.textBoxStockCountListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockCountListPageNumber.TabIndex = 17;
            this.textBoxStockCountListPageNumber.TabStop = false;
            this.textBoxStockCountListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockCountListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockCountList);
            this.panel2.Controls.Add(this.textBoxStockCountListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 9;
            // 
            // dateTimePickerStockCountListFilter
            // 
            this.dateTimePickerStockCountListFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockCountListFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockCountListFilter.Name = "dateTimePickerStockCountListFilter";
            this.dateTimePickerStockCountListFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockCountListFilter.TabIndex = 0;
            this.dateTimePickerStockCountListFilter.TabStop = false;
            this.dateTimePickerStockCountListFilter.ValueChanged += new System.EventHandler(this.dateTimePickerStockCountListFilter_ValueChanged);
            // 
            // dataGridViewStockCountList
            // 
            this.dataGridViewStockCountList.AllowUserToAddRows = false;
            this.dataGridViewStockCountList.AllowUserToDeleteRows = false;
            this.dataGridViewStockCountList.AllowUserToResizeRows = false;
            this.dataGridViewStockCountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockCountList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockCountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockCountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockCountListButtonEdit,
            this.ColumnStockCountListButtonDelete,
            this.ColumnStockCountListId,
            this.ColumnStockCountListStockCountDate,
            this.ColumnStockCountListStockCountNumber,
            this.ColumnStockCountListRemarks,
            this.ColumnStockCountListIsLocked});
            this.dataGridViewStockCountList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockCountList.MultiSelect = false;
            this.dataGridViewStockCountList.Name = "dataGridViewStockCountList";
            this.dataGridViewStockCountList.ReadOnly = true;
            this.dataGridViewStockCountList.RowTemplate.Height = 24;
            this.dataGridViewStockCountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockCountList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockCountList.TabIndex = 20;
            this.dataGridViewStockCountList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockCountList_CellClick);
            // 
            // ColumnStockCountListButtonEdit
            // 
            this.ColumnStockCountListButtonEdit.DataPropertyName = "ColumnStockCountListButtonEdit";
            this.ColumnStockCountListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockCountListButtonEdit.HeaderText = "";
            this.ColumnStockCountListButtonEdit.Name = "ColumnStockCountListButtonEdit";
            this.ColumnStockCountListButtonEdit.ReadOnly = true;
            this.ColumnStockCountListButtonEdit.Width = 70;
            // 
            // ColumnStockCountListButtonDelete
            // 
            this.ColumnStockCountListButtonDelete.DataPropertyName = "ColumnStockCountListButtonDelete";
            this.ColumnStockCountListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockCountListButtonDelete.HeaderText = "";
            this.ColumnStockCountListButtonDelete.Name = "ColumnStockCountListButtonDelete";
            this.ColumnStockCountListButtonDelete.ReadOnly = true;
            this.ColumnStockCountListButtonDelete.Width = 70;
            // 
            // ColumnStockCountListId
            // 
            this.ColumnStockCountListId.DataPropertyName = "ColumnStockCountListId";
            this.ColumnStockCountListId.HeaderText = "Id";
            this.ColumnStockCountListId.Name = "ColumnStockCountListId";
            this.ColumnStockCountListId.ReadOnly = true;
            this.ColumnStockCountListId.Visible = false;
            // 
            // ColumnStockCountListStockCountDate
            // 
            this.ColumnStockCountListStockCountDate.DataPropertyName = "ColumnStockCountListStockCountDate";
            this.ColumnStockCountListStockCountDate.HeaderText = "Stock-Count Date";
            this.ColumnStockCountListStockCountDate.Name = "ColumnStockCountListStockCountDate";
            this.ColumnStockCountListStockCountDate.ReadOnly = true;
            this.ColumnStockCountListStockCountDate.Width = 95;
            // 
            // ColumnStockCountListStockCountNumber
            // 
            this.ColumnStockCountListStockCountNumber.DataPropertyName = "ColumnStockCountListStockCountNumber";
            this.ColumnStockCountListStockCountNumber.HeaderText = "Stock-Count No.";
            this.ColumnStockCountListStockCountNumber.Name = "ColumnStockCountListStockCountNumber";
            this.ColumnStockCountListStockCountNumber.ReadOnly = true;
            // 
            // ColumnStockCountListRemarks
            // 
            this.ColumnStockCountListRemarks.DataPropertyName = "ColumnStockCountListRemarks";
            this.ColumnStockCountListRemarks.HeaderText = "Remarks";
            this.ColumnStockCountListRemarks.Name = "ColumnStockCountListRemarks";
            this.ColumnStockCountListRemarks.ReadOnly = true;
            this.ColumnStockCountListRemarks.Width = 300;
            // 
            // ColumnStockCountListIsLocked
            // 
            this.ColumnStockCountListIsLocked.DataPropertyName = "ColumnStockCountListIsLocked";
            this.ColumnStockCountListIsLocked.HeaderText = "L";
            this.ColumnStockCountListIsLocked.Name = "ColumnStockCountListIsLocked";
            this.ColumnStockCountListIsLocked.ReadOnly = true;
            this.ColumnStockCountListIsLocked.Width = 35;
            // 
            // textBoxStockCountListFilter
            // 
            this.textBoxStockCountListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockCountListFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxStockCountListFilter.Name = "textBoxStockCountListFilter";
            this.textBoxStockCountListFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxStockCountListFilter.TabIndex = 1;
            this.textBoxStockCountListFilter.TabStop = false;
            this.textBoxStockCountListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockCountListFilter_KeyDown);
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
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Stock_Count;
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
            this.label1.Size = new System.Drawing.Size(207, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-Count List";
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
            // TrnStockCountListForm
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
            this.Name = "TrnStockCountListForm";
            this.Text = "TrnStockOutList";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockCountList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonStockCountListPageListFirst;
        private System.Windows.Forms.Button buttonStockCountListPageListPrevious;
        private System.Windows.Forms.Button buttonStockCountListPageListNext;
        private System.Windows.Forms.Button buttonStockCountListPageListLast;
        private System.Windows.Forms.TextBox textBoxStockCountListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockCountListFilter;
        private System.Windows.Forms.DataGridView dataGridViewStockCountList;
        private System.Windows.Forms.TextBox textBoxStockCountListFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockCountListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockCountListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCountListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCountListStockCountDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCountListStockCountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockCountListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockCountListIsLocked;
    }
}