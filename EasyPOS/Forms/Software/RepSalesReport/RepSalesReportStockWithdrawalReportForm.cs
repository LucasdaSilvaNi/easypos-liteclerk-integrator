using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepSalesReportStockWithdrawalReportForm : Form
    {
        public Boolean isDeliveryReceipt;
        public Boolean isDirectPrint;

        public RepSalesReportStockWithdrawalReportForm(String filePath, List<Entities.RepSalesReportTrnCollectionEntity> collectionLists, Boolean filterIsDeliveryReceipt, Boolean filterIsDirectPrint)
        {
            InitializeComponent();
            isDeliveryReceipt = filterIsDeliveryReceipt;
            isDirectPrint = filterIsDirectPrint;

            PrintStockWithdrawalReport(collectionLists);
        }

        public void PrintStockWithdrawalReport(List<Entities.RepSalesReportTrnCollectionEntity> collectionLists)
        {
            try
            {
                iTextSharp.text.Font fontTimesNewRoman09 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 09);
                iTextSharp.text.Font fontTimesNewRoman09Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTimesNewRoman0Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
                iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.DARK_GRAY, Element.ALIGN_MIDDLE, 10F)));

                Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

                var fileName = "StockWithdrawalReport" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(432, 576);

                var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();
                String ORFooter = systemCurrent.ReceiptFooter;
                PdfPTable tableFooter = new PdfPTable(2);
                tableFooter.SetWidths(new float[] { 50f, 50f });
                tableFooter.DefaultCell.Border = 0;
                tableFooter.TotalWidth = pagesize.Width - 5f - 72f;
                tableFooter.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 2, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
                tableFooter.AddCell(new PdfPCell(new Phrase("Received by / Date Received:", fontTimesNewRoman0Italic)) { Border = 0, Padding = 3f, Colspan = 2 });
                tableFooter.AddCell(new PdfPCell(new Phrase("_____________________")) { Border = 0, PaddingTop = 25f });
                tableFooter.AddCell(new PdfPCell(new Phrase("")) { Border = 0, PaddingTop = 25f });
                tableFooter.AddCell(new PdfPCell(new Phrase("No.: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 3f, Colspan = 2 });
                tableFooter.AddCell(new PdfPCell(new Phrase(ORFooter, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 3f, Colspan = 2 });

                Document document = new Document(pagesize);
                document.SetMargins(5f, 72f, 127f, 5f + tableFooter.TotalHeight);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                document.Open();

                if (collectionLists.Any())
                {
                    foreach (var collectionList in collectionLists)
                    {
                        var collection = from d in db.TrnCollections where d.Id == collectionList.Id select d;

                        pdfWriter.PageEvent = new CollectionHeaderFooter(currentUser.FirstOrDefault().Id, collectionList.Id, isDeliveryReceipt);

                        Int32 colspan = 3;
                        Int32 numberOfColumns = 3;
                        float[] widths = new float[] { 100f, 20f, 30f };

                        if (isDeliveryReceipt == true)
                        {
                            colspan = 5;
                            numberOfColumns = 5;
                            widths = new float[] { 70f, 20f, 30f, 30f, 30f };
                        }

                        PdfPTable tableItem = new PdfPTable(numberOfColumns);
                        tableItem.SetWidths(widths);
                        tableItem.WidthPercentage = 100;

                        Decimal totalAmount = 0;

                        if (collection.FirstOrDefault().TrnSale.TrnSalesLines.Any())
                        {
                            foreach (var salesItem in collection.FirstOrDefault().TrnSale.TrnSalesLines)
                            {
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.ItemDescription, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Quantity.ToString("#,##0.00"), fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.MstUnit.Unit, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });

                                if (isDeliveryReceipt == true)
                                {
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Price.ToString("#,##0.00"), fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Amount.ToString("#,##0.00"), fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                }

                                totalAmount += salesItem.Amount;
                            }
                        }

                        if (isDeliveryReceipt == true)
                        {
                            tableItem.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = -5f, Colspan = colspan });
                            tableItem.AddCell(new PdfPCell(new Phrase("Total: " + totalAmount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, Colspan = colspan, HorizontalAlignment = 2 });
                        }

                        document.Add(tableItem);
                        document.NewPage();

                        pdfWriter.PageEvent = null;
                    }
                }

                document.Close();

                if (isDirectPrint == true)
                {
                    ProcessStartInfo info = new ProcessStartInfo(fileName)
                    {
                        Verb = "Print",
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process printDwg = new Process
                    {
                        StartInfo = info
                    };

                    printDwg.Start();
                    printDwg.Close();
                }
                else
                {
                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class CollectionHeaderFooter : PdfPageEventHelper
    {
        public Int32 userId = 0;
        public Int32 collectonId = 0;
        public Boolean isDeliveryReceipt;
        public Data.easyposdbDataContext db;

        public CollectionHeaderFooter(Int32 currentUserId, Int32 currentCollectonId, Boolean filterIsDeliveryReceipt)
        {
            userId = currentUserId;
            collectonId = currentCollectonId;
            isDeliveryReceipt = filterIsDeliveryReceipt;

            db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            var collection = from d in db.TrnCollections where d.Id == collectonId select d;

            iTextSharp.text.Font fontTimesNewRoman09 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 09);
            iTextSharp.text.Font fontTimesNewRoman09Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 09, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontTimesNewRoman09Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 09, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontTimesNewRoman0Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
            iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 7F)));

            String documentTitle = systemCurrent.ORPrintTitle;
            String date = DateTime.Today.ToShortDateString();
            String terminal = collection.FirstOrDefault().MstTerminal.Terminal;
            String term = collection.FirstOrDefault().MstCustomer.MstTerm.Term;
            String user = collection.FirstOrDefault().TrnSale.MstUser.UserName;
            String dueDate = collection.FirstOrDefault().CollectionDate.AddDays(Convert.ToDouble(collection.FirstOrDefault().MstCustomer.MstTerm.NumberOfDays)).Date.ToShortDateString();
            String deliveryDate = collection.FirstOrDefault().CollectionDate.ToShortDateString();

            String customer = collection.FirstOrDefault().MstCustomer.Customer;
            String address = collection.FirstOrDefault().MstCustomer.Address;

            String ORFooter = systemCurrent.ReceiptFooter;

            PdfPTable tableHeader = new PdfPTable(4);
            tableHeader.SetWidths(new float[] { 27f, 65f, 35f, 50f });
            tableHeader.DefaultCell.Border = 0;
            tableHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableHeader.AddCell(new PdfPCell(new Phrase(documentTitle, fontTimesNewRoman14Bold)) { Colspan = 3, Border = 0, Padding = 3f, PaddingBottom = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontTimesNewRoman10Bold)) { HorizontalAlignment = 2, Border = 0, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Date: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(date, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Terminal: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(terminal, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Term: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(term, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("User: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(user, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Due Date: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(dueDate, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Delivery Date: ", fontTimesNewRoman09Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(deliveryDate, fontTimesNewRoman09)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase(customer, fontTimesNewRoman10Bold)) { Border = 0, Colspan = 4, Padding = 1f });

            var addressCell = new PdfPCell(new Phrase(address, fontTimesNewRoman09)) { Border = 0, Colspan = 4, Rowspan = 2, Padding = 1f };
            addressCell.FixedHeight = 20f;

            tableHeader.AddCell(addressCell);
            tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });

            Int32 colspan = 3;
            Int32 numberOfColumns = 3;
            float[] widths = new float[] { 100f, 20f, 30f };

            if (isDeliveryReceipt == true)
            {
                colspan = 5;
                numberOfColumns = 5;
                widths = new float[] { 70f, 20f, 30f, 30f, 30f };
            }

            PdfPTable tableItem = new PdfPTable(numberOfColumns);
            tableItem.SetWidths(widths);
            tableItem.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableItem.AddCell(new PdfPCell(new Phrase(" ", fontTimesNewRoman10Bold)) { Border = 0, Colspan = colspan, PaddingTop = -10f });
            tableItem.AddCell(new PdfPCell(new Phrase("Description", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            tableItem.AddCell(new PdfPCell(new Phrase("Qty.", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            tableItem.AddCell(new PdfPCell(new Phrase("Unit", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });

            if (isDeliveryReceipt == true)
            {
                tableItem.AddCell(new PdfPCell(new Phrase("Price", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableItem.AddCell(new PdfPCell(new Phrase("Amount", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            }

            tableHeader.AddCell(new PdfPCell(tableItem) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 127f, writer.DirectContent);

            PdfPTable tableFooter = new PdfPTable(2);
            tableFooter.SetWidths(new float[] { 50f, 50f });
            tableFooter.DefaultCell.Border = 0;
            tableFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableFooter.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 2, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableFooter.AddCell(new PdfPCell(new Phrase("Received by / Date Received:", fontTimesNewRoman0Italic)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase("_____________________")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontTimesNewRoman10Bold)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase(ORFooter, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 3f, Colspan = 2 });
            tableFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) + 5f, writer.DirectContent);

            float marginBottom = writer.PageSize.GetBottom(document.BottomMargin) + tableFooter.TotalHeight;

            iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(432, 576);

            document = null;
            document = new Document(pagesize);

            document.SetMargins(5f, 72f, 105f, marginBottom);
        }
    }
}
