using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepPOSReport
{
    public partial class RepXReadingReportForm : Form
    {
        private Modules.SysUserRightsModule sysUserRights;

        public Forms.Software.RepPOSReport.RepPOSReportForm repPOSReportForm;
        public Int32 filterTerminalId;
        public DateTime filterDate;
        public Int32 filterSalesAgentId;
        public Entities.RepPOSReportXReadingReportEntity xReadingReportEntity;

        public RepXReadingReportForm(Forms.Software.RepPOSReport.RepPOSReportForm POSReportForm, Int32 terminalId, DateTime date, Int32 salesAgentId)
        {
            InitializeComponent();

            repPOSReportForm = POSReportForm;
            filterTerminalId = terminalId;
            filterDate = date;
            filterSalesAgentId = salesAgentId;
            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                printDocumentXReadingReport.DefaultPageSettings.PaperSize = new PaperSize("X Reading Report", 255, 1000);
                XReadingDataSource();
            }
            else
            {
                printDocumentXReadingReport.DefaultPageSettings.PaperSize = new PaperSize("X Reading Report", 270, 1000);
                XReadingDataSource();
            }

            sysUserRights = new Modules.SysUserRightsModule("RepPOS (X Reading)");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (sysUserRights.GetUserRights().CanPrint == false)
                {
                    buttonPrint.Enabled = false;
                }

            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult printerDialogResult = printDialogXReadingReport.ShowDialog();
            if (printerDialogResult == DialogResult.OK)
            {
                PrintReport();
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void PrintReport()
        {
            printDocumentXReadingReport.Print();
        }

        public void XReadingDataSource()
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            Entities.RepPOSReportXReadingReportEntity repXReadingReportEntity = new Entities.RepPOSReportXReadingReportEntity()
            {
                SalesAgent = "",
                Date = "",
                TotalGrossSales = 0,
                TotalRegularDiscount = 0,
                TotalSeniorDiscount = 0,
                TotalPWDDiscount = 0,
                TotalSalesReturn = 0,
                TotalNetSales = 0,
                CollectionLines = new List<Entities.TrnCollectionLineEntity>(),
                TotalRefund = 0,
                TotalCollection = 0,
                TotalVATSales = 0,
                TotalVATAmount = 0,
                TotalNonVAT = 0,
                TotalVATExclusive = 0,
                TotalVATExempt = 0,
                TotalVATZeroRated = 0,
                CounterIdStart = "0000000000",
                CounterIdEnd = "0000000000",
                TotalCancelledTrnsactionCount = 0,
                TotalCancelledAmount = 0,
                TotalNumberOfTransactions = 0,
                TotalNumberOfSKU = 0,
                TotalQuantity = 0,
                TotalPreviousReading = 0,
                RunningTotal = 0
            };

            repXReadingReportEntity.Date = filterDate.ToShortDateString();

            var salesAgentUser = from d in db.MstUsers
                                 where d.Id == filterSalesAgentId
                                 select d;

            if (salesAgentUser.Any())
            {
                repXReadingReportEntity.SalesAgent = salesAgentUser.FirstOrDefault().UserName;
            }

            var currentCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate
                                     && d.PreparedBy == filterSalesAgentId
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     && d.SalesId != null
                                     select d;

            var currentCollectionLines = from d in db.TrnCollectionLines
                                         where d.TrnCollection.TerminalId == filterTerminalId
                                         && d.TrnCollection.CollectionDate == filterDate
                                         && d.TrnCollection.PreparedBy == filterSalesAgentId
                                         && d.TrnCollection.IsLocked == true
                                         && d.TrnCollection.IsCancelled == false
                                         && d.TrnCollection.TrnSale.IsReturned == false
                                         group d by new
                                         {
                                             d.MstPayType.PayTypeCode,
                                             d.MstPayType.PayType,
                                         } into g
                                         select new
                                         {
                                             g.Key.PayTypeCode,
                                             g.Key.PayType,
                                             TotalAmount = g.Sum(s => s.Amount),
                                             TotalChangeAmount = g.Sum(s => s.TrnCollection.ChangeAmount)
                                         };

            if (currentCollections.Any() && currentCollectionLines.ToList().Any())
            {
                var disbursmenet = from d in db.TrnDisbursements
                                   where d.TerminalId == filterTerminalId
                                   && d.DisbursementDate == filterDate
                                   && d.IsLocked == true
                                   && d.IsRefund == true
                                   && d.RefundSalesId != null
                                   && d.PreparedBy == filterSalesAgentId
                                   select d;

                if (disbursmenet.Any())
                {
                    repXReadingReportEntity.TotalRefund = disbursmenet.Sum(d => d.Amount);
                }

                Decimal totalGrossSales = 0;
                Decimal totalRegularDiscount = 0;
                Decimal totalSeniorCitizenDiscount = 0;
                Decimal totalPWDDiscount = 0;
                Decimal totalSalesReturn = 0;
                Decimal totalVATSales = 0;
                Decimal totalVATAmount = 0;
                Decimal totalNonVATSales = 0;
                Decimal totalVATExemptSales = 0;
                Decimal totalVATZeroRatedSales = 0;
                Decimal totalNoOfSKUs = 0;
                Decimal totalQUantity = 0;

                foreach (var currentCollection in currentCollections)
                {
                    var sales = from d in db.TrnSales
                                where d.Id == currentCollection.SalesId
                                select d;

                    if (sales.Any())
                    {
                        var salesLines = sales.FirstOrDefault().TrnSalesLines.Where(d => d.Quantity > 0 && d.TrnSale.IsReturned == false);

                        Decimal salesLineTotalGrossSales = 0;
                        Decimal salesLineTotalRegularDiscount = 0;
                        Decimal salesLineTotalSeniorCitizenDiscount = 0;
                        Decimal salesLineTotalPWDDiscount = 0;
                        Decimal salesLineTotalVATSales = 0;
                        Decimal salesLineTotalVATAmount = 0;
                        Decimal salesLineTotalNonVATSales = 0;
                        Decimal salesLineTotalVATExemptSales = 0;
                        Decimal salesLineTotalVATZeroRatedSales = 0;

                        if (salesLines.Any())
                        {
                            totalNoOfSKUs += salesLines.Count();
                            totalQUantity += salesLines.Sum(d => d.Quantity);

                            foreach (var salesLine in salesLines)
                            {
                                if (salesLine.MstTax.Code == "EXEMPTVAT")
                                {
                                    if (salesLine.MstItem.MstTax1.Rate > 0)
                                    {
                                        salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstItem.MstTax1.Rate / 100)) * (salesLine.MstItem.MstTax1.Rate / 100));
                                    }
                                    else
                                    {
                                        salesLineTotalGrossSales += salesLine.Price * salesLine.Quantity;
                                    }
                                }
                                else
                                {
                                    salesLineTotalGrossSales += (salesLine.Price * salesLine.Quantity) - ((salesLine.Price * salesLine.Quantity) / (1 + (salesLine.MstTax.Rate / 100)) * (salesLine.MstTax.Rate / 100));
                                }

                                if (salesLine.MstDiscount.Discount != "Senior Citizen Discount" && salesLine.MstDiscount.Discount != "PWD")
                                {
                                    salesLineTotalRegularDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                                }

                                if (salesLine.MstDiscount.Discount == "Senior Citizen Discount")
                                {
                                    salesLineTotalSeniorCitizenDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                                }

                                if (salesLine.MstDiscount.Discount == "PWD")
                                {
                                    salesLineTotalPWDDiscount += salesLine.DiscountAmount * salesLine.Quantity;
                                }

                                if (salesLine.MstTax.Code.Equals("VAT"))
                                {
                                    salesLineTotalVATSales += salesLine.Amount - (salesLine.Amount / (1 + (salesLine.MstTax.Rate / 100)) * (salesLine.MstTax.Rate / 100));
                                }

                                salesLineTotalVATAmount += salesLine.TaxAmount;

                                if (salesLine.MstTax.Code.Equals("NONVAT"))
                                {
                                    salesLineTotalNonVATSales += salesLine.Amount;
                                }

                                if (salesLine.MstTax.Code.Equals("EXEMPTVAT"))
                                {
                                    salesLineTotalVATExemptSales += salesLine.Amount;
                                }

                                if (salesLine.MstTax.Code.Equals("ZEROVAT"))
                                {
                                    salesLineTotalVATZeroRatedSales += salesLine.Amount;
                                }
                            }
                        }

                        totalGrossSales += salesLineTotalGrossSales;
                        totalRegularDiscount += salesLineTotalRegularDiscount;
                        totalSeniorCitizenDiscount += salesLineTotalSeniorCitizenDiscount;
                        totalPWDDiscount += salesLineTotalPWDDiscount;
                        totalVATSales += salesLineTotalVATSales;
                        totalVATAmount += salesLineTotalVATAmount;
                        totalNonVATSales += salesLineTotalNonVATSales;
                        totalVATExemptSales += salesLineTotalVATExemptSales;
                        totalVATZeroRatedSales += salesLineTotalVATZeroRatedSales;
                    }
                }

                totalVATSales -= repXReadingReportEntity.TotalRefund;

                Decimal salesReturnLineTotalAmount = 0;

                var salesReturnLines = from d in db.TrnSalesLines
                                       where d.Quantity < 0
                                       && d.TrnSale.SalesDate == filterDate
                                       && d.TrnSale.IsLocked == true
                                       && d.TrnSale.IsCancelled == false
                                       && d.TrnSale.IsReturned == true
                                       && d.TrnSale.PreparedBy == filterSalesAgentId
                                       select d;

                if (salesReturnLines.Any())
                {
                    foreach (var salesReturnLine in salesReturnLines)
                    {
                        if (salesReturnLine.MstTax.Code == "EXEMPTVAT")
                        {
                            if (salesReturnLine.MstItem.MstTax1.Rate > 0)
                            {
                                salesReturnLineTotalAmount += (salesReturnLine.Price * salesReturnLine.Quantity) - ((salesReturnLine.Price * salesReturnLine.Quantity) / (1 + (salesReturnLine.MstItem.MstTax1.Rate / 100)) * (salesReturnLine.MstItem.MstTax1.Rate / 100));
                                totalVATExemptSales -= (((salesReturnLine.Price * salesReturnLine.Quantity) - ((salesReturnLine.Price * salesReturnLine.Quantity) / (1 + (salesReturnLine.MstItem.MstTax1.Rate / 100)) * (salesReturnLine.MstItem.MstTax1.Rate / 100))) * -1);
                            }
                            else
                            {
                                salesReturnLineTotalAmount += salesReturnLine.Price * salesReturnLine.Quantity;
                                totalVATExemptSales -= ((salesReturnLine.Price * salesReturnLine.Quantity) * -1);
                            }
                        }
                        else
                        {
                            salesReturnLineTotalAmount += (salesReturnLine.Price * salesReturnLine.Quantity) - ((salesReturnLine.Price * salesReturnLine.Quantity) / (1 + (salesReturnLine.MstTax.Rate / 100)) * (salesReturnLine.MstTax.Rate / 100));
                            totalVATSales -= (((salesReturnLine.Price * salesReturnLine.Quantity) - ((salesReturnLine.Price * salesReturnLine.Quantity) / (1 + (salesReturnLine.MstTax.Rate / 100)) * (salesReturnLine.MstTax.Rate / 100))) * -1);
                        }

                        totalVATAmount -= (salesReturnLine.TaxAmount * -1);
                    }
                }

                totalSalesReturn += salesReturnLineTotalAmount * -1;

                repXReadingReportEntity.TotalGrossSales = totalGrossSales;
                repXReadingReportEntity.TotalRegularDiscount = totalRegularDiscount;
                repXReadingReportEntity.TotalSeniorDiscount = totalSeniorCitizenDiscount;
                repXReadingReportEntity.TotalPWDDiscount = totalPWDDiscount;
                repXReadingReportEntity.TotalSalesReturn = totalSalesReturn;
                repXReadingReportEntity.TotalNetSales = totalGrossSales -
                                                        totalRegularDiscount -
                                                        totalSeniorCitizenDiscount -
                                                        totalPWDDiscount -
                                                        totalSalesReturn;

                foreach (var collectionLine in currentCollectionLines)
                {
                    Decimal amount = collectionLine.TotalAmount;
                    if (collectionLine.PayTypeCode.Equals("CASH"))
                    {
                        amount = collectionLine.TotalAmount - collectionLine.TotalChangeAmount;
                    }

                    repXReadingReportEntity.CollectionLines.Add(new Entities.TrnCollectionLineEntity()
                    {
                        PayType = collectionLine.PayType,
                        Amount = amount
                    });
                }

                repXReadingReportEntity.TotalCollection = currentCollections.Sum(d => d.Amount) - repXReadingReportEntity.TotalRefund;
                repXReadingReportEntity.TotalVATSales = totalVATSales;
                repXReadingReportEntity.TotalVATAmount = totalVATAmount;
                repXReadingReportEntity.TotalNonVAT = totalNonVATSales;
                repXReadingReportEntity.TotalVATExempt = totalVATExemptSales;

                var counterCollections = from d in db.TrnCollections
                                         where d.TerminalId == filterTerminalId
                                         && d.CollectionDate == filterDate
                                         && d.IsLocked == true
                                         select d;

                if (counterCollections.Any())
                {
                    repXReadingReportEntity.CounterIdStart = counterCollections.OrderBy(d => d.Id).FirstOrDefault().CollectionNumber;
                    repXReadingReportEntity.CounterIdEnd = counterCollections.OrderByDescending(d => d.Id).FirstOrDefault().CollectionNumber;
                }

                repXReadingReportEntity.TotalNumberOfTransactions = currentCollections.Count();
                repXReadingReportEntity.TotalNumberOfSKU = totalNoOfSKUs;
                repXReadingReportEntity.TotalQuantity = totalQUantity;
            }

            var currentCancelledCollections = from d in db.TrnCollections
                                              where d.TerminalId == filterTerminalId
                                              && d.CollectionDate == filterDate
                                              && d.PreparedBy == filterSalesAgentId
                                              && d.IsLocked == true
                                              && d.IsCancelled == true
                                              select d;

            if (currentCancelledCollections.Any())
            {
                repXReadingReportEntity.TotalCancelledTrnsactionCount = currentCancelledCollections.Count();
                repXReadingReportEntity.TotalCancelledAmount = currentCancelledCollections.Sum(d => d.Amount);
            }

            var previousCollections = from d in db.TrnCollections
                                      where d.TerminalId == filterTerminalId
                                      && d.CollectionDate < filterDate
                                      && d.PreparedBy == filterSalesAgentId
                                      && d.IsLocked == true
                                      && d.IsCancelled == false
                                      select d;

            if (previousCollections.Any())
            {
                repXReadingReportEntity.TotalPreviousReading = previousCollections.Sum(d => d.Amount);
                repXReadingReportEntity.RunningTotal = repXReadingReportEntity.TotalNetSales + repXReadingReportEntity.TotalPreviousReading;
            }

            xReadingReportEntity = repXReadingReportEntity;
        }

        private void printDocumentXReadingReport_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var dataSource = xReadingReportEntity;
            Decimal declareRate = Modules.SysCurrentModule.GetCurrentSettings().DeclareRate;

            // =============
            // Font Settings
            // =============
            Font fontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font fontArial12Regular = new Font("Arial", 12, FontStyle.Regular);
            Font fontArial11Bold = new Font("Arial", 11, FontStyle.Bold);
            Font fontArial11Regular = new Font("Arial", 11, FontStyle.Regular);
            Font fontArial8Bold = new Font("Arial", 8, FontStyle.Bold);
            Font fontArial8Regular = new Font("Arial", 8, FontStyle.Regular);

            // ==================
            // Alignment Settings
            // ==================
            StringFormat drawFormatCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat drawFormatLeft = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat drawFormatRight = new StringFormat { Alignment = StringAlignment.Far };

            float x, y;
            float width, height;
            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                x = 5; y = 5;
                width = 245.0F; height = 0F;
            }
            else
            {
                x = 5; y = 5;
                width = 260.0F; height = 0F;
            }

            // ==============
            // Tools Settings
            // ==============
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black, 1);
            Pen whitePen = new Pen(Color.White, 1);

            // ========
            // Graphics
            // ========
            Graphics graphics = e.Graphics;

            // ==============
            // System Current
            // ==============
            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            // ============
            // Company Name
            // ============
            String companyName = systemCurrent.CompanyName;
            float adjustStringName = 1;
            if (companyName.Length > 43)
            {
                adjustStringName = 3;
            }
            graphics.DrawString(companyName, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyName, fontArial8Regular).Height* adjustStringName;

            // ===============
            // Company Address
            // ===============
            String companyAddress = systemCurrent.Address;

            float adjuctHeight = 1;
            if (companyAddress.Length > 43)
            {
                adjuctHeight = 3;
            }

            graphics.DrawString(companyAddress, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += (graphics.MeasureString(companyAddress, fontArial8Regular).Height * adjuctHeight);

            // ======================
            // X Reading Report Title
            // ======================
            String zReadingReportTitle = "X Reading Report";
            graphics.DrawString(zReadingReportTitle, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(zReadingReportTitle, fontArial8Regular).Height;

            // ====
            // Date 
            // ====
            String collectionDateText = filterDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
            graphics.DrawString(collectionDateText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(collectionDateText, fontArial8Regular).Height;

            // ===========
            // Sales Agent 
            // ===========
            String salesAgent = dataSource.SalesAgent;
            graphics.DrawString(salesAgent, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(salesAgent, fontArial8Regular).Height;

            // ========
            // 1st Line
            // ========
            Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

            Decimal totalGrossSales = dataSource.TotalGrossSales * declareRate;
            Decimal totalRegularDiscount = dataSource.TotalRegularDiscount * declareRate;
            Decimal totalSeniorDiscount = dataSource.TotalSeniorDiscount * declareRate;
            Decimal totalPWDDiscount = dataSource.TotalPWDDiscount * declareRate;
            Decimal totalSalesReturn = dataSource.TotalSalesReturn * declareRate;
            Decimal totalNetSales = dataSource.TotalNetSales * declareRate;

            // ===========
            // Gross Sales
            // ===========
            String totalGrossSalesLabel = "\nGross Sales (Net of VAT)";
            String totalGrossSalesData = "\n" + totalGrossSales.ToString("#,##0.00");
            graphics.DrawString(totalGrossSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalGrossSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalGrossSalesData, fontArial8Regular).Height;

            // ================
            // Regular Discount
            // ================
            String totalRegularDiscountLabel = "Regular Discount";
            String totalRegularDiscountData = totalRegularDiscount.ToString("#,##0.00");
            graphics.DrawString(totalRegularDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalRegularDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalRegularDiscountData, fontArial8Regular).Height;

            // ===============
            // Senior Discount
            // ===============
            String totalSeniorDiscountLabel = "Senior Discount";
            String totalSeniorDiscountData = totalSeniorDiscount.ToString("#,##0.00");
            graphics.DrawString(totalSeniorDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalSeniorDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalSeniorDiscountData, fontArial8Regular).Height;

            // ============
            // PWD Discount
            // ============
            String totalPWDDiscountLabel = "PWD Discount";
            String totalPWDDiscountData = totalPWDDiscount.ToString("#,##0.00");
            graphics.DrawString(totalPWDDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalPWDDiscountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalPWDDiscountData, fontArial8Regular).Height;

            // ============
            // Sales Return
            // ============
            String totalSalesReturnLabel = "Sales Return";
            String totalSalesReturnData = "(" + totalSalesReturn.ToString("#,##0.00") + ")";
            graphics.DrawString(totalSalesReturnLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalSalesReturnData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalSalesReturnData, fontArial8Regular).Height;

            // =========
            // Net Sales
            // =========
            String totalNetSalesLabel = "Net Sales\n\n";
            String totalNetSalesData = totalNetSales.ToString("#,##0.00") + "\n\n";
            graphics.DrawString(totalNetSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNetSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNetSalesData, fontArial8Regular).Height;

            // ========
            // 2nd Line
            // ========
            Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y) - 7);
            Point secondLineSecondPoint = new Point(500, Convert.ToInt32(y) - 7);
            graphics.DrawLine(blackPen, secondLineFirstPoint, secondLineSecondPoint);

            if (dataSource.CollectionLines.Any())
            {
                foreach (var collectionLine in dataSource.CollectionLines)
                {
                    // ================
                    // Collection Lines
                    // ================
                    String collectionLineLabel = collectionLine.PayType;
                    String collectionLineData = (collectionLine.Amount * declareRate).ToString("#,##0.00");
                    graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    graphics.DrawString(collectionLineData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += graphics.MeasureString(collectionLineData, fontArial8Regular).Height;

                }
                Decimal totalRefund = dataSource.TotalRefund * declareRate;

                String totalRefundLabel = "Refund";
                String totalRefundData = "(" + totalRefund.ToString("#,##0.00") + ")";
                graphics.DrawString(totalRefundLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalRefundData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalRefundData, fontArial8Regular).Height;
                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);
            }

            Decimal totalCollection = dataSource.TotalCollection * declareRate;

            // ================
            // Total Collection
            // ================
            if (dataSource.CollectionLines.Any())
            {
                String totalCollectionLabel = "\nTotal Collection";
                String totalCollectionData = "\n" + totalCollection.ToString("#,##0.00");
                graphics.DrawString(totalCollectionLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalCollectionData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalCollectionData, fontArial8Regular).Height;
            }
            else
            {
                String totalCollectionLabel = "Total Collection";
                String totalCollectionData = totalCollection.ToString("#,##0.00");
                graphics.DrawString(totalCollectionLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalCollectionData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalCollectionData, fontArial8Regular).Height;
            }

            // ========
            // 4th Line
            // ========
            Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point forthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, forthLineFirstPoint, forthLineSecondPoint);

            Decimal totalVATSales = dataSource.TotalVATSales * declareRate;
            Decimal totalVATAmount = dataSource.TotalVATAmount * declareRate;
            Decimal totalNonVAT = dataSource.TotalNonVAT * declareRate;
            Decimal totalVATExclusive = dataSource.TotalVATExclusive * declareRate;
            Decimal totalVATExempt = dataSource.TotalVATExempt * declareRate;
            Decimal totalVATZeroRated = dataSource.TotalVATZeroRated * declareRate;

            String vatSalesLabel = "\nVAT Sales";
            String totalVatSalesData = "\n" + totalVATSales.ToString("#,##0.00");
            graphics.DrawString(vatSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVatSalesData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVatSalesData, fontArial8Regular).Height;

            String totalVATAmountLabel = "VAT Amount";
            String totalVATAmountData = totalVATAmount.ToString("#,##0.00");
            graphics.DrawString(totalVATAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVATAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVATAmountData, fontArial8Regular).Height;

            String totalNonVATLabel = "Non-VAT";
            String totalNonVATAmount = totalNonVAT.ToString("#,##0.00");
            graphics.DrawString(totalNonVATLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNonVATAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNonVATAmount, fontArial8Regular).Height;

            //String totalVATExclusiveLabel = "VAT Exclusive";
            //String totalVATExclusiveData = totalVATExclusive.ToString("#,##0.00");
            //graphics.DrawString(totalVATExclusiveLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            //graphics.DrawString(totalVATExclusiveData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            //y += graphics.MeasureString(totalVATExclusiveData, fontArial8Regular).Height;

            String totalVATExemptLabel = "VAT Exempt";
            String totalVATExemptData = totalVATExempt.ToString("#,##0.00");
            graphics.DrawString(totalVATExemptLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVATExemptData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVATExemptData, fontArial8Regular).Height;

            String totalVATZeroRatedLabel = "VAT Zero Rated";
            String totalVatZeroRatedData = totalVATZeroRated.ToString("#,##0.00");
            graphics.DrawString(totalVATZeroRatedLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalVatZeroRatedData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalVatZeroRatedData, fontArial8Regular).Height;

            // ========
            // 5th Line
            // ========
            Point fifthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point fifthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, fifthLineFirstPoint, fifthLineSecondPoint);

            String counterIdStart = dataSource.CounterIdStart;
            String counterIdEnd = dataSource.CounterIdEnd;

            String startCounterIdLabel = "\nCounter ID Start";
            String startCounterIdData = "\n" + counterIdStart;
            graphics.DrawString(startCounterIdLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(startCounterIdData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(startCounterIdData, fontArial8Regular).Height;

            String endCounterIdLabel = "Counter ID End";
            String endCounterIdData = counterIdEnd;
            graphics.DrawString(endCounterIdLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(endCounterIdData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(endCounterIdData, fontArial8Regular).Height;

            // ========
            // 6th Line
            // ========
            Point sixthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point sixthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, sixthLineFirstPoint, sixthLineSecondPoint);

            Decimal totalCancelledTrnsactionCount = dataSource.TotalCancelledTrnsactionCount;
            Decimal totalCancelledAmount = dataSource.TotalCancelledAmount * declareRate;

            String totalCancelledTrnsactionCountLabel = "\nCancelled Tx.";
            String totalCancelledTrnsactionCountData = "\n" + totalCancelledTrnsactionCount.ToString("#,##0");
            graphics.DrawString(totalCancelledTrnsactionCountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalCancelledTrnsactionCountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalCancelledTrnsactionCountData, fontArial8Regular).Height;

            String totalCancelledAmountLabel = "Cancelled Amount";
            String totalCancelledAmountData = totalCancelledAmount.ToString("#,##0.00");
            graphics.DrawString(totalCancelledAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalCancelledAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalCancelledAmountData, fontArial8Regular).Height;

            // ========
            // 7th Line
            // ========
            Point seventhLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point seventhLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, seventhLineFirstPoint, seventhLineSecondPoint);

            Decimal totalNumberOfTransactions = dataSource.TotalNumberOfTransactions;
            Decimal totalNumberOfSKU = dataSource.TotalNumberOfSKU;
            Decimal totalQuantity = dataSource.TotalQuantity;

            String totalNumberOfTransactionsLabel = "\nNo. of Transactions";
            String totalNumberOfTransactionsData = "\n" + totalNumberOfTransactions.ToString("#,##0");
            graphics.DrawString(totalNumberOfTransactionsLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNumberOfTransactionsData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNumberOfTransactionsData, fontArial8Regular).Height;

            String totalNumberOfSKULabel = "No. of SKU";
            String totalNumberOfSKUData = totalNumberOfSKU.ToString("#,##0");
            graphics.DrawString(totalNumberOfSKULabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNumberOfSKUData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNumberOfSKUData, fontArial8Regular).Height;

            String totalQuantityLabel = "Total Quantity";
            String totalQuantityData = totalQuantity.ToString("#,##0.00");
            graphics.DrawString(totalQuantityLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalQuantityData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalQuantityData, fontArial8Regular).Height;

            // ========
            // 8th Line
            // ========
            Point eightLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point eightLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, eightLineFirstPoint, eightLineSecondPoint);

            //Decimal totalPreviousReading = dataSource.TotalPreviousReading;
            //Decimal runningTotal = dataSource.RunningTotal;

            //String totalPreviousReadingLabel = "\nPrevious Reading";
            //String totalPreviousReadingData = "\n" + totalPreviousReading.ToString("#,##0.00");
            //graphics.DrawString(totalPreviousReadingLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            //graphics.DrawString(totalPreviousReadingData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            //y += graphics.MeasureString(totalPreviousReadingData, fontArial8Regular).Height;

            //graphics.DrawString("Net Sales", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            //graphics.DrawString(totalNetSales.ToString("#,##0.00"), fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            //y += graphics.MeasureString(totalNetSales.ToString("#,##0.00"), fontArial8Regular).Height;

            //String runningTotalLabel = "Running Total";
            //String runningTotalData = runningTotal.ToString("#,##0.00");
            //graphics.DrawString(runningTotalLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            //graphics.DrawString(runningTotalData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            //y += graphics.MeasureString(runningTotalData, fontArial8Regular).Height;

            //// ========
            //// 9th Line
            //// ========
            //Point ninethLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            //Point ninethLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            //graphics.DrawLine(blackPen, ninethLineFirstPoint, ninethLineSecondPoint);

            String xReadingFooter = systemCurrent.ZReadingFooter;

            if (Modules.SysCurrentModule.GetCurrentSettings().PrinterType == "Dot Matrix Printer")
            {
                String xReadingEndLabel = "\n" + xReadingFooter + "\n \n\n\n\n\n\n\n\n\n\n.";
                graphics.DrawString(xReadingEndLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(xReadingEndLabel, fontArial8Regular).Height;
            }
            else 
            {
                String xReadingEndLabel = "\n" + xReadingFooter + "\n \n\n\n.";
                graphics.DrawString(xReadingEndLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(xReadingEndLabel, fontArial8Regular).Height;
            }
                
        }
    }
}
