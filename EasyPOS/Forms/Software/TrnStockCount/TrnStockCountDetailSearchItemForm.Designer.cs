namespace EasyPOS.Forms.Software.TrnStockCount
{
    partial class TrnStockCountDetailSearchItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockCountDetailSearchItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridViewSearchItemList = new System.Windows.Forms.DataGridView();
            this.ColumnSearchItemListId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListGenericName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListOutTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListOutTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListOutTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListOnhandQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemListButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxSearchItemListFilter = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSearchItemListPageListFirst = new System.Windows.Forms.Button();
            this.buttonSearchItemListPageListPrevious = new System.Windows.Forms.Button();
            this.buttonSearchItemListPageListNext = new System.Windows.Forms.Button();
            this.buttonSearchItemListPageListLast = new System.Windows.Forms.Button();
            this.textBoxSearchItemListPageNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItemList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(982, 63);
            this.panel1.TabIndex = 9;
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
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Item";
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
            this.buttonClose.Location = new System.Drawing.Point(882, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridViewSearchItemList
            // 
            this.dataGridViewSearchItemList.AllowUserToAddRows = false;
            this.dataGridViewSearchItemList.AllowUserToDeleteRows = false;
            this.dataGridViewSearchItemList.AllowUserToResizeRows = false;
            this.dataGridViewSearchItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSearchItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSearchItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchItemListId,
            this.ColumnSearchItemListBarCode,
            this.ColumnSearchItemListDescription,
            this.ColumnSearchItemListGenericName,
            this.ColumnSearchItemListOutTaxId,
            this.ColumnSearchItemListOutTax,
            this.ColumnSearchItemListOutTaxRate,
            this.ColumnSearchItemListUnitId,
            this.ColumnSearchItemListUnit,
            this.ColumnSearchItemListPrice,
            this.ColumnSearchItemListOnhandQuantity,
            this.ColumnSearchItemListButtonPick});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSearchItemList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSearchItemList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSearchItemList.MultiSelect = false;
            this.dataGridViewSearchItemList.Name = "dataGridViewSearchItemList";
            this.dataGridViewSearchItemList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSearchItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewSearchItemList.RowHeadersVisible = false;
            this.dataGridViewSearchItemList.RowTemplate.Height = 24;
            this.dataGridViewSearchItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchItemList.Size = new System.Drawing.Size(958, 439);
            this.dataGridViewSearchItemList.TabIndex = 6;
            this.dataGridViewSearchItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchItemList_CellClick);
            // 
            // ColumnSearchItemListId
            // 
            this.ColumnSearchItemListId.DataPropertyName = "ColumnSearchItemListId";
            this.ColumnSearchItemListId.HeaderText = "Id";
            this.ColumnSearchItemListId.Name = "ColumnSearchItemListId";
            this.ColumnSearchItemListId.ReadOnly = true;
            this.ColumnSearchItemListId.Visible = false;
            // 
            // ColumnSearchItemListBarCode
            // 
            this.ColumnSearchItemListBarCode.DataPropertyName = "ColumnSearchItemListBarCode";
            this.ColumnSearchItemListBarCode.HeaderText = "Barcode";
            this.ColumnSearchItemListBarCode.Name = "ColumnSearchItemListBarCode";
            this.ColumnSearchItemListBarCode.ReadOnly = true;
            this.ColumnSearchItemListBarCode.Width = 150;
            // 
            // ColumnSearchItemListDescription
            // 
            this.ColumnSearchItemListDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchItemListDescription.DataPropertyName = "ColumnSearchItemListDescription";
            this.ColumnSearchItemListDescription.HeaderText = "Item Description";
            this.ColumnSearchItemListDescription.Name = "ColumnSearchItemListDescription";
            this.ColumnSearchItemListDescription.ReadOnly = true;
            // 
            // ColumnSearchItemListGenericName
            // 
            this.ColumnSearchItemListGenericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchItemListGenericName.DataPropertyName = "ColumnSearchItemListGenericName";
            this.ColumnSearchItemListGenericName.HeaderText = "Generic Name";
            this.ColumnSearchItemListGenericName.Name = "ColumnSearchItemListGenericName";
            this.ColumnSearchItemListGenericName.ReadOnly = true;
            // 
            // ColumnSearchItemListOutTaxId
            // 
            this.ColumnSearchItemListOutTaxId.DataPropertyName = "ColumnSearchItemListOutTaxId";
            this.ColumnSearchItemListOutTaxId.HeaderText = "OutTaxId";
            this.ColumnSearchItemListOutTaxId.Name = "ColumnSearchItemListOutTaxId";
            this.ColumnSearchItemListOutTaxId.ReadOnly = true;
            this.ColumnSearchItemListOutTaxId.Visible = false;
            // 
            // ColumnSearchItemListOutTax
            // 
            this.ColumnSearchItemListOutTax.DataPropertyName = "ColumnSearchItemListOutTax";
            this.ColumnSearchItemListOutTax.HeaderText = "OutTax";
            this.ColumnSearchItemListOutTax.Name = "ColumnSearchItemListOutTax";
            this.ColumnSearchItemListOutTax.ReadOnly = true;
            this.ColumnSearchItemListOutTax.Visible = false;
            // 
            // ColumnSearchItemListOutTaxRate
            // 
            this.ColumnSearchItemListOutTaxRate.DataPropertyName = "ColumnSearchItemListOutTaxRate";
            this.ColumnSearchItemListOutTaxRate.HeaderText = "OutTaxRate";
            this.ColumnSearchItemListOutTaxRate.Name = "ColumnSearchItemListOutTaxRate";
            this.ColumnSearchItemListOutTaxRate.ReadOnly = true;
            this.ColumnSearchItemListOutTaxRate.Visible = false;
            // 
            // ColumnSearchItemListUnitId
            // 
            this.ColumnSearchItemListUnitId.DataPropertyName = "ColumnSearchItemListUnitId";
            this.ColumnSearchItemListUnitId.HeaderText = "UnitId";
            this.ColumnSearchItemListUnitId.Name = "ColumnSearchItemListUnitId";
            this.ColumnSearchItemListUnitId.ReadOnly = true;
            this.ColumnSearchItemListUnitId.Visible = false;
            // 
            // ColumnSearchItemListUnit
            // 
            this.ColumnSearchItemListUnit.DataPropertyName = "ColumnSearchItemListUnit";
            this.ColumnSearchItemListUnit.HeaderText = "Unit";
            this.ColumnSearchItemListUnit.Name = "ColumnSearchItemListUnit";
            this.ColumnSearchItemListUnit.ReadOnly = true;
            this.ColumnSearchItemListUnit.Visible = false;
            // 
            // ColumnSearchItemListPrice
            // 
            this.ColumnSearchItemListPrice.DataPropertyName = "ColumnSearchItemListPrice";
            this.ColumnSearchItemListPrice.HeaderText = "Price";
            this.ColumnSearchItemListPrice.Name = "ColumnSearchItemListPrice";
            this.ColumnSearchItemListPrice.ReadOnly = true;
            this.ColumnSearchItemListPrice.Visible = false;
            // 
            // ColumnSearchItemListOnhandQuantity
            // 
            this.ColumnSearchItemListOnhandQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnSearchItemListOnhandQuantity.DataPropertyName = "ColumnSearchItemListOnhandQuantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchItemListOnhandQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSearchItemListOnhandQuantity.HeaderText = "On Hand Qty.";
            this.ColumnSearchItemListOnhandQuantity.Name = "ColumnSearchItemListOnhandQuantity";
            this.ColumnSearchItemListOnhandQuantity.ReadOnly = true;
            this.ColumnSearchItemListOnhandQuantity.Width = 144;
            // 
            // ColumnSearchItemListButtonPick
            // 
            this.ColumnSearchItemListButtonPick.DataPropertyName = "ColumnSearchItemListButtonPick";
            this.ColumnSearchItemListButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchItemListButtonPick.HeaderText = "Pick";
            this.ColumnSearchItemListButtonPick.Name = "ColumnSearchItemListButtonPick";
            this.ColumnSearchItemListButtonPick.ReadOnly = true;
            this.ColumnSearchItemListButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchItemListButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchItemListButtonPick.Width = 70;
            // 
            // textBoxSearchItemListFilter
            // 
            this.textBoxSearchItemListFilter.AcceptsTab = true;
            this.textBoxSearchItemListFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchItemListFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxSearchItemListFilter.HideSelection = false;
            this.textBoxSearchItemListFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxSearchItemListFilter.Name = "textBoxSearchItemListFilter";
            this.textBoxSearchItemListFilter.Size = new System.Drawing.Size(958, 30);
            this.textBoxSearchItemListFilter.TabIndex = 0;
            this.textBoxSearchItemListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchItemListFilter_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonSearchItemListPageListFirst);
            this.panel3.Controls.Add(this.buttonSearchItemListPageListPrevious);
            this.panel3.Controls.Add(this.buttonSearchItemListPageListNext);
            this.panel3.Controls.Add(this.buttonSearchItemListPageListLast);
            this.panel3.Controls.Add(this.textBoxSearchItemListPageNumber);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 487);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 53);
            this.panel3.TabIndex = 19;
            // 
            // buttonSearchItemListPageListFirst
            // 
            this.buttonSearchItemListPageListFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemListPageListFirst.Enabled = false;
            this.buttonSearchItemListPageListFirst.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemListPageListFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemListPageListFirst.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemListPageListFirst.Location = new System.Drawing.Point(12, 9);
            this.buttonSearchItemListPageListFirst.Name = "buttonSearchItemListPageListFirst";
            this.buttonSearchItemListPageListFirst.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemListPageListFirst.TabIndex = 13;
            this.buttonSearchItemListPageListFirst.Text = "First";
            this.buttonSearchItemListPageListFirst.UseVisualStyleBackColor = false;
            this.buttonSearchItemListPageListFirst.Click += new System.EventHandler(this.buttonSearchItemListPageListFirst_Click);
            // 
            // buttonSearchItemListPageListPrevious
            // 
            this.buttonSearchItemListPageListPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemListPageListPrevious.Enabled = false;
            this.buttonSearchItemListPageListPrevious.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemListPageListPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemListPageListPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemListPageListPrevious.Location = new System.Drawing.Point(100, 9);
            this.buttonSearchItemListPageListPrevious.Name = "buttonSearchItemListPageListPrevious";
            this.buttonSearchItemListPageListPrevious.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemListPageListPrevious.TabIndex = 14;
            this.buttonSearchItemListPageListPrevious.Text = "Previous";
            this.buttonSearchItemListPageListPrevious.UseVisualStyleBackColor = false;
            this.buttonSearchItemListPageListPrevious.Click += new System.EventHandler(this.buttonSearchItemListPageListPrevious_Click);
            // 
            // buttonSearchItemListPageListNext
            // 
            this.buttonSearchItemListPageListNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemListPageListNext.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemListPageListNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemListPageListNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemListPageListNext.Location = new System.Drawing.Point(263, 9);
            this.buttonSearchItemListPageListNext.Name = "buttonSearchItemListPageListNext";
            this.buttonSearchItemListPageListNext.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemListPageListNext.TabIndex = 15;
            this.buttonSearchItemListPageListNext.Text = "Next";
            this.buttonSearchItemListPageListNext.UseVisualStyleBackColor = false;
            this.buttonSearchItemListPageListNext.Click += new System.EventHandler(this.buttonSearchItemListPageListNext_Click);
            // 
            // buttonSearchItemListPageListLast
            // 
            this.buttonSearchItemListPageListLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSearchItemListPageListLast.FlatAppearance.BorderSize = 0;
            this.buttonSearchItemListPageListLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchItemListPageListLast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSearchItemListPageListLast.Location = new System.Drawing.Point(348, 9);
            this.buttonSearchItemListPageListLast.Name = "buttonSearchItemListPageListLast";
            this.buttonSearchItemListPageListLast.Size = new System.Drawing.Size(82, 32);
            this.buttonSearchItemListPageListLast.TabIndex = 16;
            this.buttonSearchItemListPageListLast.Text = "Last";
            this.buttonSearchItemListPageListLast.UseVisualStyleBackColor = false;
            this.buttonSearchItemListPageListLast.Click += new System.EventHandler(this.buttonSearchItemListPageListLast_Click);
            // 
            // textBoxSearchItemListPageNumber
            // 
            this.textBoxSearchItemListPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSearchItemListPageNumber.BackColor = System.Drawing.Color.White;
            this.textBoxSearchItemListPageNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchItemListPageNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxSearchItemListPageNumber.Location = new System.Drawing.Point(188, 14);
            this.textBoxSearchItemListPageNumber.Name = "textBoxSearchItemListPageNumber";
            this.textBoxSearchItemListPageNumber.ReadOnly = true;
            this.textBoxSearchItemListPageNumber.Size = new System.Drawing.Size(69, 20);
            this.textBoxSearchItemListPageNumber.TabIndex = 17;
            this.textBoxSearchItemListPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.textBoxSearchItemListFilter);
            this.panel2.Controls.Add(this.dataGridViewSearchItemList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 540);
            this.panel2.TabIndex = 10;
            // 
            // TrnStockCountDetailSearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrnStockCountDetailSearchItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Item";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItemList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridViewSearchItemList;
        private System.Windows.Forms.TextBox textBoxSearchItemListFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSearchItemListPageListFirst;
        private System.Windows.Forms.Button buttonSearchItemListPageListPrevious;
        private System.Windows.Forms.Button buttonSearchItemListPageListNext;
        private System.Windows.Forms.Button buttonSearchItemListPageListLast;
        private System.Windows.Forms.TextBox textBoxSearchItemListPageNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListGenericName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListOutTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListOutTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListOutTaxRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemListOnhandQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchItemListButtonPick;
    }
}