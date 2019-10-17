namespace EasyPOS.Reports
{
    partial class RepOfficialReceiptReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepOfficialReceiptReportForm));
            this.printDocumentOfficialReceipt = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // printDocumentOfficialReceipt
            // 
            this.printDocumentOfficialReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentOfficialReceipt_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Printing...";
            // 
            // RepOfficialReceiptReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 133);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "RepOfficialReceiptReportForm";
            this.Text = "Official Receipt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocumentOfficialReceipt;
        private System.Windows.Forms.Label label1;
    }
}