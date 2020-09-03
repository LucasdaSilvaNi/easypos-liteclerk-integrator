namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnPOSSearchItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPOSSearchItemForm));
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
            this.ColumnSearchItemIsInventory = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 50);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EasyPOS.Properties.Resources.POS;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 28);
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
            this.buttonClose.Location = new System.Drawing.Point(748, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(109, 32);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Esc - Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(10, 5);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(847, 26);
            this.textBoxFilter.TabIndex = 1;
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
            this.ColumnSearchItemIsInventory,
            this.ColumnSearchItemButtonPick});
            this.dataGridViewSearchItemList.Location = new System.Drawing.Point(10, 34);
            this.dataGridViewSearchItemList.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewSearchItemList.MultiSelect = false;
            this.dataGridViewSearchItemList.Name = "dataGridViewSearchItemList";
            this.dataGridViewSearchItemList.ReadOnly = true;
            this.dataGridViewSearchItemList.RowTemplate.Height = 24;
            this.dataGridViewSearchItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSearchItemList.Size = new System.Drawing.Size(846, 349);
            this.dataGridViewSearchItemList.TabIndex = 0;
            this.dataGridViewSearchItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSearchItemList_CellClick);
            this.dataGridViewSearchItemList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewSearchItemList_KeyDown);
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
            this.ColumnSearchItemBarcode.Width = 130;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchItemPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnSearchItemPrice.HeaderText = "Price";
            this.ColumnSearchItemPrice.Name = "ColumnSearchItemPrice";
            this.ColumnSearchItemPrice.ReadOnly = true;
            // 
            // ColumnSearchItemOnHandQuantity
            // 
            this.ColumnSearchItemOnHandQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnSearchItemOnHandQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSearchItemOnHandQuantity.HeaderText = "On Hand Qty.";
            this.ColumnSearchItemOnHandQuantity.Name = "ColumnSearchItemOnHandQuantity";
            this.ColumnSearchItemOnHandQuantity.ReadOnly = true;
            this.ColumnSearchItemOnHandQuantity.Width = 120;
            // 
            // ColumnSearchItemIsInventory
            // 
            this.ColumnSearchItemIsInventory.HeaderText = "I";
            this.ColumnSearchItemIsInventory.Name = "ColumnSearchItemIsInventory";
            this.ColumnSearchItemIsInventory.ReadOnly = true;
            this.ColumnSearchItemIsInventory.Width = 40;
            // 
            // ColumnSearchItemButtonPick
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.ColumnSearchItemButtonPick.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 392);
            this.panel2.TabIndex = 7;
            // 
            // TrnPOSSearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(866, 442);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "TrnPOSSearchItemForm";
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
        private System.Windows.Forms.Panel panel2;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSearchItemIsInventory;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSearchItemButtonPick;
    }
}