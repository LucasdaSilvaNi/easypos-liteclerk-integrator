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

namespace EasyPOS.Reports
{
    public partial class RepPOSReportZReadingReportForm : Form
    {
        private Modules.SysUserRightsModule sysUserRights;

        public Forms.Software.RepPOSReport.RepPOSReportForm repPOSReportForm;
        public Int32 filterTerminalId;
        public String filterTerminal = "";
        public DateTime filterDate;
        public Entities.RepZReadingReportEntity zReadingReportEntity;

        public RepPOSReportZReadingReportForm(Forms.Software.RepPOSReport.RepPOSReportForm POSReportForm, Int32 terminalId, DateTime date)
        {
            InitializeComponent();

            sysUserRights = new Modules.SysUserRightsModule("RepPOS (Z Reading)");
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

            repPOSReportForm = POSReportForm;
            filterTerminalId = terminalId;
            filterDate = date;

            printDocumentZReadingReport.DefaultPageSettings.PaperSize = new PaperSize("Z Reading Report", 255, 1000);
            ZReadingDataSource();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult printerDialogResult = printDialogZReadingReport.ShowDialog();
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
            printDocumentZReadingReport.Print();
        }

        public void ZReadingDataSource()
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            Entities.RepZReadingReportEntity repZReadingReportEntity = new Entities.RepZReadingReportEntity()
            {
                Date = "",
                TotalGrossSales = 0,
                TotalRegularDiscount = 0,
                TotalSeniorDiscount = 0,
                TotalPWDDiscount = 0,
                TotalSalesReturn = 0,
                TotalNetSales = 0,
                CollectionLines = new List<Entities.TrnCollectionLineEntity>(),
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

            repZReadingReportEntity.Date = filterDate.ToShortDateString();

            var terminal = from d in db.MstTerminals
                           where d.Id == filterTerminalId
                           select d;

            if (terminal.Any())
            {
                filterTerminal = terminal.FirstOrDefault().Terminal;
            }

            var salesLines = from d in db.TrnSalesLines
                             where d.TrnSale.TrnCollections.Where(s => s.TerminalId == filterTerminalId && s.CollectionDate == filterDate && s.IsLocked == true && s.IsCancelled == false).Count() > 0
                             select d;

            var currentCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     select d;

            var currentCollectionLines = from d in db.TrnCollectionLines
                                         where d.TrnCollection.TerminalId == filterTerminalId
                                         && d.TrnCollection.CollectionDate == filterDate
                                         && d.TrnCollection.IsLocked == true
                                         && d.TrnCollection.IsCancelled == false
                                         group d by new
                                         {
                                             d.MstPayType.PayType,
                                         } into g
                                         select new
                                         {
                                             g.Key.PayType,
                                             TotalAmount = g.Sum(s => s.Amount),
                                             TotalChangeAmount = g.Sum(s => s.TrnCollection.ChangeAmount)
                                         };

            if (salesLines.Any() && currentCollectionLines.Any())
            {
                var grossSales = salesLines.Where(d => d.Quantity > 0);
                if (grossSales.Any())
                {
                    repZReadingReportEntity.TotalGrossSales = grossSales.Sum(d => d.Quantity * d.Price);
                }

                var regularDiscounts = salesLines.Where(d => d.Quantity > 0
                                                             && d.MstDiscount.Discount.Equals("Senior Citizen Discount") == false
                                                             && d.MstDiscount.Discount.Equals("PWD") == false);
                if (regularDiscounts.Any())
                {
                    repZReadingReportEntity.TotalRegularDiscount = regularDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var seniorDiscounts = salesLines.Where(d => d.Quantity > 0 && d.MstDiscount.Discount.Equals("Senior Citizen Discount") == true);
                if (seniorDiscounts.Any())
                {
                    repZReadingReportEntity.TotalSeniorDiscount = seniorDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var PWDDiscounts = salesLines.Where(d => d.Quantity > 0 && d.MstDiscount.Discount.Equals("PWD") == true);
                if (PWDDiscounts.Any())
                {
                    repZReadingReportEntity.TotalPWDDiscount = PWDDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var salesReturns = salesLines.Where(d => d.Quantity < 0);
                if (salesReturns.Any())
                {
                    repZReadingReportEntity.TotalSalesReturn = salesReturns.Sum(d => d.Amount);
                }

                var netSales = salesLines.Where(d => d.Quantity > 0);
                if (netSales.Any())
                {
                    repZReadingReportEntity.TotalNetSales = netSales.Sum(d => d.Amount);
                }

                foreach (var collectionLine in currentCollectionLines)
                {
                    Decimal amount = collectionLine.TotalAmount;
                    if (collectionLine.PayType.Equals("Cash"))
                    {
                        amount = collectionLine.TotalAmount - collectionLine.TotalChangeAmount;
                    }

                    repZReadingReportEntity.CollectionLines.Add(new Entities.TrnCollectionLineEntity()
                    {
                        PayType = collectionLine.PayType,
                        Amount = amount
                    });
                }

                repZReadingReportEntity.TotalCollection = currentCollections.Sum(d => d.Amount);

                var VATSales = salesLines.Where(d => d.MstTax.Code.Equals("VAT") == true);
                if (VATSales.Any())
                {
                    repZReadingReportEntity.TotalVATSales = VATSales.Sum(d => d.Amount - d.TaxAmount);
                }

                repZReadingReportEntity.TotalVATAmount = salesLines.Sum(d => d.TaxAmount);

                var nonVATSales = salesLines.Where(d => d.MstTax.Code.Equals("NONVAT") == true);
                if (nonVATSales.Any())
                {
                    repZReadingReportEntity.TotalNonVAT = nonVATSales.Sum(d => d.Amount);
                }

                var VATExclusives = salesLines.Where(d => d.MstTax.Code.Equals("VATEXCLUSIVE") == true);
                if (VATExclusives.Any())
                {
                    repZReadingReportEntity.TotalVATExclusive = VATExclusives.Sum(d => d.Amount);
                }

                var VATExempts = salesLines.Where(d => d.MstTax.Code.Equals("VATEXEMPT") == true);
                if (VATExempts.Any())
                {
                    repZReadingReportEntity.TotalVATExempt = VATExempts.Sum(d => d.Amount);
                }

                var VATZeroRateds = salesLines.Where(d => d.MstTax.Code.Equals("VATZERORATED") == true);
                if (VATZeroRateds.Any())
                {
                    repZReadingReportEntity.TotalVATZeroRated = VATZeroRateds.Sum(d => d.Amount);
                }

                repZReadingReportEntity.CounterIdStart = currentCollections.OrderBy(d => d.Id).FirstOrDefault().CollectionNumber;
                repZReadingReportEntity.CounterIdEnd = currentCollections.OrderByDescending(d => d.Id).FirstOrDefault().CollectionNumber;

                repZReadingReportEntity.TotalNumberOfTransactions = currentCollections.Count();
                repZReadingReportEntity.TotalNumberOfSKU = salesLines.Count();
                repZReadingReportEntity.TotalQuantity = salesLines.Sum(d => d.Quantity);
            }

            var currentCancelledCollections = from d in db.TrnCollections
                                              where d.TerminalId == filterTerminalId
                                              && d.CollectionDate == filterDate
                                              && d.IsLocked == true
                                              && d.IsCancelled == true
                                              select d;

            if (currentCancelledCollections.Any())
            {
                repZReadingReportEntity.TotalCancelledTrnsactionCount = currentCancelledCollections.Count();
                repZReadingReportEntity.TotalCancelledAmount = currentCancelledCollections.Sum(d => d.Amount);
            }

            var previousCollections = from d in db.TrnCollections
                                      where d.TerminalId == filterTerminalId
                                      && d.CollectionDate < filterDate
                                      && d.IsLocked == true
                                      && d.IsCancelled == false
                                      select d;

            if (previousCollections.Any())
            {
                repZReadingReportEntity.TotalPreviousReading = previousCollections.Sum(d => d.Amount);
                repZReadingReportEntity.RunningTotal = repZReadingReportEntity.TotalNetSales + repZReadingReportEntity.TotalPreviousReading;
            }

            zReadingReportEntity = repZReadingReportEntity;
        }

        private void printDocumentZReadingReport_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var dataSource = zReadingReportEntity;

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

            float x = 5, y = 5;
            float width = 245.0F, height = 0F;

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
            graphics.DrawString(companyName, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyName, fontArial8Regular).Height;

            // ===============
            // Company Address
            // ===============
            String companyAddress = systemCurrent.Address;
            graphics.DrawString(companyAddress, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ==========
            // TIN Number
            // ==========
            String TINNumber = systemCurrent.TIN;
            graphics.DrawString("TIN: " + TINNumber, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // =============
            // Serial Number
            // =============
            String serialNo = systemCurrent.SerialNo;
            graphics.DrawString("SN: " + serialNo, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ==============
            // Machine Number
            // ==============
            String machineNo = systemCurrent.MachineNo;
            graphics.DrawString("MIN: " + machineNo, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ===============
            // Terminal Number
            // ===============
            String terminal = filterTerminal;
            graphics.DrawString("Terminal: " + terminal, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(companyAddress, fontArial8Regular).Height;

            // ======================
            // Z Reading Report Title
            // ======================
            String zReadingReportTitle = "Z Reading Report";
            graphics.DrawString(zReadingReportTitle, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(zReadingReportTitle, fontArial8Regular).Height;

            // ====
            // Date 
            // ====
            String collectionDateText = filterDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
            graphics.DrawString(collectionDateText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(collectionDateText, fontArial8Regular).Height;

            // ========
            // 1st Line
            // ========
            Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

            Decimal totalGrossSales = dataSource.TotalGrossSales;
            Decimal totalRegularDiscount = dataSource.TotalRegularDiscount;
            Decimal totalSeniorDiscount = dataSource.TotalSeniorDiscount;
            Decimal totalPWDDiscount = dataSource.TotalPWDDiscount;
            Decimal totalSalesReturn = dataSource.TotalSalesReturn;
            Decimal totalNetSales = dataSource.TotalNetSales;

            // ===========
            // Gross Sales
            // ===========
            String totalGrossSalesLabel = "\nGross Sales";
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
            String totalSalesReturnData = totalSalesReturn.ToString("#,##0.00");
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
                    String collectionLineData = collectionLine.Amount.ToString("#,##0.00");
                    graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    graphics.DrawString(collectionLineData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += graphics.MeasureString(collectionLineData, fontArial8Regular).Height;
                }

                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);
            }

            Decimal totalCollection = dataSource.TotalCollection;

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

            Decimal totalVATSales = dataSource.TotalVATSales;
            Decimal totalVATAmount = dataSource.TotalVATAmount;
            Decimal totalNonVAT = dataSource.TotalNonVAT;
            Decimal totalVATExclusive = dataSource.TotalVATExclusive;
            Decimal totalVATExempt = dataSource.TotalVATExempt;
            Decimal totalVATZeroRated = dataSource.TotalVATZeroRated;

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
            Decimal totalCancelledAmount = dataSource.TotalCancelledAmount;

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

            Decimal totalPreviousReading = dataSource.TotalPreviousReading;
            Decimal runningTotal = dataSource.RunningTotal;

            String totalPreviousReadingLabel = "\nPrevious Reading";
            String totalPreviousReadingData = "\n" + totalPreviousReading.ToString("#,##0.00");
            graphics.DrawString(totalPreviousReadingLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalPreviousReadingData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalPreviousReadingData, fontArial8Regular).Height;

            graphics.DrawString("Net Sales", fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(totalNetSales.ToString("#,##0.00"), fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(totalNetSales.ToString("#,##0.00"), fontArial8Regular).Height;

            String runningTotalLabel = "Running Total";
            String runningTotalData = runningTotal.ToString("#,##0.00");
            graphics.DrawString(runningTotalLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString(runningTotalData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(runningTotalData, fontArial8Regular).Height;

            // ========
            // 9th Line
            // ========
            Point ninethLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point ninethLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
            graphics.DrawLine(blackPen, ninethLineFirstPoint, ninethLineSecondPoint);

            String zReadingFooter = systemCurrent.ZReadingFooter;

            String zReadingEndLabel = "\n" + zReadingFooter + "\n \n\n\n\n\n\n\n\n\n\n.";
            graphics.DrawString(zReadingEndLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(zReadingEndLabel, fontArial8Regular).Height;
        }
    }
}
