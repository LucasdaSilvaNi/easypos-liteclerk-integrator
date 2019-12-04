namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnSalesDetailSalesItemDetailItemPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesDetailSalesItemDetailItemPriceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.buttonAccountListPageListFirst = new System.Windows.Forms.Button();
            this.buttonAccountListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonAccountListPageListNext = new System.Windows.Forms.Button();
            this.buttonAccountListPageListLast = new System.Windows.Forms.Button();
            this.textBoxAccountListPageNumber = new System.Windows.Forms.TextBox();
            this.dataGridViewAccountList = new System.Windows.Forms.DataGridView();
            this.ColumnAccountListButtonEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnAccountListButtonDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnAccountListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountListCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountListAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountListAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxItemDescription = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).BeginInit();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 63);
            this.panel1.TabIndex = 6;
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
            this.label1.Size = new System.Drawing.Size(183, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Price List";
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
            this.buttonClose.Location = new System.Drawing.Point(535, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel15);
            this.panel2.Controls.Add(this.dataGridViewAccountList);
            this.panel2.Controls.Add(this.textBoxItemDescription);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 319);
            this.panel2.TabIndex = 7;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.Controls.Add(this.buttonAccountListPageListFirst);
            this.panel15.Controls.Add(this.buttonAccountListPageListPrevious);
            this.panel15.Controls.Add(this.buttonAccountListPageListNext);
            this.panel15.Controls.Add(this.buttonAccountListPageListLast);
            this.panel15.Controls.Add(this.textBoxAccountListPageNumber);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(0, 266);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(635, 53);
            this.panel15.TabIndex = 26;
            // 
            // buttonAccountListPageListFirst
            // 
            this.buttonAccountListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccountListPageListFirst.Enabled = false;
            this.buttonAccountListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonAccountListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccountListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonAccountListPageListFirst.Name = "buttonAccountListPageListFirst";
            this.buttonAccountListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonAccountListPageListFirst.TabIndex = 13;
            this.buttonAccountListPageListFirst.Text = "First";
            this.buttonAccountListPageListFirst.UseVisualStyleBackColor = false;
            // 
            // buttonAccountListPageListPrevious
            // 
            this.buttonAccountListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccountListPageListPrevious.Enabled = false;
            this.buttonAccountListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonAccountListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccountListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonAccountListPageListPrevious.Name = "buttonAccountListPageListPrevious";
            this.buttonAccountListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonAccountListPageListPrevious.TabIndex = 14;
            this.buttonAccountListPageListPrevious.Text = "Previous";
            this.buttonAccountListPageListPrevious.UseVisualStyleBackColor = false;
            // 
            // buttonAccountListPageListNext
            // 
            this.buttonAccountListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccountListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonAccountListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccountListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonAccountListPageListNext.Name = "buttonAccountListPageListNext";
            this.buttonAccountListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonAccountListPageListNext.TabIndex = 15;
            this.buttonAccountListPageListNext.Text = "Next";
            this.buttonAccountListPageListNext.UseVisualStyleBackColor = false;
            // 
            // buttonAccountListPageListLast
            // 
            this.buttonAccountListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAccountListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonAccountListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccountListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAccountListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonAccountListPageListLast.Name = "buttonAccountListPageListLast";
            this.buttonAccountListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonAccountListPageListLast.TabIndex = 16;
            this.buttonAccountListPageListLast.Text = "Last";
            this.buttonAccountListPageListLast.UseVisualStyleBackColor = false;
            // 
            // textBoxAccountListPageNumber
            // 
            this.textBoxAccountListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxAccountListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxAccountListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAccountListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxAccountListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxAccountListPageNumber.Name = "textBoxAccountListPageNumber";
            this.textBoxAccountListPageNumber.ReadOnly = true;
            this.textBoxAccountListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxAccountListPageNumber.TabIndex = 17;
            this.textBoxAccountListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridViewAccountList
            // 
            this.dataGridViewAccountList.AllowUserToAddRows = false;
            this.dataGridViewAccountList.AllowUserToDeleteRows = false;
            this.dataGridViewAccountList.AllowUserToResizeRows = false;
            this.dataGridViewAccountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAccountList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAccountListButtonEdit,
            this.ColumnAccountListButtonDelete,
            this.ColumnAccountListId,
            this.ColumnAccountListCode,
            this.ColumnAccountListAccount,
            this.ColumnAccountListAccountType});
            this.dataGridViewAccountList.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewAccountList.MultiSelect = false;
            this.dataGridViewAccountList.Name = "dataGridViewAccountList";
            this.dataGridViewAccountList.ReadOnly = true;
            this.dataGridViewAccountList.RowHeadersVisible = false;
            this.dataGridViewAccountList.RowTemplate.Height = 24;
            this.dataGridViewAccountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAccountList.Size = new System.Drawing.Size(611, 216);
            this.dataGridViewAccountList.TabIndex = 25;
            // 
            // ColumnAccountListButtonEdit
            // 
            this.ColumnAccountListButtonEdit.DataPropertyName = "ColumnAccountListButtonEdit";
            this.ColumnAccountListButtonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnAccountListButtonEdit.HeaderText = "";
            this.ColumnAccountListButtonEdit.Name = "ColumnAccountListButtonEdit";
            this.ColumnAccountListButtonEdit.ReadOnly = true;
            this.ColumnAccountListButtonEdit.Width = 70;
            // 
            // ColumnAccountListButtonDelete
            // 
            this.ColumnAccountListButtonDelete.DataPropertyName = "ColumnAccountListButtonDelete";
            this.ColumnAccountListButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnAccountListButtonDelete.HeaderText = "";
            this.ColumnAccountListButtonDelete.Name = "ColumnAccountListButtonDelete";
            this.ColumnAccountListButtonDelete.ReadOnly = true;
            this.ColumnAccountListButtonDelete.Width = 70;
            // 
            // ColumnAccountListId
            // 
            this.ColumnAccountListId.DataPropertyName = "ColumnAccountListId";
            this.ColumnAccountListId.HeaderText = "Id";
            this.ColumnAccountListId.Name = "ColumnAccountListId";
            this.ColumnAccountListId.ReadOnly = true;
            this.ColumnAccountListId.Visible = false;
            // 
            // ColumnAccountListCode
            // 
            this.ColumnAccountListCode.DataPropertyName = "ColumnAccountListCode";
            this.ColumnAccountListCode.HeaderText = "Code";
            this.ColumnAccountListCode.Name = "ColumnAccountListCode";
            this.ColumnAccountListCode.ReadOnly = true;
            this.ColumnAccountListCode.Width = 150;
            // 
            // ColumnAccountListAccount
            // 
            this.ColumnAccountListAccount.DataPropertyName = "ColumnAccountListAccount";
            this.ColumnAccountListAccount.HeaderText = "Account";
            this.ColumnAccountListAccount.Name = "ColumnAccountListAccount";
            this.ColumnAccountListAccount.ReadOnly = true;
            this.ColumnAccountListAccount.Width = 250;
            // 
            // ColumnAccountListAccountType
            // 
            this.ColumnAccountListAccountType.DataPropertyName = "ColumnAccountListAccountType";
            this.ColumnAccountListAccountType.HeaderText = "Type";
            this.ColumnAccountListAccountType.Name = "ColumnAccountListAccountType";
            this.ColumnAccountListAccountType.ReadOnly = true;
            this.ColumnAccountListAccountType.Width = 200;
            // 
            // textBoxItemDescription
            // 
            this.textBoxItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItemDescription.BackColor = System.Drawing.Color.White;
            this.textBoxItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxItemDescription.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxItemDescription.Location = new System.Drawing.Point(12, 6);
            this.textBoxItemDescription.Name = "textBoxItemDescription";
            this.textBoxItemDescription.ReadOnly = true;
            this.textBoxItemDescription.Size = new System.Drawing.Size(611, 32);
            this.textBoxItemDescription.TabIndex = 7;
            this.textBoxItemDescription.TabStop = false;
            this.textBoxItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrnSalesDetailSalesItemDetailItemPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(635, 382);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrnSalesDetailSalesItemDetailItemPriceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Price";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccountList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxItemDescription;
        private System.Windows.Forms.DataGridView dataGridViewAccountList;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAccountListButtonEdit;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAccountListButtonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountListCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountListAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountListAccountType;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button buttonAccountListPageListFirst;
        private System.Windows.Forms.Button buttonAccountListPageListPrevious;
        private System.Windows.Forms.Button buttonAccountListPageListNext;
        private System.Windows.Forms.Button buttonAccountListPageListLast;
        private System.Windows.Forms.TextBox textBoxAccountListPageNumber;
    }
}