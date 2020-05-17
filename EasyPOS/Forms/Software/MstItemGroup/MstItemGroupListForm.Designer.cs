namespace EasyPOS.Forms.Software.MstItemGroup
{
    partial class MstItemGroupListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MstItemGroupListForm));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonItemGroupListPageListFirst = new System.Windows.Forms.Button();
            this.buttonItemGroupListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonItemGroupListPageListNext = new System.Windows.Forms.Button();
            this.buttonItemGroupListPageListLast = new System.Windows.Forms.Button();
            this.textBoxItemGroupListPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewItemGroupList = new System.Windows.Forms.DataGridView();
            this.ColumnItemGroupListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemGroupListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnItemGroupListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemGroupListItemGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnItemGroupListIsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxItemGroupListFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemGroupList)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(199, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Group List";
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
            this.panel2.Controls.Add(this.dataGridViewItemGroupList);
            this.panel2.Controls.Add(this.textBoxItemGroupListFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1400, 637);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonItemGroupListPageListFirst);
            this.panel3.Controls.Add(this.buttonItemGroupListPageListPrevious);
            this.panel3.Controls.Add(this.buttonItemGroupListPageListNext);
            this.panel3.Controls.Add(this.buttonItemGroupListPageListLast);
            this.panel3.Controls.Add(this.textBoxItemGroupListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 584);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1400, 53);
            this.panel3.TabIndex = 18;
            // 
            // buttonItemGroupListPageListFirst
            // 
            this.buttonItemGroupListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemGroupListPageListFirst.Enabled = false;
            this.buttonItemGroupListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonItemGroupListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemGroupListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemGroupListPageListFirst.Location = new System.Drawing.Point(12, 11);
            this.buttonItemGroupListPageListFirst.Name = "buttonItemGroupListPageListFirst";
            this.buttonItemGroupListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonItemGroupListPageListFirst.TabIndex = 13;
            this.buttonItemGroupListPageListFirst.TabStop = false;
            this.buttonItemGroupListPageListFirst.Text = "First";
            this.buttonItemGroupListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonItemGroupListPageListFirst.Click += new System.EventHandler(this.buttonItemGroupListPageListFirst_Click);
            // 
            // buttonItemGroupListPageListPrevious
            // 
            this.buttonItemGroupListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemGroupListPageListPrevious.Enabled = false;
            this.buttonItemGroupListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonItemGroupListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemGroupListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemGroupListPageListPrevious.Location = new System.Drawing.Point(100, 11);
            this.buttonItemGroupListPageListPrevious.Name = "buttonItemGroupListPageListPrevious";
            this.buttonItemGroupListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonItemGroupListPageListPrevious.TabIndex = 14;
            this.buttonItemGroupListPageListPrevious.TabStop = false;
            this.buttonItemGroupListPageListPrevious.Text = "Previous";
            this.buttonItemGroupListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonItemGroupListPageListPrevious.Click += new System.EventHandler(this.buttonItemGroupListPageListPrevious_Click);
            // 
            // buttonItemGroupListPageListNext
            // 
            this.buttonItemGroupListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemGroupListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonItemGroupListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemGroupListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemGroupListPageListNext.Location = new System.Drawing.Point(263, 11);
            this.buttonItemGroupListPageListNext.Name = "buttonItemGroupListPageListNext";
            this.buttonItemGroupListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonItemGroupListPageListNext.TabIndex = 15;
            this.buttonItemGroupListPageListNext.TabStop = false;
            this.buttonItemGroupListPageListNext.Text = "Next";
            this.buttonItemGroupListPageListNext.UseVisualStyleBackColor = false;
            this.buttonItemGroupListPageListNext.Click += new System.EventHandler(this.buttonItemGroupListPageListNext_Click);
            // 
            // buttonItemGroupListPageListLast
            // 
            this.buttonItemGroupListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonItemGroupListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonItemGroupListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItemGroupListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonItemGroupListPageListLast.Location = new System.Drawing.Point(348, 11);
            this.buttonItemGroupListPageListLast.Name = "buttonItemGroupListPageListLast";
            this.buttonItemGroupListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonItemGroupListPageListLast.TabIndex = 16;
            this.buttonItemGroupListPageListLast.TabStop = false;
            this.buttonItemGroupListPageListLast.Text = "Last";
            this.buttonItemGroupListPageListLast.UseVisualStyleBackColor = false;
            this.buttonItemGroupListPageListLast.Click += new System.EventHandler(this.buttonItemGroupListPageListLast_Click);
            // 
            // textBoxItemGroupListPageNumber
            // 
            this.textBoxItemGroupListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxItemGroupListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxItemGroupListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemGroupListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxItemGroupListPageNumber.Location = new System.Drawing.Point(188, 16);
            this.textBoxItemGroupListPageNumber.Name = "textBoxItemGroupListPageNumber";
            this.textBoxItemGroupListPageNumber.ReadOnly = true;
            this.textBoxItemGroupListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxItemGroupListPageNumber.TabIndex = 17;
            this.textBoxItemGroupListPageNumber.TabStop = false;
            this.textBoxItemGroupListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewItemGroupList
            // 
            this.dataGridViewItemGroupList.AllowUserToAddRows = false;
            this.dataGridViewItemGroupList.AllowUserToDeleteRows = false;
            this.dataGridViewItemGroupList.AllowUserToResizeRows = false;
            this.dataGridViewItemGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewItemGroupList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewItemGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnItemGroupListButtonEdit,
            this.ColumnItemGroupListButtonDelete,
            this.ColumnItemGroupListId,
            this.ColumnItemGroupListItemGroup,
            this.ColumnItemGroupListIsLocked});
            this.dataGridViewItemGroupList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewItemGroupList.MultiSelect = false;
            this.dataGridViewItemGroupList.Name = "dataGridViewItemGroupList";
            this.dataGridViewItemGroupList.ReadOnly = true;
            this.dataGridViewItemGroupList.RowTemplate.Height = 24;
            this.dataGridViewItemGroupList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewItemGroupList.Size = new System.Drawing.Size(1376, 536);
            this.dataGridViewItemGroupList.TabIndex = 9;
            this.dataGridViewItemGroupList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemGroupList_CellClick);
            // 
            // ColumnItemGroupListButtonEdit
            // 
            this.ColumnItemGroupListButtonEdit.DataPropertyName = "ColumnItemGroupListButtonEdit";
            this.ColumnItemGroupListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemGroupListButtonEdit.HeaderText = "";
            this.ColumnItemGroupListButtonEdit.Name = "ColumnItemGroupListButtonEdit";
            this.ColumnItemGroupListButtonEdit.ReadOnly = true;
            this.ColumnItemGroupListButtonEdit.Width = 70;
            // 
            // ColumnItemGroupListButtonDelete
            // 
            this.ColumnItemGroupListButtonDelete.DataPropertyName = "ColumnItemGroupListButtonDelete";
            this.ColumnItemGroupListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnItemGroupListButtonDelete.HeaderText = "";
            this.ColumnItemGroupListButtonDelete.Name = "ColumnItemGroupListButtonDelete";
            this.ColumnItemGroupListButtonDelete.ReadOnly = true;
            this.ColumnItemGroupListButtonDelete.Width = 70;
            // 
            // ColumnItemGroupListId
            // 
            this.ColumnItemGroupListId.DataPropertyName = "ColumnItemGroupListId";
            this.ColumnItemGroupListId.HeaderText = "Id";
            this.ColumnItemGroupListId.Name = "ColumnItemGroupListId";
            this.ColumnItemGroupListId.ReadOnly = true;
            this.ColumnItemGroupListId.Visible = false;
            // 
            // ColumnItemGroupListItemGroup
            // 
            this.ColumnItemGroupListItemGroup.DataPropertyName = "ColumnItemGroupListItemGroup";
            this.ColumnItemGroupListItemGroup.HeaderText = "Item Group";
            this.ColumnItemGroupListItemGroup.Name = "ColumnItemGroupListItemGroup";
            this.ColumnItemGroupListItemGroup.ReadOnly = true;
            this.ColumnItemGroupListItemGroup.Width = 250;
            // 
            // ColumnItemGroupListIsLocked
            // 
            this.ColumnItemGroupListIsLocked.DataPropertyName = "ColumnItemGroupListIsLocked";
            this.ColumnItemGroupListIsLocked.HeaderText = "L";
            this.ColumnItemGroupListIsLocked.Name = "ColumnItemGroupListIsLocked";
            this.ColumnItemGroupListIsLocked.ReadOnly = true;
            this.ColumnItemGroupListIsLocked.Width = 35;
            // 
            // textBoxItemGroupListFilter
            // 
            this.textBoxItemGroupListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemGroupListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxItemGroupListFilter.Name = "textBoxItemGroupListFilter";
            this.textBoxItemGroupListFilter.Size = new System.Drawing.Size(1376, 30);
            this.textBoxItemGroupListFilter.TabIndex = 8;
            this.textBoxItemGroupListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemGroupListFilter_KeyDown);
            // 
            // MstItemGroupListForm
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
            this.Name = "MstItemGroupListForm";
            this.Text = "ItemGroup List";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemGroupList)).EndInit();
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
        private System.Windows.Forms.Button buttonItemGroupListPageListFirst;
        private System.Windows.Forms.Button buttonItemGroupListPageListPrevious;
        private System.Windows.Forms.Button buttonItemGroupListPageListNext;
        private System.Windows.Forms.Button buttonItemGroupListPageListLast;
        private System.Windows.Forms.TextBox textBoxItemGroupListPageNumber;
        private System.Windows.Forms.DataGridView dataGridViewItemGroupList;
        private System.Windows.Forms.TextBox textBoxItemGroupListFilter;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemGroupListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnItemGroupListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemGroupListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnItemGroupListItemGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnItemGroupListIsLocked;
    }
}