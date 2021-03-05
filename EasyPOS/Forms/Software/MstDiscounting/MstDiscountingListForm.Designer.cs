namespace EasyPOS.Forms.Software.MstDiscounting
{
    partial class MstDiscountingListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstDiscountingListForm));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonDiscountListPageListFirst = new System.Windows.Forms.Button();
            this.buttonDiscountListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonDiscountListPageListNext = new System.Windows.Forms.Button();
            this.buttonDiscountListPageListLast = new System.Windows.Forms.Button();
            this.textBoxDiscountListPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewDiscountList = new System.Windows.Forms.DataGridView();
            this.textBoxDiscountListFilter = new System.Windows.Forms.TextBox();
            this.ColumnDiscountListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDiscountListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDiscountListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscountListDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscountListDiscountRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiscountListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscountList)).BeginInit();
            this.SuspendLayout();
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
            this.buttonAdd.Location = new System.Drawing.Point(941, 10);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 32);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.TabStop = false;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Discounting List";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.Discounting;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1096, 50);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewDiscountList);
            this.panel2.Controls.Add(this.textBoxDiscountListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 510);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonDiscountListPageListFirst);
            this.panel3.Controls.Add(this.buttonDiscountListPageListPrevious);
            this.panel3.Controls.Add(this.buttonDiscountListPageListNext);
            this.panel3.Controls.Add(this.buttonDiscountListPageListLast);
            this.panel3.Controls.Add(this.textBoxDiscountListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 468);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1096, 42);
            this.panel3.TabIndex = 18;
            // 
            // buttonDiscountListPageListFirst
            // 
            this.buttonDiscountListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDiscountListPageListFirst.Enabled = false;
            this.buttonDiscountListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonDiscountListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscountListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDiscountListPageListFirst.Location = new System.Drawing.Point(10, 9);
            this.buttonDiscountListPageListFirst.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDiscountListPageListFirst.Name = "buttonDiscountListPageListFirst";
            this.buttonDiscountListPageListFirst.Size = new System.Drawing.Size(66, 26);
            this.buttonDiscountListPageListFirst.TabIndex = 13;
            this.buttonDiscountListPageListFirst.TabStop = false;
            this.buttonDiscountListPageListFirst.Text = "First";
            this.buttonDiscountListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonDiscountListPageListFirst.Click += new System.EventHandler(this.buttonDiscountListPageListFirst_Click);
            // 
            // buttonDiscountListPageListPrevious
            // 
            this.buttonDiscountListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDiscountListPageListPrevious.Enabled = false;
            this.buttonDiscountListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonDiscountListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscountListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDiscountListPageListPrevious.Location = new System.Drawing.Point(80, 9);
            this.buttonDiscountListPageListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDiscountListPageListPrevious.Name = "buttonDiscountListPageListPrevious";
            this.buttonDiscountListPageListPrevious.Size = new System.Drawing.Size(66, 26);
            this.buttonDiscountListPageListPrevious.TabIndex = 14;
            this.buttonDiscountListPageListPrevious.TabStop = false;
            this.buttonDiscountListPageListPrevious.Text = "Previous";
            this.buttonDiscountListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonDiscountListPageListPrevious.Click += new System.EventHandler(this.buttonDiscountListPageListPrevious_Click);
            // 
            // buttonDiscountListPageListNext
            // 
            this.buttonDiscountListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDiscountListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonDiscountListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscountListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDiscountListPageListNext.Location = new System.Drawing.Point(210, 9);
            this.buttonDiscountListPageListNext.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDiscountListPageListNext.Name = "buttonDiscountListPageListNext";
            this.buttonDiscountListPageListNext.Size = new System.Drawing.Size(66, 26);
            this.buttonDiscountListPageListNext.TabIndex = 15;
            this.buttonDiscountListPageListNext.TabStop = false;
            this.buttonDiscountListPageListNext.Text = "Next";
            this.buttonDiscountListPageListNext.UseVisualStyleBackColor = false;
            this.buttonDiscountListPageListNext.Click += new System.EventHandler(this.buttonDiscountListPageListNext_Click);
            // 
            // buttonDiscountListPageListLast
            // 
            this.buttonDiscountListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDiscountListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonDiscountListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscountListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonDiscountListPageListLast.Location = new System.Drawing.Point(278, 9);
            this.buttonDiscountListPageListLast.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDiscountListPageListLast.Name = "buttonDiscountListPageListLast";
            this.buttonDiscountListPageListLast.Size = new System.Drawing.Size(66, 26);
            this.buttonDiscountListPageListLast.TabIndex = 16;
            this.buttonDiscountListPageListLast.TabStop = false;
            this.buttonDiscountListPageListLast.Text = "Last";
            this.buttonDiscountListPageListLast.UseVisualStyleBackColor = false;
            this.buttonDiscountListPageListLast.Click += new System.EventHandler(this.buttonDiscountListPageListLast_Click);
            // 
            // textBoxDiscountListPageNumber
            // 
            this.textBoxDiscountListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxDiscountListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxDiscountListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDiscountListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDiscountListPageNumber.Location = new System.Drawing.Point(150, 13);
            this.textBoxDiscountListPageNumber.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiscountListPageNumber.Name = "textBoxDiscountListPageNumber";
            this.textBoxDiscountListPageNumber.ReadOnly = true;
            this.textBoxDiscountListPageNumber.Size = new System.Drawing.Size(55, 16);
            this.textBoxDiscountListPageNumber.TabIndex = 17;
            this.textBoxDiscountListPageNumber.TabStop = false;
            this.textBoxDiscountListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewDiscountList
            // 
            this.dataGridViewDiscountList.AllowUserToAddRows = false;
            this.dataGridViewDiscountList.AllowUserToDeleteRows = false;
            this.dataGridViewDiscountList.AllowUserToResizeRows = false;
            this.dataGridViewDiscountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDiscountList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDiscountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDiscountListButtonEdit,
            this.ColumnDiscountListButtonDelete,
            this.ColumnDiscountListId,
            this.ColumnDiscountListDiscount,
            this.ColumnDiscountListDiscountRate,
            this.ColumnDiscountListIsLocked});
            this.dataGridViewDiscountList.Location = new System.Drawing.Point(10, 34);
            this.dataGridViewDiscountList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewDiscountList.MultiSelect = false;
            this.dataGridViewDiscountList.Name = "dataGridViewDiscountList";
            this.dataGridViewDiscountList.ReadOnly = true;
            this.dataGridViewDiscountList.RowTemplate.Height = 24;
            this.dataGridViewDiscountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDiscountList.Size = new System.Drawing.Size(1077, 429);
            this.dataGridViewDiscountList.TabIndex = 9;
            this.dataGridViewDiscountList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDiscountList_CellClick);
            // 
            // textBoxDiscountListFilter
            // 
            this.textBoxDiscountListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDiscountListFilter.Location = new System.Drawing.Point(10, 5);
            this.textBoxDiscountListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDiscountListFilter.Name = "textBoxDiscountListFilter";
            this.textBoxDiscountListFilter.Size = new System.Drawing.Size(1078, 26);
            this.textBoxDiscountListFilter.TabIndex = 8;
            this.textBoxDiscountListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDiscountListFilter_KeyDown);
            // 
            // ColumnDiscountListButtonEdit
            // 
            this.ColumnDiscountListButtonEdit.DataPropertyName = "ColumnDiscountListButtonEdit";
            this.ColumnDiscountListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDiscountListButtonEdit.HeaderText = "";
            this.ColumnDiscountListButtonEdit.Name = "ColumnDiscountListButtonEdit";
            this.ColumnDiscountListButtonEdit.ReadOnly = true;
            this.ColumnDiscountListButtonEdit.Width = 70;
            // 
            // ColumnDiscountListButtonDelete
            // 
            this.ColumnDiscountListButtonDelete.DataPropertyName = "ColumnDiscountListButtonDelete";
            this.ColumnDiscountListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnDiscountListButtonDelete.HeaderText = "";
            this.ColumnDiscountListButtonDelete.Name = "ColumnDiscountListButtonDelete";
            this.ColumnDiscountListButtonDelete.ReadOnly = true;
            this.ColumnDiscountListButtonDelete.Width = 70;
            // 
            // ColumnDiscountListId
            // 
            this.ColumnDiscountListId.DataPropertyName = "ColumnDiscountListId";
            this.ColumnDiscountListId.HeaderText = "Id";
            this.ColumnDiscountListId.Name = "ColumnDiscountListId";
            this.ColumnDiscountListId.ReadOnly = true;
            this.ColumnDiscountListId.Visible = false;
            // 
            // ColumnDiscountListDiscount
            // 
            this.ColumnDiscountListDiscount.DataPropertyName = "ColumnDiscountListDiscount";
            this.ColumnDiscountListDiscount.HeaderText = "Discount";
            this.ColumnDiscountListDiscount.Name = "ColumnDiscountListDiscount";
            this.ColumnDiscountListDiscount.ReadOnly = true;
            this.ColumnDiscountListDiscount.Width = 250;
            // 
            // ColumnDiscountListDiscountRate
            // 
            this.ColumnDiscountListDiscountRate.DataPropertyName = "ColumnDiscountListDiscountRate";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnDiscountListDiscountRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnDiscountListDiscountRate.HeaderText = "Rate";
            this.ColumnDiscountListDiscountRate.Name = "ColumnDiscountListDiscountRate";
            this.ColumnDiscountListDiscountRate.ReadOnly = true;
            // 
            // ColumnDiscountListIsLocked
            // 
            this.ColumnDiscountListIsLocked.DataPropertyName = "ColumnDiscountListIsLocked";
            this.ColumnDiscountListIsLocked.HeaderText = "L";
            this.ColumnDiscountListIsLocked.Name = "ColumnDiscountListIsLocked";
            this.ColumnDiscountListIsLocked.ReadOnly = true;
            this.ColumnDiscountListIsLocked.Width = 35;
            // 
            // MstDiscountingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1096, 560);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MstDiscountingListForm";
            this.Text = "Discounting List";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscountList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonDiscountListPageListFirst;
        private System.Windows.Forms.Button buttonDiscountListPageListPrevious;
        private System.Windows.Forms.Button buttonDiscountListPageListNext;
        private System.Windows.Forms.Button buttonDiscountListPageListLast;
        private System.Windows.Forms.TextBox textBoxDiscountListPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewDiscountList;
        private System.Windows.Forms.TextBox textBoxDiscountListFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDiscountListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDiscountListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscountListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscountListDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiscountListDiscountRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnDiscountListIsLocked;
    }
}