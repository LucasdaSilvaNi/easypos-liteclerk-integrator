using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Reports
{
    public partial class RepOfficialReceiptReportForm : Form
    {
        public Int32 trnSalesId = 0;
        public Int32 trnCollectionId = 0;

        public RepOfficialReceiptReportForm(Int32 salesId, Int32 collectionId)
        {
            InitializeComponent();

            trnSalesId = salesId;
            trnCollectionId = collectionId;

            printDocumentOfficialReceipt.Print();
        }

        private void printDocumentOfficialReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // ============
            // Data Context
            // ============
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

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

            // ======================
            // Official Receipt Title
            // ======================
            String officialReceiptTitle = systemCurrent.ORPrintTitle;
            graphics.DrawString(officialReceiptTitle, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += graphics.MeasureString(officialReceiptTitle, fontArial8Regular).Height;

            // =================
            // Collection Header
            // =================
            var collections = from d in db.TrnCollections where d.Id == trnCollectionId select d;
            if (collections.Any())
            {
                String collectionNumberText = collections.FirstOrDefault().CollectionNumber;
                graphics.DrawString(collectionNumberText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(collectionNumberText, fontArial8Regular).Height;

                String collectionDateText = collections.FirstOrDefault().CollectionDate.ToString("MM-dd-yyyy h:mm:ss tt", CultureInfo.InvariantCulture) + "\n\n";
                graphics.DrawString(collectionDateText, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(collectionDateText, fontArial8Regular).Height;

                // ========
                // 1st Line
                // ========
                Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) - 9);
                Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) - 9);
                graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

                // ==========
                // Sales Line
                // ==========
                Decimal totalSales = 0;
                Decimal totalDiscount = 0;
                Decimal change = 0;
                Decimal totalVATSales = 0;
                Decimal totalVATAmount = 0;
                Decimal totalNonVATSales = 0;
                Decimal totalVATExclusive = 0;
                Decimal totalVATExempt = 0;
                Decimal totalVATZeroRated = 0;
                Decimal totalNumberOfItems = 0;

                String itemLabel = "ITEM";
                String amountLabel = "AMOUNT";
                graphics.DrawString(itemLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(amountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(itemLabel, fontArial8Regular).Height + 5.0F;

                var salesLines = from d in db.TrnSalesLines where d.SalesId == trnSalesId select d;
                if (salesLines.Any())
                {
                    var salesLineGroupbyItem = from s in salesLines
                                               group s by new
                                               {
                                                   s.SalesId,
                                                   s.ItemId,
                                                   s.UnitId,
                                                   s.NetPrice,
                                                   s.Price,
                                                   s.TaxId,
                                                   s.DiscountId,
                                                   s.DiscountRate,
                                                   s.SalesAccountId,
                                                   s.AssetAccountId,
                                                   s.CostAccountId,
                                                   s.TaxAccountId,
                                                   s.SalesLineTimeStamp,
                                                   s.UserId,
                                                   s.Preparation,
                                                   s.Price1,
                                                   s.Price2,
                                                   s.Price2LessTax,
                                                   s.PriceSplitPercentage
                                               } into g
                                               select new
                                               {
                                                   g.Key.ItemId,
                                                   db.MstItems.Where(i => i.Id == g.Key.ItemId).First().ItemDescription,
                                                   db.MstUnits.Where(u => u.Id == g.Key.UnitId).First().Unit,
                                                   g.Key.Price,
                                                   g.Key.NetPrice,
                                                   g.Key.DiscountId,
                                                   g.Key.DiscountRate,
                                                   g.Key.TaxId,
                                                   db.MstTaxes.Where(t => t.Id == g.Key.TaxId).FirstOrDefault().Tax,
                                                   MstTax = db.MstTaxes.Where(t => t.Id == g.Key.TaxId).FirstOrDefault(),
                                                   Amount = g.Sum(a => a.Amount),
                                                   Quantity = g.Sum(a => a.Quantity),
                                                   DiscountAmount = g.Sum(a => a.DiscountAmount * a.Quantity),
                                                   TaxAmount = g.Sum(a => a.TaxAmount)
                                               };

                    if (salesLineGroupbyItem.Any())
                    {
                        foreach (var salesLine in salesLineGroupbyItem.ToList())
                        {
                            totalNumberOfItems += 1;

                            totalSales += salesLine.Amount;
                            totalDiscount += salesLine.DiscountAmount;

                            if (salesLine.MstTax.Code == "VAT")
                            {
                                totalVATSales += salesLine.Amount - salesLine.TaxAmount;
                                totalVATAmount += salesLine.TaxAmount;
                            }
                            else if (salesLine.MstTax.Code == "NONVAT")
                            {
                                totalNonVATSales += salesLine.Amount;
                            }
                            else if (salesLine.MstTax.Code == "VATEXCLUSIVE")
                            {
                                totalVATExclusive += salesLine.Amount;
                                totalVATAmount += salesLine.TaxAmount;
                            }
                            else if (salesLine.MstTax.Code == "VATEXEMPT")
                            {
                                totalVATExempt += salesLine.Amount;
                            }
                            else if (salesLine.MstTax.Code == "VATZERORATED")
                            {
                                totalVATZeroRated += salesLine.Amount;
                            }

                            String itemData = salesLine.ItemDescription + "\n" + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,##0.00") + " - " + salesLine.Tax[0];
                            String itemAmountData = salesLine.Amount.ToString("#,##0.00");
                            RectangleF itemDataRectangle = new RectangleF
                            {
                                X = x,
                                Y = y,
                                Size = new Size(150, ((int)graphics.MeasureString(itemData, fontArial8Regular, 150, StringFormat.GenericTypographic).Height))
                            };
                            graphics.DrawString(itemData, fontArial8Regular, Brushes.Black, itemDataRectangle, drawFormatLeft);
                            graphics.DrawString(itemAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, 245.0F, height), drawFormatRight);
                            y += itemDataRectangle.Size.Height + 3.0F;
                        }
                    }
                }

                // ========
                // 2nd Line
                // ========
                Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y) + 10);
                Point secondLineSecondPoint = new Point(500, Convert.ToInt32(y) + 10);
                graphics.DrawLine(blackPen, secondLineFirstPoint, secondLineSecondPoint);

                // ==============================
                // Total Sales and Total Discount
                // ==============================
                String totalSalesLabel = "\n\nTotal Sales";
                String totalSalesAmount = "\n" + totalSales.ToString("#,##0.00");
                graphics.DrawString(totalSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalSalesAmount, fontArial12Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalSalesAmount, fontArial12Regular).Height;

                String totalNumberOfItemsLabel = "Total No. of Item(s)";
                String totalNumberOfItemsQuantity = totalNumberOfItems.ToString("#,##0.00");
                graphics.DrawString(totalNumberOfItemsLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalNumberOfItemsQuantity, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalNumberOfItemsQuantity, fontArial8Regular).Height;

                String totalDiscountLabel = "Total Discount\n\n";
                String totalDiscountAmount = totalDiscount.ToString("#,##0.00") + "\n\n";
                graphics.DrawString(totalDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalDiscountAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalDiscountAmount, fontArial8Regular).Height;

                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) - 7);
                Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) - 7);
                graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);

                // ================
                // Collection Lines
                // ================
                var collectionLines = from d in db.TrnCollectionLines where d.CollectionId == collections.FirstOrDefault().Id select d;
                if (collectionLines.Any())
                {
                    foreach (var collectionLine in collectionLines)
                    {
                        String collectionLineLabel = collectionLine.MstPayType.PayType;
                        String collectionLineAmount = collectionLine.Amount.ToString("#,##0.00");

                        graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                        graphics.DrawString(collectionLineAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                        y += graphics.MeasureString(collectionLineAmount, fontArial8Regular).Height;
                    }
                }

                // ======
                // Change
                // ======
                change = collections.FirstOrDefault().ChangeAmount;

                String changelabel = "Change";
                String changeAmount = change.ToString("#,##0.00");
                graphics.DrawString(changelabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(changeAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(changeAmount, fontArial8Regular).Height;

                // ========
                // 4th Line
                // ========
                Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point forthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, forthLineFirstPoint, forthLineSecondPoint);

                // ============
                // VAT Analysis
                // ============
                String vatAnalysisLabel = "\nVAT ANALYSIS";
                graphics.DrawString(vatAnalysisLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                y += graphics.MeasureString(vatAnalysisLabel, fontArial8Regular).Height + +5.0F;

                String vatSalesLabel = "VAT Sales";
                String totalVatSalesAmount = totalVATSales.ToString("#,##0.00");
                graphics.DrawString(vatSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalVatSalesAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatSalesAmount, fontArial8Regular).Height;

                String totalVATAmountLabel = "VAT Amount";
                String totalVatAmount = totalVATAmount.ToString("#,##0.00");
                graphics.DrawString(totalVATAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalVatAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatAmount, fontArial8Regular).Height;

                String totalNonVATSalesLabel = "Non-VAT";
                String totalNonVatAmount = totalNonVATSales.ToString("#,##0.00");
                graphics.DrawString(totalNonVATSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalNonVatAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalNonVatAmount, fontArial8Regular).Height;

                String totalVATExclusiveLabel = "VAT Exclusive";
                String totaltotalVATExclusiveAmount = totalVATExclusive.ToString("#,##0.00");
                graphics.DrawString(totalVATExclusiveLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totaltotalVATExclusiveAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totaltotalVATExclusiveAmount, fontArial8Regular).Height;

                String totalVATExemptLabel = "VAT Exempt";
                String totaltotalVATExemptAmount = totalVATExempt.ToString("#,##0.00");
                graphics.DrawString(totalVATExemptLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totaltotalVATExemptAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totaltotalVATExemptAmount, fontArial8Regular).Height;

                String totalVATZeroRatedLabel = "VAT Zero Rated";
                String totalVatZeroRatedAmount = totalVATZeroRated.ToString("#,##0.00");
                graphics.DrawString(totalVATZeroRatedLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(totalVatZeroRatedAmount, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatZeroRatedAmount, fontArial8Regular).Height;

                // ========
                // 6th Line
                // ========
                Point sixthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point sixthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, sixthLineFirstPoint, sixthLineSecondPoint);

                // =======
                // Cashier
                // =======
                String cashier = collections.FirstOrDefault().MstUser3.UserName;

                String cashierLabel = "\nCashier";
                String cashierUserData = "\n" + cashier;
                graphics.DrawString(cashierLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                graphics.DrawString(cashierUserData, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(cashierUserData, fontArial8Regular).Height;

                // ========
                // 7th Line
                // ========
                Point seventhLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point seventhLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, seventhLineFirstPoint, seventhLineSecondPoint);

                String soldToLabel = "\nSold To: ______________________________";
                graphics.DrawString(soldToLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                y += graphics.MeasureString(soldToLabel, fontArial8Regular).Height;

                String soldToAddressLabel = "Address: _____________________________";
                graphics.DrawString(soldToAddressLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                y += graphics.MeasureString(soldToAddressLabel, fontArial8Regular).Height;

                String soldToTINLabel = "TIN: _________________________________";
                graphics.DrawString(soldToTINLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                y += graphics.MeasureString(soldToTINLabel, fontArial8Regular).Height;

                // ========
                // 8th Line
                // ========
                Point eightLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point eightLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);
                graphics.DrawLine(blackPen, eightLineFirstPoint, eightLineSecondPoint);

                String receiptFooter = "\n" + systemCurrent.ReceiptFooter;
                graphics.DrawString(receiptFooter, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += graphics.MeasureString(receiptFooter, fontArial8Regular).Height;
            }

            String space = "\n\n\n\n\n\n\n\n\n\n.";
            graphics.DrawString(space, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
        }
    }
}
