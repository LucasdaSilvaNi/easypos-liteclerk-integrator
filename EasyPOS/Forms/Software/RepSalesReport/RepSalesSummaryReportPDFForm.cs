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
    public partial class RepSalesSummaryReportPDFForm : Form
    {
        public DateTime dateStart;
        public DateTime dateEnd;
        public Int32 filterTerminalId;
        public Int32 filterCustomerId;
        public Int32 filterSalesAgentId;

        public RepSalesSummaryReportPDFForm(DateTime startDate, DateTime endDate, Int32 terminalId, Int32 CustomerId, Int32 SalesAgentId)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;
            filterTerminalId = terminalId;
            filterCustomerId = CustomerId;
            filterSalesAgentId = SalesAgentId;

            PrintReport();
        }

        public void PrintReport()
        {
            try
            {
                Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

                iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
                iTextSharp.text.Font fontTimesNewRoman10Italic = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.5F, 100.0F, BaseColor.DARK_GRAY, Element.ALIGN_MIDDLE, 10F)));

                var fileName = "SalesSummaryReport" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                var currentUser = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;

                var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

                Document document = new Document(PageSize.LETTER.Rotate());
                document.SetMargins(30f, 30f, 100f, 30f);

                PdfWriter pdfWriter = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));
                pdfWriter.PageEvent = new ConfigureHeaderFooter(dateStart, dateEnd, filterTerminalId, filterCustomerId, filterSalesAgentId);

                document.Open();

                Controllers.RepSalesReportController repSalesSummaryReportController = new Controllers.RepSalesReportController();
                var salesList = repSalesSummaryReportController.SalesSummaryReport(dateStart, dateEnd, filterTerminalId, filterCustomerId, filterSalesAgentId);

                if (salesList.Any())
                {
                    PdfPTable tableLines = new PdfPTable(10);
                    tableLines.SetWidths(new float[] { 50f, 70f, 50f, 60f, 80f, 70f, 100f, 70f, 60f, 60f });
                    tableLines.WidthPercentage = 100;

                    Decimal totalAmount = 0;

                    foreach (var sales in salesList)
                    {
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.Terminal, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.SalesNumber, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.SalesDate, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.CustomerCode, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.Customer, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.Term, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.Remarks, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.SalesAgentUserName, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.Amount.ToString("#,##0.00"), fontTimesNewRoman10)) { HorizontalAlignment = 2, Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });
                        tableLines.AddCell(new PdfPCell(new Phrase(sales.EntryDateTime, fontTimesNewRoman10)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 0f });

                        totalAmount += Convert.ToDecimal(sales.Amount);
                    }

                    tableLines.AddCell(new PdfPCell(new Phrase(line)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = -5f, Colspan = 10 });
                    tableLines.AddCell(new PdfPCell(new Phrase("Total: ", fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, Colspan = 8, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(totalAmount.ToString("#,##0.00"), fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });
                    tableLines.AddCell(new PdfPCell(new Phrase(" ", fontTimesNewRoman10Bold)) { Border = 0, PaddingLeft = 3f, PaddingRight = 3f, PaddingTop = 3f, PaddingBottom = 20f, HorizontalAlignment = 2 });

                    document.Add(tableLines);
                    document.Close();

                    //ProcessStartInfo info = new ProcessStartInfo(fileName)
                    //{
                    //    Verb = "Print",
                    //    CreateNoWindow = true,
                    //    WindowStyle = ProcessWindowStyle.Hidden
                    //};

                    //Process printDwg = new Process
                    //{
                    //    StartInfo = info
                    //};

                    //printDwg.Start();
                    //printDwg.Close();


                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        class ConfigureHeaderFooter : PdfPageEventHelper
        {
            public DateTime dateStart;
            public DateTime dateEnd;
            public Int32 filterTerminalId;
            public Int32 filterCustomerId;
            public Int32 filterSalesAgentId;

            public Data.easyposdbDataContext db;

            public ConfigureHeaderFooter(DateTime startDate, DateTime endDate, Int32 terminalId, Int32 CustomerId, Int32 SalesAgentId)
            {
                dateStart = startDate;
                dateEnd = endDate;
                filterTerminalId = terminalId;
                filterCustomerId = CustomerId;
                filterSalesAgentId = SalesAgentId;

                db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                iTextSharp.text.Font fontTimesNewRoman10 = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10);
                iTextSharp.text.Font fontTimesNewRoman10Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font fontTimesNewRoman14Bold = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD);

                Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 7F)));

                var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();

                String companyName = systemCurrent.CompanyName;
                String documentTitle = "Sales Summary Report";

                PdfPTable tableHeader = new PdfPTable(4);
                tableHeader.SetWidths(new float[] { 20f, 30f, 20f, 50f });
                tableHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tableHeader.AddCell(new PdfPCell(new Phrase(companyName, fontTimesNewRoman14Bold)) { Colspan = 2, Border = 0, Padding = 3f, PaddingBottom = 3f });
                tableHeader.AddCell(new PdfPCell(new Phrase(documentTitle, fontTimesNewRoman14Bold)) { HorizontalAlignment = 2, Colspan = 2, Border = 0, Padding = 3f, PaddingBottom = 3f });
                tableHeader.AddCell(new PdfPCell(new Phrase("From : " + dateStart.ToShortDateString() + " To: " + dateEnd.ToShortDateString() + "\n", fontTimesNewRoman10)) { Colspan = 4, Border = 0, Padding = 3f, PaddingBottom = -5f });

                PdfPTable tableLines = new PdfPTable(10);
                tableLines.SetWidths(new float[] { 50f, 70f, 50f, 60f, 80f, 70f, 100f, 70f, 60f, 60f });
                tableLines.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tableLines.AddCell(new PdfPCell(new Phrase(" \n", fontTimesNewRoman10Bold)) { Border = 0, Colspan = 12, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Terminal", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Sales No.", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Date", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Code", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Customer", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Term", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Remarks", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Sales", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Amount", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableLines.AddCell(new PdfPCell(new Phrase("Date/Time", fontTimesNewRoman10Bold)) { HorizontalAlignment = 1, PaddingTop = 2f, PaddingBottom = 5f });
                tableHeader.AddCell(new PdfPCell(tableLines) { Border = 0, Colspan = 4, PaddingBottom = -5f, PaddingLeft = 0f, PaddingRight = 0f });
                tableHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin) + 67f, writer.DirectContent);
            }
        }
    }
}


