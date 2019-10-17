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
            RectangleF companyNameRectangle = new RectangleF
            {
                X = x,
                Y = y,
                Size = new Size(245, ((int)graphics.MeasureString(companyName, fontArial8Regular, 245, StringFormat.GenericTypographic).Height))
            };
            graphics.DrawString(companyName, fontArial8Regular, Brushes.Black, companyNameRectangle, drawFormatCenter);
            y += companyNameRectangle.Size.Height;

            // ===============
            // Company Address
            // ===============
            String companyAddress = systemCurrent.Address;
            RectangleF companyAddressRectangle = new RectangleF
            {
                X = x,
                Y = y,
                Size = new Size(245, ((int)graphics.MeasureString(companyAddress, fontArial8Regular, 245, StringFormat.GenericTypographic).Height))
            };
            graphics.DrawString(companyAddress, fontArial8Regular, Brushes.Black, companyAddressRectangle, drawFormatCenter);
            y += companyAddressRectangle.Size.Height;

            // ======================
            // Official Receipt Title
            // ======================
            String officialReceiptTitle = systemCurrent.ORPrintTitle;
            RectangleF officialReceiptTitleRectangle = new RectangleF
            {
                X = x,
                Y = y,
                Size = new Size(245, ((int)graphics.MeasureString(officialReceiptTitle, fontArial8Regular, 245, StringFormat.GenericTypographic).Height))
            };
            graphics.DrawString(officialReceiptTitle, fontArial8Regular, Brushes.Black, officialReceiptTitleRectangle, drawFormatCenter);
            y += officialReceiptTitleRectangle.Size.Height + 5.0F;

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

                // ====================
                // Line Points Settings
                // ====================
                Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y) - 9);
                Point firstLineSecondPoint = new Point(500, Convert.ToInt32(y) - 9);

                graphics.DrawLine(blackPen, firstLineFirstPoint, firstLineSecondPoint);

                String itemLabel = "ITEM";
                graphics.DrawString(itemLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String amountLabel = "AMOUNT";
                graphics.DrawString(amountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(itemLabel, fontArial8Regular).Height + 5.0F;

                // ==========
                // Sales Line
                // ==========
                var salesLines = from d in db.TrnSalesLines where d.SalesId == trnSalesId select d;

                Decimal totalSales = 0, totalDiscount = 0, cash = 0, change = 0;
                Decimal vatSales = 0, vatAmount = 0, nonVatSales = 0, vatExclusive = 0, vatExemptSales = 0, vatZeroRatedSales = 0;

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
                                                   ItemId = g.Key.ItemId,
                                                   ItemDescription = db.MstItems.Where(i => i.Id == g.Key.ItemId).First().ItemDescription,
                                                   Unit = db.MstUnits.Where(u => u.Id == g.Key.UnitId).First().Unit,
                                                   Price = g.Key.Price,
                                                   NetPrice = g.Key.NetPrice,
                                                   DiscountId = g.Key.DiscountId,
                                                   DiscountRate = g.Key.DiscountRate,
                                                   TaxId = g.Key.TaxId,
                                                   Tax = db.MstTaxes.Where(t => t.Id == g.Key.TaxId).FirstOrDefault().Tax,
                                                   MstTax = db.MstTaxes.Where(t => t.Id == g.Key.TaxId).FirstOrDefault(),
                                                   Amount = g.Sum(a => a.Amount),
                                                   Quantity = g.Sum(a => a.Quantity),
                                                   DiscountAmount = g.Sum(a => a.DiscountAmount * a.Quantity),
                                                   TaxAmount = g.Sum(a => a.TaxAmount)
                                               };

                    if (salesLineGroupbyItem.Any())
                    {
                        foreach (var salesLine in salesLineGroupbyItem)
                        {
                            String itemData = salesLine.ItemDescription + "\n" + "**" + salesLine.Quantity.ToString("#,##0.00") + " @ " + salesLine.Price.ToString("#,##0.00") + " - " + salesLine.Tax;
                            RectangleF itemDataRectangle = new RectangleF
                            {
                                X = x,
                                Y = y,
                                Size = new Size(150, ((int)graphics.MeasureString(itemData, fontArial8Regular, 150, StringFormat.GenericTypographic).Height))
                            };
                            graphics.DrawString(itemData, fontArial8Regular, Brushes.Black, itemDataRectangle, drawFormatLeft);

                            String itemAmountData = salesLine.Amount.ToString("#,##0.00");
                            graphics.DrawString(itemAmountData, fontArial8Regular, drawBrush, new RectangleF(x, y, 245.0F, height), drawFormatRight);
                            y += itemDataRectangle.Size.Height + 5.0F;

                            totalSales += salesLine.Amount;
                            totalDiscount += salesLine.DiscountAmount;

                            if (salesLine.MstTax.Code == "VAT")
                            {
                                vatSales += salesLine.Amount - salesLine.TaxAmount;
                                vatAmount += salesLine.TaxAmount;
                            }
                            else if (salesLine.MstTax.Code == "NONVAT")
                            {
                                nonVatSales += salesLine.Amount;
                            }
                            else if (salesLine.MstTax.Code == "VATEXCLUSIVE")
                            {
                                vatExclusive += salesLine.Amount;
                                vatAmount += salesLine.TaxAmount;
                            }
                            else if (salesLine.MstTax.Code == "VATEXEMPT")
                            {
                                vatExemptSales += salesLine.Amount;
                            }
                            else if (salesLine.MstTax.Code == "VATZERORATED")
                            {
                                vatZeroRatedSales += salesLine.Amount;
                            }
                        }
                    }
                }

                // ========================
                // Total Sales and Discount
                // ========================
                Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point secondLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);

                graphics.DrawLine(blackPen, secondLineFirstPoint, secondLineSecondPoint);

                String totalSalesLabel = "\nTotal Sales";
                graphics.DrawString(totalSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalSalesAmount = "\n" + totalSales.ToString("#,##0.00");
                graphics.DrawString(totalSalesAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalSalesAmount, fontArial8Bold).Height;

                String totalDiscountLabel = "Total Discount";
                graphics.DrawString(totalDiscountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalDiscountAmount = totalDiscount.ToString("#,##0.00");
                graphics.DrawString(totalDiscountAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalDiscountAmount, fontArial8Bold).Height;

                // ================
                // Collection Lines
                // ================
                var collectionLines = from d in db.TrnCollectionLines  where d.CollectionId == collections.FirstOrDefault().Id select d;
                if (collectionLines.Any())
                {
                    Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                    Point thirdLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);

                    graphics.DrawLine(blackPen, thirdLineFirstPoint, thirdLineSecondPoint);
                    graphics.DrawLine(whitePen, thirdLineFirstPoint, thirdLineSecondPoint);

                    foreach (var collectionLine in collectionLines)
                    {
                        String collectionLineLabel = collectionLine.MstPayType.PayType;
                        graphics.DrawString(collectionLineLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                        String collectionLineAmount = collectionLine.Amount.ToString("#,##0.00");
                        graphics.DrawString(collectionLineAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                        y += graphics.MeasureString(collectionLineAmount, fontArial8Bold).Height;
                    }
                }

                // =========
                // VAT Sales
                // =========
                Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
                Point forthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);

                graphics.DrawLine(blackPen, forthLineFirstPoint, forthLineSecondPoint);

                String vatSalesLabel = "\nVat Sales";
                graphics.DrawString(vatSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalVatSalesAmount = "\n" + vatSales.ToString("#,##0.00");
                graphics.DrawString(totalVatSalesAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatSalesAmount, fontArial8Bold).Height;

                String vatAmountLabel = "Vat Amount";
                graphics.DrawString(vatAmountLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalVatAmount = totalDiscount.ToString("#,##0.00");
                graphics.DrawString(totalVatAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatAmount, fontArial8Bold).Height;

                String nonVatSalesLabel = "Non-Vat Sales";
                graphics.DrawString(nonVatSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalNonVatSalesAmount = nonVatSales.ToString("#,##0.00");
                graphics.DrawString(totalNonVatSalesAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalNonVatSalesAmount, fontArial8Bold).Height;

                String vatExclusiveLabel = "Vat Exclusive";
                graphics.DrawString(vatExclusiveLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalvatExclusiveAmount = vatExclusive.ToString("#,##0.00");
                graphics.DrawString(totalvatExclusiveAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalvatExclusiveAmount, fontArial8Bold).Height;

                String vatExemptSalesLabel = "Vat Exempt Sales";
                graphics.DrawString(vatExemptSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalvatExemptSalesAmount = vatExemptSales.ToString("#,##0.00");
                graphics.DrawString(totalvatExemptSalesAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalvatExemptSalesAmount, fontArial8Bold).Height;

                String vatZeroRatedSalesLabel = "Vat Zero Rated Sales";
                graphics.DrawString(vatZeroRatedSalesLabel, fontArial8Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                String totalVatZeroRatedSalesAmount = vatZeroRatedSales.ToString("#,##0.00");
                graphics.DrawString(totalVatZeroRatedSalesAmount, fontArial8Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                y += graphics.MeasureString(totalVatZeroRatedSalesAmount, fontArial8Bold).Height;

                if (collections.Any())
                {
                    cash = collections.FirstOrDefault().TenderAmount;
                    change = collections.FirstOrDefault().ChangeAmount;
                }
            }

            // ====================
            // Line Points Settings
            // ====================
            Point fifthLineFirstPoint = new Point(0, Convert.ToInt32(y) + 5);
            Point fifthLineSecondPoint = new Point(500, Convert.ToInt32(y) + 5);

            graphics.DrawLine(blackPen, fifthLineFirstPoint, fifthLineSecondPoint);
        }
    }
}
