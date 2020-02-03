namespace EasyPOS.Forms.Software.RepSalesReport
{
    partial class RepStockWithdrawalReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepStockWithdrawalReportForm));
            this.printDocumentDeliveryReceipt = new System.Drawing.Printing.PrintDocument();
            this.printDialogStockWithdrawalReport = new System.Windows.Forms.PrintDialog();
            this.SuspendLayout();
            // 
            // printDocumentDeliveryReceipt
            // 
            this.printDocumentDeliveryReceipt.OriginAtMargins = true;
            this.printDocumentDeliveryReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentDeliveryReceipt_PrintPage);
            // 
            // printDialogStockWithdrawalReport
            // 
            this.printDialogStockWithdrawalReport.UseEXDialog = true;
            // 
            // RepStockWithdrawalReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 53);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 100);
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "RepStockWithdrawalReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Receipt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocumentDeliveryReceipt;
        private System.Windows.Forms.PrintDialog printDialogStockWithdrawalReport;
    }
}