namespace EasyPOS.Reports
{
    partial class RepDeliveryReceiptReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepDeliveryReceiptReportForm));
            this.printDocumentDeliveryReceipt = new System.Drawing.Printing.PrintDocument();
            this.printPreviewControlDeliveryReceipt = new System.Windows.Forms.PrintPreviewControl();
            this.SuspendLayout();
            // 
            // printDocumentDeliveryReceipt
            // 
            this.printDocumentDeliveryReceipt.OriginAtMargins = true;
            this.printDocumentDeliveryReceipt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentDeliveryReceipt_PrintPage);
            // 
            // printPreviewControlDeliveryReceipt
            // 
            this.printPreviewControlDeliveryReceipt.AutoZoom = false;
            this.printPreviewControlDeliveryReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControlDeliveryReceipt.Document = this.printDocumentDeliveryReceipt;
            this.printPreviewControlDeliveryReceipt.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControlDeliveryReceipt.Name = "printPreviewControlDeliveryReceipt";
            this.printPreviewControlDeliveryReceipt.Size = new System.Drawing.Size(996, 637);
            this.printPreviewControlDeliveryReceipt.TabIndex = 0;
            this.printPreviewControlDeliveryReceipt.Zoom = 1D;
            // 
            // RepDeliveryReceiptReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 637);
            this.Controls.Add(this.printPreviewControlDeliveryReceipt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RepDeliveryReceiptReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Receipt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocumentDeliveryReceipt;
        private System.Windows.Forms.PrintPreviewControl printPreviewControlDeliveryReceipt;
    }
}