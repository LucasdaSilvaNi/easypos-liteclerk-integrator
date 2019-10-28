namespace EasyPOS.Forms.Software.TrnStockOut
{
    partial class TrnStockOutListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockOutListForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonStockOutListPageListFirst = new System.Windows.Forms.Button();
            this.buttonStockOutListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonStockOutListPageListNext = new System.Windows.Forms.Button();
            this.buttonStockOutListPageListLast = new System.Windows.Forms.Button();
            this.textBoxStockOutListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerStockOutListFilter = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewStockOutList = new System.Windows.Forms.DataGridView();
            this.ColumnStockOutListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnStockOutListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutListStockOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutListStockOutNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutListRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStockOutListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxStockOutListFilter = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOutList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonStockOutListPageListFirst);
            this.panel3.Controls.Add(this.buttonStockOutListPageListPrevious);
            this.panel3.Controls.Add(this.buttonStockOutListPageListNext);
            this.panel3.Controls.Add(this.buttonStockOutListPageListLast);
            this.panel3.Controls.Add(this.textBoxStockOutListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 21;
            // 
            // buttonStockOutListPageListFirst
            // 
            this.buttonStockOutListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutListPageListFirst.Enabled = false;
            this.buttonStockOutListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonStockOutListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonStockOutListPageListFirst.Name = "buttonStockOutListPageListFirst";
            this.buttonStockOutListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutListPageListFirst.TabIndex = 13;
            this.buttonStockOutListPageListFirst.Text = "First";
            this.buttonStockOutListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonStockOutListPageListFirst.Click += new System.EventHandler(this.buttonStockOutListPageListFirst_Click);
            // 
            // buttonStockOutListPageListPrevious
            // 
            this.buttonStockOutListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutListPageListPrevious.Enabled = false;
            this.buttonStockOutListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonStockOutListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonStockOutListPageListPrevious.Name = "buttonStockOutListPageListPrevious";
            this.buttonStockOutListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutListPageListPrevious.TabIndex = 14;
            this.buttonStockOutListPageListPrevious.Text = "Previous";
            this.buttonStockOutListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonStockOutListPageListPrevious.Click += new System.EventHandler(this.buttonStockOutListPageListPrevious_Click);
            // 
            // buttonStockOutListPageListNext
            // 
            this.buttonStockOutListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonStockOutListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonStockOutListPageListNext.Name = "buttonStockOutListPageListNext";
            this.buttonStockOutListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutListPageListNext.TabIndex = 15;
            this.buttonStockOutListPageListNext.Text = "Next";
            this.buttonStockOutListPageListNext.UseVisualStyleBackColor = false;
            this.buttonStockOutListPageListNext.Click += new System.EventHandler(this.buttonStockOutListPageListNext_Click);
            // 
            // buttonStockOutListPageListLast
            // 
            this.buttonStockOutListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonStockOutListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonStockOutListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStockOutListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonStockOutListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonStockOutListPageListLast.Name = "buttonStockOutListPageListLast";
            this.buttonStockOutListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonStockOutListPageListLast.TabIndex = 16;
            this.buttonStockOutListPageListLast.Text = "Last";
            this.buttonStockOutListPageListLast.UseVisualStyleBackColor = false;
            this.buttonStockOutListPageListLast.Click += new System.EventHandler(this.buttonStockOutListPageListLast_Click);
            // 
            // textBoxStockOutListPageNumber
            // 
            this.textBoxStockOutListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStockOutListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxStockOutListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockOutListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStockOutListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxStockOutListPageNumber.Name = "textBoxStockOutListPageNumber";
            this.textBoxStockOutListPageNumber.ReadOnly = true;
            this.textBoxStockOutListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxStockOutListPageNumber.TabIndex = 17;
            this.textBoxStockOutListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePickerStockOutListFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewStockOutList);
            this.panel2.Controls.Add(this.textBoxStockOutListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 9;
            // 
            // dateTimePickerStockOutListFilter
            // 
            this.dateTimePickerStockOutListFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStockOutListFilter.Location = new System.Drawing.Point(12, 6);
            this.dateTimePickerStockOutListFilter.Name = "dateTimePickerStockOutListFilter";
            this.dateTimePickerStockOutListFilter.Size = new System.Drawing.Size(141, 30);
            this.dateTimePickerStockOutListFilter.TabIndex = 22;
            this.dateTimePickerStockOutListFilter.ValueChanged += new System.EventHandler(this.dateTimePickerStockOutListFilter_ValueChanged);
            // 
            // dataGridViewStockOutList
            // 
            this.dataGridViewStockOutList.AllowUserToAddRows = false;
            this.dataGridViewStockOutList.AllowUserToDeleteRows = false;
            this.dataGridViewStockOutList.AllowUserToResizeRows = false;
            this.dataGridViewStockOutList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockOutList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStockOutList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockOutList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStockOutListButtonEdit,
            this.ColumnStockOutListButtonDelete,
            this.ColumnStockOutListId,
            this.ColumnStockOutListStockOutDate,
            this.ColumnStockOutListStockOutNumber,
            this.ColumnStockOutListRemarks,
            this.ColumnStockOutListIsLocked});
            this.dataGridViewStockOutList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewStockOutList.MultiSelect = false;
            this.dataGridViewStockOutList.Name = "dataGridViewStockOutList";
            this.dataGridViewStockOutList.ReadOnly = true;
            this.dataGridViewStockOutList.RowHeadersVisible = false;
            this.dataGridViewStockOutList.RowTemplate.Height = 24;
            this.dataGridViewStockOutList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockOutList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewStockOutList.TabIndex = 20;
            this.dataGridViewStockOutList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStockOutList_CellClick);
            // 
            // ColumnStockOutListButtonEdit
            // 
            this.ColumnStockOutListButtonEdit.DataPropertyName = "ColumnStockOutListButtonEdit";
            this.ColumnStockOutListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockOutListButtonEdit.HeaderText = "";
            this.ColumnStockOutListButtonEdit.Name = "ColumnStockOutListButtonEdit";
            this.ColumnStockOutListButtonEdit.ReadOnly = true;
            this.ColumnStockOutListButtonEdit.Width = 70;
            // 
            // ColumnStockOutListButtonDelete
            // 
            this.ColumnStockOutListButtonDelete.DataPropertyName = "ColumnStockOutListButtonDelete";
            this.ColumnStockOutListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnStockOutListButtonDelete.HeaderText = "";
            this.ColumnStockOutListButtonDelete.Name = "ColumnStockOutListButtonDelete";
            this.ColumnStockOutListButtonDelete.ReadOnly = true;
            this.ColumnStockOutListButtonDelete.Width = 70;
            // 
            // ColumnStockOutListId
            // 
            this.ColumnStockOutListId.DataPropertyName = "ColumnStockOutListId";
            this.ColumnStockOutListId.HeaderText = "Id";
            this.ColumnStockOutListId.Name = "ColumnStockOutListId";
            this.ColumnStockOutListId.ReadOnly = true;
            this.ColumnStockOutListId.Visible = false;
            // 
            // ColumnStockOutListStockOutDate
            // 
            this.ColumnStockOutListStockOutDate.DataPropertyName = "ColumnStockOutListStockOutDate";
            this.ColumnStockOutListStockOutDate.HeaderText = "Stock-Out Date";
            this.ColumnStockOutListStockOutDate.Name = "ColumnStockOutListStockOutDate";
            this.ColumnStockOutListStockOutDate.ReadOnly = true;
            this.ColumnStockOutListStockOutDate.Width = 95;
            // 
            // ColumnStockOutListStockOutNumber
            // 
            this.ColumnStockOutListStockOutNumber.DataPropertyName = "ColumnStockOutListStockOutNumber";
            this.ColumnStockOutListStockOutNumber.HeaderText = "Stock-Out No.";
            this.ColumnStockOutListStockOutNumber.Name = "ColumnStockOutListStockOutNumber";
            this.ColumnStockOutListStockOutNumber.ReadOnly = true;
            // 
            // ColumnStockOutListRemarks
            // 
            this.ColumnStockOutListRemarks.DataPropertyName = "ColumnStockOutListRemarks";
            this.ColumnStockOutListRemarks.HeaderText = "Remarks";
            this.ColumnStockOutListRemarks.Name = "ColumnStockOutListRemarks";
            this.ColumnStockOutListRemarks.ReadOnly = true;
            this.ColumnStockOutListRemarks.Width = 300;
            // 
            // ColumnStockOutListIsLocked
            // 
            this.ColumnStockOutListIsLocked.DataPropertyName = "ColumnStockOutListIsLocked";
            this.ColumnStockOutListIsLocked.HeaderText = "L";
            this.ColumnStockOutListIsLocked.Name = "ColumnStockOutListIsLocked";
            this.ColumnStockOutListIsLocked.ReadOnly = true;
            this.ColumnStockOutListIsLocked.Width = 35;
            // 
            // textBoxStockOutListFilter
            // 
            this.textBoxStockOutListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockOutListFilter.Location = new System.Drawing.Point(159, 6);
            this.textBoxStockOutListFilter.Name = "textBoxStockOutListFilter";
            this.textBoxStockOutListFilter.Size = new System.Drawing.Size(1229, 30);
            this.textBoxStockOutListFilter.TabIndex = 19;
            this.textBoxStockOutListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxStockOutListFilter_KeyDown);
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
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Stock_Out;
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
            this.label1.Size = new System.Drawing.Size(180, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-Out List";
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
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // TrnStockOutListForm
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
            this.Name = "TrnStockOutListForm";
            this.Text = "TrnStockOutList";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockOutList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonStockOutListPageListFirst;
        private System.Windows.Forms.Button buttonStockOutListPageListPrevious;
        private System.Windows.Forms.Button buttonStockOutListPageListNext;
        private System.Windows.Forms.Button buttonStockOutListPageListLast;
        private System.Windows.Forms.TextBox textBoxStockOutListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStockOutListFilter;
        private System.Windows.Forms.DataGridView dataGridViewStockOutList;
        private System.Windows.Forms.TextBox textBoxStockOutListFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnStockOutListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutListStockOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutListStockOutNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStockOutListRemarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnStockOutListIsLocked;
    }
}