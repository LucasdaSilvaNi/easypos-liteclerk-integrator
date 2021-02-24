
namespace EasyPOS.Forms.Software._80mmReport
{
    partial class RepSalesSummaryReport80mmForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepSalesSummaryReport80mmForm));
            this.printDocumentSalesSummaryReport = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // printDocumentSalesSummaryReport
            // 
            this.printDocumentSalesSummaryReport.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentSalesSummaryReport_PrintPage);
            // 
            // RepSalesSummaryReport80mmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 89);
            this.ControlBox = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RepSalesSummaryReport80mmForm";
            this.Text = "80mm Sales Summary Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocumentSalesSummaryReport;
    }
}