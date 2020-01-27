namespace EasyPOS.Forms.Software.TrnStockCount
{
    partial class TrnStockCountDetailStockCountLineItemDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnStockCountDetailStockCountLineItemDetailForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxStockCountLineAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStockCountLineCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStockCountLineItemDescription = new System.Windows.Forms.TextBox();
            this.textBoxStockCountLineQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStockCountLineUnit = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 63);
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
            this.label1.Size = new System.Drawing.Size(221, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stock-Count Item";
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
            this.buttonClose.Location = new System.Drawing.Point(586, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 40);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(166)))), ((int)(((byte)(240)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(492, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 40);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.TabStop = false;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxStockCountLineAmount);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxStockCountLineCost);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBoxStockCountLineItemDescription);
            this.panel2.Controls.Add(this.textBoxStockCountLineQuantity);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBoxStockCountLineUnit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 191);
            this.panel2.TabIndex = 9;
            // 
            // textBoxStockCountLineAmount
            // 
            this.textBoxStockCountLineAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStockCountLineAmount.Location = new System.Drawing.Point(98, 152);
            this.textBoxStockCountLineAmount.Name = "textBoxStockCountLineAmount";
            this.textBoxStockCountLineAmount.ReadOnly = true;
            this.textBoxStockCountLineAmount.Size = new System.Drawing.Size(269, 30);
            this.textBoxStockCountLineAmount.TabIndex = 3;
            this.textBoxStockCountLineAmount.TabStop = false;
            this.textBoxStockCountLineAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label9.Location = new System.Drawing.Point(16, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label4.Location = new System.Drawing.Point(44, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cost:";
            // 
            // textBoxStockCountLineCost
            // 
            this.textBoxStockCountLineCost.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStockCountLineCost.Location = new System.Drawing.Point(98, 116);
            this.textBoxStockCountLineCost.Name = "textBoxStockCountLineCost";
            this.textBoxStockCountLineCost.Size = new System.Drawing.Size(269, 30);
            this.textBoxStockCountLineCost.TabIndex = 2;
            this.textBoxStockCountLineCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStockCountLineCost.TextChanged += new System.EventHandler(this.textBoxStockCountLineCost_TextChanged);
            this.textBoxStockCountLineCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStockCountLineCost_KeyPress);
            this.textBoxStockCountLineCost.Leave += new System.EventHandler(this.textBoxStockCountLineCost_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quantity:";
            // 
            // textBoxStockCountLineItemDescription
            // 
            this.textBoxStockCountLineItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStockCountLineItemDescription.BackColor = System.Drawing.Color.White;
            this.textBoxStockCountLineItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStockCountLineItemDescription.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxStockCountLineItemDescription.Location = new System.Drawing.Point(12, 6);
            this.textBoxStockCountLineItemDescription.Name = "textBoxStockCountLineItemDescription";
            this.textBoxStockCountLineItemDescription.ReadOnly = true;
            this.textBoxStockCountLineItemDescription.Size = new System.Drawing.Size(662, 32);
            this.textBoxStockCountLineItemDescription.TabIndex = 12;
            this.textBoxStockCountLineItemDescription.TabStop = false;
            this.textBoxStockCountLineItemDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxStockCountLineQuantity
            // 
            this.textBoxStockCountLineQuantity.AcceptsTab = true;
            this.textBoxStockCountLineQuantity.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStockCountLineQuantity.HideSelection = false;
            this.textBoxStockCountLineQuantity.Location = new System.Drawing.Point(98, 44);
            this.textBoxStockCountLineQuantity.Name = "textBoxStockCountLineQuantity";
            this.textBoxStockCountLineQuantity.Size = new System.Drawing.Size(269, 30);
            this.textBoxStockCountLineQuantity.TabIndex = 0;
            this.textBoxStockCountLineQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxStockCountLineQuantity.TextChanged += new System.EventHandler(this.textBoxStockCountLineQuantity_TextChanged);
            this.textBoxStockCountLineQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStockCountLineQuantity_KeyPress);
            this.textBoxStockCountLineQuantity.Leave += new System.EventHandler(this.textBoxStockCountLineQuantity_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.label3.Location = new System.Drawing.Point(46, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Unit:";
            // 
            // textBoxStockCountLineUnit
            // 
            this.textBoxStockCountLineUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.textBoxStockCountLineUnit.Location = new System.Drawing.Point(98, 80);
            this.textBoxStockCountLineUnit.Name = "textBoxStockCountLineUnit";
            this.textBoxStockCountLineUnit.ReadOnly = true;
            this.textBoxStockCountLineUnit.Size = new System.Drawing.Size(116, 30);
            this.textBoxStockCountLineUnit.TabIndex = 1;
            this.textBoxStockCountLineUnit.TabStop = false;
            // 
            // TrnStockCountDetailStockCountLineItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(686, 254);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrnStockCountDetailStockCountLineItemDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock-Count Line Item Detail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStockCountLineItemDescription;
        private System.Windows.Forms.TextBox textBoxStockCountLineQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStockCountLineUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStockCountLineCost;
        private System.Windows.Forms.TextBox textBoxStockCountLineAmount;
        private System.Windows.Forms.Label label9;
    }
}