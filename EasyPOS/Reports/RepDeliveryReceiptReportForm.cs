using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Reports
{
    public partial class RepDeliveryReceiptReportForm : Form
    {
        public Int32 trnSalesId = 0;
        public Int32 trnCollectionId = 0;
        public Boolean trnIsReprinted = false;

        public RepDeliveryReceiptReportForm(Int32 salesId, Int32 collectionId, Boolean isReprinted)
        {
            InitializeComponent();

            trnSalesId = salesId;
            trnCollectionId = collectionId;
            trnIsReprinted = isReprinted;

            printDocumentDeliveryReceipt.DefaultPageSettings.PaperSize = new PaperSize("Delivery Receipt", 1200, 850);

            Margins margins = new Margins(15, 0, 20, 0);
            printDocumentDeliveryReceipt.DefaultPageSettings.Margins = margins;

            printDocumentDeliveryReceipt.Print();
        }

        private void printDocumentDeliveryReceipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // ============
            // Data Context
            // ============
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            // =============
            // Font Settings
            // =============
            Font fontArial15Bold = new Font("Arial", 15, FontStyle.Bold);
            Font fontArial15Regular = new Font("Arial", 15, FontStyle.Regular);
            Font fontArial14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font fontArial14Regular = new Font("Arial", 14, FontStyle.Regular);
            Font fontArial13Bold = new Font("Arial", 13, FontStyle.Bold);
            Font fontArial13Regular = new Font("Arial", 13, FontStyle.Regular);
            Font fontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font fontArial12Regular = new Font("Arial", 12, FontStyle.Regular);
            Font fontArial11Bold = new Font("Arial", 11, FontStyle.Bold);
            Font fontArial11Regular = new Font("Arial", 11, FontStyle.Regular);
            Font fontArial11Italic = new Font("Arial", 11, FontStyle.Italic);
            Font fontArial10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font fontArial10Regular = new Font("Arial", 10, FontStyle.Regular);
            Font fontArial10Italic = new Font("Arial", 10, FontStyle.Italic);

            // ==================
            // Alignment Settings
            // ==================
            StringFormat drawFormatCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat drawFormatLeft = new StringFormat { Alignment = StringAlignment.Near };
            StringFormat drawFormatRight = new StringFormat { Alignment = StringAlignment.Far };

            float x = 5, y = 5;
            float width = 490.0F, height = 0F;

            // ==============
            // Tools Settings
            // ==============
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen blackPen = new Pen(Color.Black, 1);
            Pen whitePen = new Pen(Color.White, 1);
            Pen blackDashPen = new Pen(Color.Black, 1)
            {
                DashPattern = new float[] { 2, 2 }
            };

            // ========
            // Graphics
            // ========
            Graphics graphics = e.Graphics;

            // ==============
            // System Current
            // ==============
            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            // ==============
            // Document Title
            // ==============
            String documentTitle = "DELIVERY RECIEPT";
            String documentDate = DateTime.Today.ToShortDateString();
            graphics.DrawString(documentTitle, fontArial15Bold, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            graphics.DrawString("Date: " + documentDate, fontArial11Regular, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += graphics.MeasureString(documentTitle, fontArial15Bold).Height;

            // ========
            // 1st Line
            // ========
            Point firstLineFirstPoint = new Point(0, Convert.ToInt32(y));
            Point firstLineSecondPoint = new Point(490, Convert.ToInt32(y));
            graphics.DrawLine(blackDashPen, firstLineFirstPoint, firstLineSecondPoint);

            // =================
            // Collection Header
            // =================
            var collection = from d in db.TrnCollections
                             where d.Id == trnCollectionId
                             select d;

            if (collection.Any())
            {
                // =============================
                // Term, Due Date, Delivery Date
                // =============================
                String term = collection.FirstOrDefault().MstCustomer.MstTerm.Term;
                String dueDate = collection.FirstOrDefault().CollectionDate.AddDays(Convert.ToDouble(collection.FirstOrDefault().MstCustomer.MstTerm.NumberOfDays)).Date.ToShortDateString();
                String deliveryDate = collection.FirstOrDefault().CollectionDate.ToShortDateString();

                graphics.DrawString("Term: " + term, fontArial11Regular, drawBrush, new RectangleF(x, y + 5, width, height), drawFormatLeft);
                graphics.DrawString("Due Date: " + dueDate, fontArial11Regular, drawBrush, new RectangleF(-200, y + 5, width, height), drawFormatRight);
                graphics.DrawString("Delivery Date: " + deliveryDate, fontArial11Regular, drawBrush, new RectangleF(x, y + 5, width, height), drawFormatRight);
                y += graphics.MeasureString(term, fontArial11Regular).Height + 10;

                // ========
                // 2nd Line
                // ========
                Point secondLineFirstPoint = new Point(0, Convert.ToInt32(y));
                Point secondLineSecondPoint = new Point(490, Convert.ToInt32(y));
                graphics.DrawLine(blackDashPen, secondLineFirstPoint, secondLineSecondPoint);

                // ========
                // Customer
                // ========
                String customer = collection.FirstOrDefault().MstCustomer.Customer;
                RectangleF customerRectangle = new RectangleF
                {
                    X = x,
                    Y = y + 5,
                    Size = new Size(545, ((int)graphics.MeasureString(customer, fontArial11Bold, 485, StringFormat.GenericTypographic).Height))
                };
                graphics.DrawString(customer, fontArial11Bold, drawBrush, customerRectangle, drawFormatLeft);
                y += customerRectangle.Size.Height + 5;

                // =======
                // Address
                // =======
                String address = collection.FirstOrDefault().MstCustomer.Address;
                RectangleF addressRectangle = new RectangleF
                {
                    X = x,
                    Y = y + 5,
                    Size = new Size(545, ((int)graphics.MeasureString(address, fontArial11Regular, 485, StringFormat.GenericTypographic).Height))
                };
                graphics.DrawString(address, fontArial11Regular, drawBrush, addressRectangle, drawFormatLeft);
                y += addressRectangle.Size.Height + 10;

                // ========
                // 3rd Line
                // ========
                Point thirdLineFirstPoint = new Point(0, Convert.ToInt32(y));
                Point thirdLineSecondPoint = new Point(490, Convert.ToInt32(y));
                graphics.DrawLine(blackDashPen, thirdLineFirstPoint, thirdLineSecondPoint);

                // =================
                // Item Column Label
                // =================
                graphics.DrawString("Description", fontArial10Bold, drawBrush, new RectangleF(-150, y + 5, width, height), drawFormatCenter);
                graphics.DrawString("Qty.", fontArial10Bold, drawBrush, new RectangleF(-40, y + 5, width, height), drawFormatCenter);
                graphics.DrawString("U/M", fontArial10Bold, drawBrush, new RectangleF(x + 35, y + 5, width, height), drawFormatCenter);
                graphics.DrawString("Price", fontArial10Bold, drawBrush, new RectangleF(x + 120, y + 5, width, height), drawFormatCenter);
                graphics.DrawString("Amount", fontArial10Bold, drawBrush, new RectangleF(x + 200, y + 5, width, height), drawFormatCenter);
                y += graphics.MeasureString("Description", fontArial10Bold).Height + 10;

                // =========
                // 4rth Line
                // =========
                Point forthLineFirstPoint = new Point(0, Convert.ToInt32(y));
                Point forthLineSecondPoint = new Point(490, Convert.ToInt32(y));
                graphics.DrawLine(blackDashPen, forthLineFirstPoint, forthLineSecondPoint);

                Decimal subTotalAmount = 0;

                if (collection.FirstOrDefault().TrnSale.TrnSalesLines.Any())
                {
                    var salesLines = collection.FirstOrDefault().TrnSale.TrnSalesLines.ToList();
                    foreach (var salesLine in salesLines)
                    {
                        String item = salesLine.MstItem.ItemDescription;
                        String quantity = salesLine.Quantity.ToString("#,##0.00");
                        String unit = salesLine.MstUnit.Unit;
                        String price = salesLine.Price.ToString("#,##0.00");
                        String amount = salesLine.Amount.ToString("#,##0.00");

                        RectangleF itemRectangle = new RectangleF
                        {
                            X = x,
                            Y = y + 5,
                            Size = new Size(160, ((int)graphics.MeasureString(item, fontArial11Regular, 160, StringFormat.GenericTypographic).Height))
                        };
                        graphics.DrawString(item, fontArial10Regular, Brushes.Black, itemRectangle, drawFormatLeft);

                        RectangleF quantityRectangle = new RectangleF
                        {
                            X = itemRectangle.Width + 10,
                            Y = y + 5,
                            Size = new Size(70, ((int)graphics.MeasureString(quantity, fontArial11Regular, 70, StringFormat.GenericTypographic).Height))
                        };
                        graphics.DrawString(quantity, fontArial10Regular, Brushes.Black, quantityRectangle, drawFormatRight);

                        RectangleF unitRectangle = new RectangleF
                        {
                            X = itemRectangle.Width + quantityRectangle.Width + 15,
                            Y = y + 5,
                            Size = new Size(90, ((int)graphics.MeasureString(unit, fontArial11Regular, 100, StringFormat.GenericTypographic).Height))
                        };
                        graphics.DrawString(unit, fontArial10Regular, Brushes.Black, unitRectangle, drawFormatLeft);

                        RectangleF priceRectangle = new RectangleF
                        {
                            X = itemRectangle.Width + quantityRectangle.Width + unitRectangle.Width + 10,
                            Y = y + 5,
                            Size = new Size(80, ((int)graphics.MeasureString(price, fontArial11Regular, 80, StringFormat.GenericTypographic).Height))
                        };
                        graphics.DrawString(price, fontArial10Regular, Brushes.Black, priceRectangle, drawFormatRight);

                        RectangleF amountRectangle = new RectangleF
                        {
                            X = itemRectangle.Width + quantityRectangle.Width + unitRectangle.Width + priceRectangle.Width + 10,
                            Y = y + 5,
                            Size = new Size(80, ((int)graphics.MeasureString(amount, fontArial11Regular, 80, StringFormat.GenericTypographic).Height))
                        };
                        graphics.DrawString(amount, fontArial10Regular, Brushes.Black, amountRectangle, drawFormatRight);

                        float[] rectangleHeights = new float[5] {
                            itemRectangle.Size.Height,
                            quantityRectangle.Size.Height,
                            unitRectangle.Size.Height,
                            priceRectangle.Size.Height,
                            amountRectangle.Size.Height
                        };

                        y += rectangleHeights.Max() + 3.0F;

                        subTotalAmount += salesLine.Amount;
                    }
                }

                y += 5;

                // ========
                // 5th Line
                // ========
                Point fifthLineFirstPoint = new Point(0, Convert.ToInt32(y));
                Point fifthLineSecondPoint = new Point(490, Convert.ToInt32(y));
                graphics.DrawLine(blackPen, fifthLineFirstPoint, fifthLineSecondPoint);

                y += 5;

                // =================================================
                // Received By / Date Received, Payment / Deductions
                // =================================================
                graphics.DrawString("Received by / Date Received:", fontArial10Italic, drawBrush, new RectangleF(x, y + 5, 245.0F, height), drawFormatLeft);
                graphics.DrawString("Total: ", fontArial10Bold, drawBrush, new RectangleF(x + 100, y + 5, 245.0F, height), drawFormatRight);
                graphics.DrawString(subTotalAmount.ToString("#,##0.00"), fontArial10Bold, drawBrush, new RectangleF(x + 240, y + 5, 245.0F, height), drawFormatRight);
                y += graphics.MeasureString("Total: ", fontArial10Bold).Height + 70;

                //graphics.DrawString("Payment / Deductions: ", fontArial9Bold, drawBrush, new RectangleF(x + 100, y + 5, 245.0F, height), drawFormatRight);
                //graphics.DrawString("0.00", fontArial9Bold, drawBrush, new RectangleF(x + 240, y + 5, 245.0F, height), drawFormatRight);
                //y += graphics.MeasureString("Payment / Deductions: ", fontArial9Bold).Height + 10;

                // ========
                // 6th Line
                // ========
                Point sixthFirstLineFirstPoint = new Point(0, Convert.ToInt32(y));
                Point sixthFirstLineSecondPoint = new Point(205, Convert.ToInt32(y));
                graphics.DrawLine(blackDashPen, sixthFirstLineFirstPoint, sixthFirstLineSecondPoint);

                //Point sixthSecondLineFirstPoint = new Point(210, Convert.ToInt32(y));
                //Point sixthSecondLineSecondPoint = new Point(490, Convert.ToInt32(y));
                //graphics.DrawLine(blackPen, sixthSecondLineFirstPoint, sixthSecondLineSecondPoint);

                //y += 5;

                // =====
                // Total
                // =====
                graphics.DrawString("DR No.: " + collection.FirstOrDefault().CollectionNumber, fontArial11Bold, drawBrush, new RectangleF(x, y + 5, 245.0F, height), drawFormatLeft);
                //graphics.DrawString("Total: ", fontArial9Bold, drawBrush, new RectangleF(x + 100, y + 5, 245.0F, height), drawFormatRight);
                //graphics.DrawString(subTotalAmount.ToString("#,##0.00"), fontArial9Bold, drawBrush, new RectangleF(x + 240, y + 5, 245.0F, height), drawFormatRight);
                //y += graphics.MeasureString("Total: ", fontArial9Bold).Height + 5;

                y += 50;

                graphics.DrawString("Received in above-stated stocks and the undersigned hereby agrees to pay the value of the stocks on or before ____________________. " , fontArial10Regular, drawBrush, new RectangleF(x, y + 5, 490, height), drawFormatCenter);
            }
        }
    }
}
