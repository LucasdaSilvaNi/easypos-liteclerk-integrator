namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnSalesDetailSearchItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnSalesDetailSearchItemForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.dataGridViewSearchItemList = new System.Windows.Forms.DataGridView();
            this.ColumnSearchItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemGenericName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemOutTaxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemOutTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemOutTaxRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemOnHandQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSearchItemButtonPick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItemList)).BeginInit();
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
            this.panel1.TabIndex = 4;
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
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(12, 6);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(958, 30);
            this.textBoxFilter.TabIndex = 5;
            this.textBoxFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyDown);
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
            this.dataGridViewSearchItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearchItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSearchItemId,
            this.ColumnSearchItemBarcode,
            this.ColumnSearchItemDescription,
            this.ColumnSearchItemGenericName,
            this.ColumnSearchItemOutTaxId,
            this.ColumnSearchItemOutTax,
            this.ColumnSearchItemOutTaxRate,
            this.ColumnSearchItemUnitId,
            this.ColumnSearchItemUnit,
            this.ColumnSearchItemPrice,
            this.ColumnSearchItemOnHandQuantity,
            this.ColumnSearchItemButtonPick});
            this.dataGridViewSearchItemList.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewSearchItemList.MultiSelect = false;
            this.dataGridViewSearchItemList.Name = "dataGridViewSearchItemList";
            this.dataGridViewSearchItemList.ReadOnly = true;
            this.dataGridViewSearchItemList.RowHeadersVisible = false;
            this.dataGridViewSearchItemList.RowTemplate.Height = 24;
            this.dataGridViewSearchItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchItemList.Size = new System.Drawing.Size(958, 436);
            this.dataGridViewSearchItemList.TabIndex = 6;
            this.dataGridViewSearchItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchItemList_CellClick);
            // 
            // ColumnSearchItemId
            // 
            this.ColumnSearchItemId.HeaderText = "Id";
            this.ColumnSearchItemId.Name = "ColumnSearchItemId";
            this.ColumnSearchItemId.ReadOnly = true;
            this.ColumnSearchItemId.Visible = false;
            // 
            // ColumnSearchItemBarcode
            // 
            this.ColumnSearchItemBarcode.HeaderText = "Barcode";
            this.ColumnSearchItemBarcode.Name = "ColumnSearchItemBarcode";
            this.ColumnSearchItemBarcode.ReadOnly = true;
            this.ColumnSearchItemBarcode.Width = 150;
            // 
            // ColumnSearchItemDescription
            // 
            this.ColumnSearchItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchItemDescription.HeaderText = "Item Description";
            this.ColumnSearchItemDescription.Name = "ColumnSearchItemDescription";
            this.ColumnSearchItemDescription.ReadOnly = true;
            // 
            // ColumnSearchItemGenericName
            // 
            this.ColumnSearchItemGenericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSearchItemGenericName.HeaderText = "Generic Name";
            this.ColumnSearchItemGenericName.Name = "ColumnSearchItemGenericName";
            this.ColumnSearchItemGenericName.ReadOnly = true;
            // 
            // ColumnSearchItemOutTaxId
            // 
            this.ColumnSearchItemOutTaxId.HeaderText = "OutTaxId";
            this.ColumnSearchItemOutTaxId.Name = "ColumnSearchItemOutTaxId";
            this.ColumnSearchItemOutTaxId.ReadOnly = true;
            this.ColumnSearchItemOutTaxId.Visible = false;
            // 
            // ColumnSearchItemOutTax
            // 
            this.ColumnSearchItemOutTax.HeaderText = "OutTax";
            this.ColumnSearchItemOutTax.Name = "ColumnSearchItemOutTax";
            this.ColumnSearchItemOutTax.ReadOnly = true;
            this.ColumnSearchItemOutTax.Visible = false;
            // 
            // ColumnSearchItemOutTaxRate
            // 
            this.ColumnSearchItemOutTaxRate.HeaderText = "OutTaxRate";
            this.ColumnSearchItemOutTaxRate.Name = "ColumnSearchItemOutTaxRate";
            this.ColumnSearchItemOutTaxRate.ReadOnly = true;
            this.ColumnSearchItemOutTaxRate.Visible = false;
            // 
            // ColumnSearchItemUnitId
            // 
            this.ColumnSearchItemUnitId.HeaderText = "UnitId";
            this.ColumnSearchItemUnitId.Name = "ColumnSearchItemUnitId";
            this.ColumnSearchItemUnitId.ReadOnly = true;
            this.ColumnSearchItemUnitId.Visible = false;
            // 
            // ColumnSearchItemUnit
            // 
            this.ColumnSearchItemUnit.HeaderText = "Unit";
            this.ColumnSearchItemUnit.Name = "ColumnSearchItemUnit";
            this.ColumnSearchItemUnit.ReadOnly = true;
            this.ColumnSearchItemUnit.Visible = false;
            // 
            // ColumnSearchItemPrice
            // 
            this.ColumnSearchItemPrice.HeaderText = "Price";
            this.ColumnSearchItemPrice.Name = "ColumnSearchItemPrice";
            this.ColumnSearchItemPrice.ReadOnly = true;
            this.ColumnSearchItemPrice.Visible = false;
            // 
            // ColumnSearchItemOnHandQuantity
            // 
            this.ColumnSearchItemOnHandQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchItemOnHandQuantity.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSearchItemOnHandQuantity.HeaderText = "On Hand Qty.";
            this.ColumnSearchItemOnHandQuantity.Name = "ColumnSearchItemOnHandQuantity";
            this.ColumnSearchItemOnHandQuantity.ReadOnly = true;
            this.ColumnSearchItemOnHandQuantity.Width = 144;
            // 
            // ColumnSearchItemButtonPick
            // 
            this.ColumnSearchItemButtonPick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnSearchItemButtonPick.HeaderText = "Pick";
            this.ColumnSearchItemButtonPick.Name = "ColumnSearchItemButtonPick";
            this.ColumnSearchItemButtonPick.ReadOnly = true;
            this.ColumnSearchItemButtonPick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSearchItemButtonPick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSearchItemButtonPick.Width = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxFilter);
            this.panel2.Controls.Add(this.dataGridViewSearchItemList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 490);
            this.panel2.TabIndex = 7;
            // 
            // TrnSalesDetailSearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "TrnSalesDetailSearchItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Item";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearchItemList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.DataGridView dataGridViewSearchItemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemGenericName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemOutTaxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemOutTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemOutTaxRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSearchItemOnHandQuantity;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchItemButtonPick;
        private System.Windows.Forms.Panel panel2;
    }
}