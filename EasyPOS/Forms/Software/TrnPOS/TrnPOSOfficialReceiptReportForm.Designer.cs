namespace EasyPOS.Forms.Software.TrnPOS
{
    partial class TrnPOSOfficialReceiptReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrnPOSOfficialReceiptReportForm));
            this.printDocumentOfficialReceipt = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // printDocumentOfficialReceipt
            // 
            this.printDocumentOfficialReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentOfficialReceipt_PrintPage);
            // 
            // TrnPOSOfficialReceiptReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(482, 53);
            this.ControlBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(500, 100);
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "TrnPOSOfficialReceiptReportForm";
            this.Text = "Official Receipt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocumentOfficialReceipt;
    }
}