using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSDeliveryReceiptReportForm : Form
    {
        public Boolean isDeliveryReceipt;
        public Boolean isWithdrawalReceipt;
        public Boolean isDirectPrint;

        public TrnPOSDeliveryReceiptReportForm(String filePath, List<Entities.RepSalesReportCollectionSummaryReportEntity> collectionLists, Boolean filterIsDeliveryReceipt, Boolean filterisWithdrawalReceipt, Boolean filterIsDirectPrint)
        {
            InitializeComponent();
            isDeliveryReceipt = filterIsDeliveryReceipt;
            isWithdrawalReceipt = filterisWithdrawalReceipt;
            isDirectPrint = filterIsDirectPrint;

            PrintStockWithdrawalReport(collectionLists);
        }

        public void PrintStockWithdrawalReport(List<Entities.RepSalesReportCollectionSummaryReportEntity> collectionLists)
        {
            try
            {
                iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
                iTextSharp.text.Font fontTimesNewRoman10Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTimesNewRoman11 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 11);
                iTextSharp.text.Font fontTimesNewRoman11Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
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
                tableFooter.AddCell(new PdfPCell(new Phrase("Received by / Date Received:", fontTimesNewRoman10Italic)) { Border = 0, Padding = 3f, Colspan = 2 });
                tableFooter.AddCell(new PdfPCell(new Phrase("_____________________")) { Border = 0, PaddingTop = 25f });
                tableFooter.AddCell(new PdfPCell(new Phrase("")) { Border = 0, PaddingTop = 25f });
                tableFooter.AddCell(new PdfPCell(new Phrase("No.: ", fontTimesNewRoman11Bold)) { Border = 0, Padding = 3f, Colspan = 2 });
                tableFooter.AddCell(new PdfPCell(new Phrase(ORFooter, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 3f, Colspan = 2 });

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
                            if (isDeliveryReceipt == false)
                            {
                                foreach (var salesItem in collection.FirstOrDefault().TrnSale.TrnSalesLines)
                                {
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.ItemDescription, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Quantity.ToString("#,##0.00"), fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.MstUnit.Unit, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });

                                    totalAmount += salesItem.Amount;
                                }
                            }

                            else
                            {
                                foreach (var salesItem in collection.FirstOrDefault().TrnSale.TrnSalesLines)
                                {
                                    if (salesItem.MstDiscount.Discount == "Zero Discount")
                                    {
                                        tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.ItemDescription, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                    }
                                    else
                                    {
                                        tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.ItemDescription + " - " + salesItem.MstDiscount.Discount, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                    }
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Quantity.ToString("#,##0.00"), fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.MstItem.MstUnit.Unit, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Price.ToString("#,##0.00"), fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });
                                    tableItem.AddCell(new PdfPCell(new Phrase(salesItem.Amount.ToString("#,##0.00"), fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, HorizontalAlignment = 2 });

                                    totalAmount += salesItem.Amount;
                                }
                            }
                        }

                        if (isDeliveryReceipt == true)
                        {
                            tableItem.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = -5f, Colspan = colspan });
                            tableItem.AddCell(new PdfPCell(new Phrase("Total: " + totalAmount.ToString("#,##0.00"), fontTimesNewRoman11Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f, Colspan = colspan, HorizontalAlignment = 2 });
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

            iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
            iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontTimesNewRoman10Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontTimesNewRoman11 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 11);
            iTextSharp.text.Font fontTimesNewRoman11Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 11, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

            var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 7F)));

            String documentTitle = systemCurrent.ORPrintTitle;
            if (isDeliveryReceipt == false)
            {
                documentTitle = systemCurrent.WithdrawalPrintTitle;
            }
            String deliveryDate = collection.FirstOrDefault().CollectionDate.ToShortDateString();
            String term = collection.FirstOrDefault().TrnSale.MstTerm.Term;
            String dueDate = collection.FirstOrDefault().CollectionDate.AddDays(Convert.ToDouble(collection.FirstOrDefault().TrnSale.MstTerm.NumberOfDays)).Date.ToShortDateString();
            String terminal = collection.FirstOrDefault().MstTerminal.Terminal;
            String user = collection.FirstOrDefault().TrnSale.MstUser.UserName;
            String remarks = collection.FirstOrDefault().TrnSale.Remarks;

            String customer = collection.FirstOrDefault().MstCustomer.Customer;
            String address = collection.FirstOrDefault().MstCustomer.Address;

            String ORFooter = systemCurrent.ReceiptFooter;
            if (isDeliveryReceipt == false)
            {
                ORFooter = systemCurrent.WithdrawalFooter;
            }

            PdfPTable tableHeader = new PdfPTable(4);
            tableHeader.SetWidths(new float[] { 20f, 30f, 20f, 50f });
            tableHeader.DefaultCell.Border = 0;
            tableHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableHeader.LockedWidth = true;
            if (documentTitle.Length > 15)
            {
                tableHeader.AddCell(new PdfPCell(new Phrase(documentTitle, fontTimesNewRoman11Bold)) { Colspan = 3, Border = 0, Padding = 3f, PaddingBottom = 0f });
            }
            else
            {
                tableHeader.AddCell(new PdfPCell(new Phrase(documentTitle, fontTimesNewRoman14Bold)) { Colspan = 3, Border = 0, Padding = 3f, PaddingBottom = 0f });
            }
            tableHeader.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontTimesNewRoman11Bold)) { HorizontalAlignment = 2, Border = 0, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Date: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(deliveryDate, fontTimesNewRoman10)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Terminal: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(terminal, fontTimesNewRoman10)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Term: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(term, fontTimesNewRoman10)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("User: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(user, fontTimesNewRoman10)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Due Date: ", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(dueDate, fontTimesNewRoman10)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase("Remarks:", fontTimesNewRoman10Bold)) { Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(remarks, fontTimesNewRoman10)) { FixedHeight = 10f, Border = 0, Padding = 1f });
            tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.AddCell(new PdfPCell(new Phrase(customer, fontTimesNewRoman11Bold)) { Border = 0, Colspan = 4, Padding = 1f });

            tableHeader.AddCell(new PdfPCell(new Phrase(address, fontTimesNewRoman10)) { Border = 0, Colspan = 4, Rowspan = 2, Padding = 1f, FixedHeight = 22f });
            //tableHeader.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });

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
            tableItem.AddCell(new PdfPCell(new Phrase(" ", fontTimesNewRoman11Bold)) { Border = 0, Colspan = colspan, PaddingTop = -8f });
            tableItem.AddCell(new PdfPCell(new Phrase("Description", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            tableItem.AddCell(new PdfPCell(new Phrase("Qty.", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            tableItem.AddCell(new PdfPCell(new Phrase("Unit", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });

            if (isDeliveryReceipt == true)
            {
                tableItem.AddCell(new PdfPCell(new Phrase("Price", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableItem.AddCell(new PdfPCell(new Phrase("Amount", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableItem.AddCell(new PdfPCell(new Phrase("Discount", fontTimesNewRoman11Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
            }

            tableHeader.AddCell(new PdfPCell(tableItem) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 127f, writer.DirectContent);

            PdfPTable tableFooter = new PdfPTable(2);
            tableFooter.SetWidths(new float[] { 50f, 50f });
            tableFooter.DefaultCell.Border = 0;
            tableFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            tableFooter.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, Colspan = 2, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
            tableFooter.AddCell(new PdfPCell(new Phrase("Received by / Date Received:", fontTimesNewRoman10Italic)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase("_____________________")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("")) { Border = 0, PaddingTop = 25f });
            tableFooter.AddCell(new PdfPCell(new Phrase("No.: " + collection.FirstOrDefault().CollectionNumber, fontTimesNewRoman11Bold)) { Border = 0, Padding = 3f, Colspan = 2 });
            tableFooter.AddCell(new PdfPCell(new Phrase(ORFooter, fontTimesNewRoman11)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 5f, PaddingBottom = 3f, Colspan = 2 });
            tableFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) + 5f, writer.DirectContent);

            float marginBottom = writer.PageSize.GetBottom(document.BottomMargin) + tableFooter.TotalHeight;

            iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(432, 576);

            document = null;
            document = new Document(pagesize);

            document.SetMargins(5f, 72f, 105f, marginBottom);
        }
    }
}
