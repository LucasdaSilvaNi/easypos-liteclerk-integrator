namespace EasyPOS.Forms.Software.MstTableGroup
{
    partial class MstTableGroupListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstTableGroupListForm));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonTableGroupListPageListFirst = new System.Windows.Forms.Button();
            this.buttonTableGroupListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonTableGroupListPageListNext = new System.Windows.Forms.Button();
            this.buttonTableGroupListPageListLast = new System.Windows.Forms.Button();
            this.textBoxTableGroupListPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewTableGroupList = new System.Windows.Forms.DataGridView();
            this.ColumnTableGroupListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnTableGroupListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnTableGroupListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableGroupListTableGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTableGroupListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxTableGroupListFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableGroupList)).BeginInit();
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
            this.buttonAdd.Location = new System.Drawing.Point(1206, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 40);
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
            this.buttonClose.Location = new System.Drawing.Point(1300, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
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
            this.label1.Location = new System.Drawing.Point(63, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Table Group List";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 40);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1400, 63);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewTableGroupList);
            this.panel2.Controls.Add(this.textBoxTableGroupListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonTableGroupListPageListFirst);
            this.panel3.Controls.Add(this.buttonTableGroupListPageListPrevious);
            this.panel3.Controls.Add(this.buttonTableGroupListPageListNext);
            this.panel3.Controls.Add(this.buttonTableGroupListPageListLast);
            this.panel3.Controls.Add(this.textBoxTableGroupListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 18;
            // 
            // buttonTableGroupListPageListFirst
            // 
            this.buttonTableGroupListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTableGroupListPageListFirst.Enabled = false;
            this.buttonTableGroupListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonTableGroupListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTableGroupListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonTableGroupListPageListFirst.Location = new System.Drawing.Point(12, 11);
            this.buttonTableGroupListPageListFirst.Name = "buttonTableGroupListPageListFirst";
            this.buttonTableGroupListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonTableGroupListPageListFirst.TabIndex = 13;
            this.buttonTableGroupListPageListFirst.TabStop = false;
            this.buttonTableGroupListPageListFirst.Text = "First";
            this.buttonTableGroupListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonTableGroupListPageListFirst.Click += new System.EventHandler(this.buttonTableGroupListPageListFirst_Click);
            // 
            // buttonTableGroupListPageListPrevious
            // 
            this.buttonTableGroupListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTableGroupListPageListPrevious.Enabled = false;
            this.buttonTableGroupListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonTableGroupListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTableGroupListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonTableGroupListPageListPrevious.Location = new System.Drawing.Point(100, 11);
            this.buttonTableGroupListPageListPrevious.Name = "buttonTableGroupListPageListPrevious";
            this.buttonTableGroupListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonTableGroupListPageListPrevious.TabIndex = 14;
            this.buttonTableGroupListPageListPrevious.TabStop = false;
            this.buttonTableGroupListPageListPrevious.Text = "Previous";
            this.buttonTableGroupListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonTableGroupListPageListPrevious.Click += new System.EventHandler(this.buttonTableGroupListPageListPrevious_Click);
            // 
            // buttonTableGroupListPageListNext
            // 
            this.buttonTableGroupListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTableGroupListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonTableGroupListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTableGroupListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonTableGroupListPageListNext.Location = new System.Drawing.Point(263, 11);
            this.buttonTableGroupListPageListNext.Name = "buttonTableGroupListPageListNext";
            this.buttonTableGroupListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonTableGroupListPageListNext.TabIndex = 15;
            this.buttonTableGroupListPageListNext.TabStop = false;
            this.buttonTableGroupListPageListNext.Text = "Next";
            this.buttonTableGroupListPageListNext.UseVisualStyleBackColor = false;
            this.buttonTableGroupListPageListNext.Click += new System.EventHandler(this.buttonTableGroupListPageListNext_Click);
            // 
            // buttonTableGroupListPageListLast
            // 
            this.buttonTableGroupListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTableGroupListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonTableGroupListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTableGroupListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonTableGroupListPageListLast.Location = new System.Drawing.Point(348, 11);
            this.buttonTableGroupListPageListLast.Name = "buttonTableGroupListPageListLast";
            this.buttonTableGroupListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonTableGroupListPageListLast.TabIndex = 16;
            this.buttonTableGroupListPageListLast.TabStop = false;
            this.buttonTableGroupListPageListLast.Text = "Last";
            this.buttonTableGroupListPageListLast.UseVisualStyleBackColor = false;
            this.buttonTableGroupListPageListLast.Click += new System.EventHandler(this.buttonTableGroupListPageListLast_Click);
            // 
            // textBoxTableGroupListPageNumber
            // 
            this.textBoxTableGroupListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTableGroupListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxTableGroupListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTableGroupListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTableGroupListPageNumber.Location = new System.Drawing.Point(188, 16);
            this.textBoxTableGroupListPageNumber.Name = "textBoxTableGroupListPageNumber";
            this.textBoxTableGroupListPageNumber.ReadOnly = true;
            this.textBoxTableGroupListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxTableGroupListPageNumber.TabIndex = 17;
            this.textBoxTableGroupListPageNumber.TabStop = false;
            this.textBoxTableGroupListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewTableGroupList
            // 
            this.dataGridViewTableGroupList.AllowUserToAddRows = false;
            this.dataGridViewTableGroupList.AllowUserToDeleteRows = false;
            this.dataGridViewTableGroupList.AllowUserToResizeRows = false;
            this.dataGridViewTableGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTableGroupList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTableGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTableGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTableGroupListButtonEdit,
            this.ColumnTableGroupListButtonDelete,
            this.ColumnTableGroupListId,
            this.ColumnTableGroupListTableGroup,
            this.ColumnTableGroupListIsLocked});
            this.dataGridViewTableGroupList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewTableGroupList.MultiSelect = false;
            this.dataGridViewTableGroupList.Name = "dataGridViewTableGroupList";
            this.dataGridViewTableGroupList.ReadOnly = true;
            this.dataGridViewTableGroupList.RowTemplate.Height = 24;
            this.dataGridViewTableGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTableGroupList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewTableGroupList.TabIndex = 9;
            this.dataGridViewTableGroupList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTableGroupList_CellClick);
            // 
            // ColumnTableGroupListButtonEdit
            // 
            this.ColumnTableGroupListButtonEdit.DataPropertyName = "ColumnTableGroupListButtonEdit";
            this.ColumnTableGroupListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnTableGroupListButtonEdit.HeaderText = "";
            this.ColumnTableGroupListButtonEdit.Name = "ColumnTableGroupListButtonEdit";
            this.ColumnTableGroupListButtonEdit.ReadOnly = true;
            this.ColumnTableGroupListButtonEdit.Width = 70;
            // 
            // ColumnTableGroupListButtonDelete
            // 
            this.ColumnTableGroupListButtonDelete.DataPropertyName = "ColumnTableGroupListButtonDelete";
            this.ColumnTableGroupListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnTableGroupListButtonDelete.HeaderText = "";
            this.ColumnTableGroupListButtonDelete.Name = "ColumnTableGroupListButtonDelete";
            this.ColumnTableGroupListButtonDelete.ReadOnly = true;
            this.ColumnTableGroupListButtonDelete.Width = 70;
            // 
            // ColumnTableGroupListId
            // 
            this.ColumnTableGroupListId.DataPropertyName = "ColumnTableGroupListId";
            this.ColumnTableGroupListId.HeaderText = "Id";
            this.ColumnTableGroupListId.Name = "ColumnTableGroupListId";
            this.ColumnTableGroupListId.ReadOnly = true;
            this.ColumnTableGroupListId.Visible = false;
            // 
            // ColumnTableGroupListTableGroup
            // 
            this.ColumnTableGroupListTableGroup.DataPropertyName = "ColumnTableGroupListTableGroup";
            this.ColumnTableGroupListTableGroup.HeaderText = "Table Group";
            this.ColumnTableGroupListTableGroup.Name = "ColumnTableGroupListTableGroup";
            this.ColumnTableGroupListTableGroup.ReadOnly = true;
            this.ColumnTableGroupListTableGroup.Width = 250;
            // 
            // ColumnTableGroupListIsLocked
            // 
            this.ColumnTableGroupListIsLocked.DataPropertyName = "ColumnTableGroupListIsLocked";
            this.ColumnTableGroupListIsLocked.HeaderText = "L";
            this.ColumnTableGroupListIsLocked.Name = "ColumnTableGroupListIsLocked";
            this.ColumnTableGroupListIsLocked.ReadOnly = true;
            this.ColumnTableGroupListIsLocked.Width = 35;
            // 
            // textBoxTableGroupListFilter
            // 
            this.textBoxTableGroupListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTableGroupListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxTableGroupListFilter.Name = "textBoxTableGroupListFilter";
            this.textBoxTableGroupListFilter.Size = new System.Drawing.Size(1376, 30);
            this.textBoxTableGroupListFilter.TabIndex = 8;
            this.textBoxTableGroupListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTableGroupListFilter_KeyDown);
            // 
            // MstTableGroupListForm
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
            this.Name = "MstTableGroupListForm";
            this.Text = "TableGroup List";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTableGroupList)).EndInit();
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
        private System.Windows.Forms.Button buttonTableGroupListPageListFirst;
        private System.Windows.Forms.Button buttonTableGroupListPageListPrevious;
        private System.Windows.Forms.Button buttonTableGroupListPageListNext;
        private System.Windows.Forms.Button buttonTableGroupListPageListLast;
        private System.Windows.Forms.TextBox textBoxTableGroupListPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewTableGroupList;
        private System.Windows.Forms.TextBox textBoxTableGroupListFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTableGroupListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTableGroupListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableGroupListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTableGroupListTableGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnTableGroupListIsLocked;
    }
}