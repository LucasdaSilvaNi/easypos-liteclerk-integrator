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
        public RepSalesReportStockWithdrawalReportForm(String filePath, List<Entities.RepSalesReportTrnCollectionEntity> collectionLists)
        {
            InitializeComponent();
            PrintStockWithdrawalReport(filePath, collectionLists);
        }

        public void PrintStockWithdrawalReport(String filePath, List<Entities.RepSalesReportTrnCollectionEntity> collectionLists)
        {
            try
            {
                iTextSharp.text.Font fontArial09 = FontFactory.GetFont("Arial", 09);
                iTextSharp.text.Font fontArial09Italic = FontFactory.GetFont("Arial", 09, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontArial0Italic = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontArial10 = FontFactory.GetFont("Arial", 10);
                iTextSharp.text.Font fontArial10Bold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontArial14Bold = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);

                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.DARK_GRAY, Element.ALIGN_MIDDLE, 10F)));

                Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

                var fileName = filePath + "StockWithdrawalReport" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(432, 576);

                Document document = new Document(pagesize);
                document.SetMargins(5f, 72f, 5f, 5f);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

                document.Open();

                if (collectionLists.Any())
                {
                    foreach (var collectionList in collectionLists)
                    {
                        var collection = from d in db.TrnCollections where d.Id == collectionList.Id select d;

                        pdfWriter.PageEvent = new CollectionHeaderFooter(currentUser.FirstOrDefault().Id, collectionList.Id);

                        PdfPTable tableItem = new PdfPTable(3);
                        tableItem.SetWidths(new float[] { 100f, 20f, 30f });
                        tableItem.WidthPercentage = 100;
                        tableItem.AddCell(new PdfPCell(new Phrase(" ", fontArial10Bold)) { Border = 0, Colspan = 3, PaddingTop = -20f });
                        tableItem.AddCell(new PdfPCell(new Phrase("Description", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                        tableItem.AddCell(new PdfPCell(new Phrase("Qty.", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                        tableItem.AddCell(new PdfPCell(new Phrase("Unit", fontArial10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });

                        if (collection.FirstOrDefault().TrnSale.TrnSalesLines.Any())
                        {
                            foreach (var salesItem in collection.FirstOrDefault().TrnSale.TrnSalesLines)
                            {
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.ItemDescription, fontArial10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Quantity.ToString("#,##0.00"), fontArial10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.MstUnit.Unit, fontArial10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                            }
                        }

                        document.Add(tableItem);
                        document.Add(line);

                        document.NewPage();
                    }
                }

                document.Close();

                Process.Start(fileName);
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
        public Data.easyposdbDataContext db;

        public CollectionHeaderFooter(Int32 currentUserId, Int32 currentCollectonId)
        {
            userId = currentUserId;
            collectonId = currentCollectonId;

            db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            var collection = from d in db.TrnCollections where d.Id == collectonId select d;

            iTextSharp.text.Font fontArial09 = FontFactory.GetFont("Arial", 09);
            iTextSharp.text.Font fontArial09Italic = FontFactory.GetFont("Arial", 09, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontArial0Italic = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontArial10 = FontFactory.GetFont("Arial", 10);
            iTextSharp.text.Font fontArial10Bold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontArial14Bold = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);

            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            Paragraph headerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(2F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));
            Paragraph footerLine = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 5F)));

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
            tableHeader.SetWidths(new float[] { 50f, 50f, 50f, 50f });
            tableHeader.DefaultCell.Border = 0;
            tableHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableHeader.AddCell(new PdfPCell(new Phrase(documentTitle, fontArial14Bold)) { Colspan = 2, Border = 0, Padding = 3f });
            tableHeader.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontArial10Bold)) { HorizontalAlignment = 2, Colspan = 2, Border = 0, Padding = 3f });
            tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 4 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Date: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(date, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Terminal: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(terminal, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Term: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(term, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase("User: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(user, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Due Date: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(dueDate, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase("Delivery Date: ", fontArial09)) { HorizontalAlignment = 2, Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(deliveryDate, fontArial09)) { Border = 0 });
            tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 4 });
            tableHeader.AddCell(new PdfPCell(new Phrase(customer, fontArial10Bold)) { Border = 0, Colspan = 4 });
            tableHeader.AddCell(new PdfPCell(new Phrase(address, fontArial10)) { Border = 0, Colspan = 4 });
            tableHeader.AddCell(new PdfPCell(new Phrase(headerLine)) { Border = 0, Colspan = 4 });
            tableHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 80, writer.DirectContent);

            PdfPTable tableFooter = new PdfPTable(2);
            tableFooter.SetWidths(new float[] { 50f, 50f });
            tableFooter.DefaultCell.Border = 0;
            tableFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableFooter.AddCell(new PdfPCell(new Phrase("Received by / Date Received:", fontArial0Italic)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase("_____________________")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontArial10Bold)) { Border = 0, PaddingTop = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase(ORFooter, fontArial10)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) - 10, writer.DirectContent);
        }
    }
}
